﻿
namespace DailyBuildFriend
{
    partial class ReportForm
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
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MemberListView = new System.Windows.Forms.ListView();
            this.SuccessMessageTextBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuccessTestButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(209, 39);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(431, 37);
            this.UserNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "メールアドレス";
            // 
            // MemberListView
            // 
            this.MemberListView.CheckBoxes = true;
            this.MemberListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MemberListView.FullRowSelect = true;
            this.MemberListView.GridLines = true;
            this.MemberListView.HideSelection = false;
            this.MemberListView.LabelEdit = true;
            this.MemberListView.Location = new System.Drawing.Point(12, 158);
            this.MemberListView.MultiSelect = false;
            this.MemberListView.Name = "MemberListView";
            this.MemberListView.Size = new System.Drawing.Size(1318, 596);
            this.MemberListView.TabIndex = 2;
            this.MemberListView.UseCompatibleStateImageBehavior = false;
            this.MemberListView.View = System.Windows.Forms.View.Details;
            this.MemberListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.MemberListView_AfterLabelEdit);
            this.MemberListView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.MemberListView_BeforeLabelEdit);
            this.MemberListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MemberListView_KeyUp);
            // 
            // SuccessMessageTextBox
            // 
            this.SuccessMessageTextBox.Location = new System.Drawing.Point(17, 823);
            this.SuccessMessageTextBox.Multiline = true;
            this.SuccessMessageTextBox.Name = "SuccessMessageTextBox";
            this.SuccessMessageTextBox.Size = new System.Drawing.Size(664, 194);
            this.SuccessMessageTextBox.TabIndex = 3;
            this.SuccessMessageTextBox.Text = "デイリービルドが成功しました。";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(701, 823);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(629, 194);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "デイリービルドが失敗しました。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 779);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "成功時メッセージ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(696, 779);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "失敗時メッセージ";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "メールアドレス";
            this.columnHeader1.Width = 500;
            // 
            // SuccessTestButton
            // 
            this.SuccessTestButton.Location = new System.Drawing.Point(485, 1033);
            this.SuccessTestButton.Name = "SuccessTestButton";
            this.SuccessTestButton.Size = new System.Drawing.Size(196, 59);
            this.SuccessTestButton.TabIndex = 7;
            this.SuccessTestButton.Text = "テスト送信";
            this.SuccessTestButton.UseVisualStyleBackColor = true;
            this.SuccessTestButton.Click += new System.EventHandler(this.SuccessTestButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1132, 1033);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 59);
            this.button2.TabIndex = 8;
            this.button2.Text = "テスト送信";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1002, 1123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 59);
            this.button3.TabIndex = 9;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1178, 1123);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 59);
            this.button4.TabIndex = 10;
            this.button4.Text = "キャンセル";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(664, 77);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(196, 59);
            this.AddUserButton.TabIndex = 11;
            this.AddUserButton.Text = "追加";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "パスワード";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(209, 88);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(431, 37);
            this.PasswordTextBox.TabIndex = 12;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "パスワード";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 1194);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SuccessTestButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.SuccessMessageTextBox);
            this.Controls.Add(this.MemberListView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTextBox);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView MemberListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox SuccessMessageTextBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SuccessTestButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswordTextBox;
    }
}