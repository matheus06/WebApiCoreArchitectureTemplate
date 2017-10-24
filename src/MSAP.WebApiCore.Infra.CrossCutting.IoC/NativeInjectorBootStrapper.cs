using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MSAP.WebApiCore.Application.AppService;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Interfaces.Services;
using MSAP.WebApiCore.Domain.Services;
using MSAP.WebApiCore.Infra.Data.Context;
using MSAP.WebApiCore.Infra.Data.Repositories;

namespace MSAP.WebApiCore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Applicaation
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IAppTodoService, AppTodoService>();

            //Domain
            services.AddScoped(typeof(IService<>), typeof(Service <>));
            services.AddScoped<ITodoService, TodoService>();

            //Infra-Data
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<WebApiContext>();
        }
    }
}
