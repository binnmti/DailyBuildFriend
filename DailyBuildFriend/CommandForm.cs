using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class CommandForm : Form
    {
        //private TaskController TaskController { get; set; } = new TaskController();
        internal Command Command => new Command();
        public CommandForm(Command command)
        {
            InitializeComponent();
        }
    }
}
