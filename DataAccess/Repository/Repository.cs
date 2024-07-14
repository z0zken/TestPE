using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}

// ProductRepository.cs
namespace DataAccess.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsWithSupplierAsync()
        {
            return await _context.Product.Include(p => p.Supplier).ToListAsync();
        }
    }
}

// SupplierRepository.cs
namespace DataAccess.Data
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Supplier> GetSupplierWithAddressAsync(int id)
        {
            return await _context.Supplier.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}

// AddressRepository.cs
namespace DataAccess.Data
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
