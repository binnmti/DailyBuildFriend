using System.Collections.Generic;

namespace DailyBuildFriend.Model
{
    public class Report
    {
        public bool Checked { get; set; }
        public string SuccessMessage { get; set; } = "";
        public string FailureMessage { get; set; } = "";
        public string SlackChannel { get; set; } = "";
        public string SlackUrl { get; set; } = "";
        public List<ReportMember> ReportMembers { get; set; } = new List<ReportMember>();
    }
}
