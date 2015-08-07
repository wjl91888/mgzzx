using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.PM;
using Telerik.Web.UI;

public partial class MasterPages_AppBasePage111 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            websiteName.Text = RICH.Common.ConstantsManager.WEBSITE_NAME;
            InitalPage();
            if (Request.Cookies["LAST_MENU_USERGROUPID"] != null)
            {
                var item = ddlUserGroupID.Items.FindItemByValue(Server.UrlDecode(Request.Cookies["LAST_MENU_USERGROUPID"].Value));
                if (item != null)
                {
                    item.Selected = true;
                }
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
        var htInputParameter = new Hashtable();
        var dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserID", Session["UserID"]);
        htInputParameter.Add("IsPageMenu", "true");
        htInputParameter.Add("PurviewPRI", 1);

        UserPurviewLibrary instanceUserPurviewLibrary = new UserPurviewLibrary();
        var htOutputParameter = instanceUserPurviewLibrary.GetUserPurviewInfoForMenu(htInputParameter);
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
        Response.Cookies.Add(new HttpCookie("LAST_MENU_USERGROUPID", Server.UrlEncode(ddlUserGroupID.SelectedValue)));
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
