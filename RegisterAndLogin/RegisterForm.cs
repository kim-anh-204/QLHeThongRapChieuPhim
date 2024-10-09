using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.RegisterAndLogin
{
    public partial class RegisterForm : Form
    {
        public delegate void Form_Changed();
        public event Form_Changed SwapToLoginForm;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            SwapToLoginForm?.Invoke();
        }

        private void RegisterForm_Activated(object sender, EventArgs e)
        {
            textBoxTenDangNhap.Clear();
            textBoxEmail.Clear();
            textBoxMatKhau.Clear();
            textBoxMatKhau2.Clear();
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện các textbox và kết nối với cơ sở dữ liệu
           
            //Sau khi đăng ký thành công sẽ chuyển về màn hình đăng nhập.
            SystemSounds.Beep.Play();
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SwapToLoginForm?.Invoke();
        }
    }
}
