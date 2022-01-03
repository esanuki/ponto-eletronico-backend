using System;

namespace Api.Domain.Models
{
    public class Funcionario : BaseModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid UsuarioId { get; set; }

        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
