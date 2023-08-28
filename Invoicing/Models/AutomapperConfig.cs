using AutoMapper;
using Invoicing.DTO;
using System;

namespace Invoicing.Models
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
