namespace DailyBuildFriend.ViewModel
{
    internal enum CommandType
    {
        PullGit,
        CheckoutGit,
        CloneGit,
        VisualStudioBuild,
        VisualStudioTest,

        RunBat,
        CopyFile,
        SendMail,
        SendSlack,
    }
}
