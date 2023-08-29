using Invoicing.DTO;

namespace Invoicing.Services
{
    public interface ISellerServices
    {
        Task<Seller> AddSellerAsync(Seller seller);
        Task<bool> DeleteSellerAsync(Guid id);
        Task<bool> EditSellerAsync(Guid id, Seller seller);
    }
}