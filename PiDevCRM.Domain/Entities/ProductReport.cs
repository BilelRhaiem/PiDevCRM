using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class ProductReport
    {
        #region Declaration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPcell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Product> _liste = new List<Product>();
        #endregion
        public byte[] prepareReport(List<Product> liste) {
            _liste = liste;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f, 100f });

            #endregion
            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }
        private void ReportHeader() {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPcell = new PdfPCell(new Phrase("product name", _fontStyle));
            _pdfPcell.Colspan = _totalColumn;
            _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPcell.Border = 0;
            _pdfPcell.BackgroundColor = BaseColor.WHITE;
            _pdfPcell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPcell);
            _pdfTable.CompleteRow();
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPcell = new PdfPCell(new Phrase("product list", _fontStyle));
            _pdfPcell.Colspan = _totalColumn;
            _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPcell.Border = 0;
            _pdfPcell.BackgroundColor = BaseColor.WHITE;
            _pdfPcell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPcell);
            _pdfTable.CompleteRow();

        }
        private void ReportBody() {
            #region Table Header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPcell = new PdfPCell(new Phrase("Number", _fontStyle));
            _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPcell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPcell);
            _pdfPcell = new PdfPCell(new Phrase("Name", _fontStyle));
            _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPcell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPcell);
            _pdfPcell = new PdfPCell(new Phrase("description", _fontStyle));
            _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPcell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPcell);
            _pdfTable.CompleteRow();
            #endregion
            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f,0);
            int Number = 1;
            foreach (Product product in _liste) {
                _pdfPcell = new PdfPCell(new Phrase(Number++.ToString(), _fontStyle));
                _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPcell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPcell);
                _pdfPcell = new PdfPCell(new Phrase(product.NameProduct, _fontStyle));
                _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPcell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPcell);
                _pdfPcell = new PdfPCell(new Phrase(product.Description, _fontStyle));
                _pdfPcell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPcell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPcell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPcell);
                _pdfTable.CompleteRow();
            }
            #endregion

        }
    }
}
