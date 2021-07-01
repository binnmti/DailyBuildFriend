using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewTaskAccessor
    {
        internal static Task ToTask(this ViewTask task)
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

        internal static ViewTask ToViewTask(this Task task)
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
                ViewCommands = task.Commands.Select(x => x.ToViewCommand()).ToList(),
            };

        internal static void OpenLog(this ViewTask task)
            => Process.Start(Path.Combine(task.LogPath, "index.html"));

        internal static void OpenProject(this ViewTask task)
            => Process.Start(task.ProjectPath);
        
        internal static string Validation(this ViewTask task)
        {
            //TODO:タスク名の重複チェックをしたいが、この作りでは情報が足りてない
            if (string.IsNullOrEmpty(task.TaskName)) return "名前がありません";
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            if (task.LogPath != "" && !Directory.Exists(task.LogPath)) Directory.CreateDirectory(task.LogPath);
            return "";
        }

        internal static void Update(this ViewTask task)
        {
            task.ResultFileName = Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.csv");
            task.LocalRevision = task.GetGitCommitId("");
            task.ServerRevision = task.GetGitCommitId("origin");
            task.UpdateDate = task.GetUpdateDate();
            task.Result = task.GetResult();
        }

        private static string GetGitCommitId(this ViewTask task, string branch)
            //TODO:gitを直打ちしている
            => Directory.Exists(task.ProjectPath) ? ProcessUtility.ProcessStart("git", task.ProjectPath, $"log -n 1 --format=%h {branch}").Replace("\n", "") : "-";

        private static string GetResult(this ViewTask task)
            => File.Exists(task.ResultFileName) ? File.ReadLines(task.ResultFileName).Skip(1).FirstOrDefault()?.Split(',')?.Skip(1).FirstOrDefault() ?? "" : "";

        private static string GetUpdateDate(this ViewTask task)
            => File.Exists(task.ResultFileName) ? File.GetLastWriteTime(task.ResultFileName).ToString() : "-";
    }
}
