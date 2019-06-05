using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AppServices.Interfaces;
using NetCore.AppServices.Services;
using NetCore.Domain.Interfaces;
using NetCore.Domain.Repositories;
using NetCore.Domain.Services;
using NetCore.Infra.Repositories;
using NetCore.Infra;

namespace NetCore.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            //Application Services
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //Domain Services
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Infra
            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
