using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.HomePage
{
    public partial class HomePageForm : Form
    {
        private DatVeForm _datVeFormManager;

        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public HomePageForm(string username)
        {
            InitializeComponent();
            labelTenDangNhap.Text = username;
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            _datVeFormManager = new DatVeForm();
            Helper.HideUI(_datVeFormManager, this);
            Helper.OpenMdiChildForm(_datVeFormManager);
        }

        private void HomePageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return;
            OnCloseClick?.Invoke();
        }
    }
}
