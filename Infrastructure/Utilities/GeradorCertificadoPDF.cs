using System;
using System.IO;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace servico_certificado.Infrastructure.Utilities;
public class GeradorCertificadoPDF
{
    public byte[] GerarCertificado(string nome, string curso, string cpf)
        {

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(curso) || string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("Os parâmetros nome, curso e cpf devem ser informados.");
            }

            using (MemoryStream ms = new MemoryStream())
            {

                using (var writer = new PdfWriter(ms))
                using (var pdf = new PdfDocument(writer))
                using (var document = new Document(pdf, PageSize.A4))
                {
                    document.Add(new Paragraph("CERTIFICADO").SetFontSize(32).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                    document.Add(new Paragraph("\n\n\n"));

                    document.Add(new Paragraph($"Certificamos que {nome.ToUpper()} concluiu o curso de {curso.ToUpper()}.").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    document.Add(new Paragraph($"CPF: {cpf}").SetFontSize(16).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                }

                return ms.ToArray();
            }
        }

}
