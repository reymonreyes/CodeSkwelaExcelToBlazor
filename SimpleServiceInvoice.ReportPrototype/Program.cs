using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace SimpleServiceInvoice.ReportPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(0.8F, Unit.Inch);
                    page.Content().Container()
                    .Column(column =>
                    {
                        column.Item().Row(row =>
                        {
                            row.RelativeItem(7).PaddingTop(10).ScaleToFit().Text(text =>
                            {
                                text.Line("First Up Consultants").FontColor(Colors.Blue.Darken4).FontSize(20).Bold();
                                text.EmptyLine();
                                text.Line("12 Beacon St.").FontColor(Colors.Black).FontSize(16);
                                text.Line("Boston, MA 98765").FontColor(Colors.Black).FontSize(16);
                                text.Line("Phone: (516) 555-0135").FontColor(Colors.Black).FontSize(16);
                            });
                            row.RelativeItem(3).Text("INVOICE").FontColor(Colors.Blue.Darken4).FontSize(30).AlignRight();
                        });
                        //BILL TO
                        column.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem(6).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("BILL TO").FontColor(Colors.White);
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("Jordan Mitchell");
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("Khusa Marketing");
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("123 Main Street");
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("Seattle, WA 87654");
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("(954) 555-0190");
                                table.Cell().PaddingLeft(5).PaddingTop(3).Text("jordan@example.com");
                            });
                            row.RelativeItem(4).Column(column =>
                            {
                                column.Spacing(10);
                                //INVOICE # & DATE
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(5);
                                        columns.RelativeColumn(5);
                                    });
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("INVOICE #").FontColor(Colors.White);
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("DATE").FontColor(Colors.White);
                                    table.Cell().Padding(5).Text("2034");
                                    table.Cell().Padding(5).Text("13/10/2025");
                                });
                                //CUSTOMERID & TERMS
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(5);
                                        columns.RelativeColumn(5);
                                    });
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("CUSTOMER ID").FontColor(Colors.White);
                                    table.Cell().Background(Colors.Blue.Darken4).Border(1, Colors.Black).Padding(5).Text("TERMS").FontColor(Colors.White);
                                    table.Cell().Padding(5).Text("2034");
                                    table.Cell().Padding(5).Text("13/10/2025");
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

                            foreach (var i in Enumerable.Range(1, 5))
                            {
                                table.Cell().Border(1, Colors.Black).Padding(5).Text("Service fee");
                                table.Cell().Border(1, Colors.Black).Padding(5).Text("1").AlignRight();
                                table.Cell().Border(1, Colors.Black).Padding(5).Text("23.23").AlignRight();
                                table.Cell().Border(1, Colors.Black).Padding(5).Text("23.23").AlignRight();
                            }

                            table.Cell().Border(1, Colors.Black).Padding(5).Text("Thank you for your business!").FontColor(Colors.Blue.Darken4).AlignCenter().Italic();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text("").AlignRight();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text("TOTAL").AlignRight();
                            table.Cell().Border(1, Colors.Black).Padding(5).Text("123.23").AlignRight();
                        });

                        column.Item().PaddingTop(20).Text("If you have any questions about this invoice, please contact").FontSize(10).Italic().AlignCenter();
                        column.Item().Text("Cora Thomas at (516) 555-0135 or cora@example.com").FontSize(10).Bold().AlignCenter();
                    });                    
                });
            }).ShowInCompanion();
        }
    }
}
