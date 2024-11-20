using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyRapChieuPhim
{
    internal class RegexPatternHelper
    {
        public static readonly string PasswordPattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        public static readonly string UsernamePattern = @"^[A-Za-z][A-Za-z0-9_]{7,29}$";
        public static readonly string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
