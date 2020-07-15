using Application.Interfaces;
using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Services.Interfaces;

namespace Application.Implementations
{
    public class TransacaoAppService : ITransacaoAppService
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoAppService(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        public async Task CreateTransactionCredit(TransacaoCreditDto transacaoCredit)
        {
            await _transacaoService.CreateTransactionCredit(transacaoCredit.ContaCorrenteId, transacaoCredit.Valor);
        }

        public async Task CreateTransactionDebit(TransacaoDebitDto transacaoDebit)
        {
            await _transacaoService.CreateTransactionDebit(transacaoDebit.ContaCorrenteId, transacaoDebit.Valor);
        }

        public async Task CreateTransactionDebitAndCredit(TransacaoDto transaction)
        {
            await _transacaoService.CreateTransactionDebitAndCredit(transaction);
        }
    }
}
