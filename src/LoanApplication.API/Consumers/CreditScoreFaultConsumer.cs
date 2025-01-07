using MassTransit;
using Message.Contracts;

namespace LoanApplication.API.Consumers
{
  public class CreditScoreFaultConsumer : IConsumer<Fault<CreditScoreFaultResponse>>
  {
  

    public async Task Consume(ConsumeContext<Fault<CreditScoreFaultResponse>> context)
    {
      await Console.Out.WriteLineAsync($"Hata: {context.Message}");
    }
  }
}
