namespace DailyBuildFriend.Model
{
    public enum CommandType
    {
        CloneGit,
        PullGit,
        VisualStudioBuild,
        VisualStudioTest,

        RunBat,
        CopyFile,
        SendMail,
        SendSlack,
    }
}
