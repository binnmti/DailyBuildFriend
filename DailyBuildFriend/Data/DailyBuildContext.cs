using DailyBuildFriend.Model;
using System.Collections.Generic;

namespace DailyBuildFriend.Data
{
    internal class DailyBuildContext
    {
        internal List<Task> Tasks { get; set; } = new List<Task>();
    }
}
