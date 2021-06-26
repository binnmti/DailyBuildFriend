using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DailyBuildFriend.ViewModel
{
    //TODO:名前は再考
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

        internal static void WriteCsvFile(this ResultData data, string csvFileName)
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
            if (File.Exists(csvFileName)) sb.Append(string.Join("\n", File.ReadAllLines(csvFileName).Skip(1)));
            File.WriteAllText(csvFileName, sb.ToString());
        }

        //指定ファイルにあったキーワードから専用ファイルを作る
        internal static int WriteFileFromKeyword(string analyzeFileName, string writeFileName, string keyword, string command, string param)
        {
            int hit = 0;

            using var writer = new StreamWriter(writeFileName);
            writer.WriteLine("コマンド:" + command);
            writer.WriteLine("ソリューション構成:" + param);
            writer.WriteLine("//--------------------------------------------------------------------------");
            //TODO:devenvがSJISを吐くのでDefault。devenvへの文字コード指定は出来ない。一時バッチで対応するか。文字コード問題は考えねばならぬ。
            foreach (var line in File.ReadLines(analyzeFileName, Encoding.Default).Where(x => x.Contains(keyword)))
            {
                writer.WriteLine(line);
                hit++;
            }
            return hit;
        }
    }
}
