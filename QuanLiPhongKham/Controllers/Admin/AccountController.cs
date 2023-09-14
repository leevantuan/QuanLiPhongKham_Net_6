using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly IAccountRepository _accountRepo;
        public AccountController(MyContext context, IAccountRepository account)
        {
            _context = context;
            _accountRepo = account;
        }

        //get danh sách trong API
        [HttpGet]
        public IActionResult GetAllAccount()
        {
            try
            {
                return Ok(_accountRepo.GetAllAccount());
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get data by id
        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                var account = _accountRepo.GetAccountByEmail(email);
                return Ok(account);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //post data create
        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            try
            {
                var account = _accountRepo.GetAccountByEmail(model.Email);
                if (account != null)
                {
                    return BadRequest("Email Exist!");
                }
                var result = _accountRepo.SignUp(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        //Login
        [HttpPost("/login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                var account = _accountRepo.GetAccountByEmail(model.Email);
                if (account != null)
                {
                    var result = _accountRepo.Login(model);
                    if (result == null)
                    {
                        return BadRequest("Login Fail");

                    }
                    return Ok(result);
                }
                return BadRequest("Login Fail");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //put data update
        [HttpPut("{email}")]
        public IActionResult Update(string email, AccountModel model)
        {
            if(email != model.Email)
            {
                return BadRequest("Email Exist!");
            }
            try
            {
                var result = _accountRepo.UpdateAccount(model);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        //delete
        [HttpDelete("{email}")]
        public IActionResult RemoveAccount(string email)
        {
            var ListAccounts = _context.Accounts.SingleOrDefault(acc => acc.Email == email);

            if (ListAccounts != null)
            {
                var result = _accountRepo.DeleteAccount(email);
                return Ok(result);
            }
            else { return NotFound(); }
        }
    }
}
