using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.MainForm
{
    public partial class DashboardForm : Form
    {
        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public DashboardForm(string username)
        {
            InitializeComponent();
            labelTenDangNhap.Text = username;
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


        private void MoveIndicatorToButton(BunifuButton2 button)
        {
        }

        private void buttonTrangChu_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonTrangChu);
        }

        private void buttonPhim_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonPhim);
        }

        private void buttonNhanVien_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonNhanVien);
        }
        private void buttonTrangChu_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonTrangChu.ClientRectangle.Contains(buttonTrangChu.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }

        private void buttonPhim_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonPhim.ClientRectangle.Contains(buttonPhim.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonNhanVien_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonNhanVien.ClientRectangle.Contains(buttonNhanVien.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }
        private void MoveIndicatorToDefault()
        {
        }
    }
}
