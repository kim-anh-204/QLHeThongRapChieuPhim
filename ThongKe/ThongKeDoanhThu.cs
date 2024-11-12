using QuanLyRapChieuPhim.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.ThongKe
{
	internal class ThongKeDoanhThu
	{
		// Phương thức gọi Stored Procedure và trả về DataTable
		public DataTable DoanhThuTheoPhim()
		{
			return Connection.GetDataTable("sp_DoanhThuTheoPhim");
		}

		public DataTable DoanhThuHomNay()
		{
			return Connection.GetDataTable("sp_DoanhThuHomNay");
		}

		public DataTable DoanhThuTheoTuan()
		{
			return Connection.GetDataTable("sp_DoanhThuTheoTuan");
		}
		public DataTable DoanhThuTheoThang()
		{
			return Connection.GetDataTable("sp_DoanhThuTheoThang");
		}
		public DataTable DoanhThuTheoNam()
		{
			return Connection.GetDataTable("sp_DoanhThuTheoNam");
		}
	}
}
