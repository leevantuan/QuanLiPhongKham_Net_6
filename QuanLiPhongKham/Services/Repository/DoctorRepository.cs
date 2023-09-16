using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Updates;
using QuanLiPhongKham.Services.IRepository;

namespace QuanLiPhongKham.Services.Repository
{
    public class DoctorRepository : IDoctorRepsitory
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public DoctorRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Add(DoctorModel _doctor)
        {
            try
            {
                var doctor = _mapper.Map<Doctor>(_doctor);
                _context.Doctors.Add(doctor);
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
                var doctor = _context.Doctors.Find(id);
                if (doctor == null) return false;
                _context.Doctors.Remove(doctor);
                _context.SaveChanges(true);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DoctorUpdate> GetAll()
        {
            try
            {
                List<Doctor> AllDoctor = _context.Doctors.ToList();
                return _mapper.Map<List<DoctorUpdate>>(AllDoctor);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DoctorModel GetById(int id)
        {
            try
            {
                var doctor = _context.Doctors.SingleOrDefault(e => e.DoctorId == id);
                return _mapper.Map<DoctorModel>(doctor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(DoctorUpdate _doctor)
        {
            var doctor = _context.Doctors.FirstOrDefault(e => e.DoctorId == _doctor.DoctorId);
            try
            {
                if (doctor == null) return false;
                doctor.Professtional = _doctor.Professtional;
                doctor.Status = _doctor.Status;
                doctor.DateWork = _doctor.DateWork;
                doctor.BirthDay = _doctor.BirthDay;
                doctor.PhoneNumber = _doctor.PhoneNumber;
                doctor.Address = _doctor.Address;
                doctor.DoctorName = _doctor.DoctorName;
                doctor.RoomId = _doctor.RoomId;
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
