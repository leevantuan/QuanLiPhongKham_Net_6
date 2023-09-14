using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;

namespace QuanLiPhongKham.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class BHYTController : ControllerBase
    {
        private readonly MyContext _context;

        public BHYTController(MyContext context)
        {
            _context = context;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            var Lists = _context.Bhyts.ToList();
            return Ok(Lists);
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            var Lists = _context.Bhyts.SingleOrDefault(e => e.BHYTId == id);

            if (Lists != null)
            {
                return Ok(Lists);
            }
            else { return NotFound(); }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(BHYTModel model)
        {
            try
            {
                var Bhyt = new BHYT
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Birthday = model.Birthday,
                    Professtion = model.Professtion,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };

                _context.Add(Bhyt);
                _context.SaveChanges();
                return Ok(Bhyt);
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, BHYTModel model)
        {
            var Lists = _context.Bhyts.SingleOrDefault(e => e.BHYTId == id);

            if (Lists != null)
            {
                Lists.FullName = model.FullName;
                Lists.PhoneNumber = model.PhoneNumber;
                Lists.Address = model.Address;
                Lists.Birthday = model.Birthday;
                Lists.Professtion = model.Professtion;
                Lists.StartDate = model.StartDate;
                Lists.EndDate = model.EndDate;
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
            var Lists = _context.Bhyts.SingleOrDefault(e => e.BHYTId == id);

            if (Lists != null)
            {
                _context.Bhyts.Remove(Lists);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
