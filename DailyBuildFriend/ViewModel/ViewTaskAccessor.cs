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
                UpdateDate = GetUpdateDate(Path.Combine(task.ProjectPath, task.FileName, task.FileName + "Result.csv")),
                LocalRevision = GetGitCommitId(task.ProjectPath, ""),
                ServerRevision = GetGitCommitId(task.ProjectPath, "origin"),
                Result = GetResult(Path.Combine(task.ProjectPath, task.FileName, task.FileName + "Result.csv")),
                ViewCommands = task.Commands.Select(x => x.ToViewCommand()).ToList(),
            };

        internal static void OpenLog(this ViewTask task)
            => Process.Start(Path.Combine(task.ProjectPath, task.FileName, task.FileName + "Result.html"));

        internal static string Validation(this ViewTask task)
        {
            if (string.IsNullOrEmpty(task.TaskName)) return "名前がありません";
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            if (!Directory.Exists(task.LogPath)) return "ログパスが存在しません";
            return "";
        }

        internal static ViewTask Update(this ViewTask task)
        {
            task.UpdateDate = GetUpdateDate(Path.Combine(task.ProjectPath, task.FileName, task.FileName + "Result.csv"));
            task.LocalRevision = GetGitCommitId(task.ProjectPath, "");
            task.ServerRevision = GetGitCommitId(task.ProjectPath, "origin");
            task.Result = GetResult(Path.Combine(task.ProjectPath, task.FileName, task.FileName + "Result.csv"));
            return task;
        }

        private static string GetGitCommitId(string projectPath, string branch)
            => ProcessUtility.ProcessStart("git", projectPath, $"log -n 1 --format=%h {branch}").Replace("\n", "");

        private static string GetResult(string fileName)
            => File.Exists(fileName) ? File.ReadLines(fileName).Skip(1).FirstOrDefault()?.Split(',')?.Skip(1).FirstOrDefault() ?? "" : "-";

        private static string GetUpdateDate(string fileName)
            => File.Exists(fileName) ? File.GetLastWriteTime(fileName).ToString() : "-";
    }
}
