﻿namespace api.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string? Ten { get; set; } = string.Empty;
        public string? Email {  get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string? DiaChi { get; set; } = string.Empty;
        public string? CCCD { get; set; } = string.Empty;
        public int? SoDienThoai {  get; set; }
        public ICollection<HoaDonDatPhong>? HoaDonDatPhong { get; set; }
    }
}
