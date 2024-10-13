using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UserPage
{
    public partial class Update : Form
    {
        private string maKhach;
        private string tenKhach;
        private string sdt;
        private UserManager userManager;
        public Update(UserManager userManager,string maKhach, string tenKhach, string sdt)
        {
            InitializeComponent();
            this.userManager = userManager;
            NameBtn.Text = tenKhach;
            SdtBtn.Text = sdt;
            this.maKhach=maKhach;
            this.tenKhach=tenKhach;
            this.sdt=sdt;
        }
        private bool UpdateKhachHang(string maKhach, string tenKhach, string sdt)
        {
            string query = "UPDATE KHACHHANG SET TenKhach = @tenKhach, SDT = @sdt WHERE MaKhach = @maKhach";

            return Connection.ExcuteNonQuery(query, new (string, object)[]
            {
             ("@MaKhach", maKhach),
            ("@TenKhach", tenKhach),
            ("@SDT", sdt),
          
            });
        }
        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string newTenKhach = NameBtn.Text;
            string newSDT = SdtBtn.Text;

            // Gọi phương thức cập nhật cơ sở dữ liệu
            bool result = UpdateKhachHang(maKhach, newTenKhach, newSDT);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi cập nhật thành công
                userManager.LoadKhachHangData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
