using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MSAP.WebApiCore.Application.AppService;
using MSAP.WebApiCore.Application.Interfaces;
using MSAP.WebApiCore.Domain.Interfaces.Repositories;
using MSAP.WebApiCore.Domain.Interfaces.Services;
using MSAP.WebApiCore.Domain.Services;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces;
using MSAP.WebApiCore.Infra.Data.Context;
using MSAP.WebApiCore.Infra.Data.Repositories;



namespace MSAP.WebApiCore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddTransient<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddTransient<IAppTodoService, AppTodoService>();
            services.AddSingleton<IEventBus>(provider => new EventBusRabbitMQ.EventBusRabbitMQ());

            //Domain
            services.AddTransient(typeof(IService<>), typeof(Service <>));
            services.AddTransient<ITodoService, TodoService>();

            //Infra-Data
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<WebApiContext>();
        }
    }
}
