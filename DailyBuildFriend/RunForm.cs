using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class RunForm : Form
    {
        public RunForm()
        {
            InitializeComponent();
        }

        private string Title { get; set; } = "";
        private string Message1 { get; set; } = "";
        private string Message2 { get; set; } = "";
        private string TaskState { get; set; } = "";
        private string CommandState { get; set; } = "";
        private string Revision { get; set; } = "";

        private delegate void SetMessageDelegate();

        private void ShowMessage()
        {
            if (InvokeRequired)
            {
                Invoke(new SetMessageDelegate(ShowMessage));
            }
            else
            {
                Message1Label.Text = Message1;
                Message2Label.Text = Message2;
                CommandLabel.Text = CommandState;
                TaskLabel.Text = TaskState;
                RevisionLabel.Text = Revision;
                Text = Title;
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

        public void SetMessage(string title, string msg1, string msg2, string revision, string co)
        {
            Title = title;
            Message1 = msg1;
            Message2 = msg2;
            CommandState = "コマンド進行状況: " + co;
            Revision = (revision == "-1") ? "-" : "リビジョン:" + revision;
            ShowMessage();
        }

    }
}
