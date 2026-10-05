using DeskFlowApi.Services;
using DeskFlowApi.Context;
using Microsoft.EntityFrameworkCore;
using DeskFlowApi.Repositories;
using DeskFlowApi.Middlewares;

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
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();