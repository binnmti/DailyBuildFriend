using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class CommandForm : Form
    {
        private readonly Command Command = new Command();
        public CommandForm(Command command)
        {
            InitializeComponent();

            Command = command;
            Command.Name = CommandController.GetName(command.CommandType);
            CommandTextBox.Text = Command.Name;
            Param1Label.Text = CommandController.GetParam1Description(command.CommandType);
            Param2Label.Text = CommandController.GetParam2Description(command.CommandType);
            Param1TextBox.Text = CommandController.GetParam1Default(command.CommandType, command.Param1);
            Param2TextBox.Text = CommandController.GetParam1Default(command.CommandType, command.Param2);
        }

        private void Param1TextBox_TextChanged(object sender, System.EventArgs e)
        {
            Command.Param1 = Param1TextBox.Text;
        }

        private void Param2TextBox_TextChanged(object sender, System.EventArgs e)
        {
            Command.Param2 = Param2TextBox.Text;
        }

        private void CommandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = CommandController.Validation(Command);
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }
    }
}
