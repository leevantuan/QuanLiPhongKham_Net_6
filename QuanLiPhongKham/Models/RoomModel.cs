using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class RoomModel
    {
        [Required]
        public string RoomName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
