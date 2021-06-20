using DailyBuildFriend.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace DailyBuildFriend.Controller
{
    internal class CommandController
    {
        private class ViewCommand
        {
            public string Name { get; set; } = "";
            public string Param1Default { get; set; } = "";
            public string Param2Default { get; set; } = "";
            public string Param1Description { get; set; } = "";
            public string Param2Description { get; set; } = "";
        }

        private static readonly Dictionary<CommandType, ViewCommand> Data = new Dictionary<CommandType, ViewCommand>()
        {
            { CommandType.CloneGit, new ViewCommand() { Name = "Gitクローン" , Param1Description = "GitHubなどのURLを入力して下さい", Param2Description = "Gitのパスを入力してください" } },
            { CommandType.PullGit, new ViewCommand() { Name = "Gitプル" , Param1Description = "Gitのパスを入力してください", Param2Description = "ブランチを入力してください" } },
            { CommandType.VisualStudioBuild, new ViewCommand() { Name = "VisualStudioビルド" , Param1Description = "slnファイルを選択して下さい", Param2Description = "ビルドかリビルド", Param2Default = "ビルド" }  },
            { CommandType.VisualStudioTest, new ViewCommand() { Name = "VisualStudioテスト" , Param1Description = "csprojファイルを選択して下さい", Param2Description = "" } },
            { CommandType.RunBat, new ViewCommand() { Name = "バッチ実行" , Param1Description = "batファイルを選択して下さい", Param2Description = "" } },
            { CommandType.CopyFile, new ViewCommand() { Name = "メール送信" , Param1Description = "コピー元を選択して下さい", Param2Description = "コピー先を選択して下さい" } },
            { CommandType.SendMail, new ViewCommand() { Name = "コピーファイル" , Param1Description = "", Param2Description = "" } },
            { CommandType.SendSlack, new ViewCommand() { Name = "Slack送信" , Param1Description = "", Param2Description = "" } },
        };

        internal static string GetName(CommandType type) => Data[type].Name;
        internal static string GetParam1Description(CommandType type) => Data[type].Param1Description;
        internal static string GetParam2Description(CommandType type) => Data[type].Param2Description;
        internal static string GetParam1Default(CommandType type, string param) => string.IsNullOrEmpty(param) ? Data[type].Param1Default : param;
        internal static string GetParam2Default(CommandType type, string param) => string.IsNullOrEmpty(param) ? Data[type].Param2Default : param;
        internal static string Validation(Command command)
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
