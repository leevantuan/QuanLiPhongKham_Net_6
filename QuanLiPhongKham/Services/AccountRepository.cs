using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.Admin;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper _mapper;
        private readonly MyContext _context;
        public AccountRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool SignUp(SignUpModel model)
        {
            try
            {             
                return(AddAccount(_mapper.Map<Account>(model)));               
            }
            catch
            {
                return false;
            }
        }

        public LoginResponseModel Login(LoginModel model)
        {
            try
            {

                var account = GetAccountByEmail(model.Email);
                if(account.Password == model.Password)
                {
                    LoginResponseModel res = new LoginResponseModel();
                    res.Email = account.Email;
                    res.FullName = account.FullName;
                    return res;
                }
                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AccountModel> GetAllAccount()
        {
            try
            {
                List<Account> AllAccount = _context.Accounts.ToList();
                return _mapper.Map<List<AccountModel>>(AllAccount);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccountModel GetAccountByEmail(string email)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(e => e.Email == email);
                return _mapper.Map<AccountModel>(account);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                var result = _context.SaveChanges();
                if (result == 1) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateAccount(AccountModel _account)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(e => e.Email == _account.Email);
                if (account != null)
                {
                    account.Email = _account.Email;
                    account.FullName = _account.FullName;
                    account.PhoneNumber = _account.PhoneNumber;
                    account.UserName = _account.UserName;
                    account.Password = _account.Password;
                    account.Status = _account.Status;
                    account.RoleId = _account.RoleId;
                    var result = _context.SaveChanges();
                    if(result == 1) return true;
                    return false;
                } return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAccount(string email)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(account => account.Email == email);
                if (account != null)
                {
                    _context.Remove(account);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
