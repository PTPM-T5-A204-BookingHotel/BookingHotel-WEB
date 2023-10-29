using System;
using System.Collections.Generic;

namespace api.Models;

public partial class NhapKho
{
    public string MaNk { get; set; } = null!;

    public int? MaNv { get; set; }

    public string? MaNcc { get; set; }

    public string? MaVt { get; set; }

    public DateTime ThoiGianNk { get; set; }

    public int? SoLuong { get; set; }

    public virtual NhaCc? MaNccNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual VatTu? MaVtNavigation { get; set; }
}
