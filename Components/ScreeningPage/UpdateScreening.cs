using DocumentFormat.OpenXml.Spreadsheet;
using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Connection = QuanLyRapChieuPhim.Util.Connection;

namespace QuanLyRapChieuPhim.ScreeningPage
{
    public partial class UpdateScreening : Form
    {
        private Screening screening;
        private string maSc, maPhim, maPhong, gioBatDau, loaiChieu, giaVe;
        private DateTime ngayChieu;
        public UpdateScreening(Screening screening,string maSc, string maPhim, string maPhong, string gioBatDau, DateTime ngayChieu, string loaiChieu, string giaVe)
        {
            InitializeComponent();
            this.screening = screening;
            this.maSc = maSc;
            this.maPhim = maPhim;
            this.maPhong = maPhong;
            this.gioBatDau = gioBatDau;
            this.ngayChieu = ngayChieu;
            this.loaiChieu = loaiChieu;
            this.giaVe = giaVe;
            getMovies();
            LoadRoom();
            priceTextBox.Text = giaVe;
            SetDefaultMovie(maPhim);
            SetDefaultMovieRoom(maPhong);
            movieType.Text = loaiChieu;
            dateTimePicker1.Value = DateTime.Parse(gioBatDau);
            bunifuDatePicker1.Value = ngayChieu;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxMovies.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần chọn phim");
                return;
            }
            else if (comboBoxRoom.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần chọn phòng");
                return;
            }
            else if (movieType.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần chọn loại chiếu");
                return;
            }
            else if (priceTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập giá vé");
                return;
            }
            var selectedMovie = (KeyValuePair<string, string>)comboBoxMovies.SelectedItem;
            this.maPhim = selectedMovie.Key;
            var selectedRoom = (KeyValuePair<string, string>)comboBoxRoom.SelectedItem;
            this.maPhong = selectedRoom.Key;
            DateTime selectedTime = dateTimePicker1.Value;
            string formattedDate = bunifuDatePicker1.Value.ToString("MM/dd/yyyy"); ;
            string queryPhim = @"SELECT TOP 1 NgayKhoiChieu,DATEADD(MONTH, 1, PHIM.NgayKhoiChieu) AS NgayKetThuc FROM PHIM WHERE MaPhim= @MaPhim";
            var parameters = new (string, object)[] { ("@MaPhim", maPhim) };
            string maNguoiDDung = (String)SharedData.GetValue("MaNguoiDung");
            DataTable resultPhim = Connection.GetDataTable(queryPhim, parameters);
            DateTime ngayKhoiChieu = (DateTime)resultPhim.Rows[0]["NgayKhoiChieu"];
            DateTime ngayKetThuc = (DateTime)resultPhim.Rows[0]["NgayKetThuc"];
            this.loaiChieu = movieType.SelectedItem.ToString();
            this.giaVe = priceTextBox.Text;
            DateTime today = DateTime.Now.Date;
            DateTime now = DateTime.Now;
            DateTime NgayTao = DateTime.Now.Date;
            string queryPC = @"SELECT TOP 1 * FROM PHONGCHIEUPHIM WHERE MaPhong= @MaPhong";
            var parametersPC = new (string, object)[] { ("@MaPhong", maPhong) };
            DataTable resultPC = Connection.GetDataTable(queryPC, parametersPC);
            Boolean trangThaiPhong = (Boolean)resultPC.Rows[0]["TrangthaiPhongchieu"];
            string queryTrung = @"
SELECT COUNT(*) 
FROM SUATCHIEU 
WHERE MaPhong = @MaPhong 
  AND TrangThai = 'CHUAXOA'
  AND MaSuatChieu NOT IN (@MaSC)
  AND (
      (NgayChieu = @NgayChieu AND 
       (
           CAST(@NgayChieu AS DATETIME) + CAST(@GioDuocChon AS DATETIME) < CAST(NgayChieu AS DATETIME) + CAST(GioBatDau AS DATETIME) + 4.0/24 
           AND 
           CAST(@NgayChieu AS DATETIME) + CAST(@GioDuocChon AS DATETIME) + 4.0/24 > CAST(NgayChieu AS DATETIME) + CAST(GioBatDau AS DATETIME)
       )
      )
      OR
      (NgayChieu = DATEADD(DAY, -1, @NgayChieu) AND 
       CAST(NgayChieu AS DATETIME) + CAST(GioBatDau AS DATETIME) + 4.0/24 > CAST(@NgayChieu AS DATETIME) + CAST(@GioDuocChon AS DATETIME)
      )
      OR
      (NgayChieu = DATEADD(DAY, 1, @NgayChieu) AND 
       CAST(@NgayChieu AS DATETIME) + CAST(@GioDuocChon AS DATETIME) + 4.0/24 > CAST(NgayChieu AS DATETIME) + CAST(GioBatDau AS DATETIME)
      )
  )";
            var parametersTrung = new (string, object)[] { ("@MaPhong", maPhong), ("@Ngaychieu", formattedDate), ("@GioDuocChon", selectedTime.TimeOfDay), ("@MaSC", maSc) };
            DataTable resultTrung = Connection.GetDataTable(queryTrung, parametersTrung);
            int count = Convert.ToInt32(Connection.ExecuteScalar(queryTrung, parametersTrung));
            if (ngayKetThuc < today)
            {
                MessageBox.Show("Phim này đã hết hạn vui lòng chọn phim khác!");
                return;
            }
            else if (ngayKetThuc < bunifuDatePicker1.Value || bunifuDatePicker1.Value < today || bunifuDatePicker1.Value < ngayKhoiChieu)
            {
                MessageBox.Show("Ngày chiếu phim không nằm trong thời gian chiếu của phim!");
                return;
            }
            else if (bunifuDatePicker1.Value.Date == today.Date && selectedTime.TimeOfDay < now.TimeOfDay)
            {
                MessageBox.Show("Giờ được chọn phải lớn hơn giờ hiện tại!");
                return;
            }
            else if (!trangThaiPhong)
            {
                MessageBox.Show("Phòng đang được bảo trì vui lòng chọn phòng khác!");
                return;
            }
            else if (count > 0)
            {
                MessageBox.Show("Đã bị trùng lịch chiếu!");
                return;
            }
            string checkGHEQuery = "SELECT COUNT(*) FROM GHE WHERE MaSuatChieu = @MaSuatChieu AND TrangThai = 'True'";
            int count1 = Connection.ExecuteScalarInt32(checkGHEQuery, new (string, object)[] { ("@MaSuatChieu", maSc) });
            if (count1 > 0 && ngayChieu >= today)
            {
                MessageBox.Show("Cập nhật không thành công vì đã có người đặt vé!");
                return;
            }
            string query = "UPDATE SUATCHIEU SET MaPhim = @MaPhim,MaPhong=@MaPhong, LoaiChieu = @LoaiChieu,GioBatDau = @GioBatDau,NgayChieu = @NgayChieu,GiaVe=@GiaVe WHERE MaSuatChieu = @MaSuatChieu";
            var result = Connection.ExcuteNonQuery(query, new (string, object)[]
           {
            ("@MaSuatChieu", maSc),
            ("@MaPhim", maPhim),
            ("@MaPhong", maPhong),
            ("@MaNguoiDung", maNguoiDDung),
            ("@NgayChieu", formattedDate),
            ("@GioBatDau", selectedTime.ToString("HH:mm")),
            ("@LoaiChieu", loaiChieu),
            ("@GiaVe", giaVe)

           });

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                screening.LoadScreeningData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            screening.LoadScreeningData();
            screening.VisibleButton();
        }

