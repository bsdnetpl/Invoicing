using Invoicing.DTO;

namespace Invoicing.Services
{
    public class CustomerServices : ICustomerServices
    {
        public async Task<Customer> AddCustomerAsync(CustomerDTO customerDTO)
        {

        }
        public async Task<Customer> EditCustomerAsync(CustomerDTO customerDTO)
        {

        }
        public async Task<bool> DeleteCustomerAsync(Guid idUser)
        {

        }
        public async Task<Customer> SeekCustomerByNipAsync(string nip)
        {

        }
        public async Task<Customer> SeekCustomerByNameAsync(string name)
        {

        }
    }
}
