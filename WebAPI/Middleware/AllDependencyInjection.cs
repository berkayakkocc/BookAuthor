using Core.Interfaces.GenericInterfaces;
using Core.Interfaces.PageInterfaces;
using Service;
using Service.Repositories.GenericCrudRepository;

namespace WebAPI.Middleware
{
    public static  class AllDependencyInjection
    {
        public static IServiceCollection AddInjections(
                this IServiceCollection services)
        {
             services.AddTransient(typeof(IGenericCrudRepository<>), typeof(GenericCrudRepository<>));
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
