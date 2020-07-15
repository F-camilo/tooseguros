using System;
using System.Threading.Tasks;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Interfaces;

namespace TooSeguros.Services.Implementations
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly ILancamentoRepository _lancamentoRepository;

        public TransacaoService(IContaCorrenteRepository contaCorrenteRepository, ILancamentoRepository lancamentoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _lancamentoRepository = lancamentoRepository;
        }
       
        public async Task CreateTransactionDebitAndCredit(TransacaoDto transaction)
        {
            await this.CreateTransactionCredit(transaction.IdContaCorrenteDestino, transaction.Valor);
            await this.CreateTransactionDebit(transaction.IdContaCorrenteOrigem, transaction.Valor);
        }

        public async Task CreateTransactionCredit(int contaCorrenteId, double valor)
        {
            if (valor <= 0)
                throw new TransacaoException("Erro ao efetuar transação de Crédito, Valor não pode ser menor ou igual a 0 (Zero).");

            var contaCorrente = await _contaCorrenteRepository.GetContaCorrente(contaCorrenteId);

            if (contaCorrente == null)
                throw new TransacaoException("Erro ao efetuar transação de Crédito, Conta Corrente Não encontrada.");

            await _lancamentoRepository.CreateLancamento(new Domain.Entities.Lancamento(contaCorrenteId, Domain.Enum.TipoTransacao.Credito, DateTime.Now, valor));
            contaCorrente.AplicarCredito(valor);
            await _contaCorrenteRepository.UpdateContaCorrente(contaCorrente);
        }

        public async Task CreateTransactionDebit(int contaCorrenteId, double valor)
        {
            if (valor <= 0)
                throw new TransacaoException("Erro ao efetuar transação de Crédito, Valor não pode ser menor ou igual a 0 (Zero).");

            var contaCorrente = await _contaCorrenteRepository.GetContaCorrente(contaCorrenteId);

            if (contaCorrente == null)
                throw new TransacaoException("Erro ao efetuar transação de Débito, Conta Corrente Não encontrada.");

            await _lancamentoRepository.CreateLancamento(new Domain.Entities.Lancamento(contaCorrenteId, Domain.Enum.TipoTransacao.Debito, DateTime.Now, valor));
            contaCorrente.AplicarDebito(valor);

            await _contaCorrenteRepository.UpdateContaCorrente(contaCorrente);
        }

    }
}
