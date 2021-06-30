using System.Text.Json;

namespace DailyBuildFriend.Model
{
    internal static class DailyBuildAccessor
    {
        internal static string ToJson(this DailyBuild dailyBild, bool indent)
            => JsonSerializer.Serialize(dailyBild, new JsonSerializerOptions { WriteIndented = indent });

        internal static DailyBuild ToDailyBuild(string json)
            => JsonSerializer.Deserialize<DailyBuild>(json) ?? new DailyBuild();
    }
}
