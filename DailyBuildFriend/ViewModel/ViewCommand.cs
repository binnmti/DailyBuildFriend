namespace DailyBuildFriend.ViewModel
{
    internal class ViewCommand
    {
        internal CommandType CommandType { get; set; }
        internal string Name { get; set; } = "";
        internal string Param1 { get; set; } = "";
        internal string Param2 { get; set; } = "";
        internal string Param1Description { get; set; } = "";
        internal string Param2Description { get; set; } = "";
        internal bool Checked { get; set; }
    }
}
