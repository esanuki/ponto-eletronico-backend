using System;

namespace Api.Domain.Dto
{
    public class FuncionarioDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
