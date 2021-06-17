using DailyBuildFriend.Model;
using DailyBuildFriendWindowForm.Controller;
using System;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        internal TaskController TaskController { get; set; }

        public TaskForm(Task task)
        {
            InitializeComponent();
            TaskNameTextBox.Text = task.TaskName;
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TaskController.SetTaskName(TaskNameTextBox.Text);
        }
    }
}
