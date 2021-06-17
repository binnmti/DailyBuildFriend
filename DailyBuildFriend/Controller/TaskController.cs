using DailyBuildFriend.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace DailyBuildFriendWindowForm.Controller
{
    internal class TaskController
    {
        internal Task Task { get; private set; }

        internal void SetTaskName(string taskName) => Task.TaskName = taskName;
        internal void SetFileName(string fileName) => Task.FileName = fileName;
        internal void SetProjectPath(string path) => Task.FileName = path;
        internal void SetTimer(bool check) => Task.Timer = check;
        internal void SetInterval(bool check) => Task.Interval = check;
        internal void SetReport(bool check) => Task.Report = check;
        internal void SetTimeOut(bool check) => Task.TimeOut = check;
        internal void SetTimeOutTime(int time) => Task.TimeOutTime = time;

        internal string Validation()
        {
            if (!Regex.IsMatch(Task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!File.Exists(Task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }

        //{
        //    if (!File.Exists(path)) return false;
        //    Task.FileName = path;
        //    return true;
        //}
        //internal string ProjectPath { get => Task.ProjectPath; set => Task.ProjectPath = value; }
        //internal bool Timer { get => Task.Timer; set => Task.Timer = value; }
        //internal bool Interval { get => Task.Interval; set => Task.Interval = value; }
        //internal bool Report { get => Task.Report; set => Task.Report = value; }
        //internal bool TimeOut { get => Task.TimeOut; set => Task.TimeOut = value; }
        //internal int TimeOutTime { get => Task.TimeOutTime; set => Task.TimeOutTime = value; }
    }
}
