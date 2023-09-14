using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvideNumberController : ControllerBase
    {
        private readonly MyContext _context;

        public ProvideNumberController(MyContext context)
        {
            _context = context;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            var Lists = _context.ProvideNumbers.ToList();
            return Ok(Lists);
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            var Lists = _context.ProvideNumbers.SingleOrDefault(provide => provide.ProvideNumberId == id);

            if (Lists != null)
            {
                return Ok(Lists);
            }
            else { return NotFound(); }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(ProvideNumberModel model)
        {
            try
            {
                var provide = new ProvideNumber
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    StartDate = model.StartDate,
                    EndtDate = model.EndtDate,
                    Price = model.Price,
                    ServiceId = model.ServiceId,
                };

                _context.Add(provide);
                _context.SaveChanges();
                return Ok(provide);
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProvideNumberModel model)
        {
            var Lists = _context.ProvideNumbers.SingleOrDefault(provide => provide.ProvideNumberId == id);

            if (Lists != null)
            {
                Lists.FullName = model.FullName;
                Lists.PhoneNumber = model.PhoneNumber;
                Lists.StartDate = model.StartDate;
                Lists.EndtDate = model.EndtDate;
                Lists.Price = model.Price;
                Lists.ServiceId = model.ServiceId;
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
            var Lists = _context.ProvideNumbers.SingleOrDefault(provide => provide.ProvideNumberId == id);

            if (Lists != null)
            {
                _context.ProvideNumbers.Remove(Lists);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
