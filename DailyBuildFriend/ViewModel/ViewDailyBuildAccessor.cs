using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewDailyBuildAccessor
    {
        internal static string ToJson(this ViewDailyBuild viewDailyBuild, bool indent)
            => DailyBuildAccessor.ToJson(new DailyBuild()
            {
                Schedule = viewDailyBuild.ViewSchedule.ToSchedule(),
                Option = viewDailyBuild.ViewOption.ToOption(),
                Report = viewDailyBuild.ViewReport.ToReport(),
                Tasks = viewDailyBuild.ViewTasks.Select(x => x.ToTask()).ToList(),
            }, indent);

        internal static ViewDailyBuild ToViewDailyBuild(string json)
        {
            var dailybuild = DailyBuildAccessor.ToDailyBuild(json);
            return new ViewDailyBuild()
            {
                ViewTasks = dailybuild.Tasks.Select(x => x.ToViewTask()).ToList(),
                ViewOption = dailybuild.Option.ToViewOption(),
                ViewReport = dailybuild.Report.ToViewReport(),
                ViewSchedule = dailybuild.Schedule.ToViewSchedule(),
            };
        }

        //TODO:RunFormが引数なのはちょっと微妙だが、直接渡さないとデータをファイルに書き出してFormで読むなどの処理が必要。そういう仕組みを作ったら移行する
        internal static void Run(this ViewDailyBuild viewDailyBuild, RunForm runForm, CancellationToken token, RunType runType, string forceBuild)
        {
            var tasks = runType switch
            {
                RunType.Click => viewDailyBuild.ViewTasks.Where(x => x.Checked),
                RunType.Timer => viewDailyBuild.ViewTasks.Where(x => x.Timer.Checked),
                RunType.Interval => viewDailyBuild.ViewTasks.Where(x => x.Interval.Checked),
                _ => viewDailyBuild.ViewTasks.Where(x => x.Checked),
                //TODO:OnlyをやろうとするならSelectedが良い。
            };
            foreach (var task in tasks)
            {
                var data = new RunResultSerivce.ResultData();

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
                FileUtility.Write(logFileName, false, "デイリービルド開始", true);
                foreach (var command in task.ViewCommands.Where(x => x.Check))
                {
                    runForm.SetMessage($"{task.TaskName}実行中", $"{task.TaskName}:{command.Name}中", $"内容:{command.Summary}", task.ServerRevision, "1");
                    try
                    {
                        FileUtility.Write(logFileName, true, $"{command.Name}開始", true);
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
                                data.BuildWarningCount += RunResultSerivce.WriteFileFromKeyword(logFile, Path.Combine(logPathName, task.FileName + "Warning.log"), " warning ", command.Name, command.Param1);
                                data.BuildErrorCount += RunResultSerivce.WriteFileFromKeyword(logFile, Path.Combine(logPathName, task.FileName + "Error.log"), " error ", command.Name, command.Param1);
                                break;
                            //case CommandType.MSBuild:
                            //    //    var arguments = $"\"{slnFile}\" /t:{rebuild} /p:Configuration={command.Param1} /fileLogger /fileLoggerParameters:LogFile=\"{logFile}\"";
                            //    //    ProcessUtility.ProcessStart(ViewOptionAccessor.MSBuild, Path.GetDirectoryName(slnFile), arguments);
                            //    break;
                        }
                        FileUtility.Write(logFileName, true, $"{command.Name}終了", true);
                    }
                    //他のプロセスで例外が起きたら、ログを残して、実行を中断する
                    catch (Exception ex)
                    {
                        FileUtility.Write(logFileName, true, command.Name + "中断", false);
                        FileUtility.Write(logFileName, true, "break!!", false);
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
                FileUtility.Write(logFileName, true, "デイリービルド終了", true);
                FileUtility.Write(logFileName, true, "finish!!", false);

                //TODO:ここでファイルアクセス出来ない場合はどうするか
                data.WriteCsvFile(Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.csv"), task.TaskName);
                WriteHtml(task);
            }
        }

        private static void WriteHtml(ViewTask task)
        {
            using var writer = new StreamWriter(Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.html"));
            writer.WriteLine("<html>");
            writer.WriteLine("<head><title>デイリービルド結果</title></head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table border='1'>");
            writer.WriteLine("<td>名前</td>");
            writer.WriteLine("<td>最新結果時間</td>");
            writer.WriteLine("<td>最新リビジョン</td>");
            writer.WriteLine("<td>エラー数</td>");
            writer.WriteLine("<td>警告数</td>");
            writer.WriteLine("<td>ビルド情報</td>");
            writer.WriteLine("<td>最終成功時間</td>");
            //フォルダの中にあるcsvのファイル名を回す
            foreach (var csvFile in Directory.GetFiles(Path.Combine(task.LogPath, task.FileName), "*.csv"))
            {
                writer.WriteLine("<tr>");
                var lines = File.ReadAllLines(csvFile);
                if (lines.Length >= 2)
                {
                    var cols = lines[1].Split(',');
                    var logFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.log");
                    //名前
                    var taskName = lines[0].Substring(lines[0].LastIndexOf(',') + 1);
                    writer.WriteLine($"<td><font size='5'>{taskName}</font></td>");
                    //ビルド中
                    if (!File.ReadAllText(logFile).Contains("finish!!"))
                    {
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font><a href='{logFile}'>（詳細）</a></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>ビルド中</font></td>");
                    }
                    //中断時
                    else if (cols[1].Contains("中断"))
                    {
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>{cols[7]}(中断)</font><a href='{logFile}'>（詳細）</a></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                    }
                    //成功時
                    else
                    {
                        var resultColor = cols[1].Contains("失敗") ? "FF0000" : "00FF00";
                        //最新結果時間
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{DateTime.Parse(cols[7]):yy/MM/dd HH:mm}</font><a href='{logFile}'>（詳細）</a></td>");
                        //リビジョン
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{cols[0]}</font></td>");
                        //エラー
                        int.TryParse(cols[2], out var error);
                        if (error == 0)
                        {
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>0</font></td>");
                        }
                        else
                        {
                            var errorFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "error.log");
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{error}</font><a href='{errorFile}'>（詳細）</a></td>");
                        }
                        //警告
                        int.TryParse(cols[3], out var warning);
                        if (warning == 0)
                        {
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>0</font></td>");
                        }
                        else
                        {
                            var warningFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "warning.log");
                            writer.WriteLine($"<td><font color='#D0D000' size='5'>{warning}</font><a href='{warningFile}'>（詳細）</a></td>");
                        }
                        //ビルド情報
                        string buildType = (cols[5] == "○") ? "リビルド" : "ビルド";
                        DateTime.TryParse(cols[8], out var buildTime);
                        int minute = (buildTime.Hour * 60 + buildTime.Minute != 0) ? (buildTime.Hour * 60 + buildTime.Minute) : 0;
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{buildType}約{minute}分</font></td>");
                    }
                    var line = lines.Skip(1).FirstOrDefault(x => x.Split(',')[1].Contains("成功"));
                    if (line != null)
                    {
                        var c = line.Split(',');
                        writer.WriteLine($"<td><font color='#00FF00' size='5'>{DateTime.Parse(c[7]):yy/MM/dd HH:mm} リビジョン:{c[0]}</font><a href='{csvFile}'>（詳細）</a></td>");
                    }
                    else
                    {
                        writer.WriteLine($"<td>-<a href='{csvFile}'>（詳細）</a></td>");
                    }
                }
                //情報未定義
                else
                {
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                }
            }
            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

    }
}
