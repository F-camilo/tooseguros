using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Interfaces;
using TooSeguros.Services.Validators;

namespace TooSeguros.Services.Implementations
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<ContaCorrente> CreateContaCorrente(ContaCorrente contaCorrente)
        {
            var validation = new ContaCorrenteValidator().Validate(contaCorrente);

            if (!validation.IsValid)
                throw new TransacaoException(validation.Errors.Join(" "));

            return await _contaCorrenteRepository.CreateContaCorrente(contaCorrente);
        }

        public async Task<IEnumerable<ContaCorrente>> GetAllContaCorrente()
        {
            return await _contaCorrenteRepository.GetAllContaCorrente();
        }

        public async Task<ContaCorrente> GetContaCorrente(int contaCorrenteId)
        {
            return await _contaCorrenteRepository.GetContaCorrente(contaCorrenteId);
        }

        public async Task<ContaCorrente> UpdateContaCorrente(ContaCorrente contaCorrente)
        {
            var validation = new ContaCorrenteValidator().Validate(contaCorrente);

            if (!validation.IsValid)
                throw new TransacaoException(validation.Errors.Join(" "));

            return await _contaCorrenteRepository.UpdateContaCorrente(contaCorrente);
        }
    }
}
