namespace DailyBuildFriend.Model
{
    public enum CommandType
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
