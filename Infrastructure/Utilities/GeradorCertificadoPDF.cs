using System;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Layer;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace servico_certificado.Infrastructure.Utilities;
public class GeradorCertificadoPDF
{
    public byte[] GerarCertificado(string nome, string curso, string cpf)
        {
            
            string logoFilePath = "C:/TestePDF/logo/logoCertificado.png";

            using (MemoryStream ms = new MemoryStream())
            {
                using (var writer = new PdfWriter(ms))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf, PageSize.A4.Rotate()))
                {


                    Image logo = new Image(ImageDataFactory.Create(logoFilePath));
                    logo.SetFixedPosition(0, 0);
                    logo.ScaleToFit(document.GetPdfDocument().GetDefaultPageSize().GetWidth(), document.GetPdfDocument().GetDefaultPageSize().GetHeight());
                    document.Add(logo);

                    string titulo = "CERTIFICADO";
                    document.Add(new Paragraph(titulo).SetFontSize(32).SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("\n\n\n"));

                    string textoCertificado = "Certificamos que {0} concluiu o curso de {1}.";
                    string textoCPF = "CPF: {0}";

                    Paragraph certificado = new Paragraph(string.Format(textoCertificado, nome.ToUpper(), curso.ToUpper()))
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER);
                    document.Add(certificado);

                    Paragraph cpfParagrafo = new Paragraph(string.Format(textoCPF, cpf))
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER);
                    document.Add(cpfParagrafo);
                }

                return ms.ToArray();
            }
        }
}

