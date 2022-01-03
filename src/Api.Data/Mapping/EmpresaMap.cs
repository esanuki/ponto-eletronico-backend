using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Mapping
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("EmpresaId");

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RazaoSocial")
                .HasColumnType("varchar(80)");

            builder.Property(e => e.Cnpj)
                .HasColumnName("Cnpj")
                .HasColumnType("varchar(14)");

            builder.Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.Property(e => e.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.HasOne(e => e.Usuario)
                .WithOne(u => u.Empresa);
        }
    }
}
