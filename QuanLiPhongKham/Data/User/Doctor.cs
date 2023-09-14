using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data.User
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string DoctorName { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string BirthDay { get; set; } = string.Empty;

        [Required]
        public string DateWork { get; set; } = string.Empty;

        [Required]
        public string Professtional { get; set; } = string.Empty;

        public bool Status { get; set; }

        public int? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }

}
