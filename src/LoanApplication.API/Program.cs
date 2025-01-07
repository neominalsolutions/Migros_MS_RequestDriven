using LoanApplication.API.Consumers;
using MassTransit;
using Message.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(cfg =>
{
  // burada consumer yerine request client tan�m� yapaca��z.
  // get-credit-score �zerinden bir endpoint tan�m� yapt�k.
  cfg.AddRequestClient<GetCreditScoreRequest>(new Uri("exchange:get-credit-score"));
  // api/customer-credit/get-credit-score POST
  cfg.AddConsumer<CreditScoreFaultConsumer>();

  cfg.UsingRabbitMq((context, config) =>
  {
    config.Host(builder.Configuration.GetConnectionString("RabbitConn"));
    // requestin at�l�p response ald���n� servisde ayn� api da oldu�u gibi endpoint tan�m� yap�l�r.

    config.ReceiveEndpoint("get-credit-score_error", cfg => cfg.ConfigureConsumer<CreditScoreFaultConsumer>(context));
    config.ConfigureEndpoints(context);

  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
