using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Update_Get_Model;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public ServiceRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Add(ServiceModel _service)
        {
            var service = _mapper.Map<Service>(_service);

            try
            {
                _context.Services.Add(service);
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
                var service = _context.Services.Find(id);
                if (service != null)
                {
                    _context.Services.Remove(service);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ServiceUpdate_GetModel> GetAll()
        {
            try
            {
                List<Service> AllService = _context.Services.ToList();
                return _mapper.Map<List<ServiceUpdate_GetModel>>(AllService);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceModel GetById(int id)
        {
            try
            {
                var ServiceById = _context.Services.FirstOrDefault(e => e.ServiceId == id);
                return _mapper.Map<ServiceModel>(ServiceById);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(ServiceUpdate_GetModel _service)
        {
            try
            {
                var service = _context.Services.FirstOrDefault(e => e.ServiceId == _service.ServiceId);
                if (service != null)
                {
                    service.ServiceName = _service.ServiceName;
                    service.Price = _service.Price;
                    service.Status = _service.Status;
                    service.RoomId = _service.RoomId;
                    var result = _context.SaveChanges();
                    if (result == 1) return true;
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
