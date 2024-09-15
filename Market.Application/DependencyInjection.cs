using Market.Application.Interfaces;
using Market.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IReturnedProductService, ReturnedProductService>();

            return services;
        }
    }
}
