using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;

namespace QuanLiPhongKham.Services
{
    public interface IAccountRepository
    {
        public LoginResponseModel Login(LoginModel model);
        public bool SignUp(SignUpModel model);
        public List<AccountModel> GetAllAccount();
        public AccountModel GetAccountByEmail(string email);
        public bool AddAccount(Account account);
    }
}
