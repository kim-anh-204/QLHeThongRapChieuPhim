using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
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
            string queryID = "SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY MaNV DESC;";
            DataTable result = Connection.GetDataTable(queryID);
            string maNV = result.Rows[0]["MaNV"].ToString();
           
            string prefix = maNV.Substring(0, 1);
            string numberPart = maNV.Substring(1); 
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
            string newMaNV = prefix + newNumberPart;
            string name = NameBtn.Text.Trim();
            string phoneNumber = SdtBtn.Text.Trim();  
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

        private void Add_Load(object sender, EventArgs e)
        {

        }


    }
}
