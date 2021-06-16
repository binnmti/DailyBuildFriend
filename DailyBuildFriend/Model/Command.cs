namespace DailyBuildFriend.Model
{
    public class Command
    {
        public CommandType CommandType { get; set; }
        public string Name { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public bool Checked { get; set; }
    }
}
