﻿using DailyBuildFriend.ViewModel;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class CommandForm : Form
    {
        private readonly ViewCommand Command = new ViewCommand();
        internal CommandForm(ViewCommand command)
        {
            InitializeComponent();

            Command = command;
            CommandTextBox.Text = Command.Name;
            Param1Label.Text = command.Param1Description;
            Param2Label.Text = command.Param2Description;
            Param1TextBox.Text = command.Param1;
            Param2TextBox.Text = command.Param2;
        }

        private void Param1TextBox_TextChanged(object sender, System.EventArgs e)
            => Command.Param1 = Param1TextBox.Text;

        private void Param2TextBox_TextChanged(object sender, System.EventArgs e)
            => Command.Param2 = Param2TextBox.Text;

        private void CommandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) return;
            var error = ViewCommandController.Validation(Command);
            if (string.IsNullOrEmpty(error)) return;

            MessageBox.Show(error);
            e.Cancel = true;
        }
    }
}
