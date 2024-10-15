using Bunifu.UI.WinForms;
using QuanLyRapChieuPhim.UserPage;
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

namespace QuanLyRapChieuPhim.ScreeningPage
{
    public partial class Screening : Form
    {
        public Screening()
        {
            InitializeComponent();
            LoadScreeningData();
            SetupDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                    string giaVe = row["GiaVe"]?.ToString();
                    if (DateTime.TryParse(ngayChieu, out DateTime parsedNgayChieu))
                    {
                        ngayChieu = parsedNgayChieu.ToString("MM/dd/yyyy"); // Định dạng lại chỉ lấy phần ngày
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

                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
                {
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
                    string giaVe =screeningData.Rows[0]["GiaVe"].ToString();
                    UpdateScreening updateScreening = new UpdateScreening(this, maSc, maPhim, maPhong, gioBatDau, ngayChieu, loaiChieu, giaVe);
                    updateScreening.Show();
                }
                else if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa suất chiếu phim?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        string deleteGHEQuery = "DELETE FROM GHE WHERE MaSuatChieu = @MaSuatChieu";
                        bool isDeletedGHE = Connection.ExcuteNonQuery(deleteGHEQuery, new (string, object)[] { ("@MaSuatChieu", maSc) });
                        string deleteQuery = "DELETE FROM SUATCHIEU WHERE MaSuatChieu = @MaSuatChieu";
                        bool isDeleted = Connection.ExcuteNonQuery(deleteQuery, new (string, object)[] { ("@MaSuatChieu", maSc) });
                        
                        if (isDeleted&& isDeletedGHE)
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
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
