namespace api.Models.RequestModels
{
    public class HoaDonDatPhongRequest
    {
        public DateTime NgayDatPhong { get; set; }
        public DateTime NgayTraPhong { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public double TongTien { get; set; }
    }
}
