using DailyBuildFriend.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DailyBuildFriend.Model
{
    public class DailyBuildController
    {
        private readonly DailyBuildContext Context = new DailyBuildContext();

        internal IEnumerable<Task> GetTasks() => Context.Tasks;
        internal void AddTask(Task task) => Context.Tasks.Add(task);
        internal Task GetTask(int index) => Context.Tasks.ElementAtOrDefault(index);
        internal void RemoveTask(int index) => Context.Tasks.RemoveAt(index);
        internal void ClearTask() => Context.Tasks.Clear();
        internal void EditTask(int index, Task task) => Context.Tasks[index] = task;
        internal string GetJson(bool indent) => JsonSerializer.Serialize(Context.Tasks, new JsonSerializerOptions { WriteIndented = indent });
        internal void SetJson(string json) => Context.Tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
    }
}
