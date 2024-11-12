using QuanLyRapChieuPhim.Dashboard.DatVeForms;
using QuanLyRapChieuPhim.DashBoard;
using QuanLyRapChieuPhim.RegisterAndLogin;
﻿using QuanLyRapChieuPhim.QuanLyPhim;
using QuanLyRapChieuPhim.RegisterAndLogin;
using QuanLyRapChieuPhim.ThongKe;
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
            Application.Run(new LoginAndRegisterForm());
        }
    }
}
