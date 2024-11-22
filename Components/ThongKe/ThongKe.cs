using System;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;

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
			dtgvLichsuDatve.DataSource = thongKeDoanhThu.LichSuDatVe();
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
			BindDataToGrid(temp);
			if (temp != null && temp.Rows.Count > 0)
			{
				var totalRevenue = temp.Compute("SUM([Doanh Thu])", string.Empty);
				// Update the label with the total revenue value
				labelDtHomnay.Text = $"Doanh thu hôm nay: {totalRevenue:N0} VNĐ";
				labelTien.Text = $"{totalRevenue:N0} VNĐ";
			}
			else
			{
				labelDtHomnay.Text = "Doanh thu hôm nay: 0 VNĐ";
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
				BindDataToGrid(dtTable);
				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					var totalRevenue = dtTable.Compute("SUM([Doanh Thu])", string.Empty);

					// Update the label with the total revenue value
					labelDtHomnay.Text = $"Doanh thu hôm nay: {totalRevenue:N0} VNĐ";
					UpdateLabel("ngày");
				}
				else
				{
					labelDtHomnay.Text = "Doanh thu hôm nay: 0 VNĐ";
					MessageBox.Show("Chưa có doanh thu cho ngày hôm nay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
				BindDataToGrid(dtTable);
				if (dtTable != null && dtTable.Rows.Count > 0)
				{
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
				BindDataToGrid(dtTable);
				if (dtTable != null && dtTable.Rows.Count > 0)
				{
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
				BindDataToGrid(dtTable);
				if (dtTable != null && dtTable.Rows.Count > 0)
				{
					UpdateLabel("năm");
				}
				else
				{
					MessageBox.Show("Không có doanh thu cho năm này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void buttonBaocao_Click(object sender, EventArgs e)
		{
			// Chọn nơi lưu file qua SaveFileDialog
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
			saveFileDialog.FileName = "BaoCaoDoanhThu.xlsx";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = saveFileDialog.FileName;

				ExportToExcel(thongKeDoanhThu, filePath);

				MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void ExportToExcel(ThongKeDoanhThu thongKe, string filePath)
		{
			using (XLWorkbook workbook = new XLWorkbook()) // Tạo một workbook (sổ làm việc) mới
			{
				// Sheet 1: Tổng quan doanh thu theo phim
				var dtTongQuan = thongKe.DoanhThuTheoPhim();
				var sheetTheoPhim = workbook.Worksheets.Add(dtTongQuan, "Doanh thu theo phim");
				sheetTheoPhim.Row(1).InsertRowsAbove(1);

				// Tính tổng doanh thu theo phim
				var tongDTphim = dtTongQuan.Compute("SUM([Doanh Thu])", string.Empty);
				sheetTheoPhim.Cell(1, 1).Value = "Tổng Doanh Thu";
				sheetTheoPhim.Cell(1, 2).Value = string.Format("{0:N0} VNĐ", tongDTphim);

				// Sheet 2: Doanh thu hôm nay
				var dtTheoNgay = thongKe.GetDoanhThuHomNay();
				var sheetTheoNgay = workbook.Worksheets.Add(dtTheoNgay, "Doanh thu hôm nay");
				sheetTheoNgay.Row(1).InsertRowsAbove(1);

				// Tính tổng doanh thu hôm nay
				var tongDTNgay = dtTheoNgay.Compute("SUM([Doanh Thu])", string.Empty);				
				sheetTheoNgay.Cell(1, 1).Value = "Tổng Doanh Thu";
				sheetTheoNgay.Cell(1, 2).Value = string.Format("{0:N0} VNĐ", tongDTNgay);

				// Sheet 3: Doanh thu theo tuần
				var dtTheoTuan = thongKe.GetDoanhThuTheoTuan();
				var sheetTheoTuan = workbook.Worksheets.Add(dtTheoTuan, "Doanh thu theo tuần");
				sheetTheoTuan.Row(1).InsertRowsAbove(1);

				// Tính tổng doanh thu theo tuần
				var tongDTTuan = dtTheoTuan.Compute("SUM([Doanh Thu])", string.Empty);
				sheetTheoTuan.Cell(1, 1).Value = "Tổng Doanh Thu";
				sheetTheoTuan.Cell(1, 2).Value = string.Format("{0:N0} VNĐ", tongDTTuan);


				// Sheet 4: Doanh thu theo tháng
				var dtTheoThang = thongKe.GetDoanhThuTheoThang();
				var sheetTheoThang = workbook.Worksheets.Add(dtTheoThang, "Doanh thu theo tháng");
				sheetTheoThang.Row(1).InsertRowsAbove(1);

				// Tính tổng doanh thu theo tháng
				var tongDTThang = dtTheoThang.Compute("SUM([Doanh Thu])", string.Empty);
				sheetTheoThang.Cell(1, 1).Value = "Tổng Doanh Thu";
				sheetTheoThang.Cell(1, 2).Value = string.Format("{0:N0} VNĐ", tongDTThang);

				// Sheet 5: Doanh thu theo năm
				var dtTheoNam = thongKe.GetDoanhThuTheoNam();
				var sheetTheoNam = workbook.Worksheets.Add(dtTheoNam, "Doanh thu theo năm");
				sheetTheoNam.Row(1).InsertRowsAbove(1);

				// Tính tổng doanh thu theo năm
				var tongDTNam = dtTheoNam.Compute("SUM([Doanh Thu])", string.Empty);
				sheetTheoNam.Cell(1, 1).Value = "Tổng Doanh Thu";
				sheetTheoNam.Cell(1, 2).Value = string.Format("{0:N0} VNĐ", tongDTNam);
				// Lưu file
				workbook.SaveAs(filePath);
			}
		}
	}
}
