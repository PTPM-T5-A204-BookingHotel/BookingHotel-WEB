using System;
using System.Collections.Generic;

namespace api.Models;

public partial class LoaiPhong
{
    public int MaLp { get; set; }

    public string TenLp { get; set; } = null!;

    public int? GiaPh { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
