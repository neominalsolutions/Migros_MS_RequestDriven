namespace Message.Contracts
{
  public record CreditIsNotSuitableResponse(string reason, int creditScore);
}
