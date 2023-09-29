namespace bookinghotel_web.Models
{
    public class HoaDonDatPhongViewModel
    {
        public int Id { get; set; }
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public string TenKhachHang { get; set; } = string.Empty;
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongPhong { get; set; }
        public double? TongTien { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string HinhXacNhan { get; set; } = string.Empty;
        public int CCCD { get; set; }
        public int? KhachHangId { get; set; }
        public int? LoaiPhongId { get; set; }
    }
}
