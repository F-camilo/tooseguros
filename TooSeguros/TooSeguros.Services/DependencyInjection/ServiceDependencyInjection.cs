using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TooSeguros.Infra.Data.DependencyInjection;
using TooSeguros.Services.Implementations;
using TooSeguros.Services.Interfaces;

namespace TooSeguros.Services.DependencyInjection
{
    public class ServiceDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            InfraDependencyInjection.RegisterServices(services, Configuration);

            services
                .AddScoped<IContaCorrenteService, ContaCorrenteService>()
                .AddScoped<ILancamentoService, LancamentoService>()
                .AddScoped<ITransacaoService, TransacaoService>()
                .AddScoped<IUsuarioService, UsuarioService>();

        }
    }
}
