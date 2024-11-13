using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

using QuanLyRapChieuPhim.Util;

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
			return Connection.GetDataTable("SELECT PHIM.MaPhim, PHIM.TenPhim, PHIM.NgayKhoiChieu, PHIM.ThoiLuong, PHIM.DaoDien, PHIM.DienVienChinh, " +
										   "PHIM.HangSanXuat, PHIM.NuocSanXuat, PHIM.MoTa, PHIM.HinhAnh, " +
										   "DATEADD(MONTH, 1, PHIM.NgayKhoiChieu) AS NgayKetThuc " +
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
					XoaPhim(e.RowIndex);
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

		private void XoaPhim(int rowIndex)
		{
			DataRow row = movieTable.Rows[rowIndex];
			string maPhim = row["MaPhim"].ToString();
			string tenPhim = row["TenPhim"].ToString();

			DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá phim " + tenPhim + "?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				using (SqlConnection connection = new SqlConnection(Connection.connectionString))
				{
					connection.Open();
					SqlTransaction transaction = connection.BeginTransaction();
					try
					{
						// Xoá trong bảng PHIM_LOAIPHIM
						string queryLoaiPhim = "DELETE FROM PHIM_LOAIPHIM WHERE MaPhim = @MaPhim";
						using (SqlCommand cmdLoaiPhim = new SqlCommand(queryLoaiPhim, connection, transaction))
						{
							cmdLoaiPhim.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdLoaiPhim.ExecuteNonQuery();
						}

						// Xoá VEXEMPHIM
						string queryVeXemPhim = "DELETE FROM VeXemPhim WHERE MaSuatChieu IN (SELECT MaSuatChieu FROM SuatChieu WHERE MaPhim = @MaPhim)";
						using (SqlCommand cmdVe = new SqlCommand(queryVeXemPhim, connection, transaction))
						{
							cmdVe.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdVe.ExecuteNonQuery();
						}

						// Xoá GHE
						string queryGhe = "DELETE FROM Ghe WHERE MaSuatChieu IN (SELECT MaSuatChieu FROM SuatChieu WHERE MaPhim = @MaPhim)";
						using (SqlCommand cmdGhe = new SqlCommand(queryGhe, connection, transaction))
						{
							cmdGhe.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdGhe.ExecuteNonQuery();
						}

						// Xoá các suất chiếu trong bảng SuatChieu có liên quan đến phim
						string queryXuatChieu = "DELETE FROM SuatChieu WHERE MaPhim = @MaPhim";
						using (SqlCommand cmdXuatChieu = new SqlCommand(queryXuatChieu, connection, transaction))
						{
							cmdXuatChieu.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdXuatChieu.ExecuteNonQuery();
						}

						// Xoá phim trong bảng PHIM
						string queryPhim = "DELETE FROM PHIM WHERE MaPhim = @MaPhim";
						using (SqlCommand cmdPhim = new SqlCommand(queryPhim, connection, transaction))
						{
							cmdPhim.Parameters.AddWithValue("@MaPhim", maPhim);
							cmdPhim.ExecuteNonQuery();
						}

						// Cam kết giao dịch nếu xoá thành công
						transaction.Commit();
						DtGridViewQLP.Rows.RemoveAt(rowIndex);
						movieTable.AcceptChanges(); // Cập nhật lại DataTable để không còn chứa dòng đã xóa
						MessageBox.Show("Xoá phim thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					catch (Exception ex)
					{
						// Khôi phục lại dữ liệu nếu có lỗi
						transaction.Rollback();
						MessageBox.Show("Lỗi khi xoá phim: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void TextBoxTimKiem_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
