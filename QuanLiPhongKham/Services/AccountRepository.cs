using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;

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
    }
}
