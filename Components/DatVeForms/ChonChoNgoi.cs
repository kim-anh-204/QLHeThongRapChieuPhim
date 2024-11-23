using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    public partial class ChonChoNgoi : Form
    {
        private List<string> _selectedSeats = new List<string>();
        private int _giaVe;
        private string _maSuatChieu;
        private string _tenPhim;
        private string _ngayChieu;
        private string _gioChieu;
        public delegate void QuayLai_Click();
        public QuayLai_Click OnQuayLai_Click;
        public ChonChoNgoi()
        {
            InitializeComponent();
            flowLayoutPanel1.Controls.Clear();
            for (char c = 'A'; c <= 'F'; ++c)
            {
                for (int i = 1; i <= 8; ++i)
                {
                    string seatName = c + i.ToString();
                    Button button = CreateSeatButton(seatName, seatName);
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
        }
        public void ChangeInfo(string tenPhim, string ngayChieu, string gioChieu)
        {
            _tenPhim = tenPhim;
            _ngayChieu = ngayChieu;
            _gioChieu = gioChieu;
            _selectedSeats.Clear();
            string query = @"
SELECT 
    HinhAnh, 
    TenPhim, 
    TenPhong, 
    Ngaychieu, 
    GioBatdau,
    GiaVe, 
    TenGhe, 
    GHE.TrangThai, 
    SUATCHIEU.MaSuatchieu 
FROM 
    SUATCHIEU 
JOIN 
    PHIM 
        ON SUATCHIEU.MaPhim = PHIM.MaPhim 
JOIN 
    GHE 
        ON SUATCHIEU.MaSuatchieu = GHE.MaSuatChieu 
JOIN 
    PHONGCHIEUPHIM 
        ON PHONGCHIEUPHIM.MaPhong = SUATCHIEU.MaPhong 
WHERE 
    TenPhim = @TenPhim 
    AND Ngaychieu = @Ngaychieu 
    AND GioBatdau = @GioBatdau";
            DataTable dt = Connection.GetDataTable(query, new (string, object)[]
            {
                ("@TenPhim", tenPhim),
                ("@Ngaychieu",  ngayChieu),
                ("@GioBatdau",  gioChieu),
            });
            DataRow tmp = dt.Rows[0];
            pictureBoxPoster.Image = Helper.ConvertArrayToImage((byte[])tmp[0]);
            labelTenPhim.Text = (string)tmp[1];
            labelPhongChieu.Text = (string)tmp[2];
            labelSuatChieu.Text = ((DateTime)tmp[3]).ToString("dd/MM/yyyy") + "\n" + ((TimeSpan)tmp[4]).ToString();
            _giaVe = (int)tmp[5];
            labelGhe.Text = "";
            labelGiaVe.Text = _giaVe.ToString("N0") + " VND";
            labelTongTien.Text = "0 VND";
            _maSuatChieu = (string)tmp["MaSuatChieu"];

            ResetAllSeats();

            foreach (DataRow dr in dt.Rows)
            {
                if ((bool)dr["TrangThai"] == true)
                {
                    string tenGhe = (string)dr["TenGhe"];
                    int key = (tenGhe[0] - 'A') * 8 + (tenGhe[1] - '1');
                    flowLayoutPanel1.Controls[key].Enabled = false;
                }
            }

        }
        private void buttonQuayLai_Click(object sender, EventArgs e)
        {
            OnQuayLai_Click?.Invoke();
        }
        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            bool is_insert_successfully = InsertTicketToDatabase();
            bool is_update_successfully = UpdateSeatState();
            if (is_insert_successfully && is_update_successfully)
            {
                MessageBox.Show("Đặt vé thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeInfo(_tenPhim, _ngayChieu, _gioChieu);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đặt vé! Vui lòng thử lại vào khi khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChonChoNgoi_Load(object sender, EventArgs e)
        {

        }

        private Button CreateSeatButton(string buttonText, string buttonName)
        {
            Button button = new Button
            {
                Text = buttonText,
                Name = buttonName,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(40, 40)
            };
            button.Click += seatButton_Click;
            button.EnabledChanged += seatEnabledChanged;
            return button;
        }

        private void seatEnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
                button.BackColor = Color.White;
            else
                button.BackColor = Color.FromArgb(255, 187, 187);
        }
        private void seatButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string seatName = button.Text;
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Red;
                _selectedSeats.Add(seatName);
            }
            else
            {
                button.BackColor = Color.White;
                _selectedSeats.Remove(seatName);
            }
            labelGhe.Text = string.Join(", ", _selectedSeats);
            int tongTien = _giaVe * _selectedSeats.Count;
            labelTongTien.Text = tongTien.ToString("N0") + " VND";
        }

        private void ResetAllSeats()
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.BackColor = Color.White;
                control.Enabled = true;
            }

        }
        private bool InsertTicketToDatabase()
        {
            string lastId = Connection.ExecuteScalar("SELECT TOP 1 MAVE FROM VEXEMPHIM ORDER BY MAVE DESC") as string;
            string insertTicketQuery = "INSERT INTO VEXEMPHIM VALUES (@Mave, @MaSuatChieu, @MaNV, @TenGhe, @ThoigianDatve)";

            string lastNhanVienIdStr = (string)Connection.ExecuteScalar("SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY MaNV DESC");
            int lastNhanVienId = int.Parse(lastNhanVienIdStr.Substring(1));

            Random random = new Random();
            foreach (string Ghe in _selectedSeats)
            {
                string nextId = Helper.GenerateNextId(lastId, "V", 4);
                string maNV;
                do
                {
                    maNV = "E" + random.Next(1, lastNhanVienId).ToString("D3");
                }
                while (Connection.ExecuteScalarInt32("SELECT COUNT(*) FROM NHANVIEN WHERE MaNV = @MaNV", new (string, object)[] { ("@MaNV", maNV) }) == 0);

                bool is_insert_successfully = Connection.ExcuteNonQuery(insertTicketQuery, new (string, object)[]
                {
                    ("@Mave", nextId),
                    ("@MaSuatChieu", _maSuatChieu),
                    ("@MaNV", maNV),
                    ("@TenGhe", Ghe),
                    ("ThoigianDatVe", DateTime.Now)
                });

                if (is_insert_successfully == false)
                    return false;

                lastId = nextId;
            }
            return true;
        }
        private bool UpdateSeatState()
        {
            string danhSachGhe = string.Join(", ", _selectedSeats.Select(Ghe => $"'{Ghe}'"));
            string updateSeatQuery = $"UPDATE GHE SET TrangThai = 1 WHERE MaSuatChieu = @MaSuatChieu and TenGhe in ({danhSachGhe})";
            return Connection.ExcuteNonQuery(updateSeatQuery, new (string, object)[]
            {
                ("@MaSuatChieu", _maSuatChieu)
            });
        }

    }
}
