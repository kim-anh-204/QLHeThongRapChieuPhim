CREATE PROCEDURE sp_DoanhThuTheoTuan
AS
BEGIN
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
        DATENAME(WEEKDAY, DATEADD(DAY, Days.offset, @startOfWeek)) AS Thu, -- Lấy tên thứ trong tuần
        CAST(DATEADD(DAY, Days.offset, @startOfWeek) AS DATE) AS [Thời gian], -- Ngày cụ thể trong tuần
        ISNULL(SUM(svbd.SoVe * sc.GiaVe), 0) AS [Doanh Thu] -- Hiển thị 0 nếu không có doanh thu
    FROM 
        (SELECT 0 AS offset UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 
         UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6) AS Days
    LEFT JOIN SUATCHIEU sc ON CAST(sc.NgayChieu AS DATE) = DATEADD(DAY, Days.offset, @startOfWeek)
    LEFT JOIN SoVeBanDuoc svbd ON sc.MaSuatChieu = svbd.MaSuatChieu
    LEFT JOIN PHIM p ON sc.MaPhim = p.MaPhim
   -- WHERE DATEADD(DAY, Days.offset, @startOfWeek) <= @today -- Chỉ lấy đến ngày hiện tại
    GROUP BY 
        Days.offset
    ORDER BY Days.offset;
END
