using System;

namespace Api.Domain.Dto
{
    public class EmpresaDto
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
