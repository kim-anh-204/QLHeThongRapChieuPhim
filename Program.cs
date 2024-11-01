using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.MainForm;
using QuanLyRapChieuPhim.RegisterAndLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyRapChieuPhim.ScreeningPage;
using QuanLyRapChieuPhim.UserPage;
using QuanLyRapChieuPhim.BaoCao;
using QuanLyRapChieuPhim.QLPhongChieu; 
namespace QuanLyRapChieuPhim
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DashboardForm("Tran Van Giap"));
            //Application.Run(new ReportManagement());
            //Application.Run(new ScreeningRoomManagement());

            Application.Run(new LoginAndRegisterForm());
            //Application.Run(new ChonChoNgoi());
        }
    }
}
