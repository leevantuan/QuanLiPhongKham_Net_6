using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Update_Get_Model
{
    public class RoleUpdate_GetModel
    {

        public int RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public string Describe { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
