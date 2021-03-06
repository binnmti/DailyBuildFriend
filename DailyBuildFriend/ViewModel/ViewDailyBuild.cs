using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    internal record ViewDailyBuild
    {
        public List<ViewTask> ViewTasks { get; set; } = new List<ViewTask>();
        public ViewOption ViewOption { get; set; } = new ViewOption();
        public ViewReport ViewReport { get; set; } = new ViewReport();
        public ViewSchedule ViewSchedule { get; set; } = new ViewSchedule();
    }
}
