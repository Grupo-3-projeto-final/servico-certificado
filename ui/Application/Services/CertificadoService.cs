using servico_certificado.Domain.Entities;
using servico_certificado.Domain.interfaces;
using servico_certificado.Domain.Interfaces;
using servico_certificado.Domain.Services;
using servico_certificado.Infrastructure.Contexto;
using servico_certificado.Infrastructure.Repositories;
using servico_certificado.Infrastructure.Utilities;

namespace servico_certificado.Application.Entities
{
    public class CertificadoService : ICertificadoService
    {
        private readonly IHtmlParaPdf _htmlParaPdf;

        public CertificadoService(IHtmlParaPdf htmlParaPdf)
        {
            _htmlParaPdf = htmlParaPdf;
        }

        public byte[] EmitirCertificado(string nome, string curso, string cpf)
        {
            var htmlCertificado = MontarHtmlCertificado.GerarHtmlCertificado(nome, curso, cpf);
            return _htmlParaPdf.ConverterHtmlParaPdf(htmlCertificado);
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
