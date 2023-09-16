using AutoMapper;
using QuanLiPhongKham.Data.Admin;
using QuanLiPhongKham.Data.User;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;
using QuanLiPhongKham.Models.Updates;

namespace TheBookStore.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Account,SignUpModel>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<Doctor, DoctorModel>().ReverseMap();
            CreateMap<Room, RoomModel>().ReverseMap();
            CreateMap<ProvideNumber, ProvideNumberModel>().ReverseMap();
            CreateMap<BHYT, BHYTModel>().ReverseMap();

            //full id
            CreateMap<Doctor, DoctorUpdate>().ReverseMap();
            CreateMap<Room, RoomUpdate>().ReverseMap();
        }
    }
}