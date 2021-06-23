using DailyBuildFriend.Model;
using System.Collections.Generic;

namespace DailyBuildFriend.Data
{
    internal static class DailyBuildContext
    {
        internal static List<Task> Tasks { get; set; } = new List<Task>();
    }
}
