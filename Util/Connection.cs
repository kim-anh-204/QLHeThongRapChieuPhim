using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.Util
{
    internal class Connection
    {
        private static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string databasePath = Path.Combine(userPath, "source", "repos", "QuanLyRapChieuPhim", "QuanLyRapChieuPhim.mdf");
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + databasePath + ";Integrated Security=True";
    }
}
