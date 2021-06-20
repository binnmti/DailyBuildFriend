using DailyBuildFriend.Data;
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

        private static List<ViewCommand> Data = new List<ViewCommand>()
        {
            { new ViewCommand() { Name = "Gitクローン" , Param1Description = "GitHubなどのURLを入力して下さい", Param2Description = "Gitのパスを入力してください" } },
            { new ViewCommand() { Name = "Gitプル" , Param1Description = "Gitのパスを入力してください", Param2Description = "ブランチを入力してください" } },
            { new ViewCommand() { Name = "VisualStudioビルド" , Param1Description = "slnファイルを選択して下さい", Param2Description = "ビルドかリビルド" } },
            { new ViewCommand() { Name = "VisualStudioテスト" , Param1Description = "csprojファイルを選択して下さい", Param2Description = "" } },
            { new ViewCommand() { Name = "バッチ実行" , Param1Description = "batファイルを選択して下さい", Param2Description = "" } },
            { new ViewCommand() { Name = "コピーファイル" , Param1Description = "コピー元を選択して下さい", Param2Description = "コピー先を選択して下さい" } },
            { new ViewCommand() { Name = "メール送信" , Param1Description = "", Param2Description = "" } },
            { new ViewCommand() { Name = "Slack送信" , Param1Description = "", Param2Description = "" } },
        };

        internal static string GetName(CommandType type) => Data[(int)type].Name;
        internal static string GetParam1Description(CommandType type) => Data[(int)type].Name;
        internal static string GetParam2Description(CommandType type) => Data[(int)type].Name;
        internal static string GetParam1Default(CommandType type, string param) => string.IsNullOrEmpty(param) ? Data[(int)type].Param1Default : param;
        internal static string GetParam2Default(CommandType type, string param) => string.IsNullOrEmpty(param) ? Data[(int)type].Param2Default : param;


        internal string Validation(Command command)
        {
            string msg = "";
            switch(command.CommandType)
            {
                case CommandType.CloneGit:
                    if (Uri.IsWellFormedUriString(command.Param1, UriKind.Absolute))
                    {
                        msg = "URLが無効です";
                    }
                    if (Directory.Exists(command.Param2))
                    {
                        msg = "プロジェクトフォルダが存在しません";
                    }
                    break;

                case CommandType.PullGit:
                    if (File.Exists(command.Param1))
                    {
                        msg = "slnファイルが存在しません";
                    }
                    break;

            }
            return msg;
        }
    }

}
