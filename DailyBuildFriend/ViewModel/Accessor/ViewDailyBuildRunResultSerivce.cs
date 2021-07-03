using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DailyBuildFriend.ViewModel.Accessor
{
    internal static class ViewDailyBuildRunResultSerivce
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

        private enum CsvColumn
        {
            Revision,
            Result,
            BuildError,
            BuildWarning,
            TestError,
            Build,
            StateDate,
            EndDate,
            Priod,
            TaskName,
        }

        internal static void WriteCsvFile(this ResultData data, string csvFileName, string taskName)
        {
            var sb = new StringBuilder();
            //TODO:編集者を入れたい
            sb.AppendLine("リビジョン,結果,ビルドエラー,ビルド警告,テストエラー,リビルド,開始時間,終了時間,全時間," + taskName);
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

        internal static void WriteHtmlFile(this ViewTask task)
        {
            using var writer = new StreamWriter(Path.Combine(task.LogPath, "index.html"));
            writer.WriteLine("<html>");
            writer.WriteLine("<head><title>デイリービルド結果</title></head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table border='1'>");
            writer.WriteLine("<td>名前</td>");
            writer.WriteLine("<td>最新結果時間</td>");
            writer.WriteLine("<td>最新リビジョン</td>");
            writer.WriteLine("<td>ビルドエラー数</td>");
            writer.WriteLine("<td>テストエラー数</td>");
            writer.WriteLine("<td>ビルド警告数</td>");
            writer.WriteLine("<td>ビルド情報</td>");
            writer.WriteLine("<td>最終成功時間</td>");
            //フォルダの中にあるcsvのファイル名を回す
            foreach (var csvFile in Directory.GetFiles(task.LogPath, "*.csv", SearchOption.AllDirectories))
            {
                writer.WriteLine("<tr>");
                var lines = File.ReadAllLines(csvFile);
                if (lines.Length >= 2)
                {
                    var cols = lines[1].Split(',');
                    var logFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.log");
                    //名前
                    var taskName = lines[0].Substring(lines[0].LastIndexOf(',') + 1);
                    writer.WriteLine($"<td><font size='5'>{taskName}</font></td>");
                    //ビルド中
                    if (!File.ReadAllText(logFile).Contains("finish!!"))
                    {
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font><a href='{logFile}'>（詳細）</a></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>ビルド中</font></td>");
                    }
                    //中断時
                    else if (cols[(int)CsvColumn.Result].Contains("中断"))
                    {
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>{cols[(int)CsvColumn.EndDate]}(中断)</font><a href='{logFile}'>（詳細）</a></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                        writer.WriteLine($"<td><font color='#C0C0C0' size='5'>-</font></td>");
                    }
                    //成功時
                    else
                    {
                        var resultColor = cols[(int)CsvColumn.Result].Contains("失敗") ? "FF0000" : "00FF00";
                        //最新結果時間
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{DateTime.Parse(cols[(int)CsvColumn.EndDate]):yy/MM/dd HH:mm}</font><a href='{logFile}'>（詳細）</a></td>");
                        //リビジョン
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{cols[(int)CsvColumn.Revision]}</font></td>");
                        //ビルドエラー
                        int.TryParse(cols[(int)CsvColumn.BuildError], out var error);
                        if (error == 0)
                        {
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>0</font></td>");
                        }
                        else
                        {
                            var errorFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "error.log");
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{error}</font><a href='{errorFile}'>（詳細）</a></td>");
                        }
                        //テストエラー
                        int.TryParse(cols[(int)CsvColumn.TestError], out var testError);
                        if (testError == 0)
                        {
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>0</font></td>");
                        }
                        else
                        {
                            var testErrorFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "test.trx");
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{testError}</font><a href='{testErrorFile}'>（詳細）</a></td>");
                        }
                        //警告
                        int.TryParse(cols[(int)CsvColumn.BuildWarning], out var warning);
                        if (warning == 0)
                        {
                            writer.WriteLine($"<td><font color='#{resultColor}' size='5'>0</font></td>");
                        }
                        else
                        {
                            var warningFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "warning.log");
                            writer.WriteLine($"<td><font color='#D0D000' size='5'>{warning}</font><a href='{warningFile}'>（詳細）</a></td>");
                        }
                        //ビルド情報
                        string buildType = (cols[(int)CsvColumn.Build] == "○") ? "リビルド" : "ビルド";
                        DateTime.TryParse(cols[(int)CsvColumn.Priod], out var buildTime);
                        int minute = (buildTime.Hour * 60 + buildTime.Minute != 0) ? (buildTime.Hour * 60 + buildTime.Minute) : 0;
                        writer.WriteLine($"<td><font color='#{resultColor}' size='5'>{buildType}約{minute}分</font></td>");
                    }
                    var line = lines.Skip(1).FirstOrDefault(x => x.Split(',')[1].Contains("成功"));
                    if (line != null)
                    {
                        var c = line.Split(',');
                        writer.WriteLine($"<td><font color='#00FF00' size='5'>{DateTime.Parse(c[7]):yy/MM/dd HH:mm} リビジョン:{c[0]}</font><a href='{csvFile}'>（詳細）</a></td>");
                    }
                    else
                    {
                        writer.WriteLine($"<td>-<a href='{csvFile}'>（詳細）</a></td>");
                    }
                }
                //情報未定義
                else
                {
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                    writer.WriteLine("<td>-</td>");
                }
            }
            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        internal static (string, string) GetReportMessage(this ViewDailyBuild viewDailyBuild)
        {
            var sb = new StringBuilder();
            string nowState = "";
            string preState = "";
            int preErrorCounter = 0;
            int nowErrorCounter = 0;
            foreach (var task in viewDailyBuild.ViewTasks.Where(x => x.Report.Checked))
            {
                var lines = File.ReadAllLines(task.ResultFileName);
                if (lines.Length < 2) continue;
                nowState = lines[1].Split(',')[(int)CsvColumn.Result];
                nowErrorCounter = int.TryParse(lines[1].Split(',')[(int)CsvColumn.BuildError], out var error) ? error : 0;
                nowErrorCounter += int.TryParse(lines[1].Split(',')[(int)CsvColumn.TestError], out error) ? error : 0;
                //成功時は何の情報もいらないが、成功以外の場合は何処で失敗したかを知りたい。
                if (nowState != "成功")
                {
                    sb.AppendLine($"//--------------------------------------------------------------------------");
                    sb.AppendLine($"タスク名:{task.TaskName}:リビジョン:{task.LocalRevision}");
                    sb.AppendLine($"エラー数:{nowErrorCounter}:全時間:{DateTime.Parse(lines[1].Split(',')[(int)CsvColumn.Priod]):yy/MM/dd HH:mm}");
                }
                if (lines.Length < 3) continue;
                preState = lines[2].Split(',')[(int)CsvColumn.Result];
                preErrorCounter = int.TryParse(lines[2].Split(',')[(int)CsvColumn.BuildError], out error) ? error : 0;
                preErrorCounter += int.TryParse(lines[2].Split(',')[(int)CsvColumn.TestError], out error) ? error : 0;
            }

            string subject = "";
            string message = "";
            if (nowState == "中断")
            {
                //中断は管理者のみで良い
                subject = "中断連絡";
                message = $"{viewDailyBuild.ViewReport.FailureMessage}\n{sb}";
            }
            else if (nowState == "成功")
            {
                //連続成功連絡は、相手によってはノイズ
                subject = preState != "成功" ? "成功連絡" : "連続成功連絡";
                message = viewDailyBuild.ViewReport.SuccessMessage;
            }
            //失敗
            else
            {
                //失敗再送連絡は、相手によってはノイズ
                subject = preState == "成功" ? "失敗連絡" : nowErrorCounter != preErrorCounter ? "連続失敗連絡" : "失敗再送連絡";
                message = $"{viewDailyBuild.ViewReport.FailureMessage}\n{sb}";
            }
            return ($"デイリービルドフレンズ:{subject}", message);
        }
    }
}
