using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ProductService.cs
namespace BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync(includeProperties: "Supplier");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.Remove(product);
            }
        }
    }
}

// SupplierService.cs
namespace BusinessLayer.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _supplierRepository.GetAllAsync(includeProperties: "Address");
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.AddAsync(supplier);
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            await _supplierRepository.Update(supplier);
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier != null)
            {
                await _supplierRepository.Remove(supplier);
            }
        }
    }
}

// AddressService.cs
namespace BusinessLayer.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _addressRepository.GetByIdAsync(id);
        }

        public async Task AddAddressAsync(Address address)
        {
            await _addressRepository.AddAsync(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            await _addressRepository.Update(address);
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address != null)
            {
                await _addressRepository.Remove(address);
            }
        }
    }
}


// AccountService.cs
namespace BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountService(IAccountRepository AccountRepository)
        {
            _AccountRepository = AccountRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAccount()
        {
            return await _AccountRepository.GetAllAsync();
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _AccountRepository.GetByIdAsync(id);
        }

        public async Task AddAccountAsync(Account address)
        {
            await _AccountRepository.AddAsync(address);
        }

        public async Task UpdateAccountAsync(Account address)
        {
            await _AccountRepository.Update(address);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var address = await _AccountRepository.GetByIdAsync(id);
            if (address != null)
            {
                await _AccountRepository.Remove(address);
            }
        }

        public async Task<Account> GetAccountWithUsernameAndPassword(string username, string password)
        {
            return await _AccountRepository.GetAccountWithUsernameAndPassword(username, password);
        }
    }
}
