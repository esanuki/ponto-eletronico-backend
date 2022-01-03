using Api.Domain.Enuns;

namespace Api.Domain.Models
{
    public class Usuario : BaseModel
    {
        
        public string Email { get; set; }
        public string Senha { get; set; }
        public Role Perfil { get; set; }

        public Empresa Empresa { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
