using System;
using System.Collections.Generic;

namespace api.Models;

public partial class DichVu
{
    public string MaDv { get; set; } = null!;

    public string TenDv { get; set; } = null!;

    public int? GiaDv { get; set; }

    public string? MotaDv { get; set; }

    public virtual ICollection<HoaDonDichVu> HoaDonDichVus { get; set; } = new List<HoaDonDichVu>();
}
