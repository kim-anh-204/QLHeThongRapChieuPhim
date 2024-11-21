using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.InfoManager
{
    public partial class InfoManagerForm : Form
    {
        public delegate void CancelEvent();
        public CancelEvent OnCancelClick;
        public InfoManagerForm()
        {
            InitializeComponent();
        }

        private void InfoManagerForm_Shown(object sender, EventArgs e)
        {
            string checkQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE TenDangNhap = @TenDangNhap";
            int logCount = Connection.ExecuteScalarInt32(checkQuery, new (string, object)[]
            {
                ("@TenDangNhap", SharedData.GetValue("TenDangNhap"))
            });
            if (logCount == 0)
            {
                string insertQuery = "INSERT INTO KHACHHANG (TenDangNhap) VALUES (@TenDangNhap)";
                Connection.ExcuteNonQuery(insertQuery, new (string, object)[]
                {
                    ("@TenDangNhap", SharedData.GetValue("TenDangNhap"))
                });
            }
            string query = "SELECT * FROM KHACHHANG WHERE TenDangNhap = @TenDangNhap";
            DataRow dr = Connection.GetDataTable(query, new (string, object)[]
            {
                ("@TenDangNhap", SharedData.GetValue("TenDangNhap"))
            }).Rows[0];

            if (dr[1] != DBNull.Value)
                textBoxName.Text = (string)dr[1];
            if (dr[2] != DBNull.Value)
                comboBoxGender.SelectedIndex = Convert.ToInt32(dr[2]);
            if (dr[3] != DBNull.Value)
                datePickerBorn.Value = (DateTime)dr[3];
            if (dr[4] != DBNull.Value)
                textBoxSDT.Text = (string)dr[4];
            if (dr[5] != DBNull.Value)
                textBoxEmail.Text = (string)dr[5];
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // VALIDATE
            string name = textBoxName.Text.Trim();
            if (name.Length == 0 || name.Length > 150)
            {
                MessageBox.Show("Tên không được bỏ trống hoặc quá dài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show("Không được bỏ trống giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (datePickerBorn.Value > DateTime.Today)
            {
                MessageBox.Show("Tuổi không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string email = textBoxEmail.Text.Trim();
            if (email.Length > 0 && Regex.IsMatch(email, RegexPatternHelper.EmailPattern) == false)
            {
                MessageBox.Show("Email không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string updateQuery = "UPDATE KHACHHANG SET HoVaTen = @HoVaTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SoDienThoai = @SoDienThoai, Email = @Email WHERE TenDangNhap = @TenDangNhap";
            bool result = Connection.ExcuteNonQuery(updateQuery, new (string, object)[]
            {
                ("@HoVaTen", name),
                ("GioiTinh", comboBoxGender.SelectedIndex),
                ("@NgaySinh", datePickerBorn.Value),
                ("@SoDienThoai",  phoneNumber),
                ("@Email",  email),
                ("@TenDangNhap", SharedData.GetValue("TenDangNhap")),
            });

            if (checkBoxPassword.Checked)
            {
                string oldPassword = textBoxOldPassword.Text.Trim();
                if (oldPassword.Length == 0 || oldPassword.Length > 150)
                {
                    MessageBox.Show("Mật khẩu cũ không được bỏ trống hoặc quá dài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string newPassword = textBoxPassword.Text.Trim();
                string newPassword2 = textBoxPassword2.Text.Trim();
                if (newPassword.Length == 0 || newPassword.Length > 150)
                {
                    MessageBox.Show("Mật khẩu mới không được bỏ trống hoặc quá dài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (newPassword != newPassword2)
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Regex.IsMatch(newPassword, RegexPatternHelper.PasswordPattern) == false)
                {
                    MessageBox.Show("Mật khẩu mới phải có tối thiểu 8 ký tự, không có khoảng trắng và có ít nhất 1 chữ cái và 1 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedOldPassword = SecurityHelper.HashPassword(oldPassword);
                string checkPasswordQuery = "SELECT COUNT(*) FROM NGUOIDUNG WHERE TenDangNhap = @TenDangNhap AND Matkhau = @MatKhau";
                int log_count = Connection.ExecuteScalarInt32(checkPasswordQuery, new (string, object)[]
                {
                    ("@TenDangNhap", SharedData.GetValue("TenDangNhap")),
                    ("@MatKhau", hashedOldPassword),
                });
                if (log_count == 0)
                {
                    MessageBox.Show("Mật khẩu cũ sai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string hashedNewPassword = SecurityHelper.HashPassword(newPassword);
                string updatePasswordQuery = "UPDATE NGUOIDUNG SET Matkhau = @MatKhau WHERE TenDangNhap = @TenDangNhap";
                result &= Connection.ExcuteNonQuery(updatePasswordQuery, new (string, object)[]
                {
                    ("@MatKhau", hashedNewPassword),
                    ("@TenDangNhap", SharedData.GetValue("TenDangNhap")),
                });
            }


            if (result)
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            OnCancelClick?.Invoke();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            char result = checkBoxShowPassword.Checked ? '\0' : '●';
            textBoxOldPassword.PasswordChar = result;
            textBoxPassword.PasswordChar = result;
            textBoxPassword2.PasswordChar= result;
        }
    }
}
