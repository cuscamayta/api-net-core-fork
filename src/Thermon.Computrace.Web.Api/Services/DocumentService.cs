using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using Thermon.Computrace.Web.Application.Response;

namespace Thermon.Computrace.Web.Api.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IConverter _converter;

        public DocumentService(IConverter converter)
        {
            _converter = new SynchronizedConverter(new PdfTools());
        }

        public byte[] GeneratePdfFromString(List<Materials> items)
        {
            var htmlContent = $@"
           <!DOCTYPE html>
                <html>
                <head>

                </head>
                <body>
                <div style=""text-align:center""><h2 style=""font-family: arial, sans-serif;margin-bottom: 0;margin-top: 40px;"">Bill Of Materials</h2>
                <div style=""font-size: 12px;font-family: sans-serif;"">Computrace Cairo Version 0.1.1</div>
                </div>


                <div style=""margin-top: 35px;margin-bottom: 25px;font-family: sans-serif;"">
                <table>
                  <tr>
                    <td style=""font-weight: 700;"">Current Date</td>
                    <td style=""padding-left: 9px;"">[currentDate]</td>
                  </tr>
                  <tr>
                    <td style=""font-weight: 700;"">Customer</td>
                    <td style=""padding-left: 9px;"">N/A</td>
                  </tr>
                  <tr>
                    <td style=""font-weight: 700;"">Purchase Order Number</td>
                    <td style=""padding-left: 9px;"">N/A</td>
                  </tr>
                </table>
                </div>


                <table style=""font-family: arial, sans-serif;border-collapse: collapse;width: 100%;"">
                  <tr>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Item Number</th>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Part Number</th>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Catalog Number</th>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Description</th>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Quantity</th>
                    <th style=""border: 1px solid #dddddd;text-align: left;padding: 8px;background-color: #bc2523;color: white;"">Units</th>
                  </tr>
                  [body]
                </table>

                </body>
                </html>
            ";

            return GeneratePdf(htmlContent, items);
        }

        private string GenerateBodyTable(List<Materials> rows)
        {
            var body = string.Empty;
            foreach (var row in rows)
            {
                var currentRow = $@"
                 <tr>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.ItemNumber}</td>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.PartNumber}</td>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.CatalogNumber}</td>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.Description}</td>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.Quantity}</td>
                    <td style=""border: 1px solid #dddddd;text-align: left;padding: 8px;"">{row.Units}</td>
                 </tr>
                ";
                body += currentRow;
            }
            return body;
        }
        private byte[] GeneratePdf(string htmlContent, List<Materials> items)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.Letter,
                Margins = new MarginSettings { Top = 18, Bottom = 18 },
            };

            var htmlBody = GenerateBodyTable(items);
            htmlContent = htmlContent.Replace("[currentDate]", DateTime.Now.ToString("MM/dd/yyyy"));
            htmlContent = htmlContent.Replace("[body]", htmlBody);

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontSize = 10, Right = "Page [page] of [toPage]", Line = false },
                FooterSettings = { FontSize = 8, Center = "Computrace Cairo Version", Line = false },
            };

            var htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };

            return _converter.Convert(htmlToPdfDocument);
        }

    }
}
