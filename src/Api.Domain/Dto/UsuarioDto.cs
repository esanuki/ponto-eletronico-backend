using Api.Domain.Enuns;

namespace Api.Domain.Dto
{
    public class UsuarioDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Role Perfil { get; set; }

        public EmpresaDto Empresa { get; set; }
        public FuncionarioDto Funcionario { get; set; }
    }
}
