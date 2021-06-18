using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
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

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TaskForm(new Task());
            if (form.ShowDialog() == DialogResult.OK) DailyBuildController.AddTask(form.Task);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            DailyBuildController.RemoveTask(index);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var form = new TaskForm(DailyBuildController.GetTask(index));
            if (form.ShowDialog() == DialogResult.OK) DailyBuildController.EditTask(index, form.Task);
        }

        private void AddToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {

        }
    }
}
