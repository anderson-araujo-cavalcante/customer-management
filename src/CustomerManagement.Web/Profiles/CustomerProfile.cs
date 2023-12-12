using AutoMapper;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Web.DTOs;

namespace CustomerManagement.Web.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }        
    }
}
