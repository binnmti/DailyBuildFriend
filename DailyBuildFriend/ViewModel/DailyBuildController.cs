using DailyBuildFriend.Data;
using DailyBuildFriend.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DailyBuildFriend.ViewModel
{
    public class DailyBuildController
    {
        private readonly DailyBuildContext DailyBuildContext = new DailyBuildContext();

        internal IEnumerable<ViewTask> GetTasks() => DailyBuildContext.Tasks.Select(x => x.ToViewTask());

        internal void AddTask(ViewTask task) => DailyBuildContext.Tasks.Add(task.ToTask());
        internal ViewTask GetTask(int index) => DailyBuildContext.Tasks.ElementAtOrDefault(index).ToViewTask();
        internal void RemoveTask(int index) => DailyBuildContext.Tasks.RemoveAt(index);
        internal void ClearTask() => DailyBuildContext.Tasks.Clear();
        internal void EditTask(int index, ViewTask task) => DailyBuildContext.Tasks[index] = task.ToTask();

        internal string GetJson() => JsonSerializer.Serialize(DailyBuildContext.Tasks);

        internal void Save(string fileName)
        {
            var jsonString = JsonSerializer.Serialize(DailyBuildContext.Tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
        }

        internal void Load(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            DailyBuildContext.Tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
        }
    }
}
