using System;
using System.Collections.Generic;

namespace api.Models;

public partial class HoaDonDichVu
{
    public string MaHd { get; set; } = null!;

    public string MaDv { get; set; } = null!;

    public int? SoLuongDv { get; set; }

    public int? ThanhTienDv { get; set; }

    public virtual DichVu MaDvNavigation { get; set; } = null!;

    public virtual HoaDon MaHdNavigation { get; set; } = null!;
}
