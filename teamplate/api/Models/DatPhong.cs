using System;
using System.Collections.Generic;

namespace api.Models;

public partial class DatPhong
{
    public int MaDp { get; set; }

    public string? Hoten { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public int? SoLuongTgoLai { get; set; }

    public int? SoLuongNg { get; set; }

    public DateTime? ThoiGianNhanPhong { get; set; }
    public string? HinhAnh {  get; set; }
    public string? TinhtrangDP {  get; set; }
}
