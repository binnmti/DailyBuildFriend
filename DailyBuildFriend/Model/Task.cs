using System.Collections.Generic;

namespace DailyBuildFriend.Model
{
    public class Task
    {
        public bool Checked { get; set; }
        public string TaskName { get; set; } = "";
        public string FileName { get; set; } = "";
        public string ProjectPath { get; set; } = "";
        public string LogPath { get; set; } = "";
        public bool Timer { get; set; }
        public bool Interval { get; set; }
        public bool Report { get; set; }
        public bool TimeOut { get; set; }
        public int TimeOutTime { get; set; }
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}
