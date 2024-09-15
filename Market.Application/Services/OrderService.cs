using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;

namespace Market.Application.Services
{
    public class OrderService(AppDbContext context) : IOrderService
    {
        public async ValueTask<bool> CreateAsync(Order order)
        {
            order.Id = Guid.NewGuid();
            order.CreatedDate = DateTime.UtcNow.AddHours(5);
            order.DeletedDate = null;
            order.UpdatedDate = null;

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var order = await context.Orders.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Order));

            order.DeletedDate = DateTime.UtcNow.AddHours(5);
            order.IsDeleted = true;

            context.Orders.Update(order);
            await context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Order> GetAll()
            => context.Orders.AsQueryable();

        public async ValueTask<Order> GetByIdAsync(Guid id)
        {
            var order = await context.Orders.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Order));

            return order;
        }

        public async ValueTask<bool> UpdateAsync(Order order)
        {
            order.UpdatedDate = DateTime.UtcNow.AddHours(5);
            context.Orders.Update(order);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
