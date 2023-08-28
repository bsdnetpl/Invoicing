using AutoMapper;
using Invoicing.DTO;
using System;

namespace Invoicing.Models
{
    public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
