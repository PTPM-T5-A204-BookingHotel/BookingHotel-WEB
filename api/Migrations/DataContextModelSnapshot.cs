﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.DichVu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("GiaDichVu")
                        .HasColumnType("float");

                    b.Property<string>("MoTaDichVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDichVu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DichVu");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CCCD")
                        .HasColumnType("int");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhXacNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<int?>("LoaiPhongId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDatPhong")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTraPhong")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuongNguoiLon")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongPhong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTreEm")
                        .HasColumnType("int");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangId");

                    b.HasIndex("LoaiPhongId");

                    b.ToTable("HoaDonDatPhong");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhongDichVu", b =>
                {
                    b.Property<int>("HoaDonDatPhongId")
                        .HasColumnType("int");

                    b.Property<int>("DichVuId")
                        .HasColumnType("int");

                    b.HasKey("HoaDonDatPhongId", "DichVuId");

                    b.HasIndex("DichVuId");

                    b.ToTable("HoaDonDatPhongDichVu");
                });

            modelBuilder.Entity("api.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("api.Models.LoaiPhong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("GiaPhong")
                        .HasColumnType("float");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoaiPhong");
                });

            modelBuilder.Entity("api.Models.Phong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LoaiPhongId")
                        .HasColumnType("int");

                    b.Property<int?>("SoPhong")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LoaiPhongId");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhong", b =>
                {
                    b.HasOne("api.Models.KhachHang", "KhachHang")
                        .WithMany("HoaDonDatPhong")
                        .HasForeignKey("KhachHangId");

                    b.HasOne("api.Models.LoaiPhong", "LoaiPhong")
                        .WithMany("HoaDonDatPhong")
                        .HasForeignKey("LoaiPhongId");

                    b.Navigation("KhachHang");

                    b.Navigation("LoaiPhong");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhongDichVu", b =>
                {
                    b.HasOne("api.Models.DichVu", "DichVus")
                        .WithMany("HoaDonDichVu")
                        .HasForeignKey("DichVuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.HoaDonDatPhong", "HoaDonDatPhongs")
                        .WithMany("HoaDonDichVu")
                        .HasForeignKey("HoaDonDatPhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DichVus");

                    b.Navigation("HoaDonDatPhongs");
                });

            modelBuilder.Entity("api.Models.Phong", b =>
                {
                    b.HasOne("api.Models.LoaiPhong", "LoaiPhong")
                        .WithMany("Phong")
                        .HasForeignKey("LoaiPhongId");

                    b.Navigation("LoaiPhong");
                });

            modelBuilder.Entity("api.Models.DichVu", b =>
                {
                    b.Navigation("HoaDonDichVu");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhong", b =>
                {
                    b.Navigation("HoaDonDichVu");
                });

            modelBuilder.Entity("api.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDonDatPhong");
                });

            modelBuilder.Entity("api.Models.LoaiPhong", b =>
                {
                    b.Navigation("HoaDonDatPhong");

                    b.Navigation("Phong");
                });
#pragma warning restore 612, 618
        }
    }
}
