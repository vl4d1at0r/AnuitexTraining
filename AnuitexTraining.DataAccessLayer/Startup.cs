using AnuitexTraining.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AnuitexTraining.DataAccessLayer
{
    public static class Startup
    {
        public static void InitDataAccessLayerServices(this IServiceCollection services)
        {
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<SignInManager<ApplicationUser>>();
        }
    }
}
