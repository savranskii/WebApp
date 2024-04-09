using Microsoft.EntityFrameworkCore;
using WebApp.Api.Extensions;
using WebApp.Infrastructure.Contexts;

const string uiCors = "_UI";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureOptions();
builder.Services.ConfigureRateLimit(builder.Configuration);
builder.Services.ConfigureExceptionHandler();
builder.Services.ConfigureDependencies(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: uiCors, policy =>
    {
        policy.WithOrigins("https://localhost:7240", "http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

app.UseCors(uiCors);

app.UseExceptionHandler(opt => { });

app.UseRateLimiter();

app.MapPlayersEndpoints();

app.Run();

public partial class Program { }
