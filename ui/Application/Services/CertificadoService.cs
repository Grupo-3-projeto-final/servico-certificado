using servico_certificado.Domain.Entities;
using servico_certificado.Domain.Services;
using servico_certificado.Infrastructure.Contexto;
using servico_certificado.Infrastructure.Repositories;
using servico_certificado.Infrastructure.Utilities;

namespace servico_certificado.Application.Entities
{
    public class CertificadoService
    {
        public byte[] EmitirCertificado(string nome, string curso, string cpf)
        {
            var htmlCertificado = MontarHtmlCertificado.GerarHtmlCertificado(nome, curso, cpf);
            return HtmlParaPdf.ConverterHtmlParaPdf(htmlCertificado);
        }

        public async Task SalvarDadosCertificado(CertificadoAluno dadosCertificado)
        {
            var context = new BancoDeDadosContexto();
            DadosCertificadoRepository _dadosCertificadoRepository = new DadosCertificadoRepository(context);
    
            var dadosCertificadoService = new DadosCertificadoService(_dadosCertificadoRepository);

            await dadosCertificadoService.SaveDadosCertificado(dadosCertificado);
        }
    }

}
