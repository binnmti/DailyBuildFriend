using DailyBuildFriend.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.Controller
{
    internal class DailyBuildController
    {
        private List<Task> Tasks { get;  set; } = new List<Task>();

        internal void AddTask(Task task) => Tasks.Add(task);
        internal Task GetTask(int index) => Tasks.ElementAtOrDefault(index);
        internal void RemoveTask(int index) => Tasks.RemoveAt(index);
        internal void EditTask(int index, Task task)
        {
            Tasks.RemoveAt(index);
            Tasks.Insert(index, task);
        }


        internal Task Task { get; private set; } = new Task();

        internal void SetTaskName(string taskName) => Task.TaskName = taskName;
        internal void SetFileName(string fileName) => Task.FileName = fileName;
        internal void SetProjectPath(string path) => Task.ProjectPath = path;
        internal void SetTimer(bool check) => Task.Timer = check;
        internal void SetInterval(bool check) => Task.Interval = check;
        internal void SetReport(bool check) => Task.Report = check;
        internal void SetTimeOut(bool check) => Task.TimeOut = check;
        internal void SetTimeOutTime(int time) => Task.TimeOutTime = time;
        internal void AddCommand(Command command) => Task.Commands.Add(command);
        internal Command GetCommand(int index) => Task.Commands.ElementAt(index);
        internal void RemoveCommand(int index) => Task.Commands.RemoveAt(index);

        internal string Validation()
        {
            if (Regex.IsMatch(Task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(Task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }
    }
}
