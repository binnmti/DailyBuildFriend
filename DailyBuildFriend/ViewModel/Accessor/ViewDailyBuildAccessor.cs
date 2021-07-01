using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using DailyBuildFriend.View;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewDailyBuildAccessor
    {
        internal static string ToJson(this ViewDailyBuild viewDailyBuild, bool indent)
            => JsonSerializer.Serialize(new DailyBuild()
            {
                Schedule = viewDailyBuild.ViewSchedule.ToSchedule(),
                Option = viewDailyBuild.ViewOption.ToOption(),
                Report = viewDailyBuild.ViewReport.ToReport(),
                Tasks = viewDailyBuild.ViewTasks.Select(x => x.ToTask()).ToList(),
            }, new JsonSerializerOptions { WriteIndented = indent });

        internal static ViewDailyBuild ToViewDailyBuild(string json)
        {
            var dailybuild = JsonSerializer.Deserialize<DailyBuild>(json) ?? new DailyBuild();
            return new ViewDailyBuild()
            {
                ViewTasks = dailybuild.Tasks.Select(x => x.ToViewTask()).ToList(),
                ViewOption = dailybuild.Option.ToViewOption(),
                ViewReport = dailybuild.Report.ToViewReport(),
                ViewSchedule = dailybuild.Schedule.ToViewSchedule(),
            };
        }

        //TODO:RunFormが引数なのはちょっと微妙だが、直接渡さないとデータをファイルに書き出してFormで読むなどの処理が必要。そういう仕組みを作ったら移行する
        internal static async System.Threading.Tasks.Task RunAsync(this ViewDailyBuild viewDailyBuild, RunForm runForm, CancellationToken token, RunType runType, string forceBuild)
        {
            var tasks = runType switch
            {
                RunType.Click => viewDailyBuild.ViewTasks.Where(x => x.Checked),
                RunType.Timer => viewDailyBuild.ViewTasks.Where(x => x.Timer.Checked),
                RunType.Interval => viewDailyBuild.ViewTasks.Where(x => x.Interval.Checked),
                _ => viewDailyBuild.ViewTasks.Where(x => x.Checked),
                //TODO:OnlyをやろうとするならSelectedが良い。
            };
            foreach (var (task,index) in tasks.Select((x,i) => (x,i)))
            {
                var data = new ViewDailyBuildRunResultSerivce.ResultData();

                string logPathName = Path.Combine(task.LogPath, task.FileName);
                string logFileName = Path.Combine(logPathName, task.FileName + "Result.log");
                //TODO:念のためやっている。バリデーションの中で必ずやることにすればいらない
                if (!Directory.Exists(logPathName)) Directory.CreateDirectory(logPathName);

                data.StartTime = DateTime.Now;
                data.Revision = task.LocalRevision;
                if (forceBuild != "")
                {
                    data.ReBuild = forceBuild == "リビルド";
                }
                else
                {
                    data.ReBuild = task.ViewCommands.SingleOrDefault(x => x.CommandType == CommandType.VisualStudioOpen)?.Param2 == "リビルド";
                }
                WriteFile(logFileName, false, "デイリービルド開始", true);
                runForm.SetTaskState($"{index + 1}/{tasks.Count()}");

                var commands = task.ViewCommands.Where(x => x.Checked);
                foreach (var (command, cIndex) in commands.Select((x, i) => (x, i)))
                {
                    runForm.SetMessage($"{task.TaskName}実行中", $"{task.TaskName}:{command.Name}中", $"内容:{command.Summary}", task.TimeOut.Time, task.ServerRevision, $"{cIndex + 1}/{commands.Count()}");
                    try
                    {
                        WriteFile(logFileName, true, $"{command.Name}開始", true);
                        switch (command.CommandType)
                        {
                            //TODO:GitPullは、強制リビジョン指定時に無視する必要がある。そういうコマンドにするか要設計
                            case CommandType.PullGit:
                                ProcessUtility.ProcessStart("git", Path.GetDirectoryName(command.Param1), "pull");
                                break;

                            case CommandType.VisualStudioOpen:
                                File.Create(Path.Combine(logPathName, task.FileName + "ErrWarning.log")).Close();
                                File.Create(Path.Combine(logPathName, task.FileName + "Warning.log")).Close();
                                File.Create(Path.Combine(logPathName, task.FileName + "Error.log")).Close();
                                break;

                            case CommandType.VisualStudioBuild:
                                var slnFile = task.ViewCommands.SingleOrDefault(x => x.CommandType == CommandType.VisualStudioOpen).Param1;
                                var logFile = Path.Combine(logPathName, task.FileName + "ErrWarning.log");
                                var rebuild = data.ReBuild ? "rebuild" : "build";
                                var arguments = $"\"{slnFile}\" /{rebuild} {command.Param1} /out \"{logFile}\"";
                                ProcessUtility.ProcessStart(viewDailyBuild.ViewOption.Devenv, Path.GetDirectoryName(slnFile), arguments);
                                data.BuildWarningCount += ViewDailyBuildRunResultSerivce.WriteFileFromKeyword(logFile, Path.Combine(logPathName, task.FileName + "Warning.log"), " warning ", command.Name, command.Param1);
                                data.BuildErrorCount += ViewDailyBuildRunResultSerivce.WriteFileFromKeyword(logFile, Path.Combine(logPathName, task.FileName + "Error.log"), " error ", command.Name, command.Param1);
                                break;

                                //TODO:MSBuildは要確認
                                //case CommandType.MSBuild:
                                //    //    var arguments = $"\"{slnFile}\" /t:{rebuild} /p:Configuration={command.Param1} /fileLogger /fileLoggerParameters:LogFile=\"{logFile}\"";
                                //    //    ProcessUtility.ProcessStart(ViewOptionAccessor.MSBuild, Path.GetDirectoryName(slnFile), arguments);
                                //    break;
                        }
                        WriteFile(logFileName, true, $"{command.Name}終了", true);
                    }
                    //他のプロセスで例外が起きたら、ログを残して、実行を中断する
                    catch (Exception ex)
                    {
                        WriteFile(logFileName, true, command.Name + "中断", false);
                        WriteFile(logFileName, true, "break!!", false);
                        using var exceptionLog = new StreamWriter(Path.Combine(logPathName, task.FileName + "Exception.log"));
                        exceptionLog.WriteLine("コマンド:" + command.Name);
                        exceptionLog.WriteLine(ex.Message);
                        exceptionLog.WriteLine(ex.StackTrace);
                        data.Break = command.Name + "中断";
                        break;
                    }
                    if (token.IsCancellationRequested) return;
                }
                data.EndTime = DateTime.Now;
                WriteFile(logFileName, true, "デイリービルド終了", true);
                WriteFile(logFileName, true, "finish!!", false);

                //TODO:ここでファイルアクセス出来ない場合など例外はどうするか
                data.WriteCsvFile(Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.csv"), task.TaskName);
                task.WriteHtmlFile();
            }
            //レポート送信
            if (viewDailyBuild.ViewReport.Checked && viewDailyBuild.ViewTasks.Any(x => x.Report.Checked))
            {
                var (subject, message) = viewDailyBuild.GetReportMessage();
                await viewDailyBuild.ViewReport.SendAsync(subject, message);
            }
        }

        private static void WriteFile(string file, bool append, string msg, bool time)
        {
            using var writer = new StreamWriter(file, append);
            writer.WriteLine(time ? $"{msg}:{DateTime.Now:G}" : msg);
        }
    }
}
