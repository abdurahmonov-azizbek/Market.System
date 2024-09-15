using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IExpenseService
    {
        ValueTask<bool> CreateAsync(Expense expense);
        IQueryable<Expense> GetAll();
        ValueTask<Expense> GetByIdAsync(Guid id);
        ValueTask<bool> UpdateAsync(Expense expense);
        ValueTask<bool> DeleteByIdAsync(Guid id);
    }
}
