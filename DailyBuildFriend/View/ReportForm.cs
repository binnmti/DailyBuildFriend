using DailyBuildFriend.ViewModel;
using DailyBuildFriend.ViewModel.Accessor;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend.View
{
    public partial class ReportForm : Form
    {
        internal ViewReport ViewReport { get; set; } = new ViewReport();
        public ReportForm(ViewReport viewReport)
        {
            InitializeComponent();

            SlackHookUrlTextBox.Text = viewReport.SlackUrl;
            SlackChannelNameTextBox.Text = viewReport.SlackChannel;
            SuccessMessageTextBox.Text = viewReport.SuccessMessage;
            FailureMessageTextBox.Text = viewReport.FailureMessage;
            viewReport.ViewReportMembers.ForEach(x => ToListViewItem(x));
            ViewReport = viewReport.Clone();
        }

        private static ListViewItem ToListViewItem(ViewReportMember member)
        {
            var item = new ListViewItem(member.MailAddress);
            item.SubItems.Add(member.Password);
            item.Checked = member.Check;
            return item;
        }

        private static ViewReportMember ToViewReportMember(ListViewItem item)
            => new ViewReportMember() { Check = item.Checked, MailAddress = item.Text, Password = item.SubItems[1].Text };


        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var item = new ListViewItem
            {
                Text = UserNameTextBox.Text
            };
            MemberListView.Items.Add(item);
            ViewReport.ViewReportMembers = MemberListView.Items.Cast<ListViewItem>().Select(x => ToViewReportMember(x)).ToList();
        }

        private async void SuccessTestButton_Click(object sender, EventArgs e)
            => await ViewReportAccessor.SendAsync(ViewReport,"成功テスト", ViewReport.SuccessMessage);

        private void SuccessMessageTextBox_TextChanged(object sender, EventArgs e)
            => ViewReport.SuccessMessage = SuccessMessageTextBox.Text;

        private void FailureMessageTextBox_TextChanged(object sender, EventArgs e)
            => ViewReport.FailureMessage = FailureMessageTextBox.Text;

        private void SlackChannelNameTextBox_TextChanged(object sender, EventArgs e)
            => ViewReport.SlackChannel = SlackChannelNameTextBox.Text;

        private void SlackHookUrlTextBox_TextChanged(object sender, EventArgs e)
            => ViewReport.SlackUrl = SlackHookUrlTextBox.Text;

        private void OkButton_Click(object sender, EventArgs e)
        {
        }

    }
}
