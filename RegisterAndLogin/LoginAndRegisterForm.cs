using Microsoft.Win32;
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
using QuanLyRapChieuPhim.MainForm;

namespace QuanLyRapChieuPhim
{
    public partial class LoginAndRegisterForm : Form
    {
        private LoginForm _loginForm;
        private RegisterForm _registerForm;
        public LoginAndRegisterForm()
        {
            InitializeComponent();
            InitializeCustomCoponent();
            OpenLoginForm();
        }
        private void InitializeCustomCoponent()
        {
            _loginForm = new LoginForm();
            _loginForm.SwapToRegisterForm += SwapToRegisterForm;
            _loginForm.OnLoginSucceeded += OnLoginSucceeded;
            SetChildFormConfig(_loginForm);

            _registerForm = new RegisterForm();
            _registerForm.SwapToLoginForm += SwapToLoginform;
            SetChildFormConfig(_registerForm);
        }
        private void OnLoginSucceeded(string username)
        {
            DashboardForm dashboard = new DashboardForm(username);
            dashboard.OnCloseClick += OnCloseClick;
            dashboard.Show();
            this.Hide();
        }
        private void OnCloseClick()
        {
            this.Close();
        }
        private void OpenLoginForm() { OpenChildForm(_loginForm); }
        private void OpenRegisterForm() { OpenChildForm(_registerForm); }
        private void SwapToLoginform() { OpenLoginForm(); }
        private void SwapToRegisterForm() { OpenRegisterForm(); }
        private void OpenChildForm(Form child)
        {
            if (child.IsAccessible == false)
                child.Show();
            child.BringToFront();
            child.Activate();
        }
        private void SetChildFormConfig(Form child)
        {
            child.MdiParent = this;
            child.Dock = DockStyle.Fill;
            child.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
