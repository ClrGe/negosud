namespace NegoSudApi.Services;

using System.Globalization;
using Aspose.Pdf.Operators;
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using NegoSudApi.Models.Interfaces;
using NegoSudApi.Services.Interfaces;

/// <summary>
/// Class uses to generate an invoice PDF 
/// </summary>
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
    /// Instantiate a new instance of the generate pdf class
    /// </summary>
    /// <param name="invoiceNumber">The number of the invoice. Include the date and the Customer's id</param>
    /// <param name="billTo">at who is the bill is addressed to</param>
    /// <param name="orderLines">The details of the order</param>
    /// <param name="billFrom">Who's ht supplier</param>
    /// <param name="vatService">The value added Tax for the bottle(s)</param>
    public GeneratePdf(string invoiceNumber, List<string> billTo, List<IOrderLine> orderLines,List<string> billFrom, IVatService vatService, List<string> terms, string url)
    {
        _invoiceNumber = invoiceNumber;
        _billFrom = billFrom;
        _billTo = billTo;
        _orderLines = orderLines;
        _vatService = vatService;
        _totalsRow = new List<TotalRow>();
        _details = terms;
        _footer = url;
        _logo = new LogoImage(160, 120);
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

    /// <summary>
    /// Saves the invoice as a PDF in a memory stream and returns the byte array representation of the PDF.
    /// </summary>
    /// <returns>The byte array representation of the generated PDF.</returns>
    public byte[] SaveInvoice()
    {
        HeaderSection();
        AddressSectionInvoice();
        GridSectionInvoice();
        TermsSectionInvoice();
        FooterSection();

        using var stream = new MemoryStream();
        _pdfDocument.Save(stream);
        var streamArray = stream.ToArray();
        _pdfDocument.Dispose();
        stream.Dispose();
        return streamArray;
    }

    /// <summary>
    /// Saves the purchase order as a PDF file in the local file system.
    /// </summary>
    /// <returns>The path to the saved PDF file.</returns>
    public string SavePurchaseOrderLocally()
    {
        HeaderSection();
        AddressSectionPurchaseOrder();
        GridSectionPurchaseOrder();
        TermsSectionPurchaseOrder();
        FooterSection();

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "temp.pdf");
        using var stream = new FileStream(filePath, FileMode.Create);
        _pdfDocument.Save(stream);
        stream.Dispose();
        this.Dispose();
        return filePath;
    }

    /// <summary>
    /// THe header section used by invoice and purchase order
    /// </summary>
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

        lines[1] = new TextFragment($"DATE: {DateTime.Today:dd/MM/yyyy}");
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
        imageStream.Dispose();
    }

    /// <summary>
    /// The address section for an invoice 
    /// </summary>
    private void AddressSectionInvoice()
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
            fragment = new TextFragment(str?? String.Empty)
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
            fragment = new TextFragment(str?? String.Empty)
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

    /// <summary>
    /// The address section for a purchase order 
    /// </summary>
    private void AddressSectionPurchaseOrder()
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
            fragment = new TextFragment(str ?? String.Empty)
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
            fragment = new TextFragment(str?? String.Empty)
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

    /// <summary>
    /// The grid of each bottle to be ordered
    /// </summary>
    private void GridSectionInvoice()
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
            vatRAte = (decimal) _vatService.GetVatAsync((int) orderLine.Bottle.VatId).Result.Value;
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

    /// <summary>
    /// The grid of each bottle to be ordered
    /// </summary>
    private void GridSectionPurchaseOrder()
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
            vatRAte = (decimal) _vatService.GetVatAsync((int) orderLine.Bottle.VatId).Result.Value;
            var row = table.Rows.Add();
            cell = row.Cells.Add(numberLine.ToString());
            cell.Alignment = HorizontalAlignment.Center;
            row.Cells.Add(orderLine.Bottle.FullName);
            cell = row.Cells.Add(((decimal) orderLine.Bottle.SupplierPrice).ToString("C2", _cultureInfo));
            cell.Alignment = HorizontalAlignment.Right;
            cell = row.Cells.Add(orderLine.Quantity.ToString());
            cell.Alignment = HorizontalAlignment.Right;
            cell = row.Cells.Add(
                ((decimal) (orderLine.Bottle.SupplierPrice * orderLine.Quantity)).ToString("C2", _cultureInfo));
            lineTotal.Add((decimal) (orderLine.Bottle.SupplierPrice * orderLine.Quantity));
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

    /// <summary>
    /// Terms and conditions for the invoice
    /// </summary>
    private void TermsSectionInvoice()
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

    /// <summary>
    /// Terms and conditions pr the purchase order
    /// </summary>
    private void TermsSectionPurchaseOrder()
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

    /// <summary>
    /// 
    /// </summary>
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

    public LogoImage(int width, int height)
    {
        FilePath = Directory.GetFiles(Environment.CurrentDirectory, "logo.png", SearchOption.AllDirectories).First()?? throw new Exception("Missing logo");
        Width = width;
        Height = height;
    }
}