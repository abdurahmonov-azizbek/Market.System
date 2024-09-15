using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;

namespace Market.Application.Services
{
    public class ExpenseService(AppDbContext context) : IExpenseService
    {
        public async ValueTask<bool> CreateAsync(Expense expense)
        {
            expense.Id = Guid.NewGuid();
            expense.CreatedDate = DateTime.UtcNow.AddHours(5);
            expense.DeletedDate = null;
            expense.UpdatedDate = null;

            await context.Expenses.AddAsync(expense);
            await context.SaveChangesAsync();

            return true;
        }

        public async ValueTask<bool> DeleteByIdAsync(Guid id)
        {
            var expense = await context.Expenses.FindAsync(id)
                ?? throw new EntityNotFoundException(typeof(Expense));

            expense.DeletedDate = DateTime.UtcNow.AddHours(5);
            expense.IsDeleted = true;

            context.Expenses.Update(expense);
            await context.SaveChangesAsync();

            return true;
        }

        public IQueryable<Expense> GetAll()
            => context.Expenses.AsQueryable();

        public async ValueTask<Expense> GetByIdAsync(Guid id)
        {
            var expense = await context.Expenses.FindAsync(id)
              ?? throw new EntityNotFoundException(typeof(Expense));

            return expense;
        }

        public async ValueTask<bool> UpdateAsync(Expense expense)
        {
            expense.UpdatedDate = DateTime.UtcNow.AddHours(5);

            context.Expenses.Update(expense);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
