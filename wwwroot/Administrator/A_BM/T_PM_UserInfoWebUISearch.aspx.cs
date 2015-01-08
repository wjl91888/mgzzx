/****************************************************** 
FileName:T_PM_UserInfoWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_PM_UserInfoWebUISearch : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
{
    #region 定义GridView列索引

    static int intUserIDColumnIndex;
    static int intUserLoginNameColumnIndex;
    static int intUserGroupIDColumnIndex;
    static int intSubjectIDColumnIndex;
    static int intUserNickNameColumnIndex;
    static int intXBColumnIndex;
    static int intMZColumnIndex;
    static int intZZMMColumnIndex;
    static int intSFZHColumnIndex;
    static int intSJHColumnIndex;
    static int intBGDHColumnIndex;
    static int intJTDHColumnIndex;
    static int intEmailColumnIndex;
    static int intQQHColumnIndex;
    static int intLoginTimeColumnIndex;
    static int intLastLoginIPColumnIndex;
    static int intLastLoginDateColumnIndex;
    static int intLoginTimesColumnIndex;
    static int intUserStatusColumnIndex;
    #endregion

    protected override void Page_Init(object sender, EventArgs e)
    {
        // 基本SESSION赋值
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_SEARCH_ACCESS_PURVIEW_ID;
        MessageContent = string.Empty;
        if (IsPostBack)
        {
            if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnOperate", StringComparison.OrdinalIgnoreCase))
            {
                switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
                {
                    case "remove":
                        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_DELETE_PURVIEW_ID;
                        break;
                    default:
                        break;
                }
            }
            else if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnExportAllToFile", StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_EXPORTALL_PURVIEW_ID;
            }
        }
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
            InitalizeColumnIndex();
            SetMoreSearchItemDisplay(false);
            InitalizeDataBind();
            InitalizeCoupledDataSource();

            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramT_PM_UserInfo.AjaxRequest += AjaxManager_AjaxRequest;
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

            gvList.Columns[intUserIDColumnIndex].Visible = chkShowUserID.Checked;
            gvList.Columns[intUserLoginNameColumnIndex].Visible = chkShowUserLoginName.Checked;
            gvList.Columns[intUserGroupIDColumnIndex].Visible = chkShowUserGroupID.Checked;
            gvList.Columns[intSubjectIDColumnIndex].Visible = chkShowSubjectID.Checked;
            gvList.Columns[intUserNickNameColumnIndex].Visible = chkShowUserNickName.Checked;
            gvList.Columns[intXBColumnIndex].Visible = chkShowXB.Checked;
            gvList.Columns[intMZColumnIndex].Visible = chkShowMZ.Checked;
            gvList.Columns[intZZMMColumnIndex].Visible = chkShowZZMM.Checked;
            gvList.Columns[intSFZHColumnIndex].Visible = chkShowSFZH.Checked;
            gvList.Columns[intSJHColumnIndex].Visible = chkShowSJH.Checked;
            gvList.Columns[intBGDHColumnIndex].Visible = chkShowBGDH.Checked;
            gvList.Columns[intJTDHColumnIndex].Visible = chkShowJTDH.Checked;
            gvList.Columns[intEmailColumnIndex].Visible = chkShowEmail.Checked;
            gvList.Columns[intQQHColumnIndex].Visible = chkShowQQH.Checked;
            gvList.Columns[intLoginTimeColumnIndex].Visible = chkShowLoginTime.Checked;
            gvList.Columns[intLastLoginIPColumnIndex].Visible = chkShowLastLoginIP.Checked;
            gvList.Columns[intLastLoginDateColumnIndex].Visible = chkShowLastLoginDate.Checked;
            gvList.Columns[intLoginTimesColumnIndex].Visible = chkShowLoginTimes.Checked;
            gvList.Columns[intUserStatusColumnIndex].Visible = chkShowUserStatus.Checked;UserGroupID.RepeatColumns = 1;
        SubjectID.RepeatColumns = 1;
        XB.RepeatColumns = 1;
        MZ.RepeatColumns = 1;
        ZZMM.RepeatColumns = 1;
        
        // 数据查询
        appData = new T_PM_UserInfoApplicationData();
        QueryRecord();
        gvList.DataSource = appData.ResultSet;
        gvList.DataBind();
        ViewState["RecordCount"] = appData.RecordCount;
        ViewState["CurrentPage"] = appData.CurrentPage;
        ViewState["PageSize"] = appData.PageSize;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;
XB_Area.Visible = isDisplay;
      MZ_Area.Visible = isDisplay;
      ZZMM_Area.Visible = isDisplay;
      SFZH_Area.Visible = isDisplay;
      BGDH_Area.Visible = isDisplay;
      JTDH_Area.Visible = isDisplay;
      
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // 查询报告列表
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // 主表

            // 初始化用户组(UserGroupID)下拉列表
          UserGroupID.DataSource = GetDataSource_UserGroupID_AdvanceSearch();
            UserGroupID.DataTextField = "UserGroupName";
            UserGroupID.DataValueField = "UserGroupID";
              UserGroupID.DataBind();
                  UserGroupID.RepeatColumns = 1;
                    
            // 初始化所属单位(SubjectID)下拉列表
          SubjectID.DataSource = GetDataSource_SubjectID_AdvanceSearch();
            SubjectID.DataTextField = "DWMC";
            SubjectID.DataValueField = "DWBH";
              SubjectID.DataBind();
                  SubjectID.RepeatColumns = 1;
                    
            // 初始化性别(XB)下拉列表
          XB.DataSource = GetDataSource_XB_AdvanceSearch();
            XB.DataTextField = "MC";
            XB.DataValueField = "DM";
              XB.DataBind();
                  XB.RepeatColumns = 1;
                    
            // 初始化民族(MZ)下拉列表
          MZ.DataSource = GetDataSource_MZ_AdvanceSearch();
            MZ.DataTextField = "MC";
            MZ.DataValueField = "DM";
              MZ.DataBind();
                  MZ.RepeatColumns = 1;
                    
            // 初始化政治面貌(ZZMM)下拉列表
          ZZMM.DataSource = GetDataSource_ZZMM_AdvanceSearch();
            ZZMM.DataTextField = "MC";
            ZZMM.DataValueField = "DM";
              ZZMM.DataBind();
                  ZZMM.RepeatColumns = 1;
                    
            // 初始化用户状态(UserStatus)下拉列表
          UserStatus.DataSource = GetDataSource_UserStatus_AdvanceSearch();
            UserStatus.DataTextField = "MC";
            UserStatus.DataValueField = "DM";
              UserStatus.DataBind();
                  UserStatus.Items.Insert(0, new ListItem("选择用户状态", ""));
                    
            // 一对一相关表

    }

    #region InitPageInfo
    //=====================================================================
    //  FunctionName : InitPageInfo
    /// <summary>
    /// 初始化分页信息栏
    /// </summary>
    //=====================================================================
    private void InitPageInfo()
    {
                if ((int)ViewState["PageCount"] == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"])
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["PageCount"] == 0)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == 0)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                else if ((int)ViewState["CurrentPage"] == 2)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }

                else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"] - 1)
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = false;
                }
                else
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                ddlPageCount.Items.Clear();
                for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                {
                    ddlPageCount.Items.Add(new ListItem("当前第" + i.ToString() + "页", i.ToString()));
                }
                ddlPageSize.Items.Clear();
                for (int i = 10; i <= 500; i=i+10)
                {
                    ddlPageSize.Items.Add(new ListItem("每页" + i.ToString() + "条记录", i.ToString()));
                }
                ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                ddlPageSize.SelectedValue = ViewState["PageSize"].ToString();
                lblPageInfo.Text = "共<b>{0}</b>页<b><span id=recordcount>{1}</span></b>条记录。";
                lblPageInfo.Text = string.Format(lblPageInfo.Text, ViewState["PageCount"], ViewState["RecordCount"]);
    }
    #endregion

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new T_PM_UserInfoApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intUserIDColumnIndex - 1].Visible = chkShowUserID.Checked;
        gvPrint.Columns[intUserLoginNameColumnIndex - 1].Visible = chkShowUserLoginName.Checked;
        gvPrint.Columns[intUserGroupIDColumnIndex - 1].Visible = chkShowUserGroupID.Checked;
        gvPrint.Columns[intSubjectIDColumnIndex - 1].Visible = chkShowSubjectID.Checked;
        gvPrint.Columns[intUserNickNameColumnIndex - 1].Visible = chkShowUserNickName.Checked;
        gvPrint.Columns[intXBColumnIndex - 1].Visible = chkShowXB.Checked;
        gvPrint.Columns[intMZColumnIndex - 1].Visible = chkShowMZ.Checked;
        gvPrint.Columns[intZZMMColumnIndex - 1].Visible = chkShowZZMM.Checked;
        gvPrint.Columns[intSFZHColumnIndex - 1].Visible = chkShowSFZH.Checked;
        gvPrint.Columns[intSJHColumnIndex - 1].Visible = chkShowSJH.Checked;
        gvPrint.Columns[intBGDHColumnIndex - 1].Visible = chkShowBGDH.Checked;
        gvPrint.Columns[intJTDHColumnIndex - 1].Visible = chkShowJTDH.Checked;
        gvPrint.Columns[intEmailColumnIndex - 1].Visible = chkShowEmail.Checked;
        gvPrint.Columns[intQQHColumnIndex - 1].Visible = chkShowQQH.Checked;
        gvPrint.Columns[intLoginTimeColumnIndex - 1].Visible = chkShowLoginTime.Checked;
        gvPrint.Columns[intLastLoginIPColumnIndex - 1].Visible = chkShowLastLoginIP.Checked;
        gvPrint.Columns[intLastLoginDateColumnIndex - 1].Visible = chkShowLastLoginDate.Checked;
        gvPrint.Columns[intLoginTimesColumnIndex - 1].Visible = chkShowLoginTimes.Checked;
        gvPrint.Columns[intUserStatusColumnIndex - 1].Visible = chkShowUserStatus.Checked;
        // 创建信息标题
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    #region 控件事件
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request事件
    /// </summary>
    //=====================================================================
    protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "Refresh":
                Initalize();
                break;
            default:
                break;
        }
    }

    //=====================================================================
    //  FunctionName : btnShowAdvanceSearchItem_Click
    /// <summary>
    /// 高级查询界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowAdvanceSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(true);
    }
    //=====================================================================
    //  FunctionName : btnShowSimpleSearchItem_Click
    /// <summary>
    /// 简单查询界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowSimpleSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(false);
    }
    //=====================================================================
    //  FunctionName : btnAdvanceSearch_Click
    /// <summary>
    /// 高级查询按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnAdvanceSearch_Click(object sender, EventArgs e)
    {
            CustomColumnIndex();
            ViewState.Clear();
            chkAll.Visible = true;
            ddlOperation.Visible = true;
            btnOperate.Visible = true;

            Initalize();
    }
    
    //=====================================================================
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// 初始化列索引
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // 初始化主表显示列序号
        
            intUserIDColumnIndex = 1;
            txtUserIDColumnIndex.Text = intUserIDColumnIndex.ToString();
            intNext = 1;
            intUserLoginNameColumnIndex = 2;
            txtUserLoginNameColumnIndex.Text = intUserLoginNameColumnIndex.ToString();
            intNext = 2;
            intUserGroupIDColumnIndex = 3;
            txtUserGroupIDColumnIndex.Text = intUserGroupIDColumnIndex.ToString();
            intNext = 3;
            intSubjectIDColumnIndex = 4;
            txtSubjectIDColumnIndex.Text = intSubjectIDColumnIndex.ToString();
            intNext = 4;
            intUserNickNameColumnIndex = 5;
            txtUserNickNameColumnIndex.Text = intUserNickNameColumnIndex.ToString();
            intNext = 5;
            intXBColumnIndex = 6;
            txtXBColumnIndex.Text = intXBColumnIndex.ToString();
            intNext = 6;
            intMZColumnIndex = 7;
            txtMZColumnIndex.Text = intMZColumnIndex.ToString();
            intNext = 7;
            intZZMMColumnIndex = 8;
            txtZZMMColumnIndex.Text = intZZMMColumnIndex.ToString();
            intNext = 8;
            intSFZHColumnIndex = 9;
            txtSFZHColumnIndex.Text = intSFZHColumnIndex.ToString();
            intNext = 9;
            intSJHColumnIndex = 10;
            txtSJHColumnIndex.Text = intSJHColumnIndex.ToString();
            intNext = 10;
            intBGDHColumnIndex = 11;
            txtBGDHColumnIndex.Text = intBGDHColumnIndex.ToString();
            intNext = 11;
            intJTDHColumnIndex = 12;
            txtJTDHColumnIndex.Text = intJTDHColumnIndex.ToString();
            intNext = 12;
            intEmailColumnIndex = 13;
            txtEmailColumnIndex.Text = intEmailColumnIndex.ToString();
            intNext = 13;
            intQQHColumnIndex = 14;
            txtQQHColumnIndex.Text = intQQHColumnIndex.ToString();
            intNext = 14;
            intLoginTimeColumnIndex = 15;
            txtLoginTimeColumnIndex.Text = intLoginTimeColumnIndex.ToString();
            intNext = 15;
            intLastLoginIPColumnIndex = 16;
            txtLastLoginIPColumnIndex.Text = intLastLoginIPColumnIndex.ToString();
            intNext = 16;
            intLastLoginDateColumnIndex = 17;
            txtLastLoginDateColumnIndex.Text = intLastLoginDateColumnIndex.ToString();
            intNext = 17;
            intLoginTimesColumnIndex = 18;
            txtLoginTimesColumnIndex.Text = intLoginTimesColumnIndex.ToString();
            intNext = 18;
            intUserStatusColumnIndex = 19;
            txtUserStatusColumnIndex.Text = intUserStatusColumnIndex.ToString();
            intNext = 19;
            // 初始化一对一对应表显示列序号
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// 自定义显示列位置
    /// </summary>
    //=====================================================================
    private void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // 主表显示列位置改变
        
            intTempColumnIndex = Convert.ToInt32(txtUserIDColumnIndex.Text);
            if(intTempColumnIndex != intUserIDColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserIDColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserIDColumnIndex - 1]);
                intUserIDColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtUserLoginNameColumnIndex.Text);
            if(intTempColumnIndex != intUserLoginNameColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserLoginNameColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserLoginNameColumnIndex - 1]);
                intUserLoginNameColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtUserGroupIDColumnIndex.Text);
            if(intTempColumnIndex != intUserGroupIDColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserGroupIDColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserGroupIDColumnIndex - 1]);
                intUserGroupIDColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSubjectIDColumnIndex.Text);
            if(intTempColumnIndex != intSubjectIDColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSubjectIDColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSubjectIDColumnIndex - 1]);
                intSubjectIDColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtUserNickNameColumnIndex.Text);
            if(intTempColumnIndex != intUserNickNameColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserNickNameColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserNickNameColumnIndex - 1]);
                intUserNickNameColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXBColumnIndex.Text);
            if(intTempColumnIndex != intXBColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXBColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXBColumnIndex - 1]);
                intXBColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtMZColumnIndex.Text);
            if(intTempColumnIndex != intMZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intMZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intMZColumnIndex - 1]);
                intMZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtZZMMColumnIndex.Text);
            if(intTempColumnIndex != intZZMMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intZZMMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intZZMMColumnIndex - 1]);
                intZZMMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSFZHColumnIndex.Text);
            if(intTempColumnIndex != intSFZHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSFZHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSFZHColumnIndex - 1]);
                intSFZHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSJHColumnIndex.Text);
            if(intTempColumnIndex != intSJHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSJHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSJHColumnIndex - 1]);
                intSJHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBGDHColumnIndex.Text);
            if(intTempColumnIndex != intBGDHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBGDHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBGDHColumnIndex - 1]);
                intBGDHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJTDHColumnIndex.Text);
            if(intTempColumnIndex != intJTDHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJTDHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJTDHColumnIndex - 1]);
                intJTDHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtEmailColumnIndex.Text);
            if(intTempColumnIndex != intEmailColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intEmailColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intEmailColumnIndex - 1]);
                intEmailColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtQQHColumnIndex.Text);
            if(intTempColumnIndex != intQQHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intQQHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intQQHColumnIndex - 1]);
                intQQHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLoginTimeColumnIndex.Text);
            if(intTempColumnIndex != intLoginTimeColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLoginTimeColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLoginTimeColumnIndex - 1]);
                intLoginTimeColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLastLoginIPColumnIndex.Text);
            if(intTempColumnIndex != intLastLoginIPColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLastLoginIPColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLastLoginIPColumnIndex - 1]);
                intLastLoginIPColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLastLoginDateColumnIndex.Text);
            if(intTempColumnIndex != intLastLoginDateColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLastLoginDateColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLastLoginDateColumnIndex - 1]);
                intLastLoginDateColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLoginTimesColumnIndex.Text);
            if(intTempColumnIndex != intLoginTimesColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLoginTimesColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLoginTimesColumnIndex - 1]);
                intLoginTimesColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtUserStatusColumnIndex.Text);
            if(intTempColumnIndex != intUserStatusColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserStatusColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserStatusColumnIndex - 1]);
                intUserStatusColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    //=====================================================================
    //  FunctionName : gvList_RowDataBound
    /// <summary>
    /// GridView列表控件RowDataBound事件
    /// </summary>
    //=====================================================================
    protected override void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // 首先判断是否是Header行
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // 设置操作状态
            LinkButton btnTemp = new LinkButton();
            string strSortFieldID = "btnSort" + (string)ViewState["SortField"];
                for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                btnTemp = (LinkButton)e.Row.Cells[i].FindControl(strSortFieldID);
                if (btnTemp != null)
                {
                    if ((Boolean)ViewState["Sort"] == false)
                    {
                        btnTemp.Text = "▼";
                        btnTemp.CommandName = "AscSort";
                    }
                    else if ((Boolean)ViewState["Sort"])
                    {
                        btnTemp.Text = "▲";
                        btnTemp.CommandName = "DescSort";
                    }
                    break;
                }
            }
        }
        // 判断是否是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string strObjectID = string.Empty;
            string strItemMenu = string.Empty;
                for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                Control hcTemp = e.Row.Cells[i].FindControl("ObjectID");
                if (hcTemp != null)
                {
                    strObjectID = ((HtmlInputHidden)hcTemp).Value;
                }
                hcTemp = e.Row.Cells[i].FindControl("itemMenu");
                if (hcTemp != null)
                {
                    strItemMenu = ((HtmlContainerControl)hcTemp).ClientID;
                }
            }
            e.Row.Attributes.Add("onmouseover", "overColor(this);");
            e.Row.Attributes.Add("onmouseout", "outColor(this);");
            
            e.Row.Attributes.Add("ondblclick", "OpenWindow('T_PM_UserInfoWebUIAdd.aspx?ObjectID={0}{1}a=v',770,600,window);return false;".FormatInvariantCulture(strObjectID,  AndChar));
        }
    }
    protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_PM_UserInfoApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_PM_UserInfoApplicationData obj = new T_PM_UserInfoApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_PM_UserInfoApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
UserLoginName.Text = GetValue(appData.UserLoginName); 
      UserGroupID.SelectedValues = GetValue(appData.UserGroupIDBatch); 
      SubjectID.SelectedValue = GetValue(appData.SubjectIDBatch); 
      UserNickName.Text = GetValue(appData.UserNickName); 
      SJH.Text = GetValue(appData.SJH); 
      Email.Text = GetValue(appData.Email); 
      UserStatus.SelectedValue = GetValue(appData.UserStatus); 
      QQH.Text = GetValue(appData.QQH); 
      XB.SelectedValue = GetValue(appData.XBBatch); 
      SFZH.Text = GetValue(appData.SFZH); 
      MZ.SelectedValue = GetValue(appData.MZBatch); 
      ZZMM.SelectedValue = GetValue(appData.ZZMMBatch); 
      BGDH.Text = GetValue(appData.BGDH); 
      JTDH.Text = GetValue(appData.JTDH); 
      
        }
        Initalize();
    }

    protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_PM_UserInfoApplicationData();
        GetQueryInputParameter();
        FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData()
        {
            BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
            UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
            BGLX = FilterReportType,
            GXBG = "0",
            XTBG = "0",
            BGCXTJ = JsonHelper.ObjectToJson(appData),
            BGCJSJ = DateTime.Now,
        };
        FilterReportApplicationData filterReportQueryApplicationData;
        if (!FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            filterReportQueryApplicationData = new FilterReportApplicationData()
            {
                BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
                UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                BGLX = FilterReportType,
                XTBG = "0",
                CurrentPage = 1,
                PageSize = 1000,
            };
            filterReportQueryApplicationData = filterReportApplicationLogic.Query(filterReportQueryApplicationData);
            if (filterReportQueryApplicationData.ResultSet.Tables.Count > 0)
            {
                foreach (DataRow item in filterReportQueryApplicationData.ResultSet.Tables[0].Rows)
                {
                    filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = GetValue(item["ObjectID"]), OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID });
                }
            }
        }
        filterReportApplicationLogic.Add(filterReportApplicationData);
        FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
        FilterReportList.Items.FindByText(FilterReportName.Text.TrimIfNotNullOrWhiteSpace()).Selected = true;
    }

    protected virtual void btnDeleteFilterReport_Click(object sender, EventArgs e)
    {
        FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData();
        if (FilterReportList.SelectedIndex <= 0 || !string.Equals(FilterReportName.Text.TrimIfNotNullOrWhiteSpace(), FilterReportList.SelectedItem.Text, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }
        filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
        if (filterReportApplicationData.XTBG != "0")
        {
            MessageContent += @"<font color=""red"">没有权限删除系统报告。</font>";
        }
        else if (!filterReportApplicationData.UserID.Equals((string) Session[ConstantsManager.SESSION_USER_ID]))
        {
            MessageContent += @"<font color=""red"">没有权限删除共享报告。</font>";
        }
        else
        {
            filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = filterReportApplicationData.ObjectID, OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID});
            FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
            FilterReportList_SelectedIndexChanged(sender, e);
        }
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
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// 得到查询用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数

            validateData = ValidateUserLoginName(UserLoginName.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateUserGroupIDBatch(UserGroupID.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserGroupIDBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSubjectIDBatch(SubjectID.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SubjectIDBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSubjectID(SubjectID.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemSubjectID.Checked)
                    {
                        appData.SubjectID = null;
                        appData.SubjectIDBatch = GetSubItem_SubjectID(SubjectID.SelectedValue) + "," + SubjectID.SelectedValue;
                    }
                }
            }
        
            validateData = ValidateUserNickName(UserNickName.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserNickName = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateXBBatch(XB.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XBBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateMZBatch(MZ.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.MZBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateZZMMBatch(ZZMM.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.ZZMMBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSFZH(SFZH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SFZH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSJH(SJH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateBGDH(BGDH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGDH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateJTDH(JTDH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.JTDH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateEmail(Email.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.Email = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateQQH(QQH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.QQH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateUserStatus(UserStatus.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserStatus = Convert.ToString(validateData.Value.ToString());
                }
            }
      

      if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
        {
          appData.QueryType = "AND";
        }
        else
        {
          appData.QueryType = ViewState["QueryType"].ToString();
        }
      }
      else
      {
        appData.SortField = "AND";
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
          appData.SortField = DEFAULT_SORT_FIELD;
        }
        else
        {
          appData.SortField = ViewState["SortField"].ToString();
        }
      }
      else
      {
        appData.SortField = DEFAULT_SORT_FIELD;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
        {
          appData.PageSize = DEFAULT_PAGE_SIZE;
        }
        else
        {
          appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
        }
      }
      else
      {
        appData.PageSize = DEFAULT_PAGE_SIZE;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
        {
          appData.CurrentPage = DEFAULT_CURRENT_PAGE;
        }
        else
        {
          appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        }
      }
      else
      {
        appData.CurrentPage = DEFAULT_CURRENT_PAGE;
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
            sbCaption.Append(@"用户信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(UserLoginName.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("用户名：");
                sbCaption.Append(UserLoginName.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(UserGroupID.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("用户组：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntity().GetValueByFixCondition("UserGroupID", UserGroupID.SelectedValues, "UserGroupName"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SubjectID.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("所属单位：");
                sbCaption.Append(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity().GetValueByFixCondition("DWBH", SubjectID.SelectedValues, "DWMC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(UserNickName.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("姓名：");
                sbCaption.Append(UserNickName.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XB.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("性别：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", XB.SelectedValues, "MC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(MZ.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("民族：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", MZ.SelectedValues, "MC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(ZZMM.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("政治面貌：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", ZZMM.SelectedValues, "MC"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SFZH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("身份证号：");
                sbCaption.Append(SFZH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SJH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("手机：");
                sbCaption.Append(SJH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BGDH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("办公电话：");
                sbCaption.Append(BGDH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(JTDH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("家庭电话：");
                sbCaption.Append(JTDH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(Email.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("Email：");
                sbCaption.Append(Email.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(QQH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("QQ：");
                sbCaption.Append(QQH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(UserStatus.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("用户状态：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", UserStatus.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            // 一对一相关表

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
}

