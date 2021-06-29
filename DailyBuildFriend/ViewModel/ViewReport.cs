using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    public class ViewReport
    {
        public string SuccessMessage { get; set; } = "";
        public string FailureMessage { get; set; } = "";
        public string SlackUrl { get; set; } = "";
        public string SlackChannel { get; set; } = "";
        public List<ViewReportMember> ViewReportMembers { get; set; } = new List<ViewReportMember>();
    }
}
