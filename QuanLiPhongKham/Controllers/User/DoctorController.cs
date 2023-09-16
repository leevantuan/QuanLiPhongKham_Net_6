using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Services.IRepository;
using System.Net;

namespace QuanLiPhongKham.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IDoctorRepsitory _doctorRepo;

        public DoctorController(MyContext context, IDoctorRepsitory doctor)
        {
            _context = context;
            _doctorRepo = doctor;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_doctorRepo.GetAll());
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
                return Ok(_doctorRepo.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(DoctorModel model)
        {
            try
            {
                return Ok(_doctorRepo.Add(model));
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, DoctorUpdate model)
        {
            var doctor = _context.Doctors.SingleOrDefault(e => e.DoctorId == id);
            if (doctor == null) return NotFound("Id not exist!");
            try
            {
                return Ok(_doctorRepo.Update(model));
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
            var Lists = _context.Doctors.SingleOrDefault(doctor => doctor.DoctorId == id);

            if (Lists != null)
            {
                _context.Doctors.Remove(Lists);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
