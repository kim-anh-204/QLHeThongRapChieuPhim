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
    public partial class Add : Form
    {
        private UserManager userManager;
        public Add(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            string queryID = "SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY MaNV DESC;";
            DataTable result = Connection.GetDataTable(queryID);
            string maNV = result.Rows[0]["MaNV"].ToString();
           
            string prefix = maNV.Substring(0, 1); // Lấy chữ cái 'E'
            string numberPart = maNV.Substring(1); // Lấy phần số
            int number = int.Parse(numberPart); // Chuyển đổi thành số nguyên

            // Tăng số lên 1 và xử lý các quy tắc khác như đã nêu ở phần trước
            number += 1;

            // Chuyển lại thành chuỗi và kiểm tra độ dài
            string newNumberPart = number.ToString();
            if (newNumberPart.Length == 1)
            {
                newNumberPart = "00" + newNumberPart; // Nếu chỉ có 1 chữ số, thêm 2 số 0
            }
            else if (newNumberPart.Length == 2)
            {
                newNumberPart = "0" + newNumberPart; // Nếu có 2 chữ số, thêm 1 số 0
            }

            // Ghép lại với prefix
            string newMaNV = prefix + newNumberPart;

            //if (result != null && result.Rows.Count > 0)
            //{
            //    maNV = Convert.ToInt32(result.Rows[0]["MaNV"]);
            //    maNV += 1;
            //}
            //else
            //{
            //    maNV = 1;
            //}
            string name = NameBtn.Text;
            string phoneNumber = SdtBtn.Text;  
            string formattedDate = DateTime.Now.ToString("MM/dd/yyyy");   
            DateTime NgayTao = DateTime.Now.Date;
            string queryInsert = "INSERT INTO NHANVIEN (MaNV,TenNV, SDT, NgayVao) VALUES (@MaNV,@TenNV, @SDT, @NgayVao)";

           Connection.ExcuteNonQuery(queryInsert, new (string, object)[]
            {
            ("@MaNV", newMaNV),
            ("@TenNV", name),
            ("@SDT", phoneNumber),
            ("@NgayVao", NgayTao)
            });
            this.Close();
            userManager.LoadNhanVienData();
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
