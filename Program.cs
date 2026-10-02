using DeskFlowApi.Services;
using DeskFlowApi.Context;
using Microsoft.EntityFrameworkCore;
using DeskFlowApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChamadoService>();
builder.Services.AddScoped<ChamadoRepository>();

builder.Services.AddScoped<InteracaoService>();
builder.Services.AddScoped<InteracaoRepository>();

builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<CategoriaRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();