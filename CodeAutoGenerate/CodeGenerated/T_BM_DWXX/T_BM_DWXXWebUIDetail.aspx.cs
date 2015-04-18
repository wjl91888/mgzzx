/****************************************************** 
FileName:T_BM_DWXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_DWXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_DWXXWebUIDetail : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
        appData = new T_BM_DWXXApplicationData();
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
                strMessageParam[1] = "单位信息";
                strMessageParam[2] = drTemp["DWMC"].ToString();
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
        appData = new T_BM_DWXXApplicationData();
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
            
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            // 获得行数
            int intLength = 0;
    
            intLength = 4;
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
            
                    // 显示单位编号标题
                    TableCell tcDWBHTitle = new TableCell();
                    tcDWBHTitle.Text = "单位编号";
                    tcDWBHTitle.ColumnSpan = 1;
                    tcDWBHTitle.RowSpan = 1;
                    tcDWBHTitle.CssClass = "fieldname";
                    tcDWBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDWBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDWBHTitle);
                    
                    // 显示单位编号值
                    TableCell tcDWBHContent = new TableCell();
                      
                    tcDWBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DWBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DWBH")).InnerHtml = "";
                    tcDWBHContent.ColumnSpan = 1;
                    tcDWBHContent.RowSpan = 1;
                    tcDWBHContent.CssClass = "fieldinput";
                    tcDWBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcDWBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcDWBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDWBHContent);
              
                    // 显示单位名称标题
                    TableCell tcDWMCTitle = new TableCell();
                    tcDWMCTitle.Text = "单位名称";
                    tcDWMCTitle.ColumnSpan = 1;
                    tcDWMCTitle.RowSpan = 1;
                    tcDWMCTitle.CssClass = "fieldname";
                    tcDWMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDWMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDWMCTitle);
                    
                    // 显示单位名称值
                    TableCell tcDWMCContent = new TableCell();
                      
                    tcDWMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DWMC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DWMC")).InnerHtml = "";
                    tcDWMCContent.ColumnSpan = 1;
                    tcDWMCContent.RowSpan = 1;
                    tcDWMCContent.CssClass = "fieldinput";
                    tcDWMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcDWMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcDWMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDWMCContent);
              
                    // 显示上级单位标题
                    TableCell tcSJDWBHTitle = new TableCell();
                    tcSJDWBHTitle.Text = "上级单位";
                    tcSJDWBHTitle.ColumnSpan = 1;
                    tcSJDWBHTitle.RowSpan = 1;
                    tcSJDWBHTitle.CssClass = "fieldname";
                    tcSJDWBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJDWBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcSJDWBHTitle);
                    
                    // 显示上级单位值
                    TableCell tcSJDWBHContent = new TableCell();
                      
                    tcSJDWBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJDWBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJDWBH")).InnerHtml = "";
                    tcSJDWBHContent.ColumnSpan = 1;
                    tcSJDWBHContent.RowSpan = 1;
                    tcSJDWBHContent.CssClass = "fieldinput";
                    tcSJDWBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcSJDWBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcSJDWBHContent);
              
                    // 显示地址标题
                    TableCell tcDZTitle = new TableCell();
                    tcDZTitle.Text = "地址";
                    tcDZTitle.ColumnSpan = 1;
                    tcDZTitle.RowSpan = 1;
                    tcDZTitle.CssClass = "fieldname";
                    tcDZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcDZTitle);
                    
                    // 显示地址值
                    TableCell tcDZContent = new TableCell();
                      
                    tcDZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DZ")).InnerHtml = "";
                    tcDZContent.ColumnSpan = 3;
                    tcDZContent.RowSpan = 1;
                    tcDZContent.CssClass = "fieldinput";
                    tcDZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcDZContent.Style.Add("border-top", "1px black solid");
                        
                    tcDZContent.Style.Add("border-left", "1px black solid");
                        
                    tcDZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDZContent.Style.Add("border-right", "1px black solid");
                        
                    tcDZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcDZContent);
              
                    // 显示邮编标题
                    TableCell tcYBTitle = new TableCell();
                    tcYBTitle.Text = "邮编";
                    tcYBTitle.ColumnSpan = 1;
                    tcYBTitle.RowSpan = 1;
                    tcYBTitle.CssClass = "fieldname";
                    tcYBTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcYBTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcYBTitle);
                    
                    // 显示邮编值
                    TableCell tcYBContent = new TableCell();
                      
                    tcYBContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YB")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YB")).InnerHtml = "";
                    tcYBContent.ColumnSpan = 1;
                    tcYBContent.RowSpan = 1;
                    tcYBContent.CssClass = "fieldinput";
                    tcYBContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcYBContent.Style.Add("border-top", "1px black solid");
                        
                    tcYBContent.Style.Add("border-left", "1px black solid");
                        
                    tcYBContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYBContent.Style.Add("border-right", "1px black solid");
                        
                    tcYBContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcYBContent);
              
                    // 显示联系部门标题
                    TableCell tcLXBMTitle = new TableCell();
                    tcLXBMTitle.Text = "联系部门";
                    tcLXBMTitle.ColumnSpan = 1;
                    tcLXBMTitle.RowSpan = 1;
                    tcLXBMTitle.CssClass = "fieldname";
                    tcLXBMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXBMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcLXBMTitle);
                    
                    // 显示联系部门值
                    TableCell tcLXBMContent = new TableCell();
                      
                    tcLXBMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXBM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXBM")).InnerHtml = "";
                    tcLXBMContent.ColumnSpan = 1;
                    tcLXBMContent.RowSpan = 1;
                    tcLXBMContent.CssClass = "fieldinput";
                    tcLXBMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLXBMContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXBMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcLXBMContent);
              
                    // 显示联系电话标题
                    TableCell tcLXDHTitle = new TableCell();
                    tcLXDHTitle.Text = "联系电话";
                    tcLXDHTitle.ColumnSpan = 1;
                    tcLXDHTitle.RowSpan = 1;
                    tcLXDHTitle.CssClass = "fieldname";
                    tcLXDHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXDHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcLXDHTitle);
                    
                    // 显示联系电话值
                    TableCell tcLXDHContent = new TableCell();
                      
                    tcLXDHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXDH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXDH")).InnerHtml = "";
                    tcLXDHContent.ColumnSpan = 1;
                    tcLXDHContent.RowSpan = 1;
                    tcLXDHContent.CssClass = "fieldinput";
                    tcLXDHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLXDHContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXDHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcLXDHContent);
              
                    // 显示Email标题
                    TableCell tcEmailTitle = new TableCell();
                    tcEmailTitle.Text = "Email";
                    tcEmailTitle.ColumnSpan = 1;
                    tcEmailTitle.RowSpan = 1;
                    tcEmailTitle.CssClass = "fieldname";
                    tcEmailTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcEmailTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcEmailTitle);
                    
                    // 显示Email值
                    TableCell tcEmailContent = new TableCell();
                      
                    tcEmailContent.Text = ((HtmlContainerControl)hcTemp.FindControl("Email")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("Email")).InnerHtml = "";
                    tcEmailContent.ColumnSpan = 1;
                    tcEmailContent.RowSpan = 1;
                    tcEmailContent.CssClass = "fieldinput";
                    tcEmailContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcEmailContent.Style.Add("border-top", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-left", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-right", "1px black solid");
                        
                    tcEmailContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcEmailContent);
              
                    // 显示联系人标题
                    TableCell tcLXRTitle = new TableCell();
                    tcLXRTitle.Text = "联系人";
                    tcLXRTitle.ColumnSpan = 1;
                    tcLXRTitle.RowSpan = 1;
                    tcLXRTitle.CssClass = "fieldname";
                    tcLXRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcLXRTitle);
                    
                    // 显示联系人值
                    TableCell tcLXRContent = new TableCell();
                      
                    tcLXRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXR")).InnerHtml = "";
                    tcLXRContent.ColumnSpan = 2;
                    tcLXRContent.RowSpan = 1;
                    tcLXRContent.CssClass = "fieldinput";
                    tcLXRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 2 / intColumn));
                        
                    tcLXRContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcLXRContent);
              
                    // 显示手机标题
                    TableCell tcSJTitle = new TableCell();
                    tcSJTitle.Text = "手机";
                    tcSJTitle.ColumnSpan = 1;
                    tcSJTitle.RowSpan = 1;
                    tcSJTitle.CssClass = "fieldname";
                    tcSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSJTitle);
                    
                    // 显示手机值
                    TableCell tcSJContent = new TableCell();
                      
                    tcSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJ")).InnerHtml = "";
                    tcSJContent.ColumnSpan = 2;
                    tcSJContent.RowSpan = 1;
                    tcSJContent.CssClass = "fieldinput";
                    tcSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 2 / intColumn));
                        
                    tcSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSJContent);
              
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
        
        intColumn += 1 + 1;
        intColumn += 1 + 1;
        intColumn += 1 + 1;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("单位信息", font19B));
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

