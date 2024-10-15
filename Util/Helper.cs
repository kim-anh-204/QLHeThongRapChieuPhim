using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Util
{
    internal class Helper
    {
        public static void OpenMdiChildForm(Form child)
        {
            if (child == null)
            {
                MessageBox.Show("Form chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (child.IsAccessible == false)
                child.Show();
            child.BringToFront();
            child.Activate();
        }
        public static void HideUI(Form form, Form parent)
        {
            if (form == null)
            {
                MessageBox.Show("Form chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (parent != null)
                form.MdiParent = parent;

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
        }
        public static byte[] ConvertImageToArray(PictureBox picture)
        {
            MemoryStream stream = new MemoryStream();
            picture.Image.Save(stream, picture.Image.RawFormat);
            return stream.GetBuffer();
        }
        public static Image ConvertArrayToImage(byte[] buffer)
        {
            MemoryStream memoryStream = new MemoryStream(buffer);
            return Image.FromStream(memoryStream);
        }

        public static string GenerateNextId(string id, string prefix, int numberPartSize)
        {
            if (string.IsNullOrEmpty(id))
            {
                return prefix + 1.ToString("D" + numberPartSize);
            }

            string numberPart = id.Substring(prefix.Length);
            int number = int.Parse(numberPart);
            ++number;

            return prefix + number.ToString("D" + numberPartSize);
        }
    }
}
