using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;

namespace Market.Application.Services
{
    public class ProductService(AppDbContext context) : IProductService
    {
        public async ValueTask<bool> CreateAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            product.CreatedDate = DateTime.UtcNow.AddHours(5);
            product.UpdatedDate = null;
            product.DeletedDate = null;
            product.IsDeleted = false;
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var foundProduct = await context.Products.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Product));

            foundProduct.IsDeleted = true;
            foundProduct.DeletedDate = DateTime.UtcNow.AddHours(5);
            context.Products.Update(foundProduct);
            await context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Product> GetAll()
            => context.Products.AsQueryable();

        public async ValueTask<Product> GetByIdAsync(Guid id)
        {
            var foundProduct = await context.Products.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Product));

            return foundProduct;
        }

        public async ValueTask<bool> UpdateAsync(Product product)
        {
            product.UpdatedDate = DateTime.UtcNow.AddHours(5);
            context.Products.Update(product);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
