using ApiIdentityEndpoint.Data;
using ApiIdentityEndpoint.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Server=localhost,1433;Database=Identity-db;User Id=sa;Password=Root@123;Trusted_Connection=False; TrustServerCertificate=True;"));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapSwagger();

app.MapGet("/", () => "Hello World")
    .RequireAuthorization();

app.MapIdentityApi<User>();

app.Run();