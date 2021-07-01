using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    internal class ViewTask
    {
        internal ViewTask Clone() => (ViewTask)MemberwiseClone();
        internal string TaskName { get; set; } = "";
        internal string FileName { get; set; } = "";
        internal string ProjectPath { get; set; } = "";
        internal string LogPath { get; set; } = "";
        internal bool Checked { get; set; }
        internal string UpdateDate { get; set; } = "";
        internal Check Timer { get; set; } = new Check();
        internal Check Interval { get; set; } = new Check();
        internal Check Report { get; set; } = new Check();
        internal TimeOut TimeOut { get; set; } = new TimeOut();
        internal string LocalRevision { get; set; } = "";
        internal string ServerRevision { get; set; } = "";
        internal string ResultFileName { get; set; } = "";
        internal string Result { get; set; } = "";
        internal List<ViewCommand> ViewCommands { get; set; } = new List<ViewCommand>();
    }
}
