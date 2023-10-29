using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VatTu
{
    public string MaVt { get; set; } = null!;

    public string TenVt { get; set; } = null!;

    public string? ThuongHieu { get; set; }

    public string? DonViTinh { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public int? GiaNhap { get; set; }

    public string? AnhVt { get; set; }

    public virtual ICollection<HoaDonVatTu> HoaDonVatTus { get; set; } = new List<HoaDonVatTu>();

    public virtual ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();
}
