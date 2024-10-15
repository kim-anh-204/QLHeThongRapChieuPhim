using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.MainForm
{
    public partial class DashboardForm : Form
    {
        private DatVeForm _datVeForm;

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
        private void buttonNhanVien_Click(object sender, EventArgs e)
        {

        }
        private void buttonBaoCao_Click(object sender, EventArgs e)
        {

        }
        private void buttonDatVe_Click(object sender, EventArgs e)
        {
            Helper.OpenMdiChildForm(_datVeForm);
        }
    }
}
