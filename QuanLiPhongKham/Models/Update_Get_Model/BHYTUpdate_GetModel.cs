using System.ComponentModel.DataAnnotations;

namespace QuanLiPhongKham.Models.Update_Get_Model
{
    public class BHYTUpdate_GetModel
    {

        public int BHYTId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Birthday { get; set; } = string.Empty;

        public string Professtion { get; set; } = string.Empty;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
