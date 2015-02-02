using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;
using RICH.Common.PM;

public partial class Administrator_A_PM_APMUserGroupList : WebUIBase
{
    #region 当前页面常量定义
    /// <summary>
    /// 当前访问页面名称
    /// </summary>
    private const string CURRENT_PAGE = "APMUserGroupList.aspx";

    /// <summary>
    /// 当前访问页面权限编号
    /// </summary>
    private const string CURRENT_PAGE_ACCESS_PURVIEW_ID = "APM11";

    /// <summary>
    /// 课程删除权限编号
    /// </summary>
    private const string DEL_PURVIEW_ID = "APM111";

    /// <summary>
    /// 默认排序方式
    /// </summary>
    private const string DEFAULT_SORT = "false";

    /// <summary>
    /// 默认排序字段
    /// </summary>
    private const string DEFAULT_SORT_FIELD = "UserGroupID";

    /// <summary>
    /// 默认每页显示记录条数
    /// </summary>
    private const string DEFAULT_PAGE_SIZE = "10";

    /// <summary>
    /// 默认当前页数
    /// </summary>
    private const string DEFAULT_CURRENT_PAGE = "1";


    #endregion

    #region 当前页面变量定义
    /// <summary>
    /// 输入参数HashTable
    /// </summary>
    private Hashtable htInputParameter;

    /// <summary>
    /// 输出参数HashTable
    /// </summary>
    private Hashtable htOutputParameter;

    /// <summary>
    /// 用来获取返回查询结果或者作为批量数据的输入的DataSet
    /// </summary>
    private DataSet dsRecordInfo;

    private Int32 intRecordCount;

    private string strMessageInfo = string.Empty;

    private string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
    #endregion

    public override string TableName
    {
        get { return null; }
    }

    public override string PurviewPrefix
    {
        get { return null; }
    }

