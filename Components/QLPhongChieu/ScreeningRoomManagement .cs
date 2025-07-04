﻿using QuanLyRapChieuPhim.ScreeningPage;
using QuanLyRapChieuPhim.Util;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            this.btnExitSearch.Location = new System.Drawing.Point(900, 90);
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
			LoadScreeningData();
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
        WHERE
            TrangThai <> 'XOA'";  // Điều kiện này để chỉ lấy các phòng có trạng thái khác 'XOA'

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
					string trangThai = Convert.ToBoolean(row["TrangthaiPhongchieu"]).ToString();
					string trangThai1 = trangThai == "True" ? "Đang hoạt động" : "Không hoạt động";

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
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


		private void bunifuButton22_Click(object sender, EventArgs e)
		{
			if (txtSearch.Text == "Tìm kiếm")
			{
				txtSearch.Text = "";
			}

			if (string.IsNullOrEmpty(txtSearch.Text))
			{
				MessageBox.Show("Vui lòng nhập mã phòng hoặc tên phòng vào thanh tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string keyword = txtSearch.Text.Trim().ToLower();

			// Điều kiện tìm kiếm khi có từ khóa và không có phòng có trạng thái 'XOA'
			if (string.IsNullOrEmpty(keyword))
			{
				// Nạp lại toàn bộ dữ liệu nếu từ khóa tìm kiếm trống
				LoadScreeningData();
				this.btnExitSearch.Visible = false; // Ẩn nút "Thoát"
			}

			// Hiển thị nút "Thoát" khi có thao tác tìm kiếm, dù tìm thấy hay không
			this.btnExitSearch.Visible = true;

			// Duyệt qua tất cả các hàng trong DataGridView
			foreach (DataGridViewRow row in bunifuDataGridView1.Rows)
			{
				if (row.IsNewRow) continue;  // Bỏ qua dòng mới (nếu có)

				// Lấy giá trị từ các cột "Mã Phòng" và "Tên Phòng"
				string maPhong = row.Cells["Column2"]?.Value?.ToString().ToLower();
				string tenPhong = row.Cells["Column3"]?.Value?.ToString().ToLower();

				// Kiểm tra trạng thái 'XOA' từ cơ sở dữ liệu (hoặc giá trị nào đó đã lưu)
				bool isDeleted = row.Cells["TrangThai"]?.Value?.ToString() == "XOA";

				// Kiểm tra nếu mã phòng hoặc tên phòng bắt đầu bằng chữ cái tìm kiếm và trạng thái không phải 'XOA'
				row.Visible = !isDeleted && ((maPhong != null && maPhong.Contains(keyword)) || (tenPhong != null && tenPhong.Contains(keyword)));
			}
		}

		private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			if (rowIndex >= 0)
			{
				string mapc = bunifuDataGridView1.Rows[rowIndex].Cells["Column2"].Value.ToString();

				// Kiểm tra nếu nhấn nút Xóa
				if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
				{
					// Kiểm tra nếu có vé đã đặt cho các suất chiếu còn hoạt động của phòng này
					string checkVeQuery = @"
                SELECT COUNT(*)
                FROM VeXemPhim
                WHERE MaSuatChieu IN (
                    SELECT sc.MaSuatChieu
                    FROM SuatChieu sc
                    JOIN Phim p ON sc.MaPhim = p.MaPhim
                    WHERE sc.MaPhong = @MaPhong
                        AND sc.TrangThai = 'CHUAXOA' -- các suất chiếu còn hoạt động
                        AND DATEADD(MINUTE, p.ThoiLuong, CAST(sc.GioBatDau AS DATETIME)) + CAST(sc.NgayChieu AS DATETIME) > GETDATE() -- thời gian chiếu chưa kết thúc
                )";
					int veCount = Connection.ExecuteScalarInt32(checkVeQuery, new (string, object)[] { ("@MaPhong", mapc) });

					if (veCount > 0)
					{
						MessageBox.Show("Không thể xóa vì còn suất chiếu chưa kết thúc hoặc có người đặt vé trong phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa phòng chiếu phim?",
														"Xác nhận xóa",
														MessageBoxButtons.YesNo,
														MessageBoxIcon.Warning);
					if (confirmResult == DialogResult.Yes)
					{
						// Cập nhật trạng thái của phòng chiếu thành 'XOA'
						string updateTrangThaiQuery = "UPDATE PHONGCHIEUPHIM SET TrangThai = 'XOA' WHERE MaPhong = @MaPhong";
						bool isUpdatedTrangThai = Connection.ExcuteNonQuery(updateTrangThaiQuery, new (string, object)[] { ("@MaPhong", mapc) });

						if (isUpdatedTrangThai)
						{
							// Ẩn dòng trong DataGridView
							bunifuDataGridView1.Rows[rowIndex].Visible = false;
							MessageBox.Show("Phòng chiếu đã được xóa!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}

				// Kiểm tra nếu nhấn nút Sửa
				if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
				{
					// Kiểm tra nếu có vé đã đặt cho các suất chiếu còn hoạt động của phòng này
					string checkVeQuery = @"
                SELECT COUNT(*)
                FROM VeXemPhim
                WHERE MaSuatChieu IN (
                    SELECT sc.MaSuatChieu
                    FROM SuatChieu sc
                    JOIN Phim p ON sc.MaPhim = p.MaPhim
                    WHERE sc.MaPhong = @MaPhong
                        AND sc.TrangThai = 'CHUAXOA' -- các suất chiếu còn hoạt động
                        AND DATEADD(MINUTE, p.ThoiLuong, CAST(sc.GioBatDau AS DATETIME)) + CAST(sc.NgayChieu AS DATETIME) > GETDATE() -- thời gian chiếu chưa kết thúc
                )";
					int veCount = Connection.ExecuteScalarInt32(checkVeQuery, new (string, object)[] { ("@MaPhong", mapc) });

					if (veCount > 0)
					{
						MessageBox.Show("Không thể sửa vì còn suất chiếu chưa kết thúc hoặc có người đặt vé trong phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					// Truy vấn thông tin phòng để sửa
					string query = @"SELECT MaPhong, TenPhong, TrangthaiPhongchieu FROM PHONGCHIEUPHIM WHERE MaPhong = @MaPhong";
					var parameters = new (string, object)[] { ("@MaPhong", mapc) };
					DataTable screeningData = Connection.GetDataTable(query, parameters);

					if (screeningData.Rows.Count > 0)
					{
						string maPhong = screeningData.Rows[0]["MaPhong"].ToString();
						string tenPhong = screeningData.Rows[0]["TenPhong"].ToString();
						string trangThai = screeningData.Rows[0]["TrangthaiPhongchieu"].ToString();
						string trangThai1 = trangThai == "True" ? "Đang hoạt động" : "Không hoạt động";

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
