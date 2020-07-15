using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Infra.Data.DataBase.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Login(UsuarioDto usuario);
    }
}
