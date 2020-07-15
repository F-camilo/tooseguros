using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Entities;
using TooSeguros.Infra.Data.Context;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;

namespace TooSeguros.Infra.Data.DataBase.Data.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Login(UsuarioDto usuario)
        {
            return await _context.Usuario.Where(x => x.Login.ToLower() == usuario.Login.ToLower() && x.Senha == usuario.Senha).FirstOrDefaultAsync();
        }
    }
}
