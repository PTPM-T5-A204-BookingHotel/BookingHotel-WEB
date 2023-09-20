namespace api.Models.RequestModels
{
    public class HoaDonDatPhongRequest
    {
        public string TenKhachHang { get; set; } = string.Empty;
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongPhong { get; set; }
        public double TongTien { get; set; }
    }
}
