using Invoicing.DTO;

namespace Invoicing.Services
{
    public interface ICustomerServices
    {
        Task<Customer> AddCustomerAsync(CustomerDTO customerDTO);
        Task<bool> DeleteCustomerAsync(Guid idUser);
        Task<bool> EditCustomerAsync(CustomerDTO customerDTO, Guid guid);
        Task<List<Customer>> SeekCustomerByNameAsync(string name);
        Task<List<Customer>> SeekCustomerByNipAsync(string nip);
    }
}