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
            login.Register_Click += LARF_Register_Click;
            OpenChildForm(login);
        }

        private void LARF_Register_Click()
        {
            OpenChildForm(new RegisterForm());
        }

        private void OpenChildForm(Form child)
        {
            foreach(Form form in this.MdiChildren)
                form.Close();
            child.MdiParent = this;
            child.Dock = DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Show();
        }


    }
}
