using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Infra.Data.Context;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;

namespace TooSeguros.Infra.Data.DataBase.Data.Implementations
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly AppDbContext _context;

        public LancamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lancamento> CreateLancamento(Lancamento lancamento)
        {
            await _context.Lancamento.AddAsync(lancamento);
            await _context.SaveChangesAsync();

            return lancamento;
        }

        public async Task<IEnumerable<Lancamento>> GetAllLancamento()
        {
            return await _context.Lancamento.ToListAsync();
        }

        public async Task<Lancamento> GetLancamento(int lancamentoId)
        {
            return await _context.Lancamento.FirstOrDefaultAsync(x => x.Id == lancamentoId);
        }

        public async Task<Lancamento> UpdateLancamento(Lancamento lancamento)
        {
            _context.Lancamento.UpdateRange(lancamento);
            await _context.SaveChangesAsync();

            return lancamento;
        }
    }
}
