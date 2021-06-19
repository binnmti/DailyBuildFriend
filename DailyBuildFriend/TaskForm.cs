using DailyBuildFriend.Model;
using DailyBuildFriend.Controller;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace DailyBuildFriend
{
    public partial class TaskForm : Form
    {
        private Task Task = new Task();

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

        private ListViewItem ToListViewItem(Command command)
        {
            var item = new ListViewItem(command.Name);
            item.SubItems.Add(command.Param1);
            return item;
        }

        private string Validation(Task task)
        {
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
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

        private void AddCommandType(CommandType type)
        {
            AddCommand(new Command() { CommandType = type });
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

        private void OKButton_Click(object sender, EventArgs e)
        {
            var error = Validation(Task);
            if(!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }
            Close();
        }

        private void CommandListView_DoubleClick(object sender, EventArgs e)
        {

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

        private void RunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GitCloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCommandType(CommandType.CloneGit);
        }

        private void GitPullToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void VsBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void VsTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
