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
                vxp.MaSuatChieu AS [Mã Suất Chiếu],
                MaNV AS [Mã Nhân Viên],
	            p.TenPhim as [Tên phim],
                STRING_AGG(TenGhe, ', ') AS [Danh Sách Ghế],
                FORMAT(ThoigianDatve, 'dd-MM-yyyy HH:mm:ss') AS [Thời Gian Đặt Vé]
            FROM 
                SUATCHIEU sc 
	            inner join PHIM p on p.MaPhim = sc.MaPhim
	            inner join VEXEMPHIM vxp on vxp.MaSuatChieu = sc.MaSuatchieu
            GROUP BY 
                vxp.MaSuatChieu, MaNV,p.TenPhim, FORMAT(ThoigianDatve,'dd-MM-yyyy HH:mm:ss')
            ORDER BY 
                FORMAT(ThoigianDatve, 'dd-MM-yyyy HH:mm:ss') DESC
            ";
            return Connection.GetDataTable(query);
        }
		public DataTable DoanhThuTheoPhim()
		{
			string query = @"WITH SoVeBanDuoc as(
	            select MaSuatChieu , COUNT(MaVe) as SoVe
	            from VEXEMPHIM
	            group by MaSuatChieu
	            )
            SELECT 
                    p.MaPhim as [Mã phim],
                    p.TenPhim as [Tên phim], 
                    ISNULL(SUM(svbd.SoVe*sc.GiaVe),0) AS [Doanh Thu]
            FROM SUATCHIEU sc
            JOIN SoVeBanDuoc svbd ON svbd.MaSuatChieu = sc.MaSuatchieu
            RIGHT JOIN PHIM p on sc.MaPhim = p.MaPhim
            GROUP BY p.MaPhim, p.TenPhim";
			return Connection.GetDataTable(query);
		}
		//WHERE CAST(ThoigianDatve AS DATE) = CAST(GETDATE() AS DATE)
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
            CAST(sc.Ngaychieu AS DATE) AS [Suất chiếu],
            svbd.SoVe AS [Số vé],
            ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu]
        FROM SUATCHIEU sc
        JOIN SoVeBanDuoc svbd ON sc.MaSuatchieu = svbd.MaSuatChieu
        RIGHT JOIN PHIM p ON sc.MaPhim = p.MaPhim
        WHERE CAST(sc.Ngaychieu AS DATE) = CAST(GETDATE() AS DATE)
        GROUP BY p.MaPhim, p.TenPhim,sc.Ngaychieu, svbd.SoVe
    ";
			return Connection.GetDataTable(query);  
		}

		public DataTable GetDoanhThuTheoTuan()
		{
			string query = @"
            SET DATEFIRST 1;
            DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
            DECLARE @startOfWeek DATE = DATEADD(DAY, 1 - DATEPART(WEEKDAY, @today), @today); -- Ngày bắt đầu tuần (Thứ Hai)

            -- Tạo bảng tạm để lưu số vé bán được theo từng ngày chiếu
            WITH SoVeBanDuocTheoNgayChieu AS (
                SELECT 
                    sc.MaSuatChieu, 
                    CAST(sc.NgayChieu AS DATE) AS NgayChieu, -- Ngày chiếu
                    COUNT(MaVe) AS SoVe -- Tổng số vé của mỗi suất chiếu
                FROM VEXEMPHIM vx
                JOIN SUATCHIEU sc ON vx.MaSuatChieu = sc.MaSuatChieu -- Liên kết vé với suất chiếu
                GROUP BY sc.MaSuatChieu, CAST(sc.NgayChieu AS DATE) -- Nhóm theo ngày chiếu
            )

            -- Lấy doanh thu theo từng ngày chiếu trong tuần
            SELECT 
                DATENAME(WEEKDAY, DATEADD(DAY, Days.offset, @startOfWeek)) AS [Thứ], -- Tên thứ trong tuần
                CAST(DATEADD(DAY, Days.offset, @startOfWeek) AS DATE) AS [Thời gian], -- Ngày cụ thể
                ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Tính doanh thu từng ngày
            FROM 
                (SELECT 0 AS offset UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 
                 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6) AS Days
            LEFT JOIN SUATCHIEU sc 
                ON CAST(sc.NgayChieu AS DATE) = DATEADD(DAY, Days.offset, @startOfWeek) -- So khớp ngày chiếu
            LEFT JOIN SoVeBanDuocTheoNgayChieu svbd 
                ON sc.MaSuatChieu = svbd.MaSuatChieu 
                AND svbd.NgayChieu = DATEADD(DAY, Days.offset, @startOfWeek) -- So khớp ngày chiếu
            LEFT JOIN PHIM p 
                ON sc.MaPhim = p.MaPhim
            WHERE DATEADD(DAY, Days.offset, @startOfWeek) <= DATEADD(DAY, 6, @startOfWeek) -- Chỉ tính đến cuối tuần
            GROUP BY 
                Days.offset, DATEADD(DAY, Days.offset, @startOfWeek) 
            ORDER BY Days.offset;
            ";
			return Connection.GetDataTable(query);
		}

		public DataTable GetDoanhThuTheoThang()
		{
			string query = @"
        DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
        DECLARE @startOfMonth DATE = DATEADD(DAY, 1 - DAY(@today), @today); -- Ngày đầu tiên của tháng

        -- Tạo bảng tạm để lưu số vé bán được theo ngày chiếu
        WITH SoVeBanDuocTheoNgayChieu AS (
            SELECT 
                sc.MaSuatChieu, 
                CAST(sc.NgayChieu AS DATE) AS NgayChieu, -- Ngày chiếu
                COUNT(MaVe) AS SoVe -- Tổng số vé bán được cho từng ngày chiếu
            FROM VEXEMPHIM vx
            JOIN SUATCHIEU sc ON vx.MaSuatChieu = sc.MaSuatChieu -- Liên kết vé với suất chiếu
            GROUP BY sc.MaSuatChieu, CAST(sc.NgayChieu AS DATE)
        ),

        -- Tạo danh sách ngày trong tháng
        Days AS (
            SELECT TOP (DAY(EOMONTH(@today))) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS offset
            FROM master.dbo.spt_values
        )

        -- Lấy doanh thu theo từng ngày trong tháng
        SELECT 
            CAST(DATEADD(DAY, Days.offset, @startOfMonth) AS DATE) AS [Ngày], -- Ngày cụ thể
            ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Hiển thị 0 nếu không có doanh thu
        FROM 
            Days
        LEFT JOIN SUATCHIEU sc 
            ON CAST(sc.NgayChieu AS DATE) = DATEADD(DAY, Days.offset, @startOfMonth) -- So khớp ngày chiếu
        LEFT JOIN SoVeBanDuocTheoNgayChieu svbd 
            ON sc.MaSuatChieu = svbd.MaSuatChieu 
            AND svbd.NgayChieu = DATEADD(DAY, Days.offset, @startOfMonth) -- So khớp ngày chiếu
        LEFT JOIN PHIM p 
            ON sc.MaPhim = p.MaPhim
        WHERE DATEADD(DAY, Days.offset, @startOfMonth) <= EOMONTH(@today) -- Đảm bảo không vượt quá cuối tháng
        GROUP BY 
            Days.offset, DATEADD(DAY, Days.offset, @startOfMonth)
        ORDER BY 
            Days.offset;
    ";
			return Connection.GetDataTable(query);
		}

		public DataTable GetDoanhThuTheoNam()
		{
	    string query = @"
        DECLARE @today DATE = GETDATE(); -- Ngày hiện tại
        DECLARE @startOfYear DATE = DATEFROMPARTS(YEAR(@today), 1, 1); -- Ngày đầu năm hiện tại
        DECLARE @endOfYear DATE = DATEFROMPARTS(YEAR(@today), 12, 31); -- Ngày cuối năm hiện tại

        -- Tạo bảng tạm để lưu số vé bán được theo từng tháng
        WITH SoVeBanDuocTheoThangChieu AS (
            SELECT 
                sc.MaSuatChieu, 
                MONTH(sc.NgayChieu) AS Thang, -- Lấy tháng từ ngày đặt vé
                COUNT(MaVe) AS SoVe
            FROM VEXEMPHIM vx
            JOIN SUATCHIEU sc ON vx.MaSuatChieu = sc.MaSuatChieu
            WHERE sc.NgayChieu BETWEEN @startOfYear AND @endOfYear -- Chỉ tính trong năm hiện tại
            GROUP BY sc.MaSuatChieu, MONTH(sc.NgayChieu)
        )
        -- Lấy doanh thu theo từng tháng trong năm
        SELECT 
            m.Thang as [Tháng], -- Tháng (1-12)
            ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Tính doanh thu, mặc định là 0 nếu không có
        FROM 
            (SELECT TOP 12 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Thang FROM master.dbo.spt_values) m -- Tạo danh sách 12 tháng
        LEFT JOIN SUATCHIEU sc ON MONTH(sc.NgayChieu) = m.Thang 
            AND YEAR(sc.NgayChieu) = YEAR(@today) -- Lọc theo năm hiện tại
        LEFT JOIN SoVeBanDuocTheoThangChieu svbd ON sc.MaSuatChieu = svbd.MaSuatChieu 
            AND svbd.Thang = m.Thang -- Chỉ nối đúng tháng
        GROUP BY 
            m.Thang
        ORDER BY 
            m.Thang;
        ";
			return Connection.GetDataTable(query);
		}

	}
}
