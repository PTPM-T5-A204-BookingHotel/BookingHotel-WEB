﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230912065542_update3")]
    partial class update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<double>("GiaDichVu")
                        .HasColumnType("float");

                    b.Property<string>("MoTaDichVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDichVu")
                        .IsRequired()
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

                    b.Property<int>("DichVuId")
                        .HasColumnType("int");

                    b.Property<int>("IdDichVu")
                        .HasColumnType("int");

                    b.Property<int>("IdKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("IdPhong")
                        .HasColumnType("int");

                    b.Property<int>("KhachHangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDatPhong")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTraPhong")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhongId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongNguoiLon")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongPhong")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTreEm")
                        .HasColumnType("int");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DichVuId");

                    b.HasIndex("KhachHangId");

                    b.HasIndex("PhongId");

                    b.ToTable("HoaDonDatPhong");
                });

            modelBuilder.Entity("api.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
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

                    b.Property<string>("Ten")
                        .IsRequired()
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

                    b.Property<int>("IdLoaiPhong")
                        .HasColumnType("int");

                    b.Property<int>("LoaiPhongId")
                        .HasColumnType("int");

                    b.Property<int>("SoPhong")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LoaiPhongId");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("api.Models.HoaDonDatPhong", b =>
                {
                    b.HasOne("api.Models.DichVu", "DichVu")
                        .WithMany()
                        .HasForeignKey("DichVuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("PhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DichVu");

                    b.Navigation("KhachHang");

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("api.Models.Phong", b =>
                {
                    b.HasOne("api.Models.LoaiPhong", "LoaiPhong")
                        .WithMany()
                        .HasForeignKey("LoaiPhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiPhong");
                });
#pragma warning restore 612, 618
        }
    }
}
