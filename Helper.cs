using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyRapChieuPhim
{
    internal class Helper
    {
        private static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static string databasePath = Path.Combine(userPath, "source", "repos", "QuanLyRapChieuPhim", "QuanLyRapChieuPhim.mdf");
        public static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databasePath + ";Integrated Security=True";

        public static string HashPassword(string passowrd)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passowrd));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
