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
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("FuncionarioId");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.Property(f => f.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)");

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionarios)
                .HasForeignKey(f => f.EmpresaId);

            builder.HasOne(f => f.Usuario)
                .WithOne(u => u.Funcionario);
        }
    }
}
