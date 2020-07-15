using Moq;
using System.Threading.Tasks;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Implementations;
using TooSeguros.Services.Interfaces;
using Xunit;

namespace Tests.ContaCorrente
{
    public class ContaCorrenteTest : BaseTeste
    {
        private readonly Mock<IContaCorrenteRepository> _contaCorrenteMock;
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteTest()
        {
            _contaCorrenteMock = new Mock<IContaCorrenteRepository>();

            _contaCorrenteService = new ContaCorrenteService(_contaCorrenteMock.Object);
        }

        #region Sucesso
        [Fact]
        public async Task CreateSuccessContaCorrente()
        {
            await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

            Assert.True(true);
        }

        #endregion

        #region Falha
        [Fact]
        public async Task CreateFailContaCorrente_CodigoBanco()
        {
            try
            {
                _contaCorrente.CodigoBanco = "";
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar o Codigo do Banco.", ex.Message);
            }
        }

        [Fact]
        public async Task CreateFailContaCorrente_Banco()
        {
            try
            {
                _contaCorrente.Banco = "";
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar o Banco.", ex.Message);
            }
        }

        [Fact]
        public async Task CreateFailContaCorrente_Agencia()
        {
            try
            {
                _contaCorrente.Agencia = "";
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar a Agência.", ex.Message);
            }
        }

        [Fact]
        public async Task CreateFailContaCorrente_Conta()
        {
            try
            {
                _contaCorrente.Conta = "";
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar a Conta.", ex.Message);
            }
        }

        [Fact]
        public async Task CreateFailContaCorrente_DigitoConta()
        {
            try
            {
                _contaCorrente.DigitoConta = "";
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar o Digito da Conta.", ex.Message);
            }
        }

        [Fact]
        public async Task CreateFailContaCorrente_TipoContaBancaria()
        {
            try
            {
                _contaCorrente.TipoContaBancaria = null;
                await _contaCorrenteService.CreateContaCorrente(_contaCorrente);

                Assert.True(false);
            }
            catch (TransacaoException ex)
            {
                Assert.Equal("É necessário informar o TipoContaBancaria.", ex.Message);
            }
        }

        #endregion
    }
}
