using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewTaskAccessor
    {
        internal static IEnumerable<ViewTask> GetTasks() => TaskAccessor.GetTasks().Select(x => x.ToViewTask());
        internal static ViewTask GetTask(int index) => TaskAccessor.GetTask(index).ToViewTask();
        internal static void RemoveTask(int index) => TaskAccessor.RemoveTask(index);
        internal static void ClearTask() => TaskAccessor.ClearTask();
        internal static string GetJson() => TaskAccessor.GetJson(false);
        internal static void Save(string fileName) => File.WriteAllText(fileName, TaskAccessor.GetJson(true));
        internal static void Load(string fileName) => TaskAccessor.SetJson(File.ReadAllText(fileName));
        internal static void EditTask(int index, ViewTask task) => TaskAccessor.EditTask(index, task.ToTask());
        internal static void AddTask(ViewTask task) => TaskAccessor.AddTask(task.ToTask());
        internal static void CheckTask(int index, bool check) => TaskAccessor.CheckTask(index, check);

        internal static void SetGitCommitId(ViewTask task)
        {
            task.LocalRevision = GetGitCommitId(task.ProjectPath, "");
            task.ServerRevision = GetGitCommitId(task.ProjectPath, "origin");
        }

        internal static string Validation(this ViewTask task)
        {
            if (string.IsNullOrEmpty(task.TaskName)) return "名前がありません";
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            if (!Directory.Exists(task.LogPath)) return "ログパスが存在しません";
            return "";
        }

        //TODO:RunFormが引数なのはちょっと微妙だが、直接渡さないとデータをファイルに書き出してFormで読むなどの処理が必要。そういう仕組みを作ったら移行する
        internal static void Run(RunForm runForm, CancellationToken token)
        {
            foreach (var task in GetTasks().Where(x => x.Checked))
            {
                ResultData data = new ResultData();

                string logPathName = Path.Combine(task.LogPath, task.FileName);
                string logFileName = Path.Combine(logPathName, task.FileName + "Result.log");

                //TODO:念のためだがバリデーションの中で必ずやることにすればいらない
                if (!Directory.Exists(Path.GetDirectoryName(logPathName))) Directory.CreateDirectory(Path.GetDirectoryName(logPathName));

                data.StartTime = DateTime.Now;
                data.Revision = task.LocalRevision;
                data.ReBuild = task.ViewCommands.SingleOrDefault(x => x.CommandType == CommandType.VisualStudioOpen)?.Param2 == "リビルド";

                FileUtility.Write(logFileName, false, "デイリービルド開始", true);
                foreach (var command in task.ViewCommands.Where(x => x.Check))
                {
                    runForm.SetMessage($"{task.TaskName}実行中", $"{task.TaskName}:{command.Name}中", $"内容:{command.Summary}", task.ServerRevision, "1");
                    try
                    {
                        FileUtility.Write(logFileName, true, $"{command.Name}開始", true);
                        switch (command.CommandType)
                        {
                            case CommandType.PullGit:
                                ProcessUtility.ProcessStart("git", Path.GetDirectoryName(command.Param1), "pull");
                                break;

                            case CommandType.VisualStudioOpen:
                                FileUtility.Write(Path.Combine(logPathName, task.FileName + "Warning.log"), false, "", true);
                                FileUtility.Write(Path.Combine(logPathName, task.FileName + "Error.log"), false, "", true);
                                break;

                            case CommandType.VisualStudioBuild:
                                command.RunVsBuild(task.ViewCommands);

                                var file = Path.Combine(logPathName, task.FileName + "ErrWarning.log");
                                data.BuildWarningCount += ErrWaningAnalyze(file, file, command.Name, command.Param1, " 警告 ");
                                data.BuildErrorCount += ErrWaningAnalyze(file, file, command.Name, command.Param1, " エラー ");
                                break;
                        }
                        FileUtility.Write(logFileName, true, $"{command.Name}終了", true);
                    }
                    //他のプロセスで例外が起きたら、ログを残して、実行を中断する
                    catch (Exception ex)
                    {
                        FileUtility.Write(logFileName, true, command.Name + "中断", false);
                        FileUtility.Write(logFileName, true, "break!!", false);
                        using var exceptionLog = new StreamWriter(Path.Combine(logPathName, task.FileName + "Exception.log"));
                        exceptionLog.WriteLine(command.Name);
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
                string csvFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.csv");
                WriteResultFile(csvFile, data);
            }
        }


        internal class ResultData
        {
            internal string Revision { get; set; } = "";
            internal bool ReBuild { get; set; }
            internal int BuildErrorCount { get; set; }
            internal int BuildWarningCount { get; set; }
            internal int TestErrorCount { get; set; }
            internal DateTime StartTime { get; set; }
            internal DateTime EndTime { get; set; }
            internal string Break { get; set; } = "";
        }

        private static void WriteResultFile(string resultFile, ResultData data)
        {
            var sb = new StringBuilder();
            //TODO:編集者を入れたい
            sb.AppendLine("リビジョン,結果,エラー,警告,テスト,リビルド,開始時間,終了時間,全時間,");
            sb.Append($"{data.Revision},");
            sb.Append(data.Break != "" ? "中断," : data.BuildErrorCount != 0 || data.TestErrorCount != 0 ? "失敗," : "成功,");
            sb.Append($"{data.BuildErrorCount},");
            sb.Append($"{data.BuildWarningCount},");
            sb.Append($"{data.TestErrorCount},");
            sb.Append(data.ReBuild ? "○," : "×,");
            sb.Append($"{data.StartTime:G},");
            sb.Append($"{data.EndTime:G},");
            if (data.Break != "")
            {
                sb.Append($"{data.Break},");
            }
            else
            {
                sb.Append($"{data.EndTime - data.StartTime:G},");
            }
            sb.AppendLine();
            if (File.Exists(resultFile)) sb.Append(string.Join("\n", File.ReadAllLines(resultFile).Skip(1)));
            File.WriteAllText(resultFile, sb.ToString());
        }

        private static int ErrWaningAnalyze(string logFileName, string saveFileName, string command, string param, string keyword)
        {
            int hit = 0;

            using var writer = new StreamWriter(saveFileName);
            writer.WriteLine("コマンド:" + command);
            writer.WriteLine("ターゲット:" + param);
            writer.WriteLine("//--------------------------------------------------------------------------");
            foreach (var line in File.ReadLines(logFileName).Where(x => x != keyword))
            {
                writer.WriteLine(line);
                hit++;
            }
            return hit;
        }

        private static ViewCommand ToViewCommand(this Command command)
            => new ViewCommand() { Name = command.Name, Check = command.Checked, Param1 = command.Param1, Param2 = command.Param2 };

        private static ViewTask ToViewTask(this Task task)
            => new ViewTask()
            {
                Checked = task.Check,
                FileName = task.FileName,
                Interval = new Check() { Checked = task.Interval },
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = new Check() { Checked = task.Report },
                TaskName = task.TaskName,
                TimeOut = new TimeOut() { Check = task.TimeOut, Time = task.TimeOutTime },
                Timer = new Check() { Checked = task.Timer },
                //TODO ログから取得 Update = task.Update,
                //TODO ログから取得 WorstTime = task.WorstTime,
                LocalRevision = GetGitCommitId(task.ProjectPath, ""),
                ServerRevision = GetGitCommitId(task.ProjectPath, "origin"),
                ViewCommands = task.Commands.Select(x => x.ToViewCommand()).ToList(),
            };

        private static Command ToCommand(this ViewCommand command)
            => new Command() { Name = command.Name, Checked = command.Check, Param1 = command.Param1, Param2 = command.Param2 };

        private static Task ToTask(this ViewTask task)
            => new Task()
            {
                Check = task.Checked,
                FileName = task.FileName,
                Interval = task.Interval.Checked,
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = task.Report.Checked,
                TaskName = task.TaskName,
                TimeOut = task.TimeOut.Check,
                TimeOutTime = task.TimeOut.Time,
                Timer = task.Timer.Checked,
                Commands = task.ViewCommands.Select(x => x.ToCommand()).ToList(),
            };

        private static string GetGitCommitId(string projectPath, string branch)
            => ProcessUtility.ProcessStart("git", projectPath, $"log -n 1 --format=%h {branch}").Replace("\n", "");
    }
}
