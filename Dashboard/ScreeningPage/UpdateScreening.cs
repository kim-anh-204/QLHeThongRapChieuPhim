using QuanLyRapChieuPhim.UserPage;
using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            this.loaiChieu = movieType.SelectedItem.ToString();
            this.giaVe = priceTextBox.Text;

            string query = "UPDATE SUATCHIEU SET MaPhim = @MaPhim, LoaiChieu = @LoaiChieu,GioBatDau = @GioBatDau,NgayChieu = @NgayChieu,GiaVe=@GiaVe WHERE MaSuatChieu = @MaSuatChieu";
            var result=Connection.ExcuteNonQuery(query, new (string, object)[]
           {
            ("@MaSuatChieu", maSc),
            ("@MaPhim", maPhim),
            ("@MaPhong", maPhong),
            ("@MaNguoiDung", "U001"),
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
        }

        private void SetDefaultMovie(string maPhim)
        {
            for (int i = 0; i < comboBoxMovies.Items.Count; i++)
            {
                var item = (KeyValuePair<string, string>)comboBoxMovies.Items[i];
                if (item.Key == maPhim)
                {
                    comboBoxMovies.SelectedIndex = i;
                    break;
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
            string query = "SELECT MaPhim, TenPhim FROM PHIM";
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
            string query = "SELECT MaPhong, TenPhong FROM PHONGCHIEUPHIM";
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
