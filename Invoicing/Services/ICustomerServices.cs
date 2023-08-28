using Invoicing.DTO;

namespace Invoicing.Services
{
    public interface ICustomerServices
    {
        Task<Customer> AddCustomerAsync(CustomerDTO customerDTO);
        Task<bool> DeleteCustomerAsync(Guid idUser);
        Task<Customer> EditCustomerAsync(CustomerDTO customerDTO);
        Task<Customer> SeekCustomerByNameAsync(string name);
        Task<Customer> SeekCustomerByNipAsync(string nip);
    }
}