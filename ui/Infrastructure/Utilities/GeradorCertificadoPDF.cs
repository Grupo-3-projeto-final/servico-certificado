using servico_certificado.Domain.interfaces;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace servico_certificado.Infrastructure.Utilities
{
    public class HtmlParaPdf : IHtmlParaPdf
    {
        private readonly IConverter _converterPdf;
        public HtmlParaPdf(IConverter converterPdf)
        {
            _converterPdf = converterPdf;
        }
        public  byte[] ConverterHtmlParaPdf(string htmlContent)
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

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = modifiedHtmlContent,
                        WebSettings= { DefaultEncoding = "utf-8"}
                    }
                }
            };

            return _converterPdf.Convert(doc);
        }
    }
}

