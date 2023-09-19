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
    public class ProvideNumberController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IProvideNumberRepository _provideRepo;

        public ProvideNumberController(MyContext context, IProvideNumberRepository provide)
        {
            _context = context;
            _provideRepo = provide;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_provideRepo.GetAll());
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
            try
            {
                return Ok(_provideRepo.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(ProvideNumberModel model)
        {
            try
            {
                return Ok(_provideRepo.Add(model));
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProvideNumberUpdate_GetModel model)
        {
            var provide = _context.ProvideNumbers.SingleOrDefault(e => e.ProvideNumberId == id);
            if (provide == null) return NotFound("Id not exist!");
            try
            {
                return Ok(_provideRepo.Update(model));
            }
            catch
            {
                return NotFound();
            }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var Lists = _context.ProvideNumbers.SingleOrDefault(e => e.ProvideNumberId == id);

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
