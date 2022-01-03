using Api.Data.Mapping;
using Api.Domain.Enuns;
using Api.Domain.Helpers;
using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Api.Data.Context
{
    public class PontoEletronicoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public PontoEletronicoContext(DbContextOptions<PontoEletronicoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

            modelBuilder.Entity<Empresa>(new EmpresaMap().Configure);

            modelBuilder.Entity<Funcionario>(new FuncionarioMap().Configure);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }



            //modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);

            //modelBuilder.Entity<Pessoa>().HasData(
            //    new Pessoa
            //    {
            //        Id = Guid.NewGuid(),
            //        Nome = "Administrador",
            //        Cnpj = "03535011000164",
            //        Cpf = "63992844064",
            //        Email = "admin@empresa.com",
            //        Senha = ConvertMD5.CriptografiaMD5("123456"),
            //        Perfil = Role.ROLE_ADMIN
            //    }
            //);

            Initial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void Initial(ModelBuilder modelBuilder)
        {
            var IdUsuarioEmpresa = Guid.NewGuid();
            var IdUsuarioFuncionario = Guid.NewGuid();
            var IdEmpresa = Guid.NewGuid();

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = IdUsuarioEmpresa,
                    Email = "admin@empresa.com",
                    Senha = ConvertMD5.CriptografiaMD5("123456"),
                    Perfil = Role.ROLE_ADMIN
                },
                new Usuario
                {
                    Id = IdUsuarioFuncionario,
                    Email = "funcionario@empresa.com",
                    Senha = ConvertMD5.CriptografiaMD5("123456"),
                    Perfil = Role.ROLE_FUNC
                }
            );

            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = IdEmpresa,
                    UsuarioId = IdUsuarioEmpresa,
                    RazaoSocial = "Empresa S/A",
                    Cnpj = "03535011000164",
                    Nome = "Administrador",
                    Cpf = "63992844064",
                }    
            );

            modelBuilder.Entity<Funcionario>().HasData(
                new Funcionario
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = IdUsuarioFuncionario,
                    EmpresaId = IdEmpresa,
                    Nome = "Funcionario",
                    Cpf = "53129582045"
                }
            );
        }
    }
}
