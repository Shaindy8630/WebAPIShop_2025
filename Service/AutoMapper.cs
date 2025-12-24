using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Repository.Models;
using DTO;

namespace Service
{
    internal class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
        }

    }
}
