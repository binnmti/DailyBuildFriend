﻿
namespace DailyBuildFriend
{
    partial class TaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CommandListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.コマンドCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitCloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSビルドVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSTestTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommandListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.TaskNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectFolderTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.TimerCheckBox = new System.Windows.Forms.CheckBox();
            this.IntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.ReportCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.TimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.CommandListViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 563);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 94);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(709, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(575, 36);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(110, 32);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CommandListView
            // 
            this.CommandListView.CheckBoxes = true;
            this.CommandListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.CommandListView.ContextMenuStrip = this.CommandListViewContextMenuStrip;
            this.CommandListView.FullRowSelect = true;
            this.CommandListView.GridLines = true;
            this.CommandListView.HideSelection = false;
            this.CommandListView.Location = new System.Drawing.Point(0, 217);
            this.CommandListView.MultiSelect = false;
            this.CommandListView.Name = "CommandListView";
            this.CommandListView.Size = new System.Drawing.Size(864, 340);
            this.CommandListView.TabIndex = 1;
            this.CommandListView.UseCompatibleStateImageBehavior = false;
            this.CommandListView.View = System.Windows.Forms.View.Details;
            this.CommandListView.DoubleClick += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "コマンド名";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "内容";
            this.columnHeader2.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コマンドCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // コマンドCToolStripMenuItem
            // 
            this.コマンドCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GitCloneToolStripMenuItem,
            this.vSビルドVToolStripMenuItem,
            this.vSTestTToolStripMenuItem});
            this.コマンドCToolStripMenuItem.Name = "コマンドCToolStripMenuItem";
            this.コマンドCToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.コマンドCToolStripMenuItem.Text = "コマンド(&C)";
            // 
            // GitCloneToolStripMenuItem
            // 
            this.GitCloneToolStripMenuItem.Name = "GitCloneToolStripMenuItem";
            this.GitCloneToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.GitCloneToolStripMenuItem.Text = "Gitクローン(&C)";
            this.GitCloneToolStripMenuItem.Click += new System.EventHandler(this.GitCloneToolStripMenuItem_Click);
            // 
            // vSビルドVToolStripMenuItem
            // 
            this.vSビルドVToolStripMenuItem.Name = "vSビルドVToolStripMenuItem";
            this.vSビルドVToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.vSビルドVToolStripMenuItem.Text = "VSビルド(&B)";
            // 
            // vSTestTToolStripMenuItem
            // 
            this.vSTestTToolStripMenuItem.Name = "vSTestTToolStripMenuItem";
            this.vSTestTToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.vSTestTToolStripMenuItem.Text = "VSテスト(&T)";
            // 
            // CommandListViewContextMenuStrip
            // 
            this.CommandListViewContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CommandListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.RunToolStripMenuItem});
            this.CommandListViewContextMenuStrip.Name = "CommandListViewContextMenuStrip";
            this.CommandListViewContextMenuStrip.Size = new System.Drawing.Size(144, 100);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.EditToolStripMenuItem.Text = "編集(&E)";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.DeleteToolStripMenuItem.Text = "削除(&D)";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // RunToolStripMenuItem
            // 
            this.RunToolStripMenuItem.Name = "RunToolStripMenuItem";
            this.RunToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.RunToolStripMenuItem.Text = "起動(&R)";
            this.RunToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "タスク名";
            // 
            // TaskNameTextBox
            // 
            this.TaskNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskNameTextBox.Location = new System.Drawing.Point(195, 56);
            this.TaskNameTextBox.Name = "TaskNameTextBox";
            this.TaskNameTextBox.Size = new System.Drawing.Size(657, 25);
            this.TaskNameTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "プロジェクトフォルダ";
            // 
            // ProjectFolderTextBox
            // 
            this.ProjectFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectFolderTextBox.Location = new System.Drawing.Point(195, 118);
            this.ProjectFolderTextBox.Name = "ProjectFolderTextBox";
            this.ProjectFolderTextBox.Size = new System.Drawing.Size(657, 25);
            this.ProjectFolderTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "ファイル名(日本語不可)";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameTextBox.Location = new System.Drawing.Point(195, 87);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(657, 25);
            this.FileNameTextBox.TabIndex = 17;
            // 
            // TimerCheckBox
            // 
            this.TimerCheckBox.AutoSize = true;
            this.TimerCheckBox.Location = new System.Drawing.Point(195, 159);
            this.TimerCheckBox.Name = "TimerCheckBox";
            this.TimerCheckBox.Size = new System.Drawing.Size(88, 22);
            this.TimerCheckBox.TabIndex = 18;
            this.TimerCheckBox.Text = "タイマー";
            this.TimerCheckBox.UseVisualStyleBackColor = true;
            // 
            // IntervalCheckBox
            // 
            this.IntervalCheckBox.AutoSize = true;
            this.IntervalCheckBox.Location = new System.Drawing.Point(289, 159);
            this.IntervalCheckBox.Name = "IntervalCheckBox";
            this.IntervalCheckBox.Size = new System.Drawing.Size(117, 22);
            this.IntervalCheckBox.TabIndex = 19;
            this.IntervalCheckBox.Text = "インターバル";
            this.IntervalCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReportCheckBox
            // 
            this.ReportCheckBox.AutoSize = true;
            this.ReportCheckBox.Location = new System.Drawing.Point(412, 159);
            this.ReportCheckBox.Name = "ReportCheckBox";
            this.ReportCheckBox.Size = new System.Drawing.Size(91, 22);
            this.ReportCheckBox.TabIndex = 20;
            this.ReportCheckBox.Text = "レポート";
            this.ReportCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeoutCheckBox
            // 
            this.TimeoutCheckBox.AutoSize = true;
            this.TimeoutCheckBox.Location = new System.Drawing.Point(509, 159);
            this.TimeoutCheckBox.Name = "TimeoutCheckBox";
            this.TimeoutCheckBox.Size = new System.Drawing.Size(114, 22);
            this.TimeoutCheckBox.TabIndex = 21;
            this.TimeoutCheckBox.Text = "タイムアウト";
            this.TimeoutCheckBox.UseVisualStyleBackColor = true;
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(630, 159);
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(74, 25);
            this.TimeoutNumericUpDown.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "分";
            // 
            // TaskForm
            // 
            this.ClientSize = new System.Drawing.Size(864, 657);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeoutNumericUpDown);
            this.Controls.Add(this.TimeoutCheckBox);
            this.Controls.Add(this.ReportCheckBox);
            this.Controls.Add(this.IntervalCheckBox);
            this.Controls.Add(this.TimerCheckBox);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProjectFolderTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TaskNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommandListView);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TaskForm";
            this.Text = "タスク";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.CommandListViewContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView CommandListView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem コマンドCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GitCloneToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem vSビルドVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vSTestTToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CommandListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TaskNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProjectFolderTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.CheckBox TimerCheckBox;
        private System.Windows.Forms.CheckBox IntervalCheckBox;
        private System.Windows.Forms.CheckBox ReportCheckBox;
        private System.Windows.Forms.CheckBox TimeoutCheckBox;
        private System.Windows.Forms.NumericUpDown TimeoutNumericUpDown;
        private System.Windows.Forms.Label label4;
    }
}

