

namespace api.Models.ResponseModels
{
    public class LoaiPhongResponse
    {
        public int MaLp { get; set; }

        public string TenLp { get; set; } = null!;

        public int? GiaPh { get; set; }
        List<Phong> phongs { get; set; } = new List<Phong>();
    }
}
