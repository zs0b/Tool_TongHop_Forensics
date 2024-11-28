﻿namespace VolWorkbench
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
            label_image_file = new Label();
            label_platform = new Label();
            label_command = new Label();
            txtpath = new TextBox();
            comboBox_platform = new ComboBox();
            comboBox_command = new ComboBox();
            button_browser_image = new Button();
            button_refresh_process_list = new Button();
            button_command_info = new Button();
            button_run = new Button();
            label_command_description = new Label();
            richTextBox_command_description = new RichTextBox();
            richTextBox_log = new RichTextBox();
            button_clear_log = new Button();
            button_save_to_file = new Button();
            button_copy_to_clipboard = new Button();
            button_about = new Button();
            button_exit = new Button();
            textBox_progress = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label_image_file
            // 
            label_image_file.AutoSize = true;
            label_image_file.Location = new Point(56, 18);
            label_image_file.Name = "label_image_file";
            label_image_file.Size = new Size(62, 15);
            label_image_file.TabIndex = 0;
            label_image_file.Text = "Image file:";
            // 
            // label_platform
            // 
            label_platform.AutoSize = true;
            label_platform.Location = new Point(65, 58);
            label_platform.Name = "label_platform";
            label_platform.Size = new Size(56, 15);
            label_platform.TabIndex = 1;
            label_platform.Text = "Platform:";
            // 
            // label_command
            // 
            label_command.AutoSize = true;
            label_command.Location = new Point(54, 95);
            label_command.Name = "label_command";
            label_command.Size = new Size(67, 15);
            label_command.TabIndex = 2;
            label_command.Text = "Command:";
            // 
            // txtpath
            // 
            txtpath.Location = new Point(124, 14);
            txtpath.Name = "txtpath";
            txtpath.ReadOnly = true;
            txtpath.Size = new Size(229, 23);
            txtpath.TabIndex = 3;
            txtpath.TextChanged += txtpath_TextChanged;
            // 
            // comboBox_platform
            // 
            comboBox_platform.FormattingEnabled = true;
            comboBox_platform.ImeMode = ImeMode.NoControl;
            comboBox_platform.Location = new Point(124, 54);
            comboBox_platform.Name = "comboBox_platform";
            comboBox_platform.Size = new Size(229, 23);
            comboBox_platform.TabIndex = 4;
            comboBox_platform.SelectedIndexChanged += comboBox_platform_SelectedIndexChanged;
            // 
            // comboBox_command
            // 
            comboBox_command.FormattingEnabled = true;
            comboBox_command.Location = new Point(124, 92);
            comboBox_command.Name = "comboBox_command";
            comboBox_command.Size = new Size(229, 23);
            comboBox_command.TabIndex = 5;
            comboBox_command.SelectedIndexChanged += comboBox_command_SelectedIndexChanged;
            // 
            // button_browser_image
            // 
            button_browser_image.Location = new Point(359, 14);
            button_browser_image.Name = "button_browser_image";
            button_browser_image.Size = new Size(146, 23);
            button_browser_image.TabIndex = 6;
            button_browser_image.Text = "Browser Image";
            button_browser_image.UseVisualStyleBackColor = true;
            button_browser_image.Click += button_browser_image_Click;
            // 
            // button_refresh_process_list
            // 
            button_refresh_process_list.Location = new Point(359, 54);
            button_refresh_process_list.Name = "button_refresh_process_list";
            button_refresh_process_list.Size = new Size(146, 23);
            button_refresh_process_list.TabIndex = 7;
            button_refresh_process_list.Text = "Refresh Process List";
            button_refresh_process_list.UseVisualStyleBackColor = true;
            button_refresh_process_list.Click += button_refresh_process_list_Click;
            // 
            // button_command_info
            // 
            button_command_info.Location = new Point(359, 92);
            button_command_info.Name = "button_command_info";
            button_command_info.Size = new Size(146, 23);
            button_command_info.TabIndex = 8;
            button_command_info.Text = "Command Info";
            button_command_info.UseVisualStyleBackColor = true;
            button_command_info.Click += button_command_info_Click;
            // 
            // button_run
            // 
            button_run.Location = new Point(359, 133);
            button_run.Name = "button_run";
            button_run.Size = new Size(146, 23);
            button_run.TabIndex = 9;
            button_run.Text = "Run";
            button_run.UseVisualStyleBackColor = true;
            button_run.Click += button_run_Click;
            // 
            // label_command_description
            // 
            label_command_description.AutoSize = true;
            label_command_description.Location = new Point(553, 17);
            label_command_description.Name = "label_command_description";
            label_command_description.Size = new Size(129, 15);
            label_command_description.TabIndex = 10;
            label_command_description.Text = "Command description:";
            // 
            // richTextBox_command_description
            // 
            richTextBox_command_description.Location = new Point(553, 35);
            richTextBox_command_description.Name = "richTextBox_command_description";
            richTextBox_command_description.ReadOnly = true;
            richTextBox_command_description.Size = new Size(246, 121);
            richTextBox_command_description.TabIndex = 11;
            richTextBox_command_description.Text = "In order to run a command:\n1- Browse an image file\n2- Get/Refresh process list\n3- Select a command from the list\n4- Enter command parameters\n5- Run command";
            // 
            // richTextBox_log
            // 
            richTextBox_log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_log.Location = new Point(12, 181);
            richTextBox_log.Name = "richTextBox_log";
            richTextBox_log.Size = new Size(1123, 203);
            richTextBox_log.TabIndex = 12;
            richTextBox_log.Text = "By zs0b - 3r0th3rcc\n--------------------\n\n";
            // 
            // button_clear_log
            // 
            button_clear_log.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_clear_log.Location = new Point(491, 415);
            button_clear_log.Name = "button_clear_log";
            button_clear_log.Size = new Size(124, 23);
            button_clear_log.TabIndex = 13;
            button_clear_log.Text = "Clear log";
            button_clear_log.UseVisualStyleBackColor = true;
            button_clear_log.Click += button_clear_log_Click;
            // 
            // button_save_to_file
            // 
            button_save_to_file.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_save_to_file.Location = new Point(621, 415);
            button_save_to_file.Name = "button_save_to_file";
            button_save_to_file.Size = new Size(124, 23);
            button_save_to_file.TabIndex = 14;
            button_save_to_file.Text = "Save to file";
            button_save_to_file.UseVisualStyleBackColor = true;
            button_save_to_file.Click += button_save_to_file_Click;
            // 
            // button_copy_to_clipboard
            // 
            button_copy_to_clipboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_copy_to_clipboard.Location = new Point(751, 415);
            button_copy_to_clipboard.Name = "button_copy_to_clipboard";
            button_copy_to_clipboard.Size = new Size(124, 23);
            button_copy_to_clipboard.TabIndex = 15;
            button_copy_to_clipboard.Text = "Copy to clipboard";
            button_copy_to_clipboard.UseVisualStyleBackColor = true;
            button_copy_to_clipboard.Click += button_copy_to_clipboard_Click;
            // 
            // button_about
            // 
            button_about.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_about.Location = new Point(881, 415);
            button_about.Name = "button_about";
            button_about.Size = new Size(124, 23);
            button_about.TabIndex = 16;
            button_about.Text = "About";
            button_about.UseVisualStyleBackColor = true;
            button_about.Click += button_about_Click;
            // 
            // button_exit
            // 
            button_exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_exit.Location = new Point(1011, 415);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(124, 23);
            button_exit.TabIndex = 17;
            button_exit.Text = "Exit";
            button_exit.UseVisualStyleBackColor = true;
            button_exit.Click += button_exit_Click;
            // 
            // textBox_progress
            // 
            textBox_progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox_progress.BackColor = SystemColors.Control;
            textBox_progress.BorderStyle = BorderStyle.None;
            textBox_progress.Location = new Point(12, 390);
            textBox_progress.Name = "textBox_progress";
            textBox_progress.ReadOnly = true;
            textBox_progress.Size = new Size(162, 16);
            textBox_progress.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Location = new Point(969, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(166, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 450);
            Controls.Add(pictureBox1);
            Controls.Add(textBox_progress);
            Controls.Add(button_exit);
            Controls.Add(button_about);
            Controls.Add(button_copy_to_clipboard);
            Controls.Add(button_save_to_file);
            Controls.Add(button_clear_log);
            Controls.Add(richTextBox_log);
            Controls.Add(richTextBox_command_description);
            Controls.Add(label_command_description);
            Controls.Add(button_run);
            Controls.Add(button_command_info);
            Controls.Add(button_refresh_process_list);
            Controls.Add(button_browser_image);
            Controls.Add(comboBox_command);
            Controls.Add(comboBox_platform);
            Controls.Add(txtpath);
            Controls.Add(label_command);
            Controls.Add(label_platform);
            Controls.Add(label_image_file);
            Name = "Form1";
            Text = "Volatility 3";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label_image_file;
        private Label label_platform;
        private Label label_command;
        private TextBox txtpath;
        private ComboBox comboBox_platform;
        private ComboBox comboBox_command;
        private Button button_browser_image;
        private Button button_refresh_process_list;
        private Button button_command_info;
        private Button button_run;
        private Label label_command_description;
        private RichTextBox richTextBox_command_description;
        private RichTextBox richTextBox_log;
        private Button button_clear_log;
        private Button button_save_to_file;
        private Button button_copy_to_clipboard;
        private Button button_about;
        private Button button_exit;
        private TextBox textBox_progress;
        private PictureBox pictureBox1;
    }
}
