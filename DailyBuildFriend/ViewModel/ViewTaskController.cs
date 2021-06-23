using DailyBuildFriend.Model;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewTaskController
    {
        internal static ViewTask ToViewTask(this Task task)
            => new ViewTask()
            {
                Checked = task.Checked,
                FileName = task.FileName,
                Interval = new Check() { Checked = task.Interval },
                LocalRevision = task.LocalRevision,
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = new Check() { Checked = task.Report },
                ServerRevision = task.ServerRevision,
                TaskName = task.TaskName,
                TimeOut = new TimeOut() { Check = task.TimeOut, Time = task.TimeOutTime },
                Timer = new Check() { Checked = task.Timer },
                Update = task.Update,
                WorstTime = task.WorstTime,
                ViewCommands = task.Commands.Select(x => x.ToCommand()).ToList(),
            };

        internal static Task ToTask(this ViewTask task)
            => new Task()
            {
                Checked = task.Checked,
                FileName = task.FileName,
                Interval = task.Interval.Checked,
                LocalRevision = task.LocalRevision,
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = task.Report.Checked,
                ServerRevision = task.ServerRevision,
                TaskName = task.TaskName,
                TimeOut = task.TimeOut.Check,
                TimeOutTime = task.TimeOut.Time,
                Timer = task.Timer.Checked,
                Update = task.Update,
                WorstTime = task.WorstTime,
                Commands = task.ViewCommands.Select(x => x.ToCommand()).ToList(),
            };

        internal static string Validation(this ViewTask task)
        {
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }
    }
}
