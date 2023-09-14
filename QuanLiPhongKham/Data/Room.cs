using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [Required]
        public int RoomId { get; set; }

        [Required]
        public string RoomName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
