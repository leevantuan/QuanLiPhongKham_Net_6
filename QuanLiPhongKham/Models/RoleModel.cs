using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class RoleModel
    {
        [Required]
        public string RoleName { get; set; } = String.Empty;

        public string Describe { get; set; } = String.Empty;

        public bool Status { get; set; } = true;

    }
}
