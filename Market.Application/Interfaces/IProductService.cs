using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IProductService
    {
        ValueTask<bool> CreateAsync(Product product);
        IQueryable<Product> GetAll();
        ValueTask<Product> GetByIdAsync(Guid id);
        ValueTask<bool> UpdateAsync(Product product);
        ValueTask<bool> DeleteAsync(Guid id);
    }
}