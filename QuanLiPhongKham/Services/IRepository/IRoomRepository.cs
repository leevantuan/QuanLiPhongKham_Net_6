using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IRoomRepository
    {
        public List<RoomUpdate> GetAll();

        public RoomModel GetById(int id);

        public bool Add(RoomModel room);

        public bool Update(RoomUpdate room);

        public bool Delete(int id);
    }
}
