using AvaliacaoDevCalculoCDB.Domain.Entities.v1;

namespace AvaliacaoDevCalculoCDB.Tests.Domain;

public class CdbInvestmentTests
{
    [Fact]
    public void Calculate_ShouldCalculateCorrectGrossAndNetReturn_ForValidMonths()
    {
        // Arrange
        var investment = new CdbInvestment { InitialValue = 1000m };
        int months = 12;

        // Act
        investment.Calculate(months);

        // Assert
        Assert.Equal(1123.08m, investment.GrossReturn); 
        Assert.Equal(1098.46m, investment.NetReturn);  
    }

    [Theory]
    [InlineData(6, 0.225)]
    [InlineData(12, 0.20)]
    [InlineData(24, 0.175)]
    [InlineData(36, 0.15)]
    public void GetTaxRate_ShouldReturnCorrectTaxRate(int months, decimal expectedTaxRate)
    {
        // Act
        var taxRate = CdbInvestment.GetTaxRate(months);

        // Assert
        Assert.Equal(expectedTaxRate, taxRate);
    }

    [Fact]
    public void Calculate_ShouldHandleEdgeCasesForInitialValueZero()
    {
        // Arrange
        var investment = new CdbInvestment { InitialValue = 0m };

        // Act
        investment.Calculate(12);

        // Assert
        Assert.Equal(0m, investment.GrossReturn);
        Assert.Equal(0m, investment.NetReturn);
    }
}