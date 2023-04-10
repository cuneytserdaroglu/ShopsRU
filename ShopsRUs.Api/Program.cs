using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using ShopsRUs.Repository;
using ShopsRUs.Repository.Repositories.EntityFramework.UoW;
using ShopsRUs.Service;
using ShopsRUs.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

#endregion

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);






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
