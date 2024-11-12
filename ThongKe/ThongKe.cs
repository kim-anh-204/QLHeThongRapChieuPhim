using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.ThongKe
{
	public partial class ThongKe : Form
	{
		private DataTable dtTable;
		private ThongKeDoanhThu thongKeDoanhThu = new ThongKeDoanhThu();

		public ThongKe()
		{
			InitializeComponent();
		}

		private void BindDataToGrid(DataTable dtTable)
		{
			dtGridviewThongKe.AutoGenerateColumns = true;
			dtGridviewThongKe.DataSource = dtTable;
			dtgvDtTheoPhim.DataSource = thongKeDoanhThu.DoanhThuTheoPhim();
		}

		private void ThongKe_Load(object sender, EventArgs e)
		{
			// Khi form được load lần đầu, sẽ không có dữ liệu nào được hiển thị
			dtTable = new DataTable();
			BindDataToGrid(dtTable);

			DataTable dt = thongKeDoanhThu.GetDoanhThuTheoNam();
			decimal tongDoanhThuNam = 0;

			foreach (DataRow row in dt.Rows)
			{
				tongDoanhThuNam += Convert.ToDecimal(row["Doanh Thu"]);
			}
			labelTongDoanhthu.Text = $"{tongDoanhThuNam:N0} VNĐ";

			DataTable temp = new DataTable();
			temp = thongKeDoanhThu.GetDoanhThuHomNay();

			if (temp != null && temp.Rows.Count > 0)
			{
				BindDataToGrid(temp);
				var totalRevenue = temp.Compute("SUM([Doanh Thu])", string.Empty);

				// Update the label with the total revenue value
				labelDtHomnay.Text = $"Doanh thu hôm nay: {totalRevenue:N0} VNĐ";
			}
			else
			{
				labelDtHomnay.Text = "Doanh thu hôm nay: 0 VNĐ";
				MessageBox.Show("Không có doanh thu cho ngày hôm nay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void UpdateLabel(string txt)
		{
			if (dtTable != null && dtTable.Rows.Count > 0)
			{
				var totalRevenue = dtTable.Compute("SUM([Doanh Thu])", string.Empty);

				// Update the label with the total revenue value
				lbDoanhthu.Text = $"Doanh thu {txt}";
				labelTien.Text = $"{totalRevenue:N0} VNĐ";
			}
			else
			{
				lbDoanhthu.Text = $"Doanh thu {txt} VNĐ";
				labelTien.Text = $"{0}";
			}
			
		}

		private void RBNgay_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			// Kiểm tra chỉ xử lý khi radio button được chọn
			if (e.Checked)
			{
				dtGridviewThongKe.DataSource = null;  // Xóa dữ liệu cũ
				dtTable = thongKeDoanhThu.GetDoanhThuHomNay();

				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					BindDataToGrid(dtTable);
					var totalRevenue = dtTable.Compute("SUM([Doanh Thu])", string.Empty);

					// Update the label with the total revenue value
					labelDtHomnay.Text = $"Doanh thu hôm nay: {totalRevenue:N0} VNĐ";
					UpdateLabel("ngày");
				}
				else
				{
					labelDtHomnay.Text = "Doanh thu hôm nay: 0";
					MessageBox.Show("Không có doanh thu cho ngày hôm nay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void RBTuan_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			// Kiểm tra chỉ xử lý khi radio button được chọn
			if (e.Checked)
			{
				dtGridviewThongKe.DataSource = null;  // Xóa dữ liệu cũ
				dtTable = thongKeDoanhThu.GetDoanhThuTheoTuan();

				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					BindDataToGrid(dtTable);
					UpdateLabel("tuần");
				}
				else
				{
					MessageBox.Show("Không có doanh thu cho tuần này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void RBThang_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			if (e.Checked)
			{
				dtGridviewThongKe.DataSource = null;  // Xóa dữ liệu cũ
				dtTable = thongKeDoanhThu.GetDoanhThuTheoThang();

				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					BindDataToGrid(dtTable);
					UpdateLabel("tháng");
				}
				else
				{
					MessageBox.Show("Không có doanh thu cho tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void RBNam_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			if (e.Checked)
			{
				dtGridviewThongKe.DataSource = null;  // Xóa dữ liệu cũ
				dtTable = thongKeDoanhThu.GetDoanhThuTheoNam();

				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					BindDataToGrid(dtTable);
					UpdateLabel("năm");
				}
				else
				{
					MessageBox.Show("Không có doanh thu cho năm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
	}
}
