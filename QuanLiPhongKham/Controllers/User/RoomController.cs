using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly MyContext _context;

        public RoomController(MyContext context)
        {
            _context = context;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            var Lists = _context.Rooms.ToList();
            return Ok(Lists);
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            var Lists = _context.Rooms.SingleOrDefault(room => room.RoomId == id);

            if (Lists != null)
            {
                return Ok(Lists);
            }
            else { return NotFound(); }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(RoomModel model)
        {
            try
            {
                var room = new Room
                {
                    RoomName = model.RoomName,
                };

                _context.Add(room);
                _context.SaveChanges();
                return Ok(room);
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, RoomModel model)
        {
            var Lists = _context.Rooms.SingleOrDefault(room => room.RoomId == id);

            if (Lists != null)
            {
                Lists.RoomName = model.RoomName;
                Lists.Status = model.Status;
                _context.SaveChanges();
                return NoContent();
            }
            else { return NotFound(); }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var Lists = _context.Rooms.SingleOrDefault(room => room.RoomId == id);

            if (Lists != null)
            {
                _context.Rooms.Remove(Lists);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
