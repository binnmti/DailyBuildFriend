using System;

namespace DailyBuildFriend.ViewModel
{
    class ViewSchedule
    {
        public bool Check { get; set; }
        public int Interval { get; set; } = 600;
        public DateTime Timer { get; set; } = new DateTime();
    }
}