    public override string FilterReportType
    {
        get { return null; }
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //基本SESSION赋值
            Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + CURRENT_PAGE;
            CurrentAccessPermission = CURRENT_PAGE_ACCESS_PURVIEW_ID;
            ViewState["CurrentPage"] = 1;
            QueryRecordInfo();
            ViewState["RecordCount"] = intRecordCount;
            ViewState["PageSize"] = int.Parse(DEFAULT_PAGE_SIZE);
            ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
            InitPageInfo();

        }
        else
        {
            if (Request.Form["__EVENTTARGET"].ToString().IndexOf("btnDel") >= 0)
            {
                Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = DEL_PURVIEW_ID;
            }
        }
        base.Page_Load(sender, e);
    }

    #region QueryRecordInfo
    //***************************************************** 
    //  Function Name:  QueryRecordInfo
    /// <summary>
    /// 根据条件查询记录
    /// </summary>
    //  Writer:         王景璐
    //  Create Date:    2007/04/09
    //******************************************************
    private void QueryRecordInfo()
    {
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");

        if (Request["Sort"] == "" || Request["Sort"] == null)
        {
            htInputParameter.Add("Sort", DEFAULT_SORT);
        }
        else
        {
            htInputParameter.Add("Sort", Request["Sort"]);
        }
        if (Request["SortField"] == "" || Request["SortField"] == null)
        {
            htInputParameter.Add("SortField", DEFAULT_SORT_FIELD);
        }
        else
        {
            htInputParameter.Add("SortField", Request["SortField"]);
        }
        if (DataValidateManager.ValidateIsNull(ViewState["PageSize"]) == true)
        {
            htInputParameter.Add("PageSize", DEFAULT_PAGE_SIZE);
        }
        else
        {
            htInputParameter.Add("PageSize", ViewState["PageSize"].ToString());
        }
        if (DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]) == true)
        {
            htInputParameter.Add("CurrentPage", DEFAULT_CURRENT_PAGE);
        }
        else
        {
            htInputParameter.Add("CurrentPage", ViewState["CurrentPage"].ToString());
        }

        if (DataValidateManager.ValidateIsNull(ViewState["ObjectID"]) == false)
        {
            htInputParameter.Add("ObjectID", ViewState["ObjectID"].ToString());
        }
        if (DataValidateManager.ValidateIsNull(ViewState["UserGroupID"]) == false)
        {
            htInputParameter.Add("UserGroupID", ViewState["UserGroupID"].ToString());
        }
        if (DataValidateManager.ValidateIsNull(ViewState["UserGroupName"]) == false)
        {
            htInputParameter.Add("UserGroupName", ViewState["UserGroupName"].ToString());
        }
        if (DataValidateManager.ValidateIsNull(ViewState["UserGroupContent"]) == false)
        {
            htInputParameter.Add("UserGroupContent", ViewState["UserGroupContent"].ToString());
        }
        if (DataValidateManager.ValidateIsNull(ViewState["UserGroupRemark"]) == false)
        {
            htInputParameter.Add("UserGroupRemark", ViewState["UserGroupRemark"].ToString());
        }

        if (ValidateQueryInputParameter())
        {
            UserGroupLibrary instanceUserGroupLibrary = new UserGroupLibrary();
            htOutputParameter = instanceUserGroupLibrary.SelectRecordInfo(htInputParameter);
            dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];
            intRecordCount = (int)htOutputParameter[ConstantsManager.RECORD_COUNT];
            gvRecordList.DataSource = dsRecordInfo;
            gvRecordList.DataBind();
        }
        else
        {
            //对错误消息进行处理
            MessageContent = strMessageInfo;
        }
    }
    #endregion

    private Boolean ValidateQueryInputParameter()
    {

        Boolean boolReturn = true;
        if (DataValidateManager.ValidateIsNull(htInputParameter["UserGroupID"]) == false)
        {
            if (DataValidateManager.ValidateStringLengthRange(htInputParameter["UserGroupID"], 0, 50) == false)
            {
                strMessageParam[0] = "用户组编号";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                boolReturn = false;
            }
        }
        else
        {
            htInputParameter.Remove("UserGroupID");
        }
        //UserGroupName输入检验
        if (DataValidateManager.ValidateIsNull(htInputParameter["UserGroupName"]) == false)
        {
            if (DataValidateManager.ValidateStringLengthRange(htInputParameter["UserGroupName"], 0, 50) == false)
            {
                strMessageParam[0] = "用户组名称";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                boolReturn = false;
            }
        }
        else
        {
            htInputParameter.Remove("UserGroupName");
        }
        //UserGroupContent输入检验
        if (DataValidateManager.ValidateIsNull(htInputParameter["UserGroupContent"]) == false)
        {
            if (DataValidateManager.ValidateStringLengthRange(htInputParameter["UserGroupContent"], 0, 50) == false)
            {
                strMessageParam[0] = "用户组内容";
                strMessageParam[1] = "0";
                strMessageParam[2] = "50";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                boolReturn = false;
            }
        }
        else
        {
            htInputParameter.Remove("UserGroupContent");
        }
        //UserGroupRemark输入检验
        if (DataValidateManager.ValidateIsNull(htInputParameter["UserGroupRemark"]) == false)
        {
            if (DataValidateManager.ValidateStringLengthRange(htInputParameter["UserGroupRemark"], 0, 255) == false)
            {
                strMessageParam[0] = "用户组备注";
                strMessageParam[1] = "0";
                strMessageParam[2] = "50";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                boolReturn = false;
            }
        }
        else
        {
            htInputParameter.Remove("UserGroupRemark");
        }
        return boolReturn;
    }

    protected void gvRecordList_DataBinding(object sender, EventArgs e)
    {

    }

    protected void gvRecordList_DataBound(object sender, EventArgs e)
    {

    }

    protected void gvRecordList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //首先判断是否是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //当鼠标停留时更改背景色
            e.Row.Attributes.Add("onmouseover", "overColor(this);");
            //当鼠标移开时还原背景色
            e.Row.Attributes.Add("onmouseout", "outColor(this);");
        }
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        LinkButton btnTemp = new LinkButton();
        btnTemp = (LinkButton)sender;
        htInputParameter = new Hashtable();
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");

        htInputParameter.Add("ObjectID", btnTemp.CommandArgument.ToString());
        UserGroupLibrary instanceUserGroupLibrary = new UserGroupLibrary();
        instanceUserGroupLibrary.DeleteRecordInfo(htInputParameter);

        //记录日志开始
        string strLogTypeID = "A02";
        strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
        strMessageParam[1] = "用户组信息";
        strMessageParam[2] = (string)htInputParameter["ObjectID"];
        strMessageParam[3] = "删除";
        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
        LogLibrary.LogWrite(strLogTypeID, strLogContent, (string)htInputParameter["ObjectID"], null, null);
        //记录日志结束

        QueryRecordInfo();
    }

    #region InitPageInfo
    private void InitPageInfo()
    {
        try
        {
            if ((int)ViewState["PageCount"] == 1)
            {
                btnFirstPage.Visible = false;
                btnPrePage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"])
            {
                btnFirstPage.Visible = true;
                btnPrePage.Visible = true;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            else if ((int)ViewState["PageCount"] == 0)
            {
                btnFirstPage.Visible = false;
                btnPrePage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            else if ((int)ViewState["CurrentPage"] == 0)
            {
                btnFirstPage.Visible = false;
                btnPrePage.Visible = false;
                btnNextPage.Visible = false;
                btnLastPage.Visible = false;
            }
            else if ((int)ViewState["CurrentPage"] == 1)
            {
                btnFirstPage.Visible = false;
                btnPrePage.Visible = false;
                btnNextPage.Visible = true;
                btnLastPage.Visible = true;
            }
            else if ((int)ViewState["CurrentPage"] == 2)
            {
                btnFirstPage.Visible = false;
                btnPrePage.Visible = true;
                btnNextPage.Visible = true;
                btnLastPage.Visible = true;
            }

            else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"] - 1)
            {
                btnFirstPage.Visible = true;
                btnPrePage.Visible = true;
                btnNextPage.Visible = true;
                btnLastPage.Visible = false;
            }
            else
            {
                btnFirstPage.Visible = true;
                btnPrePage.Visible = true;
                btnNextPage.Visible = true;
                btnLastPage.Visible = true;
            }
            ddlPageSize.Items.Clear();
            for (int i = 1; i <= (int)ViewState["PageCount"]; i++)
            {
                ddlPageSize.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlPageSize.SelectedValue = ViewState["CurrentPage"].ToString();
            lblPageInfo.Text = "每页{0}条记录，当前在<b><span class=tx>{1}</span>/{2}</b>，共<b><span id=recordcount>{3}</span></b>条记录。";
            lblPageInfo.Text = string.Format(lblPageInfo.Text, ViewState["PageSize"], ViewState["CurrentPage"], ViewState["PageCount"], ViewState["RecordCount"]);
        }
        catch (Exception)
        {

            throw;
        }


    }
    #endregion

    protected void btnFirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = 1;
        ViewState["PageSize"] = int.Parse(DEFAULT_PAGE_SIZE);
        QueryRecordInfo();
        ViewState["RecordCount"] = intRecordCount;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }

    protected void btnPrePage_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] - 1;
        QueryRecordInfo();
        ViewState["RecordCount"] = intRecordCount;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }

    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] + 1;
        QueryRecordInfo();
        ViewState["RecordCount"] = intRecordCount;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }

    protected void btnLastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = ViewState["PageCount"];
        QueryRecordInfo();
        ViewState["RecordCount"] = intRecordCount;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CurrentPage"] = int.Parse(ddlPageSize.SelectedValue);
        QueryRecordInfo();
        ViewState["RecordCount"] = intRecordCount;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }
}
