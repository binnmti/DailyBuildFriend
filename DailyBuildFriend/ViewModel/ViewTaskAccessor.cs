using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
            => ProcessUtility.ProcessStart("git", projectPath, $"log -n 1 --format=%h {branch}");
    }
}
