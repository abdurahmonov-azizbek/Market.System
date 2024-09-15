using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
