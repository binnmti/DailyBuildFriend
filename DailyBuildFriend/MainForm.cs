using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private string _fileName = "";

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
            return item;
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var task = new Task();
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            DailyBuildController.AddTask(task);
            TaskListView.Items.Add(ToListViewItem(task));
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in TaskListView.SelectedItems.Cast<ListViewItem>())
            {
                DailyBuildController.RemoveTask(item.Index);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var task = DailyBuildController.GetTask(index);
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            DailyBuildController.EditTask(index, task);
            TaskListView.Items[index] = ToListViewItem(task);
        }

        private void AddToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {

        }

        private void SaveFile(string fileName, bool bCheck)
        {
            DailyBuildController.Save(fileName);
            _fileName = fileName;
        }
        private void LoadFile(string fileName)
        {
            DailyBuildController.Load(fileName);
            DailyBuildController.GetTasks().ToList().ForEach(x => TaskListView.Items.Add(ToListViewItem(x)));
            _fileName = fileName;
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
    }
}
