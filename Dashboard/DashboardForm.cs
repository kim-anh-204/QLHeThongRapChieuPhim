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
        public DashboardForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseClick?.Invoke();
        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
            defaultY = buttonTrangChu.Location.Y;
            //indicator.Top = ((Control)sender).Top;
        }

        private void buttonPhim_Click(object sender, EventArgs e)
        {
            defaultY = buttonPhim.Location.Y;
            //indicator.Top = ((Control)sender).Top;
        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {
            defaultY = buttonNhanVien.Location.Y;
            //indicator.Top = ((Control)sender).Top;
        }

        private int defaultY, currentY, targetY;
        private int indicatorSpeed = 5;
        private void Indicator_Animation_Tick(object sender, EventArgs e)
        {
            if (currentY < targetY)
                currentY = Math.Min(currentY + indicatorSpeed, targetY);
            else if (currentY > targetY)
                currentY = Math.Max(currentY - indicatorSpeed, targetY);

            indicator.Location = new Point(indicator.Location.X, currentY);
            if (currentY == targetY)
            {
                Indicator_Animation.Stop();
            }
        }

        private void ButtonPhim_MouseEnter(object sender, EventArgs e)
        {
            MoveIndicatorToButton(buttonPhim);
        }

        private void ButtonNhanVien_MouseEnter(object sender, EventArgs e)
        {
            MoveIndicatorToButton(buttonNhanVien);
        }

        private void MoveIndicatorToButton(BunifuButton2 button)
        {
            targetY = button.Location.Y;
            if (!Indicator_Animation.Enabled)
            {
                currentY = indicator.Location.Y;
                Indicator_Animation.Start();
            }
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

        private void buttonNhanVien_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonNhanVien.ClientRectangle.Contains(buttonNhanVien.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }
        private void MoveIndicatorToDefault()
        {
            targetY = defaultY;
            if (!Indicator_Animation.Enabled)
            {
                currentY = indicator.Location.Y;
                Indicator_Animation.Start();
            }
        }
    }
}
