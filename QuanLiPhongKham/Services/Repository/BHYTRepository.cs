using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services.Repository
{
    public class BHYTRepository : IBHYTRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public BHYTRepository(MyContext context, IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        public bool Add(BHYTModel _bhyt)
        {
            try
            {
                var bhyt = _mapper.Map<BHYT>(_bhyt);
                _context.Bhyts.Add(bhyt);
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
                var bhyt = _context.Bhyts.Find(id);
                if (bhyt == null) return false;
                _context.Bhyts.Remove(bhyt);
                _context.SaveChanges(true);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BHYTUpdate_GetModel> GetAll()
        {
            try
            {
                List<BHYT> bhyt = _context.Bhyts.ToList();
                return _mapper.Map<List<BHYTUpdate_GetModel>>(bhyt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BHYTModel GetById(int id)
        {
            try
            {
                var bhyt = _context.Bhyts.SingleOrDefault(e => e.BHYTId == id);
                return _mapper.Map<BHYTModel>(bhyt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(BHYTUpdate_GetModel _bhyt)
        {
            var bhyt = _context.Bhyts.FirstOrDefault(e => e.BHYTId == _bhyt.BHYTId);
            try
            {
                if (bhyt == null) return false;
                bhyt.FullName = _bhyt.FullName;
                bhyt.PhoneNumber = _bhyt.PhoneNumber;
                bhyt.Address = _bhyt.Address;
                bhyt.Birthday = _bhyt.Birthday;
                bhyt.Professtion = _bhyt.Professtion;
                bhyt.StartDate = _bhyt.StartDate;
                bhyt.EndDate = _bhyt.EndDate;
                bhyt.Status = _bhyt.Status;
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
