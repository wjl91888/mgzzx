//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Microsoft.Office.Interop;
//using Microsoft.Office.Core;

//namespace DataModelApplication.Common
//{

//    ///   <summary > 
//    ///   ExcelFileLabrary   ��ժҪ˵�� 
//    ///   </summary > 
//    public class ExcelFileLabrary
//    {
//        public string mFilename;
//        public Excel.Application app;
//        public Excel.Workbooks wbs;
//        public Excel.Workbook wb;
//        public Excel.Worksheets wss;
//        public Excel.Worksheet ws;
//        public ExcelFileLabrary()
//        {
//            // 
//            //   TODO:   �ڴ˴���ӹ��캯���߼� 
//            // 
//        }
//        public void Create()//����һ��Excel���� 
//        {
//            app = new Excel.Application();
//            wbs = app.Workbooks;
//            wb = wbs.Add(true);
//        }
//        public void Open(string FileName)//��һ��Excel�ļ� 
//        {
//            app = new Excel.Application();
//            wbs = app.Workbooks;
//            wb = wbs.Add(FileName);
//            //wb   =   wbs.Open(FileName,     0,   true,   5, " ",   " ",   true,   Excel.XlPlatform.xlWindows,   "\t ",   false,   false,   0,   true,Type.Missing,Type.Missing); 
//            //wb   =   wbs.Open(FileName,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Excel.XlPlatform.xlWindows,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing); 
//            mFilename = FileName;
//        }
//        public Excel.Worksheet GetSheet(string SheetName)//��ȡһ�������� 
//        {
//            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets[SheetName];
//            return s;
//        }
//        public Excel.Worksheet AddSheet(string SheetName)//���һ�������� 
//        {
//            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
//            s.Name = SheetName;
//            return s;
//        }

//        public void DelSheet(string SheetName)//ɾ��һ�������� 
//        {
//            ((Excel.Worksheet)wb.Worksheets[SheetName]).Delete();
//        }
//        public Excel.Worksheet ReNameSheet(string OldSheetName, string NewSheetName)//������һ��������һ 
//        {
//            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets[OldSheetName];
//            s.Name = NewSheetName;
//            return s;
//        }

//        public Excel.Worksheet ReNameSheet(Excel.Worksheet Sheet, string NewSheetName)//������һ��������� 
//        {

//            Sheet.Name = NewSheetName;

//            return Sheet;
//        }

//        public void SetCellValue(Excel.Worksheet ws, int x, int y, object value)//ws��Ҫ��ֵ�Ĺ�����           X��Y��           value       ֵ   
//        {
//            ws.Cells[x, y] = value;
//        }
//        public void SetCellValue(string ws, int x, int y, object value)//ws��Ҫ��ֵ�Ĺ����������   X��Y��   value   ֵ 
//        {

//            GetSheet(ws).Cells[x, y] = value;
//        }

//        public void SetCellProperty(Excel.Worksheet ws, int Startx, int Starty, int Endx, int Endy, int size, string name, Excel.Constants color, Excel.Constants HorizontalAlignment)//����һ����Ԫ�������       ���壬       ��С����ɫ       �����뷽ʽ 
//        {
//            name = "���� ";
//            size = 12;
//            color = Excel.Constants.xlAutomatic;
//            HorizontalAlignment = Excel.Constants.xlRight;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
//        }

//        public void SetCellProperty(string wsn, int Startx, int Starty, int Endx, int Endy, int size, string name, Excel.Constants color, Excel.Constants HorizontalAlignment)
//        {
//            //name   =   "���� "; 
//            //size   =   12; 
//            //color   =   Excel.Constants.xlAutomatic; 
//            //HorizontalAlignment   =   Excel.Constants.xlRight; 

//            Excel.Worksheet ws = GetSheet(wsn);
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;

//            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
//        }


//        public void UniteCells(Excel.Worksheet ws, int x1, int y1, int x2, int y2)//�ϲ���Ԫ�� 
//        {
//            ws.get_Range(ws.Cells[x1, y1], ws.Cells[x2, y2]).Merge(Type.Missing);
//        }

//        public void UniteCells(string ws, int x1, int y1, int x2, int y2)//�ϲ���Ԫ�� 
//        {
//            GetSheet(ws).get_Range(GetSheet(ws).Cells[x1, y1], GetSheet(ws).Cells[x2, y2]).Merge(Type.Missing);

//        }


//        public void InsertTable(System.Data.DataTable dt, string ws, int startX, int startY)//���ڴ������ݱ����뵽Excelָ���������ָ��λ��   Ϊ��ʹ��ģ��ʱ���Ƹ�ʽʱʹ��һ 
//        {

