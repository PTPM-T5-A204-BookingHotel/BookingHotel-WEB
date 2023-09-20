namespace api.Models
{
    public class LoaiPhong
    {
        public int Id { get; set; }
        public string? Ten { get; set; } = string.Empty;
        public Double? GiaPhong { get; set; }
        public string? Mota { get; set; }
    }
}
