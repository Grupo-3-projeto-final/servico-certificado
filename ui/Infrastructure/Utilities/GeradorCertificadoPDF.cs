namespace servico_certificado.Infrastructure.Utilities
{
    public static class HtmlParaPdf 
    {
        public static byte[] ConverterHtmlParaPdf(string htmlContent)
        {
            var renderer = new ChromePdfRenderer();

            var pdfDocument = renderer.RenderHtmlAsPdf(htmlContent);

            return pdfDocument.Stream.ToArray();
        }
    }
}

