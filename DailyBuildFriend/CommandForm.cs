using DailyBuildFriend.Controller;
using DailyBuildFriend.Model;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class CommandForm : Form
    {
        private Command Command = new Command();
        public CommandForm(Command command)
        {
            InitializeComponent();
            var viewCommand = CommandController.GetViewCommand(command.CommandType);

            Command = command;
            Command.Name = viewCommand.Name;
            CommandTextBox.Text = viewCommand.Name;
            Param1Label.Text = viewCommand.Param1Description;
            Param2Label.Text = viewCommand.Param2Description;
            Param1TextBox.Text = string.IsNullOrEmpty(command.Param1) ? viewCommand.Param1Default : command.Param1;
            Param2TextBox.Text = string.IsNullOrEmpty(command.Param2) ? viewCommand.Param2Default : command.Param2;
        }

        private void Param1TextBox_TextChanged(object sender, System.EventArgs e)
        {
            Command.Param1 = Param1TextBox.Text;
        }

        private void Param2TextBox_TextChanged(object sender, System.EventArgs e)
        {
            Command.Param2 = Param2TextBox.Text;
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
