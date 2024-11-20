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
using QuanLyRapChieuPhim.DashBoard;
using QuanLyRapChieuPhim.Util;
using QuanLyRapChieuPhim.HomePage;

namespace QuanLyRapChieuPhim
{
    public partial class LoginAndRegisterForm : Form
    {
        private LoginForm _loginForm;
        private RegisterForm _registerForm;
        public LoginAndRegisterForm()
        {
            InitializeComponent();
        }
        private void LoginAndRegisterForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            OpenLoginForm();
        }
        private void LoadForm()
        {
            _loginForm = new LoginForm();
            Helper.HideUI(_loginForm, this);
            _loginForm.SwapToRegisterForm += SwapToRegisterForm;
            _loginForm.OnLoginSucceeded += OnLoginSucceeded;

            _registerForm = new RegisterForm();
            Helper.HideUI(_registerForm, this);
            _registerForm.SwapToLoginForm += SwapToLoginform;
        }
        private void OnLoginSucceeded()
        {
            if ((string)SharedData.GetValue("LoaiNguoiDung") == "Admin")
            {
                DashboardForm dashboard = new DashboardForm();
                dashboard.OnCloseClick += OnChildFormCloseClick;
                dashboard.Show();
            }
            else
            {
                HomePageForm homePageForm = new HomePageForm();
                homePageForm.OnCloseClick += OnChildFormCloseClick;
                homePageForm.Show();
            }

            this.Hide();
        }

        private void OnChildFormCloseClick()
        {
            _loginForm.ResetTextBox();
            this.Show();
        }
        private void OpenLoginForm() { Helper.OpenMdiChildForm(_loginForm); }
        private void OpenRegisterForm() { Helper.OpenMdiChildForm(_registerForm); }
        private void SwapToLoginform() { OpenLoginForm(); }
        private void SwapToRegisterForm() { OpenRegisterForm(); }
    }
}
