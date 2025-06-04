using AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoDevCalculoCDB.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CdbInvestmentController(ICdbInvestmentService cdbInvestmentService) : ControllerBase
{
    private readonly ICdbInvestmentService _cdbInvestmentService = cdbInvestmentService;

    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] CdbInvestmentRequestDto request)
    {
        var response = _cdbInvestmentService.CalculateCdbInvestment(request);
        return StatusCode(response.StatusCode, response);
    }
}