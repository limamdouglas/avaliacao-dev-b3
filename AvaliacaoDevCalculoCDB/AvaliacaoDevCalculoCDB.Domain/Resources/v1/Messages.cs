namespace AvaliacaoDevCalculoCDB.Domain.Resources.v1;

public static class Messages
{
    public const string ServiceStart = "Starting CdbInvestmentService.";
    public const string ServiceEnd = "Finished CdbInvestmentService.";

    public const string CalculationSuccessLog = "Calculation completed successfully for initial value: {InitialValue}, months: {Months}.";

    public const string InvalidInitialValue = "The initial value must be greater than zero.";
    public const string InvalidPeriod = "The period must be greater than zero.";
    public const string CalculationSuccess = "Calculation completed successfully.";

    public const string UnexpectedError = "An unexpected error occurred while calculating CDB investment.";
}