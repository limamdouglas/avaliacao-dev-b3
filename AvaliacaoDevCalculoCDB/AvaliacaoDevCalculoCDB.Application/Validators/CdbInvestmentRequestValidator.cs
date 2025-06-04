using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using FluentValidation;

namespace AvaliacaoDevCalculoCDB.Application.Validators;

public class CdbInvestmentRequestValidator : AbstractValidator<CdbInvestmentRequestDto>
{
    public CdbInvestmentRequestValidator()
    {
        RuleFor(x => x.InitialValue)
            .GreaterThan(0).WithMessage("O valor inicial deve ser maior que zero.");

        RuleFor(x => x.Months)
            .GreaterThan(1).WithMessage("A quantidade de meses deve ser maior que um.");
    }
}