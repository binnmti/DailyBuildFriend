
namespace DailyBuildFriend
{
    partial class CommandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandForm));
            this.label1 = new System.Windows.Forms.Label();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.Param1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Param2TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.DoCancelButton = new System.Windows.Forms.Button();
            this.Param1Label = new System.Windows.Forms.Label();
            this.Param2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "コマンド";
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Location = new System.Drawing.Point(13, 35);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.ReadOnly = true;
            this.CommandTextBox.Size = new System.Drawing.Size(585, 25);
            this.CommandTextBox.TabIndex = 1;
            // 
            // Param1TextBox
            // 
            this.Param1TextBox.Location = new System.Drawing.Point(13, 115);
            this.Param1TextBox.Name = "Param1TextBox";
            this.Param1TextBox.Size = new System.Drawing.Size(585, 25);
            this.Param1TextBox.TabIndex = 3;
            this.Param1TextBox.TextChanged += new System.EventHandler(this.Param1TextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "パラメータ1";
            // 
            // Param2TextBox
            // 
            this.Param2TextBox.Location = new System.Drawing.Point(13, 220);
            this.Param2TextBox.Name = "Param2TextBox";
            this.Param2TextBox.Size = new System.Drawing.Size(585, 25);
            this.Param2TextBox.TabIndex = 5;
            this.Param2TextBox.TextChanged += new System.EventHandler(this.Param2TextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "パラメータ2";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(439, 341);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DoCancelButton
            // 
            this.DoCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DoCancelButton.Location = new System.Drawing.Point(532, 341);
            this.DoCancelButton.Name = "DoCancelButton";
            this.DoCancelButton.Size = new System.Drawing.Size(75, 23);
            this.DoCancelButton.TabIndex = 7;
            this.DoCancelButton.Text = "キャンセル";
            this.DoCancelButton.UseVisualStyleBackColor = true;
            // 
            // Param1Label
            // 
            this.Param1Label.AutoSize = true;
            this.Param1Label.Location = new System.Drawing.Point(13, 157);
            this.Param1Label.Name = "Param1Label";
            this.Param1Label.Size = new System.Drawing.Size(52, 18);
            this.Param1Label.TabIndex = 8;
            this.Param1Label.Text = "label4";
            // 
            // Param2Label
            // 
            this.Param2Label.AutoSize = true;
            this.Param2Label.Location = new System.Drawing.Point(13, 262);
            this.Param2Label.Name = "Param2Label";
            this.Param2Label.Size = new System.Drawing.Size(52, 18);
            this.Param2Label.TabIndex = 9;
            this.Param2Label.Text = "label5";
            // 
            // CommandForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DoCancelButton;
            this.ClientSize = new System.Drawing.Size(641, 376);
            this.Controls.Add(this.Param2Label);
            this.Controls.Add(this.Param1Label);
            this.Controls.Add(this.DoCancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.Param2TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Param1TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandForm";
            this.Text = "コマンド";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.TextBox Param1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Param2TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button DoCancelButton;
        private System.Windows.Forms.Label Param1Label;
        private System.Windows.Forms.Label Param2Label;
    }
}