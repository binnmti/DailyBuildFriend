using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DailyBuildFriend.ViewModel
{
    internal static class RunResultSerivce
    {
        internal class ResultData
        {
            internal string Revision { get; set; } = "";
            internal bool ReBuild { get; set; }
            internal int BuildErrorCount { get; set; }
            internal int BuildWarningCount { get; set; }
            internal int TestErrorCount { get; set; }
            internal DateTime StartTime { get; set; }
            internal DateTime EndTime { get; set; }
            internal string Break { get; set; } = "";
        }

        internal static void WriteResult(this ResultData data, string resultFile)
        {
            var sb = new StringBuilder();
            //TODO:編集者を入れたい
            sb.AppendLine("リビジョン,結果,エラー,警告,テスト,リビルド,開始時間,終了時間,全時間,");
            sb.Append($"{data.Revision},");
            sb.Append(data.Break != "" ? "中断," : data.BuildErrorCount != 0 || data.TestErrorCount != 0 ? "失敗," : "成功,");
            sb.Append($"{data.BuildErrorCount},");
            sb.Append($"{data.BuildWarningCount},");
            sb.Append($"{data.TestErrorCount},");
            sb.Append(data.ReBuild ? "○," : "×,");
            sb.Append($"{data.StartTime:G},");
            sb.Append($"{data.EndTime:G},");
            if (data.Break != "")
            {
                sb.Append($"{data.Break},");
            }
            else
            {
                sb.Append($"{data.EndTime - data.StartTime:T},");
            }
            sb.AppendLine();
            if (File.Exists(resultFile)) sb.Append(string.Join("\n", File.ReadAllLines(resultFile).Skip(1)));
            File.WriteAllText(resultFile, sb.ToString());
        }
    }
}
