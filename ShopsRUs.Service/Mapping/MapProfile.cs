using AutoMapper;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Domain.Concrete;

namespace ShopsRUs.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
        }
    }
}
