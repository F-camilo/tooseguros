using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<string> Token(UsuarioDto usuarioDto);
    }
}
