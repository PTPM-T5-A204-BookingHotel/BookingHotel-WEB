namespace api.Models.RequestModels
{
    public class HoaDonRequest
    {
        public string MaHd { get; set; } = string.Empty;
        public int MaKh { get; set; }

        public int MaPh { get; set; }

        public DateTime TgnhanPhong { get; set; }

        public DateTime TgtraPhong { get; set; }

        public int? SoNgayLuuTru { get; set; }

        public int? TongTien { get; set; }

        public int? GiamGia { get; set; }

        public int? ThanhTienHd { get; set; }
    }
}
