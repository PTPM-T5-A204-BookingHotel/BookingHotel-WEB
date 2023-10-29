using System;
using System.Collections.Generic;

namespace api.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string HoTenNv { get; set; } = null!;

    public int MaCv { get; set; }

    public string GioiTinhNv { get; set; } = null!;

    public string Cccdnv { get; set; } = null!;

    public string SoDienThoaiNv { get; set; } = null!;

    public DateTime NgaySinhNv { get; set; }

    public string DiaChiNv { get; set; } = null!;

    public string? AnhNv { get; set; }

    public string? EmailNv { get; set; }

    public virtual ChucVu MaCvNavigation { get; set; } = null!;

    public virtual ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
