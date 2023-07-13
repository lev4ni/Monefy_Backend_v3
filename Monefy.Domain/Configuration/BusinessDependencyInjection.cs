using Microsoft.Extensions.DependencyInjection;
using Monefy.Domain.Contracts;
using Monefy.Domain.Implementation;
using Monefy.Domain.Services;

namespace Monefy.Domain.Configuration
{
    public static class BusinessDependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryBusinessService, CategoryBusinessService>();
            services.AddTransient<ICurrencyBusinessService, CurrencyBusinessService>();
            services.AddTransient<IExpenseBusinessService, ExpenseBusinessService>();
            services.AddTransient<IUserBusinessService, UserBusinessService>();
            services.AddTransient<IWalletBusinessService, WalletBusinessService>();
            services.AddTransient<IIncomeBusinessService, IncomeBusinessService>();
            services.AddTransient<UserValidator>();

            return services;
        }
    }
}
