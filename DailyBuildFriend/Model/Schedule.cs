using System;

namespace DailyBuildFriend.Model
{
    public class Schedule
    {
        public bool Check { get; set; }
        public int Interval { get; set; }
        public DateTime Timer { get; set; } = new DateTime();
    }
}
