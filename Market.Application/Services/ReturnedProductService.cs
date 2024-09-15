using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;

namespace Market.Application.Services
{
    public class ReturnedProductService(AppDbContext context) : IReturnedProductService
    {
        public async ValueTask<bool> Create(ReturnedProduct returnedProduct)
        {
            returnedProduct.Id = Guid.NewGuid();
            returnedProduct.CreatedDate = DateTime.UtcNow.AddHours(5);
            returnedProduct.UpdatedDate = null;
            returnedProduct.DeletedDate = null;

            await context.ReturnedProducts.AddAsync(returnedProduct);
            await context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var returnedProduct = await context.ReturnedProducts.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(ReturnedProduct));

            returnedProduct.DeletedDate = DateTime.UtcNow.AddHours(5);
            returnedProduct.IsDeleted = true;

            context.ReturnedProducts.Update(returnedProduct);
            await context.SaveChangesAsync();

            return true;
        }

        public IQueryable<ReturnedProduct> GetAll()
            => context.ReturnedProducts.AsQueryable();

        public async ValueTask<ReturnedProduct> GetByIdAsync(Guid id)
        {
            var returnedProduct = await context.ReturnedProducts.FindAsync(id)
               ?? throw new EntityNotFoundException(typeof(ReturnedProduct));

            return returnedProduct;
        }

        public async ValueTask<bool> UpdateAsync(ReturnedProduct returnedProduct)
        {
            returnedProduct.UpdatedDate = DateTime.UtcNow.AddHours(5);
            context.ReturnedProducts.Update(returnedProduct);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
