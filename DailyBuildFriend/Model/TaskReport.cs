using DailyBuildFriend.Data;

namespace DailyBuildFriend.Model
{
    public static class TaskReport
    {
        internal static void AddReport(Report report) => DailyBuildContext.Report = report;
        internal static Report GetReport() => DailyBuildContext.Report;
    }
}
