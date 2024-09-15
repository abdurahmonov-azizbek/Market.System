using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface ICategoryService
    {
        ValueTask<bool> CreateAsync(Category category);
        IQueryable<Category> GetAll();
        ValueTask<Category> GetByIdAsync(Guid id);
        ValueTask<bool> UpdateAsync(Category category);
        ValueTask<bool> DeleteAsync(Guid id);
    }
}
