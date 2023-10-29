using System;
using System.Collections.Generic;

namespace api.Models;

public partial class HoaDonVatTu
{
    public string MaHd { get; set; } = null!;

    public string MaVt { get; set; } = null!;

    public int? SoLuongVt { get; set; }

    public int? ThanhTienVt { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual VatTu MaVtNavigation { get; set; } = null!;
}
