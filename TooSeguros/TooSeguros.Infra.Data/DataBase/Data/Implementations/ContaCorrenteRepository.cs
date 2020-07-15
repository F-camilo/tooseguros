using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Infra.Data.Context;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;

namespace TooSeguros.Infra.Data.DataBase.Data.Implementations
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly AppDbContext _context;

        public ContaCorrenteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContaCorrente> CreateContaCorrente(ContaCorrente contaCorrente)
        {
            await _context.ContaCorrente.AddAsync(contaCorrente);
            await _context.SaveChangesAsync();

            return contaCorrente;
        }

        public async Task<IEnumerable<ContaCorrente>> GetAllContaCorrente()
        {
            return await _context.ContaCorrente.Include(x => x.Lancamentos).ToListAsync();
        }

        public async Task<ContaCorrente> GetContaCorrente(int contaCorrenteId)
        {
            return await _context.ContaCorrente.FirstOrDefaultAsync(x => x.Id == contaCorrenteId);
        }

        public async Task<ContaCorrente> UpdateContaCorrente(ContaCorrente contaCorrente)
        {
            _context.ContaCorrente.UpdateRange(contaCorrente);
            await _context.SaveChangesAsync();

            return contaCorrente;
        }
    }
}
