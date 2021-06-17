using DailyBuildFriend.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.Controller
{
    internal class TaskController
    {
        internal Task Task { get; private set; } = new Task();

        internal void SetTaskName(string taskName) => Task.TaskName = taskName;
        internal void SetFileName(string fileName) => Task.FileName = fileName;
        internal void SetProjectPath(string path) => Task.ProjectPath = path;
        internal void SetTimer(bool check) => Task.Timer = check;
        internal void SetInterval(bool check) => Task.Interval = check;
        internal void SetReport(bool check) => Task.Report = check;
        internal void SetTimeOut(bool check) => Task.TimeOut = check;
        internal void SetTimeOutTime(int time) => Task.TimeOutTime = time;

        internal string Validation()
        {
            if (Regex.IsMatch(Task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(Task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }
    }
}
