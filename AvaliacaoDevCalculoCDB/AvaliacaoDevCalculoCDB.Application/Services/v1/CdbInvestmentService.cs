using AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Response;
using AvaliacaoDevCalculoCDB.Domain.Entities.v1;

namespace AvaliacaoDevCalculoCDB.Application.Services.v1;

public class CdbInvestmentService : ICdbInvestmentService
{
    public CdbInvestmentResponseDto CalculateCdbInvestment(CdbInvestmentRequestDto dto)
    {
        //if (dto.InitialValue <= 0)
        //    throw new ArgumentException("O valor inicial deve ser maior que zero.");
        //if (dto.Months < 1)
        //    throw new ArgumentException("O prazo deve ser maior que zero.");

        var investment = new CdbInvestment
        {
            InitialValue = dto.InitialValue
        };

        investment.Calculate(dto.Months);

        return new CdbInvestmentResponseDto
        {
            GrossReturn = investment.GrossReturn,
            NetReturn = investment.NetReturn
        };
    }
}