namespace VolWorkbench
{
    partial class Sigup
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
            textBox_signup_email = new TextBox();
            label_signup_email = new Label();
            label_signuo_loginhere = new Label();
            label_signup_alreadyhaveaccount = new Label();
            textBox_signup_password = new TextBox();
            label_signup_password = new Label();
            textBox_signup_username = new TextBox();
            checkBox_signup_showpassword = new CheckBox();
            button_signup_login = new Button();
            label_signup_username = new Label();
            label_signup_getstarted = new Label();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox_signup_email);
            panel1.Controls.Add(label_signup_email);
            panel1.Controls.Add(label_signuo_loginhere);
            panel1.Controls.Add(label_signup_alreadyhaveaccount);
            panel1.Controls.Add(textBox_signup_password);
            panel1.Controls.Add(label_signup_password);
            panel1.Controls.Add(textBox_signup_username);
            panel1.Controls.Add(checkBox_signup_showpassword);
            panel1.Controls.Add(button_signup_login);
            panel1.Controls.Add(label_signup_username);
            panel1.Controls.Add(label_signup_getstarted);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 516);
            panel1.TabIndex = 1;
            // 
            // textBox_signup_email
            // 
            textBox_signup_email.Location = new Point(484, 164);
            textBox_signup_email.Multiline = true;
            textBox_signup_email.Name = "textBox_signup_email";
            textBox_signup_email.Size = new Size(360, 28);
            textBox_signup_email.TabIndex = 14;
            // 
            // label_signup_email
            // 
            label_signup_email.AutoSize = true;
            label_signup_email.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_signup_email.Location = new Point(483, 137);
            label_signup_email.Name = "label_signup_email";
            label_signup_email.Size = new Size(99, 16);
            label_signup_email.TabIndex = 13;
            label_signup_email.Text = "Email address";
            // 
            // label_signuo_loginhere
            // 
            label_signuo_loginhere.AutoSize = true;
            label_signuo_loginhere.Cursor = Cursors.Hand;
            label_signuo_loginhere.Font = new Font("MS PGothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_signuo_loginhere.Location = new Point(652, 436);
            label_signuo_loginhere.Name = "label_signuo_loginhere";
            label_signuo_loginhere.Size = new Size(77, 13);
            label_signuo_loginhere.TabIndex = 12;
            label_signuo_loginhere.Text = "Login here";
            label_signuo_loginhere.Click += label_signuo_loginhere_Click;
            // 
            // label_signup_alreadyhaveaccount
            // 
            label_signup_alreadyhaveaccount.AutoSize = true;
            label_signup_alreadyhaveaccount.Font = new Font("MS PGothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_signup_alreadyhaveaccount.Location = new Point(491, 436);
            label_signup_alreadyhaveaccount.Name = "label_signup_alreadyhaveaccount";
            label_signup_alreadyhaveaccount.Size = new Size(155, 13);
            label_signup_alreadyhaveaccount.TabIndex = 11;
            label_signup_alreadyhaveaccount.Text = "Already have an account ?";
            // 
            // textBox_signup_password
            // 
            textBox_signup_password.Location = new Point(484, 304);
            textBox_signup_password.Multiline = true;
            textBox_signup_password.Name = "textBox_signup_password";
            textBox_signup_password.Size = new Size(361, 28);
            textBox_signup_password.TabIndex = 10;
            textBox_signup_password.TextChanged += textBox_signup_password_TextChanged;
            // 
            // label_signup_password
            // 
            label_signup_password.AutoSize = true;
            label_signup_password.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_signup_password.Location = new Point(484, 276);
            label_signup_password.Name = "label_signup_password";
            label_signup_password.Size = new Size(71, 16);
            label_signup_password.TabIndex = 9;
            label_signup_password.Text = "Password";
            // 
            // textBox_signup_username
            // 
            textBox_signup_username.Location = new Point(485, 232);
            textBox_signup_username.Multiline = true;
            textBox_signup_username.Name = "textBox_signup_username";
            textBox_signup_username.Size = new Size(360, 28);
            textBox_signup_username.TabIndex = 8;
            // 
            // checkBox_signup_showpassword
            // 
            checkBox_signup_showpassword.AutoSize = true;
            checkBox_signup_showpassword.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_signup_showpassword.Location = new Point(716, 350);
            checkBox_signup_showpassword.Name = "checkBox_signup_showpassword";
            checkBox_signup_showpassword.Size = new Size(129, 20);
            checkBox_signup_showpassword.TabIndex = 7;
            checkBox_signup_showpassword.Text = "Show password";
            checkBox_signup_showpassword.UseVisualStyleBackColor = true;
            checkBox_signup_showpassword.CheckedChanged += checkBox_signup_showpassword_CheckedChanged;
            // 
            // button_signup_login
            // 
            button_signup_login.BackColor = Color.MidnightBlue;
            button_signup_login.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_signup_login.ForeColor = SystemColors.ButtonHighlight;
            button_signup_login.Location = new Point(483, 350);
            button_signup_login.Name = "button_signup_login";
            button_signup_login.Size = new Size(121, 39);
            button_signup_login.TabIndex = 6;
            button_signup_login.Text = "Signup";
            button_signup_login.UseVisualStyleBackColor = false;
            button_signup_login.Click += button_signup_login_Click;
            // 
            // label_signup_username
            // 
            label_signup_username.AutoSize = true;
            label_signup_username.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_signup_username.Location = new Point(484, 205);
            label_signup_username.Name = "label_signup_username";
            label_signup_username.Size = new Size(74, 16);
            label_signup_username.TabIndex = 2;
            label_signup_username.Text = "Username";
            // 
            // label_signup_getstarted
            // 
            label_signup_getstarted.AutoSize = true;
            label_signup_getstarted.Font = new Font("MS PGothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_signup_getstarted.Location = new Point(476, 83);
            label_signup_getstarted.Name = "label_signup_getstarted";
            label_signup_getstarted.Size = new Size(181, 29);
            label_signup_getstarted.TabIndex = 1;
            label_signup_getstarted.Text = "Get started !";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 516);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS PGothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(153, 369);
            label2.Name = "label2";
            label2.Size = new Size(141, 16);
            label2.TabIndex = 14;
            label2.Text = "By z$0b.3r0th3r CC";
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
            // Sigup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 513);
            Controls.Add(panel1);
            Name = "Sigup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tool Forensics";
            FormClosing += Sigup_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox_signup_email;
        private Label label_signup_email;
        private Label label_signuo_loginhere;
        private Label label_signup_alreadyhaveaccount;
        private TextBox textBox_signup_password;
        private Label label_signup_password;
        private TextBox textBox_signup_username;
        private CheckBox checkBox_signup_showpassword;
        private Button button_signup_login;
        private Label label_signup_username;
        private Label label_signup_getstarted;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
    }
}