using System;
using System.Collections.Generic;

namespace api.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public int MaKh { get; set; }

    public int MaPh { get; set; }

    public DateTime TgnhanPhong { get; set; }

    public DateTime TgtraPhong { get; set; }

    public int? SoNgayLuuTru { get; set; }

    public int? TongTien { get; set; }

    public int? GiamGia { get; set; }

    public int? ThanhTienHd { get; set; }

    public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; set; } = new List<HoaDonDichVu>();

    public virtual ICollection<HoaDonVatTu> HoaDonVatTus { get; set; } = new List<HoaDonVatTu>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual Phong MaPhNavigation { get; set; } = null!;
}
