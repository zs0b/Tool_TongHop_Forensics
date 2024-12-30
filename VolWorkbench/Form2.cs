using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace VolWorkbench
{
    public partial class Form_Login : Form
    {
        private readonly ApplicationDbContext _context;

        public Form_Login()
        {
            InitializeComponent();
            string connectionString = "Server=171.247.175.33;Port=62807;Database=tool_for;Uid=zs0b;Pwd=123456789;SslMode=None;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 11, 8)));
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        private void label_registerhere_Click(object sender, EventArgs e)
        {
            Sigup signupForm = new Sigup();
            signupForm.Show();
            this.Hide();
        }


        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }


        private void checkBox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            textBox_login_password.PasswordChar = checkBox_showpassword.Checked ? '\0' : '*';
        }


        private void textBox_login_password_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox_showpassword.Checked)
            {
                textBox_login_password.PasswordChar = '*';
            }
            else
            {
                textBox_login_password.PasswordChar = '\0';
            }
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_login_username.Text) || string.IsNullOrEmpty(textBox_login_password.Text))
            {
                MessageBox.Show("Dien cho het di !!!", "Loii 0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy thông tin người dùng từ cơ sở dữ liệu
                var user = await _context.Users
                                          .Where(u => u.Username == textBox_login_username.Text)
                                          .FirstOrDefaultAsync();

                if (user != null)
                {
                    // Loại bỏ khoảng trắng thừa trong mật khẩu người dùng nhập vào
                    string passwordToVerify = textBox_login_password.Text.Trim();

                    // Kiểm tra mật khẩu đã mã hóa
                    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(passwordToVerify, user.Password);

                    if (isPasswordValid)
                    {
                        MessageBox.Show("Logged in successfully", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form_Vol3 form_Vol3 = new Form_Vol3();
                        form_Vol3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu!", "Lỗi 0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi 0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }

}

