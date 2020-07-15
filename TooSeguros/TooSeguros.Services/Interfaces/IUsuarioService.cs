using System.Threading.Tasks;
using TooSeguros.Domain.Dto;

namespace TooSeguros.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> Token(UsuarioDto usuario);
    }
}
