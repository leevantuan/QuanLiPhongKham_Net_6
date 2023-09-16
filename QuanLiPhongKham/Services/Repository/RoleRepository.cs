using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.Admin;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Services.IRepository;
using System.Data;

namespace QuanLiPhongKham.Services.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyContext _context;

        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public RoleUpdate Add(RoleModel role)
        {
            var _role = new Role
            {
                RoleName = role.RoleName,
                Describe = role.Describe,
            };

            _context.Add(_role);
            _context.SaveChanges();

            return new RoleUpdate
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

        public List<RoleUpdate> GetAll()
        {
            var list = _context.Roles.Select(role => new RoleUpdate
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Describe = role.Describe,
                Status = role.Status,
            });
            return list.ToList();
        }

        public RoleUpdate GetById(int id)
        {
            var list = _context.Roles.SingleOrDefault(role => role.RoleId == id);
            if (list != null)
            {
                return new RoleUpdate
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

        public void Update(RoleUpdate _role)
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
