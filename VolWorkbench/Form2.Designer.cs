namespace VolWorkbench
{
    partial class Form_Login
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
            panel1 = new Panel();
            label_registerhere = new Label();
            label_donthaveaccount = new Label();
            textBox_login_password = new TextBox();
            label_login_password = new Label();
            textBox_login_username = new TextBox();
            checkBox_showpassword = new CheckBox();
            button_login = new Button();
            label_login_username = new Label();
            label2 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label_registerhere);
            panel1.Controls.Add(label_donthaveaccount);
            panel1.Controls.Add(textBox_login_password);
            panel1.Controls.Add(label_login_password);
            panel1.Controls.Add(textBox_login_username);
            panel1.Controls.Add(checkBox_showpassword);
            panel1.Controls.Add(button_login);
            panel1.Controls.Add(label_login_username);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 516);
            panel1.TabIndex = 0;
            // 
            // label_registerhere
            // 
            label_registerhere.AutoSize = true;
            label_registerhere.Cursor = Cursors.Hand;
            label_registerhere.Font = new Font("MS PGothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_registerhere.Location = new Point(640, 436);
            label_registerhere.Name = "label_registerhere";
            label_registerhere.Size = new Size(97, 13);
            label_registerhere.TabIndex = 12;
            label_registerhere.Text = "Register here";
            label_registerhere.Click += label_registerhere_Click;
            // 
            // label_donthaveaccount
            // 
            label_donthaveaccount.AutoSize = true;
            label_donthaveaccount.Font = new Font("MS PGothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_donthaveaccount.Location = new Point(490, 436);
            label_donthaveaccount.Name = "label_donthaveaccount";
            label_donthaveaccount.Size = new Size(144, 13);
            label_donthaveaccount.TabIndex = 11;
            label_donthaveaccount.Text = "Don't have an account ?";
            // 
            // textBox_login_password
            // 
            textBox_login_password.Location = new Point(483, 252);
            textBox_login_password.Multiline = true;
            textBox_login_password.Name = "textBox_login_password";
            textBox_login_password.Size = new Size(361, 28);
            textBox_login_password.TabIndex = 10;
            textBox_login_password.TextChanged += textBox_login_password_TextChanged;
            // 
            // label_login_password
            // 
            label_login_password.AutoSize = true;
            label_login_password.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_login_password.Location = new Point(483, 224);
            label_login_password.Name = "label_login_password";
            label_login_password.Size = new Size(71, 16);
            label_login_password.TabIndex = 9;
            label_login_password.Text = "Password";
            // 
            // textBox_login_username
            // 
            textBox_login_username.Location = new Point(484, 180);
            textBox_login_username.Multiline = true;
            textBox_login_username.Name = "textBox_login_username";
            textBox_login_username.Size = new Size(360, 28);
            textBox_login_username.TabIndex = 8;
            // 
            // checkBox_showpassword
            // 
            checkBox_showpassword.AutoSize = true;
            checkBox_showpassword.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_showpassword.Location = new Point(715, 344);
            checkBox_showpassword.Name = "checkBox_showpassword";
            checkBox_showpassword.Size = new Size(129, 20);
            checkBox_showpassword.TabIndex = 7;
            checkBox_showpassword.Text = "Show password";
            checkBox_showpassword.UseVisualStyleBackColor = true;
            checkBox_showpassword.CheckedChanged += checkBox_showpassword_CheckedChanged;
            // 
            // button_login
            // 
            button_login.BackColor = Color.MidnightBlue;
            button_login.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_login.ForeColor = SystemColors.ButtonHighlight;
            button_login.Location = new Point(483, 344);
            button_login.Name = "button_login";
            button_login.Size = new Size(121, 39);
            button_login.TabIndex = 6;
            button_login.Text = "Login";
            button_login.UseVisualStyleBackColor = false;
            button_login.Click += button_login_Click;
            // 
            // label_login_username
            // 
            label_login_username.AutoSize = true;
            label_login_username.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_login_username.Location = new Point(483, 153);
            label_login_username.Name = "label_login_username";
            label_login_username.Size = new Size(74, 16);
            label_login_username.TabIndex = 2;
            label_login_username.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS PGothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(475, 83);
            label2.Name = "label2";
            label2.Size = new Size(129, 29);
            label2.TabIndex = 1;
            label2.Text = "Welcome";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.Navy;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 516);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_white_halloween;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(63, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(211, 197);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(24, 307);
            label1.Name = "label1";
            label1.Size = new Size(287, 45);
            label1.TabIndex = 0;
            label1.Text = "Tool Forensics";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(154, 367);
            label3.Name = "label3";
            label3.Size = new Size(141, 16);
            label3.TabIndex = 15;
            label3.Text = "By z$0b.3r0th3r CC";
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 513);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form_Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tool Forensics";
            FormClosing += Form_Login_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private CheckBox checkBox_showpassword;
        private Button button_login;
        private Label label_login_username;
        private Label label2;
        private TextBox textBox_login_password;
        private Label label_login_password;
        private TextBox textBox_login_username;
        private Label label_registerhere;
        private Label label_donthaveaccount;
        private PictureBox pictureBox1;
        private Label label3;
    }
}