        private void SetDefaultMovie(string maPhim)
        {
            for (int i = 0; i < comboBoxMovies.Items.Count; i++)
            {
                var item = (KeyValuePair<string, string>)comboBoxMovies.Items[i];
                if (item.Key == maPhim)
                {
                    comboBoxMovies.SelectedIndex = i;
                    return;
                }
            }
        }
        private void SetDefaultMovieRoom(string maPhong) { 
            for (int i = 0; i < comboBoxRoom.Items.Count; i++)
            {
                var item = (KeyValuePair<string, string>)comboBoxRoom.Items[i];
                if (item.Key == maPhong)
                {
                    comboBoxRoom.SelectedIndex = i;
                    break;
                }
            }
        }
        private void getMovies()
        {
            string query = "SELECT MaPhim, TenPhim FROM PHIM  WHERE TrangThai='True'";
            DataTable moviesTable = QuanLyRapChieuPhim.Util.Connection.GetDataTable(query);

            if (moviesTable != null)
            {
                comboBoxMovies.Items.Clear();

                foreach (DataRow row in moviesTable.Rows)
                {
                    comboBoxMovies.Items.Add(new KeyValuePair<string, string>(row["MaPhim"].ToString(), row["TenPhim"].ToString()));
                }
                comboBoxMovies.DisplayMember = "Value";
                comboBoxMovies.ValueMember = "Key";
                comboBoxMovies.Text = "Chọn phim";
            }
            else
            {
                MessageBox.Show("Không thể tải danh sách phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRoom()
        {
            string query = "SELECT MaPhong, TenPhong FROM PHONGCHIEUPHIM WHERE TrangThai='CHUAXOA'";
            DataTable moviesTable = QuanLyRapChieuPhim.Util.Connection.GetDataTable(query);

            if (moviesTable != null)
            {
                comboBoxRoom.Items.Clear();

                foreach (DataRow row in moviesTable.Rows)
                {
                    comboBoxRoom.Items.Add(new KeyValuePair<string, string>(row["MaPhong"].ToString(), row["TenPhong"].ToString()));
                }
                comboBoxRoom.DisplayMember = "Value";
                comboBoxRoom.ValueMember = "Key";
                comboBoxRoom.Text = "Chọn phòng";
            }
            else
            {
                MessageBox.Show("Không thể tải danh sách phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateScreening_Load(object sender, EventArgs e)
        {

        }
    }
}
