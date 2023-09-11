namespace api.Models.RequestModels
{
    public class DichVuRequest
    {
        public string TenDichVu { get; set; } = string.Empty;
        public double GiaDichVu { get; set; }
        public string MoTaDichVu { get; set; } = string.Empty;
    }
}
