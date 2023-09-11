namespace api.Models.ResponseModels
{
    public class KhachHangResponse
    {
        public int Id { get; set; }
        public string Ten { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; } = string.Empty;
        public string CCCD { get; set; } = string.Empty;
        public int SoDienThoai { get; set; }
    }
}
