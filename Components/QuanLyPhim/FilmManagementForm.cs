using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

using QuanLyRapChieuPhim.Util;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using QuanLyRapChieuPhim.QLPhongChieu;

namespace QuanLyRapChieuPhim.QuanLyPhim
{
	public partial class FilmManagementForm : Form
	{
		private DataTable movieTable;
		public FilmManagementForm()
		{
			InitializeComponent();
		}
		//SqlConnection cnn = new SqlConnection(Connection.connectionString);
		private DataTable LoadData()
		{
			return Connection.GetDataTable("SELECT " +
				"PHIM.MaPhim, " + 
				"PHIM.TenPhim, " +
				"PHIM.NgayKhoiChieu, " +
				"PHIM.ThoiLuong, " +
				"PHIM.DaoDien, " +
				"PHIM.DienVienChinh, " +
				"PHIM.HangSanXuat, PHIM.NuocSanXuat, PHIM.MoTa, PHIM.HinhAnh, " +
				"DATEADD(MONTH, 1, PHIM.NgayKhoiChieu) AS NgayKetThuc, " +
				"CASE WHEN PHIM.Trangthai = 1 THEN N'Sử dụng' ELSE N'Không sử dụng' END as Trangthai " +
				"FROM PHIM");
		}
		private void BindDataToGrid(DataTable dataTable)
		{
			if (dataTable != null)
			{
				DtGridViewQLP.AutoGenerateColumns = false;
				DtGridViewQLP.DataSource = dataTable;
			}
			else
			{
				MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void MovieManagementForm_Load(object sender, EventArgs e)
		{
			movieTable = LoadData(); // Lưu dữ liệu vào biến movieTable
			BindDataToGrid(movieTable); // Đổ dữ liệu vào DataGridView
		}

		private void ThemPhim_Click(object sender, EventArgs e)
		{
			FormAddFilm formThemPhim = new FormAddFilm();
			formThemPhim.ShowDialog(); // Dạng modal dialog
									   // Làm mới dữ liệu trên DataGridView
			MovieManagementForm_Load(sender, e);
		}

		private void ButtonTim_Click(object sender, EventArgs e)
		{
			string searchValue = TextBoxTimKiem.Text.Trim().ToLower();

			//tạo bản sao của DataTable ban đầu để lưu kết quả tìm kiếm
			DataTable filteredTable = movieTable.Clone();

			//Bien dung de kiem tra phim co trong csdl hay khoong
			bool found = false;

			foreach (DataRow row in movieTable.Rows)
			{
				string tenPhim = row["TenPhim"].ToString().ToLower();
				if (tenPhim.Contains(searchValue))
				{
					filteredTable.ImportRow(row);
					found = true;
				}
			}
			if (!found)
			{
				MessageBox.Show("Không tìm thấy phim.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			DtGridViewQLP.DataSource = filteredTable;
			TextBoxTimKiem.Clear();
		}

		private void ButtonDsPhim_Click(object sender, EventArgs e)
		{
			MovieManagementForm_Load(sender, e);
		}

		private void DtGridViewQLP_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				string colName = DtGridViewQLP.Columns[e.ColumnIndex].Name;
				if (colName == "Sua")
				{
					SuaPhim(e.RowIndex);
				}
				else if (colName == "Xoa")
				{
					DialogResult result = MessageBox.Show(
						"Bạn muốn làm gì với phim này?\n1. " +
						"Xoá hoàn toàn. Chọn 'Yes'\n2 " +
						"Đánh dấu là không sử dụng nữa. Chọn 'NO'",
						"Xác nhận hành động",
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Question
						);
					if(result == DialogResult.Yes)
					{
						XoaPhim(e.RowIndex);
					}
					else if(result == DialogResult.No)
					{
						KhongSuDungPhim(e.RowIndex);
					}		
				}
			}
		}

		private List<string> GetTheLoaiByPhim(string maPhim)
		{
			List<string> theLoai = new List<string>();
			string query = "SELECT LOAIPHIM.TenLoaiPhim FROM PHIM_LOAIPHIM " +
						   "JOIN LOAIPHIM ON PHIM_LOAIPHIM.MaLoaiPhim = LOAIPHIM.MaLoaiPhim " +
						   "WHERE PHIM_LOAIPHIM.MaPhim = @MaPhim";
			DataTable dt = Connection.GetDataTable(query, new (string, object)[] { ("@MaPhim", maPhim) });

			foreach (DataRow row in dt.Rows)
			{
				theLoai.Add(row["TenLoaiPhim"].ToString());
			}

			return theLoai;
		}
		private void SuaPhim(int rowIndex)
		{
			DataRow row = movieTable.Rows[rowIndex];
			// Lấy tất cả thông tin phim từ DataRow
			string maPhim = row["MaPhim"].ToString();
			string tenPhim = row["TenPhim"].ToString();
			DateTime ngayKhoiChieu = row["NgayKhoiChieu"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayKhoiChieu"]);
			int thoiLuong = row["ThoiLuong"] == DBNull.Value ? 0 : Convert.ToInt32(row["ThoiLuong"]);
			string daoDien = row["DaoDien"].ToString();
			string dienVienChinh = row["DienVienChinh"].ToString();
			string hangSX = row["HangSanXuat"].ToString();
			string nuocSX = row["NuocSanXuat"].ToString();
			List<string> theLoai = GetTheLoaiByPhim(maPhim);
			string moTa = row["MoTa"].ToString();
			byte[] hinhAnh = row["HinhAnh"] != DBNull.Value ? (byte[])row["HinhAnh"] : null;
			// Gọi FormAddFilm với đầy đủ thông tin
			FormAddFilm formAddFilm = new FormAddFilm();
			formAddFilm.SetEditMode(maPhim, tenPhim, nuocSX, hangSX, daoDien, dienVienChinh, theLoai, ngayKhoiChieu, thoiLuong, moTa, hinhAnh);
			formAddFilm.FilmUpdated += (s, e) => MovieManagementForm_Load(s, e);
			formAddFilm.ShowDialog();
		}

		private void KhongSuDungPhim(int rowIndex)
		{
			DataRow row = movieTable.Rows[rowIndex];
			string maPhim = row["MaPhim"].ToString();

			// Lấy danh sách các suất chiếu của phim
			string getSuatChieuQuery = "SELECT MaSuatChieu, NgayChieu FROM SUATCHIEU WHERE MaPhim = @MaPhim";
			DataTable suatChieuTable = Connection.GetDataTable(getSuatChieuQuery, new (string, object)[] { ("@MaPhim", maPhim) });

			bool hasActiveShowtimes = false;

			foreach (DataRow suatChieuRow in suatChieuTable.Rows)
			{
				string maSuatChieu = suatChieuRow["MaSuatChieu"].ToString();
				DateTime ngayChieu = Convert.ToDateTime(suatChieuRow["NgayChieu"]);
				DateTime today = DateTime.Today;

				if (ngayChieu >= today) // Nếu suất chiếu chưa qua ngày
				{
					// Kiểm tra xem suất chiếu có vé được đặt hay không
					string checkVeQuery = "SELECT COUNT(*) FROM GHE WHERE MaSuatChieu = @MaSuatChieu AND TrangThai = 'True'";
					int veCount = Connection.ExecuteScalarInt32(checkVeQuery, new (string, object)[] { ("@MaSuatChieu", maSuatChieu) });

					if (veCount > 0)
					{
						// Nếu suất chiếu có ghế được đặt, đánh dấu suất chiếu đang hoạt động
						hasActiveShowtimes = true;
						continue; // Bỏ qua suất chiếu này
					}
				}

				// Ẩn suất chiếu nếu không có ghế đặt hoặc suất chiếu đã qua ngày
				string updateSuatChieuQuery = "UPDATE SUATCHIEU SET TrangThai = 'XOA' WHERE MaSuatChieu = @MaSuatChieu";
				Connection.ExcuteNonQuery(updateSuatChieuQuery, new (string, object)[] { ("@MaSuatChieu", maSuatChieu) });
			}

			// Nếu vẫn còn suất chiếu hoạt động, không cho phép ẩn phim
			if (hasActiveShowtimes)
			{
				MessageBox.Show("Không thể ẩn phim vì vẫn còn suất chiếu có người đặt vé hoặc chưa kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Ẩn phim nếu tất cả suất chiếu đã được xử lý
			string updatePhimQuery = "UPDATE PHIM SET TrangThai = 0 WHERE MaPhim = @MaPhim";
			Connection.ExcuteNonQuery(updatePhimQuery, new (string, object)[] { ("@MaPhim", maPhim) });

			// Cập nhật giao diện
			DtGridViewQLP.Rows[rowIndex].Cells["Trangthai"].Value = "Không sử dụng";

			MessageBox.Show("Phim đã được đánh dấu là 'Không sử dụng'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		private void XoaPhim(int rowIndex)
		{
			DataRow row = movieTable.Rows[rowIndex];
			string maPhim = row["MaPhim"].ToString();
			string tenPhim = row["TenPhim"].ToString();

			// Hiển thị hộp thoại xác nhận
			DialogResult result = MessageBox.Show(
				$"Bạn có chắc chắn muốn xoá phim \"{tenPhim}\" không?",
				"Xác nhận xoá",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			if (result == DialogResult.Yes)
			{
				using (SqlConnection connection = new SqlConnection(Connection.connectionString))
				{
					connection.Open();
					SqlTransaction transaction = connection.BeginTransaction();
					try
					{
						// Kiểm tra xem phim có liên quan đến các bảng khác không
						string checkQuery = @"
                    SELECT COUNT(*) 
                    FROM SuatChieu 
                    WHERE MaPhim = @MaPhim";

						using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection, transaction))
						{
							checkCmd.Parameters.AddWithValue("@MaPhim", maPhim);
							int relatedCount = Convert.ToInt32(checkCmd.ExecuteScalar());

							if (relatedCount > 0)
							{
								// Nếu có liên kết, thông báo không thể xoá
								MessageBox.Show(
									$"Không thể xoá phim \"{tenPhim}\" vì có liên quan đến suất chiếu.",
									"Thông báo",
									MessageBoxButtons.OK,
									MessageBoxIcon.Warning
								);
								transaction.Rollback();
								return;
							}
						}
						// Nếu không có liên kết, tiến hành xoá phim, phim_loaiphim
						string queryLoaiPhim = "DELETE FROM PHIM_LOAIPHIM WHERE MaPhim = @MaPhim";
						using (SqlCommand cmdLoaiPhim = new SqlCommand(queryLoaiPhim, connection, transaction))
						{
							cmdLoaiPhim.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdLoaiPhim.ExecuteNonQuery();
						}
						string deleteQuery = "DELETE FROM PHIM WHERE MaPhim = @MaPhim";
						using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection, transaction))
						{
							deleteCmd.Parameters.AddWithValue("@MaPhim", maPhim);
							deleteCmd.ExecuteNonQuery();
						}

						// Cam kết giao dịch
						transaction.Commit();

						// Cập nhật giao diện
						DtGridViewQLP.Rows.RemoveAt(rowIndex);
						movieTable.AcceptChanges();
						MessageBox.Show(
							$"Xoá phim \"{tenPhim}\" thành công.",
							"Thông báo",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information
						);
					}
					catch (Exception ex)
					{
						// Khôi phục dữ liệu nếu xảy ra lỗi
						transaction.Rollback();
						MessageBox.Show(
							"Lỗi khi xoá phim: " + ex.Message,
							"Thông báo",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
					}
				}
			}
		}


		private void TextBoxTimKiem_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
