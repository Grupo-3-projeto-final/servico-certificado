using iText.StyledXmlParser.Jsoup.Nodes;
using servico_certificado.Infrastructure.Utilities.Templates;

namespace servico_certificado.Infrastructure.Utilities
{
    public static class MontarHtmlCertificado
    {
        public static string GerarHtmlCertificado(string nome, string curso, string cpf)
        {
            string htmlCertificado = HtmlCertificado.CERTFICADO_HTML;
            string styleHtmlCertificado = HtmlCertificado.STYLE_HTML_CERTIFICADO;

            return string.Format(htmlCertificado,
                                 styleHtmlCertificado,
                                 nome,
                                 curso,
                                 cpf);
        }
    }
}
