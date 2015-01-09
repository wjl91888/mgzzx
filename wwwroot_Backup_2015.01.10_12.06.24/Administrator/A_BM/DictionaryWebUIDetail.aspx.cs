/****************************************************** 
FileName:DictionaryWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.Dictionary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class DictionaryWebUIDetail : RICH.Common.BM.Dictionary.DictionaryWebUI
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        // ����SESSION��ֵ
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_DETAIL_FILENAME;
        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_SEARCH_ACCESS_PURVIEW_ID;
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
        appData = new DictionaryApplicationData();
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
                strMessageParam[1] = "�ֵ���Ϣ";
                strMessageParam[2] = drTemp["DM"].ToString();
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
        appData = new DictionaryApplicationData();
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
            // �������������������
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // �������
            int intColumn = 0;
            
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            // �������
            int intLength = 0;
    
            intLength = 3;
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
                    // ���ɱ���
                    // ������������
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
            
                    // ��ʾ�������
                    TableCell tcDMTitle = new TableCell();
                    tcDMTitle.Text = "����";
                    tcDMTitle.ColumnSpan = 1;
                    tcDMTitle.RowSpan = 1;
                    tcDMTitle.CssClass = "fieldname";
                    tcDMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDMTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcDMContent = new TableCell();
                      
                    tcDMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DM")).InnerHtml = "";
                    tcDMContent.ColumnSpan = 1;
                    tcDMContent.RowSpan = 1;
                    tcDMContent.CssClass = "fieldinput";
                    tcDMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcDMContent.Style.Add("border-top", "1px black solid");
                        
                    tcDMContent.Style.Add("border-left", "1px black solid");
                        
                    tcDMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDMContent.Style.Add("border-right", "1px black solid");
                        
                    tcDMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDMContent);
              
                    // ��ʾ���ͱ���
                    TableCell tcLXTitle = new TableCell();
                    tcLXTitle.Text = "����";
                    tcLXTitle.ColumnSpan = 1;
                    tcLXTitle.RowSpan = 1;
                    tcLXTitle.CssClass = "fieldname";
                    tcLXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcLXTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcLXContent = new TableCell();
                      
                    tcLXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LX")).InnerHtml = "";
                    tcLXContent.ColumnSpan = 1;
                    tcLXContent.RowSpan = 1;
                    tcLXContent.CssClass = "fieldinput";
                    tcLXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLXContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcLXContent);
              
                    // ��ʾ���Ʊ���
                    TableCell tcMCTitle = new TableCell();
                    tcMCTitle.Text = "����";
                    tcMCTitle.ColumnSpan = 1;
                    tcMCTitle.RowSpan = 1;
                    tcMCTitle.CssClass = "fieldname";
                    tcMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcMCTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcMCContent = new TableCell();
                      
                    tcMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("MC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("MC")).InnerHtml = "";
                    tcMCContent.ColumnSpan = 1;
                    tcMCContent.RowSpan = 1;
                    tcMCContent.CssClass = "fieldinput";
                    tcMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcMCContent);
              
                    // ��ʾ�ϼ��������
                    TableCell tcSJDMTitle = new TableCell();
                    tcSJDMTitle.Text = "�ϼ�����";
                    tcSJDMTitle.ColumnSpan = 1;
                    tcSJDMTitle.RowSpan = 1;
                    tcSJDMTitle.CssClass = "fieldname";
                    tcSJDMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJDMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcSJDMTitle);
                    
                    // ��ʾ�ϼ�����ֵ
                    TableCell tcSJDMContent = new TableCell();
                      
                    tcSJDMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJDM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJDM")).InnerHtml = "";
                    tcSJDMContent.ColumnSpan = 1;
                    tcSJDMContent.RowSpan = 1;
                    tcSJDMContent.CssClass = "fieldinput";
                    tcSJDMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcSJDMContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJDMContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJDMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJDMContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJDMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcSJDMContent);
              
                    // ��ʾ˵������
                    TableCell tcSMTitle = new TableCell();
                    tcSMTitle.Text = "˵��";
                    tcSMTitle.ColumnSpan = 1;
                    tcSMTitle.RowSpan = 1;
                    tcSMTitle.CssClass = "fieldname";
                    tcSMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcSMTitle);
                    
                    // ��ʾ˵��ֵ
                    TableCell tcSMContent = new TableCell();
                      
                    tcSMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SM")).InnerHtml = "";
                    tcSMContent.ColumnSpan = 3;
                    tcSMContent.RowSpan = 1;
                    tcSMContent.CssClass = "fieldinput";
                    tcSMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcSMContent.Style.Add("border-top", "1px black solid");
                        
                    tcSMContent.Style.Add("border-left", "1px black solid");
                        
                    tcSMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSMContent.Style.Add("border-right", "1px black solid");
                        
                    tcSMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcSMContent);
              
                    // ����һ��һ��ر�����
            
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
        // ����������һ��һ��ر���Ϣ
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // ����һ�Զ���ر���Ϣ
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // ���ɱ���
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
        
        intColumn += 1 + 1;
        intColumn += 1 + 1;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // �����ͷ��Ϣ
        Cell cellTitle = new Cell(new Paragraph("�ֵ���Ϣ", font19B));
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
                // ������������
            
                // ��ʾ�������
                
                iTextSharp.text.Cell cellDMTitle = new Cell(new Paragraph("����", font11B));
                cellDMTitle.BorderWidth = 0.5F;
                cellDMTitle.HorizontalAlignment = 1;
                    
                cellDMTitle.Rowspan = 1;
                cellDMTitle.Colspan = 1;
                cellDMTitle.Width = 100 / intColumn;
                cellDMTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellDMTitle);
                
                // ��ʾ����ֵ
                
                iTextSharp.text.Cell cellDMContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["DM"], null)), font10));
                        
                cellDMContent.Rowspan = 1;
                cellDMContent.Colspan = 1;
                cellDMContent.Width = 100 / intColumn;
                cellDMContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellDMContent.HorizontalAlignment = 1;
                cellDMContent.BorderWidthTop = 0.5F;
                        
                cellDMContent.BorderWidthLeft = 0.5F;
                        
                cellDMContent.BorderWidthBottom = 0.5F;
                        
                cellDMContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellDMContent);
                
                // ��ʾ���ͱ���
                
                iTextSharp.text.Cell cellLXTitle = new Cell(new Paragraph("����", font11B));
                cellLXTitle.BorderWidth = 0.5F;
                cellLXTitle.HorizontalAlignment = 1;
                    
                cellLXTitle.Rowspan = 1;
                cellLXTitle.Colspan = 1;
                cellLXTitle.Width = 100 / intColumn;
                cellLXTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellLXTitle);
                
                // ��ʾ����ֵ
                
                iTextSharp.text.Cell cellLXContent = new Cell(new Paragraph(GetValue(drTemp["LX_DictionaryType_MC"]), font10));
                cellLXContent.Rowspan = 1;
                cellLXContent.Colspan = 1;
                cellLXContent.Width = 100 / intColumn;
                cellLXContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellLXContent.HorizontalAlignment = 1;
                cellLXContent.BorderWidthTop = 0.5F;
                        
                cellLXContent.BorderWidthLeft = 0.5F;
                        
                cellLXContent.BorderWidthBottom = 0.5F;
                        
                cellLXContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellLXContent);
                
                // ��ʾ���Ʊ���
                
                iTextSharp.text.Cell cellMCTitle = new Cell(new Paragraph("����", font11B));
                cellMCTitle.BorderWidth = 0.5F;
                cellMCTitle.HorizontalAlignment = 1;
                    
                cellMCTitle.Rowspan = 1;
                cellMCTitle.Colspan = 1;
                cellMCTitle.Width = 100 / intColumn;
                cellMCTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellMCTitle);
                
                // ��ʾ����ֵ
                
                iTextSharp.text.Cell cellMCContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["MC"], null)), font10));
                        
                cellMCContent.Rowspan = 1;
                cellMCContent.Colspan = 1;
                cellMCContent.Width = 100 / intColumn;
                cellMCContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellMCContent.HorizontalAlignment = 1;
                cellMCContent.BorderWidthTop = 0.5F;
                        
                cellMCContent.BorderWidthLeft = 0.5F;
                        
                cellMCContent.BorderWidthBottom = 0.5F;
                        
                cellMCContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellMCContent);
                
                // ��ʾ�ϼ��������
                
                iTextSharp.text.Cell cellSJDMTitle = new Cell(new Paragraph("�ϼ�����", font11B));
                cellSJDMTitle.BorderWidth = 0.5F;
                cellSJDMTitle.HorizontalAlignment = 1;
                    
                cellSJDMTitle.Rowspan = 1;
                cellSJDMTitle.Colspan = 1;
                cellSJDMTitle.Width = 100 / intColumn;
                cellSJDMTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellSJDMTitle);
                
                // ��ʾ�ϼ�����ֵ
                
                iTextSharp.text.Cell cellSJDMContent = new Cell(new Paragraph(GetValue(drTemp["SJDM_Dictionary_MC"]), font10));
                cellSJDMContent.Rowspan = 1;
                cellSJDMContent.Colspan = 1;
                cellSJDMContent.Width = 100 / intColumn;
                cellSJDMContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellSJDMContent.HorizontalAlignment = 1;
                cellSJDMContent.BorderWidthTop = 0.5F;
                        
                cellSJDMContent.BorderWidthLeft = 0.5F;
                        
                cellSJDMContent.BorderWidthBottom = 0.5F;
                        
                cellSJDMContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellSJDMContent);
                
                // ��ʾ˵������
                
                iTextSharp.text.Cell cellSMTitle = new Cell(new Paragraph("˵��", font11B));
                cellSMTitle.BorderWidth = 0.5F;
                cellSMTitle.HorizontalAlignment = 1;
                    
                cellSMTitle.Rowspan = 1;
                cellSMTitle.Colspan = 1;
                cellSMTitle.Width = 100 / intColumn;
                cellSMTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellSMTitle);
                
                // ��ʾ˵��ֵ
                
                iTextSharp.text.Cell cellSMContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["SM"], null)), font10));
                        
                cellSMContent.Rowspan = 1;
                cellSMContent.Colspan = 3;
                cellSMContent.Width = 100 / intColumn;
                cellSMContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellSMContent.HorizontalAlignment = 1;
                cellSMContent.BorderWidthTop = 0.5F;
                        
                cellSMContent.BorderWidthLeft = 0.5F;
                        
                cellSMContent.BorderWidthBottom = 0.5F;
                        
                cellSMContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellSMContent);
                
                // ����һ��һ��ر�����
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // ���ɱ���
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
