using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    public class ViewReport
    {
        internal ViewReport Clone() => (ViewReport)MemberwiseClone();
        public bool Check { get; set; }
        public string SuccessMessage { get; set; } = "デイリービルドが成功しました。";
        public string FailureMessage { get; set; } = "デイリービルドが失敗しました。";
        public string SlackUrl { get; set; } = "";
        public string SlackChannel { get; set; } = "";
        public List<ViewReportMember> ViewReportMembers { get; set; } = new List<ViewReportMember>();
    }
}
