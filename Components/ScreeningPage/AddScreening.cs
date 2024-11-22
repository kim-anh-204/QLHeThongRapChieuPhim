using Bunifu.UI.WinForms;
using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.ScreeningPage
{
    public partial class AddScreening : Form
    {
        private Screening screening;
        public AddScreening(Screening screening)
        {
            InitializeComponent();
            this.screening = screening;
            this.ActiveControl = null;
            bunifuDatePicker1.Value = DateTime.Now;
            getMovies();
            LoadRoom();
        }
        private void getMovies()
        {
            string query = "SELECT MaPhim, TenPhim FROM PHIM"; 
            DataTable moviesTable = Connection.GetDataTable(query);

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
            DataTable moviesTable = Connection.GetDataTable(query);

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
        private void Add_Load(object sender, EventArgs e)
        {

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
            string queryID = "SELECT TOP 1 MaSuatChieu FROM SUATCHIEU ORDER BY MaSuatChieu DESC;";
            DataTable result = Connection.GetDataTable(queryID);
            string maSC = result.Rows[0]["MaSuatChieu"].ToString();
            string prefix = maSC.Substring(0, 1); 
            string numberPart = maSC.Substring(1);
            int number = int.Parse(numberPart);
            number += 1;
            string newNumberPart = number.ToString();
            if (newNumberPart.Length == 1)
            {
                newNumberPart = "00" + newNumberPart; 
            }
            else if (newNumberPart.Length == 2)
            {
                newNumberPart = "0" + newNumberPart; 
            }
            string newMaSC = prefix + newNumberPart;

            var selectedMovie = (KeyValuePair<string, string>)comboBoxMovies.SelectedItem;
            string maPhim = selectedMovie.Key;
            string queryPhim = @"SELECT TOP 1 NgayKhoiChieu,DATEADD(MONTH, 1, PHIM.NgayKhoiChieu) AS NgayKetThuc FROM PHIM WHERE MaPhim= @MaPhim";
            var parameters = new (string, object)[] { ("@MaPhim", maPhim) };
            DataTable resultPhim = Connection.GetDataTable(queryPhim, parameters);
            string ngayKhoiChieu = resultPhim.Rows[0]["NgayKhoiChieu"].ToString();
            string ngayKetThuc = resultPhim.Rows[0]["NgayKetThuc"].ToString();
            string tenPhim = selectedMovie.Value;
            var selectedRoom = (KeyValuePair<string, string>)comboBoxRoom.SelectedItem;
            string maPhong = selectedRoom.Key;
            string price = priceTextBox.Text;
            string type = movieType.SelectedItem.ToString();
            DateTime selectedTime = dateTimePicker1.Value;
            DateTime today = DateTime.Now.Date;
            DateTime now = DateTime.Now;
            string formattedDate = bunifuDatePicker1.Value.ToString("MM/dd/yyyy");
            DateTime selectedDate = DateTime.ParseExact(ngayKetThuc, "M/d/yyyy h:mm:ss tt", null);
            DateTime NgayTao = DateTime.Now.Date;


            if (selectedDate < today)
            {
                MessageBox.Show("Phim này đã hết hạn vui lòng chọn phim khác!");
                return;
            }
            else if (selectedDate < bunifuDatePicker1.Value|| bunifuDatePicker1.Value< today)
            {
                MessageBox.Show("Thời gian chiếu phim đã vưọt quá ngày hết hạn phim hoặc nhỏ hơn ngày hiện tại!");
                return;
            }
            else if (selectedTime < now)
            {
                MessageBox.Show("Giờ được chọn phải lớn hơn giờ hiện tại");
                return;
            }
            string queryInsert = "INSERT INTO SUATCHIEU (MaSuatChieu,MaPhim, MaPhong,MaNguoiDung,NgayChieu,GioBatDau,SoVeToiDa,LoaiChieu, GiaVe) VALUES (@MaSuatChieu,@MaPhim, @MaPhong,@MaNguoiDung,@NgayChieu,@GioBatDau,@SoVeToiDa,@LoaiChieu, @GiaVe)";

            Connection.ExcuteNonQuery(queryInsert, new (string, object)[]
             {
            ("@MaSuatChieu", newMaSC),
            ("@MaPhim", maPhim),
            ("@MaPhong", maPhong),
            ("@MaNguoiDung", "U001"),
            ("@NgayChieu", formattedDate),
            ("@GioBatDau", selectedTime.ToString("HH:mm")),
            ("@SoVeToiDa", 48),
            ("@LoaiChieu", type),
            ("@GiaVe", price)
             });
            List<string> gheList = new List<string>();
            char[] hang = { 'A', 'B', 'C', 'D', 'E', 'F' }; // Các hàng ghế
            int soGhe = 8; // Số ghế mỗi hàng

            // Tạo tên ghế
            foreach (char h in hang)
            {
                for (int i = 1; i <= soGhe; i++)
                {
                    gheList.Add($"{h}{i}");
                }
            }

            foreach (string tenGhe in gheList)
            {
                string queryInsertGhe = "INSERT INTO GHE (TenGhe, MaSuatChieu, TrangThai) VALUES (@TenGhe, @MaSuatChieu, @TrangThai)";

                Connection.ExcuteNonQuery(queryInsertGhe, new (string, object)[]
                {
                    ("@TenGhe", tenGhe),
                    ("@MaSuatChieu", newMaSC),
                    ("@TrangThai", false)
                });
            }
            this.Close();
            screening.LoadScreeningData();
            screening.VisibleButton();
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ticketTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
