using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.RegisterAndLogin
{
    public partial class LoginForm : Form
    {
        public delegate void Form_Changed();
        public Form_Changed SwapToRegisterForm;

        public delegate void LoginSucceeded(string username);
        public event LoginSucceeded OnLoginSucceeded;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SwapToRegisterForm?.Invoke();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            textBoxTenDangNhap.Clear();
            textBoxMatKhau.Clear();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện các textbox và kết nối với cơ sở dữ liệu
            string username = textBoxTenDangNhap.Text;
            if (username == "")
            {
                MessageBox.Show("Trường tên đăng nhập không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTenDangNhap.Focus();
                return;
            }
            if (Regex.IsMatch(username, RegexPatternHelper.UsernamePattern) == false)
            {
                MessageBox.Show("Tên đăng nhập phải bắt đầu bằng chữ cái và có tối thiểu 8 ký tự, không có khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = textBoxMatKhau.Text;
            if (password == "")
            {
                MessageBox.Show("Trường mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMatKhau.Focus();
                return;
            }
            if (Regex.IsMatch(password, RegexPatternHelper.PasswordPattern) == false)
            {
                MessageBox.Show("Mật khẩu phải có tối thiểu 8 ký tự, không có khoảng trắng và có ít nhất 1 chữ cái và 1 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            password = SecurityHelper.HashPassword(password);
            string loginQuery = "SELECT COUNT(*) FROM NGUOIDUNG WHERE TenDangNhap = @TenDangNhap AND Matkhau = @Matkhau";
            int log_count = Connection.ExecuteScalarInt32(loginQuery,
                                                            new (string, object)[] {
                                                                ("@TenDangNhap", username),
                                                                ("@Matkhau", password)
                                                            });
            if (log_count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Tiến hành đăng nhập vào giao diện chính.
            OnLoginSucceeded?.Invoke(username);
        }
    }
}
