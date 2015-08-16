/****************************************************** 
FileName:T_PM_UserInfoWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_PM_UserInfo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_PM_UserInfoWebUIDetail : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
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
        appData = new T_PM_UserInfoApplicationData();
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
                strMessageParam[1] = "用户信息";
                strMessageParam[2] = drTemp["UserNickName"].ToString();
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
        appData = new T_PM_UserInfoApplicationData();
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
            intColumn += 1 + 1;
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
            
                    // 显示用户编号标题
                    TableCell tcUserIDTitle = new TableCell();
                    tcUserIDTitle.Text = "用户编号";
                    tcUserIDTitle.ColumnSpan = 1;
                    tcUserIDTitle.RowSpan = 1;
                    tcUserIDTitle.CssClass = "fieldname";
                    tcUserIDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserIDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcUserIDTitle);
                    
                    // 显示用户编号值
                    TableCell tcUserIDContent = new TableCell();
                      
                    tcUserIDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserID")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserID")).InnerHtml = "";
                    tcUserIDContent.ColumnSpan = 1;
                    tcUserIDContent.RowSpan = 1;
                    tcUserIDContent.CssClass = "fieldinput";
                    tcUserIDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserIDContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserIDContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserIDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcUserIDContent);
              
                    // 显示用户名标题
                    TableCell tcUserLoginNameTitle = new TableCell();
                    tcUserLoginNameTitle.Text = "用户名";
                    tcUserLoginNameTitle.ColumnSpan = 1;
                    tcUserLoginNameTitle.RowSpan = 1;
                    tcUserLoginNameTitle.CssClass = "fieldname";
                    tcUserLoginNameTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserLoginNameTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcUserLoginNameTitle);
                    
                    // 显示用户名值
                    TableCell tcUserLoginNameContent = new TableCell();
                      
                    tcUserLoginNameContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserLoginName")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserLoginName")).InnerHtml = "";
                    tcUserLoginNameContent.ColumnSpan = 1;
                    tcUserLoginNameContent.RowSpan = 1;
                    tcUserLoginNameContent.CssClass = "fieldinput";
                    tcUserLoginNameContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserLoginNameContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserLoginNameContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserLoginNameContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserLoginNameContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserLoginNameContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcUserLoginNameContent);
              
                    // 显示用户组标题
                    TableCell tcUserGroupIDTitle = new TableCell();
                    tcUserGroupIDTitle.Text = "用户组";
                    tcUserGroupIDTitle.ColumnSpan = 1;
                    tcUserGroupIDTitle.RowSpan = 1;
                    tcUserGroupIDTitle.CssClass = "fieldname";
                    tcUserGroupIDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserGroupIDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupIDTitle);
                    
                    // 显示用户组值
                    TableCell tcUserGroupIDContent = new TableCell();
                      
                    tcUserGroupIDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserGroupID")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserGroupID")).InnerHtml = "";
                    tcUserGroupIDContent.ColumnSpan = 1;
                    tcUserGroupIDContent.RowSpan = 1;
                    tcUserGroupIDContent.CssClass = "fieldinput";
                    tcUserGroupIDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserGroupIDContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupIDContent);
              
                    // 显示所属单位标题
                    TableCell tcSubjectIDTitle = new TableCell();
                    tcSubjectIDTitle.Text = "所属单位";
                    tcSubjectIDTitle.ColumnSpan = 1;
                    tcSubjectIDTitle.RowSpan = 1;
                    tcSubjectIDTitle.CssClass = "fieldname";
                    tcSubjectIDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSubjectIDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcSubjectIDTitle);
                    
                    // 显示所属单位值
                    TableCell tcSubjectIDContent = new TableCell();
                      
                    tcSubjectIDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SubjectID")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SubjectID")).InnerHtml = "";
                    tcSubjectIDContent.ColumnSpan = 1;
                    tcSubjectIDContent.RowSpan = 1;
                    tcSubjectIDContent.CssClass = "fieldinput";
                    tcSubjectIDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcSubjectIDContent.Style.Add("border-top", "1px black solid");
                        
                    tcSubjectIDContent.Style.Add("border-left", "1px black solid");
                        
                    tcSubjectIDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSubjectIDContent.Style.Add("border-right", "1px black solid");
                        
                    tcSubjectIDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcSubjectIDContent);
              
                    // 显示姓名标题
                    TableCell tcUserNickNameTitle = new TableCell();
                    tcUserNickNameTitle.Text = "姓名";
                    tcUserNickNameTitle.ColumnSpan = 1;
                    tcUserNickNameTitle.RowSpan = 1;
                    tcUserNickNameTitle.CssClass = "fieldname";
                    tcUserNickNameTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserNickNameTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcUserNickNameTitle);
                    
                    // 显示姓名值
                    TableCell tcUserNickNameContent = new TableCell();
                      
                    tcUserNickNameContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserNickName")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserNickName")).InnerHtml = "";
                    tcUserNickNameContent.ColumnSpan = 1;
                    tcUserNickNameContent.RowSpan = 1;
                    tcUserNickNameContent.CssClass = "fieldinput";
                    tcUserNickNameContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserNickNameContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserNickNameContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserNickNameContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserNickNameContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserNickNameContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcUserNickNameContent);
              
                    // 显示性别标题
                    TableCell tcXBTitle = new TableCell();
                    tcXBTitle.Text = "性别";
                    tcXBTitle.ColumnSpan = 1;
                    tcXBTitle.RowSpan = 1;
                    tcXBTitle.CssClass = "fieldname";
                    tcXBTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcXBTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcXBTitle);
                    
                    // 显示性别值
                    TableCell tcXBContent = new TableCell();
                      
                    tcXBContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml = "";
                    tcXBContent.ColumnSpan = 1;
                    tcXBContent.RowSpan = 1;
                    tcXBContent.CssClass = "fieldinput";
                    tcXBContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcXBContent.Style.Add("border-top", "1px black solid");
                        
                    tcXBContent.Style.Add("border-left", "1px black solid");
                        
                    tcXBContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXBContent.Style.Add("border-right", "1px black solid");
                        
                    tcXBContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcXBContent);
              
                    // 显示民族标题
                    TableCell tcMZTitle = new TableCell();
                    tcMZTitle.Text = "民族";
                    tcMZTitle.ColumnSpan = 1;
                    tcMZTitle.RowSpan = 1;
                    tcMZTitle.CssClass = "fieldname";
                    tcMZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcMZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcMZTitle);
                    
                    // 显示民族值
                    TableCell tcMZContent = new TableCell();
                      
                    tcMZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("MZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("MZ")).InnerHtml = "";
                    tcMZContent.ColumnSpan = 1;
                    tcMZContent.RowSpan = 1;
                    tcMZContent.CssClass = "fieldinput";
                    tcMZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcMZContent.Style.Add("border-top", "1px black solid");
                        
                    tcMZContent.Style.Add("border-left", "1px black solid");
                        
                    tcMZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcMZContent.Style.Add("border-right", "1px black solid");
                        
                    tcMZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcMZContent);
              
                    // 显示政治面貌标题
                    TableCell tcZZMMTitle = new TableCell();
                    tcZZMMTitle.Text = "政治面貌";
                    tcZZMMTitle.ColumnSpan = 1;
                    tcZZMMTitle.RowSpan = 1;
                    tcZZMMTitle.CssClass = "fieldname";
                    tcZZMMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcZZMMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcZZMMTitle);
                    
                    // 显示政治面貌值
                    TableCell tcZZMMContent = new TableCell();
                      
                    tcZZMMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZZMM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZZMM")).InnerHtml = "";
                    tcZZMMContent.ColumnSpan = 1;
                    tcZZMMContent.RowSpan = 1;
                    tcZZMMContent.CssClass = "fieldinput";
                    tcZZMMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcZZMMContent.Style.Add("border-top", "1px black solid");
                        
                    tcZZMMContent.Style.Add("border-left", "1px black solid");
                        
                    tcZZMMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZZMMContent.Style.Add("border-right", "1px black solid");
                        
                    tcZZMMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcZZMMContent);
              
                    // 显示身份证号标题
                    TableCell tcSFZHTitle = new TableCell();
                    tcSFZHTitle.Text = "身份证号";
                    tcSFZHTitle.ColumnSpan = 1;
                    tcSFZHTitle.RowSpan = 1;
                    tcSFZHTitle.CssClass = "fieldname";
                    tcSFZHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSFZHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcSFZHTitle);
                    
                    // 显示身份证号值
                    TableCell tcSFZHContent = new TableCell();
                      
                    tcSFZHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml = "";
                    tcSFZHContent.ColumnSpan = 5;
                    tcSFZHContent.RowSpan = 1;
                    tcSFZHContent.CssClass = "fieldinput";
                    tcSFZHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 5 / intColumn));
                        
                    tcSFZHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFZHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcSFZHContent);
              
                    // 显示手机标题
                    TableCell tcSJHTitle = new TableCell();
                    tcSJHTitle.Text = "手机";
                    tcSJHTitle.ColumnSpan = 1;
                    tcSJHTitle.RowSpan = 1;
                    tcSJHTitle.CssClass = "fieldname";
                    tcSJHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcSJHTitle);
                    
                    // 显示手机值
                    TableCell tcSJHContent = new TableCell();
                      
                    tcSJHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJH")).InnerHtml = "";
                    tcSJHContent.ColumnSpan = 1;
                    tcSJHContent.RowSpan = 1;
                    tcSJHContent.CssClass = "fieldinput";
                    tcSJHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcSJHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcSJHContent);
              
                    // 显示办公电话标题
                    TableCell tcBGDHTitle = new TableCell();
                    tcBGDHTitle.Text = "办公电话";
                    tcBGDHTitle.ColumnSpan = 1;
                    tcBGDHTitle.RowSpan = 1;
                    tcBGDHTitle.CssClass = "fieldname";
                    tcBGDHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcBGDHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcBGDHTitle);
                    
                    // 显示办公电话值
                    TableCell tcBGDHContent = new TableCell();
                      
                    tcBGDHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BGDH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BGDH")).InnerHtml = "";
                    tcBGDHContent.ColumnSpan = 1;
                    tcBGDHContent.RowSpan = 1;
                    tcBGDHContent.CssClass = "fieldinput";
                    tcBGDHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcBGDHContent.Style.Add("border-top", "1px black solid");
                        
                    tcBGDHContent.Style.Add("border-left", "1px black solid");
                        
                    tcBGDHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBGDHContent.Style.Add("border-right", "1px black solid");
                        
                    tcBGDHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcBGDHContent);
              
                    // 显示家庭电话标题
                    TableCell tcJTDHTitle = new TableCell();
                    tcJTDHTitle.Text = "家庭电话";
                    tcJTDHTitle.ColumnSpan = 1;
                    tcJTDHTitle.RowSpan = 1;
                    tcJTDHTitle.CssClass = "fieldname";
                    tcJTDHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcJTDHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJTDHTitle);
                    
                    // 显示家庭电话值
                    TableCell tcJTDHContent = new TableCell();
                      
                    tcJTDHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JTDH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JTDH")).InnerHtml = "";
                    tcJTDHContent.ColumnSpan = 1;
                    tcJTDHContent.RowSpan = 1;
                    tcJTDHContent.CssClass = "fieldinput";
                    tcJTDHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcJTDHContent.Style.Add("border-top", "1px black solid");
                        
                    tcJTDHContent.Style.Add("border-left", "1px black solid");
                        
                    tcJTDHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJTDHContent.Style.Add("border-right", "1px black solid");
                        
                    tcJTDHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcJTDHContent);
              
                    // 显示Email标题
                    TableCell tcEmailTitle = new TableCell();
                    tcEmailTitle.Text = "Email";
                    tcEmailTitle.ColumnSpan = 1;
                    tcEmailTitle.RowSpan = 1;
                    tcEmailTitle.CssClass = "fieldname";
                    tcEmailTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcEmailTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcEmailTitle);
                    
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
                    tDetailView.Rows[4].Cells.Add(tcEmailContent);
              
                    // 显示QQ标题
                    TableCell tcQQHTitle = new TableCell();
                    tcQQHTitle.Text = "QQ";
                    tcQQHTitle.ColumnSpan = 1;
                    tcQQHTitle.RowSpan = 1;
                    tcQQHTitle.CssClass = "fieldname";
                    tcQQHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcQQHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcQQHTitle);
                    
                    // 显示QQ值
                    TableCell tcQQHContent = new TableCell();
                      
                    tcQQHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("QQH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("QQH")).InnerHtml = "";
                    tcQQHContent.ColumnSpan = 1;
                    tcQQHContent.RowSpan = 1;
                    tcQQHContent.CssClass = "fieldinput";
                    tcQQHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcQQHContent.Style.Add("border-top", "1px black solid");
                        
                    tcQQHContent.Style.Add("border-left", "1px black solid");
                        
                    tcQQHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcQQHContent.Style.Add("border-right", "1px black solid");
                        
                    tcQQHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcQQHContent);
              
                    // 显示登录时间标题
                    TableCell tcLoginTimeTitle = new TableCell();
                    tcLoginTimeTitle.Text = "登录时间";
                    tcLoginTimeTitle.ColumnSpan = 1;
                    tcLoginTimeTitle.RowSpan = 1;
                    tcLoginTimeTitle.CssClass = "fieldname";
                    tcLoginTimeTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLoginTimeTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcLoginTimeTitle);
                    
                    // 显示登录时间值
                    TableCell tcLoginTimeContent = new TableCell();
                      
                    tcLoginTimeContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LoginTime")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LoginTime")).InnerHtml = "";
                    tcLoginTimeContent.ColumnSpan = 1;
                    tcLoginTimeContent.RowSpan = 1;
                    tcLoginTimeContent.CssClass = "fieldinput";
                    tcLoginTimeContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLoginTimeContent.Style.Add("border-top", "1px black solid");
                        
                    tcLoginTimeContent.Style.Add("border-left", "1px black solid");
                        
                    tcLoginTimeContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLoginTimeContent.Style.Add("border-right", "1px black solid");
                        
                    tcLoginTimeContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcLoginTimeContent);
              
                    // 显示登录IP标题
                    TableCell tcLastLoginIPTitle = new TableCell();
                    tcLastLoginIPTitle.Text = "登录IP";
                    tcLastLoginIPTitle.ColumnSpan = 1;
                    tcLastLoginIPTitle.RowSpan = 1;
                    tcLastLoginIPTitle.CssClass = "fieldname";
                    tcLastLoginIPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLastLoginIPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcLastLoginIPTitle);
                    
                    // 显示登录IP值
                    TableCell tcLastLoginIPContent = new TableCell();
                      
                    tcLastLoginIPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LastLoginIP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LastLoginIP")).InnerHtml = "";
                    tcLastLoginIPContent.ColumnSpan = 1;
                    tcLastLoginIPContent.RowSpan = 1;
                    tcLastLoginIPContent.CssClass = "fieldinput";
                    tcLastLoginIPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLastLoginIPContent.Style.Add("border-top", "1px black solid");
                        
                    tcLastLoginIPContent.Style.Add("border-left", "1px black solid");
                        
                    tcLastLoginIPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLastLoginIPContent.Style.Add("border-right", "1px black solid");
                        
                    tcLastLoginIPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcLastLoginIPContent);
              
                    // 显示上次时间标题
                    TableCell tcLastLoginDateTitle = new TableCell();
                    tcLastLoginDateTitle.Text = "上次时间";
                    tcLastLoginDateTitle.ColumnSpan = 1;
                    tcLastLoginDateTitle.RowSpan = 1;
                    tcLastLoginDateTitle.CssClass = "fieldname";
                    tcLastLoginDateTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLastLoginDateTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcLastLoginDateTitle);
                    
                    // 显示上次时间值
                    TableCell tcLastLoginDateContent = new TableCell();
                      
                    tcLastLoginDateContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LastLoginDate")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LastLoginDate")).InnerHtml = "";
                    tcLastLoginDateContent.ColumnSpan = 1;
                    tcLastLoginDateContent.RowSpan = 1;
                    tcLastLoginDateContent.CssClass = "fieldinput";
                    tcLastLoginDateContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLastLoginDateContent.Style.Add("border-top", "1px black solid");
                        
                    tcLastLoginDateContent.Style.Add("border-left", "1px black solid");
                        
                    tcLastLoginDateContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLastLoginDateContent.Style.Add("border-right", "1px black solid");
                        
                    tcLastLoginDateContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcLastLoginDateContent);
              
                    // 显示登录次数标题
                    TableCell tcLoginTimesTitle = new TableCell();
                    tcLoginTimesTitle.Text = "登录次数";
                    tcLoginTimesTitle.ColumnSpan = 1;
                    tcLoginTimesTitle.RowSpan = 1;
                    tcLoginTimesTitle.CssClass = "fieldname";
                    tcLoginTimesTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLoginTimesTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcLoginTimesTitle);
                    
                    // 显示登录次数值
                    TableCell tcLoginTimesContent = new TableCell();
                      
                    tcLoginTimesContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LoginTimes")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LoginTimes")).InnerHtml = "";
                    tcLoginTimesContent.ColumnSpan = 1;
                    tcLoginTimesContent.RowSpan = 1;
                    tcLoginTimesContent.CssClass = "fieldinput";
                    tcLoginTimesContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLoginTimesContent.Style.Add("border-top", "1px black solid");
                        
                    tcLoginTimesContent.Style.Add("border-left", "1px black solid");
                        
                    tcLoginTimesContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLoginTimesContent.Style.Add("border-right", "1px black solid");
                        
                    tcLoginTimesContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcLoginTimesContent);
              
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
        intColumn += 1 + 1;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("用户信息", font19B));
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

