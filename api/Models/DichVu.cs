using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class DichVu
    {
        [Key]
        public int Id { get; set; }
        public string TenDichVu { get; set; } = string.Empty;
        public double GiaDichVu { get; set; }
        public string MoTaDichVu { get; set; } = string.Empty;

    }
}
