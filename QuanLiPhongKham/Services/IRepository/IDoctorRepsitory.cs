using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Data.User;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IDoctorRepsitory
    {
        public List<DoctorUpdate> GetAll();

        public DoctorModel GetById(int id);

        public bool Add(DoctorModel role);

        public bool Update(DoctorUpdate role);

        public bool Delete(int id);
    }
}
