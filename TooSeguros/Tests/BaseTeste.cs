using System;

namespace Tests
{
    public class BaseTeste
    {
        protected readonly TooSeguros.Domain.Entities.ContaCorrente _contaCorrente;
        protected readonly TooSeguros.Domain.Entities.Lancamento _lancamento;
        protected readonly TooSeguros.Domain.Dto.TransacaoDto _transacaoDto;


        public BaseTeste()
        {
            _contaCorrente = new TooSeguros.Domain.Entities.ContaCorrente()
            {
                CodigoBanco = "554",
                Banco = "Itau",
                Agencia = "5524",
                DigitoAgencia = "",
                Conta = "66541",
                DigitoConta = "2",
                TipoContaBancaria = TooSeguros.Domain.Enum.TipoContaBancaria.Corrente
            };

            _lancamento = new TooSeguros.Domain.Entities.Lancamento()
            {
                ContaCorrenteId = 1,
                TipoTransacao = TooSeguros.Domain.Enum.TipoTransacao.Credito,
                DataCriacao = DateTime.Now,
                Valor = 100
            };

            _transacaoDto = new TooSeguros.Domain.Dto.TransacaoDto()
            {
                IdContaCorrenteOrigem = 1,
                IdContaCorrenteDestino = 2,
                Valor = 3
            };
        }

    }
}
