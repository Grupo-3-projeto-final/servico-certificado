using servico_certificado.Domain.Entities;

namespace servico_certificado.Domain.Interfaces
{
    public interface ICertificadoService
    {
        Task SalvarDadosCertificado(CertificadoAluno dadosCertificado);
        byte[] EmitirCertificado(string nome, string curso, string cpf);
    }
}