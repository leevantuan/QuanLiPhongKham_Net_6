using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.Admin;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.View_Model;
using QuanLiPhongKham.Services.IRepository;
using System.Data;

namespace QuanLiPhongKham.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyContext _context;

        public RoleRepository(MyContext context) 
        {
            _context = context;
        }

        public RoleView Add(RoleModel role)
        {
            var _role = new Role
            {
                RoleName = role.RoleName,
                Describe = role.Describe,
            };

            _context.Add(_role);
            _context.SaveChanges();

            return new RoleView
            {
                RoleId = _role.RoleId,
                RoleName = _role.RoleName,
                Describe = _role.Describe,
                Status = _role.Status,
            };
        }

        public void Delete(int id)
        {
            var list = _context.Roles.SingleOrDefault(role => role.RoleId == id);
            if (list != null)
            {
                _context.Remove(list);
                _context.SaveChanges();
            }
        }

        public List<RoleView> GetAll()
        {
            var list = _context.Roles.Select(role => new RoleView
            {
                RoleId = role.RoleId, 
                RoleName = role.RoleName,
                Describe = role.Describe,
                Status = role.Status,
            });
            return list.ToList();
        }

        public RoleView GetById(int id)
        {
            var list = _context.Roles.SingleOrDefault(role => role.RoleId == id);
            if(list != null) 
            {
                return new RoleView
                {
                    RoleId = list.RoleId,
                    RoleName = list.RoleName,
                    Describe = list.Describe,
                    Status = list.Status,
                };
            }
            else
            {
                return null;
            }
        }

        public void Update(RoleView _role)
        {
            var list = _context.Roles.SingleOrDefault(role => role.RoleId == _role.RoleId);
            if (list != null)
            {
                list.RoleName = _role.RoleName;
                list.Describe = _role.Describe;
                list.Status = _role.Status;
                _context.SaveChanges();
            }
        }

    }
}
