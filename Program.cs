using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using servico_certificado.Application.Entities;
using servico_certificado.Domain.Entities;
using servico_certificado.Infrastructure;
using servico_certificado.Infrastructure.Contexto;
using servico_certificado.Infrastructure.Utilities;

var builder = WebApplication.CreateBuilder(args);

/*var context = new BancoDeDadosContexto();
context.CertificadosAlunos.Add(new CertificadoAluno{
    Nome = "Douglas Dog", 
    Curso = "Computacao",
    Cpf = "1292773737"
});

context.SaveChanges();*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () =>
{

    return new {
        Mensagem = "Bem vindo a API servico-certificado"
    };
})
.WithName("GetWeatherForecast")
.WithOpenApi();

var _geradorCertificadoPDF =  new GeradorCertificadoPDF();

CertificadoService _certificado = new CertificadoService(_geradorCertificadoPDF);

app.MapPost("/gerar-certificado", (HttpContext context, [FromBody] DadosCertificado dados) =>
{
    var pdfBytes = _certificado.EmitirCertificado(dados.Nome, dados.Curso, dados.CPF);

    var dadosCertificado = new CertificadoAluno {
         Nome = dados.Nome,
        Curso = dados.Curso,
        Cpf = dados.CPF,
    };

    _certificado.SalvarDadosCertificado(dadosCertificado);

    context.Response.ContentType = "application/pdf";
    context.Response.Headers.Add("Content-Disposition", "attachment; filename=Certificado.pdf");
    context.Response.Body.WriteAsync(pdfBytes, 0, pdfBytes.Length);
})
.WithName("PostGerarCertificado")
.WithOpenApi();


app.Run();