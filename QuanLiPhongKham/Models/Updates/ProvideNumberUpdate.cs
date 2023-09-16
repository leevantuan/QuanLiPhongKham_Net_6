using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Updates
{
    public class ProvideNumberUpdate
    {
        [Required]
        public int ProvideNumberId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string StartDate { get; set; } = string.Empty;

        [Required]
        public string EndtDate { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        public bool Status { get; set; }

        public int? ServiceId { get; set; }
    }
}
