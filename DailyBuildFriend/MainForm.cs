using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private DailyBuildController DailyBuildController { get; set; } = new DailyBuildController();

        public MainForm()
        {
            InitializeComponent();
        }

        private ListViewItem ToListViewItem(Task task)
        {
            var item = new ListViewItem(task.TaskName);
            item.SubItems.Add(task.FileName);

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
    }
}
