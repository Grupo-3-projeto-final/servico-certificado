namespace servico_certificado.Domain.interfaces
{
    public interface IHtmlParaPdf
    {
        byte[] ConverterHtmlParaPdf(string htmlContent);
    }
}