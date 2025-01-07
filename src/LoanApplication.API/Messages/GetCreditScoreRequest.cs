namespace Message.Contracts
{
  // term vade sayısı
  // annualIncome yıllık gelir
  // accountNumber banka hesap no
  // requestAmount istenen miktar
  public record GetCreditScoreRequest(string accountNumber,decimal annualIncome,decimal requestAmount,int term);
  
}
