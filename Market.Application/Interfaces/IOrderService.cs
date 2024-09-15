using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IOrderService
    {
        ValueTask<bool> CreateAsync(Order order);
        IQueryable<Order> GetAll();
        ValueTask<Order> GetByIdAsync(Guid id);
        ValueTask<bool> UpdateAsync(Order order);
        ValueTask<bool> DeleteAsync(Guid id);
    }
}
