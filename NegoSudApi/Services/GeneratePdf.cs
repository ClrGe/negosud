using NegoSudApi.Models.Interfaces;
using NegoSudApi.Services.Interfaces;

namespace NegoSudApi.Services;

using System.Globalization;
using Aspose.Pdf.Operators;
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;

public class GeneratePdf : IDisposable
{
    private readonly CultureInfo _cultureInfo;
    private readonly Color _textColor;
    private readonly Color _backColor;
    private readonly Font _timeNewRomanFont;
    private readonly Page _pdfPage;
    private readonly Document _pdfDocument;
    private readonly Rectangle _logoPlaceHolder;
    private readonly string _invoiceNumber;
    private readonly LogoImage _logo;
    private readonly List<string> _billFrom;
    private readonly List<string> _billTo;
    private readonly List<IOrderLine> _orderLines;
    private readonly List<TotalRow> _totalsRow;
    private readonly List<string> _details;
    private readonly string _footer;
    private readonly IVatService _vatService;

    /// <summary>
    /// Class uses to generate an invoice PDF 
    /// </summary>
    /// <param name="invoiceNumber">The number of the invoice. Include the date and the Customer's id</param>
    /// <param name="billTo">The Customer info</param>
    /// <param name="orderLines">The details of the order</param>
    /// <param name="vatService">The value added Tax for the bottle(s)</param>
    public GeneratePdf(string invoiceNumber, List<string> billTo, List<IOrderLine> orderLines,
        IVatService vatService)
    {
        _invoiceNumber = invoiceNumber;
        _billFrom = new List<string>
            {"NegoSud", "80 avenue Edmund Halley", "Saint-Étienne-du-Rouvray", "76800", "France"};
        _billTo = billTo;
        _orderLines = orderLines;
        _vatService = vatService;
        _totalsRow = new List<TotalRow>();
        _details = new List<string>
        {
            "Termes et conditions",
            string.Empty,
            "Si vous avez la moindre question concernant votre facture, n'hesitez pas nous contacter via le formulaire de contact : url formulaire.",
            string.Empty,
            "Merci pour votre achat chez NegoSud"
        };
        _footer = "site e-commerce link";
        _logo = new LogoImage("C:\\temp\\logo.png", 160, 120);
        _cultureInfo = new CultureInfo("fr-FR");
        _pdfDocument = new Document();
        _pdfDocument.PageInfo.Margin.Left = 36;
        _pdfDocument.PageInfo.Margin.Right = 36;
        _pdfPage = _pdfDocument.Pages.Add();
        _textColor = Color.Black;
        _backColor = Color.Parse("#C85161");
        _logoPlaceHolder = new Rectangle(20, 700, 120, 800);
        _timeNewRomanFont = FontRepository.FindFont("Times New Roman");
    }

    public byte[] Save()
    {
        HeaderSection();
        AddressSection();
        GridSection();
        TermsSection();
        FooterSection();

        using var stream = new MemoryStream();
        _pdfDocument.Save(stream);
        return stream.ToArray();
    }
    
