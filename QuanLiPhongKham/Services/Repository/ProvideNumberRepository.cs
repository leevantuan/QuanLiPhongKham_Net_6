using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services.Repository
{
    public class ProvideNumberRepository : IProvideNumberRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ProvideNumberRepository(MyContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public bool Add(ProvideNumberModel _provide)
        {
            try
            {
                var provide = _mapper.Map<ProvideNumber>(_provide);
                _context.ProvideNumbers.Add(provide);
                var result = _context.SaveChanges();
                if (result == 1) return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var provideNumber = _context.ProvideNumbers.Find(id);
                if (provideNumber == null) return false;
                _context.ProvideNumbers.Remove(provideNumber);
                _context.SaveChanges(true);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProvideNumberUpdate_GetModel> GetAll()
        {
            try
            {
                List<ProvideNumber> All = _context.ProvideNumbers.ToList();
                return _mapper.Map<List<ProvideNumberUpdate_GetModel>>(All);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProvideNumberModel GetById(int id)
        {
            try
            {
                var provide = _context.ProvideNumbers.SingleOrDefault(e => e.ProvideNumberId == id);
                return _mapper.Map<ProvideNumberModel>(provide);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ProvideNumberUpdate_GetModel _provide)
        {
            var provideNumber = _context.ProvideNumbers.FirstOrDefault(e => e.ProvideNumberId == _provide.ProvideNumberId);
            try
            {
                if (provideNumber == null) return false;
                provideNumber.FullName = _provide.FullName;
                provideNumber.Status = _provide.Status;
                provideNumber.PhoneNumber = _provide.PhoneNumber;
                provideNumber.StartDate = _provide.StartDate;
                provideNumber.EndtDate = _provide.EndtDate;
                provideNumber.Price = _provide.Price;
                provideNumber.ServiceId = _provide.ServiceId;
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
