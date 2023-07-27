using servico_certificado.Domain.interfaces;
using servico_certificado.Infrastructure.Utilities;
using servico_certificado.Web.Routes;
using WkHtmlToPdfDotNet.Contracts;
using WkHtmlToPdfDotNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddScoped<IHtmlParaPdf, HtmlParaPdf>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

new GerarCertificadoRoute(app).Register();

app.Run();