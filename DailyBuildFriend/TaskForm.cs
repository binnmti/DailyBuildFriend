using DailyBuildFriend.Model;
using DailyBuildFriend.Controller;
using System;
using System.Windows.Forms;
using System.Linq;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private DailyBuildController TaskController { get; set; } = new DailyBuildController();
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

        private void GitCloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommand(CommandType.CloneGit);
        }

        private void CommandListView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void AddCommand(CommandType type)
        {
            AddCommand(new Command() { CommandType = type });
        }

        private void AddCommand(Command command)
        {
            var form = new CommandForm(command);
            if (form.ShowDialog() == DialogResult.OK)
            {
                TaskController.AddCommand(form.Command);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var command = TaskController.GetCommand(index);
            AddCommand(command);

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            TaskController.RemoveCommand(index);
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
