using DailyBuildFriend.Data;
using System.IO;
using System.Text.Json;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewOptionAccessor
    {
        internal static ViewOption GetViewOption() => DailyBuildContext.ViewOption;
        internal static void SetViewOption(ViewOption option) => DailyBuildContext.ViewOption = option;

        internal static string DevEnv => DailyBuildContext.ViewOption.Devenv;
        internal static string MSBuild => DailyBuildContext.ViewOption.MSBuild;

        internal static void Save(string fileName) => File.WriteAllText(fileName, JsonSerializer.Serialize(DailyBuildContext.ViewOption, new JsonSerializerOptions { WriteIndented = true }));
        internal static void Load(string fileName) => SetViewOption(JsonSerializer.Deserialize<ViewOption>(File.ReadAllText(fileName)));
    }
}
