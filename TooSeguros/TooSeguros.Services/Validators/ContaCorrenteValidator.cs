using FluentValidation;
using System;
using TooSeguros.Domain.Entities;

namespace TooSeguros.Services.Validators
{
    class ContaCorrenteValidator : AbstractValidator<ContaCorrente>
    {
        public ContaCorrenteValidator()
        {
            RuleFor(c => c)
               .NotNull()
               .OnAnyFailure(x =>
               {
                   throw new ArgumentNullException("Não foi possível encontrar o objeto.");
               });

            RuleFor(c => c.CodigoBanco)
                .NotEmpty().WithMessage("É necessário informar o Codigo do Banco.")
                .NotNull().WithMessage("É necessário informar o Codigo do Banco.");

            RuleFor(c => c.Banco)
                .NotEmpty().WithMessage("É necessário informar o Banco.")
                .NotNull().WithMessage("É necessário informar o Banco.");

            RuleFor(c => c.Agencia)
                .NotEmpty().WithMessage("É necessário informar a Agência.")
                .NotNull().WithMessage("É necessário informar a Agência.");

            RuleFor(c => c.Conta)
                .NotEmpty().WithMessage("É necessário informar a Conta.")
                .NotNull().WithMessage("É necessário informar a Conta.");

            RuleFor(c => c.DigitoConta)
                .NotEmpty().WithMessage("É necessário informar o Digito da Conta.")
                .NotNull().WithMessage("É necessário informar o Digito da Conta.");

            RuleFor(c => c.TipoContaBancaria)
                .NotNull().WithMessage("É necessário informar o TipoContaBancaria.");

        }
    }
}
