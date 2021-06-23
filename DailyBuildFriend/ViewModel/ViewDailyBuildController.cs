using DailyBuildFriend.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DailyBuildFriend.ViewModel
{
    public class ViewDailyBuildController
    {
        private readonly DailyBuildController DailyBuildController = new DailyBuildController();

        internal IEnumerable<ViewTask> GetTasks() => DailyBuildController.GetTasks().Select(x => x.ToViewTask());
        internal void AddTask(ViewTask task) => DailyBuildController.AddTask(task.ToTask());
        internal ViewTask GetTask(int index) => DailyBuildController.GetTask(index).ToViewTask();
        internal void RemoveTask(int index) => DailyBuildController.RemoveTask(index);
        internal void ClearTask() => DailyBuildController.ClearTask();
        internal void EditTask(int index, ViewTask task) => DailyBuildController.EditTask(index, task.ToTask());
        internal string GetJson() => DailyBuildController.GetJson(false);
        internal void Save(string fileName) => File.WriteAllText(fileName, DailyBuildController.GetJson(true));
        internal void Load(string fileName) => DailyBuildController.SetJson(File.ReadAllText(fileName));
    }

    internal static class TaskConvert
    {
        private static ViewCommand ToViewCommand(this Command command)
            => new ViewCommand() { Name = command.Name, Checked = command.Checked, Param1 = command.Param1, Param2 = command.Param2 };

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
                ViewCommands = task.Commands.Select(x => x.ToViewCommand()).ToList(),
            };

        private static Command ToCommand(this ViewCommand command)
            => new Command() { Name = command.Name, Checked = command.Checked, Param1 = command.Param1, Param2 = command.Param2 };

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
    }
}
