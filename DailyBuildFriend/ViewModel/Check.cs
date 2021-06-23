namespace DailyBuildFriend.ViewModel
{
    public class Check
    {
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; Result = value ? "〇" : "×"; }
        }

        public string Result { get; private set; } = "";
    }
}
