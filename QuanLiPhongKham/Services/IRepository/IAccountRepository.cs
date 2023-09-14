using QuanLiPhongKham.Data.Admin;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;

namespace QuanLiPhongKham.Services.IRepository
{
    public interface IAccountRepository
    {
        public LoginResponseModel Login(LoginModel model);
        public bool SignUp(SignUpModel model);
        public List<AccountModel> GetAllAccount();
        public AccountModel GetAccountByEmail(string email);
        public bool AddAccount(Account account);
        public bool UpdateAccount(AccountModel account);
        public bool DeleteAccount(string email);
    }
}
