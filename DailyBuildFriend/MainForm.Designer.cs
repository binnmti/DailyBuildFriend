
namespace DailyBuildFriend
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RunButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReBuildRadioButton = new System.Windows.Forms.RadioButton();
            this.BuildRadioButton = new System.Windows.Forms.RadioButton();
            this.NormalRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TimerTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.NowTimerTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.IntervalTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CheckTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ScheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ReportButton = new System.Windows.Forms.Button();
            this.ReportCheckBox = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.TaskListViewContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.設定SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1981, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.NameSaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.OpenToolStripMenuItem.Text = "開く(&O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.CloseToolStripMenuItem.Text = "閉じる(C)";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.SaveToolStripMenuItem.Text = "保存(&S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // NameSaveToolStripMenuItem
            // 
            this.NameSaveToolStripMenuItem.Name = "NameSaveToolStripMenuItem";
            this.NameSaveToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.NameSaveToolStripMenuItem.Text = "名前を付けて保存する(&A)";
            this.NameSaveToolStripMenuItem.Click += new System.EventHandler(this.NameSaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(296, 34);
            this.ExitToolStripMenuItem.Text = "終了(&T)";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.TerminalToolStripMenuItem_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionToolStripMenuItem});
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.設定SToolStripMenuItem.Text = "設定(&S)";
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.OptionToolStripMenuItem.Text = "オプション(&O)";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // TaskListViewContextMenuStrip
            // 
            this.TaskListViewContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TaskListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.LogToolStripMenuItem,
            this.ProjectToolStripMenuItem});
            this.TaskListViewContextMenuStrip.Name = "contextMenuStrip1";
            this.TaskListViewContextMenuStrip.Size = new System.Drawing.Size(227, 170);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.AddToolStripMenuItem.Text = "追加(&A)";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.EditToolStripMenuItem.Text = "編集(&E)";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.DeleteToolStripMenuItem.Text = "削除(&D)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // LogToolStripMenuItem
            // 
            this.LogToolStripMenuItem.Name = "LogToolStripMenuItem";
            this.LogToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.LogToolStripMenuItem.Text = "ログ(&L)";
            this.LogToolStripMenuItem.Click += new System.EventHandler(this.LogToolStripMenuItem_Click);
            // 
            // ProjectToolStripMenuItem
            // 
            this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
            this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.ProjectToolStripMenuItem.Text = "プロジェクトを開く(&P)";
            this.ProjectToolStripMenuItem.Click += new System.EventHandler(this.ProjectToolStripMenuItem_Click);
            // 
            // TaskListView
            // 
            this.TaskListView.AllowDrop = true;
            this.TaskListView.CheckBoxes = true;
            this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.TaskListView.ContextMenuStrip = this.TaskListViewContextMenuStrip;
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskListView.FullRowSelect = true;
            this.TaskListView.GridLines = true;
            this.TaskListView.HideSelection = false;
            this.TaskListView.Location = new System.Drawing.Point(0, 33);
            this.TaskListView.MultiSelect = false;
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(1981, 125);
            this.TaskListView.TabIndex = 2;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            this.TaskListView.View = System.Windows.Forms.View.Details;
            this.TaskListView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TaskListView_ItemCheck);
            this.TaskListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.TaskListView_DragDrop);
            this.TaskListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.TaskListView_DragEnter);
            this.TaskListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TaskListView_MouseDoubleClick);
            this.TaskListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskListView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "タスク名";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "更新日時";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "プロジェクトパス";
            this.columnHeader3.Width = 400;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "タイマー";
            this.columnHeader4.Width = 66;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "インターバル";
            this.columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "レポート";
            this.columnHeader6.Width = 69;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "タイムアウト";
            this.columnHeader7.Width = 92;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ワースト";
            this.columnHeader8.Width = 68;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ローカル";
            this.columnHeader9.Width = 68;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "サーバー";
            // 
            // RunButton
            // 
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.Location = new System.Drawing.Point(1790, 13);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(180, 79);
            this.RunButton.TabIndex = 3;
            this.RunButton.Text = "実行";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.ReportButton);
            this.panel1.Controls.Add(this.ReportCheckBox);
            this.panel1.Controls.Add(this.RunButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1981, 137);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReBuildRadioButton);
            this.groupBox2.Controls.Add(this.BuildRadioButton);
            this.groupBox2.Controls.Add(this.NormalRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(674, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(232, 123);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ビルド設定";
            // 
            // ReBuildRadioButton
            // 
            this.ReBuildRadioButton.AutoSize = true;
            this.ReBuildRadioButton.Location = new System.Drawing.Point(21, 81);
            this.ReBuildRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReBuildRadioButton.Name = "ReBuildRadioButton";
            this.ReBuildRadioButton.Size = new System.Drawing.Size(171, 22);
            this.ReBuildRadioButton.TabIndex = 2;
            this.ReBuildRadioButton.Text = "強制的に全リビルド";
            this.ReBuildRadioButton.UseVisualStyleBackColor = true;
            // 
            // BuildRadioButton
            // 
            this.BuildRadioButton.AutoSize = true;
            this.BuildRadioButton.Location = new System.Drawing.Point(21, 52);
            this.BuildRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.BuildRadioButton.Name = "BuildRadioButton";
            this.BuildRadioButton.Size = new System.Drawing.Size(160, 22);
            this.BuildRadioButton.TabIndex = 1;
            this.BuildRadioButton.Text = "強制的に全ビルド";
            this.BuildRadioButton.UseVisualStyleBackColor = true;
            // 
            // NormalRadioButton
            // 
            this.NormalRadioButton.AutoSize = true;
            this.NormalRadioButton.Checked = true;
            this.NormalRadioButton.Location = new System.Drawing.Point(21, 23);
            this.NormalRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.NormalRadioButton.Name = "NormalRadioButton";
            this.NormalRadioButton.Size = new System.Drawing.Size(163, 22);
            this.NormalRadioButton.TabIndex = 0;
            this.NormalRadioButton.TabStop = true;
            this.NormalRadioButton.Text = "設定どおりにビルド";
            this.NormalRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TimerTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.IntervalNumericUpDown);
            this.groupBox1.Controls.Add(this.NowTimerTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.IntervalTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CheckTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ScheduleCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(211, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(426, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // TimerTextBox
            // 
            this.TimerTextBox.Location = new System.Drawing.Point(129, 86);
            this.TimerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TimerTextBox.Name = "TimerTextBox";
            this.TimerTextBox.Size = new System.Drawing.Size(107, 25);
            this.TimerTextBox.TabIndex = 16;
            this.TimerTextBox.Text = "0:00:00";
            this.TimerTextBox.TextChanged += new System.EventHandler(this.TimerTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "分";
            // 
            // IntervalNumericUpDown
            // 
            this.IntervalNumericUpDown.Location = new System.Drawing.Point(129, 56);
            this.IntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.IntervalNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.IntervalNumericUpDown.Name = "IntervalNumericUpDown";
            this.IntervalNumericUpDown.Size = new System.Drawing.Size(75, 25);
            this.IntervalNumericUpDown.TabIndex = 13;
            this.IntervalNumericUpDown.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.IntervalNumericUpDown.ValueChanged += new System.EventHandler(this.IntervalNumericUpDown_ValueChanged);
            // 
            // NowTimerTextBox
            // 
            this.NowTimerTextBox.Location = new System.Drawing.Point(311, 86);
            this.NowTimerTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NowTimerTextBox.Name = "NowTimerTextBox";
            this.NowTimerTextBox.ReadOnly = true;
            this.NowTimerTextBox.Size = new System.Drawing.Size(95, 25);
            this.NowTimerTextBox.TabIndex = 12;
            this.NowTimerTextBox.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "現在";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 88);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "タイマー";
            // 
            // IntervalTextBox
            // 
            this.IntervalTextBox.Location = new System.Drawing.Point(311, 56);
            this.IntervalTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IntervalTextBox.Name = "IntervalTextBox";
            this.IntervalTextBox.ReadOnly = true;
            this.IntervalTextBox.Size = new System.Drawing.Size(64, 25);
            this.IntervalTextBox.TabIndex = 8;
            this.IntervalTextBox.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "秒";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "残り";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "インターバル";
            // 
            // CheckTextBox
            // 
            this.CheckTextBox.Location = new System.Drawing.Point(311, 25);
            this.CheckTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckTextBox.Name = "CheckTextBox";
            this.CheckTextBox.ReadOnly = true;
            this.CheckTextBox.Size = new System.Drawing.Size(64, 25);
            this.CheckTextBox.TabIndex = 4;
            this.CheckTextBox.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "残り";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "チェック";
            // 
            // ScheduleCheckBox
            // 
            this.ScheduleCheckBox.AutoSize = true;
            this.ScheduleCheckBox.Location = new System.Drawing.Point(4, 0);
            this.ScheduleCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ScheduleCheckBox.Name = "ScheduleCheckBox";
            this.ScheduleCheckBox.Size = new System.Drawing.Size(155, 22);
            this.ScheduleCheckBox.TabIndex = 0;
            this.ScheduleCheckBox.Text = "スケジュール設定";
            this.ScheduleCheckBox.UseVisualStyleBackColor = true;
            this.ScheduleCheckBox.CheckedChanged += new System.EventHandler(this.ScheduleCheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 5);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(157, 22);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "全タスクON・OFF";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ReportButton
            // 
            this.ReportButton.Location = new System.Drawing.Point(114, 95);
            this.ReportButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(34, 35);
            this.ReportButton.TabIndex = 5;
            this.ReportButton.Text = "...";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // ReportCheckBox
            // 
            this.ReportCheckBox.AutoSize = true;
            this.ReportCheckBox.Location = new System.Drawing.Point(14, 103);
            this.ReportCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ReportCheckBox.Name = "ReportCheckBox";
            this.ReportCheckBox.Size = new System.Drawing.Size(91, 22);
            this.ReportCheckBox.TabIndex = 4;
            this.ReportCheckBox.Text = "レポート";
            this.ReportCheckBox.UseVisualStyleBackColor = true;
            this.ReportCheckBox.CheckedChanged += new System.EventHandler(this.ReportCheckBox_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dbf";
            this.saveFileDialog1.Filter = "dbfファイル|*.dbf";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dbf";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "dbfファイル|*.dbf";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1981, 295);
            this.Controls.Add(this.TaskListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "デイリービルドフレンズ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TaskListViewContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TaskListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ListView TaskListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NameSaveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogToolStripMenuItem;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.CheckBox ReportCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown IntervalNumericUpDown;
        private System.Windows.Forms.TextBox NowTimerTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox IntervalTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CheckTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ScheduleCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton ReBuildRadioButton;
        private System.Windows.Forms.RadioButton BuildRadioButton;
        private System.Windows.Forms.RadioButton NormalRadioButton;
        private System.Windows.Forms.TextBox TimerTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
    }
}

