using System;
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class Empresa : BaseModel
    {
        public Empresa()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}
