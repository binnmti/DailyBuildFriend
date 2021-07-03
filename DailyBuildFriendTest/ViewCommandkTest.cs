using DailyBuildFriend.ViewModel;
using DailyBuildFriend.ViewModel.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyBuildFriendTest
{
    [TestClass]
    public class ViewCommandkTest
    {
        [TestMethod]
        public void Gitプルを作る()
        {
            var command = ViewCommandAccessor.Create(CommandType.PullGit, "", "");
            command.Name.Is("Gitプル");
            command.Param1.Is("");
            command.Param2.Is("");
            command.Param1Description.Is("Gitのパスを入力してください");
            command.Param2Description.Is("");
            command.Param2Disabled.Is(true);
        }

        [TestMethod]
        public void VS起動を作る()
        {
            var command = ViewCommandAccessor.Create(CommandType.VisualStudioOpen, "", "");
            command.Name.Is("VS起動");
            command.Param1.Is("");
            command.Param2.Is("リビルド");
            command.Param1Description.Is("slnファイルを選択して下さい");
            command.Param2Description.Is("ビルドかリビルド");
            command.Param2Disabled.Is(false);
        }

        [TestMethod]
        public void Gitクローンをチェック()
        {
            var command = ViewCommandAccessor.Create(CommandType.CloneGit, "", "");
            command.Param1 = "";
            command.Validation().Is("URLが未入力です");
            command.Param1 = "URLではないもの";
            command.Validation().Is("URLが無効です");
            command.Param1 = "http://googole.co.jp";
            command.Param2 = "";
            command.Validation().Is("パスが未入力です");
            command.Param2 = @"C:\dailybuildTest";
            command.Validation().Is("パスが存在しません");
            command.Param2 = @"C:";
            command.Validation().Is();
        }
    }
}
