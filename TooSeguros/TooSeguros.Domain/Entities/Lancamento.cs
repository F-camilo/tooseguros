using Newtonsoft.Json;
using System;
using TooSeguros.Domain.Enum;

namespace TooSeguros.Domain.Entities
{
    public class Lancamento : BaseEntity
    {
        public Lancamento() {}

        public Lancamento(int contaCorrenteId, TipoTransacao? tipoTransacao, DateTime dataCriacao, double valor)
        {
            ContaCorrenteId = contaCorrenteId;
            TipoTransacao = tipoTransacao;
            DataCriacao = dataCriacao;
            Valor = valor;
        }

        [JsonProperty("contaCorrenteId")]
        public int ContaCorrenteId { get; set; }
        [JsonProperty("tipoTransacao")]
        public TipoTransacao? TipoTransacao { get; set; }
        [JsonProperty("dataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        [JsonProperty("valor")]
        public double Valor { get; set; }
    }
}
