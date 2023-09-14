using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data.Admin
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        public string Describe { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
