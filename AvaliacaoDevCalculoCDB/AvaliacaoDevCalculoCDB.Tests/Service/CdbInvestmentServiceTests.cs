using AvaliacaoDevCalculoCDB.Application.Services.v1;
using AvaliacaoDevCalculoCDB.Domain.Dtos.v1.Request;
using AvaliacaoDevCalculoCDB.Domain.Resources.v1;
using Microsoft.Extensions.Logging;
using Moq;

namespace AvaliacaoDevCalculoCDB.Tests.Service;

public class CdbInvestmentServiceTests
{
    private readonly Mock<ILogger<CdbInvestmentService>> _mockLogger;
    private readonly CdbInvestmentService _service;

    public CdbInvestmentServiceTests()
    {
        _mockLogger = new Mock<ILogger<CdbInvestmentService>>();
        _service = new CdbInvestmentService(_mockLogger.Object);
    }

    [Fact]
    public void CalculateCdbInvestment_ShouldReturnBadRequest_WhenInitialValueIsInvalid()
    {
        // Arrange
        var dto = new CdbInvestmentRequestDto { InitialValue = 0, Months = 12 };

        // Act
        var response = _service.CalculateCdbInvestment(dto);

        // Assert
        Assert.Equal(400, response.StatusCode);
        Assert.Equal(Messages.InvalidInitialValue, response.Message);
    }

    [Fact]
    public void CalculateCdbInvestment_ShouldReturnBadRequest_WhenMonthsIsInvalid()
    {
        // Arrange
        var dto = new CdbInvestmentRequestDto { InitialValue = 1000m, Months = 0 };

        // Act
        var response = _service.CalculateCdbInvestment(dto);

        // Assert
        Assert.Equal(400, response.StatusCode);
        Assert.Equal(Messages.InvalidPeriod, response.Message);
    }

    [Fact]
    public void CalculateCdbInvestment_ShouldReturnSuccess_WhenInputIsValid()
    {
        // Arrange
        var dto = new CdbInvestmentRequestDto { InitialValue = 1000m, Months = 12 };

        // Act
        var response = _service.CalculateCdbInvestment(dto);

        // Assert
        Assert.Equal(200, response.StatusCode);
        Assert.NotNull(response.Data);
        Assert.Equal(1123.08m, response.Data.GrossReturn); 
        Assert.Equal(1098.46m, response.Data.NetReturn);  
    }
}