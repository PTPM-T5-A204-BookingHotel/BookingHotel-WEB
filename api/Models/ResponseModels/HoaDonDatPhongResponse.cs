namespace api.Models.ResponseModels
{
    public class HoaDonDatPhongResponse
    {
        public int Id { get; set; }
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public string TenKhachHang { get; set; } = string.Empty;
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongPhong { get; set; }
        public double TongTien { get; set; }
        public KhachHang? KhachHang { get; set; }
        public LoaiPhong? LoaiPhong { get; set; }
        public List<DichVuResponse> DichVus {  get; set; }
    }
}
