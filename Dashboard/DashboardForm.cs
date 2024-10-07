using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.MainForm
{
    public partial class DashboardForm : Form
    {
        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseClick?.Invoke();
        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
        }

        private void buttonPhim_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
        }
    }
}
