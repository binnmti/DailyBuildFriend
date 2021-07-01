using DailyBuildFriend.Model;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewReportAccessor
    {
        internal static ViewReport ToViewReport(this Report report)
         => new ViewReport()
            {
                Checked = report.Checked,
                FailureMessage = report.FailureMessage,
                SuccessMessage = report.SuccessMessage,
                SlackChannel = report.SlackChannel,
                SlackUrl = report.SlackUrl,
                ViewReportMembers = report.ReportMembers
                    .Select(x => new ViewReportMember() { Checked = x.Checked, MailAddress = x.MailAddress, Password = x.Password })
                    .ToList(),
            };

        internal static Report ToReport(this ViewReport report)
             => new Report()
             {
                 Checked = report.Checked,
                 FailureMessage = report.FailureMessage,
                 SuccessMessage = report.SuccessMessage,
                 SlackChannel = report.SlackChannel,
                 SlackUrl = report.SlackUrl,
                 ReportMembers = report.ViewReportMembers
                            .Select(x => new ReportMember()
                            {
                                Checked = x.Checked,
                                MailAddress = x.MailAddress,
                                Password = x.Password
                            })
                            .ToList(),
             };


        internal static async System.Threading.Tasks.Task SendAsync(this ViewReport viewReport, string subject, string message)
        {
            SendMail(viewReport, subject, message);
            await SendSlackAsync(viewReport, message);
        }

        private static void SendMail(ViewReport viewReport, string subject, string message)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            foreach (var member in viewReport.ViewReportMembers.Where(x => x.Checked))
            {
                smtp.Authenticate(member.MailAddress, member.Password);
                // 送信するメールを作成
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", "dailybuild@gmail.com"));
                mail.To.Add(new MimeKit.MailboxAddress("", member.MailAddress));
                mail.Subject = subject;
                builder.TextBody = message;
                mail.Body = builder.ToMessageBody();
                smtp.Send(mail);
            }
            smtp.Disconnect(true);
        }


        public class SlackWebhook
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "Slackの仕様")]
            public string channel { get; set; } = "";
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "Slackの仕様")]
            public string username { get; set; } = "";
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "Slackの仕様")]
            public string text { get; set; } = "";
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "Slackの仕様")]
            public string icon_emoji { get; set; } = "";
        }

        private static HttpClient HttpClient { get; set; } = new HttpClient();

        private static async System.Threading.Tasks.Task SendSlackAsync(ViewReport viewReport, string message)
        {
            if (viewReport.SlackUrl == "") return;

            var slack = new SlackWebhook()
            {
                channel = viewReport.SlackChannel,
                username = "DailyBuildAutomata",
                text = message,
                icon_emoji = ":books:",
            };
            var json = JsonSerializer.Serialize(slack);
            await HttpClient.PostAsync(viewReport.SlackUrl, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}
