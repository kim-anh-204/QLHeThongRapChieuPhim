using QuanLyRapChieuPhim.ScreeningPage;
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

namespace QuanLyRapChieuPhim.QLPhongChieu
{
    public partial class ScreeningRoomManagement : Form
    {
        private Button btnExitSearch;
        private Screening screeningInstance;

        public ScreeningRoomManagement()
        {
            InitializeComponent();

            // Khởi tạo Button để tìm kiếm

            this.Controls.Add(this.btnSearch); // Thêm Button vào form

            // Khởi tạo nút "Thoát"
            this.btnExitSearch = new System.Windows.Forms.Button();
            this.btnExitSearch.Location = new System.Drawing.Point(608, 90);
            this.btnExitSearch.Name = "btnExitSearch";
            this.btnExitSearch.Size = new System.Drawing.Size(75, 35);
            this.btnExitSearch.TabIndex = 3;
            this.btnExitSearch.Text = "Thoát";
            this.btnExitSearch.UseVisualStyleBackColor = true;
            this.btnExitSearch.Click += new System.EventHandler(this.btnExitSearch_Click);

            // Thêm nút vào form
            this.Controls.Add(this.btnExitSearch);

            // Đưa nút "Thoát" lên phía trước DataGridView
            this.btnExitSearch.BringToFront();

            // Ẩn nút "Thoát" ban đầu
            this.btnExitSearch.Visible = false;


        }
        public void Visible()
        {  // Ẩn nút "Thoát"
            this.btnExitSearch.Visible = false;



            // Xóa nội dung của ô tìm kiếm
            txtSearch.Text = string.Empty;
        }


        private void btnExitSearch_Click(object sender, EventArgs e)
        {  // Ẩn nút "Thoát"
            this.btnExitSearch.Visible = false;

            // Hiển thị lại tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
            {
                row.Visible = true;
            }

            // Xóa nội dung của ô tìm kiếm
            txtSearch.Text = string.Empty;
        }



        private void QLPC_Load(object sender, EventArgs e)
        {
            LoadScreeningData();

        }



        public void LoadScreeningData()
        {

            bunifuDataGridView1.Rows.Clear(); // Xóa tất cả các hàng
            bunifuDataGridView1.DataSource = null; // Đặt DataSource về null để làm mới

            string query = @"
        SELECT
            MaPhong, TenPhong, TrangThaiPhongChieu
        FROM
            PHONGCHIEUPHIM
    ";

            DataTable screeningData = Connection.GetDataTable(query);

            if (screeningData != null && screeningData.Rows.Count > 0)
            {
                // Tạm ngừng cập nhật giao diện
                bunifuDataGridView1.SuspendLayout();

                bunifuDataGridView1.AllowUserToAddRows = false;

                // Kiểm tra nếu các cột "Sửa" và "Xóa" đã tồn tại chưa, chỉ thêm nếu chưa có
                if (bunifuDataGridView1.Columns["Sua"] == null)
                {
                    DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                    editButtonColumn.Name = "Sua";
                    editButtonColumn.HeaderText = "";
                    editButtonColumn.Text = "Sửa";
                    editButtonColumn.UseColumnTextForButtonValue = true;
                    bunifuDataGridView1.Columns.Add(editButtonColumn);
                }

                if (bunifuDataGridView1.Columns["Xoa"] == null)
                {
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                    deleteButtonColumn.Name = "Xoa";
                    deleteButtonColumn.HeaderText = "";
                    deleteButtonColumn.Text = "Xóa";
                    deleteButtonColumn.UseColumnTextForButtonValue = true;
                    bunifuDataGridView1.Columns.Add(deleteButtonColumn);
                }

                // Thêm các hàng từ dữ liệu
                for (int i = 0; i < screeningData.Rows.Count; i++)
                {
                    DataRow row = screeningData.Rows[i];
                    string maSc = row["MaPhong"]?.ToString();
                    string tenPhong = row["TenPhong"]?.ToString();
                    string trangThai = Convert.ToBoolean(row["TrangthaiPhongchieu"]).ToString(); ;
                    string trangThai1;
                    if (trangThai == "True")
                    {
                        trangThai1 = "Đang hoạt động"; // Set status to 1 for "Active"
                    }
                    else // Assuming the only other state is "Không hoạt động"
                    {
                        trangThai1 = "Không hoạt động"; // Set status to 0 for "Inactive"
                    }
                    if (maSc != null && tenPhong != null)
                    {
                        bunifuDataGridView1.Rows.Add(i + 1, maSc, tenPhong, trangThai1);
                    }
                }

                // Kết thúc tạm ngừng cập nhật giao diện
                bunifuDataGridView1.ResumeLayout();
            }
            else
            {
                MessageBox.Show("No data available.");
            }
        }


        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            AddScreeningRoom addScreeningForm = new AddScreeningRoom(this);
            if (addScreeningForm.ShowDialog() == DialogResult.OK)
            {
                LoadScreeningData(); // Tải lại dữ liệu khi thêm phòng thành công
            }

        }

