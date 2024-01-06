using CoffeShop.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CoffeShop.Services;
internal class CustomersDocument : IReport<List<Customer>>
{
    List<Customer> _customers = new List<Customer>();

    public void SetData(List<Customer> data)
    {
        _customers = data;
    }

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

                page.Footer().AlignCenter().Text(x =>
                {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
    }

    void ComposeHeader(IContainer container)
    {
        var titleStyle = TextStyle.Default
            .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

        container.Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().Text($"Coffee Shop Customers Report").Style(titleStyle);

                column.Item().Text(text =>
                {
                    text.Span("Report Date: ").SemiBold();
                    text.Span($"{DateTime.Now:d}");
                });
            });

            row.ConstantItem(100).Height(50).Placeholder();
        });
    }

    void ComposeContent(IContainer container)
    {
        container.PaddingVertical(40).Column(column =>
        {
            column.Spacing(5);

            column.Item().Element(ComposeTable);
        });
    }

    void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(25);
                columns.RelativeColumn(3);
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            // step 2
            table.Header(header =>
            {
                header.Cell().Element(CellStyle).Text("#");
                header.Cell().Element(CellStyle).Text("Name");
                header.Cell().Element(CellStyle).AlignRight().Text("City");
                header.Cell().Element(CellStyle).AlignRight().Text("Age");

                static IContainer CellStyle(IContainer container)
                {
                    return container
                        .DefaultTextStyle(x => x.SemiBold())
                        .PaddingVertical(5)
                        .BorderBottom(1)
                        .BorderColor(Colors.Black);
                }
            });

            // step 3
            var index = 1;
            foreach (var customer in _customers)
            {
                table.Cell().Element(CellStyle).Text($"{index}");
                table.Cell().Element(CellStyle)
                    .Text($"{customer.FirstName} {customer.LastName}");
                table.Cell().Element(CellStyle).Text(customer.City);
                table.Cell().Element(CellStyle).AlignRight()
                    .Text($"{customer.Age}");
                index++;

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
