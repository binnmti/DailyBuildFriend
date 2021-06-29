using DailyBuildFriend.Model;
using DailyBuildFriend.ViewModel;
using System.Collections.Generic;

namespace DailyBuildFriend.Data
{
    internal static class DailyBuildContext
    {
        internal static List<Task> Tasks { get; set; } = new List<Task>();
        internal static Report Report { get; set; } = new Report();
        
        internal static ViewOption ViewOption { get; set; } = new ViewOption();
    }
}
