using System.Diagnostics;

namespace DailyBuildFriend.Utility
{
    internal static class ProcessUtility
    {
        internal static string ProcessStart(string fileName, string workingDirectory, string arguments)
            => Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                WorkingDirectory = workingDirectory,
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
            }).StandardOutput.ReadToEnd();
    }
}
