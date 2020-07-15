using FluentValidation;
using System;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Services.Validators
{
    public class LancamentoValidator : AbstractValidator<Lancamento>
    {
        public LancamentoValidator()
        {
            RuleFor(c => c)
                   .NotNull()
                   .OnAnyFailure(x =>
                   {
                       throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                   });

            RuleFor(c => c.ContaCorrenteId)
                .NotEmpty().WithMessage("É necessário informar a Conta Corrente.")
                .NotNull().WithMessage("É necessário informar a Conta Corrente.");

            RuleFor(c => c.TipoTransacao)
                .NotNull().WithMessage("É necessário informar o Tipo de Transação.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("É necessário informar o Valor.")
                .NotNull().WithMessage("É necessário informar o Valor")
                .InclusiveBetween(0, 100000.00).WithMessage("Valor deve estar entre 1 a 100000.00");

        }
    }
}
