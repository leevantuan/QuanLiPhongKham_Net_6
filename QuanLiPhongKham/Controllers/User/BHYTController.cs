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
    public class BHYTController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IBHYTRepository _bhytRepo;

        public BHYTController(MyContext context, IBHYTRepository bhyt)
        {
            _context = context;
            _bhytRepo = bhyt;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_bhytRepo.GetAll());
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
                return Ok(_bhytRepo.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(BHYTModel model)
        {
            try
            {
                return Ok(_bhytRepo.Add(model));
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, BHYTUpdate_GetModel model)
        {
            var bhyt = _context.Bhyts.SingleOrDefault(e => e.BHYTId == id);
            if (bhyt == null) return NotFound("Id not exist!");
            try
            {
                return Ok(_bhytRepo.Update(model));
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
