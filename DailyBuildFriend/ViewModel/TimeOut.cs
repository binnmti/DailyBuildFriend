namespace DailyBuildFriend.ViewModel
{
    internal class TimeOut
    {
        public bool Checked { get; set; }
        public int Time { get; set; }
        public string Result => Checked ? $"{Time}分" : "-";
    }
}
