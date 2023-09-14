using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models
{
    public class AccountModel
    {
        [Required]
        public string FullName { get; set; } = String.Empty;

        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        public string Img { get; set; } = String.Empty;

        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [Required]
        public string UserName { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;

        public bool Status { get; set; } = true;

        public int? RoleId { get; set; }
    }
}
