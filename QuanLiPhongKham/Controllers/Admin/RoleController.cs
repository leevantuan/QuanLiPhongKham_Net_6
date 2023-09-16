using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Services.IRepository;
using System.Data;
using System.Net;

namespace QuanLiPhongKham.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _repo.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(RoleUpdate role, int id)
        {
            if (id != role.RoleId)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else
            {
                try
                {
                    _repo.Update(role);
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(RoleModel role)
        {

            try
            {
                return Ok(_repo.Add(role));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        //private readonly MyContext _context;

        //public RoleController(MyContext context)
        //{
        //    _context = context;
        //}

        ////get danh sách trong API
        //[HttpGet]
        //public IActionResult GetAll() 
        //{ 
        //    var ListRoles = _context.Roles.ToList();
        //    return Ok(ListRoles);
        //}

        ////get data by id
        //[HttpGet("{id}")]
        //public IActionResult GetById( int id)
        //{
        //    //SingleOrDefault Methor tìm kiếm có hoặc không
        //    var ListRoles = _context.Roles.SingleOrDefault( role => role.RoleId == id);

        //    if (ListRoles != null)
        //    {
        //        return Ok(ListRoles);
        //    }
        //    else { return NotFound(); }
        //}

        ////post data create
        //[HttpPost]
        //public IActionResult CreateNew(RoleModel model)
        //{
        //    try
        //    {
        //        var role = new Role
        //        {
        //            RoleName = model.RoleName,
        //            Describe = model.Describe,
        //        };

        //        _context.Add(role);
        //        _context.SaveChanges();
        //        return Ok(role);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }

        //}

        ////put data update
        //[HttpPut("{id}")]
        //public IActionResult UpdateRole(int id, RoleModel model) 
        //{
        //    var ListRoles = _context.Roles.SingleOrDefault(role => role.RoleId == id);

        //    if (ListRoles != null)
        //    {
        //        ListRoles.RoleName = model.RoleName;
        //        ListRoles.Describe = model.Describe;
        //        ListRoles.Status = model.Status;
        //        _context.SaveChanges();
        //        return NoContent();
        //    }
        //    else { return NotFound(); }
        //}

        ////delete
        //[HttpDelete("{id}")]
        //public IActionResult RemoveRole(int id)
        //{
        //    var ListRoles = _context.Roles.SingleOrDefault(role => role.RoleId == id);

        //    if (ListRoles != null)
        //    {
        //        _context.Roles.Remove(ListRoles);
        //        _context.SaveChanges();
        //        return Ok();
        //    }
        //    else { return NotFound(); }
        //}
    }
}
