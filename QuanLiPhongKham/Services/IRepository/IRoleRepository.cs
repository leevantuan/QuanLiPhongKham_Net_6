using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IRoleRepository
    {
        List<RoleUpdate_GetModel> GetAll();

        RoleUpdate_GetModel GetById(int id);

        RoleUpdate_GetModel Add(RoleModel role);

        void Update(RoleUpdate_GetModel role);

        void Delete(int id);
    }
}
