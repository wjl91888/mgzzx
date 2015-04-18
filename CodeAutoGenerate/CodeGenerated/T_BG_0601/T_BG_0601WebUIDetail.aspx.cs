/****************************************************** 
FileName:T_BG_0601WebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BG_0601;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BG_0601WebUIDetail : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
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
        appData = new T_BG_0601ApplicationData();
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
                strMessageParam[1] = "公共信息";
                strMessageParam[2] = drTemp["BT"].ToString();
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
        appData = new T_BG_0601ApplicationData();
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
            
            intColumn += 4 + 12;
            // 获得行数
            int intLength = 0;
    
            intLength = 9;
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
                    TableCell tcBTTitle = new TableCell();
                    tcBTTitle.Text = "标题";
                    tcBTTitle.ColumnSpan = 4;
                    tcBTTitle.RowSpan = 1;
                    tcBTTitle.CssClass = "fieldname";
                    tcBTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcBTTitle);
                    
                    // 显示标题值
                    TableCell tcBTContent = new TableCell();
                      
                    tcBTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BT")).InnerHtml = "";
                    tcBTContent.ColumnSpan = 12;
                    tcBTContent.RowSpan = 1;
                    tcBTContent.CssClass = "fieldinput";
                    tcBTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcBTContent.Style.Add("border-top", "1px black solid");
                        
                    tcBTContent.Style.Add("border-left", "1px black solid");
                        
                    tcBTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBTContent.Style.Add("border-right", "1px black solid");
                        
                    tcBTContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcBTContent);
              
                    // 显示发布栏目标题
                    TableCell tcFBLMTitle = new TableCell();
                    tcFBLMTitle.Text = "发布栏目";
                    tcFBLMTitle.ColumnSpan = 4;
                    tcFBLMTitle.RowSpan = 1;
                    tcFBLMTitle.CssClass = "fieldname";
                    tcFBLMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFBLMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcFBLMTitle);
                    
                    // 显示发布栏目值
                    TableCell tcFBLMContent = new TableCell();
                      
                    tcFBLMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FBLM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FBLM")).InnerHtml = "";
                    tcFBLMContent.ColumnSpan = 4;
                    tcFBLMContent.RowSpan = 1;
                    tcFBLMContent.CssClass = "fieldinput";
                    tcFBLMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFBLMContent.Style.Add("border-top", "1px black solid");
                        
                    tcFBLMContent.Style.Add("border-left", "1px black solid");
                        
                    tcFBLMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFBLMContent.Style.Add("border-right", "1px black solid");
                        
                    tcFBLMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcFBLMContent);
              
                    // 显示发布部门标题
                    TableCell tcFBBMTitle = new TableCell();
                    tcFBBMTitle.Text = "发布部门";
                    tcFBBMTitle.ColumnSpan = 4;
                    tcFBBMTitle.RowSpan = 1;
                    tcFBBMTitle.CssClass = "fieldname";
                    tcFBBMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFBBMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcFBBMTitle);
                    
                    // 显示发布部门值
                    TableCell tcFBBMContent = new TableCell();
                      
                    tcFBBMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FBBM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FBBM")).InnerHtml = "";
                    tcFBBMContent.ColumnSpan = 4;
                    tcFBBMContent.RowSpan = 1;
                    tcFBBMContent.CssClass = "fieldinput";
                    tcFBBMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFBBMContent.Style.Add("border-top", "1px black solid");
                        
                    tcFBBMContent.Style.Add("border-left", "1px black solid");
                        
                    tcFBBMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFBBMContent.Style.Add("border-right", "1px black solid");
                        
                    tcFBBMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcFBBMContent);
              
                    // 显示信息图片标题
                    TableCell tcXXTPDZTitle = new TableCell();
                    tcXXTPDZTitle.Text = "信息图片";
                    tcXXTPDZTitle.ColumnSpan = 4;
                    tcXXTPDZTitle.RowSpan = 1;
                    tcXXTPDZTitle.CssClass = "fieldname";
                    tcXXTPDZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXXTPDZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcXXTPDZTitle);
                    
                    // 显示信息图片值
                    TableCell tcXXTPDZContent = new TableCell();
                      
                    tcXXTPDZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XXTPDZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XXTPDZ")).InnerHtml = "";
                    tcXXTPDZContent.ColumnSpan = 12;
                    tcXXTPDZContent.RowSpan = 1;
                    tcXXTPDZContent.CssClass = "fieldinput";
                    tcXXTPDZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcXXTPDZContent.Style.Add("border-top", "1px black solid");
                        
                    tcXXTPDZContent.Style.Add("border-left", "1px black solid");
                        
                    tcXXTPDZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXXTPDZContent.Style.Add("border-right", "1px black solid");
                        
                    tcXXTPDZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcXXTPDZContent);
              
                    // 显示信息内容值
                    TableCell tcXXNRContent = new TableCell();
                      
                    tcXXNRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XXNR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XXNR")).InnerHtml = "";
                    tcXXNRContent.ColumnSpan = 16;
                    tcXXNRContent.RowSpan = 1;
                    tcXXNRContent.CssClass = "fieldinput";
                    tcXXNRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 16 / intColumn));
                        
                    tcXXNRContent.Style.Add("border-top", "1px black solid");
                        
                    tcXXNRContent.Style.Add("border-left", "1px black solid");
                        
                    tcXXNRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXXNRContent.Style.Add("border-right", "1px black solid");
                        
                    tcXXNRContent.Style.Add("text-align", "left");
                    tDetailView.Rows[4].Cells.Add(tcXXNRContent);
              
                    // 显示附件标题
                    TableCell tcFJXZDZTitle = new TableCell();
                    tcFJXZDZTitle.Text = "附件";
                    tcFJXZDZTitle.ColumnSpan = 4;
                    tcFJXZDZTitle.RowSpan = 1;
                    tcFJXZDZTitle.CssClass = "fieldname";
                    tcFJXZDZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFJXZDZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcFJXZDZTitle);
                    
                    // 显示附件值
                    TableCell tcFJXZDZContent = new TableCell();
                      
                    tcFJXZDZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FJXZDZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FJXZDZ")).InnerHtml = "";
                    tcFJXZDZContent.ColumnSpan = 12;
                    tcFJXZDZContent.RowSpan = 1;
                    tcFJXZDZContent.CssClass = "fieldinput";
                    tcFJXZDZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcFJXZDZContent.Style.Add("border-top", "1px black solid");
                        
                    tcFJXZDZContent.Style.Add("border-left", "1px black solid");
                        
                    tcFJXZDZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFJXZDZContent.Style.Add("border-right", "1px black solid");
                        
                    tcFJXZDZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcFJXZDZContent);
              
                    // 显示发布人标题
                    TableCell tcFBRJGHTitle = new TableCell();
                    tcFBRJGHTitle.Text = "发布人";
                    tcFBRJGHTitle.ColumnSpan = 4;
                    tcFBRJGHTitle.RowSpan = 1;
                    tcFBRJGHTitle.CssClass = "fieldname";
                    tcFBRJGHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFBRJGHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcFBRJGHTitle);
                    
                    // 显示发布人值
                    TableCell tcFBRJGHContent = new TableCell();
                      
                    tcFBRJGHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FBRJGH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FBRJGH")).InnerHtml = "";
                    tcFBRJGHContent.ColumnSpan = 4;
                    tcFBRJGHContent.RowSpan = 1;
                    tcFBRJGHContent.CssClass = "fieldinput";
                    tcFBRJGHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFBRJGHContent.Style.Add("border-top", "1px black solid");
                        
                    tcFBRJGHContent.Style.Add("border-left", "1px black solid");
                        
                    tcFBRJGHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFBRJGHContent.Style.Add("border-right", "1px black solid");
                        
                    tcFBRJGHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[8].Cells.Add(tcFBRJGHContent);
              
                    // 显示发布时间标题
                    TableCell tcFBSJRQTitle = new TableCell();
                    tcFBSJRQTitle.Text = "发布时间";
                    tcFBSJRQTitle.ColumnSpan = 4;
                    tcFBSJRQTitle.RowSpan = 1;
                    tcFBSJRQTitle.CssClass = "fieldname";
                    tcFBSJRQTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFBSJRQTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcFBSJRQTitle);
                    
                    // 显示发布时间值
                    TableCell tcFBSJRQContent = new TableCell();
                      
                    tcFBSJRQContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FBSJRQ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FBSJRQ")).InnerHtml = "";
                    tcFBSJRQContent.ColumnSpan = 4;
                    tcFBSJRQContent.RowSpan = 1;
                    tcFBSJRQContent.CssClass = "fieldinput";
                    tcFBSJRQContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFBSJRQContent.Style.Add("border-top", "1px black solid");
                        
                    tcFBSJRQContent.Style.Add("border-left", "1px black solid");
                        
                    tcFBSJRQContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFBSJRQContent.Style.Add("border-right", "1px black solid");
                        
                    tcFBSJRQContent.Style.Add("text-align", "center");
                    tDetailView.Rows[8].Cells.Add(tcFBSJRQContent);
              
                    // 显示发布IP标题
                    TableCell tcFBIPTitle = new TableCell();
                    tcFBIPTitle.Text = "发布IP";
                    tcFBIPTitle.ColumnSpan = 4;
                    tcFBIPTitle.RowSpan = 1;
                    tcFBIPTitle.CssClass = "fieldname";
                    tcFBIPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFBIPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcFBIPTitle);
                    
                    // 显示发布IP值
                    TableCell tcFBIPContent = new TableCell();
                      
                    tcFBIPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FBIP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FBIP")).InnerHtml = "";
                    tcFBIPContent.ColumnSpan = 12;
                    tcFBIPContent.RowSpan = 1;
                    tcFBIPContent.CssClass = "fieldinput";
                    tcFBIPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcFBIPContent.Style.Add("border-top", "1px black solid");
                        
                    tcFBIPContent.Style.Add("border-left", "1px black solid");
                        
                    tcFBIPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFBIPContent.Style.Add("border-right", "1px black solid");
                        
                    tcFBIPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[9].Cells.Add(tcFBIPContent);
              
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
        
        intColumn += 4 + 12;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("公共信息", font19B));
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

