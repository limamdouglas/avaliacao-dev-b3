using AvaliacaoDevCalculoCDB.Domain.Resources.v1;

namespace AvaliacaoDevCalculoCDB.Domain.Entities.v1;

public class CdbInvestment
{
    public decimal InitialValue { get; set; }
    public decimal GrossReturn { get; set; }
    public decimal NetReturn { get; set; }

    public void Calculate(int months)
    {
        GrossReturn = CalculateGrossReturn(months);
        var taxRate = GetTaxRate(months);
        NetReturn = CalculateNetReturn(taxRate);
    }

    private decimal CalculateGrossReturn(int months)
    {
        decimal accumulatedValue = InitialValue;
        for (int i = 0; i < months; i++)
        {
            accumulatedValue *= (1 + (Constants.CDI * Constants.TB));
        }
        return accumulatedValue;
    }

    private decimal CalculateNetReturn(decimal taxRate)
    {
        var profit = GrossReturn - InitialValue;
        return GrossReturn - (profit * taxRate);
    }

    private static decimal GetTaxRate(int months)
    {
        return months switch
        {
            <= 6 => 0.225m,
            <= 12 => 0.20m,
            <= 24 => 0.175m,
            _ => 0.15m
        };
    }
}