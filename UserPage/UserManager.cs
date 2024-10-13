using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
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
    public partial class UserManager : Form
    {
        private DataGridViewRow selectedRow = null;
        private int selectedColumnIndex = -1;
        public UserManager()
        {
            InitializeComponent();          
            SetupDataGridView();
            LoadData();
            LoadKhachHangData();
          
        }
        private void InitializeButton()
        {
            
        }
        public void LoadKhachHangData()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            string query = "SELECT * FROM KHACHHANG ORDER BY CAST(MaKhach AS INT);"; // Câu truy vấn SQL để lấy dữ liệu từ bảng KhachHang
            DataTable khachHangData = Connection.GetDataTable(query); // Gọi phương thức GetDataTable
            if (khachHangData != null && khachHangData.Rows.Count > 0) // Kiểm tra DataTable có chứa dữ liệu
            {
                //bunifuDataGridView1.Rows.Clear();
                //bunifuDataGridView1.Columns.Clear(); // Xóa các cột cũ nếu có

                // Thêm cột dữ liệu

                //bunifuDataGridView1.Columns.Add("Makhach", "Mã Khách");
                //bunifuDataGridView1.Columns.Add("TenKhach", "Tên Khách");
                //bunifuDataGridView1.Columns.Add("SDT", "Số Điện Thoại");

                //// Thêm cột "Sửa"
                //DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                //btnEdit.Name = "Sửa";
                //btnEdit.Text = "Sửa";
                //btnEdit.UseColumnTextForButtonValue = true; // Hiển thị văn bản trên nút
                //bunifuDataGridView1.Columns.Add(btnEdit);

                //// Thêm cột "Xóa"
                //DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                //btnDelete.Name = "Xóa";
                //btnDelete.Text = "Xóa";
                //btnDelete.UseColumnTextForButtonValue = true;
                //bunifuDataGridView1.Columns.Add(btnDelete);
                // Thêm dữ liệu vào các dòng
                foreach (DataRow row in khachHangData.Rows)
                {
                    string maKhach = row["Makhach"]?.ToString();
                    string tenKhach = row["TenKhach"]?.ToString();
                    string sdt = row["SDT"]?.ToString();

                    bunifuDataGridView1.Rows.Add(maKhach, tenKhach, sdt);
                }
            }
            else
            {
                bunifuDataGridView1.Rows.Add("", "", ""); // Thêm hàng trống
                //MessageBox.Show("Không thể lấy dữ liệu từ bảng KhachHang hoặc bảng không có dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void BunifuDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }
        private void BunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề cột
            {
                string maKhach = bunifuDataGridView1.Rows[e.RowIndex].Cells["Makhach"].Value.ToString();

                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
                {
                    string maKhachEdit = bunifuDataGridView1.Rows[rowIndex].Cells["MaKhach"].Value.ToString();
                    string tenKhachEdit = bunifuDataGridView1.Rows[rowIndex].Cells["TenKhachHang"].Value.ToString();
                    string sdtEdit = bunifuDataGridView1.Rows[rowIndex].Cells["SoDienThoai"].Value.ToString();
                    // Xử lý logic sửa bản ghi, ví dụ mở form chỉnh sửa
                    //MessageBox.Show($"Bạn chọn sửa khách hàng với mã: {maKhach}", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Update update = new Update(this, maKhachEdit, tenKhachEdit, sdtEdit);

                    // Hiển thị Form2
                    update.Show();
                    // Ví dụ: Gọi một form sửa thông tin khách hàng
                    //var editForm = new EditKhachHangForm(maKhach);
                    //if (editForm.ShowDialog() == DialogResult.OK)
                    //{
                    //    // Nếu form sửa xong, cập nhật lại DataGridView
                    //    ReloadKhachHangData();
                    //}
                }
                else if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    // Xử lý logic xóa bản ghi
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng với mã: {maKhach}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Thực hiện câu lệnh SQL để xóa khách hàng trong cơ sở dữ liệu
                        string deleteQuery = "DELETE FROM KHACHHANG WHERE Makhach = @Makhach";
                        bool isDeleted = Connection.ExcuteNonQuery(deleteQuery, new (string, object)[] { ("@Makhach", maKhach) });

                        if (isDeleted)
                        {
                            // Xóa dòng khỏi DataGridView
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void SetupDataGridView()
        {
            // Setting up the appearance
            bunifuDataGridView1.CellClick += BunifuDataGridView1_CellClick;
            bunifuDataGridView1.CellMouseClick += BunifuDataGridView1_CellMouseClick;
            bunifuDataGridView1.ColumnHeaderMouseClick += BunifuDataGridView1_ColumnHeaderMouseClick;

        }
        private void BunifuDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }
        private void LoadData()
        {
            
        }
        private void UserManager_Load(object sender, EventArgs e)
        {
          
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Add add = new Add(this);

            // Hiển thị Form2
            add.Show();
        }

        private void bunifuDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
