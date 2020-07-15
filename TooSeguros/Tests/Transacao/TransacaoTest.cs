using Moq;
using System;
using System.Threading.Tasks;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Implementations;
using TooSeguros.Services.Interfaces;
using Xunit;

namespace Tests.ContaCorrente
{
    public class TransacaoTest : BaseTeste
    {
        private readonly Mock<ILancamentoRepository> _lancamentoMock;
        private readonly Mock<IContaCorrenteRepository> _contaCorrenteMock;

        private readonly ITransacaoService _transacaoService;


        public TransacaoTest()
        {
            _lancamentoMock = new Mock<ILancamentoRepository>();
            _contaCorrenteMock = new Mock<IContaCorrenteRepository>();

            _transacaoService = new TransacaoService(_contaCorrenteMock.Object, _lancamentoMock.Object);
        }

        #region Falha

        [Fact]
        public async Task CreateFailTransactionDebitAndCredit()
        {
            try
            {
                _transacaoDto.Valor = -10;
                await _transacaoService.CreateTransactionDebitAndCredit(_transacaoDto);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("Erro ao efetuar transação de Crédito, Valor não pode ser menor ou igual a 0 (Zero).", ex.Message);
            }

        }

        [Fact]
        public async Task CreateFailTransactionCredit()
        {
            try
            {
                _transacaoDto.Valor = -10;
                await _transacaoService.CreateTransactionDebitAndCredit(_transacaoDto);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("Erro ao efetuar transação de Crédito, Valor não pode ser menor ou igual a 0 (Zero).", ex.Message);
            }

        }

        [Fact]
        public async Task CreateFailTransactionDebit()
        {
            try
            {
                _transacaoDto.Valor = -10;
                await _transacaoService.CreateTransactionDebitAndCredit(_transacaoDto);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("Erro ao efetuar transação de Crédito, Valor não pode ser menor ou igual a 0 (Zero).", ex.Message);
            }

        }
        #endregion

    }
}
