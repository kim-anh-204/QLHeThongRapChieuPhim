--Create database QLRapChieuPhim
--Use  QLRapChieuPhim
GO
/****** Object:  Table [dbo].[GHE]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GHE](
	
	[MaGhe] [nvarchar](10) NOT NULL,
	TenGhe nvarchar(10) not null,
	[MaPhong] [nvarchar](5) NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_GHE] PRIMARY KEY CLUSTERED 
(
	[MaGhe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHIM]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHIM](
	[MaLoaiPhim] [nvarchar](10) NOT NULL,
	[TenLoaiPhim] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LOAIPHIM] PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](

	[MaNguoidung] [nvarchar](20) NOT NULL,
	[TenDangnhap] [nvarchar](50) NOT NULL,
	[Matkhau] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[MaNguoidung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [nvarchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[SDT] [int] NULL,
	[NgayVao] [datetime] NULL,
 CONSTRAINT [PK_KHACH] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIM]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIM](
	[MaPhim] [nvarchar](30) NOT NULL,
	[TenPhim] [nvarchar](max) NOT NULL,
	[Thoiluong] [int] NOT NULL,
	[Daodien] [nvarchar](50) NULL,
	[DienvienChinh] [nvarchar](max) NULL,
	[HangSanxuat] [nvarchar](50) NULL,
	[NuocSanxuat] [nvarchar](50) NULL,
	[HinhAnh] [image] NULL,
	[MoTa] [text] NULL,
	[NgayKhoiChieu] [date] NULL,
 CONSTRAINT [PK_PHIM] PRIMARY KEY CLUSTERED 
(
	[MaPhim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIM_LOAIPHIM]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIM_LOAIPHIM](
	[MaPhim] [nvarchar](30) NOT NULL,
	[MaLoaiPhim] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_PHIM_LOAIPHIM_1] PRIMARY KEY CLUSTERED 
(
	[MaPhim] ASC,
	[MaLoaiPhim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGCHIEUPHIM]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGCHIEUPHIM](
	[MaPhong] [nvarchar](5) NOT NULL,
	[TenPhong] [nvarchar](10) NULL,
	[TrangthaiPhongchieu] [bit] NOT NULL,
 CONSTRAINT [PK_PHONGCHIEUPHIM] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUATCHIEU]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUATCHIEU](
	[MaSuatchieu] [nvarchar](20) NOT NULL,
	[MaPhim] [nvarchar](30) NOT NULL,
	[MaPhong] [nvarchar](5) NOT NULL,
	[MaNguoiDung] [nvarchar](20) NOT NULL,
	[Ngaychieu] [date] NULL,
	[GioBatdau] [time](0) NULL,
	[SoVeToida] [int] NULL,
	[LoaiChieu] [nvarchar](2) NULL,
 CONSTRAINT [PK_SUATCHIEU] PRIMARY KEY CLUSTERED 
(
	[MaSuatchieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEXEMPHIM]    Script Date: 12/10/2024 6:30:12 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEXEMPHIM](
	[MaVe] [nvarchar](20) NOT NULL,
	[MaSuatChieu] [nvarchar](20) NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MaGhe]  [nvarchar](10) NOT NULL ,
	[GiaVe] [decimal](18, 0) NULL,
	[ThoigianDatve] [datetime] NULL,

 CONSTRAINT [PK_VEXEMPHIM] PRIMARY KEY CLUSTERED 
(
	[MaVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GHE]  WITH CHECK ADD  CONSTRAINT [FK_GHE_PHONGCHIEUPHIM] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONGCHIEUPHIM] ([MaPhong])
GO
ALTER TABLE [dbo].[GHE] CHECK CONSTRAINT [FK_GHE_PHONGCHIEUPHIM]
GO
ALTER TABLE [dbo].[PHIM_LOAIPHIM]  WITH CHECK ADD  CONSTRAINT [FK_PHIM_LOAIPHIM_LOAIPHIM] FOREIGN KEY([MaLoaiPhim])
REFERENCES [dbo].[LOAIPHIM] ([MaLoaiPhim])
GO
ALTER TABLE [dbo].[PHIM_LOAIPHIM] CHECK CONSTRAINT [FK_PHIM_LOAIPHIM_LOAIPHIM]
GO
ALTER TABLE [dbo].[PHIM_LOAIPHIM]  WITH CHECK ADD  CONSTRAINT [FK_PHIM_LOAIPHIM_PHIM] FOREIGN KEY([MaPhim])
REFERENCES [dbo].[PHIM] ([MaPhim])
GO
ALTER TABLE [dbo].[PHIM_LOAIPHIM] CHECK CONSTRAINT [FK_PHIM_LOAIPHIM_PHIM]
GO
ALTER TABLE [dbo].[SUATCHIEU]  WITH CHECK ADD  CONSTRAINT [FK_SUATCHIEU_NGUOIDUNG] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NGUOIDUNG] ([MaNguoidung])
GO
ALTER TABLE [dbo].[SUATCHIEU] CHECK CONSTRAINT [FK_SUATCHIEU_NGUOIDUNG]
GO
ALTER TABLE [dbo].[SUATCHIEU]  WITH CHECK ADD  CONSTRAINT [FK_SUATCHIEU_PHIM] FOREIGN KEY([MaPhim])
REFERENCES [dbo].[PHIM] ([MaPhim])
GO
ALTER TABLE [dbo].[SUATCHIEU] CHECK CONSTRAINT [FK_SUATCHIEU_PHIM]
GO
ALTER TABLE [dbo].[SUATCHIEU]  WITH CHECK ADD  CONSTRAINT [FK_SUATCHIEU_PHONGCHIEUPHIM] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONGCHIEUPHIM] ([MaPhong])
GO
ALTER TABLE [dbo].[SUATCHIEU] CHECK CONSTRAINT [FK_SUATCHIEU_PHONGCHIEUPHIM]
GO
ALTER TABLE [dbo].[VEXEMPHIM]  WITH CHECK ADD  CONSTRAINT [FK_VEXEMPHIM_GHE] FOREIGN KEY([MaGhe])
REFERENCES [dbo].[GHE] ([MaGhe])
GO
ALTER TABLE [dbo].[VEXEMPHIM] CHECK CONSTRAINT [FK_VEXEMPHIM_GHE]
GO
ALTER TABLE [dbo].[VEXEMPHIM]  WITH CHECK ADD  CONSTRAINT [FK_VEXEMPHIM_KHACHHANG] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[VEXEMPHIM] CHECK CONSTRAINT [FK_VEXEMPHIM_KHACHHANG]
GO
ALTER TABLE [dbo].[VEXEMPHIM]  WITH CHECK ADD  CONSTRAINT [FK_VEXEMPHIM_SUATCHIEU] FOREIGN KEY([MaSuatChieu])
REFERENCES [dbo].[SUATCHIEU] ([MaSuatchieu])
GO
ALTER TABLE [dbo].[VEXEMPHIM] CHECK CONSTRAINT [FK_VEXEMPHIM_SUATCHIEU]
GO

INSERT INTO LOAIPHIM (MaLoaiPhim, TenLoaiPhim)
VALUES
('L01', N'Hành động'),
('L02', N'Kinh dị'),
('L03', N'Viễn tưởng'),
('L04', N'Tâm lý'),
('L05', N'Tình cảm'),
('L06', N'Kịch'),
('L07', N'Lãng mạn'),
('L08', N'Tội Phạm'),
('L09', N'Âm nhạc'),
('L10', N'Hài Hước');


INSERT INTO GHE (MaGhe, TenGhe, MaPhong, TrangThai)
VALUES
('G001', 'A1', 'PXP-1', 0),
('G002', 'A2', 'PXP-1', 0),
('G003', 'A3', 'PXP-1', 0),
('G004', 'A4', 'PXP-1', 0),
('G005', 'A5', 'PXP-1', 0),
('G006', 'A6', 'PXP-1', 1),
('G007', 'A7', 'PXP-1', 0),
('G008', 'A8', 'PXP-1', 0),
('G009', 'B1', 'PXP-1', 0),
('G010', 'B2', 'PXP-1', 0),
('G011', 'B3', 'PXP-1', 0),
('G012', 'B4', 'PXP-1', 0),
('G013', 'B5', 'PXP-1', 0),
('G014', 'B6', 'PXP-1', 0),
('G015', 'B7', 'PXP-1', 0),
('G016', 'B8', 'PXP-1', 0),
('G017', 'C1', 'PXP-1', 0),
('G018', 'C2', 'PXP-1', 0),
('G019', 'C3', 'PXP-1', 0),
('G020', 'C4', 'PXP-1', 0),
('G021', 'C5', 'PXP-1', 0),
('G022', 'C6', 'PXP-1', 0),
('G023', 'C7', 'PXP-1', 0),
('G024', 'C8', 'PXP-1', 0),
('G025', 'D1', 'PXP-1', 0),
('G026', 'D2', 'PXP-1', 0),
('G027', 'D3', 'PXP-1', 0),
('G028', 'D4', 'PXP-1', 0),
('G029', 'D5', 'PXP-1', 0),
('G030', 'D6', 'PXP-1', 0),
('G031', 'D7', 'PXP-1', 0),
('G032', 'D8', 'PXP-1', 0),
('G033', 'E1', 'PXP-1', 0),
('G034', 'E2', 'PXP-1', 0),
('G035', 'E3', 'PXP-1', 0),
('G036', 'E4', 'PXP-1', 0),
('G037', 'E5', 'PXP-1', 0),
('G038', 'E6', 'PXP-1', 0),
('G039', 'E7', 'PXP-1', 0),
('G040', 'E8', 'PXP-1', 0),
('G041', 'F1', 'PXP-1', 0),
('G042', 'F2', 'PXP-1', 0),
('G043', 'F3', 'PXP-1', 0),
('G044', 'F4', 'PXP-1', 0),
('G045', 'F5', 'PXP-1', 0),
('G046', 'F6', 'PXP-1', 0),
('G047', 'F7', 'PXP-1', 0),
('G048', 'F8', 'PXP-1', 0),

('G049', 'A1', 'PXP-2', 0),
('G050', 'A2', 'PXP-2', 0),
('G051', 'A3', 'PXP-2', 0),
('G052', 'A4', 'PXP-2', 0),
('G053', 'A5', 'PXP-2', 0),
('G054', 'A6', 'PXP-2', 1),
('G055', 'A7', 'PXP-2', 0),
('G056', 'A8', 'PXP-2', 0),
('G057', 'B1', 'PXP-2', 0),
('G058', 'B2', 'PXP-2', 0),
('G059', 'B3', 'PXP-2', 0),
('G060', 'B4', 'PXP-2', 0),
('G061', 'B5', 'PXP-2', 0),
('G062', 'B6', 'PXP-2', 0),
('G063', 'B7', 'PXP-2', 0),
('G064', 'B8', 'PXP-2', 0),
('G065', 'C1', 'PXP-2', 0),
('G066', 'C2', 'PXP-2', 0),
('G067', 'C3', 'PXP-2', 0),
('G068', 'C4', 'PXP-2', 0),
('G069', 'C5', 'PXP-2', 0),
('G070', 'C6', 'PXP-2', 0),
('G071', 'C7', 'PXP-2', 0),
('G072', 'C8', 'PXP-2', 0),
('G073', 'D1', 'PXP-2', 0),
('G074', 'D2', 'PXP-2', 0),
('G075', 'D3', 'PXP-2', 0),
('G076', 'D4', 'PXP-2', 0),
('G077', 'D5', 'PXP-2', 0),
('G078', 'D6', 'PXP-2', 0),
('G079', 'D7', 'PXP-2', 0),
('G080', 'D8', 'PXP-2', 0),
('G081', 'E1', 'PXP-2', 0),
('G082', 'E2', 'PXP-2', 0),
('G083', 'E3', 'PXP-2', 0),
('G084', 'E4', 'PXP-2', 0),
('G085', 'E5', 'PXP-2', 0),
('G086', 'E6', 'PXP-2', 0),
('G087', 'E7', 'PXP-2', 0),
('G088', 'E8', 'PXP-2', 0),
('G089', 'F1', 'PXP-2', 0),
('G090', 'F2', 'PXP-2', 0),
('G091', 'F3', 'PXP-2', 0),
('G092', 'F4', 'PXP-2', 0),
('G093', 'F5', 'PXP-2', 0),
('G094', 'F6', 'PXP-2', 0),
('G095', 'F7', 'PXP-2', 0),
('G096', 'F8', 'PXP-2', 0),

('G097', 'A1', 'PXP-3', 0),
('G098', 'A2', 'PXP-3', 0),
('G099', 'A3', 'PXP-3', 0),
('G100', 'A4', 'PXP-3', 0),
('G101', 'A5', 'PXP-3', 0),
('G102', 'A6', 'PXP-3', 1),
('G103', 'A7', 'PXP-3', 0),
('G104', 'A8', 'PXP-3', 0),
('G105', 'B1', 'PXP-3', 0),
('G106', 'B2', 'PXP-3', 0),
('G107', 'B3', 'PXP-3', 0),
('G108', 'B4', 'PXP-3', 0),
('G109', 'B5', 'PXP-3', 0),
('G110', 'B6', 'PXP-3', 0),
('G111', 'B7', 'PXP-3', 0),
('G112', 'B8', 'PXP-3', 0),
('G113', 'C1', 'PXP-3', 0),
('G114', 'C2', 'PXP-3', 0),
('G115', 'C3', 'PXP-3', 0),
('G116', 'C4', 'PXP-3', 0),
('G117', 'C5', 'PXP-3', 0),
('G118', 'C6', 'PXP-3', 0),
('G119', 'C7', 'PXP-3', 0),
('G120', 'C8', 'PXP-3', 0),
('G121', 'D1', 'PXP-3', 0),
('G122', 'D2', 'PXP-3', 0),
('G123', 'D3', 'PXP-3', 0),
('G124', 'D4', 'PXP-3', 0),
('G125', 'D5', 'PXP-3', 0),
('G126', 'D6', 'PXP-3', 0),
('G127', 'D7', 'PXP-3', 0),
('G128', 'D8', 'PXP-3', 0),
('G129', 'E1', 'PXP-3', 0),
('G130', 'E2', 'PXP-3', 0),
('G131', 'E3', 'PXP-3', 0),
('G132', 'E4', 'PXP-3', 0),
('G133', 'E5', 'PXP-3', 0),
('G134', 'E6', 'PXP-3', 0),
('G135', 'E7', 'PXP-3', 0),
('G136', 'E8', 'PXP-3', 0),
('G137', 'F1', 'PXP-3', 0),
('G138', 'F2', 'PXP-3', 0),
('G139', 'F3', 'PXP-3', 0),
('G140', 'F4', 'PXP-3', 0),
('G141', 'F5', 'PXP-3', 0),
('G142', 'F6', 'PXP-3', 0),
('G143', 'F7', 'PXP-3', 0),
('G144', 'F8', 'PXP-3', 0),

('G145', 'A1', 'PXP-4', 0),
('G146', 'A2', 'PXP-4', 0),
('G147', 'A3', 'PXP-4', 0),
('G148', 'A4', 'PXP-4', 0),
('G149', 'A5', 'PXP-4', 0),
('G150', 'A6', 'PXP-4', 1),
('G151', 'A7', 'PXP-4', 0),
('G152', 'A8', 'PXP-4', 0),
('G153', 'B1', 'PXP-4', 0),
('G154', 'B2', 'PXP-4', 0),
('G155', 'B3', 'PXP-4', 0),
('G156', 'B4', 'PXP-4', 0),
('G157', 'B5', 'PXP-4', 0),
('G158', 'B6', 'PXP-4', 0),
('G159', 'B7', 'PXP-4', 0),
('G160', 'B8', 'PXP-4', 0),
('G161', 'C1', 'PXP-4', 0),
('G162', 'C2', 'PXP-4', 0),
('G163', 'C3', 'PXP-4', 0),
('G164', 'C4', 'PXP-4', 0),
('G165', 'C5', 'PXP-4', 0),
('G166', 'C6', 'PXP-4', 0),
('G167', 'C7', 'PXP-4', 0),
('G168', 'C8', 'PXP-4', 0),
('G169', 'D1', 'PXP-4', 0),
('G170', 'D2', 'PXP-4', 0),
('G171', 'D3', 'PXP-4', 0),
('G172', 'D4', 'PXP-4', 0),
('G173', 'D5', 'PXP-4', 0),
('G174', 'D6', 'PXP-4', 0),
('G175', 'D7', 'PXP-4', 0),
('G176', 'D8', 'PXP-4', 0),
('G177', 'E1', 'PXP-4', 0),
('G178', 'E2', 'PXP-4', 0),
('G179', 'E3', 'PXP-4', 0),
('G180', 'E4', 'PXP-4', 0),
('G181', 'E5', 'PXP-4', 0),
('G182', 'E6', 'PXP-4', 0),
('G183', 'E7', 'PXP-4', 0),
('G184', 'E8', 'PXP-4', 0),
('G185', 'F1', 'PXP-4', 0),
('G186', 'F2', 'PXP-4', 0),
('G187', 'F3', 'PXP-4', 0),
('G188', 'F4', 'PXP-4', 0),
('G189', 'F5', 'PXP-4', 0),
('G190', 'F6', 'PXP-4', 0),
('G191', 'F7', 'PXP-4', 0),
('G192', 'F8', 'PXP-4', 0);


INSERT INTO NGUOIDUNG (MaNguoidung, TenDangnhap, Matkhau) VALUES
('U001', 'Giap123', '123'),
('U002', 'Lam123', '123'),
('U003', 'TA123', '123'),
('U004', 'KA123', '123');

INSERT INTO NHANVIEN (MaNV, TenNV, SDT, NgayVao) VALUES
('E001', N'Nguyễn Như Quỳnh', '0123456789', '2024-09-13'),
('E002', N'Nguyễn Thị Hoa', '0123456689', '2024-09-14'),
('E003', N'Phạm Trung Kiên', '0123456690', '2024-09-15'),
('E004', N'Hoàng Quốc Khánh', '0123456691', '2024-09-16'),
('E005', N'Lưu Thị Ngân', '0123456692', '2024-09-17'),
('E006', N'Tran Kim Ngân', '0123456693', '2024-09-18'),
('E007', N'Tran Thanh Tâm', '0123456694', '2024-09-19'),
('E008', N'Tran Văn Quốc', '0123456695', '2024-09-20'),
('E009', N'Nguyễn Minh Hải', '0123456696', '2024-09-21'),
('E010', N'Phạm Anh Tuấn', '0123456697', '2024-09-22');
INSERT INTO PHIM (MaPhim, TenPhim, ThoiLuong, DaoDien, DienVienChinh, HangSanXuat, NuocSanXuat, MoTa, NgayKhoiChieu) 
VALUES
('P01', N'Tee Yod: Quỷ Ăn Tạng Phần 2', 111, N'Taweewat Wantha', N'Nadech Kugimiya, Denise Jelilcha Kapaun, Mim Rattawadee Wongthong, Junior Kajbhunditt Jaidee, Friend Peerakrit Phacharaboonyakiat, Nutthatcha Jessica Padovan', N'Five Star Production', N'Thái Lan', N'Ba năm sau cái chết của Yam, Yak vẫn tiếp tục săn lùng linh hồn bí ẩn mặc áo choàng đen. Gặp một người đàn ông có triệu chứng giống Yam, Yak phát hiện ra người bảo vệ linh hồn, pháp sư ẩn dật Puang, sống trong một khu rừng đầy nguy hiểm...', '2024-10-18'),
('P02', N'Cô Dâu Hào Môn', 114, N'Vũ Ngọc Đãng', N'Uyển Ân, Samuel An, Thu Trang, Lê Giang, Kiều Minh Tuấn, NSND Hồng Vân', N'16 Films', N'Việt Nam', N'Phim lấy đề tài làm dâu hào môn và khai thác câu chuyện môn đăng hộ đối, lối sống và quy tắc của giới thượng lưu dưới góc nhìn hài hước và châm biếm.', '2024-10-10'),
('P03', N'Domino: Lối Thoát Cuối Cùng', 103, N'Nguyễn Phúc Huy Cương', N'Thuận Nguyễn, Quốc Cường, Huỳnh Anh Tuấn, Henry Nguyễn, Cát Hạ', N'Galaxy Studio', N'Việt Nam', N'Sau khi cha bị kẻ ác sát hại, từ người ngoài cuộc, An (Thuận Nguyễn) từng bước bị kéo vào cuộc chiến của các phe đảng xã hội đen. An một mình sẽ phải đối mặt với những nguy hiểm đe dọa đến cả tính mạng.', '2004-11-10'),
('P04', N'Robot Hoang Dã', 102, N'Chris Sanders', N'Lupita Nyong''o, Pedro Pascal, Catherine O’hara, Bill Nighy', N'Warner Bros', N'Mỹ', N'Cuộc phiêu lưu hoành tráng theo chân hành trình của một robot — đơn vị ROZZUM 7134, gọi tắt là Roz. Roz vô tình dạt vào hoang đảo sau một sự cố và nơi đây trở thành địa điểm sống mới của cô...', '2024-11-10'),
('P05', N'Joker: Folie À Deux Điên Có Đôi', 138, N'Todd Phillips', N'Joaquin Phoenix, Zazie Beetz, Lady Gaga', N'Warner Bros', N'Mỹ', N'“Joker: Folie à Deux” đưa Arthur Fleck đến trại tâm thần Arkham trong khi chờ xét xử cho những tội ác của hắn với tư cách là Joker. Trong lúc vật lộn với hai bản ngã của mình...', '2024-10-04'),
('P06', N'Mộ Đom Đóm', 89, N'Isao Takahata', N'Tsutomu Tatsumi, Ayano Shiraishi, Yoshiko Shinohara, Akemi Yamaguchi', N'Toho', N'Nhật Bản', N'Bộ phim được đặt trong bối cảnh giai đoạn cuối chiến tranh thế giới thứ 2 ở Nhật, kể về câu chuyện cảm động về tình anh em của hai đứa trẻ mồ côi là Seita và Setsuko...', '2024-10-05'),
('P07', N'Kumanthong', 101, N'Xian Lim', N'Cindy Miranda, Althea Ruedas, Max Nattapol Diloknawarit', N'Five Star Production', N'Philippines', N'Sau cái chết của con trai, Sarah tìm đến vùng đất tâm linh Thái Lan, khẩn cần một thầy tu nổi tiếng sử dụng tro cốt đứa bé để tạo nên bức tượng Kumanthong...', '2024-10-04'),
('P08', N'Khi Bầu Trời Gặp Biển Cả Ở Giữa Là Chúng Ta', 99, N'Michio Koshikawa', N'Hibiki Kitazawa, Ayumu Nakajima', N'Studio Ghibli', N'Nhật Bản', N'Một ngày nọ, cô gái trẻ tên Momo (Hibiki Kitazawa) tình cờ gặp Todo (Ayumu Nakajima), một người đàn ông 40 tuổi trong quán ăn. Mối quan hệ của họ bắt đầu chớm nở...', '2024-10-04'),
('P09', N'BTS: Hành Trình Solo | JungKook: I Am Still', 112, N'Jun-Soo Park', N'JUNG KOOK', N'Giraffe Pictures', N'Hàn Quốc', N'Tôi chỉ đi theo kim chỉ nam của riêng mình. BTS Jung Kook - thành viên của nhóm nhạc đạt danh hiệu Nghệ sĩ nhạc Pop thế kỷ 21...', '2024-10-06'),
('P10', N'Cám', 122, N'Trần Hữu Tấn', N'Lâm Thanh Mỹ, Rima Thanh Vy, Thúy Diễm, Quốc Cường, Hải Nam', N'BHD Studio', N'Việt Nam', N'Câu chuyện phim là dị bản kinh dị đẫm máu lấy cảm hứng từ truyện cổ tích nổi tiếng Tấm Cám...', '2024-10-06'),
('P11', N'Elli Và Bí Ẩn Chiếc Tàu Ma', 87, N'Piet De Rycker, Jesper Møller, Jens Møller', N'Dalia Schmidt-Foß, Oliver Kalkofe, Santiago Ziesmer', N'Universal Pictures', N'Mỹ', N'Khi một hồn ma nhỏ vô gia cư gõ cửa nhà những cư dân lập dị của một Chuyến tàu ma để tìm kiếm một nơi để thuộc về...', '2024-11-06'),
('P12', N'Linh Miêu: Quỷ Nhập Tràng', 111, N'Lưu Thành Luân', N'Hồng Đào, Thiên An, Thuỳ Tiên, Văn Anh, Samuel An', N'Phim Việt', N'Việt Nam', N'Linh Miêu: Quỷ Nhập Tràng lấy cảm hứng từ truyền thuyết dân gian về quỷ nhập tràng để xây dựng cốt truyện. Phim lồng ghép những nét văn hóa đặc trưng của Huế...', '2024-11-16'),
('P13', N'Truy Tìm Lối Thoát', 110, N'William Henry Aherne', N'Vachiravit Paisarnkulwong, Worranit Thawornwong, Frame Supakchaya Sukbaiyen', N'Five Star Production', N'Thá Lan', N'Một nhóm học sinh đi đến một lễ hội bí ẩn để giải trí, nhưng lễ hội hóa ra lại là một trò chơi sinh tồn tàn khốc...', '2024-11-15'),
('P14', N'Red One: Mật Mã Đỏ', 123, N'Jake Kasdan', N'Dwayne Johnson, Chris Evans, Lucy Liu', N'Warner Bros', N'Mỹ', N'Sau khi Ông già Noel (tên mã: Red One) bị bắt cóc, Trưởng phòng An ninh Bắc Cực (Dwayne Johnson) phải hợp tác với thợ săn tiền thưởng khét tiếng nhất thế giới (Chris Evans)...', '2024-11-15'),
('P15', N'Thiên Đường Quả Báo', 110, N'Naruebet Kuno', N'Jeff Satur, Engfa Waraha, Srida Puapimol', N'Star', N'Thá Lan', N'Cặp đôi đồng tính chưa kết hôn cùng nhau xây dựng nhà cửa, trang trại sầu riêng. Sau cái chết bất ngờ của một người, gia đình anh ta tịch thu tài sản do không được công nhận là vợ chồng hợp pháp...', '2024-11-15'),
('P16', N'Ngày Xưa Có Một Chuyện Tình', 120, N'Trịnh Đình Lê Minh', N'Avin Lu, Ngọc Xuân, Đỗ Nhật Hoàng, Thanh Tú, Bảo Tiên, Hạo Khang', N'Phim Việt', N'Việt Nam', N'Ngày xưa có một chuyện tình kể về tình bạn, tình yêu giữa hai chàng trai và một cô gái từ thuở ấu thơ cho đến khi trưởng', '2024-11-15');


insert into PHONGCHIEUPHIM( MaPhong, TenPhong, TrangthaiPhongchieu) values
('PXP-1', 'PC-01', '0'),
('PXP-2', 'PC-02', '0'),
('PXP-3', 'PC-03', '0'),
('PXP-4', 'PC-04', '0');

INSERT INTO SUATCHIEU (MaSuatchieu, MaPhim, MaPhong, MaNguoiDung, Ngaychieu, GioBatdau, SoVeToida, LoaiChieu) VALUES
('S001', 'P01', 'PXP-1', 'U001', '2024-10-18', '09:00:00', 48, '2D'),
('S002', 'P01', 'PXP-2', 'U001', '2024-10-19', '21:00:00', 48, '2D'),
('S003', 'P01', 'PXP-3', 'U002', '2024-10-21', '22:00:00', 48, '2D'),
('S004', 'P02', 'PXP-4', 'U003', '2024-10-18', '09:00:00', 48, '2D'),
('S005', 'P03', 'PXP-2', 'U004', '2024-10-18', '12:00:00', 48, '2D'),
('S006', 'P04', 'PXP-3', 'U001', '2024-10-18', '14:00:00', 48, '2D'),
('S007', 'P05', 'PXP-4', 'U002', '2024-10-18', '20:00:00', 48, '3D'),
('S008', 'P06', 'PXP-1', 'U003', '2024-10-19', '20:00:00', 48, '2D'),
('S009', 'P07', 'PXP-2', 'U004', '2024-10-19', '14:00:00', 48, '2D'),
('S010', 'P08', 'PXP-3', 'U001', '2024-10-19', '19:00:00', 48, '2D'),
('S011', 'P09', 'PXP-4', 'U002', '2024-10-19', '16:00:00', 48, '2D'),
('S012', 'P10', 'PXP-1', 'U003', '2024-10-19', '23:00:00', 48, '2D'),
('S013', 'P11', 'PXP-2', 'U004', '2024-10-19', '23:00:00', 48, '3D'),
('S014', 'P12', 'PXP-3', 'U001', '2024-10-20', '12:00:00', 48, '2D'),
('S015', 'P13', 'PXP-4', 'U002', '2024-10-20', '14:00:00', 48, '2D'),
('S016', 'P14', 'PXP-1', 'U003', '2024-10-20', '20:00:00', 48, '2D'),
('S017', 'P15', 'PXP-2', 'U004', '2024-10-20', '22:00:00', 48, '2D'),
('S018', 'P16', 'PXP-3', 'U001', '2024-10-20', '09:00:00', 48, '2D'),
('S019', 'P06', 'PXP-4', 'U002', '2024-10-21', '09:00:00', 48, '2D'),
('S020', 'P07', 'PXP-1', 'U003', '2024-10-21', '10:00:00', 48, '2D'),
('S021', 'P08', 'PXP-2', 'U004', '2024-10-21', '11:00:00', 48, '2D'),
('S022', 'P09', 'PXP-3', 'U001', '2024-10-21', '12:00:00', 48, '2D'),
('S023', 'P10', 'PXP-4', 'U002', '2024-10-21', '19:00:00', 48, '2D'),
('S024', 'P11', 'PXP-1', 'U003', '2024-10-21', '20:00:00', 48, '3D'),
('S025', 'P12', 'PXP-2', 'U004', '2024-10-21', '21:00:00', 48, '2D'),
('S026', 'P13', 'PXP-3', 'U001', '2024-10-21', '22:00:00', 48, '2D');



INSERT INTO VEXEMPHIM (MaVe, MaSuatChieu, MaNV, MaGhe, GiaVe, ThoigianDatve)
VALUES
('V001', 'S001', 'E001', 'G001', 65000, '2024-10-18 07:00:00'),
('V002', 'S001', 'E002', 'G030', 65000, '2024-10-18 08:30:00'),
('V003', 'S001', 'E003', 'G013', 65000, '2024-10-18 08:45:00'),
('V004', 'S001', 'E004', 'G024', 65000, '2024-10-18 08:50:00'),
('V005', 'S001', 'E005', 'G043', 65000, '2024-10-18 08:55:00'),
('V006', 'S002', 'E006', 'G080', 70000, '2024-10-19 20:00:00'),
('V007', 'S003', 'E007', 'G132', 80000, '2024-10-21 21:30:00'),
('V008', 'S003', 'E008', 'G133', 80000, '2024-10-21 21:45:00'),
('V009', 'S003', 'E009', 'G120', 80000, '2024-10-21 21:50:00'),
('V010', 'S004', 'E010', 'G164', 75000, '2024-10-18 08:00:00'),
('V011', 'S005', 'E001', 'G070', 70000, '2024-10-18 11:00:00'),
('V012', 'S006', 'E002', 'G111', 65000, '2024-10-18 13:00:00'),
('V013', 'S007', 'E003', 'G150', 80000, '2024-10-19 18:00:00'),
('V014', 'S008', 'E004', 'G030', 80000, '2024-10-19 17:30:00');

INSERT INTO Phim_LoaiPhim (MaPhim, MaLoaiPhim)
VALUES
('P01', 'L02'),
('P02', 'L04'),
('P03', 'L01'),
('P04', 'L03'),
('P05', 'L04'),
('P05', 'L08'),
('P06', 'L03'),
('P06', 'L06'),
('P07', 'L02'),
('P08', 'L07'),
('P08', 'L08'),
('P09', 'L09'),
('P10', 'L02'),
('P11', 'L03'),
('P12', 'L02'),
('P13', 'L01'),
('P15', 'L06'),
('P15', 'L01'),
('P14', 'L01'),
('P14', 'L10'),
('P16', 'L04'),
('P16', 'L05');
