using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Services.Interfaces;

namespace Application.Implementations
{
    public class LancamentoAppService : ILancamentoAppService
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoAppService(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        public async Task<Lancamento> CreateLancamento(Lancamento lancamento)
        {
            return await _lancamentoService.CreateLancamento(lancamento);
        }

        public async Task<IEnumerable<Lancamento>> GetAllLancamento()
        {
            return await _lancamentoService.GetAllLancamento();
        }

        public async Task<Lancamento> GetLancamento(int lancamentoId)
        {
            return await _lancamentoService.GetLancamento(lancamentoId);
        }

        public async Task<Lancamento> UpdateLancamento(Lancamento lancamento)
        {
            return await _lancamentoService.UpdateLancamento(lancamento);
        }
    }
}
