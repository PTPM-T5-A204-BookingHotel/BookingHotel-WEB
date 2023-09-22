namespace api.Models
{
    public class HoaDonDatPhong
    {
        public int Id { get; set; }
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public string TenKhachHang {  get; set; } = string.Empty;
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongPhong { get; set; }
        public double? TongTien { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
        public virtual LoaiPhong? LoaiPhong { get; set;}
        public ICollection<HoaDonDatPhongDichVu>? HoaDonDichVu { get; set; }
    }
}
