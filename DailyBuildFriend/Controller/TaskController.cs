using DailyBuildFriend.Model;

namespace DailyBuildFriendWindowForm.Controller
{
    internal class TaskController
    {
        internal Task Task { get; private set; }

        internal void SetTaskName(string taskName) => Task.TaskName = taskName;

        //internal string TaskName { get => Task.TaskName; set => Task.TaskName = value; }
        //internal string FileName { get => Task.FileName; set => Task.FileName = value; }
        //internal string ProjectPath { get => Task.ProjectPath; set => Task.ProjectPath = value; }
        //internal bool Timer { get => Task.Timer; set => Task.Timer = value; }
        //internal bool Interval { get => Task.Interval; set => Task.Interval = value; }
        //internal bool Report { get => Task.Report; set => Task.Report = value; }
        //internal bool TimeOut { get => Task.TimeOut; set => Task.TimeOut = value; }
        //internal int TimeOutTime { get => Task.TimeOutTime; set => Task.TimeOutTime = value; }
    }
}
