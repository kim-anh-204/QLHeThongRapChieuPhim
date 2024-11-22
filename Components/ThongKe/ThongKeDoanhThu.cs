using QuanLyRapChieuPhim.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.ThongKe
{
	internal class ThongKeDoanhThu
	{
        public DataTable LichSuDatVe()
        {
            string query = @"
            SELECT 
                MaSuatChieu AS [Mã Suất Chiếu],
                MaNV AS [Mã Nhân Viên],
                STRING_AGG(TenGhe, ', ') AS [Danh Sách Ghế],
                FORMAT(ThoigianDatve, 'dd-MM-yyyy HH:mm:ss') AS [Thời Gian Đặt Vé]
            FROM 
                VEXEMPHIM
            GROUP BY 
                MaSuatChieu, MaNV, FORMAT(ThoigianDatve,'dd-MM-yyyy HH:mm:ss')
            ORDER BY 
                FORMAT(ThoigianDatve, 'dd-MM-yyyy HH:mm:ss') DESC;
            ";
            return Connection.GetDataTable(query);
        }
		public DataTable DoanhThuTheoPhim()
		{
			string query = @"WITH SoVeBanDuoc as(
	            select MaSuatChieu, COUNT(MaVe) as SoVe
	            from VEXEMPHIM
	            group by MaSuatChieu
	            )
            SELECT p.MaPhim,p.TenPhim, ISNULL(SUM(svbd.SoVe*sc.GiaVe),0) AS [Doanh Thu]
            FROM SUATCHIEU sc
            JOIN SoVeBanDuoc svbd ON svbd.MaSuatChieu = sc.MaSuatchieu
            RIGHT JOIN PHIM p on sc.MaPhim = p.MaPhim
            GROUP BY p.MaPhim, p.TenPhim";
			return Connection.GetDataTable(query);
		}

		public DataTable GetDoanhThuHomNay()
		{
			string query = @"
    WITH SoVeBanDuoc AS (
        SELECT MaSuatChieu, COUNT(MaVe) AS SoVe
        FROM VEXEMPHIM
        GROUP BY MaSuatChieu
    )
    SELECT 
        p.MaPhim AS [Mã phim],
        p.TenPhim AS [Tên phim],
        CAST(GETDATE() AS DATE) AS [Thời gian],
        svbd.SoVe AS [Số vé],
        ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu]
    FROM SUATCHIEU sc
    JOIN SoVeBanDuoc svbd ON sc.MaSuatchieu = svbd.MaSuatChieu
    RIGHT JOIN PHIM p ON sc.MaPhim = p.MaPhim
    WHERE CAST(sc.Ngaychieu AS DATE) = CAST(GETDATE() AS DATE)
    GROUP BY p.MaPhim, p.TenPhim, svbd.SoVe
    ";

			return Connection.GetDataTable(query);  // Sử dụng phương thức GetDataTable từ class Connection
		}

		public DataTable GetDoanhThuTheoTuan()
		{
			string query = @"
   -- Đảm bảo tuần bắt đầu từ thứ Hai
    SET DATEFIRST 1;
    DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
    DECLARE @startOfWeek DATE = DATEADD(DAY, 1 - DATEPART(WEEKDAY, @today), @today); 
    -- Ngày bắt đầu tuần (thứ Hai của tuần hiện tại)

    -- Tạo bảng tạm để lưu số vé bán được
    WITH SoVeBanDuoc AS (
        SELECT 
            MaSuatChieu, 
            COUNT(MaVe) AS SoVe
        FROM VEXEMPHIM
        GROUP BY MaSuatChieu
    )

    -- Lấy doanh thu theo từng ngày đã qua trong tuần
    SELECT 
        DATENAME(WEEKDAY, DATEADD(DAY, Days.offset, @startOfWeek)) AS [Thứ], -- Lấy tên thứ trong tuần
        CAST(DATEADD(DAY, Days.offset, @startOfWeek) AS DATE) AS [Thời gian], -- Ngày cụ thể trong tuần
        ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Hiển thị 0 nếu không có doanh thu
    FROM 
        (SELECT 0 AS offset UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 
         UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6) AS Days
    LEFT JOIN SUATCHIEU sc ON CAST(sc.NgayChieu AS DATE) = DATEADD(DAY, Days.offset, @startOfWeek)
    LEFT JOIN SoVeBanDuoc svbd ON sc.MaSuatChieu = svbd.MaSuatChieu
    LEFT JOIN PHIM p ON sc.MaPhim = p.MaPhim
    WHERE DATEADD(DAY, Days.offset, @startOfWeek) <= @today -- Chỉ lấy đến ngày hiện tại
    GROUP BY 
        Days.offset, DATEADD(DAY, Days.offset, @startOfWeek) 
    ORDER BY Days.offset;
    ";
			return Connection.GetDataTable(query);
		}

		public DataTable GetDoanhThuTheoThang()
		{
			string query = @"DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
            DECLARE @startOfMonth DATE = DATEADD(DAY, 1 - DAY(@today), @today); 
            -- Ngày đầu tiên của tháng hiện tại

            -- Tạo bảng tạm để lưu số vé bán được
            WITH SoVeBanDuoc AS (
                SELECT 
                    MaSuatChieu, 
                    COUNT(MaVe) AS SoVe
                FROM VEXEMPHIM
                GROUP BY MaSuatChieu
            )

            -- Lấy doanh thu theo từng ngày trong tháng đã qua
            SELECT 
                CAST(DATEADD(DAY, Days.offset, @startOfMonth) AS DATE) AS [Ngày], -- Ngày cụ thể trong tháng
                ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Hiển thị 0 nếu không có doanh thu
            FROM 
                (SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS offset 
                 FROM master.dbo.spt_values) AS Days
                -- Dãy offset từ 0 đến số ngày trong tháng hiện tại
            LEFT JOIN SUATCHIEU sc ON CAST(sc.NgayChieu AS DATE) = DATEADD(DAY, Days.offset, @startOfMonth)
            LEFT JOIN SoVeBanDuoc svbd ON sc.MaSuatChieu = svbd.MaSuatChieu
            LEFT JOIN PHIM p ON sc.MaPhim = p.MaPhim
           WHERE DATEADD(DAY, Days.offset, @startOfMonth) <= EOMONTH(@today)  -- Lọc đến ngày cuối cùng của tháng
            GROUP BY 
                Days.offset, DATEADD(DAY, Days.offset, @startOfMonth) -- Đảm bảo nhóm theo ngày
            ORDER BY 
                Days.offset;";
			return Connection.GetDataTable(query);
		}
		public DataTable GetDoanhThuTheoNam()
		{
			string query = @"DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
    DECLARE @startOfYear DATE = DATEADD(YEAR, DATEDIFF(YEAR, 0, @today), 0); -- Ngày đầu tiên của năm hiện tại

    -- Tạo bảng tạm để lưu số vé bán được
    WITH SoVeBanDuoc AS (
        SELECT 
            MaSuatChieu, 
            COUNT(MaVe) AS SoVe
        FROM VEXEMPHIM
        GROUP BY MaSuatChieu
    ),

    -- Tạo danh sách các tháng từ 0 đến 11, tương ứng với các tháng từ tháng 1 đến tháng 12
    Months AS (
        SELECT 0 AS offset
        UNION ALL SELECT 1
        UNION ALL SELECT 2
        UNION ALL SELECT 3
        UNION ALL SELECT 4
        UNION ALL SELECT 5
        UNION ALL SELECT 6
        UNION ALL SELECT 7
        UNION ALL SELECT 8
        UNION ALL SELECT 9
        UNION ALL SELECT 10
        UNION ALL SELECT 11
    )

    -- Lấy doanh thu theo từng tháng trong năm
    SELECT 
        MONTH(DATEADD(MONTH, Months.offset, @startOfYear)) AS [Tháng], -- Số tháng trong năm
        ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Hiển thị 0 nếu không có doanh thu
    FROM 
        Months
    LEFT JOIN SUATCHIEU sc ON DATEPART(MONTH, sc.NgayChieu) = MONTH(DATEADD(MONTH, Months.offset, @startOfYear))
        AND DATEPART(YEAR, sc.NgayChieu) = DATEPART(YEAR, @today)
    LEFT JOIN SoVeBanDuoc svbd ON sc.MaSuatChieu = svbd.MaSuatChieu
    GROUP BY 
        Months.offset
    ORDER BY 
        Months.offset;";
			return Connection.GetDataTable(query);
		}
	}
}
