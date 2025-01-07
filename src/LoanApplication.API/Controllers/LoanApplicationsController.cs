using LoanApplication.API.Requests;
using MassTransit;
using Message.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplication.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoanApplicationsController : ControllerBase
  {
    private readonly IRequestClient<GetCreditScoreRequest> requestClient;


    public LoanApplicationsController(IRequestClient<GetCreditScoreRequest> requestClient)
    {
      this.requestClient = requestClient;
    }

    [HttpPost]
    public async Task<IActionResult> POST([FromBody] LoanApplicationRequest req)
    {

    
        var request = new GetCreditScoreRequest(accountNumber: req.accountNumber, 1500000, requestAmount: req.amount, 12);
        var response = await this.requestClient.GetResponse<CreditIsSuitableResponse, CreditIsNotSuitableResponse,Fault<CreditScoreFaultResponse>>(request);



      if(response.Is(out Response<Fault<CreditScoreFaultResponse>> faultRes))
      {
        return Ok(faultRes.Message);

      }



      if (response.Is(out Response<CreditIsNotSuitableResponse> isNotSuitableRes))
        {
          await Console.Out.WriteLineAsync(isNotSuitableRes.Message.reason);
          return Ok(isNotSuitableRes.Message);
        }


        if (response.Is(out Response<CreditIsSuitableResponse> isSuitableRes))
        {
          await Console.Out.WriteLineAsync($"Score {isSuitableRes.Message.creditScore}, limit: {isSuitableRes.Message.availableLimit}");
        }


     
        return Ok(isSuitableRes.Message);


    }
  }
}
