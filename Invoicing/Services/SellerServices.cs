using Invoicing.DB;
using Invoicing.DTO;
using System;

namespace Invoicing.Services
{
    public class SellerServices : ISellerServices
    {
        private readonly ConnectMssql _connectMssql;

        public SellerServices(ConnectMssql connectMssql)
        {
            _connectMssql = connectMssql;
        }

        public async Task<Seller> AddSellerAsync(Seller seller)
        {
            seller.id = Guid.NewGuid();
            await _connectMssql.sellers.AddAsync(seller);
            await _connectMssql.SaveChangesAsync();
            return seller;
        }
        public async Task<bool> DeleteSellerAsync(Guid id)
        {
            var result = _connectMssql.sellers.Find(id);
            if (result == null)
            {
                return false;
            }
            _connectMssql.sellers.Remove(result);
            await _connectMssql.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EditSellerAsync(Guid id, Seller seller)
        {
            var result = _connectMssql.sellers.FirstOrDefault(f => f.id.Equals(id));
            if (result == null)
            {
                return false;
            }
            result.Name = seller.Name;
            result.Description = seller.Description;
            result.NIP = seller.NIP;
            result.Address = seller.Address;
            result.City = seller.City;
            result.Region = seller.Region;
            result.PostalCode = seller.PostalCode;
            result.Country = seller.Country;
            result.Phone = seller.Phone;
            result.Invoce_created_Place = seller.Invoce_created_Place;
            result.Invoce_number = seller.Invoce_number;
            result.Password = seller.Password;
            result.Regon = seller.Regon;
            await _connectMssql.SaveChangesAsync();
            return true;
        }
    }
}
