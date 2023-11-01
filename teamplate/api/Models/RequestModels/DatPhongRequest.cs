namespace api.Models.RequestModels
{
    public class DatPhongRequest
    {
        //public int MaDp { get; set; }

        public string? Hoten { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public int? SoLuongTgoLai { get; set; }

        public int? SoLuongNg { get; set; }

        public DateTime? ThoiGianNhanPhong { get; set; }
    }
}
