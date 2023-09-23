using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
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
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<HoaDonDatPhong> HoaDonDatPhong { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<LoaiPhong> LoaiPhong { get; set;}
        public DbSet<Phong> Phong { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDonDatPhongDichVu>().HasKey(p => new { p.HoaDonDatPhongId, p.DichVuId });
            modelBuilder.Entity<HoaDonDatPhongDichVu>().HasOne(p => p.HoaDonDatPhongs).WithMany(hd => hd.HoaDonDichVu).HasForeignKey(hddv => hddv.HoaDonDatPhongId);
            modelBuilder.Entity<HoaDonDatPhongDichVu>().HasOne(p => p.DichVus).WithMany(dv => dv.HoaDonDichVu).HasForeignKey(hddv => hddv.DichVuId);
        }
    }
}
