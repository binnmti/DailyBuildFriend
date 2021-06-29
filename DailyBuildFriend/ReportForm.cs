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
        }

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

        private void SuccessTestButton_Click(object sender, EventArgs e)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            foreach (var item in MemberListView.Items.Cast<ListViewItem>().Where(x => x.Checked))
            {
                smtp.Authenticate(item.Text.Substring(0, item.Text.IndexOf('@')), item.SubItems[1].Text);

                // 送信するメールを作成
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", "binmatsui@hotmail.com"));
                mail.To.Add(new MimeKit.MailboxAddress("", item.Text));
                mail.Subject = "デイリービルドフレンズ:成功連絡";
                builder.TextBody = SuccessMessageTextBox.Text;
                mail.Body = builder.ToMessageBody();
                // メールを送信
                smtp.Send(mail);
            }
            // SMTPサーバから切断
            smtp.Disconnect(true);
        }
    }
}
