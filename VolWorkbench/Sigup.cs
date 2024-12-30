using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace VolWorkbench
{
    public partial class Sigup : Form
    {
        private readonly ApplicationDbContext _context;

        // Constructor that accepts ApplicationDbContext to inject it via Dependency Injection
        public Sigup()
        {
            InitializeComponent();
            string connectionString = "Server=171.247.175.33;Port=62807;Database=tool_for;Uid=zs0b;Pwd=123456789;SslMode=None;";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 11, 8)));
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }

        private bool isSwitchingForm = false;

        // Event handler for "Login Here" link
        private void label_signuo_loginhere_Click(object sender, EventArgs e)
        {
            Form_Login form_Login = new Form_Login();
            form_Login.Show();
            isSwitchingForm = true;
            this.Close();
        }

        // Async event handler for the signup button click
        private async void button_signup_login_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường dữ liệu không được điền đầy đủ
            if (string.IsNullOrWhiteSpace(textBox_signup_email.Text) ||
                string.IsNullOrWhiteSpace(textBox_signup_username.Text) ||
                string.IsNullOrWhiteSpace(textBox_signup_password.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kiểm tra xem username đã tồn tại trong cơ sở dữ liệu chưa
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == textBox_signup_username.Text.Trim());

                if (existingUser != null)
                {
                    MessageBox.Show($"{textBox_signup_username.Text} đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(textBox_signup_password.Text.Trim());

                    // Tạo đối tượng người dùng mới
                    var newUser = new User
                    {
                        Email = textBox_signup_email.Text.Trim(),
                        Username = textBox_signup_username.Text.Trim(),
                        Password = hashedPassword, // Sử dụng mật khẩu đã mã hóa
                        DateCreated = DateTime.Now // Lưu thời gian hiện tại
                    };

                    // Thêm người dùng mới vào DbContext
                    _context.Users.Add(newUser);

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form đăng nhập và đóng form đăng ký
                    Form_Login form_Login = new Form_Login();
                    form_Login.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi nếu có sự cố xảy ra
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Event handler for show/hide password checkbox
        private void checkBox_signup_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_signup_showpassword.Checked)
            {
                textBox_signup_password.PasswordChar = '\0'; // Show password
            }
            else
            {
                textBox_signup_password.PasswordChar = '*'; // Hide password
            }

            textBox_signup_password.Refresh();
        }

        // Event handler for password text change
        private void textBox_signup_password_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox_signup_showpassword.Checked)
            {
                textBox_signup_password.PasswordChar = '*';  // Hide password
            }
            else
            {
                textBox_signup_password.PasswordChar = '\0';  // Show password
            }
        }

        // Event handler for form closing
        private void Sigup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSwitchingForm)
            {
                e.Cancel = false;
                return;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
