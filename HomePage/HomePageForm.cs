using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.HomePage
{
    public partial class HomePageForm : Form
    {
        private DatVeForm _datVeFormManager;
        public HomePageForm()
        {
            InitializeComponent();
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
    }
}
