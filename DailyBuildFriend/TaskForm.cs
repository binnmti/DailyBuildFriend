using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private readonly List<Task> Task = new List<Task>();

        public TaskForm(List<Task> task)
        {
            Task = task;
            InitializeComponent();
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
