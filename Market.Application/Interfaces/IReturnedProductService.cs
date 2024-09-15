using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IReturnedProductService
    {
        ValueTask<bool> Create(ReturnedProduct returnedProduct);
        IQueryable<ReturnedProduct> GetAll();
        ValueTask<ReturnedProduct> GetByIdAsync(Guid id);
        ValueTask<bool> UpdateAsync(ReturnedProduct returnedProduct);
        ValueTask<bool> DeleteAsync(Guid id);
    }
}
