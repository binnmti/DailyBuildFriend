using DailyBuildFriend.ViewModel;
using System.Collections.Generic;

namespace DailyBuildFriend.Data
{
    public static class ViewCommandData
    {
        //public enum CommandType


        public static List<ViewCommand> Data = new List<ViewCommand>()
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
    }
}
