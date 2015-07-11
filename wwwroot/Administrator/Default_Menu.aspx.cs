using System;
using System.Data;
using System.Text;
using System.Collections;
using RICH.Common;
using RICH.Common.Base.WebUI;
using RICH.Common.PM;
using Telerik.Web.UI;

public partial class Administrator_Default_Menu : WebUIBase
{
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
        base.Page_Load(sender, e);
        if (!IsPostBack)
        {
            websiteName.Text = RICH.Common.ConstantsManager.WEBSITE_NAME;
            InitalPage();
            if (!DataValidateManager.ValidateIsNull(Request.Cookies["LAST_MENU_USERGROUPID"]))
            {
                ddlUserGroupID.SelectedValue = Request.Cookies["LAST_MENU_USERGROUPID"].Value;
            } 
        }
        GetMenu();
    }

    private void InitalPage()
    {
        linkDefaultIndex.HRef = ConstantsManager.DEFAULT_ADMINISTRATOR_INDEX;
        if (!DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_GROUP_ID]))
        {
            string[] strArrUserGroupID = ((string)Session[ConstantsManager.SESSION_USER_GROUP_ID]).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string strUserGroupID in strArrUserGroupID)
            {
                string strUserGroupName;
                RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase t_PM_UserGroupInfoBusinessEntityBase = new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase();
                strUserGroupName = (string)t_PM_UserGroupInfoBusinessEntityBase.GetValueByFixCondition("UserGroupID", strUserGroupID, "UserGroupName");
                if (!DataValidateManager.ValidateIsNull(strUserGroupName))
                {
                    ddlUserGroupID.Items.Add(new RadComboBoxItem(strUserGroupName, strUserGroupID));
                }
            }
        }
    }

    private void GetMenu()
    {
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserID", Session["UserID"]);
        htInputParameter.Add("IsPageMenu", "true");
        htInputParameter.Add("PurviewPRI", 1);

        UserPurviewLibrary instanceUserPurviewLibrary = new UserPurviewLibrary();
        htOutputParameter = instanceUserPurviewLibrary.GetUserPurviewInfoForMenu(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];

        rtvMenu.DataNavigateUrlField = "PageFileName";
        rtvMenu.DataFieldParentID = "MenuLevelID";
        rtvMenu.DataFieldID = "PurviewID";
        rtvMenu.DataTextField = "PurviewName";
        rtvMenu.DataValueField = "PurviewID";
        dsRecordInfo.Tables[0].DefaultView.RowFilter = "UserGroupID='{0}'".FormatInvariantCulture(ddlUserGroupID.SelectedValue);
        rtvMenu.DataSource = dsRecordInfo.Tables[0].DefaultView;
        rtvMenu.DataBind();
        rtvMenu.ExpandAllNodes();
    }

    protected void ddlUserGroupID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        GetMenu();
    }

    protected void rtvMenu_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        var node = e.Node;
        if (!node.NavigateUrl.IsHtmlNullOrWiteSpace())
        {
            var dr = (DataRowView)node.DataItem;
            node.Target = "ContentFrame";
            node.NavigateUrl = "..{0}/{1}".FormatInvariantCulture(dr["PageFilePath"], dr["PageFileName"]);
        }
    }
}
