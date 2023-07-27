using servico_certificado.Application.Entities;
using servico_certificado.Domain.interfaces;
using servico_certificado.Infrastructure.Utilities;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddEnvironmentVariables(); // Carrega as variáveis de ambiente

// Injeção de dependência
builder.Services.AddScoped<IHtmlParaPdf, HtmlParaPdf>();
builder.Services.AddScoped<CertificadoService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
