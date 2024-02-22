using APIRestGrpuL.Models.DTO.ProductsDTO;
using AutoMapper;
using Models.Entities.Products;
using OrdersAPI.Application.DTO.ProductsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoriesDTO, Categories>().ReverseMap();

            CreateMap<Categories, CategoriesCreateDTO>().ReverseMap();

        }
    }
}
