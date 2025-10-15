using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SimpleServiceInvoice.ViewModels;

namespace SimpleServiceInvoice.Services
{
    //extract to interface to support multiple formats
    public class ReportService
    {
        public string GenerateInvoice(InvoiceViewModel invoice)
        {
            string resultPath = $"Invoice-{invoice.Id}-{invoice.InvoiceDate?.ToString("yyyy-MM-dd")}.pdf";

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.DefaultTextStyle(x => x.FontSize(10));
                    page.Margin(1.3F, Unit.Centimetre);
                    page.Content().Container()
                    .Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.RelativeItem(7).PaddingTop(10).ScaleToFit().Text(text =>
                            {
                                text.Line(invoice.Provider.Name).FontColor(Colors.Blue.Darken4).FontSize(20).Bold();
                                text.EmptyLine();
                                text.Line(invoice.Provider.Address).FontColor(Colors.Black).FontSize(16);
                                text.Line($"Phone: {invoice.Provider.Phone}").FontColor(Colors.Black).FontSize(16);
                            });
                            row.RelativeItem(3).Text("INVOICE").FontColor(Colors.Blue.Darken4).FontSize(30).AlignRight();
                        });

                        column.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                });

                                //BILL TO
                                table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("BILL TO").FontColor(Colors.White);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text(invoice.Customer.ContactName);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text(invoice.Customer.Name);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text(invoice.Customer.Address);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text(invoice.Customer.Phone);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text(invoice.Customer.Email);
                            });
                            row.RelativeItem(5).Column(column =>
                            {
                                column.Spacing(10);
                                //INVOICE # & DATE
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(4);
                                        columns.RelativeColumn(6);
                                    });
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("INVOICE #").FontColor(Colors.White);
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("DATE").FontColor(Colors.White);
                                    table.Cell().Padding(5).Text(invoice.InvoiceNumber);
                                    table.Cell().Padding(5).Text(invoice.InvoiceDate?.ToShortDateString());
                                });
                                //CUSTOMERID & TERMS
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(4);
                                        columns.RelativeColumn(6);
                                    });
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("CUSTOMER ID").FontColor(Colors.White);
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("TERMS").FontColor(Colors.White);
                                    table.Cell().Padding(5).Text(invoice.Customer.Id.ToString());
                                    table.Cell().Padding(5).Text(invoice.Terms);
                                });
                            });
                        });

                        //Items
                        column.Item().PaddingTop(20).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(10);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(5);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("DESCRIPTION").FontColor(Colors.White);
                                header.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("QTY").FontColor(Colors.White).AlignCenter();
                                header.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("UNIT PRICE").FontColor(Colors.White).AlignCenter();
                                header.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("AMOUNT").FontColor(Colors.White).AlignCenter();
                            });

                            foreach (var item in invoice.Items)
                            {
                                table.Cell().Border(1, Colors.Black).Padding(5).Text(item.Service.Description);
                                table.Cell().Border(1, Colors.Black).Padding(5).Text(item.Quantity.ToString()).AlignRight();
                                table.Cell().Border(1, Colors.Black).Padding(5).Text(item.UnitPrice.ToString("N2")).AlignRight();
                                table.Cell().Border(1, Colors.Black).Padding(5).Text(item.Total.ToString("N2")).AlignRight();
                            }

                            table.Cell().Border(1, Colors.Black).Padding(5).Text("Thank you for your business!").FontColor(Colors.Blue.Darken4).AlignCenter().Italic();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text("").AlignRight();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text("TOTAL").AlignRight();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text(invoice.Items.Sum(x => x.Total).ToString("N2")).AlignRight();
                        });

                        column.Item().PaddingTop(20).Text("If you have any questions about this invoice, please contact").FontSize(10).Italic().AlignCenter();
                        column.Item().Text("Cora Thomas at (516) 555-0135 or cora@example.com").FontSize(10).Bold().AlignCenter();
                    });
                });
            }).GeneratePdf(resultPath);

            return resultPath;
        }
    }
}
