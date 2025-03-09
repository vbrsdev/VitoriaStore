using Microsoft.EntityFrameworkCore;
using VitoriaStore.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.services é uma injecao de dependencia = configuraçoes de servicos 
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VitoriaStoreDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DEV-DOCKER-SQLSERVER")));

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
