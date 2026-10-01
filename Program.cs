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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();


app.Run();
