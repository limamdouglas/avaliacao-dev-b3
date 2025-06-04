namespace AvaliacaoDevCalculoCDB.Domain.Resources.v1;

public static class Messages
{
    public const string ServiceStart = "Starting CdbInvestmentService.";
    public const string ServiceEnd = "Finished CdbInvestmentService.";
    public const string InvalidInitialValueLog = "Invalid initial value provided: {0}.";
    public const string InvalidPeriodLog = "Invalid period provided: {0}.";
    public const string CalculationSuccessLog = "Calculation completed successfully for initial value: {0}, months: {1}.";
    public const string ServiceError = "An error occurred while executing CdbInvestmentService.";

    public const string InvalidInitialValue = "The initial value must be greater than zero.";
    public const string InvalidPeriod = "The period must be greater than zero.";
    public const string CalculationSuccess = "Calculation completed successfully.";
    public const string InternalServerError = "An internal server error occurred.";
}