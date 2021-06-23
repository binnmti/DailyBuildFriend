using DailyBuildFriend.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DailyBuildFriend.Model
{
    public static class TaskAccessor
    {
        internal static IEnumerable<Task> GetTasks() => DailyBuildContext.Tasks;
        internal static void AddTask(Task task) => DailyBuildContext.Tasks.Add(task);
        internal static Task GetTask(int index) => DailyBuildContext.Tasks.ElementAtOrDefault(index);
        internal static void RemoveTask(int index) => DailyBuildContext.Tasks.RemoveAt(index);
        internal static void ClearTask() => DailyBuildContext.Tasks.Clear();
        internal static void EditTask(int index, Task task) => DailyBuildContext.Tasks[index] = task;
        internal static void CheckTask(int index, bool check) => DailyBuildContext.Tasks[index].Check = check;
        internal static string GetJson(bool indent) => JsonSerializer.Serialize(DailyBuildContext.Tasks, new JsonSerializerOptions { WriteIndented = indent });
        internal static void SetJson(string json) => DailyBuildContext.Tasks = JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
    }
}
