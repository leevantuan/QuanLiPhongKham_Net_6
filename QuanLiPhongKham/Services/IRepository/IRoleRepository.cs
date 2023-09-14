using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.View_Model;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IRoleRepository
    {
        List<RoleView> GetAll();

        RoleView GetById(int id);

        RoleView Add(RoleModel role);

        void Update(RoleView role);

        void Delete(int id);
    }
}
