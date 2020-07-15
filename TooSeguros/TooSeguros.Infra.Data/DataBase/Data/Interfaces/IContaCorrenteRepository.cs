using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Infra.Data.DataBase.Data.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> CreateContaCorrente(ContaCorrente contaCorrente);
        Task<ContaCorrente> UpdateContaCorrente(ContaCorrente contaCorrente);
        Task<IEnumerable<ContaCorrente>> GetAllContaCorrente();
        Task<ContaCorrente> GetContaCorrente(int contaCorrenteId);
    }
}
