using Newtonsoft.Json;
using System.Collections.Generic;
using TooSeguros.Domain.Enum;

namespace TooSeguros.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {
        public ContaCorrente() {}

        public ContaCorrente(string codigoBanco, string banco, string agencia, string digitoAgencia, string conta, string digitoConta, TipoContaBancaria? tipoContaBancaria)
        {
            CodigoBanco = codigoBanco;
            Banco = banco;
            Agencia = agencia;
            DigitoAgencia = digitoAgencia;
            Conta = conta;
            DigitoConta = digitoConta;
            TipoContaBancaria = tipoContaBancaria;
        }

        [JsonProperty("bancoCodigo")]
        public string CodigoBanco { get; set; }
        [JsonProperty("banco")]
        public string Banco { get; set; }
        [JsonProperty("agencia")]
        public string Agencia { get; set; }
        [JsonProperty("digitoAgencia")]
        public string DigitoAgencia { get; set; }
        [JsonProperty("conta")]
        public string Conta { get; set; }
        [JsonProperty("digitoConta")]
        public string DigitoConta { get; set; }
        [JsonProperty("tipoContaBancaria")]
        public TipoContaBancaria? TipoContaBancaria { get; set; }
        [JsonProperty("saldo")]
        public double Saldo { get; private set; }

        [JsonProperty("lancamentos")]
        public virtual IEnumerable<Lancamento> Lancamentos { get; internal set; }


        public void SetSaldo(double valor) => this.Saldo = valor;
        public void SetLancamentos(IEnumerable<Lancamento> lancamentos) => this.Lancamentos = lancamentos;

        public void AplicarDebito(double valor)
        {
            this.Saldo -= valor;
        }

        public void AplicarCredito(double valor)
        {
            this.Saldo += valor;
        }
    }
}
