using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace VolWorkbench
{
    public partial class Form_Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zs0b\Documents\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        public Form_Login()
        {
            InitializeComponent();
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo-white-halloween.ico");
            this.Icon = new Icon(iconPath);

        }

        private bool isSwitchingForm = false;

        private void label_registerhere_Click(object sender, EventArgs e)
        {
            isSwitchingForm = true; // Đặt cờ báo hiệu đang chuyển form
            Sigup Sform = new Sigup();
            Sform.Show();
            this.Hide(); // Sử dụng Close() thay vì Hide()
        }


        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu đang chuyển form, bỏ qua xác nhận thoát
            if (isSwitchingForm)
            {
                e.Cancel = false;
                return;
            }

            // Kiểm tra nếu sự kiện FormClosing được kích hoạt bởi người dùng
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Hiển thị hộp thoại xác nhận
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




        private void checkBox_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_showpassword.Checked)
            {
                textBox_login_password.PasswordChar = '\0';
            }
            else
            {
                textBox_login_password.PasswordChar = '*';
            }
            textBox_login_password.Refresh();
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

        private void button_login_Click(object sender, EventArgs e)
        {
            if(textBox_login_username.Text == "" || textBox_login_password.Text == "")
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

                        string selectdata = "SELECT * FROM admin WHERE username = @username AND passwd = @pass ";
                        using (SqlCommand cmd = new SqlCommand(selectdata, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", textBox_login_username.Text);
                            cmd.Parameters.AddWithValue("@pass", textBox_login_password.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if(table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Loggedd ~~", "Thong baoo 0.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form_Vol3 form_Vol3 = new Form_Vol3();
                                form_Vol3.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password", "Loii 0.0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show("Error connecting: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}
