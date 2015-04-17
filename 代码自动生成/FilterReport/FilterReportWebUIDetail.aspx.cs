/****************************************************** 
FileName:FilterReportWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.FilterReport;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class FilterReportWebUIDetail : RICH.Common.BM.FilterReport.FilterReportWebUI
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        base.Page_Init(sender, e);
    }

    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            Initalize();
        }
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
   protected override void Initalize()
    {
        // �����ʼ��
        // ��ʼ����ӡҳ���С
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // ��ʼ����ӡҳ�淽���С
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "landscape"));

        // ��ȡ��¼��ϸ����
        appData = new FilterReportApplicationData();
        appData.ObjectID = ObjectID;
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        Header.DataBind();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        if (IsPostBack != true)
        {
            foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
            {
                //��¼��־��ʼ
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "������Ϣ";
                strMessageParam[2] = drTemp["BGMC"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                //��¼��־����
            }
        }
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ����ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new FilterReportApplicationData();
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        appData.ObjectID = base.ObjectID;
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            case "pdf":
                string pageSize = ddlPrintPageSize.SelectedValue;
                bool boolOrientation = ddlPrintPageOrientation.SelectedValue == "landscape" ? true : false;
                float marginTop = DataValidateManager.ValidateNumberFormat(txtMarginTop.Text) == true ? Convert.ToSingle(txtMarginTop.Text) : 50;
                float marginRight = DataValidateManager.ValidateNumberFormat(txtMarginRight.Text) == true ? Convert.ToSingle(txtMarginRight.Text) : 50;
                float marginBottom = DataValidateManager.ValidateNumberFormat(txtMarginBottom.Text) == true ? Convert.ToSingle(txtMarginBottom.Text) : 50;
                float marginLeft = DataValidateManager.ValidateNumberFormat(txtMarginLeft.Text) == true ? Convert.ToSingle(txtMarginLeft.Text) : 50;
                ExportToPDFFile(appData.ResultSet, "Result", pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Control hcTemp;
            // �����������������
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // �������
            int intColumn = 0;
            
            intColumn += 4 + 12;
            // �������
            int intLength = 0;
    
            intLength = 5;
            intLength++;
            // ������
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // �õ�ֵ����ؼ�
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // ���ɱ��
                    // ����������
                    for (int i = intColumn; i > 0; i--)
                    {
                        TableCell tcBlank = new TableCell();
                        tcBlank.ColumnSpan = 1;
                        tcBlank.RowSpan = 1;
                        tcBlank.Height = 0;
                        tcBlank.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        tcBlank.Style.Add("height", "0");
                        tDetailView.Rows[0].Cells.Add(tcBlank);
                    }
                    tDetailView.Rows[0].Height = 0;
            
                    // ��ʾ�������Ʊ���
                    TableCell tcBGMCTitle = new TableCell();
                    tcBGMCTitle.Text = "��������";
                    tcBGMCTitle.ColumnSpan = 4;
                    tcBGMCTitle.RowSpan = 1;
                    tcBGMCTitle.CssClass = "fieldname";
                    tcBGMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBGMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcBGMCTitle);
                    
                    // ��ʾ��������ֵ
                    TableCell tcBGMCContent = new TableCell();
                      
                    tcBGMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BGMC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BGMC")).InnerHtml = "";
                    tcBGMCContent.ColumnSpan = 12;
                    tcBGMCContent.RowSpan = 1;
                    tcBGMCContent.CssClass = "fieldinput";
                    tcBGMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcBGMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcBGMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcBGMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBGMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcBGMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcBGMCContent);
              
                    // ��ʾ�û���ű���
                    TableCell tcUserIDTitle = new TableCell();
                    tcUserIDTitle.Text = "�û����";
                    tcUserIDTitle.ColumnSpan = 4;
                    tcUserIDTitle.RowSpan = 1;
                    tcUserIDTitle.CssClass = "fieldname";
                    tcUserIDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcUserIDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcUserIDTitle);
                    
                    // ��ʾ�û����ֵ
                    TableCell tcUserIDContent = new TableCell();
                      
                    tcUserIDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserID")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserID")).InnerHtml = "";
                    tcUserIDContent.ColumnSpan = 4;
                    tcUserIDContent.RowSpan = 1;
                    tcUserIDContent.CssClass = "fieldinput";
                    tcUserIDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcUserIDContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserIDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcUserIDContent);
              
                    // ��ʾ�������ͱ���
                    TableCell tcBGLXTitle = new TableCell();
                    tcBGLXTitle.Text = "��������";
                    tcBGLXTitle.ColumnSpan = 4;
                    tcBGLXTitle.RowSpan = 1;
                    tcBGLXTitle.CssClass = "fieldname";
                    tcBGLXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBGLXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcBGLXTitle);
                    
                    // ��ʾ��������ֵ
                    TableCell tcBGLXContent = new TableCell();
                      
                    tcBGLXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BGLX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BGLX")).InnerHtml = "";
                    tcBGLXContent.ColumnSpan = 4;
                    tcBGLXContent.RowSpan = 1;
                    tcBGLXContent.CssClass = "fieldinput";
                    tcBGLXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcBGLXContent.Style.Add("border-top", "1px black solid");
                        
                    tcBGLXContent.Style.Add("border-left", "1px black solid");
                        
                    tcBGLXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBGLXContent.Style.Add("border-right", "1px black solid");
                        
                    tcBGLXContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcBGLXContent);
              
                    // ��ʾ���������
                    TableCell tcGXBGTitle = new TableCell();
                    tcGXBGTitle.Text = "������";
                    tcGXBGTitle.ColumnSpan = 4;
                    tcGXBGTitle.RowSpan = 1;
                    tcGXBGTitle.CssClass = "fieldname";
                    tcGXBGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcGXBGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcGXBGTitle);
                    
                    // ��ʾ������ֵ
                    TableCell tcGXBGContent = new TableCell();
                      
                    tcGXBGContent.Text = ((HtmlContainerControl)hcTemp.FindControl("GXBG")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("GXBG")).InnerHtml = "";
                    tcGXBGContent.ColumnSpan = 4;
                    tcGXBGContent.RowSpan = 1;
                    tcGXBGContent.CssClass = "fieldinput";
                    tcGXBGContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcGXBGContent.Style.Add("border-top", "1px black solid");
                        
                    tcGXBGContent.Style.Add("border-left", "1px black solid");
                        
                    tcGXBGContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcGXBGContent.Style.Add("border-right", "1px black solid");
                        
                    tcGXBGContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcGXBGContent);
              
                    // ��ʾϵͳ�������
                    TableCell tcXTBGTitle = new TableCell();
                    tcXTBGTitle.Text = "ϵͳ����";
                    tcXTBGTitle.ColumnSpan = 4;
                    tcXTBGTitle.RowSpan = 1;
                    tcXTBGTitle.CssClass = "fieldname";
                    tcXTBGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXTBGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcXTBGTitle);
                    
                    // ��ʾϵͳ����ֵ
                    TableCell tcXTBGContent = new TableCell();
                      
                    tcXTBGContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XTBG")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XTBG")).InnerHtml = "";
                    tcXTBGContent.ColumnSpan = 4;
                    tcXTBGContent.RowSpan = 1;
                    tcXTBGContent.CssClass = "fieldinput";
                    tcXTBGContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXTBGContent.Style.Add("border-top", "1px black solid");
                        
                    tcXTBGContent.Style.Add("border-left", "1px black solid");
                        
                    tcXTBGContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXTBGContent.Style.Add("border-right", "1px black solid");
                        
                    tcXTBGContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcXTBGContent);
              
                    // ��ʾ������������
                    TableCell tcBGCXTJTitle = new TableCell();
                    tcBGCXTJTitle.Text = "��������";
                    tcBGCXTJTitle.ColumnSpan = 4;
                    tcBGCXTJTitle.RowSpan = 1;
                    tcBGCXTJTitle.CssClass = "fieldname";
                    tcBGCXTJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBGCXTJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcBGCXTJTitle);
                    
                    // ��ʾ��������ֵ
                    TableCell tcBGCXTJContent = new TableCell();
                      
                    tcBGCXTJContent.Controls.Add(
                            GenerateHtmlTable(
                            "����||ֵ",
                            ((HtmlContainerControl)hcTemp.FindControl("BGCXTJ")).InnerText,
                            true,
                            true,
                            null, "fieldname", "fieldinput",
                            null,
                            "100||100"
                            )
                        );
                    ((HtmlContainerControl)hcTemp.FindControl("BGCXTJ")).InnerHtml = "";
                    tcBGCXTJContent.ColumnSpan = 12;
                    tcBGCXTJContent.RowSpan = 1;
                    tcBGCXTJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                    tcBGCXTJContent.Style.Add("border", "1px black solid");
                    tcBGCXTJContent.Style.Add("padding", "0px !important");
                    tcBGCXTJContent.Style.Add("text-align", "left");
                        
                    tDetailView.Rows[4].Cells.Add(tcBGCXTJContent);
              
                    // ��ʾ����ʱ�����
                    TableCell tcBGCJSJTitle = new TableCell();
                    tcBGCJSJTitle.Text = "����ʱ��";
                    tcBGCJSJTitle.ColumnSpan = 4;
                    tcBGCJSJTitle.RowSpan = 1;
                    tcBGCJSJTitle.CssClass = "fieldname";
                    tcBGCJSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBGCJSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcBGCJSJTitle);
                    
                    // ��ʾ����ʱ��ֵ
                    TableCell tcBGCJSJContent = new TableCell();
                      
                    tcBGCJSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BGCJSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BGCJSJ")).InnerHtml = "";
                    tcBGCJSJContent.ColumnSpan = 12;
                    tcBGCJSJContent.RowSpan = 1;
                    tcBGCJSJContent.CssClass = "fieldinput";
                    tcBGCJSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcBGCJSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcBGCJSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcBGCJSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBGCJSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcBGCJSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcBGCJSJContent);
              
                    // ����һ��һ��ر���
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // ����������Ϣ
                hcTemp = tcTemp.FindControl("divmain");
                if (hcTemp != null)
                {
                    hcTemp.Controls.Add(tDetailView);
                }
    
            }
        }
    }

    protected void ExportToPDFFile(DataSet dsMainTable,
        string filename,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = GeneratePDFDocument(dsMainTable, pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        Response.Write(pdfDoc);
        Response.End();
    }

    private iTextSharp.text.Document GeneratePDFDocument(DataSet dsMainTable,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Rectangle rect;
        switch (pageSize)
        {
            case "A0":
                rect = new Rectangle(boolOrientation == true ? PageSize.A0.Rotate() : PageSize.A0);
                break;
            case "A1":
                rect = new Rectangle(boolOrientation == true ? PageSize.A1.Rotate() : PageSize.A1);
                break;
            case "A2":
                rect = new Rectangle(boolOrientation == true ? PageSize.A2.Rotate() : PageSize.A2);
                break;
            case "A3":
                rect = new Rectangle(boolOrientation == true ? PageSize.A3.Rotate() : PageSize.A3);
                break;
            case "A4":
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
            default:
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
        }
        // �����հ�PDF�ĵ�
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // �������һ��һ��ر���Ϣ
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // ���һ�Զ���ر���Ϣ
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // ���ɱ��
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font22B = new Font(bfChinese, 22, iTextSharp.text.Font.BOLD);
        Font font22 = new Font(bfChinese, 22);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font19B = new Font(bfChinese, 19, iTextSharp.text.Font.BOLD);
        Font font19 = new Font(bfChinese, 19);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        intColumn += 4 + 12;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // �����ͷ��Ϣ
        Cell cellTitle = new Cell(new Paragraph("������Ϣ", font19B));
        cellTitle.BorderWidth = 0;
        cellTitle.HorizontalAlignment = 1;
        cellTitle.VerticalAlignment = 1;
        cellTitle.Colspan = intColumn;
        itbOutput.AddCell(cellTitle);
          
        Cell cellTitleSpace = new Cell(new Paragraph(" ", font20B));
        cellTitleSpace.BorderWidth = 0;
        cellTitleSpace.HorizontalAlignment = 1;
        cellTitleSpace.VerticalAlignment = 1;
        cellTitleSpace.Colspan = intColumn;
        itbOutput.AddCell(cellTitleSpace);
        itbOutput.AddCell(cellTitleSpace);
        // ����ָ���
        Cell cellBorder = new Cell(new Paragraph("", font10B));
        cellBorder.BorderWidth = 0;
        cellBorder.BorderWidthBottom = 1;
        cellBorder.HorizontalAlignment = 1;
        cellBorder.VerticalAlignment = 1;
        cellBorder.Colspan = intColumn;
        if (dsMainTable.Tables.Count > 0)
        {
            foreach (DataRow drTemp in dsMainTable.Tables[0].Rows)
            {
                // ����������
            
                // ��ʾ�������Ʊ���
                
                iTextSharp.text.Cell cellBGMCTitle = new Cell(new Paragraph("��������", font11B));
                cellBGMCTitle.BorderWidth = 0.5F;
                cellBGMCTitle.HorizontalAlignment = 1;
                    
                cellBGMCTitle.Rowspan = 1;
                cellBGMCTitle.Colspan = 4;
                cellBGMCTitle.Width = 100 / intColumn;
                cellBGMCTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellBGMCTitle);
                
                // ��ʾ��������ֵ
                
                iTextSharp.text.Cell cellBGMCContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["BGMC"], null)), font10));
                        
                cellBGMCContent.Rowspan = 1;
                cellBGMCContent.Colspan = 12;
                cellBGMCContent.Width = 100 / intColumn;
                cellBGMCContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellBGMCContent.HorizontalAlignment = 1;
                cellBGMCContent.BorderWidthTop = 0.5F;
                        
                cellBGMCContent.BorderWidthLeft = 0.5F;
                        
                cellBGMCContent.BorderWidthBottom = 0.5F;
                        
                cellBGMCContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellBGMCContent);
                
                // ��ʾ�û���ű���
                
                iTextSharp.text.Cell cellUserIDTitle = new Cell(new Paragraph("�û����", font11B));
                cellUserIDTitle.BorderWidth = 0.5F;
                cellUserIDTitle.HorizontalAlignment = 1;
                    
                cellUserIDTitle.Rowspan = 1;
                cellUserIDTitle.Colspan = 4;
                cellUserIDTitle.Width = 100 / intColumn;
                cellUserIDTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUserIDTitle);
                
                // ��ʾ�û����ֵ
                
                iTextSharp.text.Cell cellUserIDContent = new Cell(new Paragraph(GetValue(drTemp["UserID_T_PM_UserInfo_UserLoginName"]), font10));
                cellUserIDContent.Rowspan = 1;
                cellUserIDContent.Colspan = 4;
                cellUserIDContent.Width = 100 / intColumn;
                cellUserIDContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUserIDContent.HorizontalAlignment = 1;
                cellUserIDContent.BorderWidthTop = 0.5F;
                        
                cellUserIDContent.BorderWidthLeft = 0.5F;
                        
                cellUserIDContent.BorderWidthBottom = 0.5F;
                        
                cellUserIDContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUserIDContent);
                
                // ��ʾ�������ͱ���
                
                iTextSharp.text.Cell cellBGLXTitle = new Cell(new Paragraph("��������", font11B));
                cellBGLXTitle.BorderWidth = 0.5F;
                cellBGLXTitle.HorizontalAlignment = 1;
                    
                cellBGLXTitle.Rowspan = 1;
                cellBGLXTitle.Colspan = 4;
                cellBGLXTitle.Width = 100 / intColumn;
                cellBGLXTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellBGLXTitle);
                
                // ��ʾ��������ֵ
                
                iTextSharp.text.Cell cellBGLXContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["BGLX"], null)), font10));
                        
                cellBGLXContent.Rowspan = 1;
                cellBGLXContent.Colspan = 4;
                cellBGLXContent.Width = 100 / intColumn;
                cellBGLXContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellBGLXContent.HorizontalAlignment = 1;
                cellBGLXContent.BorderWidthTop = 0.5F;
                        
                cellBGLXContent.BorderWidthLeft = 0.5F;
                        
                cellBGLXContent.BorderWidthBottom = 0.5F;
                        
                cellBGLXContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellBGLXContent);
                
                // ��ʾ���������
                
                iTextSharp.text.Cell cellGXBGTitle = new Cell(new Paragraph("������", font11B));
                cellGXBGTitle.BorderWidth = 0.5F;
                cellGXBGTitle.HorizontalAlignment = 1;
                    
                cellGXBGTitle.Rowspan = 1;
                cellGXBGTitle.Colspan = 4;
                cellGXBGTitle.Width = 100 / intColumn;
                cellGXBGTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellGXBGTitle);
                
                // ��ʾ������ֵ
                
                iTextSharp.text.Cell cellGXBGContent = new Cell(new Paragraph(GetValue(drTemp["GXBG_Dictionary_MC"]), font10));
                cellGXBGContent.Rowspan = 1;
                cellGXBGContent.Colspan = 4;
                cellGXBGContent.Width = 100 / intColumn;
                cellGXBGContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellGXBGContent.HorizontalAlignment = 1;
                cellGXBGContent.BorderWidthTop = 0.5F;
                        
                cellGXBGContent.BorderWidthLeft = 0.5F;
                        
                cellGXBGContent.BorderWidthBottom = 0.5F;
                        
                cellGXBGContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellGXBGContent);
                
                // ��ʾϵͳ�������
                
                iTextSharp.text.Cell cellXTBGTitle = new Cell(new Paragraph("ϵͳ����", font11B));
                cellXTBGTitle.BorderWidth = 0.5F;
                cellXTBGTitle.HorizontalAlignment = 1;
                    
                cellXTBGTitle.Rowspan = 1;
                cellXTBGTitle.Colspan = 4;
                cellXTBGTitle.Width = 100 / intColumn;
                cellXTBGTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellXTBGTitle);
                
                // ��ʾϵͳ����ֵ
                
                iTextSharp.text.Cell cellXTBGContent = new Cell(new Paragraph(GetValue(drTemp["XTBG_Dictionary_MC"]), font10));
                cellXTBGContent.Rowspan = 1;
                cellXTBGContent.Colspan = 4;
                cellXTBGContent.Width = 100 / intColumn;
                cellXTBGContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellXTBGContent.HorizontalAlignment = 1;
                cellXTBGContent.BorderWidthTop = 0.5F;
                        
                cellXTBGContent.BorderWidthLeft = 0.5F;
                        
                cellXTBGContent.BorderWidthBottom = 0.5F;
                        
                cellXTBGContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellXTBGContent);
                
                // ��ʾ�����������⼰ֵ
                itbOutput = PDF.GenerateCellToTable(
                    itbOutput,
                    "��������", "4", !false,
                    "����||ֵ",
                    FunctionManager.RemoveTags(GetValue(drTemp["BGCXTJ"], null)),
                    "",
                    !false
                    );
                  
                // ��ʾ����ʱ�����
                
                iTextSharp.text.Cell cellBGCJSJTitle = new Cell(new Paragraph("����ʱ��", font11B));
                cellBGCJSJTitle.BorderWidth = 0.5F;
                cellBGCJSJTitle.HorizontalAlignment = 1;
                    
                cellBGCJSJTitle.Rowspan = 1;
                cellBGCJSJTitle.Colspan = 4;
                cellBGCJSJTitle.Width = 100 / intColumn;
                cellBGCJSJTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellBGCJSJTitle);
                
                // ��ʾ����ʱ��ֵ
                
                iTextSharp.text.Cell cellBGCJSJContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["BGCJSJ"], null)), font10));
                        
                cellBGCJSJContent.Rowspan = 1;
                cellBGCJSJContent.Colspan = 12;
                cellBGCJSJContent.Width = 100 / intColumn;
                cellBGCJSJContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellBGCJSJContent.HorizontalAlignment = 1;
                cellBGCJSJContent.BorderWidthTop = 0.5F;
                        
                cellBGCJSJContent.BorderWidthLeft = 0.5F;
                        
                cellBGCJSJContent.BorderWidthBottom = 0.5F;
                        
                cellBGCJSJContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellBGCJSJContent);
                
                // ����һ��һ��ر���
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // ���ɱ��
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        if (dsMainTable.Tables.Count > 0)
        {
            if (dsMainTable.Tables[0].Rows.Count > 0)
            {
                // �����ͷ��Ϣ
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // ������ر��ֶ�����
                
                // ������ر�����
                if (dsRelatedTable.Tables.Count > 0)
                {
                    string strTempValue = string.Empty;
                    foreach (DataRow drTemp in dsRelatedTable.Tables[0].Rows)
                    {
                    
                    }
                }
            }
        }
        return itbOutput;
    }

    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// ��ر�������ദ��
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

