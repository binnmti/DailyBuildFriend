using DailyBuildFriend.Properties;
using DailyBuildFriend.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyBuildFriend
{
    public partial class MainForm : Form
    {
        private string _fileName = "";
        private string _jsonString = "";


        public MainForm()
        {
            InitializeComponent();
        }

        private ListViewItem ToListViewItem(ViewTask task)
        {
            var item = new ListViewItem(task.TaskName);
            item.SubItems.Add(task.ProjectPath);
            item.SubItems.Add(task.Timer.Result);
            item.SubItems.Add(task.Interval.Result);
            item.SubItems.Add(task.Report.Result);
            item.SubItems.Add(task.TimeOut.Result);
            item.SubItems.Add("");
            item.SubItems.Add(task.LocalRevision);
            item.SubItems.Add(task.ServerRevision);
            item.Checked = task.Checked;
            return item;
        }

        private string GetTitle()
        {
            var title = $"デイリービルドフレンズ";
            if (!string.IsNullOrEmpty(_fileName)) title += $" - {Path.GetFileName(_fileName)}";
            if (_jsonString != ViewTaskAccessor.GetJson()) title += "*";
            return title;
        }

        private void AddTask(ViewTask task)
        {
            task.Checked = true;
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            ViewTaskAccessor.SetGitCommitId(task);
            ViewTaskAccessor.AddTask(task);
            TaskListView.Items.Add(ToListViewItem(task));
            Text = GetTitle();
        }

        private void EditTask()
        {
            if (TaskListView.SelectedItems.Count == 0) return;

            var index = TaskListView.SelectedItems.Cast<ListViewItem>().Single().Index;
            var task = ViewTaskAccessor.GetTask(index);
            var form = new TaskForm(task);
            if (form.ShowDialog() != DialogResult.OK) return;

            ViewTaskAccessor.SetGitCommitId(task);
            ViewTaskAccessor.EditTask(index, task);
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
                ViewTaskAccessor.RemoveTask(item.Index);
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
            ViewTaskAccessor.Save(fileName);
            _fileName = fileName;
            _jsonString = ViewTaskAccessor.GetJson();
            Text = GetTitle();
        }

        private void LoadFile(string fileName)
        {
            //TODO:ロードが出来てもデータとして正しいかは別なのでバリデーションが必要。
            ViewTaskAccessor.Load(fileName);
            ViewTaskAccessor.GetTasks().ToList().ForEach(x => TaskListView.Items.Add(ToListViewItem(x)));
            _fileName = fileName;
            _jsonString = ViewTaskAccessor.GetJson();
            Text = GetTitle();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName))
            {
                saveFileDialog1.ShowDialog();
            }
            else
            {
                SaveFile(_fileName);
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
            if (!File.Exists(Settings.Default.OpenFileName)) return;
            LoadFile(Settings.Default.OpenFileName);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.OpenFileName = _fileName;
            Settings.Default.Save();
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
                ViewTaskAccessor.CheckTask(index, e.NewValue == CheckState.Checked);
                Text = GetTitle();
            }
        }

        private void TaskListView_MouseDoubleClick(object sender, MouseEventArgs e)
            => EditTask();

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskListView.Items.Clear();
            ViewTaskAccessor.ClearTask();
            _fileName = "";
            Text = GetTitle();
        }

        private void NameSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(_fileName);
            saveFileDialog1.FileName = Path.GetFileName(_fileName);
            saveFileDialog1.ShowDialog();
        }

        private void TerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_jsonString == ViewTaskAccessor.GetJson()) return;

            var msg = MessageBox.Show($"{Path.GetFileName(_fileName)} は変更されています。閉じる前に保存しますか？", "", MessageBoxButtons.YesNoCancel);
            if (msg == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (msg == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(_fileName))
                {
                    saveFileDialog1.ShowDialog();
                }
                else
                {
                    SaveFile(_fileName);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var tasks = ViewTaskAccessor.GetTasks().ToList();
            for (int i = 0; i < tasks.Count; i++)
            {
                TaskListView.Items[i] = ToListViewItem(tasks[i]);
            }
        }

        private static CancellationTokenSource? _tokenSource = null;
        public static void StopRunForm() => _tokenSource?.Cancel();
        private async void RunButton_Click(object sender, EventArgs e)
        {
            using var runForm = new RunForm();
            runForm.Show();
            _tokenSource = new CancellationTokenSource();

            //TODO:UIから強制ビルドしてい可能
            await Task.Run(() => { ViewTaskAccessor.Run(runForm, _tokenSource.Token, ""); }, _tokenSource.Token)
                .ContinueWith(t =>
                {
                    void CloseRunForm()
                    {
                        if (InvokeRequired) Invoke((MethodInvoker)(() => { CloseRunForm(); }));
                        else runForm.Close();
                    }
                    CloseRunForm();
                    _tokenSource.Dispose();
                });
        }
    }
}
