using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Domain.Models;

namespace Market.Application.Services
{
    public class AuthService(
        IUserService userService,
        ITokenGeneratorService tokenGeneratorService) : IAuthService
    {
        public async ValueTask<string> LoginAsync(LoginDetails loginDetails)
        {
            var user = userService.GetAll().FirstOrDefault(user => user.Email == loginDetails.Email)
                ?? throw new InvalidOperationException("User not found!");

            if (user.Password != loginDetails.Password)
            {
                throw new InvalidOperationException("Incorrect password!");
            }

            var token = tokenGeneratorService.GenerateToken(user);

            return token;
        }

        public async ValueTask<User> Me(Guid userId)
        {
            var user = await userService.GetByIdAsync(userId);

            return user;
        }

        public async ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
        {
            var user = new User
            {
                FirstName = registerDetails.FirstName,
                LastName = registerDetails.LastName,
                Email = registerDetails.Email,
                Password = registerDetails.Password,
                Role = Domain.Enums.Role.Employee,
                IsPaid = false
            };

            var isUserSaved = await userService.CreateAsync(user);

            return isUserSaved;
        }
    }
}
