using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Infra.Data.Mapping
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> lancamento)
        {
            lancamento.ToTable("Lancamento");

            lancamento.HasKey(c => c.Id);

            lancamento.Property(c => c.ContaCorrenteId)
                .IsRequired()
                .HasColumnName("ContaCorrenteId");

            lancamento.Property(c => c.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao");

            lancamento.Property(c => c.TipoTransacao)
                .IsRequired()
                .HasColumnName("TipoTransacao");

            lancamento.Property(c => c.Valor)
                .IsRequired()
                .HasColumnName("Valor");
        }
    }
}
