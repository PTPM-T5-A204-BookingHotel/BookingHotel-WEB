using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public partial class QlkhachSanContext : DbContext
{
    public QlkhachSanContext()
    {
    }

    public QlkhachSanContext(DbContextOptions<QlkhachSanContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }
    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        var strConn = config["ConnectionStrings:DefaultConnection"];
        return strConn;
    }
    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonDichVu> HoaDonDichVus { get; set; }

    public virtual DbSet<HoaDonVatTu> HoaDonVatTus { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<ManHinh> ManHinhs { get; set; }

    public virtual DbSet<NhaCc> NhaCcs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NhapKho> NhapKhos { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<VatTu> VatTus { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("pk_MaCV_ChucVu");

            entity.ToTable("ChucVu");

            entity.HasIndex(e => e.TenCv, "UQ__ChucVu__4CF92206B7DF391F").IsUnique();

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(30)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDp).HasName("pk_MaDP_DatPhong");

            entity.ToTable("DatPhong");

            entity.Property(e => e.MaDp).HasColumnName("MaDP");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.HasIndex(e => e.Sdt).IsUnique();
            entity.Property(e => e.SoLuongTgoLai).HasColumnName("SoLuongTGoLai");
            entity.Property(e => e.ThoiGianNhanPhong).HasColumnType("date");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("pk_MaDV_DichVu");

            entity.ToTable("DichVu");

            entity.Property(e => e.MaDv)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.GiaDv)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GiaDV");
            entity.Property(e => e.MotaDv).HasColumnName("MotaDV");
            entity.Property(e => e.TenDv).HasColumnName("TenDV");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("pk_MaHD_HoaDon");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.GiamGia).HasDefaultValueSql("((0))");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaPh).HasColumnName("MaPH");
            entity.Property(e => e.SoNgayLuuTru).HasDefaultValueSql("((0))");
            entity.Property(e => e.TgnhanPhong)
                .HasColumnType("datetime")
                .HasColumnName("TGNhanPhong");
            entity.Property(e => e.TgtraPhong)
                .HasColumnType("datetime")
                .HasColumnName("TGTraPhong");
            entity.Property(e => e.ThanhTienHd)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ThanhTienHD");
            entity.Property(e => e.TongTien).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaKH_HoaDon");

            entity.HasOne(d => d.MaPhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaPh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaPH_HoaDon");
        });

        modelBuilder.Entity<HoaDonDichVu>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaDv }).HasName("pk_MaHD_MaDV_HoaDon_DichVu");

            entity.ToTable("HoaDon_DichVu");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaDv)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaDV");
            entity.Property(e => e.SoLuongDv).HasColumnName("SoLuongDV");
            entity.Property(e => e.ThanhTienDv).HasColumnName("ThanhTienDV");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.HoaDonDichVus)
                .HasForeignKey(d => d.MaDv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaDV_HoaDon_DichVu");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.HoaDonDichVus)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaHD_HoaDon_DichVu");
        });

        modelBuilder.Entity<HoaDonVatTu>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaVt }).HasName("pk_MaHD_MaVT_HoaDon_VatTu");

            entity.ToTable("HoaDon_VatTu");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaHD");
            entity.Property(e => e.MaVt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaVT");
            entity.Property(e => e.SoLuongVt).HasColumnName("SoLuongVT");
            entity.Property(e => e.ThanhTienVt).HasColumnName("ThanhTienVT");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.HoaDonVatTus)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaHD_HoaDon_VatTu");

            entity.HasOne(d => d.MaVtNavigation).WithMany(p => p.HoaDonVatTus)
                .HasForeignKey(d => d.MaVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaVT_HoaDon_VatTu");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("pk_MaKH_KhachHang");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Cccdkh, "UQ__KhachHan__DAF61A70FF7E3539").IsUnique();

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.AnhKh).HasColumnName("AnhKH");
            entity.Property(e => e.Cccdkh)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CCCDKH");
            entity.Property(e => e.DiaChiKh).HasColumnName("DiaChiKH");
            entity.Property(e => e.EmailKh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EmailKH");
            entity.Property(e => e.GioiTinhKh)
                .HasMaxLength(5)
                .HasColumnName("GioiTinhKH");
            entity.Property(e => e.HoTenKh)
                .HasMaxLength(30)
                .HasColumnName("HoTenKH");
            entity.Property(e => e.NgaySinhKh)
                .HasColumnType("date")
                .HasColumnName("NgaySinhKH");
            entity.Property(e => e.Sdtkh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDTKH");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLp).HasName("pk_MaLP_LoaiPhong");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MaLp).HasColumnName("MaLP");
            entity.Property(e => e.GiaPh)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GiaPH");
            entity.Property(e => e.TenLp).HasColumnName("TenLP");
        });

        modelBuilder.Entity<ManHinh>(entity =>
        {
            entity.HasKey(e => e.MaMh).HasName("pk_MaMH_ManHinh");

            entity.ToTable("ManHinh");

            entity.Property(e => e.MaMh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaMH");
            entity.Property(e => e.TenMh).HasColumnName("TenMH");

            entity.HasMany(d => d.TenTks).WithMany(p => p.MaMhs)
                .UsingEntity<Dictionary<string, object>>(
                    "TaiKhoanManHinh",
                    r => r.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("TenTk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_TenTK_TaiKhoan_ManHinh"),
                    l => l.HasOne<ManHinh>().WithMany()
                        .HasForeignKey("MaMh")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_MaMH_TaiKhoan_ManHinh"),
                    j =>
                    {
                        j.HasKey("MaMh", "TenTk").HasName("pk_MaMH_TenTK_TaiKhoan_ManHinh");
                        j.ToTable("TaiKhoan_ManHinh");
                        j.IndexerProperty<string>("MaMh")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("MaMH");
                        j.IndexerProperty<string>("TenTk")
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("TenTK");
                    });
        });

        modelBuilder.Entity<NhaCc>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("pk_MaNCC_NhaCC");

            entity.ToTable("NhaCC");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaNCC");
            entity.Property(e => e.DiaChiNcc)
                .HasMaxLength(100)
                .HasColumnName("DiaChiNCC");
            entity.Property(e => e.Sdtncc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDTNCC");
            entity.Property(e => e.TenNcc).HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("pk_MaNV_NhanVien");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Cccdnv, "UQ__NhanVien__DAF660C8139DE577").IsUnique();

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.AnhNv).HasColumnName("AnhNV");
            entity.Property(e => e.Cccdnv)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CCCDNV");
            entity.Property(e => e.DiaChiNv).HasColumnName("DiaChiNV");
            entity.Property(e => e.EmailNv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EmailNV");
            entity.Property(e => e.GioiTinhNv)
                .HasMaxLength(5)
                .HasColumnName("GioiTinhNV");
            entity.Property(e => e.HoTenNv)
                .HasMaxLength(50)
                .HasColumnName("HoTenNV");
            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.NgaySinhNv)
                .HasColumnType("date")
                .HasColumnName("NgaySinhNV");
            entity.Property(e => e.SoDienThoaiNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SoDienThoaiNV");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaCV_NhanVien");
        });

        modelBuilder.Entity<NhapKho>(entity =>
        {
            entity.HasKey(e => e.MaNk).HasName("pk_MaNK_NhapKho");

            entity.ToTable("NhapKho");

            entity.Property(e => e.MaNk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNK");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaVt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaVT");
            entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");
            entity.Property(e => e.ThoiGianNk)
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianNK");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.NhapKhos)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("fk_MaNCC_NhapKho");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.NhapKhos)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("fk_MaNV_NhapKho");

            entity.HasOne(d => d.MaVtNavigation).WithMany(p => p.NhapKhos)
                .HasForeignKey(d => d.MaVt)
                .HasConstraintName("fk_MaVT_NhapKho");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPh).HasName("pk_MaPH_Phong");

            entity.ToTable("Phong");

            entity.HasIndex(e => e.TenPh, "UQ__Phong__4CF9C7CF37E9D967").IsUnique();

            entity.Property(e => e.MaPh).HasColumnName("MaPH");
            entity.Property(e => e.MaLp).HasColumnName("MaLP");
            entity.Property(e => e.TenPh)
                .HasMaxLength(50)
                .HasColumnName("TenPH");
            entity.Property(e => e.TgnhanPhong)
                .HasColumnType("datetime")
                .HasColumnName("TGNhanPhong");
            entity.Property(e => e.TinhTrangPh)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Trống')")
                .HasColumnName("TinhTrangPH");

            entity.HasOne(d => d.MaLpNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaLp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MaLP_Phong");
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("pk_MaQuyen_Quyen");

            entity.ToTable("Quyen");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TenTk).HasName("pk_TenTK_TaiKhoan");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TenTk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenTK");
            entity.Property(e => e.AnhTk).HasColumnName("AnhTK");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("fk_MaNV_TaiKhoan");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaQuyen)
                .HasConstraintName("fk_MaQuyen_TaiKhoan");
        });

        modelBuilder.Entity<VatTu>(entity =>
        {
            entity.HasKey(e => e.MaVt).HasName("pk_MaVT_VatTu");

            entity.ToTable("VatTu");

            entity.Property(e => e.MaVt)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MaVT");
            entity.Property(e => e.AnhVt).HasColumnName("AnhVT");
            entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");
            entity.Property(e => e.DonViTinh).HasMaxLength(10);
            entity.Property(e => e.GiaNhap).HasDefaultValueSql("((0))");
            entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");
            entity.Property(e => e.TenVt).HasColumnName("TenVT");
            entity.Property(e => e.ThuongHieu).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
