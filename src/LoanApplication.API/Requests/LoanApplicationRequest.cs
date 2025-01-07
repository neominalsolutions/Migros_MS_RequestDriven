namespace LoanApplication.API.Requests
{
  // Controller DTO görevi gören nesne
  public record LoanApplicationRequest(string accountNumber,decimal amount);
  
}
