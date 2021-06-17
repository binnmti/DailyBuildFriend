
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.TimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.ReportCheckBox = new System.Windows.Forms.CheckBox();
            this.IntervalCheckBox = new System.Windows.Forms.CheckBox();
            this.TimerCheckBox = new System.Windows.Forms.CheckBox();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProjectFolderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TaskNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.コマンドCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 610);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 100);
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
            this.OKButton.Location = new System.Drawing.Point(617, 36);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 32);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 217);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(827, 393);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TimeoutNumericUpDown);
            this.panel2.Controls.Add(this.TimeoutCheckBox);
            this.panel2.Controls.Add(this.ReportCheckBox);
            this.panel2.Controls.Add(this.IntervalCheckBox);
            this.panel2.Controls.Add(this.TimerCheckBox);
            this.panel2.Controls.Add(this.FileNameTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ProjectFolderTextBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TaskNameTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 184);
            this.panel2.TabIndex = 2;
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(586, 131);
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(74, 25);
            this.TimeoutNumericUpDown.TabIndex = 10;
            this.TimeoutNumericUpDown.ValueChanged += new System.EventHandler(this.TimeoutNumericUpDown_ValueChanged);
            // 
            // TimeoutCheckBox
            // 
            this.TimeoutCheckBox.AutoSize = true;
            this.TimeoutCheckBox.Location = new System.Drawing.Point(465, 131);
            this.TimeoutCheckBox.Name = "TimeoutCheckBox";
            this.TimeoutCheckBox.Size = new System.Drawing.Size(114, 22);
            this.TimeoutCheckBox.TabIndex = 9;
            this.TimeoutCheckBox.Text = "タイムアウト";
            this.TimeoutCheckBox.UseVisualStyleBackColor = true;
            this.TimeoutCheckBox.CheckedChanged += new System.EventHandler(this.TimeoutCheckBox_CheckedChanged);
            // 
            // ReportCheckBox
            // 
            this.ReportCheckBox.AutoSize = true;
            this.ReportCheckBox.Location = new System.Drawing.Point(368, 131);
            this.ReportCheckBox.Name = "ReportCheckBox";
            this.ReportCheckBox.Size = new System.Drawing.Size(91, 22);
            this.ReportCheckBox.TabIndex = 8;
            this.ReportCheckBox.Text = "レポート";
            this.ReportCheckBox.UseVisualStyleBackColor = true;
            this.ReportCheckBox.CheckedChanged += new System.EventHandler(this.ReportCheckBox_CheckedChanged);
            // 
            // IntervalCheckBox
            // 
            this.IntervalCheckBox.AutoSize = true;
            this.IntervalCheckBox.Location = new System.Drawing.Point(245, 131);
            this.IntervalCheckBox.Name = "IntervalCheckBox";
            this.IntervalCheckBox.Size = new System.Drawing.Size(117, 22);
            this.IntervalCheckBox.TabIndex = 7;
            this.IntervalCheckBox.Text = "インターバル";
            this.IntervalCheckBox.UseVisualStyleBackColor = true;
            this.IntervalCheckBox.CheckedChanged += new System.EventHandler(this.IntervalCheckBox_CheckedChanged);
            // 
            // TimerCheckBox
            // 
            this.TimerCheckBox.AutoSize = true;
            this.TimerCheckBox.Location = new System.Drawing.Point(151, 131);
            this.TimerCheckBox.Name = "TimerCheckBox";
            this.TimerCheckBox.Size = new System.Drawing.Size(88, 22);
            this.TimerCheckBox.TabIndex = 6;
            this.TimerCheckBox.Text = "タイマー";
            this.TimerCheckBox.UseVisualStyleBackColor = true;
            this.TimerCheckBox.CheckedChanged += new System.EventHandler(this.TimerCheckBox_CheckedChanged);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(195, 50);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(620, 25);
            this.FileNameTextBox.TabIndex = 5;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "ファイル名(日本語不可)";
            // 
            // ProjectFolderTextBox
            // 
            this.ProjectFolderTextBox.Location = new System.Drawing.Point(195, 81);
            this.ProjectFolderTextBox.Name = "ProjectFolderTextBox";
            this.ProjectFolderTextBox.Size = new System.Drawing.Size(620, 25);
            this.ProjectFolderTextBox.TabIndex = 3;
            this.ProjectFolderTextBox.TextChanged += new System.EventHandler(this.ProjectFolderTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "プロジェクトフォルダ";
            // 
            // TaskNameTextBox
            // 
            this.TaskNameTextBox.Location = new System.Drawing.Point(195, 19);
            this.TaskNameTextBox.Name = "TaskNameTextBox";
            this.TaskNameTextBox.Size = new System.Drawing.Size(620, 25);
            this.TaskNameTextBox.TabIndex = 1;
            this.TaskNameTextBox.TextChanged += new System.EventHandler(this.TaskNameTextBoxTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "タスク名";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コマンドCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // コマンドCToolStripMenuItem
            // 
            this.コマンドCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem});
            this.コマンドCToolStripMenuItem.Name = "コマンドCToolStripMenuItem";
            this.コマンドCToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.コマンドCToolStripMenuItem.Text = "コマンド(&C)";
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            this.追加ToolStripMenuItem.Size = new System.Drawing.Size(172, 34);
            this.追加ToolStripMenuItem.Text = "追加(&A)";
            this.追加ToolStripMenuItem.Click += new System.EventHandler(this.追加ToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "分";
            // 
            // TaskForm
            // 
            this.ClientSize = new System.Drawing.Size(827, 710);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TaskForm";
            this.Text = "タスク";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem コマンドCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProjectFolderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TaskNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimeoutNumericUpDown;
        private System.Windows.Forms.CheckBox TimeoutCheckBox;
        private System.Windows.Forms.CheckBox ReportCheckBox;
        private System.Windows.Forms.CheckBox IntervalCheckBox;
        private System.Windows.Forms.CheckBox TimerCheckBox;
        private System.Windows.Forms.Label label4;
    }
}

