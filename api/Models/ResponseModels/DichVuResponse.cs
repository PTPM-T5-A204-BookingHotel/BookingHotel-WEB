namespace api.Models.ResponseModels
{
    public class DichVuResponse
    {
        public int Id { get; set; }
        public string TenDichVu { get; set; } = string.Empty;
        public double GiaDichVu { get; set; }
        public string MoTaDichVu { get; set; } = string.Empty;
    }
}
