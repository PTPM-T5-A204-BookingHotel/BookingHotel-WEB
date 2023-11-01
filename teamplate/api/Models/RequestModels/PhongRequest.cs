namespace api.Models.RequestModels
{
    public class PhongRequest
    {
        public int MaPh { get; set; }

        public string TenPh { get; set; } = null!;

        public int MaLp { get; set; }

        public int Tang { get; set; }

        public string? TinhTrangPh { get; set; }

        public DateTime? TgnhanPhong { get; set; }
    }
}
