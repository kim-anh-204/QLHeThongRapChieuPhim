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

namespace QuanLyRapChieuPhim.Components.CustomerPage
{
    public partial class CustomerManager : Form
    {
        public CustomerManager()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        public void LoadCustomerData()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            string query = @"
                SELECT *
                FROM
                KHACHHANG   
                WHERE TrangThai='CHUAXOA'
                ";

            DataTable screeningData = Connection.GetDataTable(query);
            if (screeningData != null && screeningData.Rows.Count > 0)
            {
                foreach (DataRow row in screeningData.Rows)
                {
                    string maKh = row["MaKH"]?.ToString();
                    string hoTen = row["HoVaTen"]?.ToString();
                    string gioiTinh = row["GioiTinh"]?.ToString();
                    if (gioiTinh == "False") gioiTinh = "Nam";
                    else gioiTinh = "Nữ";
                    string ngaySinh = row["NgaySinh"]?.ToString();
                    if (DateTime.TryParse(ngaySinh, out DateTime parsedNgaySinh))
                    {
                        ngaySinh = parsedNgaySinh.ToString("MM/dd/yyyy");
                    }
                    string sdt = row["SoDienThoai"]?.ToString();
                    string email = row["Email"]?.ToString();
                    bunifuDataGridView1.Rows.Add(maKh,hoTen, gioiTinh, ngaySinh, sdt, email);
                }
            }
            else
            {

            }

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string searchText = bunifuTextBox1.Text;
            string query = @"SELECT * FROM KHACHHANG              
                 WHERE HoVaTen LIKE @searchText";

            var parameters = new (string, object)[] { ("@searchText", "%" + searchText + "%") };
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            DataTable result = Connection.GetDataTable(query, parameters);
            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    string maKh = row["MaKH"]?.ToString();
                    string hoTen = row["HoVaTen"]?.ToString();
                    string gioiTinh = row["GioiTinh"]?.ToString();
                    if (gioiTinh == "False") gioiTinh = "Nam";
                    else gioiTinh = "Nữ";
                    string ngaySinh = row["NgaySinh"]?.ToString();
                    if (DateTime.TryParse(ngaySinh, out DateTime parsedNgaySinh))
                    {
                        ngaySinh = parsedNgaySinh.ToString("MM/dd/yyyy");
                    }
                    string sdt = row["SoDienThoai"]?.ToString();
                    string email = row["Email"]?.ToString();
                    bunifuDataGridView1.Rows.Add(maKh,hoTen, gioiTinh, ngaySinh, sdt, email);
                }
            }
            else
            {

            }
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                string maKh = bunifuDataGridView1.Rows[e.RowIndex].Cells["maKh"].Value.ToString();
       
                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên với mã: {maKh}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        string updateQuery = "UPDATE KHACHHANG SET TrangThai = 'XOA' WHERE MaKH = @MaKH";
                        bool isUpdated = Connection.ExcuteNonQuery(updateQuery, new (string, object)[] { ("@MaKH", maKh) });

                        if (isUpdated)
                        {
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bunifuTextBox1.Text = "";
                            LoadCustomerData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa khách hàng không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
