using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private readonly List<Task> Tasks = new List<Task>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var form = new TaskForm(Tasks[index]);
            if(form.ShowDialog() == DialogResult.OK)
            {
                Tasks[index] = form.Task;
            }
        }
    }
}
