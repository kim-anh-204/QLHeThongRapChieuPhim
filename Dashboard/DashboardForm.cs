using QuanLyRapChieuPhim.BaoCao;
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
        private UserManager _userManager;
        private Screening _screeningManager;
        private ScreeningRoomManagement _roomManager;
        private ReportManagement _reportManager;
        private FilmManagementForm _filmManager;

        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public DashboardForm(string username)
        {
            InitializeComponent();
            labelTenDangNhap.Text = username;
        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadForm();
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

            _roomManager = new ScreeningRoomManagement();
            Helper.HideUI(_roomManager, this);

            _reportManager = new ReportManagement();
            Helper.HideUI(_reportManager, this);
        }
        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseClick?.Invoke();
        }
        private void buttonTrangChu_Click(object sender, EventArgs e)
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
        private void buttonTaiKhoan_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_userManager);
        }

        private void buttonPhongChieu_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_roomManager);
        }

        private void buttonBaoCao_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_reportManager);
        }
    }
}
