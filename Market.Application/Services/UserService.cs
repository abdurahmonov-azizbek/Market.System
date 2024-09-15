using Market.Application.Interfaces;
using Market.Data.DataContexts;
using Market.Domain.Common.Exceptions;
using Market.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Market.Application.Services
{
    public class UserService(
        AppDbContext context) : IUserService
    {
        public async ValueTask<bool> CreateAsync(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                user.CreatedDate = DateTime.UtcNow.AddHours(5);
                user.UpdatedDate = null;
                user.DeletedDate = null;
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public async ValueTask<bool> DeleteAsync(Guid userId)
        {
            try
            {
                var user = await context.Users.FindAsync(userId)
                    ?? throw new EntityNotFoundException(typeof(User));

                user.IsDeleted = true;
                user.DeletedDate = DateTime.UtcNow.AddHours(5);

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public IQueryable<User> GetAll()
        {
            return context.Users.AsQueryable();
        }

        public async ValueTask<User> GetByIdAsync(Guid userId)
        {
            return await context.Users.FindAsync(userId)
                ?? throw new EntityNotFoundException(typeof(User));
        }

        public async ValueTask<bool> UpdateAsync(User user)
        {
            try
            {
                user.UpdatedDate = DateTime.UtcNow.AddHours(5);
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
