using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class HoaDonDatPhong
    {
        [Key]
        public int Id { get; set; }
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public double TongTien { get; set; }
        public int IdPhong { get; set; }
        public virtual Phong Phong { get; set; } = new Phong();
        public int IdKhachHang { get; set; }
        public virtual KhachHang KhachHang { get; set; } = new KhachHang();    
        public int IdDichVu {  get; set; }
        public virtual DichVu DichVu { get;set; } = new DichVu();

    }
}
