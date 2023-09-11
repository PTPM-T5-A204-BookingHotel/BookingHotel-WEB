using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class LoaiPhong
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; } = string.Empty;
    }
}
