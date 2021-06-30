using DailyBuildFriend.Model;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewReportAccessor
    {
        internal static ViewReport ToViewReport(this Report report)
         => new ViewReport()
            {
                FailureMessage = report.FailureMessage,
                SuccessMessage = report.SuccessMessage,
                SlackChannel = report.SlackChannel,
                SlackUrl = report.SlackUrl,
                ViewReportMembers = report.ReportMembers
                    .Select(x => new ViewReportMember() { Check = x.Check, MailAddress = x.MailAddress, Password = x.Password })
                    .ToList(),
            };

        internal static Report ToReport(this ViewReport report)
             => new Report()
             {
                 FailureMessage = report.FailureMessage,
                 SuccessMessage = report.SuccessMessage,
                 SlackChannel = report.SlackChannel,
                 ReportMembers = report.ViewReportMembers
                            .Select(x => new ReportMember()
                            {
                                Check = x.Check,
                                MailAddress = x.MailAddress,
                                Password = x.Password
                            })
                            .ToList(),
             };


        internal static async System.Threading.Tasks.Task SendAsync(ViewReport viewReport)
        {
            SendMail(viewReport);
            await SendSlackAsync(viewReport);
        }

        private static void SendMail(ViewReport viewReport)
        {
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            foreach (var member in viewReport.ViewReportMembers.Where(x => x.Check))
            {
                smtp.Authenticate(member.MailAddress, member.Password);
                // 送信するメールを作成
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", "dailybuild@gmail.com"));
                mail.To.Add(new MimeKit.MailboxAddress("", member.MailAddress));
                mail.Subject = "デイリービルドフレンズ:成功連絡";
                builder.TextBody = viewReport.SuccessMessage;
                mail.Body = builder.ToMessageBody();
                smtp.Send(mail);
            }
            smtp.Disconnect(true);
        }


        public class SlackWebhook
        {
            public string channel { get; set; } = "";
            public string username { get; set; } = "";
            public string text { get; set; } = "";
            public string icon_emoji { get; set; } = "";
        }

        private static HttpClient HttpClient { get; set; } = new HttpClient();

        private static async System.Threading.Tasks.Task SendSlackAsync(ViewReport viewReport)
        {
            if (viewReport.SlackUrl == "") return;

            var slack = new SlackWebhook()
            {
                channel = "#notification",
                username = "DailyBuildAutomata",
                text = viewReport.SuccessMessage,
                icon_emoji = ":books:",
            };
            var json = JsonSerializer.Serialize(slack);
            await HttpClient.PostAsync(viewReport.SlackUrl, new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}
