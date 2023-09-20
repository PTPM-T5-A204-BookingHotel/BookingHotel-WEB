namespace api.Models.ResponseModels
{
    public class HoaDonDatPhongResponse
    {
        public int Id { get; set; }
        public string TenKhachHang { get; set; } = string.Empty;
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongPhong { get; set; }
        public double TongTien { get; set; }
        public int IdPhong { get; set; }
        public int IdKhachHang { get; set; }
        public int IdDichVu { get; set; }
    }
}
