using QuanLyRapChieuPhim.RegisterAndLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{
    public partial class LoginAndRegisterForm : Form
    {
        public LoginAndRegisterForm()
        {
            InitializeComponent();
            OpenLoginForm();
        }

        private void OpenLoginForm()
        {
            LoginForm login = new LoginForm();
            login.SwapToRegisterForm += SwapToRegisterForm;
            OpenChildForm(login);
        }
        private void OpenRegisterForm()
        {
            RegisterForm register = new RegisterForm();
            register.SwapToLoginForm += SwapToLoginform;
            OpenChildForm(register);
        }
        private void SwapToRegisterForm()
        {
            OpenRegisterForm();
        }
        private void SwapToLoginform()
        {
            OpenLoginForm();
        }
        private void OpenChildForm(Form child)
        {
            foreach (Form form in this.MdiChildren)
                form.Close();
            child.MdiParent = this;
            child.Dock = DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Show();
        }


    }
}
