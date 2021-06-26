using System;
using System.IO;

namespace DailyBuildFriend.Utility
{
    public static class FileUtility
    {
        public static void Write(string file, bool append, string msg, bool time)
        {
            using var writer = new StreamWriter(file, append);
            writer.WriteLine(time ? $"{msg}:{DateTime.Now:G}" : msg);
        }
    }
}
