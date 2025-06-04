using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Response;

namespace AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;

public interface ICdbInvestmentService
{
    CdbInvestmentResponseDto CalculateCdbInvestment(CdbInvestmentRequestDto dto);
}