using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.View_Model
{
    public class RoleView
    {

        public int RoleId { get; set; }

        public string RoleName { get; set; } = String.Empty;

        public string Describe { get; set; } = String.Empty;

        public bool Status { get; set; } = true;
    }
}
