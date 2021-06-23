using System;
using System.Collections.Generic;
using System.IO;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewCommandAccessor
    {
        private static readonly Dictionary<CommandType, ViewCommand> Data = new Dictionary<CommandType, ViewCommand>()
        {
            { CommandType.PullGit, new ViewCommand() { Name = "Gitプル" , Param1Description = "Gitのパスを入力してください"  } },
            { CommandType.CheckoutGit, new ViewCommand() { Name = "Gitチェックアウト" , Param1Description = "Gitのパスを入力してください"  } },
            { CommandType.CloneGit, new ViewCommand() { Name = "Gitクローン" , Param1Description = "GitHubなどのURLを入力して下さい", Param2Description = "Gitのパスを入力してください" } },
            { CommandType.VisualStudioBuild, new ViewCommand() { Name = "VSビルド" , Param1Description = "slnファイルを選択して下さい", Param2Description = "ビルドかリビルド", Param2 = "ビルド" }  },
            { CommandType.VisualStudioTest, new ViewCommand() { Name = "VSテスト" , Param1Description = "csprojファイルを選択して下さい", Param2Description = "" } },
            { CommandType.RunBat, new ViewCommand() { Name = "バッチ実行" , Param1Description = "batファイルを選択して下さい", Param2Description = "" } },
            { CommandType.CopyFile, new ViewCommand() { Name = "メール送信" , Param1Description = "コピー元を選択して下さい", Param2Description = "コピー先を選択して下さい" } },
            { CommandType.SendMail, new ViewCommand() { Name = "コピーファイル" , Param1Description = "", Param2Description = "" } },
            { CommandType.SendSlack, new ViewCommand() { Name = "Slack送信" , Param1Description = "", Param2Description = "" } },
        };

        internal static ViewCommand Create(CommandType type, string param1, string param2)
            => new ViewCommand()
            {
                CommandType = type,
                Name = Data[type].Name,
                Param1 = string.IsNullOrEmpty(param1) ? Data[type].Param1 : param1,
                Param2 = string.IsNullOrEmpty(param2) ? Data[type].Param2 : param2,
                Param1Description = Data[type].Param1Description,
                Param2Description = Data[type].Param2Description,
            };

        internal static string Validation(this ViewCommand command)
        {
            string msg = "";
            switch (command.CommandType)
            {
                case CommandType.CloneGit:
                    if (string.IsNullOrEmpty(command.Param1)) msg = "URLが未入力です";
                    if (string.IsNullOrEmpty(command.Param2)) msg = "パスが未入力です";
                    if (!Uri.IsWellFormedUriString(command.Param1, UriKind.Absolute)) msg = "URLが無効です";
                    if (!Directory.Exists(command.Param2)) msg = "パスが存在しません";
                    break;

                case CommandType.PullGit:
                    if (File.Exists(command.Param1)) msg = "slnファイルが存在しません";
                    break;

            }
            return msg;
        }
    }
}
