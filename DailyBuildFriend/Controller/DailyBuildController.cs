using DailyBuildFriend.Data;
using DailyBuildFriend.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DailyBuildFriend.Controller
{
    public class DailyBuildController
    {
        private readonly DailyBuildContext DailyBuildContext = new DailyBuildContext();

        internal IEnumerable<Task> GetTasks() => DailyBuildContext.Tasks;

        internal void AddTask(Task task) => DailyBuildContext.Tasks.Add(task);
        internal Task GetTask(int index) => DailyBuildContext.Tasks.ElementAtOrDefault(index);
        internal void RemoveTask(int index) => DailyBuildContext.Tasks.RemoveAt(index);
        internal void EditTask(int index, Task task) => DailyBuildContext.Tasks[index] = task;

        internal void Save(string fileName)
        {
            var jsonString = JsonSerializer.Serialize(DailyBuildContext.Tasks);
            File.WriteAllText(fileName, jsonString);
        }
        internal void Load(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            DailyBuildContext.Tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
        }
    }
}
