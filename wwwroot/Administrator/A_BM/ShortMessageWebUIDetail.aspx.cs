/****************************************************** 
FileName:ShortMessageWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.ShortMessage;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class ShortMessageWebUIDetail : RICH.Common.BM.ShortMessage.ShortMessageWebUI
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
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
   protected override void Initalize()
    {
        // 界面初始化
        // 初始化打印页面大小
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // 初始化打印页面方向大小
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("竖向", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("横向", "landscape"));

        // 读取记录详细资料
        appData = new ShortMessageApplicationData();
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
                //记录日志开始
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "消息";
                strMessageParam[2] = drTemp["DXXBT"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                //记录日志结束
            }
        }
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new ShortMessageApplicationData();
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
            // 生成详情表并设置属性
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // 获得列数
            int intColumn = 0;
            
            intColumn += 4 + 20;
            // 获得行数
            int intLength = 0;
    
            intLength = 5;
            intLength++;
            // 生成行
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // 得到值区域控件
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // 生成表格
                    // 生成主表表格
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
            
                    // 显示标题标题
                    TableCell tcDXXBTTitle = new TableCell();
                    tcDXXBTTitle.Text = "标题";
                    tcDXXBTTitle.ColumnSpan = 4;
                    tcDXXBTTitle.RowSpan = 1;
                    tcDXXBTTitle.CssClass = "fieldname";
                    tcDXXBTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDXXBTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDXXBTTitle);
                    
                    // 显示标题值
                    TableCell tcDXXBTContent = new TableCell();
                      
                    tcDXXBTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DXXBT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DXXBT")).InnerHtml = "";
                    tcDXXBTContent.ColumnSpan = 20;
                    tcDXXBTContent.RowSpan = 1;
                    tcDXXBTContent.CssClass = "fieldinput";
                    tcDXXBTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcDXXBTContent.Style.Add("border-top", "1px black solid");
                        
                    tcDXXBTContent.Style.Add("border-left", "1px black solid");
                        
                    tcDXXBTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDXXBTContent.Style.Add("border-right", "1px black solid");
                        
                    tcDXXBTContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDXXBTContent);
              
                    // 显示内容值
                    TableCell tcDXXNRContent = new TableCell();
                      
                    tcDXXNRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DXXNR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DXXNR")).InnerHtml = "";
                    tcDXXNRContent.ColumnSpan = 24;
                    tcDXXNRContent.RowSpan = 1;
                    tcDXXNRContent.CssClass = "fieldinput";
                    tcDXXNRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 24 / intColumn));
                        
                    tcDXXNRContent.Style.Add("border-top", "1px black solid");
                        
                    tcDXXNRContent.Style.Add("border-left", "1px black solid");
                        
                    tcDXXNRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDXXNRContent.Style.Add("border-right", "1px black solid");
                        
                    tcDXXNRContent.Style.Add("text-align", "left");
                    tDetailView.Rows[2].Cells.Add(tcDXXNRContent);
              
                    // 显示附件标题
                    TableCell tcDXXFJTitle = new TableCell();
                    tcDXXFJTitle.Text = "附件";
                    tcDXXFJTitle.ColumnSpan = 4;
                    tcDXXFJTitle.RowSpan = 1;
                    tcDXXFJTitle.CssClass = "fieldname";
                    tcDXXFJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDXXFJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcDXXFJTitle);
                    
                    // 显示附件值
                    TableCell tcDXXFJContent = new TableCell();
                      
                    tcDXXFJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DXXFJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DXXFJ")).InnerHtml = "";
                    tcDXXFJContent.ColumnSpan = 20;
                    tcDXXFJContent.RowSpan = 1;
                    tcDXXFJContent.CssClass = "fieldinput";
                    tcDXXFJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcDXXFJContent.Style.Add("border-top", "1px black solid");
                        
                    tcDXXFJContent.Style.Add("border-left", "1px black solid");
                        
                    tcDXXFJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDXXFJContent.Style.Add("border-right", "1px black solid");
                        
                    tcDXXFJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcDXXFJContent);
              
                    // 显示发送时间标题
                    TableCell tcFSSJTitle = new TableCell();
                    tcFSSJTitle.Text = "发送时间";
                    tcFSSJTitle.ColumnSpan = 4;
                    tcFSSJTitle.RowSpan = 1;
                    tcFSSJTitle.CssClass = "fieldname";
                    tcFSSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFSSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcFSSJTitle);
                    
                    // 显示发送时间值
                    TableCell tcFSSJContent = new TableCell();
                      
                    tcFSSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FSSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FSSJ")).InnerHtml = "";
                    tcFSSJContent.ColumnSpan = 4;
                    tcFSSJContent.RowSpan = 1;
                    tcFSSJContent.CssClass = "fieldinput";
                    tcFSSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFSSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcFSSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcFSSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFSSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcFSSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcFSSJContent);
              
                    // 显示发送人标题
                    TableCell tcFSRTitle = new TableCell();
                    tcFSRTitle.Text = "发送人";
                    tcFSRTitle.ColumnSpan = 4;
                    tcFSRTitle.RowSpan = 1;
                    tcFSRTitle.CssClass = "fieldname";
                    tcFSRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFSRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcFSRTitle);
                    
                    // 显示发送人值
                    TableCell tcFSRContent = new TableCell();
                      
                    tcFSRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FSR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FSR")).InnerHtml = "";
                    tcFSRContent.ColumnSpan = 4;
                    tcFSRContent.RowSpan = 1;
                    tcFSRContent.CssClass = "fieldinput";
                    tcFSRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFSRContent.Style.Add("border-top", "1px black solid");
                        
                    tcFSRContent.Style.Add("border-left", "1px black solid");
                        
                    tcFSRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFSRContent.Style.Add("border-right", "1px black solid");
                        
                    tcFSRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcFSRContent);
              
                    // 显示发送部门标题
                    TableCell tcFSBMTitle = new TableCell();
                    tcFSBMTitle.Text = "发送部门";
                    tcFSBMTitle.ColumnSpan = 4;
                    tcFSBMTitle.RowSpan = 1;
                    tcFSBMTitle.CssClass = "fieldname";
                    tcFSBMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFSBMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcFSBMTitle);
                    
                    // 显示发送部门值
                    TableCell tcFSBMContent = new TableCell();
                      
                    tcFSBMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FSBM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FSBM")).InnerHtml = "";
                    tcFSBMContent.ColumnSpan = 4;
                    tcFSBMContent.RowSpan = 1;
                    tcFSBMContent.CssClass = "fieldinput";
                    tcFSBMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFSBMContent.Style.Add("border-top", "1px black solid");
                        
                    tcFSBMContent.Style.Add("border-left", "1px black solid");
                        
                    tcFSBMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFSBMContent.Style.Add("border-right", "1px black solid");
                        
                    tcFSBMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcFSBMContent);
              
                    // 显示接收人标题
                    TableCell tcJSRTitle = new TableCell();
                    tcJSRTitle.Text = "接收人";
                    tcJSRTitle.ColumnSpan = 4;
                    tcJSRTitle.RowSpan = 1;
                    tcJSRTitle.CssClass = "fieldname";
                    tcJSRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJSRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcJSRTitle);
                    
                    // 显示接收人值
                    TableCell tcJSRContent = new TableCell();
                      
                    tcJSRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JSR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JSR")).InnerHtml = "";
                    tcJSRContent.ColumnSpan = 20;
                    tcJSRContent.RowSpan = 1;
                    tcJSRContent.CssClass = "fieldinput";
                    tcJSRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcJSRContent.Style.Add("border-top", "1px black solid");
                        
                    tcJSRContent.Style.Add("border-left", "1px black solid");
                        
                    tcJSRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJSRContent.Style.Add("border-right", "1px black solid");
                        
                    tcJSRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcJSRContent);
              
                    // 生成一对一相关表表格
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // 设置主表信息
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
        // 创建空白PDF文档
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // 添加主表及一对一相关表信息
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // 添加一对多相关表信息
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // 生成表格
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
        
        intColumn += 4 + 20;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("消息", font19B));
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
        // 定义分割线
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
                // 生成主表表格
            
                // 生成一对一相关表表格
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // 生成表格
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
                // 加入表头信息
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // 加入相关表字段名称
                
                // 加入相关表数据
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
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

