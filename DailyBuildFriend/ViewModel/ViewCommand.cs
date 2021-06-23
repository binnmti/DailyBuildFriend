namespace DailyBuildFriend.ViewModel
{
    public class ViewCommand
    {
        public CommandType CommandType { get; set; }
        public string Name { get; set; } = "";
        public string Param1 { get; set; } = "";
        public string Param2 { get; set; } = "";
        public string Param1Description { get; set; } = "";
        public string Param2Description { get; set; } = "";
        public bool Checked { get; set; }
    }
}
