using Moq;
using System.Threading.Tasks;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Implementations;
using TooSeguros.Services.Interfaces;
using Xunit;

namespace Tests.ContaCorrente
{
    public class LancamentoTest : BaseTeste
    {
        private readonly Mock<ILancamentoRepository> _lancamentoMock;
        private readonly ILancamentoService _lancamentoService;

        public LancamentoTest()
        {
            _lancamentoMock = new Mock<ILancamentoRepository>();

            _lancamentoService = new LancamentoService(_lancamentoMock.Object);
        }

        #region Sucesso
        [Fact]
        public async Task CreateSuccessContaCorrente()
        {
            await _lancamentoService.CreateLancamento(_lancamento);

            Assert.True(true);
        }

        #endregion

        #region Falha
        [Fact]
        public async Task CreateFailContaCorrente_ContaCorrenteId()
        {
            try
            {
                _lancamento.ContaCorrenteId = 0;
                await _lancamentoService.CreateLancamento(_lancamento);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar a Conta Corrente.", ex.Message);
            }
        }
        [Fact]
        public async Task CreateFailContaCorrente_TipoTransacao()
        {
            try
            {
                _lancamento.TipoTransacao = null;
                await _lancamentoService.CreateLancamento(_lancamento);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar o Tipo de Transação.", ex.Message);
            }
        }


        [Fact]
        public async Task CreateFailContaCorrente_Valor()
        {
            try
            {
                _lancamento.Valor = -100;
                await _lancamentoService.CreateLancamento(_lancamento);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("Valor deve estar entre 1 a 100000.00", ex.Message);
            }
        }

        #endregion
    }
}
