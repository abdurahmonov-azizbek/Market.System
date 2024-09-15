using Market.Domain.Entities;
using Market.Domain.Models;

namespace Market.Application.Interfaces
{
    public interface IAuthService
    {
        ValueTask<bool> RegisterAsync(RegisterDetails registerDetails);
        ValueTask<string> LoginAsync(LoginDetails loginDetails);
        ValueTask<User> Me(Guid userId);
    }
}
