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
    public class ServiceController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IServiceRepository _serviceRepo;

        public ServiceController(MyContext context, IServiceRepository service)
        {
            _context = context;
            _serviceRepo = service;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
           try
            {
                return Ok(_serviceRepo.GetAll());
            }
            catch (Exception)
            {
               throw;
            }
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_serviceRepo.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(ServiceModel model)
        {
            try
            {
                return Ok(_serviceRepo.Add(model));
            }
            catch (Exception)
            {
                //return BadRequest("Create fail!");
                throw;
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, ServiceUpdate_GetModel model)
        {
            if(model.ServiceId != id)
            {
                return BadRequest("Id exist!");
            }
            try
            {
                return Ok(_serviceRepo.Update(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                return Ok(_serviceRepo.Delete(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
