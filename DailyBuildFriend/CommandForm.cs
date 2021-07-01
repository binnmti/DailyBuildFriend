using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class CommandForm : Form
    {
        internal ViewCommand Command { get; set; } = new ViewCommand();
        internal CommandForm(ViewCommand command)
        {
            InitializeComponent();

            CommandTextBox.Text = command.Name;
            Param1Label.Text = command.Param1Description;
            Param2Label.Text = command.Param2Description;
            Param1TextBox.Text = command.Param1;
            Param2TextBox.Text = command.Param2;
            Param2TextBox.Enabled = !command.Param2Disabled;
            Command = command.Clone();
        }

        private void Param1TextBox_TextChanged(object sender, System.EventArgs e)
            => Command.Param1 = Param1TextBox.Text;

        private void Param2TextBox_TextChanged(object sender, System.EventArgs e)
            => Command.Param2 = Param2TextBox.Text;

        private void CommandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = Command.Validation();
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }
    }
}
