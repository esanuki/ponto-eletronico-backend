using Api.Domain.Dto;
using Api.Domain.Helpers;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services;
using Api.Domain.Security;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfiguration _signingConfiguration;

        public UsuarioService(
            IUsuarioRepository usuarioRepository, 
            IMapper mapper,
            TokenConfigurations tokenConfigurations,
            SigningConfiguration signingConfiguration)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _tokenConfigurations = tokenConfigurations;
            _signingConfiguration = signingConfiguration;
        }

        public async Task<object> Login(string email, string senha)
        {
            var result = await _usuarioRepository.Login(email, senha);

            if (result == null)
                return await ErrorMessage();
            
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var identity = new ClaimsIdentity(
                new GenericIdentity(result.Email),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, result.Email),
                    new Claim("role", result.Perfil.ToString()),
                    new Claim("empresaId", result.Empresa.Id.ToString()),
                    new Claim("id", result.Id.ToString()),
                    new Claim("exp", expirationDate.ToString())
                });

            var handler = new JwtSecurityTokenHandler();
            var token = TokenHelpers.CreateToken(identity, createDate, expirationDate, handler, _tokenConfigurations, _signingConfiguration);

            return new
            {
                data = new
                {
                    token = token
                },
                errors = new string[] { }
            };

            
        }


        private async Task<object> ErrorMessage()
        {
            return await Task.FromResult(new
            {
                timestamp = DateTime.Now,
                status = 401,
                error = "Unauthorized",
                message = "Acesso negado. Você deve estar autenticado no sistema para acessar a URL solicitad"
            });

        }
    }
}
