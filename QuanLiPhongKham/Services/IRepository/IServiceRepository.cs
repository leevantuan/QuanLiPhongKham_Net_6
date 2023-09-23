using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IServiceRepository
    {
        public List<ServiceUpdate_GetModel> GetAll();

        public ServiceModel GetById(int id);

        public bool Add(ServiceModel role);

        public bool Update(ServiceUpdate_GetModel role);

        public bool Delete(int id);
    }
}
