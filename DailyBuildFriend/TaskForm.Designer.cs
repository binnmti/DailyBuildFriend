
namespace DailyBuildFriend
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TaskNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelingButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.CommandListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitPullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitCheckOutCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitCloneCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.VsOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VSBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VsTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BatRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MailSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SlackSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeOutTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.ReportCheckBox = new System.Windows.Forms.CheckBox();
            this.IntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.TimerCheckBox = new System.Windows.Forms.CheckBox();
            this.AllCheckBox = new System.Windows.Forms.CheckBox();
            this.LogPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOutTimeNumericUpDown)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "タスク名";
            // 
            // TaskNameTextBox
            // 
            this.TaskNameTextBox.Location = new System.Drawing.Point(155, 8);
            this.TaskNameTextBox.Name = "TaskNameTextBox";
            this.TaskNameTextBox.Size = new System.Drawing.Size(608, 25);
            this.TaskNameTextBox.TabIndex = 1;
            this.TaskNameTextBox.TextChanged += new System.EventHandler(this.TaskNameTextBox_TextChanged);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(155, 40);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(608, 25);
            this.FileNameTextBox.TabIndex = 3;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ファイル名";
            // 
            // ProjectPathTextBox
            // 
            this.ProjectPathTextBox.Location = new System.Drawing.Point(155, 72);
            this.ProjectPathTextBox.Name = "ProjectPathTextBox";
            this.ProjectPathTextBox.Size = new System.Drawing.Size(608, 25);
            this.ProjectPathTextBox.TabIndex = 5;
            this.ProjectPathTextBox.TextChanged += new System.EventHandler(this.ProjectPathTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "プロジェクトパス";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelingButton);
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 573);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 55);
            this.panel1.TabIndex = 6;
            // 
            // CancelingButton
            // 
            this.CancelingButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelingButton.Location = new System.Drawing.Point(661, 16);
            this.CancelingButton.Name = "CancelingButton";
            this.CancelingButton.Size = new System.Drawing.Size(106, 34);
            this.CancelingButton.TabIndex = 1;
            this.CancelingButton.Text = "キャンセル";
            this.CancelingButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(557, 16);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(98, 34);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CommandListView
            // 
            this.CommandListView.CheckBoxes = true;
            this.CommandListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.CommandListView.ContextMenuStrip = this.contextMenuStrip1;
            this.CommandListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandListView.FullRowSelect = true;
            this.CommandListView.GridLines = true;
            this.CommandListView.HideSelection = false;
            this.CommandListView.Location = new System.Drawing.Point(0, 220);
            this.CommandListView.MultiSelect = false;
            this.CommandListView.Name = "CommandListView";
            this.CommandListView.Size = new System.Drawing.Size(775, 353);
            this.CommandListView.TabIndex = 7;
            this.CommandListView.UseCompatibleStateImageBehavior = false;
            this.CommandListView.View = System.Windows.Forms.View.Details;
            this.CommandListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CommandListView_ItemCheck);
            this.CommandListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CommandListView_MouseDoubleClick);
            this.CommandListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CommandListView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "コマンド";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容";
            this.columnHeader2.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加AToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.RunToolStripMenuItem,
            this.toolStripSeparator3,
            this.UpToolStripMenuItem,
            this.DownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(239, 202);
            // 
            // 追加AToolStripMenuItem
            // 
            this.追加AToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GitPullToolStripMenuItem,
            this.GitCheckOutCToolStripMenuItem,
            this.GitCloneCToolStripMenuItem,
            this.toolStripSeparator1,
            this.VsOpenToolStripMenuItem,
            this.VSBuildToolStripMenuItem,
            this.VsTestToolStripMenuItem,
            this.toolStripSeparator2,
            this.BatRunToolStripMenuItem,
            this.MailSendToolStripMenuItem,
            this.SlackSendToolStripMenuItem});
            this.追加AToolStripMenuItem.Name = "追加AToolStripMenuItem";
            this.追加AToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.追加AToolStripMenuItem.Text = "追加(&A)";
            // 
            // GitPullToolStripMenuItem
            // 
            this.GitPullToolStripMenuItem.Name = "GitPullToolStripMenuItem";
            this.GitPullToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.GitPullToolStripMenuItem.Text = "gitプル(&P)";
            this.GitPullToolStripMenuItem.Click += new System.EventHandler(this.GitPullToolStripMenuItem_Click);
            // 
            // GitCheckOutCToolStripMenuItem
            // 
            this.GitCheckOutCToolStripMenuItem.Name = "GitCheckOutCToolStripMenuItem";
            this.GitCheckOutCToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.GitCheckOutCToolStripMenuItem.Text = "gitチェックアウト(&C)";
            this.GitCheckOutCToolStripMenuItem.Click += new System.EventHandler(this.GitCheckOutCToolStripMenuItem_Click);
            // 
            // GitCloneCToolStripMenuItem
            // 
            this.GitCloneCToolStripMenuItem.Name = "GitCloneCToolStripMenuItem";
            this.GitCloneCToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.GitCloneCToolStripMenuItem.Text = "gitクローン(&K)";
            this.GitCloneCToolStripMenuItem.Click += new System.EventHandler(this.GitCloneCToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // VsOpenToolStripMenuItem
            // 
            this.VsOpenToolStripMenuItem.Name = "VsOpenToolStripMenuItem";
            this.VsOpenToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.VsOpenToolStripMenuItem.Text = "VS起動(&O)";
            this.VsOpenToolStripMenuItem.Click += new System.EventHandler(this.VsOpenToolStripMenuItem_Click);
            // 
            // VSBuildToolStripMenuItem
            // 
            this.VSBuildToolStripMenuItem.Name = "VSBuildToolStripMenuItem";
            this.VSBuildToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.VSBuildToolStripMenuItem.Text = "VSビルド(&B)";
            this.VSBuildToolStripMenuItem.Click += new System.EventHandler(this.VSBuildToolStripMenuItem_Click);
            // 
            // VsTestToolStripMenuItem
            // 
            this.VsTestToolStripMenuItem.Name = "VsTestToolStripMenuItem";
            this.VsTestToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.VsTestToolStripMenuItem.Text = "VSテスト(&T)";
            this.VsTestToolStripMenuItem.Click += new System.EventHandler(this.VsTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // BatRunToolStripMenuItem
            // 
            this.BatRunToolStripMenuItem.Name = "BatRunToolStripMenuItem";
            this.BatRunToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.BatRunToolStripMenuItem.Text = "バッチ実行(&B)";
            this.BatRunToolStripMenuItem.Click += new System.EventHandler(this.BatRunToolStripMenuItem_Click);
            // 
            // MailSendToolStripMenuItem
            // 
            this.MailSendToolStripMenuItem.Name = "MailSendToolStripMenuItem";
            this.MailSendToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.MailSendToolStripMenuItem.Text = "メール送信(&M)";
            this.MailSendToolStripMenuItem.Click += new System.EventHandler(this.MailSendToolStripMenuItem_Click);
            // 
            // SlackSendToolStripMenuItem
            // 
            this.SlackSendToolStripMenuItem.Name = "SlackSendToolStripMenuItem";
            this.SlackSendToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.SlackSendToolStripMenuItem.Text = "slack送信(&S)";
            this.SlackSendToolStripMenuItem.Click += new System.EventHandler(this.SlackSendToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.EditToolStripMenuItem.Text = "編集(&E)";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.DeleteToolStripMenuItem.Text = "削除(&D)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // RunToolStripMenuItem
            // 
            this.RunToolStripMenuItem.Name = "RunToolStripMenuItem";
            this.RunToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RunToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.RunToolStripMenuItem.Text = "起動(&R)";
            this.RunToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(235, 6);
            // 
            // UpToolStripMenuItem
            // 
            this.UpToolStripMenuItem.Name = "UpToolStripMenuItem";
            this.UpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.UpToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.UpToolStripMenuItem.Text = "上へ(&U)";
            this.UpToolStripMenuItem.Click += new System.EventHandler(this.UpToolStripMenuItem_Click);
            // 
            // DownToolStripMenuItem
            // 
            this.DownToolStripMenuItem.Name = "DownToolStripMenuItem";
            this.DownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.DownToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.DownToolStripMenuItem.Text = "下へ(&D)";
            this.DownToolStripMenuItem.Click += new System.EventHandler(this.DownToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TimeOutTimeNumericUpDown);
            this.panel2.Controls.Add(this.TimeoutCheckBox);
            this.panel2.Controls.Add(this.ReportCheckBox);
            this.panel2.Controls.Add(this.IntervalCheckBox);
            this.panel2.Controls.Add(this.TimerCheckBox);
            this.panel2.Controls.Add(this.AllCheckBox);
            this.panel2.Controls.Add(this.LogPathTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ProjectPathTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.FileNameTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TaskNameTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 186);
            this.panel2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(738, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "分";
            // 
            // TimeOutTimeNumericUpDown
            // 
            this.TimeOutTimeNumericUpDown.Location = new System.Drawing.Point(609, 139);
            this.TimeOutTimeNumericUpDown.Name = "TimeOutTimeNumericUpDown";
            this.TimeOutTimeNumericUpDown.Size = new System.Drawing.Size(120, 25);
            this.TimeOutTimeNumericUpDown.TabIndex = 13;
            this.TimeOutTimeNumericUpDown.ValueChanged += new System.EventHandler(this.TimeOutTimeNumericUpDown_ValueChanged);
            // 
            // TimeoutCheckBox
            // 
            this.TimeoutCheckBox.AutoSize = true;
            this.TimeoutCheckBox.Location = new System.Drawing.Point(480, 140);
            this.TimeoutCheckBox.Name = "TimeoutCheckBox";
            this.TimeoutCheckBox.Size = new System.Drawing.Size(114, 22);
            this.TimeoutCheckBox.TabIndex = 12;
            this.TimeoutCheckBox.Text = "タイムアウト";
            this.TimeoutCheckBox.UseVisualStyleBackColor = true;
            this.TimeoutCheckBox.CheckedChanged += new System.EventHandler(this.TimeoutCheckBox_CheckedChanged);
            // 
            // ReportCheckBox
            // 
            this.ReportCheckBox.AutoSize = true;
            this.ReportCheckBox.Location = new System.Drawing.Point(380, 140);
            this.ReportCheckBox.Name = "ReportCheckBox";
            this.ReportCheckBox.Size = new System.Drawing.Size(91, 22);
            this.ReportCheckBox.TabIndex = 11;
            this.ReportCheckBox.Text = "レポート";
            this.ReportCheckBox.UseVisualStyleBackColor = true;
            this.ReportCheckBox.CheckedChanged += new System.EventHandler(this.ReportCheckBox_CheckedChanged);
            // 
            // IntervalCheckBox
            // 
            this.IntervalCheckBox.AutoSize = true;
            this.IntervalCheckBox.Location = new System.Drawing.Point(254, 140);
            this.IntervalCheckBox.Name = "IntervalCheckBox";
            this.IntervalCheckBox.Size = new System.Drawing.Size(117, 22);
            this.IntervalCheckBox.TabIndex = 10;
            this.IntervalCheckBox.Text = "インターバル";
            this.IntervalCheckBox.UseVisualStyleBackColor = true;
            this.IntervalCheckBox.CheckedChanged += new System.EventHandler(this.IntervalCheckBox_CheckedChanged);
            // 
            // TimerCheckBox
            // 
            this.TimerCheckBox.AutoSize = true;
            this.TimerCheckBox.Location = new System.Drawing.Point(157, 140);
            this.TimerCheckBox.Name = "TimerCheckBox";
            this.TimerCheckBox.Size = new System.Drawing.Size(88, 22);
            this.TimerCheckBox.TabIndex = 9;
            this.TimerCheckBox.Text = "タイマー";
            this.TimerCheckBox.UseVisualStyleBackColor = true;
            this.TimerCheckBox.CheckedChanged += new System.EventHandler(this.TimerCheckBox_CheckedChanged);
            // 
            // AllCheckBox
            // 
            this.AllCheckBox.AutoSize = true;
            this.AllCheckBox.Location = new System.Drawing.Point(12, 158);
            this.AllCheckBox.Name = "AllCheckBox";
            this.AllCheckBox.Size = new System.Drawing.Size(99, 22);
            this.AllCheckBox.TabIndex = 8;
            this.AllCheckBox.Text = "全チェック";
            this.AllCheckBox.UseVisualStyleBackColor = true;
            this.AllCheckBox.CheckedChanged += new System.EventHandler(this.AllCheckBox_CheckedChanged);
            // 
            // LogPathTextBox
            // 
            this.LogPathTextBox.Location = new System.Drawing.Point(155, 104);
            this.LogPathTextBox.Name = "LogPathTextBox";
            this.LogPathTextBox.Size = new System.Drawing.Size(608, 25);
            this.LogPathTextBox.TabIndex = 7;
            this.LogPathTextBox.TextChanged += new System.EventHandler(this.LogPathTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "ログパス";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 186);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(775, 34);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(90, 29);
            this.toolStripButton2.Text = "gitプル";
            this.toolStripButton2.Click += new System.EventHandler(this.GitPullToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(97, 29);
            this.toolStripButton4.Text = "VS起動";
            this.toolStripButton4.Click += new System.EventHandler(this.VsOpenToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(102, 29);
            this.toolStripButton1.Text = "VSビルド";
            this.toolStripButton1.Click += new System.EventHandler(this.VSBuildToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(101, 29);
            this.toolStripButton3.Text = "VSテスト";
            this.toolStripButton3.Click += new System.EventHandler(this.VsTestToolStripMenuItem_Click);
            // 
            // TaskForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelingButton;
            this.ClientSize = new System.Drawing.Size(775, 628);
            this.Controls.Add(this.CommandListView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TaskForm";
            this.Text = "タスク";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeOutTimeNumericUpDown)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TaskNameTextBox;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProjectPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView CommandListView;
        private System.Windows.Forms.Button CancelingButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox LogPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TimeOutTimeNumericUpDown;
        private System.Windows.Forms.CheckBox TimeoutCheckBox;
        private System.Windows.Forms.CheckBox ReportCheckBox;
        private System.Windows.Forms.CheckBox IntervalCheckBox;
        private System.Windows.Forms.CheckBox TimerCheckBox;
        private System.Windows.Forms.CheckBox AllCheckBox;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 追加AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitPullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitCheckOutCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitCloneCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem VSBuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VsTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BatRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MailSendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SlackSendToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem VsOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem UpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownToolStripMenuItem;
    }
}