using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
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
          
        }
        private void InitializeButton()
        {
            
        }
        public void LoadNhanVienData()
        {
            bunifuDataGridView1.Rows.Clear();
            bunifuDataGridView1.DataSource = null;
            string query = "SELECT * FROM NHANVIEN ORDER BY MaNV ;"; 

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
                }
                else if (bunifuDataGridView1.Columns[e.ColumnIndex].Name == "Xoa")
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên với mã: {maNV}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        string deleteQuery = "DELETE FROM NHANVIEN WHERE MaNV = @MaNV";
                        bool isDeleted = Connection.ExcuteNonQuery(deleteQuery, new (string, object)[] { ("@MaNV", maNV) });

                        if (isDeleted)
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
            Add add = new Add(this);
            add.Show();
        }

    }
}
