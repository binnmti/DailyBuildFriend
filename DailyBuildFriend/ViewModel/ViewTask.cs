using System;
using System.Collections.Generic;

namespace DailyBuildFriend.ViewModel
{
    public class ViewTask
    {
        public string TaskName { get; set; } = "";
        public string FileName { get; set; } = "";
        public string ProjectPath { get; set; } = "";
        public string LogPath { get; set; } = "";
        public bool Checked { get; set; }
        public DateTime Update { get; set; }
        public Check Timer { get; set; } = new Check();
        public Check Interval { get; set; } = new Check();
        public Check Report { get; set; } = new Check();
        public TimeOut TimeOut { get; set; } = new TimeOut();
        public DateTime WorstTime { get; set; }
        public string LocalRevision { get; set; } = "";
        public string ServerRevision { get; set; } = "";
        public List<ViewCommand> ViewCommands { get; set; } = new List<ViewCommand>();
    }
}
