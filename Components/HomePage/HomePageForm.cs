using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.InfoManager;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.HomePage
{
    public partial class HomePageForm : Form
    {
        private DatVeForm _datVeFormManager;
        private InfoManagerForm _infoManager;

        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public HomePageForm()
        {
            InitializeComponent();
            labelTenDangNhap.Text = (string)SharedData.GetValue("TenDangNhap");
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            Helper.OpenMdiChildForm(_datVeFormManager);
        }

        private void LoadForm()
        {
            _datVeFormManager = new DatVeForm();
            Helper.HideUI(_datVeFormManager, this);

            _infoManager = new InfoManagerForm();
            _infoManager.OnCancelClick += OnCancelClick;
            Helper.HideUI(_infoManager, this);
        }

        private void OnCancelClick()
        {
            Helper.OpenMdiChildForm(_datVeFormManager);
        }

        private void HomePageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                OnCloseClick?.Invoke();
            else
                e.Cancel = true;
        }

        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_infoManager);
        }
    }
}
