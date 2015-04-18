/****************************************************** 
FileName:T_BG_0602WebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BG_0602;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BG_0602WebUIDetail : RICH.Common.BM.T_BG_0602.T_BG_0602WebUI
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
        appData = new T_BG_0602ApplicationData();
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
                strMessageParam[1] = "公共信息栏目";
                strMessageParam[2] = drTemp["LMM"].ToString();
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
        appData = new T_BG_0602ApplicationData();
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
            
            intColumn += 4 + 4;
            intColumn += 4 + 4;
            intColumn += 4 + 4;
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
            
                    // 显示栏目号标题
                    TableCell tcLMHTitle = new TableCell();
                    tcLMHTitle.Text = "栏目号";
                    tcLMHTitle.ColumnSpan = 4;
                    tcLMHTitle.RowSpan = 1;
                    tcLMHTitle.CssClass = "fieldname";
                    tcLMHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLMHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcLMHTitle);
                    
                    // 显示栏目号值
                    TableCell tcLMHContent = new TableCell();
                      
                    tcLMHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LMH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LMH")).InnerHtml = "";
                    tcLMHContent.ColumnSpan = 4;
                    tcLMHContent.RowSpan = 1;
                    tcLMHContent.CssClass = "fieldinput";
                    tcLMHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcLMHContent.Style.Add("border-top", "1px black solid");
                        
                    tcLMHContent.Style.Add("border-left", "1px black solid");
                        
                    tcLMHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLMHContent.Style.Add("border-right", "1px black solid");
                        
                    tcLMHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcLMHContent);
              
                    // 显示栏目名标题
                    TableCell tcLMMTitle = new TableCell();
                    tcLMMTitle.Text = "栏目名";
                    tcLMMTitle.ColumnSpan = 4;
                    tcLMMTitle.RowSpan = 1;
                    tcLMMTitle.CssClass = "fieldname";
                    tcLMMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLMMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcLMMTitle);
                    
                    // 显示栏目名值
                    TableCell tcLMMContent = new TableCell();
                      
                    tcLMMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LMM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LMM")).InnerHtml = "";
                    tcLMMContent.ColumnSpan = 4;
                    tcLMMContent.RowSpan = 1;
                    tcLMMContent.CssClass = "fieldinput";
                    tcLMMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcLMMContent.Style.Add("border-top", "1px black solid");
                        
                    tcLMMContent.Style.Add("border-left", "1px black solid");
                        
                    tcLMMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLMMContent.Style.Add("border-right", "1px black solid");
                        
                    tcLMMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcLMMContent);
              
                    // 显示上级栏目标题
                    TableCell tcSJLMHTitle = new TableCell();
                    tcSJLMHTitle.Text = "上级栏目";
                    tcSJLMHTitle.ColumnSpan = 4;
                    tcSJLMHTitle.RowSpan = 1;
                    tcSJLMHTitle.CssClass = "fieldname";
                    tcSJLMHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSJLMHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcSJLMHTitle);
                    
                    // 显示上级栏目值
                    TableCell tcSJLMHContent = new TableCell();
                      
                    tcSJLMHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJLMH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJLMH")).InnerHtml = "";
                    tcSJLMHContent.ColumnSpan = 4;
                    tcSJLMHContent.RowSpan = 1;
                    tcSJLMHContent.CssClass = "fieldinput";
                    tcSJLMHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSJLMHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJLMHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJLMHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJLMHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJLMHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcSJLMHContent);
              
                    // 显示栏目图片标题
                    TableCell tcLMTPTitle = new TableCell();
                    tcLMTPTitle.Text = "栏目图片";
                    tcLMTPTitle.ColumnSpan = 4;
                    tcLMTPTitle.RowSpan = 1;
                    tcLMTPTitle.CssClass = "fieldname";
                    tcLMTPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLMTPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcLMTPTitle);
                    
                    // 显示栏目图片值
                    TableCell tcLMTPContent = new TableCell();
                      
                    tcLMTPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LMTP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LMTP")).InnerHtml = "";
                    tcLMTPContent.ColumnSpan = 20;
                    tcLMTPContent.RowSpan = 1;
                    tcLMTPContent.CssClass = "fieldinput";
                    tcLMTPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcLMTPContent.Style.Add("border-top", "1px black solid");
                        
                    tcLMTPContent.Style.Add("border-left", "1px black solid");
                        
                    tcLMTPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLMTPContent.Style.Add("border-right", "1px black solid");
                        
                    tcLMTPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcLMTPContent);
              
                    // 显示栏目显示内容标题
                    TableCell tcLMNRTitle = new TableCell();
                    tcLMNRTitle.Text = "栏目显示内容";
                    tcLMNRTitle.ColumnSpan = 4;
                    tcLMNRTitle.RowSpan = 1;
                    tcLMNRTitle.CssClass = "fieldname";
                    tcLMNRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLMNRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcLMNRTitle);
                    
                    // 显示栏目显示内容值
                    TableCell tcLMNRContent = new TableCell();
                      
                    tcLMNRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LMNR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LMNR")).InnerHtml = "";
                    tcLMNRContent.ColumnSpan = 20;
                    tcLMNRContent.RowSpan = 1;
                    tcLMNRContent.CssClass = "fieldinput";
                    tcLMNRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcLMNRContent.Style.Add("border-top", "1px black solid");
                        
                    tcLMNRContent.Style.Add("border-left", "1px black solid");
                        
                    tcLMNRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLMNRContent.Style.Add("border-right", "1px black solid");
                        
                    tcLMNRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcLMNRContent);
              
                    // 显示栏目列表样式标题
                    TableCell tcLMLBYSTitle = new TableCell();
                    tcLMLBYSTitle.Text = "栏目列表样式";
                    tcLMLBYSTitle.ColumnSpan = 4;
                    tcLMLBYSTitle.RowSpan = 1;
                    tcLMLBYSTitle.CssClass = "fieldname";
                    tcLMLBYSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLMLBYSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcLMLBYSTitle);
                    
                    // 显示栏目列表样式值
                    TableCell tcLMLBYSContent = new TableCell();
                      
                    tcLMLBYSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LMLBYS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LMLBYS")).InnerHtml = "";
                    tcLMLBYSContent.ColumnSpan = 4;
                    tcLMLBYSContent.RowSpan = 1;
                    tcLMLBYSContent.CssClass = "fieldinput";
                    tcLMLBYSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcLMLBYSContent.Style.Add("border-top", "1px black solid");
                        
                    tcLMLBYSContent.Style.Add("border-left", "1px black solid");
                        
                    tcLMLBYSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLMLBYSContent.Style.Add("border-right", "1px black solid");
                        
                    tcLMLBYSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcLMLBYSContent);
              
                    // 显示列表内容栏目标题
                    TableCell tcSFLBLMTitle = new TableCell();
                    tcSFLBLMTitle.Text = "列表内容栏目";
                    tcSFLBLMTitle.ColumnSpan = 4;
                    tcSFLBLMTitle.RowSpan = 1;
                    tcSFLBLMTitle.CssClass = "fieldname";
                    tcSFLBLMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFLBLMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSFLBLMTitle);
                    
                    // 显示列表内容栏目值
                    TableCell tcSFLBLMContent = new TableCell();
                      
                    tcSFLBLMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFLBLM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFLBLM")).InnerHtml = "";
                    tcSFLBLMContent.ColumnSpan = 4;
                    tcSFLBLMContent.RowSpan = 1;
                    tcSFLBLMContent.CssClass = "fieldinput";
                    tcSFLBLMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSFLBLMContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFLBLMContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFLBLMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFLBLMContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFLBLMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSFLBLMContent);
              
                    // 显示外部栏目标题
                    TableCell tcSFWBURLTitle = new TableCell();
                    tcSFWBURLTitle.Text = "外部栏目";
                    tcSFWBURLTitle.ColumnSpan = 4;
                    tcSFWBURLTitle.RowSpan = 1;
                    tcSFWBURLTitle.CssClass = "fieldname";
                    tcSFWBURLTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFWBURLTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSFWBURLTitle);
                    
                    // 显示外部栏目值
                    TableCell tcSFWBURLContent = new TableCell();
                      
                    tcSFWBURLContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFWBURL")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFWBURL")).InnerHtml = "";
                    tcSFWBURLContent.ColumnSpan = 4;
                    tcSFWBURLContent.RowSpan = 1;
                    tcSFWBURLContent.CssClass = "fieldinput";
                    tcSFWBURLContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSFWBURLContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFWBURLContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFWBURLContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFWBURLContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFWBURLContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSFWBURLContent);
              
                    // 显示外部栏目连接标题
                    TableCell tcWBURLTitle = new TableCell();
                    tcWBURLTitle.Text = "外部栏目连接";
                    tcWBURLTitle.ColumnSpan = 4;
                    tcWBURLTitle.RowSpan = 1;
                    tcWBURLTitle.CssClass = "fieldname";
                    tcWBURLTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcWBURLTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcWBURLTitle);
                    
                    // 显示外部栏目连接值
                    TableCell tcWBURLContent = new TableCell();
                      
                    tcWBURLContent.Text = ((HtmlContainerControl)hcTemp.FindControl("WBURL")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("WBURL")).InnerHtml = "";
                    tcWBURLContent.ColumnSpan = 20;
                    tcWBURLContent.RowSpan = 1;
                    tcWBURLContent.CssClass = "fieldinput";
                    tcWBURLContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcWBURLContent.Style.Add("border-top", "1px black solid");
                        
                    tcWBURLContent.Style.Add("border-left", "1px black solid");
                        
                    tcWBURLContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcWBURLContent.Style.Add("border-right", "1px black solid");
                        
                    tcWBURLContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcWBURLContent);
              
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
        
        intColumn += 4 + 4;
        intColumn += 4 + 4;
        intColumn += 4 + 4;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("公共信息栏目", font19B));
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

