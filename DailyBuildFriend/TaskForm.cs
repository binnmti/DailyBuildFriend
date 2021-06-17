using DailyBuildFriend.Model;
using DailyBuildFriendWindowForm.Controller;
using System;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private TaskController TaskController { get; set; }
        internal Task Task => TaskController.Task;

        public TaskForm(Task task)
        {
            InitializeComponent();
            TaskNameTextBox.Text = task.TaskName;
            FileNameTextBox.Text = task.FileName;
            ProjectFolderTextBox.Text = task.ProjectPath;
            TimeoutCheckBox.Checked = task.TimeOut;
            IntervalCheckBox.Checked = task.Interval;
            ReportCheckBox.Checked = task.Report;
            TimeoutCheckBox.Checked = task.TimeOut;
            TimeoutNumericUpDown.Value = task.TimeOutTime;
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TaskNameTextBoxTextChanged(object sender, EventArgs e)
        {
            TaskController.SetTaskName(TaskNameTextBox.Text);
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            TaskController.SetFileName(FileNameTextBox.Text);
        }

        private void ProjectFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            TaskController.SetProjectPath(ProjectFolderTextBox.Text);
        }

        private void TimerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TaskController.SetTimer(TimerCheckBox.Checked);
        }

        private void IntervalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TaskController.SetInterval(IntervalCheckBox.Checked);
        }

        private void ReportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TaskController.SetReport(ReportCheckBox.Checked);
        }

        private void TimeoutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TaskController.SetTimeOut(TimeoutCheckBox.Checked);
        }

        private void TimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TaskController.SetTimeOutTime((int)TimeoutNumericUpDown.Value);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var error = TaskController.Validation();
            if(!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }
            Close();
        }
    }
}
