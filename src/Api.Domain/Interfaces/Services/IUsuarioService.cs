using Api.Domain.Dto;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<object> Login(string email, string senha);
    }
}
