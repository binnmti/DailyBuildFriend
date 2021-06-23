namespace DailyBuildFriend.ViewModel
{
    public class TimeOut
    {
        public bool Check { get; set; }
        public int Time { get; set; }
        public string Result => Check ? $"{Time}分" : "-";
    }
}
