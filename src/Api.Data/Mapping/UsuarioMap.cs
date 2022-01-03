using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("UsuarioId");

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(60);
            builder.HasIndex(u => u.Email);

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .IsRequired()
                .HasMaxLength(60);
            builder.HasIndex(u => u.Senha);

            builder.Property(p => p.Perfil)
                .HasColumnName("Perfil")
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
