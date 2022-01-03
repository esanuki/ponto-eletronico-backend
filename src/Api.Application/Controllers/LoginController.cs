using Api.Domain.Helpers;
using Api.Domain.Interfaces.Services;
using Api.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginViewModel login)
        {
            var senhaHash = ConvertMD5.CriptografiaMD5(login.Senha);
            var result = await _usuarioService.Login(login.Email, senhaHash);

            return result;
        }

    }

    
}
