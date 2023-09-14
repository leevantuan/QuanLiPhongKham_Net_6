using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly MyContext _context;

        public ServiceController(MyContext context)
        {
            _context = context;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            var ListServices = _context.Services.ToList();
            return Ok(ListServices);
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            var ListServices = _context.Services.SingleOrDefault(service => service.ServiceId == id);

            if (ListServices != null)
            {
                return Ok(ListServices);
            }
            else { return NotFound(); }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(ServiceModel model)
        {
            try
            {
                var service = new Service 
                {
                    ServiceName = model.ServiceName,
                    Price = model.Price,
                    RoomId = model.RoomId,
                };

                _context.Add(service);
                _context.SaveChanges();
                return Ok(service);
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, ServiceModel model)
        {
            var Lists = _context.Services.SingleOrDefault(service => service.ServiceId == id);

            if (Lists != null)
            {
                Lists.ServiceName = model.ServiceName;
                Lists.Price = model.Price;
                Lists.RoomId = model.RoomId;
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
            var Lists = _context.Services.SingleOrDefault(service => service.ServiceId == id);

            if (Lists != null)
            {
                _context.Services.Remove(Lists);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
