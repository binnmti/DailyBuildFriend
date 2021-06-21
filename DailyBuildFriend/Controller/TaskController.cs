using DailyBuildFriend.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.Controller
{
    internal class TaskController
    {
        internal static string GetTimer(bool timer) => timer ? "✔" : "-";
        internal static string GetInterval(bool interval) => interval ? "✔" : "-";
        internal static string GetReport(bool report) => report ? "✔" : "-";
        internal static string GetTimeOut(bool timeOut, int timeOutTime) => timeOut ? $"{timeOutTime}分" : "-";


        internal static string Validation(Task task)
        {
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }
    }
}
