
namespace DailyBuildFriend
{
    partial class RunForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunForm));
            this.label1 = new System.Windows.Forms.Label();
            this.Message1Label = new System.Windows.Forms.Label();
            this.Message2Label = new System.Windows.Forms.Label();
            this.SuspensionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.RevisionLabel = new System.Windows.Forms.Label();
            this.TaskLabel = new System.Windows.Forms.Label();
            this.CommandLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.label1.Location = new System.Drawing.Point(562, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "デイリービルド実行中";
            // 
            // Message1Label
            // 
            this.Message1Label.AutoSize = true;
            this.Message1Label.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.Message1Label.Location = new System.Drawing.Point(72, 167);
            this.Message1Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Message1Label.Name = "Message1Label";
            this.Message1Label.Size = new System.Drawing.Size(79, 28);
            this.Message1Label.TabIndex = 1;
            this.Message1Label.Text = "label2";
            // 
            // Message2Label
            // 
            this.Message2Label.AutoSize = true;
            this.Message2Label.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.Message2Label.Location = new System.Drawing.Point(72, 262);
            this.Message2Label.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Message2Label.Name = "Message2Label";
            this.Message2Label.Size = new System.Drawing.Size(79, 28);
            this.Message2Label.TabIndex = 2;
            this.Message2Label.Text = "label3";
            // 
            // SuspensionButton
            // 
            this.SuspensionButton.Location = new System.Drawing.Point(782, 375);
            this.SuspensionButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SuspensionButton.Name = "SuspensionButton";
            this.SuspensionButton.Size = new System.Drawing.Size(218, 78);
            this.SuspensionButton.TabIndex = 3;
            this.SuspensionButton.Text = "実行中断";
            this.SuspensionButton.UseVisualStyleBackColor = true;
            this.SuspensionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 488);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "現在実行中のコマンドは止まりません";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(734, 555);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(307, 34);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "実行後全タスクを終了";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // RevisionLabel
            // 
            this.RevisionLabel.AutoSize = true;
            this.RevisionLabel.Location = new System.Drawing.Point(1360, 63);
            this.RevisionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RevisionLabel.Name = "RevisionLabel";
            this.RevisionLabel.Size = new System.Drawing.Size(114, 30);
            this.RevisionLabel.TabIndex = 6;
            this.RevisionLabel.Text = "リビジョン";
            // 
            // TaskLabel
            // 
            this.TaskLabel.AutoSize = true;
            this.TaskLabel.Location = new System.Drawing.Point(75, 488);
            this.TaskLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(114, 30);
            this.TaskLabel.TabIndex = 7;
            this.TaskLabel.Text = "リビジョン";
            // 
            // CommandLabel
            // 
            this.CommandLabel.AutoSize = true;
            this.CommandLabel.Location = new System.Drawing.Point(75, 562);
            this.CommandLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CommandLabel.Name = "CommandLabel";
            this.CommandLabel.Size = new System.Drawing.Size(114, 30);
            this.CommandLabel.TabIndex = 8;
            this.CommandLabel.Text = "リビジョン";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1330, 488);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 30);
            this.label8.TabIndex = 9;
            this.label8.Text = "タイムアウト";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1501, 483);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(158, 37);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1501, 550);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(158, 37);
            this.textBox2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1330, 555);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "経過時間";
            // 
            // RunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1693, 678);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CommandLabel);
            this.Controls.Add(this.TaskLabel);
            this.Controls.Add(this.RevisionLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SuspensionButton);
            this.Controls.Add(this.Message2Label);
            this.Controls.Add(this.Message1Label);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "RunForm";
            this.Text = "RunForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Message1Label;
        private System.Windows.Forms.Label Message2Label;
        private System.Windows.Forms.Button SuspensionButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label RevisionLabel;
        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.Label CommandLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
    }
}