using Balinware.Finanzas.Application.UseCases;
using Balinware.Finanzas.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseAuthorization();

app.MapControllers();

app.Run();
