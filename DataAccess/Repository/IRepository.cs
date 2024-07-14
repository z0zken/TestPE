using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task Update(T entity);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}

// IProductRepository.cs
namespace DataAccess.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithSupplierAsync();
    }
}

// ISupplierRepository.cs
namespace DataAccess.Data
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithAddressAsync(int id);
    }
}

// IAddressRepository.cs
namespace DataAccess.Data
{
    public interface IAddressRepository : IRepository<Address>
    {
    }
}