//            for (int i = 0; i <= dt.Rows.Count - 1; i++)
//            {
//                for (int j = 0; j <= dt.Columns.Count - 1; j++)
//                {
//                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();

//                }

//            }

//        }
//        public void InsertTable(System.Data.DataTable dt, Excel.Worksheet ws, int startX, int startY)//���ڴ������ݱ����뵽Excelָ���������ָ��λ�ö� 
//        {

//            for (int i = 0; i <= dt.Rows.Count - 1; i++)
//            {
//                for (int j = 0; j <= dt.Columns.Count - 1; j++)
//                {

//                    ws.Cells[startX + i, j + startY] = dt.Rows[i][j];

//                }

//            }

//        }


//        public void AddTable(System.Data.DataTable dt, string ws, int startX, int startY)//���ڴ������ݱ����ӵ�Excelָ���������ָ��λ��һ 
//        {

//            for (int i = 0; i <= dt.Rows.Count - 1; i++)
//            {
//                for (int j = 0; j <= dt.Columns.Count - 1; j++)
//                {

//                    GetSheet(ws).Cells[i + startX, j + startY] = dt.Rows[i][j];

//                }

//            }

//        }
//        public void AddTable(System.Data.DataTable dt, Excel.Worksheet ws, int startX, int startY)//���ڴ������ݱ����ӵ�Excelָ���������ָ��λ�ö� 
//        {


//            for (int i = 0; i <= dt.Rows.Count - 1; i++)
//            {
//                for (int j = 0; j <= dt.Columns.Count - 1; j++)
//                {

//                    ws.Cells[i + startX, j + startY] = dt.Rows[i][j];

//                }
//            }

//        }
//        public void InsertPictures(string Filename, string ws)//����ͼƬ����һ 
//        {
//            GetSheet(ws).Shapes.AddPicture(Filename, MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 10, 150, 150);//��������ֱ�ʾλ�� 
//        }

//        //public   void   InsertPictures(string   Filename,   string   ws,   int   Height,   int   Width)//����ͼƬ������ 
//        //{ 
//        //         GetSheet(ws).Shapes.AddPicture(Filename,   MsoTriState.msoFalse,   MsoTriState.msoTrue,   10,   10,   150,   150); 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).Height   =   Height; 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).Width   =   Width; 
//        //} 
//        //public   void   InsertPictures(string   Filename,   string   ws,   int   left,   int   top,   int   Height,   int   Width)//����ͼƬ������ 
//        //{ 

//        //         GetSheet(ws).Shapes.AddPicture(Filename,   MsoTriState.msoFalse,   MsoTriState.msoTrue,   10,   10,   150,   150); 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).IncrementLeft(left); 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).IncrementTop(top); 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).Height   =   Height; 
//        //         GetSheet(ws).Shapes.get_Range(Type.Missing).Width   =   Width; 
//        //} 

//        public void InsertActiveChart(Excel.XlChartType ChartType, string ws, int DataSourcesX1, int DataSourcesY1, int DataSourcesX2, int DataSourcesY2, Excel.XlRowCol ChartDataType)//����ͼ����� 
//        {
//            ChartDataType = Excel.XlRowCol.xlColumns;
//            wb.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
//            {
//                wb.ActiveChart.ChartType = ChartType;
//                wb.ActiveChart.SetSourceData(GetSheet(ws).get_Range(GetSheet(ws).Cells[DataSourcesX1, DataSourcesY1], GetSheet(ws).Cells[DataSourcesX2, DataSourcesY2]), ChartDataType);
//                wb.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, ws);
//            }
//        }
//        public bool Save()//�����ĵ� 
//        {
//            if (mFilename == " ")
//            {
//                return false;
//            }
//            else
//            {
//                try
//                {
//                    wb.Save();
//                    return true;
//                }

//                catch (Exception ex)
//                {
//                    return false;
//                }
//            }
//        }
//        public bool SaveAs(object FileName)//�ĵ����Ϊ 
//        {
//            try
//            {
//                wb.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
//                return true;

//            }

//            catch (Exception ex)
//            {
//                return false;

//            }
//        }
//        public void Close()//�ر�һ��Excel�������ٶ��� 
//        {
//            //wb.Save(); 
//            wb.Close(Type.Missing, Type.Missing, Type.Missing);
//            wbs.Close();
//            app.Quit();
//            wb = null;
//            wbs = null;
//            app = null;
//            GC.Collect();
//        }
//    }
//} 
