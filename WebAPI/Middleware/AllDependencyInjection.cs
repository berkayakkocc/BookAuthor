using Core.Interfaces.GenericInterfaces;
using Core.Interfaces.PageInterfaces;
using Core.Interfaces.PageInterfaces.RepositoryInterfaces;
using Service;
using Service.Repositories.GenericCrudRepository;
using Service.Repositories.PageRepositories;

namespace WebAPI.Middleware
{
    public static  class AllDependencyInjection
    {
        public static IServiceCollection AddInjections(
                this IServiceCollection services)
        {
             services.AddTransient(typeof(IGenericCrudRepository<>), typeof(GenericCrudRepository<>));
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();


            services.AddScoped<IAuthorServiceRepository, AuthorServiceRepository>();



            return services;
        }
    }
}
