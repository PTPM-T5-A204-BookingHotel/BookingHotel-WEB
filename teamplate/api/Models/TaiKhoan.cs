using System;
using System.Collections.Generic;

namespace api.Models;

public partial class TaiKhoan
{
    public string TenTk { get; set; } = null!;

    public int? MaNv { get; set; }

    public string MatKhau { get; set; } = null!;

    public int? MaQuyen { get; set; }

    public string? AnhTk { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual Quyen? MaQuyenNavigation { get; set; }

    public virtual ICollection<ManHinh> MaMhs { get; set; } = new List<ManHinh>();
}
