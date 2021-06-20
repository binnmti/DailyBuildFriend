using DailyBuildFriend.Data;
using DailyBuildFriend.Model;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.Controller
{
    public class DailyBuildController
    {
        private readonly DailyBuildContext DailyBuildContext = new DailyBuildContext();

        internal void AddTask(Task task) => DailyBuildContext.Tasks.Add(task);
        internal Task GetTask(int index) => DailyBuildContext.Tasks.ElementAtOrDefault(index);
        internal void RemoveTask(int index) => DailyBuildContext.Tasks.RemoveAt(index);
        internal void EditTask(int index, Task task) => DailyBuildContext.Tasks[index] = task;
    }

}
