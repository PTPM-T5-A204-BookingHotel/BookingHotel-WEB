USE [master]
GO
/****** Object:  Database [BookingHotel]    Script Date: 22/09/2023 10:54:05 CH ******/
CREATE DATABASE [BookingHotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookingHotel', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookingHotel.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookingHotel_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\BookingHotel_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookingHotel] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookingHotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookingHotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookingHotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookingHotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookingHotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookingHotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookingHotel] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookingHotel] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookingHotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookingHotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookingHotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookingHotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookingHotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookingHotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookingHotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookingHotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookingHotel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookingHotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookingHotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookingHotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookingHotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookingHotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookingHotel] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BookingHotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookingHotel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookingHotel] SET  MULTI_USER 
GO
ALTER DATABASE [BookingHotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookingHotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookingHotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookingHotel] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [BookingHotel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](max) NULL,
	[GiaDichVu] [float] NULL,
	[MoTaDichVu] [nvarchar](max) NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDatPhong]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonDatPhong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NgayDatPhong] [datetime2](7) NOT NULL,
	[NgayTraPhong] [datetime2](7) NOT NULL,
	[SoLuongNguoiLon] [int] NOT NULL,
	[SoLuongTreEm] [int] NOT NULL,
	[TongTien] [float] NULL,
	[KhachHangId] [int] NULL,
	[SoLuongPhong] [int] NOT NULL,
	[TenKhachHang] [nvarchar](max) NOT NULL,
	[LoaiPhongId] [int] NULL,
 CONSTRAINT [PK_HoaDonDatPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDatPhongDichVu]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonDatPhongDichVu](
	[HoaDonDatPhongId] [int] NOT NULL,
	[DichVuId] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonDatPhongDichVu] PRIMARY KEY CLUSTERED 
(
	[HoaDonDatPhongId] ASC,
	[DichVuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NgaySinh] [datetime2](7) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[CCCD] [nvarchar](max) NULL,
	[SoDienThoai] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NULL,
	[GiaPhong] [float] NULL,
	[Mota] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phong]    Script Date: 22/09/2023 10:54:05 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoPhong] [int] NULL,
	[TrangThai] [bit] NOT NULL,
	[LoaiPhongId] [int] NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230911034605_update1', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230911035235_update2', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230912065542_update3', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230922151527_update4', N'7.0.10')
SET IDENTITY_INSERT [dbo].[LoaiPhong] ON 

INSERT [dbo].[LoaiPhong] ([Id], [Ten], [GiaPhong], [Mota]) VALUES (1, N'Vip', NULL, NULL)
INSERT [dbo].[LoaiPhong] ([Id], [Ten], [GiaPhong], [Mota]) VALUES (2, N'Nor', NULL, NULL)
SET IDENTITY_INSERT [dbo].[LoaiPhong] OFF
/****** Object:  Index [IX_HoaDonDatPhong_KhachHangId]    Script Date: 22/09/2023 10:54:05 CH ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonDatPhong_KhachHangId] ON [dbo].[HoaDonDatPhong]
(
	[KhachHangId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonDatPhong_LoaiPhongId]    Script Date: 22/09/2023 10:54:05 CH ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonDatPhong_LoaiPhongId] ON [dbo].[HoaDonDatPhong]
(
	[LoaiPhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonDatPhongDichVu_DichVuId]    Script Date: 22/09/2023 10:54:05 CH ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonDatPhongDichVu_DichVuId] ON [dbo].[HoaDonDatPhongDichVu]
(
	[DichVuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Phong_LoaiPhongId]    Script Date: 22/09/2023 10:54:05 CH ******/
CREATE NONCLUSTERED INDEX [IX_Phong_LoaiPhongId] ON [dbo].[Phong]
(
	[LoaiPhongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HoaDonDatPhong] ADD  DEFAULT ((0)) FOR [SoLuongPhong]
GO
ALTER TABLE [dbo].[HoaDonDatPhong] ADD  DEFAULT (N'') FOR [TenKhachHang]
GO
ALTER TABLE [dbo].[HoaDonDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhong_KhachHang_KhachHangId] FOREIGN KEY([KhachHangId])
REFERENCES [dbo].[KhachHang] ([Id])
GO
ALTER TABLE [dbo].[HoaDonDatPhong] CHECK CONSTRAINT [FK_HoaDonDatPhong_KhachHang_KhachHangId]
GO
ALTER TABLE [dbo].[HoaDonDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId] FOREIGN KEY([LoaiPhongId])
REFERENCES [dbo].[LoaiPhong] ([Id])
GO
ALTER TABLE [dbo].[HoaDonDatPhong] CHECK CONSTRAINT [FK_HoaDonDatPhong_LoaiPhong_LoaiPhongId]
GO
ALTER TABLE [dbo].[HoaDonDatPhongDichVu]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhongDichVu_DichVu_DichVuId] FOREIGN KEY([DichVuId])
REFERENCES [dbo].[DichVu] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonDatPhongDichVu] CHECK CONSTRAINT [FK_HoaDonDatPhongDichVu_DichVu_DichVuId]
GO
ALTER TABLE [dbo].[HoaDonDatPhongDichVu]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhongDichVu_HoaDonDatPhong_HoaDonDatPhongId] FOREIGN KEY([HoaDonDatPhongId])
REFERENCES [dbo].[HoaDonDatPhong] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonDatPhongDichVu] CHECK CONSTRAINT [FK_HoaDonDatPhongDichVu_HoaDonDatPhong_HoaDonDatPhongId]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong_LoaiPhongId] FOREIGN KEY([LoaiPhongId])
REFERENCES [dbo].[LoaiPhong] ([Id])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong_LoaiPhongId]
GO
USE [master]
GO
ALTER DATABASE [BookingHotel] SET  READ_WRITE 
GO
