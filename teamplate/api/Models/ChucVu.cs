using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ChucVu
{
    public int MaCv { get; set; }

    public string TenCv { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
