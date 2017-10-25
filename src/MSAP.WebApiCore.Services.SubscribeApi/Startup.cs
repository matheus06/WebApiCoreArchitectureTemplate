using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSAP.WebApiCore.Application.AutoMapper;
using MSAP.WebApiCore.Infra.CrossCutting.EventBus.Interfaces;
using MSAP.WebApiCore.Infra.CrossCutting.IoC;
using MSAP.WebApiCore.Services.SubscribeApi.IntegrationEvents.EventHandling;
using MSAP.WebApiCore.Services.SubscribeApi.IntegrationEvents.Events;

namespace MSAP.WebApiCore.Services.SubscribeApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddAutoMapper();
            AutoMapperConfiguration.RegisterMappings();
            NativeInjectorBootStrapper.RegisterServices(services);

            InjectEvents(services);

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            SubscribeEvents(app);
        }

        private static void InjectEvents(IServiceCollection services)
        {
            services.AddTransient<IIntegrationEventHandler<TodoModelChangedIntegrationEvent>, TodoModelChangedIntegrationEventHandler>();
        }

        private static void SubscribeEvents(IApplicationBuilder app)
        {
            var todoModelHandler = app.ApplicationServices.GetService<IIntegrationEventHandler<TodoModelChangedIntegrationEvent>>();
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TodoModelChangedIntegrationEvent>(todoModelHandler);
        }
    }
}
