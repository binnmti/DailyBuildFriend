namespace DailyBuildFriend.ViewModel
{
    internal class ViewCommand
    {
        internal ViewCommand Clone() => (ViewCommand)MemberwiseClone();

        internal CommandType CommandType { get; set; }
        internal string Name { get; set; } = "";
        internal string Param1 { get; set; } = "";
        internal string Param2 { get; set; } = "";
        internal string Param1Description { get; set; } = "";
        internal string Param2Description { get; set; } = "";
        internal bool Param1Disabled { get; set; }
        internal bool Param2Disabled { get; set; }
        internal string Summary { get; set; } = "";
        internal bool Checked { get; set; }
    }
}
