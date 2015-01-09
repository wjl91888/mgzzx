using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RICH.Common
{
    public class PDF
    {
        public static BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        public static Font font22B = new Font(bfChinese, 22, iTextSharp.text.Font.BOLD);
        public static Font font22 = new Font(bfChinese, 22);
        public static Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        public static Font font20 = new Font(bfChinese, 20);
        public static Font font19B = new Font(bfChinese, 19, iTextSharp.text.Font.BOLD);
        public static Font font19 = new Font(bfChinese, 19);
        public static Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        public static Font font14 = new Font(bfChinese, 14);
        public static Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        public static Font font13 = new Font(bfChinese, 13);
        public static Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        public static Font font12 = new Font(bfChinese, 12);
        public static Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        public static Font font11 = new Font(bfChinese, 11);
        public static Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        public static Font font10 = new Font(bfChinese, 10);
        public static Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        public static Font font9 = new Font(bfChinese, 9);
        public static Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        public static Font font8 = new Font(bfChinese, 8);

        public static Table GenerateCellToTable(
            Table table,
            string strTitle,
            string strTitleColSpan,
            bool boolShowTitle,
            string strHeadText,
            string strContent,
            string strCellColSpan,
            bool border = true
            )
        {
            strContent = strContent.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
            string[] headText = strHeadText.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            string[] cellColSpan = strCellColSpan.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            string[] rows = strContent.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);

            if (boolShowTitle)
            {
                Cell cell = new Cell(new Paragraph(strTitle, font11B));
                cell.BorderWidth = border ? 0.5F : 0;
                cell.HorizontalAlignment = 1;
                cell.Rowspan = rows.Length + 1;
                cell.Colspan = int.Parse(strTitleColSpan);
                cell.VerticalAlignment = Cell.ALIGN_MIDDLE;
                table.AddCell(cell);
            }

            for (int i = 0; i < headText.Length; i++)
            {
                Cell cell = new Cell(new Paragraph(headText[i], font11B));
                cell.BorderWidth = border ? 0.5F : 0;
                cell.HorizontalAlignment = 1;
                cell.Rowspan = 1;
                cell.Colspan = int.Parse(cellColSpan[i]);
                cell.VerticalAlignment = Cell.ALIGN_MIDDLE;
                table.AddCell(cell);
            }
            for (int index = 0; index < rows.Length; index++)
            {
                string[] fields = rows[index].Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                for (int i = 0; i < fields.Length && i < headText.Length; i++)
                {
                    Cell cell = new Cell(new Paragraph(FunctionManager.RemoveTags(fields[i]), font10));
                    cell.Rowspan = 1;
                    cell.Colspan = int.Parse(cellColSpan[i]);
                    cell.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = 1;
                    cell.BorderWidth = border ? 0.5F : 0;
                    table.AddCell(cell);
                }
            }

            return table;
        }
    }
}
