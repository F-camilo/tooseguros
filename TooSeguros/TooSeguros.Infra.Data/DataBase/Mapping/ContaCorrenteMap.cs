using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Infra.Data.Mapping
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> contaCorrente)
        {
            contaCorrente.ToTable("ContaCorrente");

            contaCorrente.HasKey(c => c.Id);

            contaCorrente.Property(c => c.CodigoBanco)
                .IsRequired()
                .HasColumnName("CodigoBanco")
                .HasMaxLength(5);

            contaCorrente.Property(c => c.Banco)
                .IsRequired()
                .HasColumnName("Banco")
                .HasMaxLength(45);

            contaCorrente.Property(c => c.Agencia)
                .IsRequired()
                .HasColumnName("Agencia")
                .HasMaxLength(20);

            contaCorrente.Property(c => c.DigitoAgencia)
                .HasColumnName("DigitoAgencia")
                .HasMaxLength(5);

            contaCorrente.Property(c => c.Conta)
                .IsRequired()
                .HasColumnName("Conta")
                .HasMaxLength(20);

            contaCorrente.Property(c => c.DigitoConta)
                .IsRequired()
                .HasColumnName("DigitoConta")
                .HasMaxLength(5);

            contaCorrente.Property(c => c.Saldo)
                .HasColumnName("Saldo")
                .HasDefaultValue(0);

            contaCorrente.HasMany(c => c.Lancamentos);
        }
    }
}
