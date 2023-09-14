using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data
{
    [Table("ProvideNumbers")]
    public class ProvideNumber
    {
        [Key]
        [Required]
        public int ProvideNumberId { get; set; }

        [Required]
        public string FullName { get; set; } = String.Empty;

        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public string StartDate { get; set; } = String.Empty;

        [Required]
        public string EndtDate { get; set; } = String.Empty;

        [Required]
        public double Price { get; set; }

        public bool Status { get; set; }

        public int? ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
