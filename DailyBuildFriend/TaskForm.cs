using DailyBuildFriend.Model;
using DailyBuildFriend.Controller;
using System;
using System.Windows.Forms;
using System.Linq;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private readonly Task Task = new Task();

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
            Task = task;
        }

        private ListViewItem ToListViewItem(Command command)
        {
            var item = new ListViewItem(command.Name);
            item.SubItems.Add(command.Param1);
            return item;
        }

        private void AddCommand(Command command)
        {
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            Task.Commands.Add(command);
            CommandListView.Items.Add(ToListViewItem(command));
        }

        private void EditCommand(int index, Command command)
        {
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            Task.Commands[index] = command;
            CommandListView.Items[index] = ToListViewItem(command);
        }

        private void TaskNameTextBoxTextChanged(object sender, EventArgs e)
        {
            Task.TaskName = TaskNameTextBox.Text;
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Task.FileName = FileNameTextBox.Text;
        }

        private void ProjectFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            Task.ProjectPath = ProjectFolderTextBox.Text;
        }

        private void TimerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Timer = TimerCheckBox.Checked;
        }

        private void IntervalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Interval = IntervalCheckBox.Checked;
        }

        private void ReportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Report = ReportCheckBox.Checked;
        }

        private void TimeoutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.TimeOut = TimeoutCheckBox.Checked;
        }

        private void TimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Task.TimeOutTime = (int)TimeoutNumericUpDown.Value;
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var command = Task.Commands[index];

            EditCommand(index, command);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommandListView.SelectedItems.Cast<ListViewItem>()
                .ToList()
                .ForEach(x => Task.Commands.RemoveAt(x.Index));
        }

        private void GitCloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommand(new Command() { CommandType = CommandType.CloneGit });
        }

        private void GitPullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommand(new Command() { CommandType = CommandType.PullGit });
        }

        private void VsBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommand(new Command() { CommandType = CommandType.VisualStudioBuild });
        }

        private void VsTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommand(new Command() { CommandType = CommandType.VisualStudioTest });
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = TaskController.Validation(Task);
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }
    }
}
