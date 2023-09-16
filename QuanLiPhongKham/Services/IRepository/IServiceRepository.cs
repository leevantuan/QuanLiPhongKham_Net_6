using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IServiceRepository
    {
        public List<ServiceModel> GetAll();

        public ServiceModel GetById(int id);

        public bool Add(ServiceModel role);

        public bool Update(ServiceUpdate role);

        public bool Delete(int id);
    }
}
