using AvaliacaoDevCalculoCDB.Domain.Entities.v1;

namespace AvaliacaoDevCalculoCDB.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Calculate_ShouldReturnCorrectGrossAndNetReturns()
        {
            decimal initialValue = 1000m;
            int months = 12;
            var cdbInvestment = new CdbInvestment
            {
                InitialValue = initialValue
            };
            cdbInvestment.Calculate(months);

            Assert.Equal(1103.06m, Math.Round(cdbInvestment.GrossReturn, 2)); 
            Assert.Equal(1082.45m, Math.Round(cdbInvestment.NetReturn, 2));   
        }
    }
}