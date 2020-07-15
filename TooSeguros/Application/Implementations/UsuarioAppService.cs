using Application.Interfaces;
using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Services.Interfaces;

namespace Application.Implementations
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _transacaoService;

        public UsuarioAppService(IUsuarioService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        public async Task<string> Token(UsuarioDto usuarioDto)
        {
            return await _transacaoService.Token(usuarioDto);
        }
    }
}
