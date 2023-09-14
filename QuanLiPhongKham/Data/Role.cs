using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = String.Empty;

        public string Describe { get; set; } = String.Empty;

        public bool Status { get; set; } = true;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
