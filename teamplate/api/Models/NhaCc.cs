using System;
using System.Collections.Generic;

namespace api.Models;

public partial class NhaCc
{
    public string MaNcc { get; set; } = null!;

    public string TenNcc { get; set; } = null!;

    public string DiaChiNcc { get; set; } = null!;

    public string Sdtncc { get; set; } = null!;

    public string GioiTinhNcc { get; set; } = null!;

    public virtual ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();
}
