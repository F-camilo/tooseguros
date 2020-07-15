using Microsoft.EntityFrameworkCore;
using TooSeguros.Domain.Entities;
using TooSeguros.Infra.Data.Mapping;
using TooSeguros.Infra.Data.Util;

namespace TooSeguros.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<ContaCorrente> ContaCorrente { get; set; }
		public DbSet<Lancamento> Lancamento { get; set; }
		public DbSet<Usuario> Usuario { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var config = Configuration.GetConnection();

			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseSqlServer(config.ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
			modelBuilder.Entity<Lancamento>(new LancamentoMap().Configure);
			modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
		}
	}
}
