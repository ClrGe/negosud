using Aspose.Pdf.Operators;

namespace NegoSudApi.Services;

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using NegoSudApi.Models;

public class GeneratePdf : IDisposable
{
    #region Private memebers

    private static readonly License Licence = new License();
    private Color _textColor, _backColor;
    private readonly Font _timeNewRomanFont;
    private readonly TextBuilder _builder;
    private readonly Page _pdfPage;
    private readonly Document _pdfDocument;
    private readonly Rectangle _logoPlaceHolder;

    #endregion

    public string ForegroundColor
    {
        get { return _textColor.ToString(); }
        set { _textColor = Color.Parse(value); }
    }

    public string BackgroundColor
    {
        get { return _backColor.ToString(); }
        set { _backColor = Color.Parse(value); }
    }

    //Invoice details
    public string Number;
    public uint PaymentPeriod = 14;
    public LogoImage Logo;
    public List<string> BillFrom;
    public List<string> BillTo;
    public List<Bottle> Bottles;
    public List<TotalRow> Totals;
    public List<string> Details;
    public string Footer;

    public GeneratePdf()
    {
        _pdfDocument = new Document();
        _pdfDocument.PageInfo.Margin.Left = 36;
        _pdfDocument.PageInfo.Margin.Right = 36;
        _pdfPage = _pdfDocument.Pages.Add();
        _textColor = Color.Black;
        _backColor = Color.Transparent;
        _logoPlaceHolder = new Rectangle(20, 700, 120, 800);
        _timeNewRomanFont = FontRepository.FindFont("Times New Roman");
        _builder = new TextBuilder(_pdfPage);
    }

    public void Save(Stream stream)
    {
        HeaderSection();
        AddressSection();
        GridSection();
        TermsSection();
        FooterSection();

        _pdfDocument.Save(stream);
    }

    private void HeaderSection()
    {
        var lines = new TextFragment[3];
        // Create text fragment
        lines[0] = new TextFragment($"INVOICE #{Number}");
        lines[0].TextState.FontSize = 20;
        lines[0].TextState.ForegroundColor = _textColor;
        lines[0].HorizontalAlignment = HorizontalAlignment.Center;

        _pdfPage.Paragraphs.Add(lines[0]);

        lines[1] = new TextFragment($"DATE: {DateTime.Today:MM/dd/yyyy}");
        lines[2] = new TextFragment($"DUE DATE: {DateTime.Today.AddDays(PaymentPeriod):MM/dd/yyyy}");
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
        _logoPlaceHolder.URX = _logoPlaceHolder.LLX + Logo.Width;
        _logoPlaceHolder.URY = _logoPlaceHolder.LLY + Logo.Height;

        // Load image into stream
        var imageStream = new FileStream(Logo.FileName, FileMode.Open);
        // Add image to Images collection of Page Resources
        _pdfPage.Resources.Images.Add(imageStream);
        // Using GSave operator: this operator saves current graphics state
        // _pdfPage.Contents.Add(new Operator.GSave());
        // Create Matrix object
        var matrix = new Matrix(new[]
        {
            _logoPlaceHolder.URX - _logoPlaceHolder.LLX, 0, 0,
            _logoPlaceHolder.URY - _logoPlaceHolder.LLY,
            _logoPlaceHolder.LLX, _logoPlaceHolder.LLY
        });
        // Using ConcatenateMatrix (concatenate matrix) operator: defines how image must be placed
        _pdfPage.Contents.Add(new ConcatenateMatrix(matrix));
        var ximage = _pdfPage.Resources.Images[_pdfPage.Resources.Images.Count];
        // Using Do operator: this operator draws image
        _pdfPage.Contents.Add(new Do(ximage.Name));
        // Using GRestore operator: this operator restores graphics state
        // _pdfPage.Contents.Add(new Operator.GRestore());
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

        BillFrom.Insert(0, "");
        foreach (var str in BillFrom)
        {
            fragment = new TextFragment(str);
            fragment.TextState.Font = _timeNewRomanFont;
            fragment.TextState.FontSize = 12;
            // Add fragment to paragraph
            box.Paragraphs.Add(fragment);
        }

        fragment = new TextFragment("Facturé à") {IsFirstParagraphInColumn = true};
        fragment.TextState.Font = _timeNewRomanFont;
        fragment.TextState.FontSize = 12;
        fragment.TextState.HorizontalAlignment = HorizontalAlignment.Right;
        box.Paragraphs.Add(fragment);

        foreach (var str in BillTo)
        {
            fragment = new TextFragment(str);
            fragment.TextState.Font = _timeNewRomanFont;
            fragment.TextState.FontSize = 12;
            fragment.TextState.HorizontalAlignment = HorizontalAlignment.Right;
            // Add fragment to paragraph
            box.Paragraphs.Add(fragment);
        }

        _pdfPage.Paragraphs.Add(box);
    }

    private void GridSection()
    {
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
        headerRow.Cells.Add("Sous Total");
        foreach (Cell headerRowCell in headerRow.Cells)
        {
            headerRowCell.BackgroundColor = _textColor;
            headerRowCell.DefaultCellTextState.ForegroundColor = _backColor;
        }

        foreach (var bottle in Bottles)
        {
            var row = table.Rows.Add();
            cell = row.Cells.Add(bottle.Id.ToString());
            cell.Alignment = HorizontalAlignment.Center;
            row.Cells.Add(bottle.FullName);
            cell = row.Cells.Add(((decimal) bottle.CurrentPrice).ToString("C2"));
            cell.Alignment = HorizontalAlignment.Right;
            // cell = row.Cells.Add(bottle.Quantity.ToString());
            // cell.Alignment = HorizontalAlignment.Right;
            // cell = row.Cells.Add(bottle.Total.ToString("C2"));
            // cell.Alignment = HorizontalAlignment.Right;
        }

        foreach (var totalRow in Totals)
        {
            var row = table.Rows.Add();
            var nameCell = row.Cells.Add(totalRow.Text);
            nameCell.ColSpan = 4;
            var textCell = row.Cells.Add(totalRow.Value.ToString("C2"));
            textCell.Alignment = HorizontalAlignment.Right;
        }

        _pdfPage.Paragraphs.Add(table);
    }

    private void TermsSection()
    {
        foreach (var detail in Details)
        {
            var fragment = new TextFragment(detail);
            fragment.TextState.Font = _timeNewRomanFont;
            fragment.TextState.FontSize = 12;
            _pdfPage.Paragraphs.Add(fragment);
        }
    }

    private void FooterSection()
    {
        var fragment = new TextFragment(Footer);
        var len = fragment.TextState.MeasureString(fragment.Text);
        fragment.Position = new Position(_pdfPage.PageInfo.Width / 2 - len / 2, 20);
        fragment.Hyperlink = new WebHyperlink(Footer);
        var builder = new TextBuilder(_pdfPage);

        builder.AppendText(fragment);
    }

    #region IDisposable Support

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _pdfPage.Dispose();
                _pdfDocument.Dispose();
            }

            disposedValue = true;
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
    public string Text;
    public decimal Value;

    public TotalRow(string text, decimal value)
    {
        Text = text;
        Value = value;
    }                
}

public class LogoImage
{
    public string FileName;
    public int Width;
    public int Height;

    public LogoImage(string filename, int width, int height)
    {
        FileName = filename;
        Width = width;
        Height = height;
    }
}