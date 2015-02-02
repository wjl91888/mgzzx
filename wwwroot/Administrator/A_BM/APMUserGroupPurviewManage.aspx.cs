using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using RICH.Common.Base.WebUI;

public partial class APMUserGroupPurviewManage : WebUIBase
{
    /// <summary>
    /// 当前页面所在路径
    /// </summary>
    public override string CURRENT_PATH 
    {
        get { return "Administrator/A_BM"; }
    }

    /// <summary>
    /// 当前访问页面名称
    /// </summary>
    private const string CURRENT_PAGE = "APMUserGroupPurviewManage.aspx";

    /// <summary>
    /// 访问完毕跳转页面名称
    /// </summary>
    private const string REDIRECT_PAGE = "APMUserGroupList.aspx";

    /// <summary>
    /// 当前访问页面权限编号
    /// </summary>
    private const string CURRENT_PAGE_ACCESS_PURVIEW_ID = "APM16";

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

    /// <summary>
    /// 用来存储消息信息
    /// </summary>
    private string strMessageInfo = string.Empty;

    /// <summary>
    /// 用来存储消息信息的参数
    /// </summary>
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

            if (Request.QueryString["UserGroupID"] != null
                && Request.QueryString["UserGroupID"] != ""
                && Request.QueryString["UserGroupID"] != string.Empty)
            {
                lblUserGroupID.Text = Request.QueryString["UserGroupID"];
                InitialControl();
            }
        }
        InitialPage();
        base.Page_Load(sender, e);
    }

    private void InitialControl()
    {
        rblPurviewPRI.Items.Add(new ListItem("全部权限", "0"));
        rblPurviewPRI.Items.Add(new ListItem("管理后台权限", "1"));
        rblPurviewPRI.Items.Add(new ListItem("用户前台权限", "2"));
        rblPurviewPRI.SelectedValue = "0";
    }
    private void InitialPage()
    {
        //定义权限类型名临时变量
        string strPurviewTypeName;
        int intCount;
        int i;
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);

        UserGroupLibrary instanceUserGroupLibrary = new UserGroupLibrary();
        htOutputParameter = instanceUserGroupLibrary.SelectRecordInfo(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];

        lblUserGroupName.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupName"].ToString();
        lblUserGroupID.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupID"].ToString();
        lblUserGroupContent.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupContent"].ToString();

        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);
        htInputParameter.Add("PurviewPRI", int.Parse(rblPurviewPRI.SelectedValue));
        UserGroupPurviewLibrary instanceUserGroupPurviewLibrary = new UserGroupPurviewLibrary();
        htOutputParameter = instanceUserGroupPurviewLibrary.GetUserGroupPurviewInfo(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];
        strPurviewTypeName = "";
        for (i = 0; i < dsRecordInfo.Tables[0].Rows.Count; i++)
        {
            TableRow trTemp = new TableRow();
            intCount = i;
            for (int j = i; j < intCount + 4 && j < dsRecordInfo.Tables[0].Rows.Count; j++)
            {
                i = j;
                if (dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString() != strPurviewTypeName)
                {
                    TableRow trTempTitle = new TableRow();
                    TableCell tcTempTitle = new TableCell();
                    Label lblTemp = new Label();
                    lblTemp.Text = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                    tcTempTitle.Controls.Add(lblTemp);
                    tcTempTitle.ColumnSpan = 4;
                    tcTempTitle.CssClass = "xingmu";
                    trTempTitle.Cells.Add(tcTempTitle);
                    tbPurviewInfo.Rows.Add(trTemp);
                    tbPurviewInfo.Rows.Add(trTempTitle);
                    strPurviewTypeName = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                    trTemp = new TableRow();
                }
                TableCell tcTemp = new TableCell();
                CheckBox chkTemp = new CheckBox();
                chkTemp.ID = dsRecordInfo.Tables[0].Rows[i]["PurviewID"].ToString();
                chkTemp.Text = dsRecordInfo.Tables[0].Rows[i]["PurviewName"].ToString();
                if (DataValidateManager.ValidateIsNull(dsRecordInfo.Tables[0].Rows[i]["IsPageMenu"]) == false)
                {
                    if ((bool)dsRecordInfo.Tables[0].Rows[i]["IsPageMenu"] == true)
                    {
                        chkTemp.Text = chkTemp.Text + "(菜单项)";
                    }
                }
                chkTemp.InputAttributes.Add("value", dsRecordInfo.Tables[0].Rows[i]["PurviewID"].ToString());
                if (dsRecordInfo.Tables[0].Rows[i]["UserGroupID"] == DBNull.Value
                    || dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() == ""
                    || dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() == string.Empty)
                {
                    chkTemp.Checked = false;
                }
                else if (dsRecordInfo.Tables[0].Rows[i]["UserGroupID"] != DBNull.Value
                         && dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() != ""
                         && dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() != string.Empty)
                {
                    chkTemp.Checked = true;
                }
                tcTemp.Controls.Add(chkTemp);
                tcTemp.CssClass = "hback";
                trTemp.Cells.Add(tcTemp);
            }
            tbPurviewInfo.Rows.Add(trTemp);
        }
    }

    protected void btnSetPurview_Click(object sender, EventArgs e)
    {
        string strPurview, strDeletePurview;
        CheckBox chkTemp = new CheckBox();
        strPurview = "";
        strDeletePurview = "";
        foreach (TableRow trTemp in FindControl("tbPurviewInfo").Controls)
        {
            foreach (TableCell tcTemp in trTemp.Controls)
            {
                foreach (Object ctlTemp in tcTemp.Controls)
                {
                    if (ctlTemp.GetType().ToString() == typeof(CheckBox).ToString())
                    {
                        chkTemp = (CheckBox)ctlTemp;
                        if (chkTemp.Checked == true)
                        {
                            strPurview = strPurview + "," + chkTemp.ID.ToString();
                        }
                        else
                        {
                            strDeletePurview = strDeletePurview + "," + chkTemp.ID.ToString();
                        }
                    }
                }
            }
        }
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);
        htInputParameter.Add("UserGroupPurview", strPurview);
        htInputParameter.Add("UserGroupDeletePurview", strDeletePurview);
        UserGroupPurviewLibrary instanceUserGroupPurviewLibrary = new UserGroupPurviewLibrary();
        instanceUserGroupPurviewLibrary.SetUserGroupPurviewInfo(htInputParameter);

        //对成功消息进行处理
        strMessageParam[0] = "用户组权限";
        strMessageParam[1] = "修改";
        strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
        //MessageContent = strMessageInfo;
        Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + REDIRECT_PAGE;

        //记录日志开始
        string strLogTypeID = "A02";
        strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
        strMessageParam[1] = "用户组权限";
        strMessageParam[2] = lblUserGroupID.Text;
        strMessageParam[3] = "修改";
        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
        LogLibrary.LogWrite(strLogTypeID, strLogContent, (string)htInputParameter["ObjectID"], null, null);
        //记录日志结束

        //成功后页面跳转
        Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Administrator/A_BM/APMUserGroupList.aspx");
        Response.End();
    }


    protected void rblPurviewPRI_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
