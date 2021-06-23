namespace DailyBuildFriend.ViewModel
{
    internal class TimeOut
    {
        public bool Check { get; set; }
        public int Time { get; set; }
        public string Result => Check ? $"{Time}分" : "-";
    }
}
