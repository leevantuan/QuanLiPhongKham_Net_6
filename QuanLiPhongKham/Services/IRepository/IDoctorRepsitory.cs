using QuanLiPhongKham.Models;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models.Update_Get_Model;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IDoctorRepsitory
    {
        public List<DoctorUpdate_GetModel> GetAll();

        public DoctorModel GetById(int id);

        public bool Add(DoctorModel role);

        public bool Update(DoctorUpdate_GetModel role);

        public bool Delete(int id);
    }
}
