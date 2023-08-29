using AutoMapper;
using Invoicing.DB;
using Invoicing.DTO;
using System;

namespace Invoicing.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ConnectMssql _connectMssql;
        private readonly IMapper _mapper;

        public CustomerServices(ConnectMssql connectMssql, IMapper mapper)
        {
            _connectMssql = connectMssql;
            _mapper = mapper;
        }

        public async Task<Customer> AddCustomerAsync(CustomerDTO customerDTO)
        {
            var result = _mapper.Map<Customer>(customerDTO);
            result.DateTimeCreated = DateTime.Now;
            result.id = Guid.NewGuid();
            
           await  _connectMssql.customers.AddAsync(result);
           await  _connectMssql.SaveChangesAsync();
            return result;

        }
        public async Task<bool> EditCustomerAsync(CustomerDTO customerDTO, Guid guid)
        {
            var result = _connectMssql.customers.FirstOrDefault(f => f.id.Equals(guid));
            if(result == null)
            {
                return false;
            }
            result.email = customerDTO.email;
            result.NIP = customerDTO.NIP;
            result.Address = customerDTO.Address;
            result.City = customerDTO.City;
            result.PostalCode = customerDTO.PostalCode;
            result.Country = customerDTO.Country;
            result.Name = customerDTO.Name;
            result.Description = customerDTO.Description;
            result.Phone = customerDTO.Phone;
            result.Region  = customerDTO.Region;
            result.Regon = customerDTO.Regon;
            await _connectMssql.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCustomerAsync(Guid idUser)
        {
            var result = _connectMssql.customers.Find(idUser);
            if(result == null) 
            {
                return false;
            }
            _connectMssql.customers.Remove(result);
            await _connectMssql.SaveChangesAsync();
            return true;
        }
        public async Task<List<Customer>> SeekCustomerByNipAsync(string nip)
        {
            var result = _connectMssql.customers.Where(s => s.NIP == nip).ToList();
            return result;
        }
        public async Task<List<Customer>> SeekCustomerByNameAsync(string name)
        {
            var result = _connectMssql.customers.Where(s => s.Name == name).ToList();
            return result;
        }
    }
}
