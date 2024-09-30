using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{
    public partial class LoginForm : Form
    {
        public delegate void RegisterHandler();
        public event RegisterHandler Register_Click;
        public LoginForm()
        {
            InitializeComponent();

        }
        private void LoginForm_SizeChanged(object sender, EventArgs e)
        {
            //textBoxUserName.Width = (int)(this.Width * 0.225);
            //textBoxUserName.Location = new Point(
            //    (int)(this.Width * 0.605), 
            //    (int)(this.Height * 0.394));

            //textBoxPassword.Width = (int)(this.Width * 0.225);
            //textBoxPassword.Location = new Point(
            //    (int)(this.Width * 0.605), 
            //    (int)(this.Height * 0.556));

            //btnLogin.Width = (int)(this.Width * 0.288);
            //btnLogin.Height = (int)(this.Height * 0.09);
            //btnLogin.Location = new Point(
            //    (int)(this.Width * 0.55), 
            //    (int)(this.Height * 0.701));

            //btnRegister.Width = (int)(this.Width * 0.123);
            //btnRegister.Height = (int)(this.Height * 0.08);
            //btnRegister.Location = new Point(
            //    (int)(this.Width * 0.55),
            //    (int)(this.Height * 0.803));

            //btnHelp.Width = (int)(this.Width *0.123);
            //btnHelp.Height = (int)(this.Height *0.08);
            //btnHelp.Location = new Point(
            //    (int)(this.Width * 0.725),
            //    (int)(this.Height * 0.803));
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(1) FROM Users WHERE UserName = @UserName AND Password = @Password";
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", textBoxUserName.Text.Trim());
                        string password = SecurityHelper.HashPassword(textBoxPassword.Text.Trim());
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register_Click?.Invoke();
        }


    }
}
