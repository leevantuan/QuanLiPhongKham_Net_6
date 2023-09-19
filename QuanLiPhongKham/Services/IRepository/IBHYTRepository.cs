using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IBHYTRepository
    {
        public List<BHYTUpdate_GetModel> GetAll();

        public BHYTModel GetById(int id);

        public bool Add(BHYTModel bhyt);

        public bool Update(BHYTUpdate_GetModel bhyt);

        public bool Delete(int id);
    }
}
