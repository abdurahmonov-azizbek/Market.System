using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IUserService
    {
        ValueTask<bool> CreateAsync(User user);
        IQueryable<User> GetAll();
        ValueTask<User> GetByIdAsync(Guid userId);
        ValueTask<bool> UpdateAsync(User user);
        ValueTask<bool> DeleteAsync(Guid userId);
    }
}
