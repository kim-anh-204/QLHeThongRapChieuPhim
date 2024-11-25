using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyRapChieuPhim.RegisterAndLogin
{
    public partial class RegisterForm : Form
    {
        public delegate void Form_Changed();
        public event Form_Changed SwapToLoginForm;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            SwapToLoginForm?.Invoke();
        }

        private void RegisterForm_Activated(object sender, EventArgs e)
        {
            textBoxTenDangNhap.Clear();
            textBoxMatKhau.Clear();
            textBoxMatKhau2.Clear();
        }

        private void buttonDangKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện các textbox và kết nối với cơ sở dữ liệu
            string username = textBoxTenDangNhap.Text;
            if (username == "")
            {
                MessageBox.Show("Trường tên đăng nhập không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTenDangNhap.Focus();
                return;
            }
            if (Regex.IsMatch(username, RegexPatternHelper.UsernamePattern) == false)
            {
                MessageBox.Show("Tên đăng nhập phải bắt đầu bằng chữ cái và có tối thiểu 8 ký tự, không có khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = textBoxMatKhau.Text;
            string confirmPassword = textBoxMatKhau2.Text;
            if (password == "")
            {
                MessageBox.Show("Trường mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMatKhau.Focus();
                return;
            }
            if (confirmPassword == "")
            {
                MessageBox.Show("Trường nhập lại mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMatKhau2.Focus();
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Regex.IsMatch(password, RegexPatternHelper.PasswordPattern) == false)
            {
                MessageBox.Show("Mật khẩu phải có tối thiểu 8 ký tự, không có khoảng trắng, không chứa ký tự đặc biệt và có ít nhất 1 chữ cái và 1 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = textBoxName.Text.Trim();
            if (name.Length == 0 || name.Length > 150)
            {
                MessageBox.Show("Tên không được bỏ trống hoặc quá dài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string phoneNumber = textBoxSDT.Text.Trim();
            if (phoneNumber.Length == 0 || phoneNumber.Length > 20)
            {
                MessageBox.Show("Số điện thoại không được bỏ trống hoặc quá dài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(phoneNumber, out _) == false)
            {
                MessageBox.Show("Số điện thoại chỉ có thể là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePickerBorn.Value > DateTime.Today)
            {
                MessageBox.Show("Tuổi không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("Không được bỏ trống giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string checkQuery = "SELECT COUNT(*) FROM NGUOIDUNG WHERE TenDangNhap = @TenDangNhap";
            int log_count = Connection.ExecuteScalarInt32(checkQuery, new (string, object)[] { ("@TenDangNhap", username) });
            if (log_count > 0)
            {
                MessageBox.Show("Tên người dùng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string getIdQuery = "SELECT MAX(MaNguoiDung) FROM NGUOIDUNG";
            string userId = (string)Connection.ExecuteScalar(getIdQuery, null);
            userId = Helper.GenerateNextId(userId, "U", 3);
            password = SecurityHelper.HashPassword(password);
            string insertQuery = "INSERT INTO NGUOIDUNG VALUES (@MaNguoiDung, @TenNguoiDung, @Matkhau, @LoaiNguoiDung)";
            bool is_success = Connection.ExcuteNonQuery(insertQuery,
                                                        new (string, object)[] {
                                                            ("@MaNguoiDung", userId),
                                                            ("@TenNguoiDung", username),
                                                            ("@Matkhau", password),
                                                            ("@LoaiNguoiDung", "User"),
                                                        });

            insertQuery = "INSERT INTO KHACHHANG (HoVaTen, GioiTinh, NgaySinh, SoDienThoai, TenDangNhap, TrangThai) VALUES (@HoVaTen, @GioiTinh, @NgaySinh, @SoDienThoai, @TenDangNhap, @TrangThai)";
            Connection.ExcuteNonQuery(insertQuery, new (string, object)[]
            {
                ("@HoVaTen", name),
                ("@GioiTinh", comboBoxGender.SelectedIndex),
                ("@NgaySinh", datePickerBorn.Value),
                ("@SoDienThoai", textBoxSDT.Text.Trim()),
                ("@TenDangNhap", username),
                ("@TrangThai", "CHUAXOA"),
            });

            if (is_success == false)
                return;
            //Sau khi đăng ký thành công sẽ chuyển về màn hình đăng nhập.
            SystemSounds.Beep.Play();
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SwapToLoginForm?.Invoke();
        }
    }
}
