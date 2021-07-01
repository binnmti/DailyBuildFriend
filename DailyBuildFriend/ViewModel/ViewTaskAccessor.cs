using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.ViewModel
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
            => Process.Start(task.GetFileName("Result.html"));

        internal static string Validation(this ViewTask task)
        {
            if (string.IsNullOrEmpty(task.TaskName)) return "名前がありません";
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            if (!Directory.Exists(task.LogPath)) return "ログパスが存在しません";
            return "";
        }

        internal static void Update(this ViewTask task)
        {
            task.UpdateDate = task.GetUpdateDate();
            task.LocalRevision = task.GetGitCommitId("");
            task.ServerRevision = task.GetGitCommitId("origin");
            task.Result = task.GetResult();
        }

        private static string GetGitCommitId(this ViewTask task, string branch)
            => Directory.Exists(task.ProjectPath) ? ProcessUtility.ProcessStart("git", task.ProjectPath, $"log -n 1 --format=%h {branch}").Replace("\n", "") : "-";

        private static string GetResult(this ViewTask task)
        {
            var fileName = task.GetFileName("Result.csv");
            return File.Exists(fileName) ? File.ReadLines(fileName).Skip(1).FirstOrDefault()?.Split(',')?.Skip(1).FirstOrDefault() ?? "" : "-";
        }

        private static string GetUpdateDate(this ViewTask task)
        {
            var fileName = task.GetFileName("Result.csv");
            return File.Exists(fileName) ? File.GetLastWriteTime(fileName).ToString() : "-";
        }

        private static string GetFileName(this ViewTask task, string name)
            => Path.Combine(task.ProjectPath, task.FileName, task.FileName + name);
    }
}
