using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private readonly List<Task> Task = new List<Task>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TaskForm(Task);
            form.Show();
        }
    }
}
