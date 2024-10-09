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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.RegisterAndLogin
{
    public partial class LoginForm : Form
    {
        public delegate void Form_Changed();
        public Form_Changed SwapToRegisterForm;

        public delegate void LoginSucceeded();
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
            //Tiến hành đăng nhập vào giao diện chính.
            OnLoginSucceeded?.Invoke();
        }
    }
}
