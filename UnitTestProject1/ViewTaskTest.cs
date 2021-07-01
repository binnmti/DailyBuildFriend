using DailyBuildFriend.ViewModel;
using DailyBuildFriend.ViewModel.Accessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDailyBuildFriend
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
        public void タスクパス間違い()
        {
            var task = new ViewTask()
            {
                TaskName = "タスク",
                FileName = "File",
                ProjectPath = @"C:\DailyBuildFriend"
            };
            task.Validation().IsNot();
        }
    }
}
