USE [master]
GO
/****** Object:  Database [QuanLyNhanSu]    Script Date: 1/9/2025 9:39:54 PM ******/
CREATE DATABASE [QuanLyNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HUY\MSSQL\DATA\QuanLyNhanSu.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.HUY\MSSQL\DATA\QuanLyNhanSu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyNhanSu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhanSu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhanSu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhanSu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyNhanSu', N'ON'
GO
ALTER DATABASE [QuanLyNhanSu] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyNhanSu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyNhanSu]
GO
/****** Object:  Table [dbo].[BaoHiem]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoHiem](
	[maBH] [nvarchar](50) NULL,
	[NgayCap] [date] NULL,
	[maLBH] [nvarchar](50) NULL,
	[maNV] [nchar](10) NOT NULL,
	[ThoiHan] [nvarchar](50) NULL,
 CONSTRAINT [PK_BaoHiem] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[maNV] [nchar](10) NOT NULL,
	[NgayCham] [date] NULL,
	[CheckInTime] [time](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiNhanh]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiNhanh](
	[maCN] [nchar](10) NOT NULL,
	[tenCN] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChiNhanh] PRIMARY KEY CLUSTERED 
(
	[maCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chucVu]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chucVu](
	[maCV] [nchar](10) NOT NULL,
	[tenCV] [nvarchar](50) NULL,
 CONSTRAINT [PK_chucVu] PRIMARY KEY CLUSTERED 
(
	[maCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaoTao]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaoTao](
	[MaDaoTao] [nvarchar](50) NOT NULL,
	[maNV] [nchar](10) NULL,
	[NgayBD] [date] NULL,
	[NgayKT] [date] NULL,
	[maTT] [nvarchar](50) NULL,
	[MaLDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhoaHoc] PRIMARY KEY CLUSTERED 
(
	[MaDaoTao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeSoLuong]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeSoLuong](
	[maNV] [nchar](10) NULL,
	[maHSL] [nchar](10) NOT NULL,
	[HeSoLuong] [nvarchar](50) NULL,
	[bienDongLuong] [nchar](10) NULL,
	[ngayBienDong] [date] NULL,
 CONSTRAINT [PK_HeSoLuong] PRIMARY KEY CLUSTERED 
(
	[maHSL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[MaHD] [nvarchar](50) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[MaLoaiHD] [nvarchar](50) NULL,
	[maNV] [nchar](10) NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiBH]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiBH](
	[MaLBH] [nvarchar](50) NOT NULL,
	[TenBH] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiBaoHiem] PRIMARY KEY CLUSTERED 
(
	[MaLBH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDT]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDT](
	[MaLDT] [nvarchar](50) NOT NULL,
	[TenLDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiDT] PRIMARY KEY CLUSTERED 
(
	[MaLDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHopDong]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHopDong](
	[MaLoaiHD] [nvarchar](50) NOT NULL,
	[TenLoaiHD] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiHopDong] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lsNhanVien]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lsNhanVien](
	[nbxt] [nvarchar](max) NULL,
	[nxt] [nvarchar](max) NULL,
	[trangthai] [nvarchar](2) NULL,
	[ngay] [date] NULL,
	[maCN] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanVien]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanVien](
	[maNV] [nchar](10) NOT NULL,
	[tenNV] [nvarchar](50) NOT NULL,
	[sdt] [nvarchar](50) NOT NULL,
	[sdt1] [nvarchar](50) NULL,
	[ngaysinh] [date] NOT NULL,
	[gioitinh] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[maCN] [nchar](10) NULL,
	[que] [nvarchar](50) NOT NULL,
	[cccd] [nvarchar](50) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[id] [nvarchar](50) NOT NULL,
	[maCV] [nchar](10) NULL,
	[ngayVaoLam] [date] NULL,
 CONSTRAINT [PK_nhanVien] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taiKhoan]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taiKhoan](
	[id] [nvarchar](50) NOT NULL,
	[tenDN] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[maCV] [nchar](10) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[maTT] [nvarchar](50) NOT NULL,
	[TenTT] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[maTT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tuyenDung]    Script Date: 1/9/2025 9:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tuyenDung](
	[maNV] [nchar](10) NOT NULL,
	[tenNV] [nvarchar](50) NOT NULL,
	[sdt] [nvarchar](50) NOT NULL,
	[sdt1] [nvarchar](50) NULL,
	[ngaysinh] [date] NOT NULL,
	[gioitinh] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[maCV] [nchar](10) NOT NULL,
	[que] [nvarchar](50) NOT NULL,
	[cccd] [nvarchar](50) NOT NULL,
	[url] [nvarchar](max) NOT NULL,
	[id] [nvarchar](50) NOT NULL,
	[nguoiTuyen] [nvarchar](50) NULL,
	[maCN] [nchar](10) NULL,
 CONSTRAINT [PK_tuyenDung] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChamCong] ([maNV], [NgayCham], [CheckInTime]) VALUES (N'BB1119    ', CAST(N'2025-01-05' AS Date), CAST(N'20:37:45' AS Time))
INSERT [dbo].[ChamCong] ([maNV], [NgayCham], [CheckInTime]) VALUES (N'BB7481    ', CAST(N'2025-01-05' AS Date), CAST(N'20:37:46' AS Time))
INSERT [dbo].[ChamCong] ([maNV], [NgayCham], [CheckInTime]) VALUES (N'BB1119    ', CAST(N'2025-01-09' AS Date), CAST(N'21:18:54' AS Time))
GO
INSERT [dbo].[ChiNhanh] ([maCN], [tenCN], [DiaChi]) VALUES (N'CG        ', N'Chi nhánh Cầu Giấy', N'Cầu Giấy')
INSERT [dbo].[ChiNhanh] ([maCN], [tenCN], [DiaChi]) VALUES (N'TX        ', N'Chi nhánh Thanh Xuân', N'Thanh Xuân')
GO
INSERT [dbo].[chucVu] ([maCV], [tenCV]) VALUES (N'BB        ', N'Bồi bàn')
INSERT [dbo].[chucVu] ([maCV], [tenCV]) VALUES (N'CQ        ', N'Chủ quán')
INSERT [dbo].[chucVu] ([maCV], [tenCV]) VALUES (N'PC        ', N'Pha chế')
INSERT [dbo].[chucVu] ([maCV], [tenCV]) VALUES (N'QL        ', N'Quản lý')
GO
INSERT [dbo].[LoaiBH] ([MaLBH], [TenBH]) VALUES (N'1', N'Bảo Hiểm Y Tế')
INSERT [dbo].[LoaiBH] ([MaLBH], [TenBH]) VALUES (N'2', N'Bảo Hiểm Thân Thể')
INSERT [dbo].[LoaiBH] ([MaLBH], [TenBH]) VALUES (N'3', N'Bảo Hiểm Thất Ngiệp')
GO
INSERT [dbo].[LoaiDT] ([MaLDT], [TenLDT]) VALUES (N'1', N'Đào Tạo Quản Lý')
INSERT [dbo].[LoaiDT] ([MaLDT], [TenLDT]) VALUES (N'2', N'Đào Tạo Pha Chế')
GO
INSERT [dbo].[LoaiHopDong] ([MaLoaiHD], [TenLoaiHD]) VALUES (N'1', N'Hợp Đồng Lao Động Chính Thức')
INSERT [dbo].[LoaiHopDong] ([MaLoaiHD], [TenLoaiHD]) VALUES (N'2', N'Hợp Đồng Thử Việc')
GO
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsd', N'Chủ quán', N'1', CAST(N'2025-01-04' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsad', N'Chủ quán', N'1', CAST(N'2025-01-04' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsd', N'Chủ quán', N'1', CAST(N'2025-01-09' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn zvxc', N'Chủ quán', N'1', CAST(N'2025-01-09' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsd', N'Chủ quán', N'0', CAST(N'2025-01-09' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn zvxc', N'Chủ quán', N'0', CAST(N'2025-01-09' AS Date), N'          ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsadf', N'Quản lý Chi nhánh Thanh Xuân', N'1', CAST(N'2025-01-09' AS Date), N'TX        ')
INSERT [dbo].[lsNhanVien] ([nbxt], [nxt], [trangthai], [ngay], [maCN]) VALUES (N'Bồi bàn fsadf', N'Chủ quán ', N'0', CAST(N'2025-01-09' AS Date), N'          ')
GO
INSERT [dbo].[nhanVien] ([maNV], [tenNV], [sdt], [sdt1], [ngaysinh], [gioitinh], [email], [maCN], [que], [cccd], [url], [id], [maCV], [ngayVaoLam]) VALUES (N'BB1119    ', N'fsd', N'4353453455', N'5434534355', CAST(N'2025-01-04' AS Date), N'Nam', N'a@gmail.com', N'TX        ', N'hà nội', N'453543453453', N'C:\Quan_ly_nhan_su\Quan_ly_nhan_su\bin\Debug\picture\_C__Users_huyho_Downloads_Thuy.html.png', N'1119', N'BB        ', CAST(N'2025-01-04' AS Date))
INSERT [dbo].[nhanVien] ([maNV], [tenNV], [sdt], [sdt1], [ngaysinh], [gioitinh], [email], [maCN], [que], [cccd], [url], [id], [maCV], [ngayVaoLam]) VALUES (N'CQabc     ', N'admin', N'admin', N'admin', CAST(N'2024-12-24' AS Date), N'Nam', N'abc', NULL, N'abc', N'abc', N'abc', N'abc', N'CQ        ', NULL)
INSERT [dbo].[nhanVien] ([maNV], [tenNV], [sdt], [sdt1], [ngaysinh], [gioitinh], [email], [maCN], [que], [cccd], [url], [id], [maCV], [ngayVaoLam]) VALUES (N'QL7481    ', N'fsad', N'4534354535', N'4353453455', CAST(N'2025-01-04' AS Date), N'Nam', N'b@gmail.com', N'TX        ', N'hn', N'543354543145', N'C:\Quan_ly_nhan_su\Quan_ly_nhan_su\bin\Debug\picture\taikhoan.png', N'7481', N'QL        ', CAST(N'2025-01-04' AS Date))
GO
INSERT [dbo].[taiKhoan] ([id], [tenDN], [MatKhau], [maCV]) VALUES (N'1119', N'BB1119', N'BB1119', N'BB        ')
INSERT [dbo].[taiKhoan] ([id], [tenDN], [MatKhau], [maCV]) VALUES (N'7481', N'huy', N'huy', N'QL        ')
INSERT [dbo].[taiKhoan] ([id], [tenDN], [MatKhau], [maCV]) VALUES (N'abc', N'admin', N'admin', N'CQ        ')
GO
INSERT [dbo].[TrangThai] ([maTT], [TenTT]) VALUES (N'1', N'Đang Đào Tạo')
INSERT [dbo].[TrangThai] ([maTT], [TenTT]) VALUES (N'2', N'Hoàn Thành')
GO
INSERT [dbo].[tuyenDung] ([maNV], [tenNV], [sdt], [sdt1], [ngaysinh], [gioitinh], [email], [maCV], [que], [cccd], [url], [id], [nguoiTuyen], [maCN]) VALUES (N'BB0546    ', N'tử', N'4355433455', N'5433453455', CAST(N'2025-01-09' AS Date), N'Nam', N't@gmail.com', N'BB        ', N'hà nội', N'435354345345', N'C:\Quan_ly_nhan_su\Quan_ly_nhan_su\bin\Debug\picture\luong.png', N'0546', N'Chủ quán ', NULL)
GO
ALTER TABLE [dbo].[BaoHiem]  WITH CHECK ADD  CONSTRAINT [FK_BaoHiem_LoaiBH] FOREIGN KEY([maLBH])
REFERENCES [dbo].[LoaiBH] ([MaLBH])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[BaoHiem] CHECK CONSTRAINT [FK_BaoHiem_LoaiBH]
GO
ALTER TABLE [dbo].[BaoHiem]  WITH CHECK ADD  CONSTRAINT [FK_BaoHiem_nhanVien1] FOREIGN KEY([maNV])
REFERENCES [dbo].[nhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaoHiem] CHECK CONSTRAINT [FK_BaoHiem_nhanVien1]
GO
ALTER TABLE [dbo].[DaoTao]  WITH CHECK ADD  CONSTRAINT [FK_DaoTao_LoaiDT] FOREIGN KEY([MaLDT])
REFERENCES [dbo].[LoaiDT] ([MaLDT])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DaoTao] CHECK CONSTRAINT [FK_DaoTao_LoaiDT]
GO
ALTER TABLE [dbo].[DaoTao]  WITH CHECK ADD  CONSTRAINT [FK_DaoTao_nhanVien1] FOREIGN KEY([maNV])
REFERENCES [dbo].[nhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DaoTao] CHECK CONSTRAINT [FK_DaoTao_nhanVien1]
GO
ALTER TABLE [dbo].[DaoTao]  WITH CHECK ADD  CONSTRAINT [FK_DaoTao_TrangThai] FOREIGN KEY([maTT])
REFERENCES [dbo].[TrangThai] ([maTT])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DaoTao] CHECK CONSTRAINT [FK_DaoTao_TrangThai]
GO
ALTER TABLE [dbo].[HeSoLuong]  WITH CHECK ADD  CONSTRAINT [FK_HeSoLuong_nhanVien1] FOREIGN KEY([maNV])
REFERENCES [dbo].[nhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeSoLuong] CHECK CONSTRAINT [FK_HeSoLuong_nhanVien1]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_LoaiHopDong] FOREIGN KEY([MaLoaiHD])
REFERENCES [dbo].[LoaiHopDong] ([MaLoaiHD])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_LoaiHopDong]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_nhanVien1] FOREIGN KEY([maNV])
REFERENCES [dbo].[nhanVien] ([maNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_nhanVien1]
GO
ALTER TABLE [dbo].[nhanVien]  WITH CHECK ADD  CONSTRAINT [FK_nhanVien_ChiNhanh] FOREIGN KEY([maCN])
REFERENCES [dbo].[ChiNhanh] ([maCN])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[nhanVien] CHECK CONSTRAINT [FK_nhanVien_ChiNhanh]
GO
ALTER TABLE [dbo].[nhanVien]  WITH CHECK ADD  CONSTRAINT [FK_nhanVien_chucVu] FOREIGN KEY([maCV])
REFERENCES [dbo].[chucVu] ([maCV])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[nhanVien] CHECK CONSTRAINT [FK_nhanVien_chucVu]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSu] SET  READ_WRITE 
GO
