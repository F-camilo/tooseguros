using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Services.Interfaces;

namespace Application.Implementations
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteAppService(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        public async Task<ContaCorrente> CreateContaCorrente(ContaCorrente contaCorrente)
        {
            return await _contaCorrenteService.CreateContaCorrente(contaCorrente);
        }

        public async Task<IEnumerable<ContaCorrente>> GetAllContaCorrente()
        {
            return await _contaCorrenteService.GetAllContaCorrente();
        }

        public async Task<ContaCorrente> GetContaCorrente(int contaCorrenteId)
        {
            return await _contaCorrenteService.GetContaCorrente(contaCorrenteId);
        }

        public async Task<ContaCorrente> UpdateContaCorrente(ContaCorrente contaCorrente)
        {
            return await _contaCorrenteService.UpdateContaCorrente(contaCorrente);
        }
    }
}
