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
    public partial class Add : Form
    {
        private UserManager userManager;
        public Add(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            string query = "SELECT TOP 1 Makhach FROM KHACHHANG ORDER BY CAST(Makhach AS INT) DESC;";
            int maKhach;
            // Gọi phương thức để lấy dữ liệu
            DataTable result = Connection.GetDataTable(query);
            if (result != null && result.Rows.Count > 0)
            {
                // Lấy mã khách hàng từ hàng đầu tiên
                maKhach = Convert.ToInt32(result.Rows[0]["Makhach"]);
                maKhach += 1;
            }
            else
            {
                // Nếu không có dữ liệu, đặt mã khách hàng mặc định là "1"
                maKhach = 1;
            }
            //int maKhachHang = Convert.ToInt32(result.Rows[0]["Makhach"]); // Chuyển đổi sang kiểu int
            
            // Cộng thêm 1 vào mã khách hàng
            //maKhachHang += 1;

            //string maKhachHang = result.Rows[0]["Makhach"].ToString();
            string MaKhach = maKhach.ToString();
            MessageBox.Show($"{maKhach}");
            string title = NameBtn.Text; // Thay bằng dữ liệu thực tế từ người dùng
            string genre = SdtBtn.Text;  // Thay bằng dữ liệu thực tế từ người dùng
            string formattedDate = DateTime.Now.ToString("MM/dd/yyyy");   // Hoặc lấy từ một DatePicker hoặc TextBox
            DateTime NgayTao = DateTime.Now.Date;
            string query1 = "INSERT INTO KHACHHANG (MaKhach,TenKhach, SDT, NgayTao) VALUES (@MaKhach,@TenKhach, @SDT, @NgayTao)";

            bool result1 = Connection.ExcuteNonQuery(query1, new (string, object)[]
            {
            ("@MaKhach", MaKhach),
            ("@TenKhach", title),
            ("@SDT", genre),
            ("@NgayTao", NgayTao)
            });
            this.Close();
            userManager.LoadKhachHangData();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
