namespace VolWorkbench
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
            button_stop = new Button();
            panel_bigpools = new Panel();
            checkBox_Show_freed_regions = new CheckBox();
            groupBox_command_paratemer = new GroupBox();
            panel_pid = new Panel();
            checkBox_process_ID = new CheckBox();
            comboBox_PID = new ComboBox();
            panel_envars = new Panel();
            checkBox_process_ID_envars = new CheckBox();
            comboBox_PID_envars = new ComboBox();
            checkBox_suppress_variables = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_bigpools.SuspendLayout();
            groupBox_command_paratemer.SuspendLayout();
            panel_pid.SuspendLayout();
            panel_envars.SuspendLayout();
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
            richTextBox_log.Location = new Point(12, 229);
            richTextBox_log.Name = "richTextBox_log";
            richTextBox_log.Size = new Size(1059, 356);
            richTextBox_log.TabIndex = 12;
            richTextBox_log.Text = "By zs0b - 3r0th3rcc\n--------------------\n\n";
            // 
            // button_clear_log
            // 
            button_clear_log.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_clear_log.Location = new Point(427, 616);
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
            button_save_to_file.Location = new Point(557, 616);
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
            button_copy_to_clipboard.Location = new Point(687, 616);
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
            button_about.Location = new Point(817, 616);
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
            button_exit.Location = new Point(947, 616);
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
            textBox_progress.Location = new Point(12, 591);
            textBox_progress.Name = "textBox_progress";
            textBox_progress.ReadOnly = true;
            textBox_progress.Size = new Size(162, 16);
            textBox_progress.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Location = new Point(905, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(166, 166);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // button_stop
            // 
            button_stop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_stop.Location = new Point(297, 616);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(124, 23);
            button_stop.TabIndex = 20;
            button_stop.Text = "Stop";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // panel_bigpools
            // 
            panel_bigpools.Controls.Add(checkBox_Show_freed_regions);
            panel_bigpools.Location = new Point(9, 22);
            panel_bigpools.Name = "panel_bigpools";
            panel_bigpools.Size = new Size(282, 72);
            panel_bigpools.TabIndex = 21;
            panel_bigpools.Paint += panel_bigpools_Paint;
            // 
            // checkBox_Show_freed_regions
            // 
            checkBox_Show_freed_regions.AutoSize = true;
            checkBox_Show_freed_regions.Location = new Point(13, 12);
            checkBox_Show_freed_regions.Name = "checkBox_Show_freed_regions";
            checkBox_Show_freed_regions.Size = new Size(127, 19);
            checkBox_Show_freed_regions.TabIndex = 0;
            checkBox_Show_freed_regions.Text = "Show freed regions";
            checkBox_Show_freed_regions.UseVisualStyleBackColor = true;
            checkBox_Show_freed_regions.CheckedChanged += checkBox_Show_freed_regions_CheckedChanged;
            // 
            // groupBox_command_paratemer
            // 
            groupBox_command_paratemer.Controls.Add(panel_envars);
            groupBox_command_paratemer.Controls.Add(panel_pid);
            groupBox_command_paratemer.Controls.Add(panel_bigpools);
            groupBox_command_paratemer.Location = new Point(56, 123);
            groupBox_command_paratemer.Name = "groupBox_command_paratemer";
            groupBox_command_paratemer.Size = new Size(297, 100);
            groupBox_command_paratemer.TabIndex = 22;
            groupBox_command_paratemer.TabStop = false;
            groupBox_command_paratemer.Text = "Command Parameters";
            // 
            // panel_pid
            // 
            panel_pid.Controls.Add(checkBox_process_ID);
            panel_pid.Controls.Add(comboBox_PID);
            panel_pid.Location = new Point(9, 22);
            panel_pid.Name = "panel_pid";
            panel_pid.Size = new Size(282, 72);
            panel_pid.TabIndex = 23;
            panel_pid.Paint += panel_pid_Paint;
            // 
            // checkBox_process_ID
            // 
            checkBox_process_ID.AutoSize = true;
            checkBox_process_ID.Location = new Point(13, 11);
            checkBox_process_ID.Name = "checkBox_process_ID";
            checkBox_process_ID.Size = new Size(80, 19);
            checkBox_process_ID.TabIndex = 0;
            checkBox_process_ID.Text = "Process ID";
            checkBox_process_ID.UseVisualStyleBackColor = true;
            checkBox_process_ID.CheckedChanged += checkBox_process_ID_CheckedChanged;
            // 
            // comboBox_PID
            // 
            comboBox_PID.FormattingEnabled = true;
            comboBox_PID.Location = new Point(130, 7);
            comboBox_PID.Name = "comboBox_PID";
            comboBox_PID.Size = new Size(149, 23);
            comboBox_PID.TabIndex = 1;
            comboBox_PID.SelectedIndexChanged += comboBox_PID_SelectedIndexChanged;
            // 
            // panel_envars
            // 
            panel_envars.Controls.Add(checkBox_suppress_variables);
            panel_envars.Controls.Add(comboBox_PID_envars);
            panel_envars.Controls.Add(checkBox_process_ID_envars);
            panel_envars.Location = new Point(9, 23);
            panel_envars.Name = "panel_envars";
            panel_envars.Size = new Size(282, 71);
            panel_envars.TabIndex = 23;
            panel_envars.Paint += panel_envars_Paint;
            // 
            // checkBox_process_ID_envars
            // 
            checkBox_process_ID_envars.AutoSize = true;
            checkBox_process_ID_envars.Location = new Point(12, 13);
            checkBox_process_ID_envars.Name = "checkBox_process_ID_envars";
            checkBox_process_ID_envars.Size = new Size(80, 19);
            checkBox_process_ID_envars.TabIndex = 1;
            checkBox_process_ID_envars.Text = "Process ID";
            checkBox_process_ID_envars.UseVisualStyleBackColor = true;
            checkBox_process_ID_envars.CheckedChanged += checkBox_process_ID_envars_CheckedChanged;
            // 
            // comboBox_PID_envars
            // 
            comboBox_PID_envars.FormattingEnabled = true;
            comboBox_PID_envars.Location = new Point(130, 8);
            comboBox_PID_envars.Name = "comboBox_PID_envars";
            comboBox_PID_envars.Size = new Size(149, 23);
            comboBox_PID_envars.TabIndex = 2;
            comboBox_PID_envars.SelectedIndexChanged += comboBox_PID_envars_SelectedIndexChanged;
            // 
            // checkBox_suppress_variables
            // 
            checkBox_suppress_variables.AutoSize = true;
            checkBox_suppress_variables.Location = new Point(12, 38);
            checkBox_suppress_variables.Name = "checkBox_suppress_variables";
            checkBox_suppress_variables.Size = new Size(122, 19);
            checkBox_suppress_variables.TabIndex = 3;
            checkBox_suppress_variables.Text = "Suppress variables";
            checkBox_suppress_variables.UseVisualStyleBackColor = true;
            checkBox_suppress_variables.CheckedChanged += checkBox_suppress_variables_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 651);
            Controls.Add(groupBox_command_paratemer);
            Controls.Add(button_stop);
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
            panel_bigpools.ResumeLayout(false);
            panel_bigpools.PerformLayout();
            groupBox_command_paratemer.ResumeLayout(false);
            panel_pid.ResumeLayout(false);
            panel_pid.PerformLayout();
            panel_envars.ResumeLayout(false);
            panel_envars.PerformLayout();
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
        private Button button_stop;
        private Panel panel_bigpools;
        private GroupBox groupBox_command_paratemer;
        private CheckBox checkBox_Show_freed_regions;
        private Panel panel_pid;
        private ComboBox comboBox_PID;
        private CheckBox checkBox_process_ID;
        private Panel panel_envars;
        private CheckBox checkBox_process_ID_envars;
        private ComboBox comboBox_PID_envars;
        private CheckBox checkBox_suppress_variables;
    }
}
