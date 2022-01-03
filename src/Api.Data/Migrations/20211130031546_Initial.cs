using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(80)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Email", "Perfil", "Senha" },
                values: new object[] { new Guid("8aa0f728-175c-4247-9455-175a91193b1f"), "admin@empresa.com", 0, "e10adc3949ba59abbe56e057f20f883e" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Email", "Perfil", "Senha" },
                values: new object[] { new Guid("b60071fd-4352-42ff-b826-ac3dc8e86cb7"), "funcionario@empresa.com", 1, "e10adc3949ba59abbe56e057f20f883e" });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "EmpresaId", "Cnpj", "Cpf", "Nome", "RazaoSocial", "UsuarioId" },
                values: new object[] { new Guid("b11d7795-972e-4877-95d5-c1a4523f550d"), "03535011000164", "63992844064", "Administrador", "Empresa S/A", new Guid("8aa0f728-175c-4247-9455-175a91193b1f") });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "FuncionarioId", "Cpf", "EmpresaId", "Nome", "UsuarioId" },
                values: new object[] { new Guid("fb78f983-7514-45b8-b3fc-f2b41fc480cb"), "53129582045", new Guid("b11d7795-972e-4877-95d5-c1a4523f550d"), "Funcionario", new Guid("b60071fd-4352-42ff-b826-ac3dc8e86cb7") });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioId",
                table: "Empresa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EmpresaId",
                table: "Funcionario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Senha",
                table: "Usuario",
                column: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
