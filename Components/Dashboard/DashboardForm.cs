using QuanLyRapChieuPhim.BaoCao;
using QuanLyRapChieuPhim.Components.CustomerPage;
using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.QLPhongChieu;
using QuanLyRapChieuPhim.QuanLyPhim;
using QuanLyRapChieuPhim.ScreeningPage;
using QuanLyRapChieuPhim.UserPage;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.DashBoard
{
    public partial class DashboardForm : Form
    {
        private ThongKe.ThongKe _thongKe;
        private FilmManagementForm _filmManager;
        private Screening _screeningManager;
        private UserManager _userManager;
        private CustomerManager _customerManager;
        private ScreeningRoomManagement _roomManager;
        private ReportManagement _reportManager;

        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;


        public DashboardForm()
        {
            InitializeComponent();
            labelTenDangNhap.Text = (string)SharedData.GetValue("TenDangNhap");
        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            buttonDoanhThu.PerformClick();
        }

        private void LoadForm()
        {
            _thongKe = new ThongKe.ThongKe();
            Helper.HideUI(_thongKe, this);

            _filmManager = new FilmManagementForm();
            Helper.HideUI(_filmManager, this);

            _screeningManager = new Screening();
            Helper.HideUI(_screeningManager, this);

            _userManager = new UserManager();
            Helper.HideUI(_userManager, this);

            _customerManager = new CustomerManager();
            Helper.HideUI(_customerManager, this);

            _roomManager = new ScreeningRoomManagement();
            Helper.HideUI(_roomManager, this);

            _reportManager = new ReportManagement();
            Helper.HideUI(_reportManager, this);

        }
        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void buttonDoanhThu_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_thongKe);
        }
        private void buttonPhim_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_filmManager);
        }

        private void buttonSuatChieu_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_screeningManager);
        }
        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_userManager);
        }
        private void buttonKhachHang_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_customerManager);
        }
        private void buttonPhongChieu_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_roomManager);
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_reportManager);
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                OnCloseClick?.Invoke();
            else
                e.Cancel = true;
        }
    }
}
