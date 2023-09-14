using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class DoctorModel
    {
        [Required]
        public string DoctorName { get; set; } = String.Empty;

        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public string Address { get; set; } = String.Empty;

        [Required]
        public string BirthDay { get; set; } = String.Empty;

        [Required]
        public string DateWork { get; set; } = String.Empty;

        [Required]
        public string Professtional { get; set; } = String.Empty;

        public bool Status { get; set; }

        public int? RoomId { get; set; }
    }
}
