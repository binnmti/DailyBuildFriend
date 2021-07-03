using DailyBuildFriend.ViewModel;
using DailyBuildFriend.ViewModel.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyBuildFriendTest
{
    [TestClass]
    public class ViewTaskTest
    {
        [TestMethod]
        public void タスク成功()
        {
            var task = new ViewTask()
            {
                TaskName = "タスク",
                FileName = "File",
                ProjectPath = @"C:\"
            };
            task.Validation().Is();
        }

        [TestMethod]
        public void タスク名前なし()
        {
            var task = new ViewTask()
            {
                TaskName = "",
            };
            task.Validation().Is("名前がありません");
        }

        [TestMethod]
        public void タスクファイル名に日本語()
        {
            var task = new ViewTask()
            {
                TaskName = "タスク",
                FileName = "あいうえお"
            };
            task.Validation().Is("ファイル名に日本語は使えません");
        }

        [TestMethod]
        public void タスクパス間違い()
        {
            var task = new ViewTask()
            {
                TaskName = "タスク",
                FileName = "File",
                ProjectPath = @"C:\DailyBuildFriend"
            };
            task.Validation().Is("プロジェクトパスが存在しません");
        }
    }
}
