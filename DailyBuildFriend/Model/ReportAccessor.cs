using DailyBuildFriend.Data;
using System.Text.Json;

namespace DailyBuildFriend.Model
{
    public static class ReportAccessor
    {
        internal static string GetJson(bool indent) => JsonSerializer.Serialize(DailyBuildContext.Report, new JsonSerializerOptions { WriteIndented = indent });
        internal static void SetJson(string json) => DailyBuildContext.Report = JsonSerializer.Deserialize<Report>(json) ?? new Report();
    }
}
