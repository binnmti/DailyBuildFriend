namespace DailyBuildFriend.ViewModel
{
    internal enum CommandType
    {
        PullGit,
        CheckoutGit,
        CloneGit,

        VisualStudioOpen,
        VisualStudioBuild,
        VisualStudioTest,

        RunBat,
        CopyFile,
        SendMail,
        SendSlack,
    }
}
