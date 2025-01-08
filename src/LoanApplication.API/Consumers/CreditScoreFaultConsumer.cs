using MassTransit;
using Message.Contracts;

namespace LoanApplication.API.Consumers
{
  public class CreditScoreFaultConsumer : IConsumer<Fault<GetCreditScoreFaultResponse>>
  {
  

    public async Task Consume(ConsumeContext<Fault<GetCreditScoreFaultResponse>> context)
    {
      await Console.Out.WriteLineAsync($"Hata: {context.Message}");

    
    }
  }
}
