using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System;
using System.Linq;
using System.Windows.Forms;

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
            ProjectPathTextBox.Text = task.ProjectPath;
            TimerCheckBox.Checked = task.Timer;
            IntervalCheckBox.Checked = task.Interval;
            ReportCheckBox.Checked = task.Report;
            TimeoutCheckBox.Checked = task.TimeOut;
            TimeOutTimeNumericUpDown.Value = task.TimeOutTime;
            CommandListView.BeginUpdate();
            task.Commands.ForEach(x => CommandListView.Items.Add(ToListViewItem(x)));
            CommandListView.EndUpdate();
            Task = task;
        }

        private static ListViewItem ToListViewItem(Command command)
        {
            var item = new ListViewItem(command.Name);
            item.SubItems.Add(command.Param1);
            item.Checked = command.Checked;
            return item;
        }

        private void AddCommand(Command command)
        {
            command.Checked = true;
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            Task.Commands.Add(command);
            CommandListView.Items.Add(ToListViewItem(command));
        }

        private void EditCommand()
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var command = Task.Commands[index];
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            Task.Commands[index] = command;
            CommandListView.Items[index] = ToListViewItem(command);
        }


        private void Task2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = TaskController.Validation(Task);
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }


        private void TaskNameTextBox_TextChanged(object sender, EventArgs e)
            => Task.TaskName = TaskNameTextBox.Text;

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
            => Task.FileName = FileNameTextBox.Text;

        private void ProjectPathTextBox_TextChanged(object sender, EventArgs e)
            => Task.ProjectPath = ProjectPathTextBox.Text;

        private void LogPathTextBox_TextChanged(object sender, EventArgs e)
            => Task.LogPath = LogPathTextBox.Text;

        private void TimerCheckBox_CheckedChanged(object sender, EventArgs e)
            => Task.Timer = TimerCheckBox.Checked;

        private void IntervalCheckBox_CheckedChanged(object sender, EventArgs e)
            => Task.Interval = IntervalCheckBox.Checked;

        private void ReportCheckBox_CheckedChanged(object sender, EventArgs e)
            => Task.Report = ReportCheckBox.Checked;

        private void TimeoutCheckBox_CheckedChanged(object sender, EventArgs e)
            => Task.TimeOut = TimeoutCheckBox.Checked;

        private void TimeOutTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
            => Task.TimeOutTime = (int)TimeOutTimeNumericUpDown.Value;

        private void AllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Commands.ForEach(x => x.Checked = AllCheckBox.Checked);
            CommandListView.Items.Cast<ListViewItem>().ToList().ForEach(x => x.Checked = AllCheckBox.Checked);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
            => EditCommand();

        private void CommandListView_MouseDoubleClick(object sender, MouseEventArgs e)
            => EditCommand();

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in CommandListView.SelectedItems.Cast<ListViewItem>())
            {
                Task.Commands.RemoveAt(item.Index);
                CommandListView.Items.Remove(item);
            }
        }

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in CommandListView.SelectedItems.Cast<ListViewItem>())
            {
            }
        }

        private void GitPullToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.PullGit, Param1 = Task.ProjectPath });

        private void GitCheckOutCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.CheckoutGit, Param1 = Task.ProjectPath });

        private void GitCloneCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.CloneGit, Param2 = Task.ProjectPath });

        private void VSBuildToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.VisualStudioBuild, Param1 = Task.ProjectPath });

        private void VsTestToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.VisualStudioTest, Param1 = Task.ProjectPath });

        private void BatRunToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.RunBat });

        private void MailSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.SendMail });

        private void SlackSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(new Command() { CommandType = CommandType.SendSlack });
    }
}
