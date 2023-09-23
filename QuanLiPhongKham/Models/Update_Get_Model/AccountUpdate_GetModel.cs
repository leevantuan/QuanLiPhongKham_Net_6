using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Update_Get_Model
{
    public class AccountUpdate_GetModel
    {
        public int AccountId { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Img { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public int? RoleId { get; set; }
    }
}
