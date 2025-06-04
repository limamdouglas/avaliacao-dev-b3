using AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Response;
using AvaliacaoDevCalculoCDB.Domain.Entities.v1;
using AvaliacaoDevCalculoCDB.Domain.Resources.v1;
using Microsoft.Extensions.Logging;

namespace AvaliacaoDevCalculoCDB.Application.Services.v1;

public class CdbInvestmentService(ILogger<CdbInvestmentService> logger) : ICdbInvestmentService
{
    private readonly ILogger<CdbInvestmentService> _logger = logger;

    public Response<CdbInvestmentResponseDto> CalculateCdbInvestment(CdbInvestmentRequestDto dto)
    {
        _logger.LogInformation(Messages.ServiceStart);

        if (dto.InitialValue <= 0)
        {
            _logger.LogWarning(Messages.InvalidInitialValueLog, dto.InitialValue);
            return new Response<CdbInvestmentResponseDto>(400, Messages.InvalidInitialValue);
        }

        if (dto.Months < 1)
        {
            _logger.LogWarning(Messages.InvalidPeriodLog, dto.Months);
            return new Response<CdbInvestmentResponseDto>(400, Messages.InvalidPeriod);
        }

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

        _logger.LogInformation(Messages.CalculationSuccessLog, dto.InitialValue, dto.Months);
        _logger.LogInformation(Messages.ServiceEnd);

        return new Response<CdbInvestmentResponseDto>(200, Messages.CalculationSuccess, responseDto);
    }
}