namespace DailyBuildFriend.Model
{
    public enum CommandType
    {
        CloneGit,
        VisualStudioBuild,
        VisualStudioTest,

        UpdateGit,
        RunBat,
        CopyFile,
        SendMail,
        SendSlack,
    }
}
