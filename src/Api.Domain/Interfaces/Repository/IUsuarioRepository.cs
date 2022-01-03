using Api.Domain.Models;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> Login(string email, string senha);
    }
}
