using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IRoomRepository _roomRepo;

        public RoomController(MyContext context, IRoomRepository room)
        {
            _context = context;
            _roomRepo = room;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_roomRepo.GetAll());
            }
            catch
            {
                return NotFound();
            }
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            try
            {
                return Ok(_roomRepo.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(RoomModel model)
        {
            try
            {
                return Ok(_roomRepo.Add(model));
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, RoomUpdate_GetModel model)
        {
            var _rooms = _context.Rooms.SingleOrDefault(room => room.RoomId == id);
            if(_rooms == null) { return  BadRequest(); }
            try
            {
                return Ok(_roomRepo.Update(model));
            }
            catch
            {
                return BadRequest();
            }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var _rooms = _context.Rooms.SingleOrDefault(room => room.RoomId == id);
            if (_rooms == null) { return BadRequest(); }
            try
            {
                return Ok(_roomRepo.Delete(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
