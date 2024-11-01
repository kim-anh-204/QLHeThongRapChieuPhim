using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.QLPhongChieu
{
    public partial class AddScreeningRoom : Form
    {
        private ScreeningRoomManagement qLPC;
        public AddScreeningRoom(ScreeningRoomManagement qLPC)
        {
            InitializeComponent();

            this.qLPC = qLPC; // Lưu tham chiếu
        }

        private void AddScreeningForm_Load(object sender, EventArgs e)
        {

        }

        private void getRoom()
        {
            string query = "SELECT TenPhong FROM PHONGCHIEUPHIM";
            DataTable roomData = Connection.GetDataTable(query);

            if (roomData != null && roomData.Rows.Count > 0)
            {
                foreach (DataRow row in roomData.Rows)
                {
                    comboBoxRoomStatus.Items.Add(row["TenPhong"].ToString());
                }
            }

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private string GenerateNewRoomID()
        {
            string prefix = "PXP-"; // Đặt cố định prefix
            string queryID = "SELECT TOP 1 MaPhong FROM PhongChieuPhim WHERE MaPhong LIKE 'PXP-%' ORDER BY MaPhong DESC;";
            DataTable result = Connection.GetDataTable(queryID);

            // Nếu không có mã phòng nào tồn tại, bắt đầu với mã "PXP-1"
            if (result.Rows.Count == 0)
            {
                return prefix + "1";
            }

            // Lấy mã phòng cuối cùng từ kết quả truy vấn
            string maPC = result.Rows[0]["MaPhong"].ToString(); // e.g., PXP-3

            // Kiểm tra xem mã phòng có đúng định dạng "PXP-###" hay không
            if (maPC.StartsWith(prefix))
            {
                // Lấy phần số từ mã phòng, ví dụ: '3' từ 'PXP-3'
                string numberPart = maPC.Substring(prefix.Length);

                // Cố gắng chuyển đổi phần số thành số nguyên
                if (int.TryParse(numberPart, out int number))
                {
                    // Tăng giá trị của số
                    number += 1;

                    // Trả về mã phòng mới: ví dụ 'PXP-4'
                    return prefix + number.ToString();
                }
                else
                {
                    // Nếu phần số không phải là số hợp lệ, ném ra ngoại lệ
                    throw new Exception("Invalid MaPhong number format");
                }
            }
            else
            {
                // Nếu mã không bắt đầu bằng "PXP-", ném ra ngoại lệ
                throw new Exception("Invalid MaPhong format");
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {

            // Kiểm tra dữ liệu nhập
            if (bunifuTextBox2.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBoxRoomStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần chọn trạng thái cho phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem phòng chiếu đã tồn tại hay chưa
            string TenPhong = bunifuTextBox2.Text;
            string queryCheck = "SELECT COUNT(*) FROM PhongChieuPhim WHERE TenPhong = @TenPhong";
            DataTable result = Connection.GetDataTable(queryCheck, new (string, object)[] { ("@TenPhong", TenPhong) });

            if (result != null && result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0)
            {
                MessageBox.Show("Tên phòng chiếu đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm phòng vào cơ sở dữ liệu
            string newMaPC = GenerateNewRoomID();
            //string TenPhong = bunifuTextBox2.Text;
            string queryInsert = "INSERT INTO PhongChieuPhim (MaPhong, TenPhong, TrangthaiPhongchieu) VALUES ( @MaPhong, @TenPhong,  @TrangthaiPhongchieu)";
            string selectedStatus = comboBoxRoomStatus.SelectedItem.ToString();
            int roomStatus = (selectedStatus == "Đang hoạt động") ? 1 : 0;

            Connection.ExcuteNonQuery(queryInsert, new (string, object)[]
            {
        ("@MaPhong", newMaPC),
        ("@TenPhong", TenPhong),
        ("@TrangthaiPhongchieu", roomStatus)
            });

            MessageBox.Show("Thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Thiết lập DialogResult
            this.Close(); // Đóng form
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
