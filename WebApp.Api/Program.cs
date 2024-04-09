using Microsoft.EntityFrameworkCore;
using WebApp.Api.Extensions;
using WebApp.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureOptions();
builder.Services.ConfigureRateLimit(builder.Configuration);
builder.Services.ConfigureExceptionHandler();
builder.Services.ConfigureDependencies(builder.Configuration);
builder.Services.ConfigureCors(builder.Configuration);

builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsConfiguration.UiCors);

app.UseExceptionHandler(opt => { });

app.UseRateLimiter();

app.MapPlayersEndpoints();

app.Run();

public partial class Program { }
