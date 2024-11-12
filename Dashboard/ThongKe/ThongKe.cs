using System;
using System.Data;
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

		private DataTable LoadData()
		{
			dtTable = thongKeDoanhThu.DoanhThuTheoPhim();
			return dtTable;
		}

		private void BindDataToGrid(DataTable dtTable)
		{
			dtGridviewThongKe.AutoGenerateColumns = true;
			dtGridviewThongKe.DataSource = dtTable;
			dtgvDtTheoPhim.AutoGenerateColumns = true;
			dtgvDtTheoPhim.DataSource = thongKeDoanhThu.DoanhThuTheoPhim();
			// Thiết lập tiêu đề cột chỉ một lần
			//foreach (DataGridViewColumn column in dtGridviewThongKe.Columns)
			//{
			//	if (column.Name == "MaPhim")
			//	{
			//		column.HeaderText = "Mã Phim";
			//	}
			//	else if (column.Name == "TenPhim")
			//	{
			//		column.HeaderText = "Tên Phim";
			//	}
			//	else if (column.Name == "DoanhThu")
			//	{
			//		column.HeaderText = "Doanh Thu";
			//	}
			//}
		}

		private void ThongKe_Load(object sender, EventArgs e)
		{
			dtTable = LoadData();
			if (dtTable == null || dtTable.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu trong bảng chính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				BindDataToGrid(dtTable);
				UpdateLabel();
			}
		}

		private void UpdateLabel()
		{
			
		}

		private void LoadAndBindData(Func<DataTable> getDataFunction, string tableName)
		{
			dtTable = getDataFunction();
			if (dtTable == null || dtTable.Rows.Count == 0)
			{
				MessageBox.Show($"Không có dữ liệu trong bảng {tableName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				BindDataToGrid(dtTable);
				UpdateLabel();
			}
		}

		private void RBNgay_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			//LoadAndBindData(thongKeDoanhThu.DoanhThuHomNay, "DoanhThuHomNay");
		}

		private void RBTuan_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			//LoadAndBindData(thongKeDoanhThu.DoanhThuTheoTuan, "DoanhThuTheoTuan");
		}

		private void RBThang_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			//LoadAndBindData(thongKeDoanhThu.DoanhThuTheoThang, "DoanhThuTheoThang");
		}

		private void RBNam_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
		{
			//LoadAndBindData(thongKeDoanhThu.DoanhThuTheoNam, "DoanhThuTheoNam");
		}
	}
}
