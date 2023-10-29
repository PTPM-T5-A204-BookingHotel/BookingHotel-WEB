using System;
using System.Collections.Generic;

namespace api.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string Cccdkh { get; set; } = null!;

    public string HoTenKh { get; set; } = null!;

    public string GioiTinhKh { get; set; } = null!;

    public string DiaChiKh { get; set; } = null!;

    public string Sdtkh { get; set; } = null!;

    public string? AnhKh { get; set; }

    public string? EmailKh { get; set; }

    public DateTime NgaySinhKh { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
