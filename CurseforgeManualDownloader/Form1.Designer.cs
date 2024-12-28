namespace CurseforgeManualDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            openFileDialog = new OpenFileDialog();
            button2 = new Button();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Folder not selected.";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(149, 23);
            button1.TabIndex = 1;
            button1.Text = "Select the mods folder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.ApplicationData;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Profile packages|*.zip";
            // 
            // button2
            // 
            button2.Location = new Point(12, 65);
            button2.Name = "button2";
            button2.Size = new Size(149, 23);
            button2.TabIndex = 3;
            button2.Text = "Select the profile .zip file";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 91);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 2;
            label2.Text = "File not selected.";
            // 
            // button3
            // 
            button3.Location = new Point(12, 164);
            button3.Name = "button3";
            button3.Size = new Size(149, 45);
            button3.TabIndex = 4;
            button3.Text = "DOWNLOAD";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(261, 15);
            label3.TabIndex = 5;
            label3.Text = "Enter your API key below and click to download.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(427, 23);
            textBox1.TabIndex = 6;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(167, 164);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(272, 23);
            progressBar1.Step = 1;
            progressBar1.TabIndex = 7;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(167, 186);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(272, 23);
            progressBar2.Step = 1;
            progressBar2.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 212);
            label4.Name = "label4";
            label4.Size = new Size(184, 15);
            label4.TabIndex = 9;
            label4.Text = "Downloading process not started.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(12, 227);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 10;
            label5.Text = "No errors detected.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 267);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "CurseForge manual downloader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog;
        private OpenFileDialog openFileDialog;
        private Button button2;
        private Label label2;
        private Button button3;
        private Label label3;
        private TextBox textBox1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label4;
        private Label label5;
    }
}
