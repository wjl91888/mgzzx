/****************************************************** 
FileName:T_BM_DWXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_DWXX;

public partial class T_BM_DWXXWebUIStatistic : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
            InitalizeDataBind();
            InitalizeCoupledDataSource();
            // 初始化界面

            // 界面控件状态

            if (false

            )
            {
                statisticpage.Style.Add("display", "none");
                statisticresultpage.Visible = true;
                Initalize();
            }
            else
            {
                statisticpage.Visible = true;
                statisticresultpage.Visible = false;
            }
        }
        else
        {
            InitalizeCoupledDataSource();
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
        // 创建信息标题
        lblCaption.Text = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        // 数据统计
        appData = new T_BM_DWXXApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
    }

    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // 一对一相关表

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_BM_DWXXApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // 创建信息标题
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFileWithoutControl(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
        }
    }

    #region 控件事件
    //=====================================================================
    //  FunctionName : btnShowStatistic_Click
    /// <summary>
    /// 显示统计条件界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "block");
        statisticresultpage.Visible = false;
    }

    //=====================================================================
    //  FunctionName : btnStatistic_Click
    /// <summary>
    /// 统计结果按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "none");
        statisticresultpage.Visible = true;
        ViewState.Clear();
        Initalize();
    }
    #endregion


    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// 初始化联动设置
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }




    //=====================================================================
    //  FunctionName : GetCountInputParameter
    /// <summary>
    /// 得到统计记录数用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetCountInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数


        if (!DataValidateManager.ValidateIsNull(CountField.SelectedValue))
        {
            if (!DataValidateManager.ValidateStringLengthRange(CountField.SelectedValue.ToString(), 1, 50))
            {
                  strMessageParam[0] = "统计方式";
                  strMessageParam[1] = "1";
                  strMessageParam[2] = "50";
                  strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                  boolReturn = false;
            }
            else
            {
                appData.CountField = CountField.SelectedValue.ToString();
            }
        }
        else
        {
              strMessageParam[0] = "统计方式";
              strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, strMessageParam, strMessageInfo);
              boolReturn = false;
        }

        if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
        {
            if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
            {
                appData.Sort = DEFAULT_SORT;
            }
            else
            {
                appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
            }
        }
        else
        {
            appData.Sort = DEFAULT_SORT;
        }

        if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
        {
            if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
            {
                appData.SortField = "RecordID";
            }
            else
            {
                appData.SortField = ViewState["SortField"].ToString();
            }
        }
        else
        {
            appData.SortField = "RecordID";
        }
        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetTableCaption
    /// <summary>
    /// 得到信息标题
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
        System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
        sbCaption.Append(@"单位信息统计（"+CountField.SelectedItem.Text+"）");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"统计条件如下：");
        // 主表

        // 一对一相关表

            sbCaption.Append("</div>");
        return sbCaption.ToString();
    }
}

