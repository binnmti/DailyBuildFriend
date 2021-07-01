using System;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class RunForm : Form
    {
        private string Title { get; set; } = "";
        private string Message1 { get; set; } = "";
        private string Message2 { get; set; } = "";
        private string TaskState { get; set; } = "";
        private int TimeOut { get; set; }
        private string CommandState { get; set; } = "";
        private string Revision { get; set; } = "";
        private DateTime Start = new DateTime();

        public RunForm()
        {
            InitializeComponent();
            Start = DateTime.Now;
            SetTime();
        }

        private void ShowMessage()
        {
            if (InvokeRequired) Invoke((MethodInvoker)(() => { ShowMessage(); }));
            else
            {
                Message1Label.Text = Message1;
                Message2Label.Text = Message2;
                CommandLabel.Text = CommandState;
                TaskLabel.Text = TaskState;
                RevisionLabel.Text = Revision;
                Text = Title;
                TimeOutTextBox.Text = TimeOut + "分";
            }
        }

        public void SetTaskState(string state)
        {
            TaskState = "タスク進行状況: " + state;
            ShowMessage();
        }

        public void SetCommandState(string state)
        {
            CommandState = "コマンド進行状況: " + state;
            ShowMessage();
        }

        public void SetMessage(string title, string msg1, string msg2, int timeOut, string revision, string co)
        {
            Title = title;
            Message1 = msg1;
            Message2 = msg2;
            TimeOut = timeOut;
            Revision = (revision == "-1") ? "-" : "リビジョン:" + revision;
            CommandState = "コマンド進行状況: " + co;

            ShowMessage();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            SuspensionButton.Enabled = false;
            MainForm.StopRunForm();
        }

        private void SetTime() => TimeTextBox.Text = new DateTime((DateTime.Now - Start).Ticks).ToLongTimeString();
        private void Timer1Tick(object sender, EventArgs e)
        {
            SetTime();
            //タイムアウト
            if(TimeOut > 0 && (DateTime.Now - Start).Minutes == TimeOut)
            {
                SuspensionButton.Enabled = false;
                MainForm.StopRunForm();
            }
        }
    }
}
