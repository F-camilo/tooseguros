using System.Threading.Tasks;
using TooSeguros.Domain.Dto;

namespace TooSeguros.Services.Interfaces
{
    public interface ITransacaoService
    {
        Task CreateTransactionDebitAndCredit(TransacaoDto transaction);
        Task CreateTransactionDebit(int contaCorrenteId, double valor);
        Task CreateTransactionCredit(int contaCorrenteId, double valor);
    }
}
