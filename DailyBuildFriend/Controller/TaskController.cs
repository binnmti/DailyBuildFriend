using DailyBuildFriend.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace DailyBuildFriend.Controller
{
    internal class TaskController
    {
        internal static string Validation(Task task)
        {
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            return "";
        }
    }
}
