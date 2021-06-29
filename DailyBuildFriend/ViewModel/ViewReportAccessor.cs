using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewReportAccessor
    {
        internal static ViewReport ViewReport = new ViewReport();
        internal static void SetViewReport(ViewReport viewReport) => ViewReport = viewReport;
        internal static ViewReport GetViewReport() => ViewReport;

        internal static async Task SendAsync(ViewReport viewReport)
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

                //smtp.Authenticate(member.MailAddress.Substring(0, member.MailAddress.IndexOf('@')), member.Password);

                // 送信するメールを作成
                var mail = new MimeKit.MimeMessage();
                var builder = new MimeKit.BodyBuilder();
                mail.From.Add(new MimeKit.MailboxAddress("", "dailybuild@gmail.com"));
                mail.To.Add(new MimeKit.MailboxAddress("", member.MailAddress));
                mail.Subject = "デイリービルドフレンズ:成功連絡";
                builder.TextBody = ViewReport.SuccessMessage;
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

        private static async Task SendSlackAsync(ViewReport viewReport)
        {
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
