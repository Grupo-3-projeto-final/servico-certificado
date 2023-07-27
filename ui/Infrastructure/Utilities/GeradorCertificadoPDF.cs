namespace servico_certificado.Infrastructure.Utilities
{
    public static class HtmlParaPdf 
    {
        public static byte[] ConverterHtmlParaPdf(string htmlContent)
        {
            var modifiedHtmlContent = $@"
                <style>
                 @page {{ size: landscape; margin: 0; }}
                    .certificate-content {{
                        position: absolute;
                        top: 0;
                        left: 0;
                        width: 96%;
                        height: 92%;
                        text-align: center;
                        background-color: rgba(255, 255, 255, 0.8);
                        padding: 20px;
                        border-radius: 10px;
                        background-image: url(""https://www.transparentpng.com/thumb/certificate-template/certificate-template-png-1.png"");
                        background-size: cover;
                    }}
                </style>
                <div class='certificate-content'>
                    {htmlContent}
                </div>";

            var renderer = new ChromePdfRenderer();
            var pdfDocument = renderer.RenderHtmlAsPdf(modifiedHtmlContent);

            return pdfDocument.Stream.ToArray();
        }
    }
}

