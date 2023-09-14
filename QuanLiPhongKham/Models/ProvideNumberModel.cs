using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class ProvideNumberModel
    {
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
    }
}
