using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IProvideNumberRepository
    {
        public List<ProvideNumberUpdate_GetModel> GetAll();

        public ProvideNumberModel GetById(int id);

        public bool Add(ProvideNumberModel provide);

        public bool Update(ProvideNumberUpdate_GetModel provide);

        public bool Delete(int id);
    }
}
