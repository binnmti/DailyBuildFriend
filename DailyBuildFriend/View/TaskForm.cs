using DailyBuildFriend.ViewModel;
using DailyBuildFriend.ViewModel.Accessor;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend.View
{
    public partial class TaskForm : Form
    {
        //TODO:ドラッグしたら拡張子に合わせてコマンド追加をしたい。sln=VS起動など

        internal ViewTask ViewTask { get; set; } = new ViewTask();
        internal TaskForm(ViewTask task)
        {
            InitializeComponent();

            TaskNameTextBox.Text = task.TaskName;
            FileNameTextBox.Text = task.FileName;
            ProjectPathTextBox.Text = task.ProjectPath;
            LogPathTextBox.Text = task.LogPath;
            TimerCheckBox.Checked = task.Timer.Checked;
            IntervalCheckBox.Checked = task.Interval.Checked;
            ReportCheckBox.Checked = task.Report.Checked;
            TimeoutCheckBox.Checked = task.TimeOut.Checked;
            TimeOutTimeNumericUpDown.Value = task.TimeOut.Time;
            CommandListView.BeginUpdate();
            task.ViewCommands.ToList().ForEach(x => CommandListView.Items.Add(ToListViewItem(x)));
            CommandListView.EndUpdate();
            ViewTask = task.Clone();
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
            var form = new CommandForm(command, ProjectPathTextBox.Text);
            if (form.ShowDialog() != DialogResult.OK) return;

            command = form.Command;
            ViewTask.ViewCommands.Add(command);
            CommandListView.Items.Add(ToListViewItem(command));
        }

        private void EditCommand()
        {
            if (CommandListView.SelectedItems.Count == 0) return;

            var index = CommandListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var command = ViewTask.ViewCommands[index];
            var form = new CommandForm(command, ProjectPathTextBox.Text);
            if (form.ShowDialog() != DialogResult.OK) return;

            command = form.Command;
            CommandListView.Items[index] = ToListViewItem(command);
            ViewTask.ViewCommands[index] = command;
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = ViewTask.Validation();
            if (string.IsNullOrEmpty(error))
            {
                ViewTask.Update();
                return;
            }

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
            => ViewTask.TimeOut.Checked = TimeoutCheckBox.Checked;

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
            //foreach (var item in CommandListView.SelectedItems.Cast<ListViewItem>())
            //{
            //}
        }

        private bool doubleClickFlag;
        private void CommandListView_MouseDown(object sender, MouseEventArgs e)
        {
            doubleClickFlag = e.Clicks >= 2;
        }

        private void CommandListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (doubleClickFlag)
            {
                e.NewValue = e.CurrentValue;
                doubleClickFlag = false;
            }
            else
            {
                if (CommandListView.Items.Count == 0) return;

                var index = e.Index;
                ViewTask.ViewCommands[index].Checked = e.NewValue == CheckState.Checked;
            }
        }

        private void MoveCommand(int index, int nextIndex)
        {
            var command = ViewTask.ViewCommands[index];
            var item = CommandListView.Items[index];

            ViewTask.ViewCommands.Remove(command);
            ViewTask.ViewCommands.Insert(nextIndex, command);
            CommandListView.Items.Remove(item);
            CommandListView.Items.Insert(nextIndex, item);
        }

        private void UpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandListView.SelectedItems.Count == 0) return;
            var selectedItem = CommandListView.SelectedItems[0];
            if (selectedItem.Index == 0) return;
            MoveCommand(selectedItem.Index, selectedItem.Index - 1);
        }

        private void DownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CommandListView.SelectedItems.Count == 0) return;
            var selectedItem = CommandListView.SelectedItems[0];
            if (selectedItem.Index == CommandListView.Items.Count - 1) return;
            MoveCommand(selectedItem.Index, selectedItem.Index + 1);
        }

        private void GitPullToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.PullGit, "", ""));

        private void GitCheckOutCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.CheckoutGit, "", ""));

        private void GitCloneCToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.CloneGit, "", ""));

        private void VSBuildToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.VisualStudioBuild, "", ""));

        private void VsTestToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.VisualStudioTest, ViewTask.ProjectPath, ""));

        private void BatRunToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.RunBat, "", ""));

        private void MailSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.SendMail, "", ""));

        private void SlackSendToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.SendSlack, "", ""));

        private void VsOpenToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.VisualStudioOpen, "", ""));

        private void FileCopyToolStripMenuItem_Click(object sender, EventArgs e)
            => AddCommand(ViewCommandAccessor.Create(CommandType.CopyFile, ViewTask.ProjectPath, ""));
    }
}
