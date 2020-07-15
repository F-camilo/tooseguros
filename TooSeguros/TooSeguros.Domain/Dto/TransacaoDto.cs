namespace TooSeguros.Domain.Dto
{
    public class TransacaoDto : BaseTransacao
    {
        public int IdContaCorrenteOrigem { get; set; }
        public int IdContaCorrenteDestino { get; set; }
    }
}
