namespace servico_certificado.Infrastructure.Utilities.Templates
{
    public class HtmlCertificado
    {
        public const string CERTFICADO_HTML = @"<!DOCTYPE html>
                                <html>
                                <head>
                                    <title>Certificado</title>
                                    {0}
                                </head>
                                <body>
                                    <div class=""certificate-content"">
                                        <div class=""seal""></div>
                                        <h2>Certificado</h2>
                                        <div class=""box-info"">
                                            <div class=""info"">
                                                <strong>Nome do Aluno:</strong> {1}
                                            </div>
                                            <div class=""info"">
                                                <strong>Nome do Curso:</strong> {2}
                                            </div>
                                            <div class=""info"">
                                                <strong>CPF:</strong> {3}
                                            </div>
                                        </div>
                                        <div class=""assinatura""></div>
                                    </div>
                                </body>
                                </html>
                                ";

        public const string STYLE_HTML_CERTIFICADO = @"<style>
                                        body {
                                            font-family: Arial, sans-serif;
                                            display: flex;
                                        }

                                        .certificate-content h2 {
                                            margin-bottom: 20px;
                                        }

                                        .info {
                                            margin-bottom: 10px;
                                        }

                                        .seal {
                                            width: 130px; /* Ajuste o tamanho do selo conforme necessário */
                                            height: 150px;
                                            background-image: url(""https://yata-apix-92a986e0-e179-47c9-a09c-c6db317186a2.s3-object.locaweb.com.br/e3f9fce317ad4ad79a36b708c717fa0b.png"");
                                            background-size: contain;
                                            background-repeat: no-repeat;
                                            position: absolute;
                                            top: 130px; /* Ajuste a posição vertical conforme necessário */
                                            left: 650px; /* Ajuste a posição horizontal conforme necessário */
                                        }

                                        .assinatura {
                                            width: 240px; /* Ajuste o tamanho do selo conforme necessário */
                                            height: 210px;
                                            background-image: url(""https://upload.wikimedia.org/wikipedia/commons/7/7f/Assinatura_Jos%C3%A9_Saramago.png"");
                                            background-size: contain;
                                            background-repeat: no-repeat;
                                            position: absolute;
                                            top: 10px; 
                                            left: 10px;
                                        }
                                    </style>";
    }
}
