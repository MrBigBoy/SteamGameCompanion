namespace SteamGameCompanion
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Id1TextBox = new System.Windows.Forms.TextBox();
            this.Id2TextBox = new System.Windows.Forms.TextBox();
            this.GameListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id 2";
            // 
            // Id1TextBox
            // 
            this.Id1TextBox.Location = new System.Drawing.Point(52, 24);
            this.Id1TextBox.Multiline = true;
            this.Id1TextBox.Name = "Id1TextBox";
            this.Id1TextBox.Size = new System.Drawing.Size(218, 22);
            this.Id1TextBox.TabIndex = 2;
            // 
            // Id2TextBox
            // 
            this.Id2TextBox.Location = new System.Drawing.Point(52, 67);
            this.Id2TextBox.Multiline = true;
            this.Id2TextBox.Name = "Id2TextBox";
            this.Id2TextBox.Size = new System.Drawing.Size(218, 22);
            this.Id2TextBox.TabIndex = 3;
            // 
            // GameListBox
            // 
            this.GameListBox.FormattingEnabled = true;
            this.GameListBox.ItemHeight = 16;
            this.GameListBox.Location = new System.Drawing.Point(17, 113);
            this.GameListBox.Name = "GameListBox";
            this.GameListBox.Size = new System.Drawing.Size(253, 84);
            this.GameListBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Run Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GameListBox);
            this.Controls.Add(this.Id2TextBox);
            this.Controls.Add(this.Id1TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Id1TextBox;
        private System.Windows.Forms.TextBox Id2TextBox;
        private System.Windows.Forms.ListBox GameListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

