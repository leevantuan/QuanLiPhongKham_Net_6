using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Login_User
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; }
    }
}
