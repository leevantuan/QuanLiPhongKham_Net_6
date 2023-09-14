using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data.User
{
    [Table("Services")]
    public class Service
    {
        [Key]
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; } = double.MaxValue;

        public bool Status { get; set; } = true;

        public int? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        public virtual ICollection<ProvideNumber> ProvideNumbers { get; set; }
    }
}
