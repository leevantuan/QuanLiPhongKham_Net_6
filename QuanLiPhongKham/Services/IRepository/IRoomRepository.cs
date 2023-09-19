using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IRoomRepository
    {
        public List<RoomUpdate_GetModel> GetAll();

        public RoomModel GetById(int id);

        public bool Add(RoomModel room);

        public bool Update(RoomUpdate_GetModel room);

        public bool Delete(int id);
    }
}
