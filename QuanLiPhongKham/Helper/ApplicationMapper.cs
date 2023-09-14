﻿using AutoMapper;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Models;
using QuanLiPhongKham.Models.Authentication;

namespace TheBookStore.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Account,SignUpModel>().ReverseMap();
        }
    }
}