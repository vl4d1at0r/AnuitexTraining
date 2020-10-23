using AnuitexTraining.DataAccessLayer.AppContext;
using AnuitexTraining.DataAccessLayer.Entities;
using AnuitexTraining.DataAccessLayer.Providers;
using AnuitexTraining.DataAccessLayer.Repositories;
using AnuitexTraining.DataAccessLayer.Repositories.EF;
using AnuitexTraining.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.DataAccessLayer
{
    public static class Startup
    {
        public static void InitDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);
            
            services.AddIdentity<ApplicationUser, IdentityRole<long>>(options => options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<ExchangeRateProvider>();
        }
    }
}