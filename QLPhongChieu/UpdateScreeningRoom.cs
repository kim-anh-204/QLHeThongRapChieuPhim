using QuanLyRapChieuPhim.ScreeningPage;
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

namespace QuanLyRapChieuPhim.QLPhongChieu
{
    public partial class UpdateScreeningRoom : Form
    {
        private ScreeningRoomManagement qLPC;
        private string maPhong, tenPhong;
        private string trangThaiPhong;
        public UpdateScreeningRoom()
        {
            InitializeComponent();
        }

        public UpdateScreeningRoom(ScreeningRoomManagement qLPC, string maPhong, string tenPhong, string trangThaiPhong)
        {
            InitializeComponent();
            this.qLPC = qLPC;
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.trangThaiPhong = trangThaiPhong;

            bunifuTextBox2.Text = tenPhong;
        }
        private void Sua_Load(object sender, EventArgs e)
        {
            // Thêm các item vào ComboBox nếu chưa có
            comboBoxRoomStatus.Items.Clear();
            comboBoxRoomStatus.Items.Add("Đang hoạt động");
            comboBoxRoomStatus.Items.Add("Không hoạt động");

            if (trangThaiPhong == "Đang hoạt động") // có thể cần kiểm tra lại nếu trangThaiPhong là bool
            {
                comboBoxRoomStatus.SelectedItem = "Đang hoạt động";
            }
            else if (trangThaiPhong == "Không hoạt động")
            {
                comboBoxRoomStatus.SelectedItem = "Không hoạt động";
            }


            //// Kiểm tra xem ComboBox đã có giá trị chính xác chưa
            //MessageBox.Show("ComboBox hiện tại: " + comboBoxRoomStatus.SelectedItem?.ToString());

            // Truy vấn để lấy mã phòng từ cơ sở dữ liệu dựa trên tên phòng
            string query = "SELECT MaPhong FROM PhongChieuPhim WHERE TenPhong = @TenPhong";
            object result = Connection.ExecuteScalar(query, new (string, object)[]
            {
                ("@TenPhong", tenPhong) // Sử dụng tenPhong để truy vấn
            });

            if (result != null)
            {
                maPhong = result.ToString(); // Lấy mã phòng từ kết quả truy vấn
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã phòng cho tên phòng này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void bunifuTextBox2_TextChanged_1(object sender, EventArgs e)
        {


        }

        private void bunifuButton22_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            // Lấy tên phòng mới
            string tenPhongMoi = bunifuTextBox2.Text.Trim();

            // Kiểm tra nếu người dùng không nhập tên phòng
            if (string.IsNullOrWhiteSpace(tenPhongMoi))
            {
                MessageBox.Show("Bạn cần nhập tên phòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Kiểm tra xem tên phòng mới đã tồn tại trong CSDL hay chưa
            string checkQuery = "SELECT COUNT(*) FROM PhongChieuPhim WHERE TenPhong = @TenPhong AND MaPhong <> @MaPhong";
            int count = Convert.ToInt32(Connection.ExecuteScalar(checkQuery, new (string, object)[]
            {
        ("@TenPhong", tenPhongMoi), // Kiểm tra tên phòng mới
        ("@MaPhong", maPhong) // Đảm bảo không kiểm tra phòng hiện tại
            }));

            if (count > 0)
            {
                MessageBox.Show("Tên phòng này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng thực hiện nếu tên phòng đã tồn tại
            }
            // Nếu người dùng không thay đổi trạng thái, giữ nguyên trạng thái phòng cũ
            int roomStatus;
            if (comboBoxRoomStatus.SelectedItem != null)
            {
                // Người dùng có chọn trạng thái mới
                string selectedStatus = comboBoxRoomStatus.SelectedItem.ToString();
                roomStatus = selectedStatus == "Đang hoạt động" ? 1 : 0; // Chuyển đổi trạng thái thành số nguyên
            }

            else
            {
                // Người dùng không thay đổi, giữ trạng thái hiện tại
                roomStatus = trangThaiPhong == "Đang hoạt động" ? 1 : 0;
            }

            // Đảm bảo mã phòng hợp lệ
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Mã phòng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật thông tin phòng trong cơ sở dữ liệu
            string updateQuery = "UPDATE PhongChieuPhim SET TenPhong = @TenPhong, TrangthaiPhongchieu = @TrangthaiPhongchieu WHERE MaPhong = @MaPhong";
            Connection.ExcuteNonQuery(updateQuery, new (string, object)[]
            {
    ("@TenPhong", tenPhongMoi), // Cập nhật tên phòng
    ("@TrangthaiPhongchieu", roomStatus), // Cập nhật trạng thái phòng
    ("@MaPhong", maPhong) // Cập nhật theo mã phòng
			});

            MessageBox.Show("Cập nhật phòng chiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Thiết lập DialogResult
            qLPC.Visible();

            this.Close(); // Đóng form
        }

        private void comboBoxRoomStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
