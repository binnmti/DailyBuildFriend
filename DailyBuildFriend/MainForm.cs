using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using DailyBuildFriend.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private string _fileName = "";
        private string _jsonString = "";

        private DailyBuildController DailyBuildController { get; set; } = new DailyBuildController();

        public MainForm()
        {
            InitializeComponent();
        }

        private ListViewItem ToListViewItem(Task task)
        {
            var item = new ListViewItem(task.TaskName);
            item.SubItems.Add(task.ProjectPath);
            item.SubItems.Add(TaskController.GetTimer(task.Timer));
            item.SubItems.Add(TaskController.GetInterval(task.Interval));
            item.SubItems.Add(TaskController.GetReport(task.Report));
            item.SubItems.Add(TaskController.GetTimeOut(task.TimeOut, task.TimeOutTime));
            item.Checked = true;
            return item;
        }

        private string GetTitle()
        {
            var title = $"デイリービルドフレンズ";
            if (!string.IsNullOrEmpty(_fileName)) title += $" - {Path.GetFileName(_fileName)}";
            if (_jsonString != DailyBuildController.GetJson()) title += "*";
            return title;
        }

        private void AddTask(Task task)
        {
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            DailyBuildController.AddTask(task);
            TaskListView.Items.Add(ToListViewItem(task));
            Text = GetTitle();
        }

        private void EditTask(int index, Task task)
        {
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            DailyBuildController.EditTask(index, task);
            TaskListView.Items[index] = ToListViewItem(task);
            Text = GetTitle();
        }


        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTask(new Task());
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in TaskListView.SelectedItems.Cast<ListViewItem>())
            {
                DailyBuildController.RemoveTask(item.Index);
                TaskListView.Items.Remove(item);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var task = DailyBuildController.GetTask(index);
            EditTask(index, task);
        }

        private void AddToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {

        }

        private void SaveFile(string fileName, bool bCheck)
        {
            DailyBuildController.Save(fileName);
            _fileName = fileName;
            _jsonString = DailyBuildController.GetJson();
            Text = GetTitle();
        }

        private void LoadFile(string fileName)
        {
            DailyBuildController.Load(fileName);
            DailyBuildController.GetTasks().ToList().ForEach(x => TaskListView.Items.Add(ToListViewItem(x)));
            _fileName = fileName;
            _jsonString = DailyBuildController.GetJson();
            Text = GetTitle();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                saveFileDialog1.ShowDialog();
            }
            else
            {
                SaveFile(_fileName, false);
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFile(saveFileDialog1.FileName, false);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadFile(openFileDialog1.FileName);
        }

        private void TaskListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void TaskListView_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length <= 0) return;

            AddTask(new Task
            {
                FileName = Path.GetFileNameWithoutExtension(files[0]),
                ProjectPath = files[0]
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Settings.Default.OpenFileName)) return;
            LoadFile(Settings.Default.OpenFileName);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.OpenFileName = _fileName;
            Settings.Default.Save();
        }

        private bool doubleClickFlag;
        private void TaskListView_MouseDown(object sender, MouseEventArgs e)
        {
            doubleClickFlag = e.Clicks >= 2;
        }

        private void TaskListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!doubleClickFlag) return;

            e.NewValue = e.CurrentValue;
            doubleClickFlag = false;
        }

        private void TaskListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var task = DailyBuildController.GetTask(index);
            EditTask(index, task);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskListView.Items.Clear();
            DailyBuildController.ClearTask();
            _fileName = "";
            Text = $"デイリービルドフレンズ";
        }

        private void NameSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(_fileName);
            saveFileDialog1.FileName = Path.GetFileName(_fileName);
            saveFileDialog1.ShowDialog();
        }

        private void TerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
