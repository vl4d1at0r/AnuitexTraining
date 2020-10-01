using AnuitexTraining.BusinessLogicLayer.Mappers;
using AnuitexTraining.BusinessLogicLayer.Providers;
using AnuitexTraining.BusinessLogicLayer.Services;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using AnuitexTraining.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace AnuitexTraining.BusinessLogicLayer
{
    public static class Startup
    {
        public static void InitBusinessLogicLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddSingleton<EmailProvider>();
            services.AddSingleton<UserMapper>();
            services.AddSingleton<PrintingEditionMapper>();
            services.AddSingleton<AuthorMapper>();
            services.AddSingleton<OrderItemMapper>();
            services.AddSingleton<OrderMapper>();
            services.AddSingleton<ExchangeRateProvider>();
            services.AddSingleton<PasswordGeneratorProvider>();

            services.InitDataAccessLayerServices();
        }
    }
}