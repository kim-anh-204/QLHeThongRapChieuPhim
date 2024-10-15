using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.ScreeningPage;
using QuanLyRapChieuPhim.UserPage;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.MainForm
{
    public partial class DashboardForm : Form
    {
        private DatVeForm _datVeForm;
        private UserManager _userManager;
        private Screening _screening;

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
            _datVeForm = new DatVeForm();
            Helper.HideUI(_datVeForm, this);

            _userManager = new UserManager();
            Helper.HideUI(_userManager, this);

            _screening = new Screening();
            Helper.HideUI(_screening, this);
        }
        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseClick?.Invoke();
        }
        private void buttonTrangChu_Click(object sender, EventArgs e)
        {

        }
        private void buttonPhim_Click(object sender, EventArgs e)
        {

        }
        private void buttonBaoCao_Click(object sender, EventArgs e)
        {

        }
        private void buttonDatVe_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_datVeForm);
        }

        private void buttonTaiKhoan_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_userManager);
        }

        private void buttonSuatChieu_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_screening);
        }
    }
}
