using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TooSeguros.Domain.Entities;
using TooSeguros.Domain.Exceptions;
using TooSeguros.Infra.Data.DataBase.Data.Interfaces;
using TooSeguros.Services.Interfaces;
using TooSeguros.Services.Validators;

namespace TooSeguros.Services.Implementations
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public LancamentoService(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Lancamento> CreateLancamento(Lancamento lancamento)
        {
            var validation = new LancamentoValidator().Validate(lancamento);

            if (!validation.IsValid)
                throw new TransacaoException(validation.Errors.Join(" "));

            return await _lancamentoRepository.CreateLancamento(lancamento);
        }

        public async Task<IEnumerable<Lancamento>> GetAllLancamento()
        {
            return await _lancamentoRepository.GetAllLancamento();
        }

        public async Task<Lancamento> GetLancamento(int lancamentoId)
        {
            return await _lancamentoRepository.GetLancamento(lancamentoId);

        }

        public async Task<Lancamento> UpdateLancamento(Lancamento lancamento)
        {
            var validation = new LancamentoValidator().Validate(lancamento);

            if (!validation.IsValid)
                throw new TransacaoException(validation.Errors.Join(" "));

            return await _lancamentoRepository.UpdateLancamento(lancamento);
        }
    }
}
