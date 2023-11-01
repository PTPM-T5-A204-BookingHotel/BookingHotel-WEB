namespace api.Models.ResponseModels
{
    public class PhongResponse
    {
        public int MaPh { get; set; }

        public string TenPh { get; set; } = null!;

        public int MaLp { get; set; }

        public int Tang { get; set; }

        public string? TinhTrangPh { get; set; }

        public DateTime? TgnhanPhong { get; set; }
        public List<HoaDon> hoaDons { get; set; } = new List<HoaDon>();
    }
}
