using DailyBuildFriend.Properties;
using DailyBuildFriend.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private string FileName = "";
        private string JsonString = "";
        private int CheckTimeCounter = 0;
        private int IntervalTimeCounter = 0;

        private ViewDailyBuild ViewDailyBuild = new ViewDailyBuild();

        public MainForm()
        {
            InitializeComponent();
        }

        private ListViewItem ToListViewItem(ViewTask task)
        {
            var item = new ListViewItem(task.TaskName);
            item.SubItems.Add(task.UpdateDate);
            item.SubItems.Add(task.ProjectPath);
            item.SubItems.Add(task.Timer.Result);
            item.SubItems.Add(task.Interval.Result);
            item.SubItems.Add(task.Report.Result);
            item.SubItems.Add(task.TimeOut.Result);
            item.SubItems.Add("");
            item.SubItems.Add(task.LocalRevision);
            item.SubItems.Add(task.ServerRevision);
            item.ForeColor = task.Result switch
            {
                "失敗" => Color.Red,
                "中断" => Color.Gray,
                "成功" => Color.Green,
                _ => Color.Black,
            };
            item.BackColor = task.LocalRevision == task.ServerRevision ? Color.White : Color.Snow;
            item.Checked = task.Checked;
            return item;
        }

        private string GetTitle()
        {
            var title = $"デイリービルドフレンズ";
            if (!string.IsNullOrEmpty(FileName)) title += $" - {Path.GetFileName(FileName)}";
            if (JsonString != ViewDailyBuild.ToJson(false)) title += "*";
            return title;
        }

        private void AddTask(ViewTask task)
        {
            task.Checked = true;
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            ViewTaskAccessor.Update(task);
            ViewDailyBuild.ViewTasks.Add(task);
            TaskListView.Items.Add(ToListViewItem(task));
            Text = GetTitle();
        }

        private void EditTask()
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var task = ViewDailyBuild.ViewTasks[index];
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            ViewTaskAccessor.Update(task);
            ViewDailyBuild.ViewTasks[index] = task;
            TaskListView.Items[index] = ToListViewItem(task);
            Text = GetTitle();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTask(new ViewTask());
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(var item in TaskListView.SelectedItems.Cast<ListViewItem>())
            {
                ViewDailyBuild.ViewTasks.RemoveAt(item.Index);
                TaskListView.Items.Remove(item);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
            => EditTask();

        private void AddToolStripMenuItem_Click(object sender, MouseEventArgs e)
        {

        }

        private void SaveFile(string fileName)
        {
            File.WriteAllText(fileName, ViewDailyBuild.ToJson(true));

            //TODO:この3つのアクションはまとめられそう
            FileName = fileName;
            JsonString = ViewDailyBuild.ToJson(false);
            Text = GetTitle();
        }

        private void LoadFile(string fileName)
        {
            //TODO:一旦ロード切り
            //ViewDailyBuild = ViewDailyBuildAccessor.ToViewDailyBuild(File.ReadAllText(fileName));

            //TODO:ロードが出来てもデータとして正しいかは別なのでバリデーションが必要。
            //ViewTaskAccessor.SetJson(File.ReadAllText(fileName));
            ViewDailyBuild.ViewTasks.ForEach(x => TaskListView.Items.Add(ToListViewItem(x)));
            FileName = fileName;
            JsonString = ViewDailyBuild.ToJson(false);
            Text = GetTitle();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                saveFileDialog1.ShowDialog();
            }
            else
            {
                SaveFile(FileName);
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFile(saveFileDialog1.FileName);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadFile(openFileDialog1.FileName);
        }

        private void TaskListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void TaskListView_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length <= 0) return;
            AddTask(new ViewTask
            {
                FileName = Path.GetFileNameWithoutExtension(files[0]),
                ProjectPath = files[0],
                LogPath = files[0],
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath) + "option.json");
            //if (File.Exists(fileName))  ViewOptionAccessor.Load(fileName);

            if (!File.Exists(Settings.Default.OpenFileName)) return;
            LoadFile(Settings.Default.OpenFileName);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.OpenFileName = FileName;
            Settings.Default.Save();

            string fileName = Path.Combine(Application.StartupPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath) + "option.json");
            //ViewOptionAccessor.Save(fileName);
        }

        private bool doubleClickFlag;
        private void TaskListView_MouseDown(object sender, MouseEventArgs e)
        {
            doubleClickFlag = e.Clicks >= 2;
        }

        private void TaskListView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (doubleClickFlag)
            {
                e.NewValue = e.CurrentValue;
                doubleClickFlag = false;
            }
            else
            {
                if (TaskListView.Items.Count == 0) return;

                var index = e.Index;
                ViewDailyBuild.ViewTasks[index].Checked = e.NewValue == CheckState.Checked;
                Text = GetTitle();
            }
        }

        private void TaskListView_MouseDoubleClick(object sender, MouseEventArgs e)
            => EditTask();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskListView.Items.Clear();
            ViewDailyBuild.ViewTasks.Clear();
            FileName = "";
            Text = GetTitle();
        }

        private void NameSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(FileName);
            saveFileDialog1.FileName = Path.GetFileName(FileName);
            saveFileDialog1.ShowDialog();
        }

        private void TerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JsonString == ViewDailyBuild.ToJson(false)) return;

            var msg = MessageBox.Show($"{Path.GetFileName(FileName)} は変更されています。閉じる前に保存しますか？", "", MessageBoxButtons.YesNoCancel);
            if (msg == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (msg == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(FileName))
                {
                    saveFileDialog1.ShowDialog();
                }
                else
                {
                    SaveFile(FileName);
                }
            }
        }

        private void UpdateListView()
        {
            //TODO:GetTasksはVM的な意味で設計を再考
            for (int i = 0; i < ViewDailyBuild.ViewTasks.Count; i++)
            {
                TaskListView.Items[i] = ToListViewItem(ViewDailyBuild.ViewTasks[i]);
            }
        }

        private void FormActive()
        {
            Visible = true;
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Activate();
        }

        private static CancellationTokenSource? _tokenSource = null;
        public static void StopRunForm() => _tokenSource?.Cancel();
        private async Task RunDailyBuildAsync(RunType runType)
        {
            RunButton.Enabled = false;

            using var runForm = new RunForm();
            runForm.Show();
            _tokenSource = new CancellationTokenSource();

            string forceBuild = "";
            if (BuildRadioButton.Checked) forceBuild = "ビルド";
            else if (ReBuildRadioButton.Checked) forceBuild = "リビルド";

            //TODO:UIから強制ビルドしてい可能
            await Task.Run(() => { ViewDailyBuild.Run(runForm, _tokenSource.Token, runType, forceBuild); }, _tokenSource.Token)
                .ContinueWith(t =>
                {
                    void CloseRunForm()
                    {
                        if (InvokeRequired) Invoke((MethodInvoker)(() => { CloseRunForm(); }));
                        else
                        {
                            runForm.Close();
                            RunButton.Enabled = true;
                            NormalRadioButton.Checked = true;
                            UpdateListView();
                            FormActive();
                        }
                    }
                    CloseRunForm();
                    _tokenSource.Dispose();
                });

        }

        private async void RunButton_Click(object sender, EventArgs e)
            => await RunDailyBuildAsync(RunType.Click);

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //実行中
            if (!RunButton.Enabled)
            {
                //タイムアウトチェック
                return;
            }
            //スケジュール
            else if (ScheduleCheckBox.Checked)
            {
                NowTimerTextBox.Text = DateTime.Now.ToLongTimeString();
                if (TimerTextBox.Text == NowTimerTextBox.Text)
                {
                    await RunDailyBuildAsync(RunType.Timer);
                }
                IntervalTimeCounter++;
                int iTimer = (int)IntervalNumericUpDown.Value;
                if (IntervalTimeCounter == (60 * iTimer))
                {


                    await RunDailyBuildAsync(RunType.Timer);
                    IntervalTimeCounter = 0;
                }
                IntervalTextBox.Text = (60 * iTimer - IntervalTimeCounter).ToString();
                CheckTimeCounter++;
                if (CheckTimeCounter == 60)
                {
                    UpdateListView();
                    CheckTimeCounter = 0;
                }
                CheckTextBox.Text = (60 - CheckTimeCounter).ToString();
            }
        }

        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionForm(ViewDailyBuild.ViewOption);
            optionForm.ShowDialog();
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            ViewDailyBuild.ViewTasks[index].OpenLog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ScheduleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void IntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            IntervalTimeCounter = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ReportForm(ViewDailyBuild.ViewReport);
            form.ShowDialog();
        }
    }
}
