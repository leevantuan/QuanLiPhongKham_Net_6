using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLiPhongKham.Data
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string FullName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Img { get; set; } = String.Empty;

        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public string UserName { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;

        public bool Status { get; set; } = true;

        public int? RoleId {  get; set; } 
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
