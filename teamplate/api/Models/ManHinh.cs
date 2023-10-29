using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ManHinh
{
    public string MaMh { get; set; } = null!;

    public string TenMh { get; set; } = null!;

    public virtual ICollection<TaiKhoan> TenTks { get; set; } = new List<TaiKhoan>();
}
