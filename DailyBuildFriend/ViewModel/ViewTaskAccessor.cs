﻿using DailyBuildFriend.Model;
using DailyBuildFriend.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace DailyBuildFriend.ViewModel
{
    internal static class ViewTaskAccessor
    {
        internal static IEnumerable<ViewTask> GetTasks() => TaskAccessor.GetTasks().Select(x => x.ToViewTask());
        internal static ViewTask GetTask(int index) => TaskAccessor.GetTask(index).ToViewTask();
        internal static void RemoveTask(int index) => TaskAccessor.RemoveTask(index);
        internal static void ClearTask() => TaskAccessor.ClearTask();
        internal static string GetJson() => TaskAccessor.GetJson(false);
        internal static void Save(string fileName) => File.WriteAllText(fileName, TaskAccessor.GetJson(true));
        internal static void Load(string fileName) => TaskAccessor.SetJson(File.ReadAllText(fileName));
        internal static void EditTask(int index, ViewTask task) => TaskAccessor.EditTask(index, task.ToTask());
        internal static void AddTask(ViewTask task) => TaskAccessor.AddTask(task.ToTask());
        internal static void CheckTask(int index, bool check) => TaskAccessor.CheckTask(index, check);

        internal static void SetGitCommitId(ViewTask task)
        {
            task.LocalRevision = GetGitCommitId(task.ProjectPath, "");
            task.ServerRevision = GetGitCommitId(task.ProjectPath, "origin");
        }

        internal static string Validation(this ViewTask task)
        {
            if (string.IsNullOrEmpty(task.TaskName)) return "名前がありません";
            if (Regex.IsMatch(task.FileName, @"[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}]+")) return "ファイル名に日本語は使えません";
            if (!Directory.Exists(task.ProjectPath)) return "プロジェクトパスが存在しません";
            if (!Directory.Exists(task.LogPath)) return "ログパスが存在しません";
            return "";
        }

        internal static void Run(RunForm runForm, CancellationToken token)
        {
            foreach (var task in GetTasks().Where(x => x.Checked))
            {
                bool isBreak = false;
                bool isFaild = false;

                string logPathName = Path.Combine(task.LogPath, task.FileName);
                string logFileName = Path.Combine(logPathName, task.FileName + "Result.log");
                FileUtility.Write(logFileName, false, "デイリービルド開始", true);
                foreach (var command in task.ViewCommands.Where(x => x.Check))
                {
                    FileUtility.Write(logFileName, true, $"{command.Name}開始", true);
                    runForm.SetMessage($"{task.TaskName}実行中", $"{task.TaskName}:{command.Name}中", $"内容:{command.Summary}", task.ServerRevision, "1");
                    try
                    {
                        if (command.CommandType == CommandType.VisualStudioOpen)
                        {
                            FileUtility.Write(Path.Combine(logPathName, task.FileName + "Warning.log"), false, "", true);
                            FileUtility.Write(Path.Combine(logPathName, task.FileName + "Error.log"), false, "", true);
                        }
                        else if (command.CommandType == CommandType.VisualStudioBuild)
                        {
                            command.RunVsBuild(task.ViewCommands);

                            var file = Path.Combine(logPathName, task.FileName + "ErrWarning.log");
                            ErrWaningAnalyze(file, file, command.Name, command.Param1, " 警告 ");
                            ErrWaningAnalyze(file, file, command.Name, command.Param1, " エラー ");

                        }
                        else
                        {
                            command.Run();
                        }
                    }
                    catch (Exception)
                    {
                        FileUtility.Write(logFileName, true, command.Name + "失敗", false);
                        FileUtility.Write(logFileName, true, "error!!", false);
                        isBreak = true;
                        break;
                    }
                    FileUtility.Write(logFileName, true, $"{command.Name}終了", true);
                    if (token.IsCancellationRequested) return;
                }
                FileUtility.Write(logFileName, true, "デイリービルド終了", true);
                FileUtility.Write(logFileName, true, "finish!!", false);

                //TODO:ここでファイルアクセス出来ない場合はどうするか

                //CSV
                string csvFile = Path.Combine(task.LogPath, task.FileName, task.FileName + "Result.csv");

                //TODO:CSVが書き換えられた場合これでは駄目だが。。。
                //var lines = File.Exists(csvFile) ? File.ReadLines(csvFile).Skip(1) : new List<string>();
                //using var writer = new StreamWriter(csvFile);
                //writer.WriteLine("リビジョン,結果,エラー,警告,テスト,フルビルド,開始時間,終了時間,全時間,編集者,");
                //writer.Write($"{task.LocalRevision},");
                //writer.Write(isBreak ? "中断" : isFaild ? "失敗" : "成功");

                //foreach (var line in lines)
                //{
                //    writer.WriteLine(line);
                //}
            }
        }

        private static int ErrWaningAnalyze(string logFileName, string saveFileName, string command, string param, string keyword)
        {
            int hit = 0;

            using var writer = new StreamWriter(saveFileName);
            writer.WriteLine("コマンド:" + command);
            writer.WriteLine("ターゲット:" + param);
            writer.WriteLine("//--------------------------------------------------------------------------");
            foreach (var line in File.ReadLines(logFileName).Where(x => x != keyword))
            {
                writer.WriteLine(line);
                hit++;
            }
            return hit;
        }

        private static ViewCommand ToViewCommand(this Command command)
            => new ViewCommand() { Name = command.Name, Check = command.Checked, Param1 = command.Param1, Param2 = command.Param2 };

        private static ViewTask ToViewTask(this Task task)
            => new ViewTask()
            {
                Checked = task.Check,
                FileName = task.FileName,
                Interval = new Check() { Checked = task.Interval },
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = new Check() { Checked = task.Report },
                TaskName = task.TaskName,
                TimeOut = new TimeOut() { Check = task.TimeOut, Time = task.TimeOutTime },
                Timer = new Check() { Checked = task.Timer },
                //TODO ログから取得 Update = task.Update,
                //TODO ログから取得 WorstTime = task.WorstTime,
                LocalRevision = GetGitCommitId(task.ProjectPath, ""),
                ServerRevision = GetGitCommitId(task.ProjectPath, "origin"),
                ViewCommands = task.Commands.Select(x => x.ToViewCommand()).ToList(),
            };

        private static Command ToCommand(this ViewCommand command)
            => new Command() { Name = command.Name, Checked = command.Check, Param1 = command.Param1, Param2 = command.Param2 };

        private static Task ToTask(this ViewTask task)
            => new Task()
            {
                Check = task.Checked,
                FileName = task.FileName,
                Interval = task.Interval.Checked,
                LogPath = task.LogPath,
                ProjectPath = task.ProjectPath,
                Report = task.Report.Checked,
                TaskName = task.TaskName,
                TimeOut = task.TimeOut.Check,
                TimeOutTime = task.TimeOut.Time,
                Timer = task.Timer.Checked,
                Commands = task.ViewCommands.Select(x => x.ToCommand()).ToList(),
            };

        private static string GetGitCommitId(string projectPath, string branch)
            => ProcessUtility.ProcessStart("git", projectPath, $"log -n 1 --format=%h {branch}");
    }
}
