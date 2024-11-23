using Bunifu.UI.WinForms;
using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.ScreeningPage
{
    public partial class Screening : Form
    {
        public Screening()
        {
            InitializeComponent();
            LoadScreeningData();
            SetupDataGridView();
            thoat.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadScreeningData();
        }
        public void LoadScreeningData()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            string query = @"
                   SELECT
                PHIM.TenPhim,
	            PHONGCHIEUPHIM.TenPhong,
	            SUATCHIEU.Ngaychieu,
	            SUATCHIEU.GioBatdau,
	            SUATCHIEU.LoaiChieu,
	            SUATCHIEU.MaSuatchieu,
                SUATCHIEU.GiaVe
                FROM
                SUATCHIEU join PHIM on PHIM.MaPhim=SUATCHIEU.MaPhim
	            join PHONGCHIEUPHIM on PHONGCHIEUPHIM.MaPhong= SUATCHIEU.MaPhong
                WHERE SUATCHIEU.TrangThai='CHUAXOA'
                ";

            DataTable screeningData = Connection.GetDataTable(query);
            if (screeningData != null && screeningData.Rows.Count > 0)
            {
                foreach (DataRow row in screeningData.Rows)
                {
                    string maSc = row["MaSuatChieu"]?.ToString();
                    string tenPhim = row["TenPhim"]?.ToString();
                    string tenPhong = row["TenPhong"]?.ToString();
                    string ngayChieu = row["NgayChieu"]?.ToString();
                    string gioBatDau = row["GioBatDau"]?.ToString();
                    int giaVe = Convert.ToInt32(row["GiaVe"]);
                    if (DateTime.TryParse(ngayChieu, out DateTime parsedNgayChieu))
                    {
                        ngayChieu = parsedNgayChieu.ToString("MM/dd/yyyy"); 
                    }
                    bunifuDataGridView1.Rows.Add(maSc,tenPhim, tenPhong, ngayChieu, gioBatDau, giaVe);
                }
            }
            else
            {

            }

        }

        private void BunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                string maSc = bunifuDataGridView1.Rows[e.RowIndex].Cells["maSC"].Value.ToString();
                string query = @"
                         SELECT MaPhim, MaPhong, Ngaychieu, GioBatdau, SoVeToida, LoaiChieu, GiaVe
                         FROM SUATCHIEU
                         WHERE MaSuatchieu = @MaSuatchieu ";

                var parameters = new (string, object)[]
                    {
                            ("@MaSuatchieu", maSc)
                    };
                DataTable screeningData = Connection.GetDataTable(query, parameters);
                string maPhim = screeningData.Rows[0]["MaPhim"].ToString();
                string maPhong = screeningData.Rows[0]["MaPhong"].ToString();
                string gioBatDau = screeningData.Rows[0]["GioBatDau"].ToString();
                DateTime ngayChieu = Convert.ToDateTime(screeningData.Rows[0]["Ngaychieu"]);
                string soVeToida = screeningData.Rows[0]["SoVeToida"].ToString();
                string loaiChieu = screeningData.Rows[0]["LoaiChieu"].ToString();
                string giaVe = screeningData.Rows[0]["GiaVe"].ToString();
                DateTime today = DateTime.Now.Date;
                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
                {                    
                    
                    UpdateScreening updateScreening = new UpdateScreening(this, maSc, maPhim, maPhong, gioBatDau, ngayChieu, loaiChieu, giaVe);
                    updateScreening.Show();
                    bunifuTextBox1.Text = "";

                }
                else if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {                                
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu phim?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
						string checkGHEQuery = "SELECT COUNT(*) FROM GHE WHERE MaSuatChieu = @MaSuatChieu AND TrangThai = 'True'";
						int count = Connection.ExecuteScalarInt32(checkGHEQuery, new (string, object)[] { ("@MaSuatChieu", maSc) });
						if (count > 0&& ngayChieu >= today)
						{
							MessageBox.Show("Xóa không thành công vì đã có người đặt vé!");
							return;
                        }                    
                        string updateQuery = "UPDATE SUATCHIEU SET TRANGTHAI = 'XOA' WHERE MaSuatChieu = @MaSuatChieu";
                        bool isUpdated = Connection.ExcuteNonQuery(updateQuery, new (string, object)[] { ("@MaSuatChieu", maSc) });
;
                        if (isUpdated )
                        {                        
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bunifuTextBox1.Text = "";
                            thoat.Visible = false;
                            LoadScreeningData();
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
            bunifuDataGridView1.CellClick += BunifuDataGridView1_CellClick;
            if (bunifuDataGridView1.Rows.Count == 0)
            {
                bunifuDataGridView1.BackgroundColor = Color.White;
            }
        }
        private void UserManager_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            AddScreening addScreening = new AddScreening(this);
            addScreening.Show();
            bunifuTextBox1.Text = "";
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void VisibleButton()
        {
            thoat.Visible = false;
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string searchText= bunifuTextBox1.Text;
            if (searchText.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm kiếm!");
                return;

            }
            string query = @"SELECT * FROM SUATCHIEU
                 join PHIM on PHIM.MaPhim=SUATCHIEU.MaPhim
                join PHONGCHIEUPHIM on PHONGCHIEUPHIM.MaPhong= SUATCHIEU.MaPhong
                 WHERE TenPhim LIKE @searchText";

            var parameters = new (string, object)[] { ("@searchText", "%" + searchText + "%") };
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            DataTable result = Connection.GetDataTable(query, parameters);
            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    string maSc = row["MaSuatChieu"]?.ToString();
                    string tenPhim = row["TenPhim"]?.ToString();
                    string tenPhong = row["TenPhong"]?.ToString();
                    string ngayChieu = row["NgayChieu"]?.ToString();
                    string gioBatDau = row["GioBatDau"]?.ToString();
                    int giaVe = Convert.ToInt32(row["GiaVe"]);
                    if (DateTime.TryParse(ngayChieu, out DateTime parsedNgayChieu))
                    {
                        ngayChieu = parsedNgayChieu.ToString("MM/dd/yyyy");
                    }
                    bunifuDataGridView1.Rows.Add(maSc, tenPhim, tenPhong, ngayChieu, gioBatDau, giaVe);
                }
                thoat.Visible = true;

            }
            else
            {

            }
           
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void thoat_Click(object sender, EventArgs e)
        {
            thoat.Visible = false;
            bunifuTextBox1.Text = "";
            LoadScreeningData();
        }

        private void Screening_Shown(object sender, EventArgs e)
        {
            LoadScreeningData();

        }
    }
}
