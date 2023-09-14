using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class ServiceModel
    {
        [Required]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; } = double.MaxValue;

        public bool Status { get; set; }

        public int? RoomId { get; set; }
    }
}
