namespace api.Models.RequestModels
{
    public class LoaiPhongRequest
    {
        public int MaLp { get; set; }

        public string TenLp { get; set; } = null!;

        public int? GiaPh { get; set; }
    }
}
