using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Entities;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Infra.Data.Util;
using TooSeguros.Services.Interfaces;

namespace TooSeguros.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> Token(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.Login(usuarioDto);

            if (usuario == null)
                return string.Empty;

            return this.GenerateToken(usuario);
        }

        private string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var config = Configuration.GetTokenConfigurations();

            var tokeDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim (ClaimTypes.Name, usuario.Login)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Secret)), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokeDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
