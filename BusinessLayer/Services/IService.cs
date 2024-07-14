using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}

// ISupplierService.cs
namespace BusinessLayer.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task AddSupplierAsync(Supplier supplier);
        Task UpdateSupplierAsync(Supplier supplier);
        Task DeleteSupplierAsync(int id);
    }
}

// IAddressService.cs
namespace BusinessLayer.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }
}

// IAccountService.cs
namespace BusinessLayer.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAccount();
        Task<Account> GetAccountByIdAsync(int id);
        Task AddAccountAsync(Account Account);
        Task UpdateAccountAsync(Account Account);
        Task DeleteAccountAsync(int id);
        Task<Account> GetAccountWithUsernameAndPassword(string username, string password);
    }
}
