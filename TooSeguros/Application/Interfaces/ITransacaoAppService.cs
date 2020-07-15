using System.Threading.Tasks;
using TooSeguros.Domain.Dto;

namespace Application.Interfaces
{
    public interface ITransacaoAppService
    {
        Task CreateTransactionDebitAndCredit(TransacaoDto transaction);
        Task CreateTransactionDebit(TransacaoDebitDto transacaoDebit);
        Task CreateTransactionCredit(TransacaoCreditDto transacaoCredit);
    }
}
