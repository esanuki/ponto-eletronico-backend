using Api.Data.Context;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PontoEletronicoContext context) : base(context)
        {
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            return await dbSet
                .Include(u => u.Empresa)
                .Include(u => u.Funcionario)
                .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                .FirstOrDefaultAsync();
        }
    }
}
