


using MassTransit;
using Message.Contracts;

namespace CustomerCredit.API.Consumers
{

  // gelen kredi skor talebini tüketecek olan sınıf.
  public class CreditScoreConsumer : IConsumer<GetCreditScoreRequest>
  {
    public async Task Consume(ConsumeContext<GetCreditScoreRequest> context)
    {
      try
      {
        // eğer client request de bir hata meydana gelirs
        // 1.yöntem
        throw new InvalidOperationException("Hata Meydana geldi");

        
      }
      catch (Exception ex)
      {
        await context.Publish<Fault<GetCreditScoreFaultResponse>>(ex.Message);
      }


      // Eğer hata yerine response dönerse buradan devam edelim.
      //// yıllık kazancın yüzde 30 kadar kredi alınabilir
      //if((context.Message.annualIncome * 0.30M) >= context.Message.requestAmount) {
      //  await context.RespondAsync(new CreditIsSuitableResponse(context.Message.requestAmount * 0.90M, 187));
      //}
      //else
      //{
      //  await context.RespondAsync(new CreditIsNotSuitableResponse("Kredi Notunuzu Düşük",90));
      //}

    }
  }
}
