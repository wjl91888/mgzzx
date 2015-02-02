/****************************************************** 
FileName:T_BM_GZXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_GZXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_GZXXWebUIDetail : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
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
        appData = new T_BM_GZXXApplicationData();
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
                strMessageParam[1] = "工资信息";
                strMessageParam[2] = drTemp["XM"].ToString();
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
        appData = new T_BM_GZXXApplicationData();
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
            intColumn += 4 + 4;
            // 获得行数
            int intLength = 0;
    
            intLength = 14;
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
            
                    // 显示姓名标题
                    TableCell tcXMTitle = new TableCell();
                    tcXMTitle.Text = "姓名";
                    tcXMTitle.ColumnSpan = 4;
                    tcXMTitle.RowSpan = 1;
                    tcXMTitle.CssClass = "fieldname";
                    tcXMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcXMTitle);
                    
                    // 显示姓名值
                    TableCell tcXMContent = new TableCell();
                      
                    tcXMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XM")).InnerHtml = "";
                    tcXMContent.ColumnSpan = 12;
                    tcXMContent.RowSpan = 1;
                    tcXMContent.CssClass = "fieldinput";
                    tcXMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcXMContent.Style.Add("border-top", "1px black solid");
                        
                    tcXMContent.Style.Add("border-left", "1px black solid");
                        
                    tcXMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXMContent.Style.Add("border-right", "1px black solid");
                        
                    tcXMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcXMContent);
              
                    // 显示性别标题
                    TableCell tcXBTitle = new TableCell();
                    tcXBTitle.Text = "性别";
                    tcXBTitle.ColumnSpan = 4;
                    tcXBTitle.RowSpan = 1;
                    tcXBTitle.CssClass = "fieldname";
                    tcXBTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXBTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcXBTitle);
                    
                    // 显示性别值
                    TableCell tcXBContent = new TableCell();
                      
                    tcXBContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml = "";
                    tcXBContent.ColumnSpan = 4;
                    tcXBContent.RowSpan = 1;
                    tcXBContent.CssClass = "fieldinput";
                    tcXBContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXBContent.Style.Add("border-top", "1px black solid");
                        
                    tcXBContent.Style.Add("border-left", "1px black solid");
                        
                    tcXBContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXBContent.Style.Add("border-right", "1px black solid");
                        
                    tcXBContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcXBContent);
              
                    // 显示身份证号标题
                    TableCell tcSFZHTitle = new TableCell();
                    tcSFZHTitle.Text = "身份证号";
                    tcSFZHTitle.ColumnSpan = 4;
                    tcSFZHTitle.RowSpan = 1;
                    tcSFZHTitle.CssClass = "fieldname";
                    tcSFZHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFZHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcSFZHTitle);
                    
                    // 显示身份证号值
                    TableCell tcSFZHContent = new TableCell();
                      
                    tcSFZHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml = "";
                    tcSFZHContent.ColumnSpan = 12;
                    tcSFZHContent.RowSpan = 1;
                    tcSFZHContent.CssClass = "fieldinput";
                    tcSFZHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcSFZHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFZHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcSFZHContent);
              
                    // 显示日期标题
                    TableCell tcFFGZNYTitle = new TableCell();
                    tcFFGZNYTitle.Text = "日期";
                    tcFFGZNYTitle.ColumnSpan = 4;
                    tcFFGZNYTitle.RowSpan = 1;
                    tcFFGZNYTitle.CssClass = "fieldname";
                    tcFFGZNYTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFFGZNYTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcFFGZNYTitle);
                    
                    // 显示日期值
                    TableCell tcFFGZNYContent = new TableCell();
                      
                    tcFFGZNYContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FFGZNY")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FFGZNY")).InnerHtml = "";
                    tcFFGZNYContent.ColumnSpan = 4;
                    tcFFGZNYContent.RowSpan = 1;
                    tcFFGZNYContent.CssClass = "fieldinput";
                    tcFFGZNYContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFFGZNYContent.Style.Add("border-top", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-left", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-right", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcFFGZNYContent);
              
                    // 显示基础工资标题
                    TableCell tcJCGZTitle = new TableCell();
                    tcJCGZTitle.Text = "基础工资";
                    tcJCGZTitle.ColumnSpan = 4;
                    tcJCGZTitle.RowSpan = 1;
                    tcJCGZTitle.CssClass = "fieldname";
                    tcJCGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJCGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcJCGZTitle);
                    
                    // 显示基础工资值
                    TableCell tcJCGZContent = new TableCell();
                      
                    tcJCGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JCGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JCGZ")).InnerHtml = "";
                    tcJCGZContent.ColumnSpan = 4;
                    tcJCGZContent.RowSpan = 1;
                    tcJCGZContent.CssClass = "fieldinput";
                    tcJCGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJCGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJCGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[3].Cells.Add(tcJCGZContent);
              
                    // 显示技术等级工资标题
                    TableCell tcJSDJGZTitle = new TableCell();
                    tcJSDJGZTitle.Text = "技术等级工资";
                    tcJSDJGZTitle.ColumnSpan = 4;
                    tcJSDJGZTitle.RowSpan = 1;
                    tcJSDJGZTitle.CssClass = "fieldname";
                    tcJSDJGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJSDJGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcJSDJGZTitle);
                    
                    // 显示技术等级工资值
                    TableCell tcJSDJGZContent = new TableCell();
                      
                    tcJSDJGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JSDJGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JSDJGZ")).InnerHtml = "";
                    tcJSDJGZContent.ColumnSpan = 4;
                    tcJSDJGZContent.RowSpan = 1;
                    tcJSDJGZContent.CssClass = "fieldinput";
                    tcJSDJGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJSDJGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcJSDJGZContent);
              
                    // 显示职务工资标题
                    TableCell tcZWGZTitle = new TableCell();
                    tcZWGZTitle.Text = "职务工资";
                    tcZWGZTitle.ColumnSpan = 4;
                    tcZWGZTitle.RowSpan = 1;
                    tcZWGZTitle.CssClass = "fieldname";
                    tcZWGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZWGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcZWGZTitle);
                    
                    // 显示职务工资值
                    TableCell tcZWGZContent = new TableCell();
                      
                    tcZWGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZWGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZWGZ")).InnerHtml = "";
                    tcZWGZContent.ColumnSpan = 4;
                    tcZWGZContent.RowSpan = 1;
                    tcZWGZContent.CssClass = "fieldinput";
                    tcZWGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZWGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcZWGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[3].Cells.Add(tcZWGZContent);
              
                    // 显示级别工资标题
                    TableCell tcJBGZTitle = new TableCell();
                    tcJBGZTitle.Text = "级别工资";
                    tcJBGZTitle.ColumnSpan = 4;
                    tcJBGZTitle.RowSpan = 1;
                    tcJBGZTitle.CssClass = "fieldname";
                    tcJBGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJBGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJBGZTitle);
                    
                    // 显示级别工资值
                    TableCell tcJBGZContent = new TableCell();
                      
                    tcJBGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JBGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JBGZ")).InnerHtml = "";
                    tcJBGZContent.ColumnSpan = 4;
                    tcJBGZContent.RowSpan = 1;
                    tcJBGZContent.CssClass = "fieldinput";
                    tcJBGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJBGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJBGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJBGZContent);
              
                    // 显示艰苦地区津贴标题
                    TableCell tcJKDQJTTitle = new TableCell();
                    tcJKDQJTTitle.Text = "艰苦地区津贴";
                    tcJKDQJTTitle.ColumnSpan = 4;
                    tcJKDQJTTitle.RowSpan = 1;
                    tcJKDQJTTitle.CssClass = "fieldname";
                    tcJKDQJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJKDQJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJKDQJTTitle);
                    
                    // 显示艰苦地区津贴值
                    TableCell tcJKDQJTContent = new TableCell();
                      
                    tcJKDQJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JKDQJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JKDQJT")).InnerHtml = "";
                    tcJKDQJTContent.ColumnSpan = 4;
                    tcJKDQJTContent.RowSpan = 1;
                    tcJKDQJTContent.CssClass = "fieldinput";
                    tcJKDQJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJKDQJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJKDQJTContent);
              
                    // 显示艰苦特岗津贴标题
                    TableCell tcJKTSGWJTTitle = new TableCell();
                    tcJKTSGWJTTitle.Text = "艰苦特岗津贴";
                    tcJKTSGWJTTitle.ColumnSpan = 4;
                    tcJKTSGWJTTitle.RowSpan = 1;
                    tcJKTSGWJTTitle.CssClass = "fieldname";
                    tcJKTSGWJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJKTSGWJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJKTSGWJTTitle);
                    
                    // 显示艰苦特岗津贴值
                    TableCell tcJKTSGWJTContent = new TableCell();
                      
                    tcJKTSGWJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JKTSGWJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JKTSGWJT")).InnerHtml = "";
                    tcJKTSGWJTContent.ColumnSpan = 4;
                    tcJKTSGWJTContent.RowSpan = 1;
                    tcJKTSGWJTContent.CssClass = "fieldinput";
                    tcJKTSGWJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJKTSGWJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJKTSGWJTContent);
              
                    // 显示工龄工资标题
                    TableCell tcGLGZTitle = new TableCell();
                    tcGLGZTitle.Text = "工龄工资";
                    tcGLGZTitle.ColumnSpan = 4;
                    tcGLGZTitle.RowSpan = 1;
                    tcGLGZTitle.CssClass = "fieldname";
                    tcGLGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcGLGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcGLGZTitle);
                    
                    // 显示工龄工资值
                    TableCell tcGLGZContent = new TableCell();
                      
                    tcGLGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("GLGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("GLGZ")).InnerHtml = "";
                    tcGLGZContent.ColumnSpan = 4;
                    tcGLGZContent.RowSpan = 1;
                    tcGLGZContent.CssClass = "fieldinput";
                    tcGLGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcGLGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcGLGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcGLGZContent);
              
                    // 显示薪级工资标题
                    TableCell tcXJGZTitle = new TableCell();
                    tcXJGZTitle.Text = "薪级工资";
                    tcXJGZTitle.ColumnSpan = 4;
                    tcXJGZTitle.RowSpan = 1;
                    tcXJGZTitle.CssClass = "fieldname";
                    tcXJGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXJGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcXJGZTitle);
                    
                    // 显示薪级工资值
                    TableCell tcXJGZContent = new TableCell();
                      
                    tcXJGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XJGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XJGZ")).InnerHtml = "";
                    tcXJGZContent.ColumnSpan = 4;
                    tcXJGZContent.RowSpan = 1;
                    tcXJGZContent.CssClass = "fieldinput";
                    tcXJGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXJGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcXJGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcXJGZContent);
              
                    // 显示10%提高部分标题
                    TableCell tcTGBFTitle = new TableCell();
                    tcTGBFTitle.Text = "10%提高部分";
                    tcTGBFTitle.ColumnSpan = 4;
                    tcTGBFTitle.RowSpan = 1;
                    tcTGBFTitle.CssClass = "fieldname";
                    tcTGBFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcTGBFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcTGBFTitle);
                    
                    // 显示10%提高部分值
                    TableCell tcTGBFContent = new TableCell();
                      
                    tcTGBFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("TGBF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("TGBF")).InnerHtml = "";
                    tcTGBFContent.ColumnSpan = 4;
                    tcTGBFContent.RowSpan = 1;
                    tcTGBFContent.CssClass = "fieldinput";
                    tcTGBFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcTGBFContent.Style.Add("border-top", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-left", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-right", "1px black solid");
                        
                    tcTGBFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcTGBFContent);
              
                    // 显示电话费标题
                    TableCell tcDHFTitle = new TableCell();
                    tcDHFTitle.Text = "电话费";
                    tcDHFTitle.ColumnSpan = 4;
                    tcDHFTitle.RowSpan = 1;
                    tcDHFTitle.CssClass = "fieldname";
                    tcDHFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDHFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcDHFTitle);
                    
                    // 显示电话费值
                    TableCell tcDHFContent = new TableCell();
                      
                    tcDHFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DHF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DHF")).InnerHtml = "";
                    tcDHFContent.ColumnSpan = 4;
                    tcDHFContent.RowSpan = 1;
                    tcDHFContent.CssClass = "fieldinput";
                    tcDHFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDHFContent.Style.Add("border-top", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-left", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-right", "1px black solid");
                        
                    tcDHFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcDHFContent);
              
                    // 显示独生子女费标题
                    TableCell tcDSZNFTitle = new TableCell();
                    tcDSZNFTitle.Text = "独生子女费";
                    tcDSZNFTitle.ColumnSpan = 4;
                    tcDSZNFTitle.RowSpan = 1;
                    tcDSZNFTitle.CssClass = "fieldname";
                    tcDSZNFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDSZNFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcDSZNFTitle);
                    
                    // 显示独生子女费值
                    TableCell tcDSZNFContent = new TableCell();
                      
                    tcDSZNFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DSZNF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DSZNF")).InnerHtml = "";
                    tcDSZNFContent.ColumnSpan = 4;
                    tcDSZNFContent.RowSpan = 1;
                    tcDSZNFContent.CssClass = "fieldinput";
                    tcDSZNFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDSZNFContent.Style.Add("border-top", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-left", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-right", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcDSZNFContent);
              
                    // 显示妇女卫生费标题
                    TableCell tcFNWSHLFTitle = new TableCell();
                    tcFNWSHLFTitle.Text = "妇女卫生费";
                    tcFNWSHLFTitle.ColumnSpan = 4;
                    tcFNWSHLFTitle.RowSpan = 1;
                    tcFNWSHLFTitle.CssClass = "fieldname";
                    tcFNWSHLFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFNWSHLFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcFNWSHLFTitle);
                    
                    // 显示妇女卫生费值
                    TableCell tcFNWSHLFContent = new TableCell();
                      
                    tcFNWSHLFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FNWSHLF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FNWSHLF")).InnerHtml = "";
                    tcFNWSHLFContent.ColumnSpan = 4;
                    tcFNWSHLFContent.RowSpan = 1;
                    tcFNWSHLFContent.CssClass = "fieldinput";
                    tcFNWSHLFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFNWSHLFContent.Style.Add("border-top", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-left", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-right", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcFNWSHLFContent);
              
                    // 显示护理费标题
                    TableCell tcHLFTitle = new TableCell();
                    tcHLFTitle.Text = "护理费";
                    tcHLFTitle.ColumnSpan = 4;
                    tcHLFTitle.RowSpan = 1;
                    tcHLFTitle.CssClass = "fieldname";
                    tcHLFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHLFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcHLFTitle);
                    
                    // 显示护理费值
                    TableCell tcHLFContent = new TableCell();
                      
                    tcHLFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HLF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HLF")).InnerHtml = "";
                    tcHLFContent.ColumnSpan = 4;
                    tcHLFContent.RowSpan = 1;
                    tcHLFContent.CssClass = "fieldinput";
                    tcHLFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHLFContent.Style.Add("border-top", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-left", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-right", "1px black solid");
                        
                    tcHLFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcHLFContent);
              
                    // 显示取暖补贴标题
                    TableCell tcJJTitle = new TableCell();
                    tcJJTitle.Text = "取暖补贴";
                    tcJJTitle.ColumnSpan = 4;
                    tcJJTitle.RowSpan = 1;
                    tcJJTitle.CssClass = "fieldname";
                    tcJJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcJJTitle);
                    
                    // 显示取暖补贴值
                    TableCell tcJJContent = new TableCell();
                      
                    tcJJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JJ")).InnerHtml = "";
                    tcJJContent.ColumnSpan = 4;
                    tcJJContent.RowSpan = 1;
                    tcJJContent.CssClass = "fieldinput";
                    tcJJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJJContent.Style.Add("border-top", "1px black solid");
                        
                    tcJJContent.Style.Add("border-left", "1px black solid");
                        
                    tcJJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJJContent.Style.Add("border-right", "1px black solid");
                        
                    tcJJContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcJJContent);
              
                    // 显示交通费标题
                    TableCell tcJTFTitle = new TableCell();
                    tcJTFTitle.Text = "交通费";
                    tcJTFTitle.ColumnSpan = 4;
                    tcJTFTitle.RowSpan = 1;
                    tcJTFTitle.CssClass = "fieldname";
                    tcJTFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJTFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcJTFTitle);
                    
                    // 显示交通费值
                    TableCell tcJTFContent = new TableCell();
                      
                    tcJTFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JTF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JTF")).InnerHtml = "";
                    tcJTFContent.ColumnSpan = 4;
                    tcJTFContent.RowSpan = 1;
                    tcJTFContent.CssClass = "fieldinput";
                    tcJTFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJTFContent.Style.Add("border-top", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-left", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-right", "1px black solid");
                        
                    tcJTFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcJTFContent);
              
                    // 显示教护龄工资标题
                    TableCell tcJHLGZTitle = new TableCell();
                    tcJHLGZTitle.Text = "教护龄工资";
                    tcJHLGZTitle.ColumnSpan = 4;
                    tcJHLGZTitle.RowSpan = 1;
                    tcJHLGZTitle.CssClass = "fieldname";
                    tcJHLGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJHLGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcJHLGZTitle);
                    
                    // 显示教护龄工资值
                    TableCell tcJHLGZContent = new TableCell();
                      
                    tcJHLGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JHLGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JHLGZ")).InnerHtml = "";
                    tcJHLGZContent.ColumnSpan = 4;
                    tcJHLGZContent.RowSpan = 1;
                    tcJHLGZContent.CssClass = "fieldinput";
                    tcJHLGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJHLGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcJHLGZContent);
              
                    // 显示津贴标题
                    TableCell tcJTTitle = new TableCell();
                    tcJTTitle.Text = "津贴";
                    tcJTTitle.ColumnSpan = 4;
                    tcJTTitle.RowSpan = 1;
                    tcJTTitle.CssClass = "fieldname";
                    tcJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcJTTitle);
                    
                    // 显示津贴值
                    TableCell tcJTContent = new TableCell();
                      
                    tcJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JT")).InnerHtml = "";
                    tcJTContent.ColumnSpan = 4;
                    tcJTContent.RowSpan = 1;
                    tcJTContent.CssClass = "fieldinput";
                    tcJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcJTContent);
              
                    // 显示补发标题
                    TableCell tcBFTitle = new TableCell();
                    tcBFTitle.Text = "补发";
                    tcBFTitle.ColumnSpan = 4;
                    tcBFTitle.RowSpan = 1;
                    tcBFTitle.CssClass = "fieldname";
                    tcBFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcBFTitle);
                    
                    // 显示补发值
                    TableCell tcBFContent = new TableCell();
                      
                    tcBFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BF")).InnerHtml = "";
                    tcBFContent.ColumnSpan = 4;
                    tcBFContent.RowSpan = 1;
                    tcBFContent.CssClass = "fieldinput";
                    tcBFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcBFContent.Style.Add("border-top", "1px black solid");
                        
                    tcBFContent.Style.Add("border-left", "1px black solid");
                        
                    tcBFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBFContent.Style.Add("border-right", "1px black solid");
                        
                    tcBFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcBFContent);
              
                    // 显示其他补贴标题
                    TableCell tcQTBTTitle = new TableCell();
                    tcQTBTTitle.Text = "其他补贴";
                    tcQTBTTitle.ColumnSpan = 4;
                    tcQTBTTitle.RowSpan = 1;
                    tcQTBTTitle.CssClass = "fieldname";
                    tcQTBTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcQTBTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcQTBTTitle);
                    
                    // 显示其他补贴值
                    TableCell tcQTBTContent = new TableCell();
                      
                    tcQTBTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("QTBT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("QTBT")).InnerHtml = "";
                    tcQTBTContent.ColumnSpan = 4;
                    tcQTBTContent.RowSpan = 1;
                    tcQTBTContent.CssClass = "fieldinput";
                    tcQTBTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcQTBTContent.Style.Add("border-top", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-left", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-right", "1px black solid");
                        
                    tcQTBTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcQTBTContent);
              
                    // 显示地方性津贴标题
                    TableCell tcDFXJTTitle = new TableCell();
                    tcDFXJTTitle.Text = "地方性津贴";
                    tcDFXJTTitle.ColumnSpan = 4;
                    tcDFXJTTitle.RowSpan = 1;
                    tcDFXJTTitle.CssClass = "fieldname";
                    tcDFXJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDFXJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcDFXJTTitle);
                    
                    // 显示地方性津贴值
                    TableCell tcDFXJTContent = new TableCell();
                      
                    tcDFXJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DFXJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DFXJT")).InnerHtml = "";
                    tcDFXJTContent.ColumnSpan = 4;
                    tcDFXJTContent.RowSpan = 1;
                    tcDFXJTContent.CssClass = "fieldinput";
                    tcDFXJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDFXJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcDFXJTContent);
              
                    // 显示应发项标题
                    TableCell tcYFXTitle = new TableCell();
                    tcYFXTitle.Text = "应发项";
                    tcYFXTitle.ColumnSpan = 4;
                    tcYFXTitle.RowSpan = 1;
                    tcYFXTitle.CssClass = "fieldname";
                    tcYFXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYFXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcYFXTitle);
                    
                    // 显示应发项值
                    TableCell tcYFXContent = new TableCell();
                      
                    tcYFXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YFX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YFX")).InnerHtml = "";
                    tcYFXContent.ColumnSpan = 4;
                    tcYFXContent.RowSpan = 1;
                    tcYFXContent.CssClass = "fieldinput";
                    tcYFXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYFXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYFXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcYFXContent);
              
                    // 显示其他扣款标题
                    TableCell tcQTKKTitle = new TableCell();
                    tcQTKKTitle.Text = "其他扣款";
                    tcQTKKTitle.ColumnSpan = 4;
                    tcQTKKTitle.RowSpan = 1;
                    tcQTKKTitle.CssClass = "fieldname";
                    tcQTKKTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcQTKKTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcQTKKTitle);
                    
                    // 显示其他扣款值
                    TableCell tcQTKKContent = new TableCell();
                      
                    tcQTKKContent.Text = ((HtmlContainerControl)hcTemp.FindControl("QTKK")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("QTKK")).InnerHtml = "";
                    tcQTKKContent.ColumnSpan = 4;
                    tcQTKKContent.RowSpan = 1;
                    tcQTKKContent.CssClass = "fieldinput";
                    tcQTKKContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcQTKKContent.Style.Add("border-top", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-left", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-right", "1px black solid");
                        
                    tcQTKKContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcQTKKContent);
              
                    // 显示失业保险标题
                    TableCell tcSYBXTitle = new TableCell();
                    tcSYBXTitle.Text = "失业保险";
                    tcSYBXTitle.ColumnSpan = 4;
                    tcSYBXTitle.RowSpan = 1;
                    tcSYBXTitle.CssClass = "fieldname";
                    tcSYBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSYBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcSYBXTitle);
                    
                    // 显示失业保险值
                    TableCell tcSYBXContent = new TableCell();
                      
                    tcSYBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SYBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SYBX")).InnerHtml = "";
                    tcSYBXContent.ColumnSpan = 4;
                    tcSYBXContent.RowSpan = 1;
                    tcSYBXContent.CssClass = "fieldinput";
                    tcSYBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSYBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcSYBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcSYBXContent);
              
                    // 显示水电暖气费标题
                    TableCell tcSDNQFTitle = new TableCell();
                    tcSDNQFTitle.Text = "水电暖气费";
                    tcSDNQFTitle.ColumnSpan = 4;
                    tcSDNQFTitle.RowSpan = 1;
                    tcSDNQFTitle.CssClass = "fieldname";
                    tcSDNQFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSDNQFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcSDNQFTitle);
                    
                    // 显示水电暖气费值
                    TableCell tcSDNQFContent = new TableCell();
                      
                    tcSDNQFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SDNQF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SDNQF")).InnerHtml = "";
                    tcSDNQFContent.ColumnSpan = 4;
                    tcSDNQFContent.RowSpan = 1;
                    tcSDNQFContent.CssClass = "fieldinput";
                    tcSDNQFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSDNQFContent.Style.Add("border-top", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-left", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-right", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcSDNQFContent);
              
                    // 显示所得税标题
                    TableCell tcSDSTitle = new TableCell();
                    tcSDSTitle.Text = "所得税";
                    tcSDSTitle.ColumnSpan = 4;
                    tcSDSTitle.RowSpan = 1;
                    tcSDSTitle.CssClass = "fieldname";
                    tcSDSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSDSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcSDSTitle);
                    
                    // 显示所得税值
                    TableCell tcSDSContent = new TableCell();
                      
                    tcSDSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SDS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SDS")).InnerHtml = "";
                    tcSDSContent.ColumnSpan = 4;
                    tcSDSContent.RowSpan = 1;
                    tcSDSContent.CssClass = "fieldinput";
                    tcSDSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSDSContent.Style.Add("border-top", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-left", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-right", "1px black solid");
                        
                    tcSDSContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcSDSContent);
              
                    // 显示养老保险标题
                    TableCell tcYLBXTitle = new TableCell();
                    tcYLBXTitle.Text = "养老保险";
                    tcYLBXTitle.ColumnSpan = 4;
                    tcYLBXTitle.RowSpan = 1;
                    tcYLBXTitle.CssClass = "fieldname";
                    tcYLBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYLBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcYLBXTitle);
                    
                    // 显示养老保险值
                    TableCell tcYLBXContent = new TableCell();
                      
                    tcYLBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YLBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YLBX")).InnerHtml = "";
                    tcYLBXContent.ColumnSpan = 4;
                    tcYLBXContent.RowSpan = 1;
                    tcYLBXContent.CssClass = "fieldinput";
                    tcYLBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYLBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYLBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcYLBXContent);
              
                    // 显示医疗保险标题
                    TableCell tcYLIBXTitle = new TableCell();
                    tcYLIBXTitle.Text = "医疗保险";
                    tcYLIBXTitle.ColumnSpan = 4;
                    tcYLIBXTitle.RowSpan = 1;
                    tcYLIBXTitle.CssClass = "fieldname";
                    tcYLIBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYLIBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcYLIBXTitle);
                    
                    // 显示医疗保险值
                    TableCell tcYLIBXContent = new TableCell();
                      
                    tcYLIBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YLIBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YLIBX")).InnerHtml = "";
                    tcYLIBXContent.ColumnSpan = 4;
                    tcYLIBXContent.RowSpan = 1;
                    tcYLIBXContent.CssClass = "fieldinput";
                    tcYLIBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYLIBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcYLIBXContent);
              
                    // 显示遗属生活费标题
                    TableCell tcYSSHFTitle = new TableCell();
                    tcYSSHFTitle.Text = "遗属生活费";
                    tcYSSHFTitle.ColumnSpan = 4;
                    tcYSSHFTitle.RowSpan = 1;
                    tcYSSHFTitle.CssClass = "fieldname";
                    tcYSSHFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYSSHFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcYSSHFTitle);
                    
                    // 显示遗属生活费值
                    TableCell tcYSSHFContent = new TableCell();
                      
                    tcYSSHFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YSSHF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YSSHF")).InnerHtml = "";
                    tcYSSHFContent.ColumnSpan = 4;
                    tcYSSHFContent.RowSpan = 1;
                    tcYSSHFContent.CssClass = "fieldinput";
                    tcYSSHFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYSSHFContent.Style.Add("border-top", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-left", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-right", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcYSSHFContent);
              
                    // 显示住房公积金标题
                    TableCell tcZFGJJTitle = new TableCell();
                    tcZFGJJTitle.Text = "住房公积金";
                    tcZFGJJTitle.ColumnSpan = 4;
                    tcZFGJJTitle.RowSpan = 1;
                    tcZFGJJTitle.CssClass = "fieldname";
                    tcZFGJJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZFGJJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcZFGJJTitle);
                    
                    // 显示住房公积金值
                    TableCell tcZFGJJContent = new TableCell();
                      
                    tcZFGJJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZFGJJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZFGJJ")).InnerHtml = "";
                    tcZFGJJContent.ColumnSpan = 4;
                    tcZFGJJContent.RowSpan = 1;
                    tcZFGJJContent.CssClass = "fieldinput";
                    tcZFGJJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZFGJJContent.Style.Add("border-top", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-left", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-right", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcZFGJJContent);
              
                    // 显示扣发项标题
                    TableCell tcKFXTitle = new TableCell();
                    tcKFXTitle.Text = "扣发项";
                    tcKFXTitle.ColumnSpan = 4;
                    tcKFXTitle.RowSpan = 1;
                    tcKFXTitle.CssClass = "fieldname";
                    tcKFXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKFXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcKFXTitle);
                    
                    // 显示扣发项值
                    TableCell tcKFXContent = new TableCell();
                      
                    tcKFXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KFX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KFX")).InnerHtml = "";
                    tcKFXContent.ColumnSpan = 4;
                    tcKFXContent.RowSpan = 1;
                    tcKFXContent.CssClass = "fieldinput";
                    tcKFXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKFXContent.Style.Add("border-top", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-left", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-right", "1px black solid");
                        
                    tcKFXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcKFXContent);
              
                    // 显示实发工资标题
                    TableCell tcSFGZTitle = new TableCell();
                    tcSFGZTitle.Text = "实发工资";
                    tcSFGZTitle.ColumnSpan = 4;
                    tcSFGZTitle.RowSpan = 1;
                    tcSFGZTitle.CssClass = "fieldname";
                    tcSFGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[13].Cells.Add(tcSFGZTitle);
                    
                    // 显示实发工资值
                    TableCell tcSFGZContent = new TableCell();
                      
                    tcSFGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFGZ")).InnerHtml = "";
                    tcSFGZContent.ColumnSpan = 20;
                    tcSFGZContent.RowSpan = 1;
                    tcSFGZContent.CssClass = "fieldinput";
                    tcSFGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcSFGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFGZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[13].Cells.Add(tcSFGZContent);
              
                    // 显示说明标题
                    TableCell tcGZKKSMTitle = new TableCell();
                    tcGZKKSMTitle.Text = "说明";
                    tcGZKKSMTitle.ColumnSpan = 4;
                    tcGZKKSMTitle.RowSpan = 1;
                    tcGZKKSMTitle.CssClass = "fieldname";
                    tcGZKKSMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcGZKKSMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[14].Cells.Add(tcGZKKSMTitle);
                    
                    // 显示说明值
                    TableCell tcGZKKSMContent = new TableCell();
                      
                    tcGZKKSMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("GZKKSM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("GZKKSM")).InnerHtml = "";
                    tcGZKKSMContent.ColumnSpan = 20;
                    tcGZKKSMContent.RowSpan = 1;
                    tcGZKKSMContent.CssClass = "fieldinput";
                    tcGZKKSMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcGZKKSMContent.Style.Add("border-top", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-left", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-right", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("text-align", "left");
                    tDetailView.Rows[14].Cells.Add(tcGZKKSMContent);
              
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
        intColumn += 4 + 4;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("工资信息", font19B));
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

