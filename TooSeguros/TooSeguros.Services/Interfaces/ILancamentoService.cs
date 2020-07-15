using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Services.Interfaces
{
    public interface ILancamentoService
    {
        Task<Lancamento> CreateLancamento(Lancamento lancamento);
        Task<Lancamento> UpdateLancamento(Lancamento lancamento);
        Task<IEnumerable<Lancamento>> GetAllLancamento();
        Task<Lancamento> GetLancamento(int lancamentoId);
    }
}
