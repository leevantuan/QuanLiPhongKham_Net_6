using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Update_Get_Model
{
    public class ServiceUpdate_GetModel
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public double Price { get; set; } = double.MaxValue;

        public bool Status { get; set; } = true;

        public int RoomId { get; set; }
    }
}
