using Microsoft.Extensions.DependencyInjection;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Application.Services;
using System.Reflection;

namespace RestaurantWebApi.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<IOrderService, OrderService>();
            #endregion
        }
    }
}
