using System.Collections.Generic;

namespace DailyBuildFriend.Model
{
    public class DailyBuild
    {
        public List<Task> Tasks { get; set; } = new List<Task>();
        public Option Option { get; set; } = new Option();
        public Report Report { get; set; } = new Report();
    }
}
