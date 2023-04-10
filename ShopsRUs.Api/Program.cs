using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using ShopsRUs.Core.Exceptions;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using ShopsRUs.Repository;
using ShopsRUs.Repository.Repositories.EntityFramework;
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
builder.Services.AddHttpContextAccessor();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .MinimumLevel.Information()   //Default da information geliyor. Minimum bu logları al
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.WithProperty("AppDbContext", ctx.HostingEnvironment.ApplicationName)   
    );

var app = builder.Build();
app.ConfigureCustomExceptionMiddleware();
CreateDbIfNotExists(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Serilog.Log.Information("Api started");
app.Run();


static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogCritical(ex, "An error occurred creating the DB.");
        }
    }
}