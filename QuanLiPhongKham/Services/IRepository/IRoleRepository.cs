using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IRoleRepository
    {
        List<RoleUpdate> GetAll();

        RoleUpdate GetById(int id);

        RoleUpdate Add(RoleModel role);

        void Update(RoleUpdate role);

        void Delete(int id);
    }
}
