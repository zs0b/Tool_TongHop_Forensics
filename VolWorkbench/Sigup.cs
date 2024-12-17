using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VolWorkbench
{
    public partial class Sigup : Form
    {

        MySqlConnection connect = new MySqlConnection(@"Server=171.247.175.33;Port=62807;Database=tool_for;User ID=zs0b;Password=123456789;Connection Timeout=60");
        public Sigup()
        {
            InitializeComponent();
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo-white-halloween.ico");
            this.Icon = new Icon(iconPath);
        }

        private bool isSwitchingForm = false;

        private void label_signuo_loginhere_Click(object sender, EventArgs e)
        {
            Form_Login form_Login = new Form_Login();
            form_Login.Show();
            isSwitchingForm = true;

            this.Close();
        }

        private void button_signup_login_Click(object sender, EventArgs e)
        {
            if (textBox_signup_email.Text == "" || textBox_signup_username.Text == "" || textBox_signup_password.Text == "")
            {
                MessageBox.Show("Dien cho het di !!!", "Loii 0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();
                        string checkUser = "SELECT * FROM admin WHERE username = '"
                            + textBox_signup_username.Text.Trim() + "'";

                        using (MySqlCommand checkuser = new MySqlCommand(checkUser, connect))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(checkuser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(textBox_signup_username.Text + " is already exist", " Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO admin (email, username, passwd, date_created)" +
                                    "VALUES(@email, @username, @pass, @date)";

                                DateTime date = DateTime.Today;

                                using (MySqlCommand cmd = new MySqlCommand(insertData, connect))
                                {
                                    cmd.Parameters.AddWithValue("@email", textBox_signup_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", textBox_signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", textBox_signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date", date);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Registered Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Form_Login form_Login = new Form_Login();
                                    form_Login.Show();
                                    this.Hide();

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void checkBox_signup_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_signup_showpassword.Checked)
            {
                textBox_signup_password.PasswordChar = '\0';
            }
            else
            {
                textBox_signup_password.PasswordChar = '*';
            }

            textBox_signup_password.Refresh();
        }

        private void textBox_signup_password_TextChanged(object sender, EventArgs e)
        {
            if (!checkBox_signup_showpassword.Checked)
            {
                textBox_signup_password.PasswordChar = '*';  // Ẩn mật khẩu
            }
            else
            {
                textBox_signup_password.PasswordChar = '\0';  // Hiển thị mật khẩu
            }

        }

        private void Sigup_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu đang chuyển form, bỏ qua xác nhận thoát
            if (isSwitchingForm)
            {
                e.Cancel = false;
                return;
            }

            // Hiển thị hộp thoại xác nhận
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Muốn thoát ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Dừng việc đóng form
                }
                else
                {
                    Application.Exit(); // Thoát ứng dụng
                }
            }
        }


    }
}
