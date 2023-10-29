using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Phong
{
    public int MaPh { get; set; }

    public string TenPh { get; set; } = null!;

    public int MaLp { get; set; }

    public int Tang { get; set; }

    public string? TinhTrangPh { get; set; }

    public DateTime? TgnhanPhong { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual LoaiPhong MaLpNavigation { get; set; } = null!;
}