        //private void LoadRoomData()
        //{
        //	// Logic để tải dữ liệu từ cơ sở dữ liệu và hiển thị vào DataGridView
        //	string query = "SELECT * FROM PHONGCHIEUPHIM"; // Thay thế bằng truy vấn của bạn
        //	DataTable roomData = Connection.GetDataTable(query);
        //	bunifuDataGridView1.DataSource = roomData; // Giả sử bạn có dataGridView1
        //}

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BunifuButton22_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DataGridView có dữ liệu không
            if (bunifuDataGridView1.Rows.Count > 0)
            {
                // Ẩn tất cả các hàng trước khi hiển thị lại
                foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }

            // Ẩn nút "Thoát" sau khi hiển thị lại tất cả các hàng
            this.btnExitSearch.Visible = false;

            // Làm trống nội dung của TextBox tìm kiếm
            txtSearch.Text = string.Empty;
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Tìm kiếm")
            {
                txtSearch.Text = "";
            }
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng hoặc tên phòng vào thanh tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nạp lại toàn bộ dữ liệu nếu từ khóa tìm kiếm trống
                LoadScreeningData();
                this.btnExitSearch.Visible = false; // Ẩn nút "Thoát"
            }
            else
            {
                // Thực hiện lọc các hàng theo từ khóa chính xác
                bool hasResult = false;

                for (int i = 0; i < bunifuDataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = bunifuDataGridView1.Rows[i];
                    string maPhong = row.Cells["Column2"]?.Value?.ToString().ToLower();
                    string tenPhong = row.Cells["Column3"]?.Value?.ToString().ToLower();

                    // Kiểm tra khớp chính xác mã hoặc tên phòng
                    if ((maPhong != null && maPhong.Equals(keyword)) ||
                        (tenPhong != null && tenPhong.Equals(keyword)))
                    {
                        row.Visible = true;
                        hasResult = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }

                // Hiển thị nút "Thoát" khi có thao tác tìm kiếm, dù tìm thấy hay không
                this.btnExitSearch.Visible = true;

                //if (!hasResult)
                //{
                //    MessageBox.Show("Không tìm thấy kết quả phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                string mapc = bunifuDataGridView1.Rows[e.RowIndex].Cells["Column2"].Value.ToString();

                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa phòng chiếu phim?",
                                                        "Xác nhận xóa",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Xóa từ bảng VEXEMPHIM
                        string deleteVXPQuery = "DELETE FROM VEXEMPHIM WHERE MaSuatChieu IN (SELECT MaSuatChieu FROM SUATCHIEU WHERE MaPhong = @MaPhong)";
                        bool isDeletedVXP = Connection.ExcuteNonQuery(deleteVXPQuery, new (string, object)[] { ("@MaPhong", mapc) });

                        // Xóa từ bảng GHE
                        string deleteGheQuery = "DELETE FROM GHE WHERE MaSuatChieu IN (SELECT MaSuatChieu FROM SUATCHIEU WHERE MaPhong = @MaPhong)";
                        bool isDeletedGhe = Connection.ExcuteNonQuery(deleteGheQuery, new (string, object)[] { ("@MaPhong", mapc) });

                        // Xóa từ bảng SUATCHIEU
                        string deleteSuatChieuQuery = "DELETE FROM SUATCHIEU WHERE MaPhong = @MaPhong";
                        bool isDeletedSuatChieu = Connection.ExcuteNonQuery(deleteSuatChieuQuery, new (string, object)[] { ("@MaPhong", mapc) });

                        // Cuối cùng, xóa từ bảng PHONGCHIEUPHIM
                        string deletePhongChieuQuery = "DELETE FROM PHONGCHIEUPHIM WHERE MaPhong = @MaPhong";
                        bool isDeletedPhongChieu = Connection.ExcuteNonQuery(deletePhongChieuQuery, new (string, object)[] { ("@MaPhong", mapc) });

                        // Thông báo kết quả
                        if (isDeletedVXP && isDeletedGhe && isDeletedSuatChieu && isDeletedPhongChieu)
                        {
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
               



            }
            if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
                {

                    string query = @"SELECT MaPhong, TenPhong, TrangthaiPhongchieu FROM PHONGCHIEUPHIM WHERE MaPhong = @MaPhong";
                    var parameters = new (string, object)[] { ("@MaPhong", mapc) };
                    DataTable screeningData = Connection.GetDataTable(query, parameters);

                    if (screeningData.Rows.Count > 0)
                    {
                        string maPhong = screeningData.Rows[0]["MaPhong"].ToString();
                        string tenPhong = screeningData.Rows[0]["TenPhong"].ToString();
                        string trangThai = screeningData.Rows[0]["TrangthaiPhongchieu"].ToString();
                        //MessageBox.Show($"{trangThai}");
                        string trangThai1;
                        if (trangThai == "True")
                        {
                            trangThai1 = "Đang hoạt động"; // Set status to 1 for "Active"
                        }
                        else // Assuming the only other state is "Không hoạt động"
                        {
                            trangThai1 = "Không hoạt động"; // Set status to 0 for "Inactive"
                        }


                        // Pass the data to the update form
                        UpdateScreeningRoom updateScreening = new UpdateScreeningRoom(this, maPhong, tenPhong, trangThai1);

                        if (updateScreening.ShowDialog() == DialogResult.OK)
                        {
                            LoadScreeningData(); // Tải lại dữ liệu khi sửa phòng thành công
                        }
                    }
                }
            }
        }

        private void bunifuDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm")
            {
                txtSearch.Text = "";
            }
        }
    }
}
