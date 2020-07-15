using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> usuario)
        {
            usuario.ToTable("Usuario");

            usuario.HasKey(c => c.Id);

            usuario.Property(c => c.Login)
                .IsRequired()
                .HasColumnName("Login");

            usuario.Property(c => c.Senha)
                .IsRequired()
                .HasColumnName("Senha");

        }
    }
}
