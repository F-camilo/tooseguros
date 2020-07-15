using Application.Implementations;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TooSeguros.Services.DependencyInjection;

namespace Application.DependencyInjection
{
    public class ApplicationDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            ServiceDependencyInjection.RegisterServices(services, Configuration);

            services
                .AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>()
                .AddScoped<ILancamentoAppService, LancamentoAppService>()
                .AddScoped<ITransacaoAppService, TransacaoAppService>()
                .AddScoped<IUsuarioAppService, UsuarioAppService>();

            ;
        }
    }
}
