using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Authentication
{
    public class LoginResponseModel
    {
        [Required]
        public string FullName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;
    }
}
