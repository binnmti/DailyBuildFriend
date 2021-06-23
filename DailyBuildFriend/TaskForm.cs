using DailyBuildFriend.ViewModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private readonly ViewTask ViewTask = new ViewTask();
        public TaskForm(ViewTask task)
        {
            InitializeComponent();
            TaskNameTextBox.Text = task.TaskName;
            FileNameTextBox.Text = task.FileName;
            ProjectPathTextBox.Text = task.ProjectPath;
            TimerCheckBox.Checked = task.Timer.Checked;
            IntervalCheckBox.Checked = task.Interval.Checked;
            ReportCheckBox.Checked = task.Report.Checked;
            TimeoutCheckBox.Checked = task.TimeOut.Check;
            TimeOutTimeNumericUpDown.Value = task.TimeOut.Time;
            CommandListView.BeginUpdate();
            task.ViewCommands.ToList().ForEach(x => CommandListView.Items.Add(ToListViewItem(x)));
            CommandListView.EndUpdate();
            ViewTask = task;
        }

        private static ListViewItem ToListViewItem(ViewCommand command)
        {
            var item = new ListViewItem(command.Name);
            item.SubItems.Add(command.Param1);
            item.Checked = command.Checked;
            return item;
        }

        private void AddCommand(ViewCommand command)
        {
            command.Checked = true;
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            CommandListView.Items.Add(ToListViewItem(command));
            ViewTask.ViewCommands.Add(command);
        }

        private void EditCommand()
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var command = ViewTask.ViewCommands[index];
            var form = new CommandForm(command);
            if (form.ShowDialog() != DialogResult.OK) return;

            CommandListView.Items[index] = ToListViewItem(command);
            ViewTask.ViewCommands[index] = command;
        }


        private void Task2Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = ViewTaskController.Validation(ViewTask);
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }


        private void TaskNameTextBox_TextChanged(object sender, EventArgs e)
            => ViewTask.TaskName = TaskNameTextBox.Text;

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
            => ViewTask.FileName = FileNameTextBox.Text;

        private void ProjectPathTextBox_TextChanged(object sender, EventArgs e)
            => ViewTask.ProjectPath = ProjectPathTextBox.Text;

        private void LogPathTextBox_TextChanged(object sender, EventArgs e)
            => ViewTask.LogPath = LogPathTextBox.Text;

        private void TimerCheckBox_CheckedChanged(object sender, EventArgs e)
            => ViewTask.Timer.Checked = TimerCheckBox.Checked;

        private void IntervalCheckBox_CheckedChanged(object sender, EventArgs e)
            => ViewTask.Interval.Checked = IntervalCheckBox.Checked;

        private void ReportCheckBox_CheckedChanged(object sender, EventArgs e)
            => ViewTask.Report.Checked = ReportCheckBox.Checked;

        private void TimeoutCheckBox_CheckedChanged(object sender, EventArgs e)
            => ViewTask.TimeOut.Check = TimeoutCheckBox.Checked;

        private void TimeOutTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
            => ViewTask.TimeOut.Time = (int)TimeOutTimeNumericUpDown.Value;

        private void AllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ViewTask.ViewCommands.ForEach(x => x.Checked = AllCheckBox.Checked);
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
                ViewTask.ViewCommands.RemoveAt(item.Index);
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
            => AddCommand(ViewCommandController.Create(CommandType.PullGit, ViewTask.ProjectPath, ""));

        private void GitCheckOutCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.CheckoutGit, ViewTask.ProjectPath, ""));

        private void GitCloneCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.CloneGit, "", ViewTask.ProjectPath));

        private void VSBuildToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.VisualStudioBuild, ViewTask.ProjectPath, ""));

        private void VsTestToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.VisualStudioTest, ViewTask.ProjectPath, ""));

        private void BatRunToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.RunBat, "", ""));

        private void MailSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.SendMail, "", ""));

        private void SlackSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandController.Create(CommandType.SendSlack, "", ""));
    }
}
