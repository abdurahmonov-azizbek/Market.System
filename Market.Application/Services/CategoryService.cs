using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;

namespace Market.Application.Services
{
    public class CategoryService(AppDbContext context) : ICategoryService
    {
        public async ValueTask<bool> CreateAsync(Category category)
        {
            category.Id = Guid.NewGuid();
            category.CreatedDate = DateTime.UtcNow.AddHours(5);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.UpdatedDate = null;

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var foundCategory = await context.Categories.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Category));

            foundCategory.IsDeleted = true;
            foundCategory.DeletedDate = DateTime.UtcNow.AddHours(5);

            context.Categories.Update(foundCategory);
            await context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Category> GetAll()
            => context.Categories.AsQueryable();

        public async ValueTask<Category> GetByIdAsync(Guid id)
        {
            var foundCategory = await context.Categories.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Category));

            return foundCategory;
        }

        public async ValueTask<bool> UpdateAsync(Category category)
        {
            category.UpdatedDate = DateTime.UtcNow.AddHours(5);
            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
