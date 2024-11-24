using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.QuanLyPhim
{
    public partial class FormAddFilm : Form
	{
		private bool isEditing = false;
		private string maPhimEditing;
		public event EventHandler FilmUpdated;
		private bool Trangthai = true; // Biến trạng thái mặc định là true

		public FormAddFilm()
		{
			InitializeComponent();
			LoadLoaiPhimCLBox();
		}

		private void LoadLoaiPhimCLBox()
		{
			string query = "SELECT * FROM LoaiPhim";
			DataTable dt = Connection.GetDataTable(query);
			clbTheLoai.DataSource = dt;
			clbTheLoai.DisplayMember = "TenLoaiPhim";
			clbTheLoai.ValueMember = "MaLoaiPhim";
		}

		private void ButtonChonAnh_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
				ofd.Title = "Chọn ảnh";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					ptBoxPoster.Image = Image.FromFile(ofd.FileName);
					ptBoxPoster.SizeMode = PictureBoxSizeMode.Zoom;
				}
			}
		}

		private void ButtonHuy_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private bool CheckCondition()
		{
			if (!ValidateTenPhim(TBTenPhim.Text)) return false;
			if (!ValidateNhaSanXuat(TBNsx.Text)) return false;
			if (!ValidateHangSanXuat(TBHsx.Text)) return false;
			if (!ValidateDaoDien(TBDaoDien.Text)) return false;
			if (!ValidateTheLoai(clbTheLoai)) return false;
			if (!ValidateNgayKhoiChieu(DatePickerNgaykc.Value)) return false;
			if (!ValidateThoiLuong(TBThoiluong.Text)) return false;
			if (!ValidateDienVien(TBDienVien.Text)) return false;

			return true;
		}

		private bool ValidateTenPhim(string tenPhim)
		{
			if (string.IsNullOrWhiteSpace(tenPhim) || tenPhim.Length <= 0)
			{
				MessageBox.Show("Tên phim không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Kiểm tra trùng lặp trong cơ sở dữ liệu
			string query = "SELECT COUNT(*) FROM PHIM WHERE TenPhim = @TenPhim";
			var parameters = new (string, object)[] { ("@TenPhim", tenPhim) };

			int count = Convert.ToInt32(Connection.ExecuteScalar(query, parameters));
			if (count > 0)
			{
				MessageBox.Show("Tên phim đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private bool ValidateNhaSanXuat(string nhaSanXuat)
		{
			if (string.IsNullOrWhiteSpace(nhaSanXuat))
			{
				MessageBox.Show("Nhà sản xuất không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private bool ValidateHangSanXuat(string hangSanXuat)
		{
			if (string.IsNullOrWhiteSpace(hangSanXuat))
			{
				MessageBox.Show("Hãng sản xuất không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private bool ValidateDaoDien(string daoDien)
		{
			if (string.IsNullOrWhiteSpace(daoDien) || daoDien.Any(char.IsDigit))
			{
				MessageBox.Show("Tên đạo diễn không được chứa số hoặc để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private bool ValidateTheLoai(CheckedListBox clbTheLoai)
		{
			if (clbTheLoai.CheckedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn ít nhất 1 thể loại phim.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private bool ValidateNgayKhoiChieu(DateTime ngayKhoiChieu)
		{
			if (ngayKhoiChieu < DateTime.Today.Date)
			{
				MessageBox.Show($"Ngày khởi chiếu phải từ ngày {DateTime.Today.Date}.", "Thông báo");
				return false;
			}
			return true;
		}

		private bool ValidateThoiLuong(string thoiLuong)
		{
			if (!int.TryParse(thoiLuong, out _))
			{
				MessageBox.Show("Thời lượng phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TBThoiluong.Clear(); // Xóa nội dung không hợp lệ
				return false;
			}
			return true;
		}

		private bool ValidateDienVien(string dienVien)
		{
			if (string.IsNullOrWhiteSpace(dienVien) || dienVien.Any(char.IsDigit))
			{
				MessageBox.Show("Tên diễn viên chính không được chứa số hoặc để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		public void SetEditMode(string maPhim, string tenPhim, string nuocSX, string hangSX, string daoDien, string dienVienChinh, List<string> theLoai, DateTime ngayKhoiChieu, int thoiLuong, string moTa, byte[] hinhAnh)
		{
			ButtonThemPhimMoi.Text = "Lưu";

			isEditing = true;
			maPhimEditing = maPhim;
			TBTenPhim.Text = tenPhim;
			TBNsx.Text = nuocSX;
			TBHsx.Text = hangSX;
			TBDaoDien.Text = daoDien;
			TBDienVien.Text = dienVienChinh;

			for (int i = 0; i < clbTheLoai.Items.Count; i++)
			{
				clbTheLoai.SetItemChecked(i, false);
			}

			// Đánh dấu các thể loại trong CheckedListBox
			for (int i = 0; i < clbTheLoai.Items.Count; i++)
			{
				DataRowView item = clbTheLoai.Items[i] as DataRowView;
				string genreName = item["TenLoaiPhim"].ToString();
				// Đánh dấu nếu thể loại tồn tại trong danh sách đã chọn
				clbTheLoai.SetItemChecked(i, theLoai.Contains(genreName));
			}
			DatePickerNgaykc.Value = ngayKhoiChieu;
			TBThoiluong.Text = thoiLuong.ToString();
			TBNoidung.Text = moTa;
			if (hinhAnh != null && hinhAnh.Length > 0)
			{
				ptBoxPoster.Image = Image.FromStream(new MemoryStream(hinhAnh));
				ptBoxPoster.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chỉnh hiển thị nếu cần
			}
		}
		private void ButtonThemPhimMoi_Click(object sender, EventArgs e)
		{
			if (!CheckCondition())
			{
				return;
			}

			string tenPhim = TBTenPhim.Text;
			DateTime ngayKhoiChieu = DatePickerNgaykc.Value;
			int thoiLuong = int.TryParse(TBThoiluong.Text, out int temp) ? temp : 0;
			string daoDien = TBDaoDien.Text;
			string dienVienChinh = TBDienVien.Text;
			string hangSX = TBHsx.Text;
			string nuocSX = TBNsx.Text;
			string moTa = TBNoidung.Text;
			byte[] hinhAnh = Helper.ConvertImageToArray(ptBoxPoster);

			// Lấy danh sách các thể loại được chọn
			List<string> selectedGenres = new List<string>();
			foreach (var item in clbTheLoai.CheckedItems)
			{
				DataRowView row = item as DataRowView;
				selectedGenres.Add(row["MaLoaiPhim"].ToString());
			}

			if (isEditing)
			{
				// Thực hiện cập nhật dữ liệu phim
				bool result = UpdateFilmToDatabase(maPhimEditing, tenPhim, ngayKhoiChieu, thoiLuong, daoDien, dienVienChinh, hangSX, nuocSX, moTa, hinhAnh, selectedGenres, Trangthai);
				if (result)
				{
					MessageBox.Show("Phim đã được cập nhật thành công!");
					FilmUpdated?.Invoke(this, EventArgs.Empty);
				}
				else
				{
					MessageBox.Show("Cập nhật phim thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				// Thực hiện thêm phim mới
				bool result = AddNewFilmToDatabase(tenPhim, ngayKhoiChieu, thoiLuong, daoDien, dienVienChinh, hangSX, nuocSX, moTa, hinhAnh, selectedGenres);
				if (result)
				{
					MessageBox.Show("Phim mới đã được lưu!");
				}
				else
				{
					MessageBox.Show("Lưu phim mới thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			this.Close();
		}
		// Phương thức thêm phim mới vào cơ sở dữ liệu
		private bool AddNewFilmToDatabase(string tenPhim, DateTime ngayKhoiChieu, int thoiLuong, string daoDien,
										  string dienVienChinh, string hangSX, string nuocSX, string moTa, byte[] hinhAnh, List<string> theLoai)
		{
			try
			{
				string maxIdQuery = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaPhim, 2, LEN(MaPhim) - 1) AS INT)), 0) FROM PHIM";
				int maxId = Connection.ExecuteScalarInt32(maxIdQuery);

				SqlConnection conn;
				string current_ID = "P" + (maxId + 1); // Tạo ID mới từ ID lớn nhất hiện có + 1
				using (var transaction = Connection.BeginTransaction(out conn))
				{
					// Thêm phim vào bảng PHIM
					string insert_Query = "INSERT INTO PHIM VALUES (@MaPhim, @TenPhim, @Thoiluong, @Daodien, @DienvienChinh, @HangSX, @NuocSX, @HinhAnh, @MoTa, @NgayKhoiChieu, @Trangthai)";
					bool flag = Connection.ExcuteNonQuery(insert_Query, new (string, object)[] {
					("@MaPhim", current_ID),
					("@TenPhim", tenPhim),
					("@Thoiluong", thoiLuong),
					("@Daodien", daoDien),
					("@DienvienChinh", dienVienChinh),
					("@HangSX", hangSX),
					("@NuocSX", nuocSX),
					("@HinhAnh", hinhAnh),
					("@MoTa", moTa),
					("@NgayKhoiChieu", ngayKhoiChieu),
					("@Trangthai", Trangthai ? 1 : 0)
				});

					if (!flag) throw new Exception("Lỗi khi thêm phim");

					// Thêm vào bảng Phim_LoaiPhim cho các thể loại được chọn
					foreach (var selectedItem in clbTheLoai.CheckedItems)
					{
						DataRowView rowView = selectedItem as DataRowView;
						string maLoaiPhim = rowView["MaLoaiPhim"].ToString();
						string insertLoaiPhimQuery = "INSERT INTO Phim_LoaiPhim (MaPhim, MaLoaiPhim) VALUES (@MaPhim, @MaLoaiPhim)";
						Connection.ExcuteNonQuery(insertLoaiPhimQuery, new (string, object)[] {
						("@MaPhim", current_ID),
						("@MaLoaiPhim", maLoaiPhim)
					});
					}
					// Hoàn tất transaction
					transaction.Commit();
				}
				return true; // Trả về true nếu thêm thành công
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private bool UpdateFilmToDatabase(string maPhim, string tenPhim, DateTime ngayKhoiChieu, int thoiLuong,
								  string daoDien, string dienVienChinh, string hangSX, string nuocSX,
								  string moTa, byte[] hinhAnh, List<string> theLoai, bool Trangthai)
		{
			try
			{
				// Chuẩn bị truy vấn cập nhật thông tin phim trong bảng PHIM
				string updateFilmQuery = "UPDATE PHIM SET TenPhim = @TenPhim, NgayKhoiChieu = @NgayKhoiChieu, Thoiluong = @ThoiLuong, " +
										 "DaoDien = @DaoDien, DienVienChinh = @DienVienChinh, HangSanxuat = @HangSX, NuocSanxuat = @NuocSX, " +
										 "MoTa = @MoTa, HinhAnh = @HinhAnh, Trangthai = @Trangthai WHERE MaPhim = @MaPhim";

				// Các tham số cho lệnh cập nhật
				var filmParameters = new (string, object)[]
				{
			("@MaPhim", maPhim),
			("@TenPhim", tenPhim),
			("@NgayKhoiChieu", ngayKhoiChieu),
			("@ThoiLuong", thoiLuong),
			("@DaoDien", daoDien),
			("@DienVienChinh", dienVienChinh),
			("@HangSX", hangSX),
			("@NuocSX", nuocSX),
			("@MoTa", moTa),
			("@HinhAnh", hinhAnh),
			("@Trangthai", Trangthai ? 1 : 0)
				};

				SqlConnection conn;
				using (var transaction = Connection.BeginTransaction(out conn))
				{
					// Thực hiện lệnh cập nhật phim
					bool filmUpdated = Connection.ExecuteWithTransaction(updateFilmQuery, transaction, filmParameters);

					if (!filmUpdated)
						throw new Exception("Lỗi khi cập nhật thông tin phim.");

					// Xóa các thể loại cũ trong bảng liên kết Phim_LoaiPhim
					string deleteGenreQuery = "DELETE FROM Phim_LoaiPhim WHERE MaPhim = @MaPhim";
					var deleteParameters = new (string, object)[] { ("@MaPhim", maPhim) };
					Connection.ExecuteWithTransaction(deleteGenreQuery, transaction, deleteParameters);

					// Thêm lại các thể loại mới đã chọn
					string insertGenreQuery = "INSERT INTO Phim_LoaiPhim (MaPhim, MaLoaiPhim) VALUES (@MaPhim, @MaLoaiPhim)";
					foreach (var maLoaiPhim in theLoai)
					{
						var genreParameters = new (string, object)[]
						{
					("@MaPhim", maPhim),
					("@MaLoaiPhim", maLoaiPhim)
						};

						Connection.ExecuteWithTransaction(insertGenreQuery, transaction, genreParameters);
					}

					// Commit transaction nếu tất cả các lệnh thành công
					transaction.Commit();
					return true; // Cập nhật thành công
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		private void HienThiThongTinPhim(string maPhim)
		{
			// Truy vấn thông tin phim vừa thêm
			string query = "Select * from PHIM where MaPhim = @MaPhim";
			DataTable phimTable = Connection.GetDataTable(query, new (string, object)[] { ("@MaPhim", maPhim) });

			if (phimTable.Rows.Count > 0)
			{
				DataRow phim = phimTable.Rows[0];

				// Hiển thị thông tin phim (ví dụ qua MessageBox hoặc RichTextBox)
				string thongTinPhim = $"Tên phim: {phim["TenPhim"]}\n" +
									  $"Thời lượng: {phim["Thoiluong"]} phút\n" +
									  $"Đạo diễn: {phim["Daodien"]}\n" +
									  $"Diễn viên chính: {phim["DienvienChinh"]}\n" +
									  $"Hãng sản xuất: {phim["HangSanXuat"]}\n" +
									  $"Nước sản xuất: {phim["NuocSanXuat"]}\n" +
									  $"Ngày khởi chiếu: {Convert.ToDateTime(phim["NgayKhoiChieu"]).ToString("dd-MM-yyyy")}\n" +
									  $"Mô tả: {phim["MoTa"]}\n";

				// Ví dụ: Hiển thị qua MessageBox
				MessageBox.Show(thongTinPhim, "Thông tin phim");
			}

		}

		private void FormAddFilm_Load(object sender, EventArgs e)
		{

		}

		private void TBTenPhim_TextChange(object sender, EventArgs e)
		{

		}
	}
}
