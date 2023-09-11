USE [BookingHotel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/09/2023 10:59:34 SA ******/
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
/****** Object:  Table [dbo].[DichVu]    Script Date: 11/09/2023 10:59:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](max) NOT NULL,
	[GiaDichVu] [float] NOT NULL,
	[MoTaDichVu] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DichVu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonDatPhong]    Script Date: 11/09/2023 10:59:34 SA ******/
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
	[TongTien] [float] NOT NULL,
	[IdPhong] [int] NOT NULL,
	[PhongId] [int] NOT NULL,
	[IdKhachHang] [int] NOT NULL,
	[KhachHangId] [int] NOT NULL,
	[IdDichVu] [int] NOT NULL,
	[DichVuId] [int] NOT NULL,
 CONSTRAINT [PK_HoaDonDatPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/09/2023 10:59:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[DiaChi] [nvarchar](max) NOT NULL,
	[CCCD] [nvarchar](max) NOT NULL,
	[SoDienThoai] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 11/09/2023 10:59:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phong]    Script Date: 11/09/2023 10:59:34 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SoPhong] [int] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[IdLoaiPhong] [int] NOT NULL,
	[LoaiPhongId] [int] NOT NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Phong] ADD  DEFAULT ((0)) FOR [IdLoaiPhong]
GO
ALTER TABLE [dbo].[Phong] ADD  DEFAULT ((0)) FOR [LoaiPhongId]
GO
ALTER TABLE [dbo].[HoaDonDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhong_DichVu_DichVuId] FOREIGN KEY([DichVuId])
REFERENCES [dbo].[DichVu] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonDatPhong] CHECK CONSTRAINT [FK_HoaDonDatPhong_DichVu_DichVuId]
GO
ALTER TABLE [dbo].[HoaDonDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhong_KhachHang_KhachHangId] FOREIGN KEY([KhachHangId])
REFERENCES [dbo].[KhachHang] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonDatPhong] CHECK CONSTRAINT [FK_HoaDonDatPhong_KhachHang_KhachHangId]
GO
ALTER TABLE [dbo].[HoaDonDatPhong]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonDatPhong_Phong_PhongId] FOREIGN KEY([PhongId])
REFERENCES [dbo].[Phong] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonDatPhong] CHECK CONSTRAINT [FK_HoaDonDatPhong_Phong_PhongId]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong_LoaiPhongId] FOREIGN KEY([LoaiPhongId])
REFERENCES [dbo].[LoaiPhong] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong_LoaiPhongId]
GO
