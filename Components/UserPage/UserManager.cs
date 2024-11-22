using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UserPage
{
    public partial class UserManager : Form
    {
        private DataGridViewRow selectedRow = null;
        private int selectedColumnIndex = -1;
        public UserManager()
        {
            InitializeComponent();          
            SetupDataGridView();
            LoadNhanVienData();
            thoat.Visible = false;
        }
        private void InitializeButton()
        {
            
        }
        public void VisibleButton()
        {
            thoat.Visible = false;
        }
        public void LoadNhanVienData()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            string query = "SELECT * FROM NHANVIEN WHERE TRANGTHAI = 'DANGLAM' ORDER BY MaNV;";

            DataTable nhanVienData = Connection.GetDataTable(query); 
            if (nhanVienData != null && nhanVienData.Rows.Count > 0) 
            {
                foreach (DataRow row in nhanVienData.Rows)
                {
                    string maNV = row["MaNV"]?.ToString();
                    string tenNV = row["TenNV"]?.ToString();
                    string sdt = row["SDT"]?.ToString();

                    bunifuDataGridView1.Rows.Add(maNV, tenNV, sdt);
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
                string maNV = bunifuDataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();

                if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Sua")
                {
                    string maNVEdit = bunifuDataGridView1.Rows[rowIndex].Cells["MaNV"].Value.ToString();
                    string tenNVEdit = bunifuDataGridView1.Rows[rowIndex].Cells["TenNV"].Value.ToString();
                    string sdtEdit = bunifuDataGridView1.Rows[rowIndex].Cells["SoDienThoai"].Value.ToString();
                    Update update = new Update(this, maNVEdit, tenNVEdit, sdtEdit);
                    update.Show();
                    bunifuTextBox1.Text = "";                  

                }
                else if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên với mã: {maNV}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        string updateQuery = "UPDATE NHANVIEN SET TRANGTHAI = 'SATHAI' WHERE MaNV = @MaNV";
                        bool isUpdated = Connection.ExcuteNonQuery(updateQuery, new (string, object)[] { ("@MaNV", maNV) });

                        if (isUpdated)
                        {
                            bunifuDataGridView1.Rows.RemoveAt(e.RowIndex);
                            MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bunifuTextBox1.Text = "";
                            LoadNhanVienData();
                            thoat.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Add add = new Add(this);
            add.Show();
            bunifuTextBox1.Text = "";
        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string searchText = bunifuTextBox1.Text;
            if (searchText.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm kiếm!");
                return;

            }
            string query = @"SELECT * FROM NHANVIEN              
                 WHERE TenNV LIKE @searchText";

            var parameters = new (string, object)[] { ("@searchText", "%" + searchText + "%") };
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            DataTable result = Connection.GetDataTable(query, parameters);
            if (result != null && result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    string maNV = row["MaNV"]?.ToString();
                    string tenNV = row["TenNV"]?.ToString();
                    string sdt = row["SDT"]?.ToString();
                    bunifuDataGridView1.Rows.Add(maNV, tenNV, sdt);
                    thoat.Visible = true;

                }
            }
            else
            {

            }
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            thoat.Visible = false;
            bunifuTextBox1.Text = "";
            LoadNhanVienData();
        }
    }
}
