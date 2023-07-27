using Microsoft.AspNetCore.Mvc;
using servico_certificado.Application.Entities;
using servico_certificado.Domain.Entities;
using servico_certificado.Domain.interfaces;
using servico_certificado.Infrastructure;
using System.Threading.Tasks;

namespace servico_certificado.Web.Controllers
{
    [Route("api/v1/certificado")]
    [ApiController]
    public class GerarCertificadoController : ControllerBase
    {
        private readonly CertificadoService _certificado;

        public GerarCertificadoController(CertificadoService certificado)
        {
            _certificado = certificado;
        }

        [HttpPost]
        [Route("gerar-certificado")]
        public async Task<IActionResult> GerarCertificado([FromBody] DadosCertificado dados)
        {
            var pdfBytes = _certificado.EmitirCertificado(dados.Nome, dados.Curso, dados.CPF);

            var dadosCertificado = new CertificadoAluno
            {
                Nome = dados.Nome,
                Curso = dados.Curso,
                Cpf = dados.CPF
            };

            await _certificado.SalvarDadosCertificado(dadosCertificado);

            return File(pdfBytes, "application/pdf", "Certificado.pdf");
        }
    }
}