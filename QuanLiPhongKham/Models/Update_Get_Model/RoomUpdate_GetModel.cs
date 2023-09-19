using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Update_Get_Model
{
    public class RoomUpdate_GetModel
    {
        public int RoomId { get; set; }

        [Required]
        public string RoomName { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
