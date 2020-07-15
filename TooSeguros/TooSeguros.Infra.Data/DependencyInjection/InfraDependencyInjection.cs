using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TooSeguros.Infra.Data.Context;
using TooSeguros.Infra.Data.DataBase.Data.Implementations;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;

namespace TooSeguros.Infra.Data.DependencyInjection
{
    public class InfraDependencyInjection
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>()
                .AddScoped<ILancamentoRepository, LancamentoRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddDbContext<AppDbContext>(c =>
               c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
    }
}
