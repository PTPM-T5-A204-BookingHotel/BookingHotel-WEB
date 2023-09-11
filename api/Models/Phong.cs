using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Phong
    {
        [Key]
        public int Id { get; set; }
        public int SoPhong { get; set; }
        public bool TrangThai { get; set; }
        public int IdLoaiPhong { get; set; }
        public virtual LoaiPhong LoaiPhong { get; set; } = new LoaiPhong();
    }
}
