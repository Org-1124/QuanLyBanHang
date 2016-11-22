USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 11/22/2016 3:22:40 PM ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLiBanHang', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLiBanHang.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLiBanHang_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QuanLiBanHang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[tblHangHoa]    Script Date: 11/22/2016 3:22:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHangHoa](
	[IDHangHoa] [int] NOT NULL,
	[TenHang] [nvarchar](50) NULL,
	[SoLuongCon] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_tblHangHoa] PRIMARY KEY CLUSTERED 
(
	[IDHangHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHoaDon]    Script Date: 11/22/2016 3:22:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDon](
	[IDHoaDon] [int] NOT NULL,
	[IDKhachHang] [int] NULL,
	[IDNhanVien] [int] NULL,
	[ThoiGian] [datetime] NULL,
	[IDHangHoa] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_tblHoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 11/22/2016 3:22:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[IDKhachHang] [int] NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblKhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 11/22/2016 3:22:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[IDNhanVien] [int] NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[IDNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tblHangHoa] ([IDHangHoa], [TenHang], [SoLuongCon], [DonGia]) VALUES (1, N'Kem danh rang', 100, 15000)
INSERT [dbo].[tblHangHoa] ([IDHangHoa], [TenHang], [SoLuongCon], [DonGia]) VALUES (2, N'Ban chai', 100, 30000)
INSERT [dbo].[tblHangHoa] ([IDHangHoa], [TenHang], [SoLuongCon], [DonGia]) VALUES (3, N'Nuoc hoa', 15, 50000)
INSERT [dbo].[tblHangHoa] ([IDHangHoa], [TenHang], [SoLuongCon], [DonGia]) VALUES (4, N'Dau goi SunSilk', 20, 67000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (1, 4, 1, CAST(0x0000A6BF00000000 AS DateTime), 1, 3, 15000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (2, 5, 1, CAST(0x0000A6BF00000000 AS DateTime), 1, 3, 15000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (3, 6, 3, CAST(0x0000A6BF00000000 AS DateTime), 2, 3, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (4, 6, 3, CAST(0x0000A6BF00000000 AS DateTime), 3, 5, 50000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (5, 9, 1, CAST(0x0000A6BF00000000 AS DateTime), 1, 3, 15000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (6, 11, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 3, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (7, 11, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 3, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (8, 11, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 3, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (9, 12, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 10, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (10, 12, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 10, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (11, 12, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 10, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (12, 12, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 10, 30000)
INSERT [dbo].[tblHoaDon] ([IDHoaDon], [IDKhachHang], [IDNhanVien], [ThoiGian], [IDHangHoa], [SoLuong], [DonGia]) VALUES (13, 12, 1, CAST(0x0000A6BF00000000 AS DateTime), 2, 10, 30000)
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (1, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (2, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (3, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (4, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (5, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (6, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (7, N'', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (8, N'Nguyễn Thế Công', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (9, N'Nguyễn Thế Công', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (10, N'hải sơn', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (11, N'cong', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (12, N'Lê Hải Sơn', N'', N'')
INSERT [dbo].[tblKhachHang] ([IDKhachHang], [TenKhachHang], [DiaChi], [DienThoai]) VALUES (13, N'Cong', N'', N'')
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi]) VALUES (1, N'TuanAnh', N'Nam', CAST(0x411D0B00 AS Date), N'Thanh Hoa')
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi]) VALUES (2, N'SyViet', N'Nam', CAST(0x411D0B00 AS Date), N'NgheAn')
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi]) VALUES (3, N'ThanhTung', N'Nam', CAST(0x411D0B00 AS Date), N'HungYen')
INSERT [dbo].[tblNhanVien] ([IDNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi]) VALUES (4, N'HaiSon', N'Nam', CAST(0x411D0B00 AS Date), N'HungYen')
ALTER TABLE [dbo].[tblHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDon_tblHangHoa] FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[tblHangHoa] ([IDHangHoa])
GO
ALTER TABLE [dbo].[tblHoaDon] CHECK CONSTRAINT [FK_tblHoaDon_tblHangHoa]
GO
ALTER TABLE [dbo].[tblHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDon_tblKhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[tblKhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[tblHoaDon] CHECK CONSTRAINT [FK_tblHoaDon_tblKhachHang]
GO
ALTER TABLE [dbo].[tblHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDon_tblNhanVien1] FOREIGN KEY([IDNhanVien])
REFERENCES [dbo].[tblNhanVien] ([IDNhanVien])
GO
ALTER TABLE [dbo].[tblHoaDon] CHECK CONSTRAINT [FK_tblHoaDon_tblNhanVien1]
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanHang] SET  READ_WRITE 
GO
