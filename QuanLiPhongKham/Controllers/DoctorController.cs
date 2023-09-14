using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using System.Net;

namespace QuanLiPhongKham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly MyContext _context;

        public DoctorController(MyContext context)
        {
            _context = context;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAll()
        {
            var Lists = _context.Doctors.ToList();
            return Ok(Lists);
        }

        //get data by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SingleOrDefault Methor tìm kiếm có hoặc không
            var Lists = _context.Doctors.SingleOrDefault(doctor => doctor.DoctorId == id);

            if (Lists != null)
            {
                return Ok(Lists);
            }
            else { return NotFound(); }
        }

        //post data create
        [HttpPost]
        public IActionResult CreateNew(DoctorModel model)
        {
            try
            {
                var doctor = new Doctor
                {
                    DoctorName = model.DoctorName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    BirthDay = model.BirthDay,
                    DateWork = model.DateWork,
                    Professtional = model.Professtional,
                    RoomId = model.RoomId,
                };

                _context.Add(doctor);
                _context.SaveChanges();
                return Ok(doctor);
            }
            catch
            {
                return BadRequest();
            }

        }

        //put data update
        [HttpPut("{id}")]
        public IActionResult Update(int id, DoctorModel model)
        {
            var Lists = _context.Doctors.SingleOrDefault(doctor => doctor.DoctorId == id);

            if (Lists != null)
            {
                Lists.DoctorName = model.DoctorName;
                Lists.PhoneNumber = model.PhoneNumber;
                Lists.Address = model.Address;
                Lists.BirthDay = model.BirthDay;
                Lists.DateWork = model.DateWork;
                Lists.Professtional = model.Professtional;
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
