using Bunifu.UI.WinForms.BunifuButton;
using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.MainForm
{
    public partial class DashboardForm : Form
    {
        public delegate void CloseEvent();
        public CloseEvent OnCloseClick;
        public DashboardForm(string username)
        {
            InitializeComponent();
            labelTenDangNhap.Text = username;
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCloseClick?.Invoke();
        }

        private void buttonTrangChu_Click(object sender, EventArgs e)
        {
      
        }

        private void buttonPhim_Click(object sender, EventArgs e)
        {

        }

        private void buttonNhanVien_Click(object sender, EventArgs e)
        {

        }


        private void MoveIndicatorToButton(BunifuButton2 button)
        {
        }

        private void buttonTrangChu_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonTrangChu);
        }

        private void buttonPhim_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonPhim);
        }

        private void buttonNhanVien_MouseMove(object sender, MouseEventArgs e)
        {
            MoveIndicatorToButton(buttonNhanVien);
        }
        private void buttonTrangChu_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonTrangChu.ClientRectangle.Contains(buttonTrangChu.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }

        private void buttonPhim_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonPhim.ClientRectangle.Contains(buttonPhim.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void buttonNhanVien_MouseLeave(object sender, EventArgs e)
        {
            if (!buttonNhanVien.ClientRectangle.Contains(buttonNhanVien.PointToClient(Cursor.Position)))
                MoveIndicatorToDefault();
        }
        private void MoveIndicatorToDefault()
        {
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (textboxTenNV.Text == "" || textboxSDT.Text == "")
            {
                MessageBox.Show("Trống!");
                return;
            }

            string countQuery = "SELECT COUNT(*) FROM NHANVIEN";
            int id_count = Connection.ExecuteScalarInt32(countQuery);

            string current_id = "NV" + id_count;
            DateTime today = DateTime.Now;

            string insertQuery = "INSERT INTO NHANVIEN VALUES (@MaNV, @TenNV, @SDT, @NgayTao)";
            bool flag = Connection.ExcuteNonQuery(insertQuery, new (string, object)[]
            {
                ("@MaNV", current_id),
                ("@TenNV", textboxTenNV.Text),
                ("@SDT", textboxSDT.Text),
                ("@NgayTao", today)
            });
            if (flag == false)
            {
                MessageBox.Show("Lỗi");
            }
            else
            {
                DisplayData();
                MessageBox.Show("Thành công");
            }
        }

        private void DisplayData()
        {
            string dataQuery = "SELECT * FROM NHANVIEN";
            DataTable khachHang = Connection.GetDataTable(dataQuery);
            dataGridViewKhachHang.Rows.Clear();
            //dataGridViewKhachHang.DataSource = khachHang;
            foreach (DataRow row in khachHang.Rows)
            {
                dataGridViewKhachHang.Rows.Add(row["MaNV"], row["TenNV"], row["SDT"], row["NgayTao"]);
            }
        }

        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
