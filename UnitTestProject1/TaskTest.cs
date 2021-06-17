using DailyBuildFriend.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDailyBuildFriend
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void タスク成功()
        {
            var controller = new TaskController();

            controller.SetTaskName("デイリービルドフレンズ");
            controller.SetFileName("DailyBuildFriend");
            controller.SetProjectPath(@"C:\");

            controller.Validation().Is("");
        }

        [TestMethod]
        public void タスクパス間違い()
        {
            var controller = new TaskController();

            controller.SetTaskName("デイリービルドフレンズ");
            controller.SetFileName("DailyBuildFriend");
            controller.SetProjectPath(@"C:\DailyBuildFriend");
            controller.Validation().IsNot("");
        }
    }
}
