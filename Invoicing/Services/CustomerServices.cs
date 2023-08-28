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
            var result = _connectMssql.customers.Find(guid);
            if(result == null)
            {
                return false;
            }
            var editData = _mapper.Map<Customer>(result);
            await _connectMssql.customers.AddAsync(editData);
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
