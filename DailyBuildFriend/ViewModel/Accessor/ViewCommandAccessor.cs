using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewCommandAccessor
    {
        private static readonly Dictionary<CommandType, ViewCommand> Data = new Dictionary<CommandType, ViewCommand>()
        {
            { CommandType.PullGit, new ViewCommand() { Name = "Gitプル" , Param1Description = "Gitのパスを入力してください", Param2Disabled = true  } },
            { CommandType.CheckoutGit, new ViewCommand() { Name = "Gitチェックアウト" , Param1Description = "Gitのパスを入力してください", Param2Disabled = true  } },
            { CommandType.CloneGit, new ViewCommand() { Name = "Gitクローン" , Param1Description = "GitHubなどのURLを入力して下さい", Param2Description = "Gitのパスを入力してください" } },
            { CommandType.VisualStudioOpen, new ViewCommand() { Name = "VS起動" , Param1Description = "slnファイルを選択して下さい", Param2Description = "ビルドかリビルド", Param2 = "リビルド" }  },
            { CommandType.VisualStudioBuild, new ViewCommand() { Name = "VSビルド" , Param1Description = "ソリューション構成(Debug,Releaseなど)を入力してください", Param1 = "Release", Param2Disabled = true }  },
            { CommandType.VisualStudioTest, new ViewCommand() { Name = "VSテスト" , Param1Description = "dllファイルを選択して下さい", Param2Disabled = true } },
            { CommandType.RunBat, new ViewCommand() { Name = "バッチ実行" , Param1Description = "batファイルを選択して下さい", Param2Disabled = true } },
            { CommandType.CopyFile, new ViewCommand() { Name = "メール送信" , Param1Description = "コピー元を選択して下さい", Param2Description = "コピー先を選択して下さい" } },
            { CommandType.SendMail, new ViewCommand() { Name = "コピーファイル" , Param1Description = "",  Param2Disabled = true } },
            { CommandType.SendSlack, new ViewCommand() { Name = "Slack送信" , Param1Description = "",  Param2Disabled = true } },
        };

        internal static ViewCommand ToViewCommand(this Command command)
        {
            var data = Data.SingleOrDefault(x => x.Value.Name == command.Name);
            var viewCommand = Create(data.Key, "", "");
            viewCommand.CommandType = data.Key;
            viewCommand.Param1 = command.Param1;
            viewCommand.Param2 = command.Param2;
            viewCommand.Checked = command.Checked;
            return viewCommand;
        }

        internal static Command ToCommand(this ViewCommand command)
            => new Command() { Name = command.Name, Checked = command.Checked, Param1 = command.Param1, Param2 = command.Param2 };

        internal static ViewCommand Create(CommandType type, string param1, string param2)
            => new ViewCommand()
            {
                CommandType = type,
                Name = Data[type].Name,
                Param1 = string.IsNullOrEmpty(param1) ? Data[type].Param1 : param1,
                Param2 = string.IsNullOrEmpty(param2) ? Data[type].Param2 : param2,
                Param1Description = Data[type].Param1Description,
                Param2Description = Data[type].Param2Description,
                Param2Disabled = Data[type].Param2Disabled,
            };

        internal static string Validation(this ViewCommand command)
        {
            string msg = "";
            switch (command.CommandType)
            {
                case CommandType.CloneGit:
                    if (string.IsNullOrEmpty(command.Param1)) msg = "URLが未入力です";
                    else if (!Uri.IsWellFormedUriString(command.Param1, UriKind.Absolute)) msg = "URLが無効です";
                    else if (string.IsNullOrEmpty(command.Param2)) msg = "パスが未入力です";
                    else if (!Directory.Exists(command.Param2)) msg = "パスが存在しません";
                    break;

                case CommandType.VisualStudioTest:
                    if (File.Exists(command.Param1)) msg = "dllファイルが存在しません";
                    break;

                case CommandType.PullGit:
                    if (File.Exists(command.Param1)) msg = "slnファイルが存在しません";
                    break;
            }
            return msg;
        }
    }
}
