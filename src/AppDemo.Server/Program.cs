using  AppDemo.Server.Domain;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/ping", () => "pong")
        .WithName("GetWeatherForecast")
        .WithOpenApi();
app.MapGet("/sum",(int x,int y)=> Calc.Add(x,y))
        .WithName("sum")
        .WithOpenApi();

app.Run();
