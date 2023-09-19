using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(MyContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public bool Add(RoomModel room)
        {
            try
            {
                var _room = _mapper.Map<Room>(room);
                _context.Rooms.Add(_room);
                var result = _context.SaveChanges();
                if(result == 1) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var room = _context.Rooms.Find(id);
                if(room == null) return false;
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RoomUpdate_GetModel> GetAll()
        {
            try
            {
                List<Room> AllRoom = _context.Rooms.ToList();
                return _mapper.Map<List<RoomUpdate_GetModel>>(AllRoom);
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public RoomModel GetById(int id)
        {
            try
            {
                var Room = _context.Rooms.Find(id);
                return _mapper.Map<RoomModel>(Room);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(RoomUpdate_GetModel room)
        {
            var _room = _context.Rooms.FirstOrDefault(e => e.RoomId == room.RoomId);
            try
            {
                _room.RoomName = room.RoomName;
                _room.Status = room.Status;
                var result = _context.SaveChanges();
                if(result == 1) return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