    public string SaveLocally()
    {
        HeaderSection();
        AddressSection();
        GridSection();
        TermsSection();
        FooterSection();

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "temp.pdf");
        using var stream = new FileStream(filePath, FileMode.Create);
        _pdfDocument.Save(stream);
        return filePath;
    }

    private void HeaderSection()
    {
        var lines = new TextFragment[2];
        // Create text fragment
        lines[0] = new TextFragment($"Facture #{_invoiceNumber}")
        {
            TextState =
            {
                FontSize = 20,
                ForegroundColor = _textColor
            },
            HorizontalAlignment = HorizontalAlignment.Center
        };

        _pdfPage.Paragraphs.Add(lines[0]);

        lines[1] = new TextFragment($"DATE: {DateTime.Today:MM/dd/yyyy}");
        for (var i = 1; i < lines.Length; i++)
        {
            // Set text properties                
            lines[i].TextState.Font = _timeNewRomanFont;
            lines[i].TextState.FontSize = 12;
            lines[i].HorizontalAlignment = HorizontalAlignment.Right;

            // Add fragment to paragraph
            _pdfPage.Paragraphs.Add(lines[i]);
        }

        // Logo: set coordinates
        _logoPlaceHolder.URX = _logoPlaceHolder.LLX + _logo.Width;
        _logoPlaceHolder.URY = _logoPlaceHolder.LLY + _logo.Height;

        // Load image into stream
        var imageStream = new FileStream(_logo.FilePath, FileMode.Open);
        // Add image to Images collection of Page Resources
        _pdfPage.Resources.Images.Add(imageStream);

        // Create Matrix object
        var matrix = new Matrix(new[]
        {
            _logoPlaceHolder.URX - _logoPlaceHolder.LLX, 0, 0,
            _logoPlaceHolder.URY - _logoPlaceHolder.LLY,
            _logoPlaceHolder.LLX, _logoPlaceHolder.LLY
        });

        // Using ConcatenateMatrix (concatenate matrix) operator: defines how image must be placed
        _pdfPage.Contents.Add(new ConcatenateMatrix(matrix));

        var xImage = _pdfPage.Resources.Images[_pdfPage.Resources.Images.Count];
        // Using Do operator: this operator draws image
        _pdfPage.Contents.Add(new Do(xImage.Name));
    }

    private void AddressSection()
    {
        var box = new FloatingBox(524, 120)
        {
            ColumnInfo =
            {
                ColumnCount = 2,
                ColumnWidths = "252 252"
            },
            Padding =
            {
                Top = 20
            }
        };
        TextFragment fragment;

        _billFrom.Insert(0, "");
        foreach (var str in _billFrom)
        {
            fragment = new TextFragment(str)
            {
                TextState =
                {
                    Font = _timeNewRomanFont,
                    FontSize = 12
                }
            };
            // Add fragment to paragraph
            box.Paragraphs.Add(fragment);
        }

        fragment = new TextFragment("Facturé à")
        {
            IsFirstParagraphInColumn = true,
            TextState =
            {
                Font = _timeNewRomanFont,
                FontSize = 12,
                HorizontalAlignment = HorizontalAlignment.Right
            }
        };
        box.Paragraphs.Add(fragment);

        foreach (var str in _billTo)
        {
            fragment = new TextFragment(str)
            {
                TextState =
                {
                    Font = _timeNewRomanFont,
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Right,
                }
            };
            // Add fragment to paragraph
            box.Paragraphs.Add(fragment);
        }

        _pdfPage.Paragraphs.Add(box);
    }

    private void GridSection()
    {
        decimal vatRAte = 0;

        // Initializes a new instance of the Table
        var table = new Table
        {
            ColumnWidths = "26 257 78 78 78",
            Border = new BorderInfo(BorderSide.Box, 1f, _textColor),
            DefaultCellBorder = new BorderInfo(BorderSide.Box, 0.5f, _textColor),
            DefaultCellPadding = new MarginInfo(4.5, 4.5, 4.5, 4.5),
            Margin =
            {
                Bottom = 10
            },
            DefaultCellTextState =
            {
                Font = _timeNewRomanFont
            }
        };

        var headerRow = table.Rows.Add();
        var cell = headerRow.Cells.Add("#");
        cell.Alignment = HorizontalAlignment.Center;
        headerRow.Cells.Add("Produits");
        headerRow.Cells.Add("Prix");
        headerRow.Cells.Add("Quantité");
        headerRow.Cells.Add("Total");
        foreach (Cell headerRowCell in headerRow.Cells)
        {
            headerRowCell.BackgroundColor = _backColor;
            headerRowCell.DefaultCellTextState.ForegroundColor = Color.White;
        }

        var lineTotal = new List<decimal>();
        var numberLine = 1;

        foreach (var orderLine in _orderLines)
        {
            vatRAte = (decimal) _vatService.GetVatAsync(orderLine.Bottle.Vat.Id).Result.Value;
            var row = table.Rows.Add();
            cell = row.Cells.Add(numberLine.ToString());
            cell.Alignment = HorizontalAlignment.Center;
            row.Cells.Add(orderLine.Bottle.FullName);
            cell = row.Cells.Add(((decimal) orderLine.Bottle.CustomerPrice).ToString("C2", _cultureInfo));
            cell.Alignment = HorizontalAlignment.Right;
            cell = row.Cells.Add(orderLine.Quantity.ToString());
            cell.Alignment = HorizontalAlignment.Right;
            cell = row.Cells.Add(
                ((decimal) (orderLine.Bottle.CustomerPrice * orderLine.Quantity)).ToString("C2", _cultureInfo));
            lineTotal.Add((decimal) (orderLine.Bottle.CustomerPrice * orderLine.Quantity));
            cell.Alignment = HorizontalAlignment.Right;
            numberLine++;
        }


        var subTotal = lineTotal.Sum();
        _totalsRow.Add(new TotalRow("Sous total", subTotal));
        _totalsRow.Add(new TotalRow($"TVA à {vatRAte:P0}", subTotal * vatRAte));
        _totalsRow.Add(new TotalRow("Total", subTotal * (1 + vatRAte)));
        foreach (var totalRow in _totalsRow)
        {
            var row = table.Rows.Add();
            var nameCell = row.Cells.Add(totalRow.Text);
            nameCell.ColSpan = 4;
            var textCell = row.Cells.Add(totalRow.Value.ToString("C2", _cultureInfo));
            textCell.Alignment = HorizontalAlignment.Right;
        }

        _pdfPage.Paragraphs.Add(table);
    }


private void TermsSection()
    {
        foreach (var fragment in _details.Select(detail => new TextFragment(detail)
                 {
                     TextState =
                     {
                         Font = _timeNewRomanFont,
                         FontSize = 12
                     }
                 }))
        {
            _pdfPage.Paragraphs.Add(fragment);
        }
    }

    private void FooterSection()
    {
        var fragment = new TextFragment(_footer);
        var len = fragment.TextState.MeasureString(fragment.Text);
        fragment.Position = new Position(_pdfPage.PageInfo.Width / 2 - len / 2, 20);
        fragment.Hyperlink = new WebHyperlink(_footer);
        var builder = new TextBuilder(_pdfPage);

        builder.AppendText(fragment);
    }

    #region IDisposable Support

    private bool _disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _pdfPage.Dispose();
                _pdfDocument.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }

    #endregion
}

public class TotalRow
{
    public readonly string Text;
    public readonly decimal Value;

    public TotalRow(string text, decimal value)
    {
        Text = text;
        Value = value;
    }                
}

public class LogoImage
{
    public readonly string FilePath;
    public readonly int Width;
    public readonly int Height;

    public LogoImage(string filePath, int width, int height)
    {
        FilePath = filePath;
        Width = width;
        Height = height;
    }
}