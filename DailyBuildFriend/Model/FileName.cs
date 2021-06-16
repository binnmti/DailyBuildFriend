using System.Text.RegularExpressions;

namespace DailyBuildFriend.Model
{
    //便宜上日本語を省く
    public class FileName
    {
        public string Name { get; init; }

        public static bool Validation(string name)
            => !Regex.IsMatch(name, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+");
    }
}
