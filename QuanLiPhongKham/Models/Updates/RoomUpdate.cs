using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Updates
{
    public class RoomUpdate
    {
        public int RoomId { get; set; }

        [Required]
        public string RoomName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
