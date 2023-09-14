using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Login_User;
using QuanLiPhongKham.Services;

namespace QuanLiPhongKham.Controllers
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
                if(account != null)
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

        [HttpPost("/login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                var account = _accountRepo.GetAccountByEmail(model.Email);
                if(account != null)
                {
                    var result = _accountRepo.Login(model);
                    if(result == null)
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
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, AccountModel model)
        {
            var ListAccounts = _context.Accounts.SingleOrDefault(acc => acc.AccountId == id);

            if (ListAccounts != null)
            {
                ListAccounts.FullName = model.FullName;
                ListAccounts.Email = model.Email;
                ListAccounts.Img = model.Img;
                ListAccounts.PhoneNumber = model.PhoneNumber;
                ListAccounts.UserName = model.UserName;
                ListAccounts.Password = model.Password;
                ListAccounts.RoleId = model.RoleId;
                ListAccounts.Status = model.Status;
                _context.SaveChanges();
                return NoContent();
            }
            else { return NotFound(); }
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult RemoveAccount(int id)
        {
            var ListAccounts = _context.Accounts.SingleOrDefault(acc => acc.AccountId == id);

            if (ListAccounts != null)
            {
                _context.Accounts.Remove(ListAccounts);
                _context.SaveChanges();
                return Ok();
            }
            else { return NotFound(); }
        }
    }
}
