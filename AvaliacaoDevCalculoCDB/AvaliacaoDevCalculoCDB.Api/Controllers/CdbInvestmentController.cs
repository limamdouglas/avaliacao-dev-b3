using AvaliacaoDevCalculoCDB.Application.Contracts.v1.Services;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoDevCalculoCDB.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CdbInvestmentController : ControllerBase
{
    private readonly ICdbInvestmentService _cdbInvestmentService;

    public CdbInvestmentController(ICdbInvestmentService cdbInvestmentService)
    {
        _cdbInvestmentService = cdbInvestmentService;
    }

    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] CdbInvestmentRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _cdbInvestmentService.CalculateCdbInvestment(request);

        return Ok(result);
    }
}