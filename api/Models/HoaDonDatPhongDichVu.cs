namespace api.Models
{
    public class HoaDonDatPhongDichVu
    {
        public int HoaDonDatPhongId { get; set; }
        public int DichVuId { get; set; }
        public HoaDonDatPhong? HoaDonDatPhongs { get; set; }
        public DichVu? DichVus { get; set;}
    }
}
