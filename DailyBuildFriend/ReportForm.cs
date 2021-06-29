using DailyBuildFriend.ViewModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();

            var viewReport = ViewReportAccessor.GetViewReport();
            SlackChannelNameTextBox.Text = viewReport.SlackChannel;
            SuccessMessageTextBox.Text = viewReport.SuccessMessage;
            FailureMessageTextBox.Text = viewReport.FailureMessage;
            viewReport.ViewReportMembers.ForEach(x => ToListViewItem(x));
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

        private void MemberListView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private void MemberListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private void MemberListView_KeyUp(object sender, KeyEventArgs e)
        {
            var lv = (ListView)sender;
            if (e.KeyCode == Keys.F2 && lv.FocusedItem != null && lv.LabelEdit)
            {
                lv.FocusedItem.BeginEdit();
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            var li = new ListViewItem
            {
                Text = UserNameTextBox.Text
            };
            li.SubItems.Add(PasswordTextBox.Text);
            MemberListView.Items.Add(li);
        }

        private async void SuccessTestButton_Click(object sender, EventArgs e)
        {
            ViewReport viewReport = new ViewReport
            {
                SlackChannel = SlackChannelNameTextBox.Text,
                SuccessMessage = SuccessMessageTextBox.Text,
                FailureMessage = FailureMessageTextBox.Text,
                SlackUrl = slackHookUrlTextBox.Text,
                ViewReportMembers = MemberListView.Items.Cast<ListViewItem>().Select(x => ToViewReportMember(x)).ToList()
            };
            await ViewReportAccessor.SendAsync(viewReport);
        }

        private void SuccessMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FailureMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SlackChannelNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ViewReport viewReport = new ViewReport
            {
                SlackChannel = SlackChannelNameTextBox.Text,
                SuccessMessage = SuccessMessageTextBox.Text,
                FailureMessage = FailureMessageTextBox.Text,
                SlackUrl = slackHookUrlTextBox.Text,
                ViewReportMembers = MemberListView.Items.Cast<ListViewItem>().Select(x => ToViewReportMember(x)).ToList()
            };
            ViewReportAccessor.SetViewReport(viewReport);
        }
    }
}
