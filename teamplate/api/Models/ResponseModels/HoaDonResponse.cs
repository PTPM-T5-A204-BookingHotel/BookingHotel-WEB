namespace api.Models.ResponseModels
{
    public class HoaDonResponse
    {
        public string MaHd { get; set; } = null!;

        public int MaKh { get; set; }

        public int MaPh { get; set; }

        public DateTime TgnhanPhong { get; set; }

        public DateTime TgtraPhong { get; set; }

        public int? SoNgayLuuTru { get; set; }

        public int? TongTien { get; set; }

        public int? GiamGia { get; set; }

        public int? ThanhTienHd { get; set; }
        public List<HoaDonDichVu> hoaDonDichVus { get; set; } = new List<HoaDonDichVu>();
        public List<HoaDonVatTu> hoaDonVatTus { get; set; } = new List<HoaDonVatTu>();
    }
}
