using AutoMapper;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerListDto>().ReverseMap();
        }
    }
}
