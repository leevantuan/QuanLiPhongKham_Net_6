using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data.User
{
    [Table("BHYTS")]
    public class BHYT
    {
        [Key]
        [Required]
        public int BHYTId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Birthday { get; set; } = string.Empty;

        [Required]
        public string Professtion { get; set; } = string.Empty;

        [Required]
        public string StartDate { get; set; } = string.Empty;

        [Required]
        public string EndDate { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
