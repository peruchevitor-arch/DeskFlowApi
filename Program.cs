using DeskFlowApi.Services;
using DeskFlowApi.Context;
using Microsoft.EntityFrameworkCore;
using DeskFlowApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();
builder.Services.AddScoped<ChamadoService>();
builder.Services.AddScoped<ChamadoRepository>();

app.Run();
