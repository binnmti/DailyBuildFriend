namespace DailyBuildFriendWindowForm
{
    interface INeedTask
    {
        public string TaskName { get; set; }
        public string FileName { get; set; }
        public string ProjectPath { get; set; }
        public bool Timer { get; set; }
        public bool Interval { get; set; }
        public bool Report { get; set; }
        public bool TimeOut { get; set; }
        public int TimeOutTime { get; set; }
    }
}
