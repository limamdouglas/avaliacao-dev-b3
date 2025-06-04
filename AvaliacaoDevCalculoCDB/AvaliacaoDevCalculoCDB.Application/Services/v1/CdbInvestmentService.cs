using AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Response;
using AvaliacaoDevCalculoCDB.Domain.Entities.v1;

namespace AvaliacaoDevCalculoCDB.Application.Services.v1;

public class CdbInvestmentService : ICdbInvestmentService
{
    public Response<CdbInvestmentResponseDto> CalculateCdbInvestment(CdbInvestmentRequestDto dto)
    {
        if (dto.InitialValue <= 0)
            return new Response<CdbInvestmentResponseDto>(400, "O valor inicial deve ser maior que zero.");

        if (dto.Months < 1)
            return new Response<CdbInvestmentResponseDto>(400, "O prazo deve ser maior que zero.");


        var investment = new CdbInvestment
        {
            InitialValue = dto.InitialValue
        };

        investment.Calculate(dto.Months);

        var responseDto = new CdbInvestmentResponseDto
        {
            GrossReturn = investment.GrossReturn,
            NetReturn = investment.NetReturn
        };

        return new Response<CdbInvestmentResponseDto>(200, "Cálculo realizado com sucesso.", responseDto);
    }
}