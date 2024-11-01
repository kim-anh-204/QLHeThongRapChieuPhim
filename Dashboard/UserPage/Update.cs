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
    public partial class Update : Form
    {
        private string maNV;
        private string tenNV;
        private string sdt;
        private UserManager userManager;
        public Update(UserManager userManager,string maNV, string tenNV, string sdt)
        {
            InitializeComponent();
            this.userManager = userManager;
            NameBtn.Text = tenNV;
            SdtBtn.Text = sdt;
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.sdt=sdt;
        }
        private bool UpdateNV(string maNV, string tenNV, string sdt)
        {
            string query = "UPDATE NHANVIEN SET TenNV = @TenNV, SDT = @SDT WHERE MaNV = @MaNV";

            return Connection.ExcuteNonQuery(query, new (string, object)[]
            {
             ("@MaNV", maNV),
            ("@TenNV", tenNV),
            ("@SDT", sdt),
          
            });
        }
        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (NameBtn.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập tên nhân viên");
                return;
            }
            else if (SdtBtn.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại");
                return;
            }
            string newTenNV = NameBtn.Text.Trim();
            string newSDT = SdtBtn.Text.Trim();

            bool result = UpdateNV(maNV, newTenNV, newSDT);
            if (result)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); 
                userManager.LoadNhanVienData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NameBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void SdtBtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
