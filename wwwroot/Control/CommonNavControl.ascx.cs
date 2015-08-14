using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using Telerik.Web.UI;

public partial class CommonNavControl : System.Web.UI.UserControl
{
    private Hashtable htInputParameter;
    private Hashtable htOutputParameter;
    private DataSet dsRecordInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitalPage();
    }

    
    private void InitalPage()
    {
        if (!DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_GROUP_ID]))
        {
            string[] strArrUserGroupID = ((string)Session[ConstantsManager.SESSION_USER_GROUP_ID]).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Hashtable htUserGroup = new Hashtable();
            foreach (string strUserGroupID in strArrUserGroupID)
            {
                string strUserGroupName;
                RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase t_PM_UserGroupInfoBusinessEntityBase = new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase();
                strUserGroupName = (string)t_PM_UserGroupInfoBusinessEntityBase.GetValueByFixCondition("UserGroupID", strUserGroupID, "UserGroupName");
                if (!DataValidateManager.ValidateIsNull(strUserGroupName))
                {
                    htUserGroup.Add(strUserGroupID, strUserGroupName);
                }
            }
            UserGroupList.DataSource = htUserGroup;
            UserGroupList.DataBind();
            GetMenu(Request.Cookies["LAST_MENU_USERGROUPID"] != null
                        ? Server.UrlDecode(Request.Cookies["LAST_MENU_USERGROUPID"].Value)
                        : strArrUserGroupID[0]);
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        linkDefaultIndex.HRef = ConstantsManager.DEFAULT_ADMINISTRATOR_INDEX;
    }

    public void GetMenu(string groupID)
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
        dsRecordInfo.Tables[0].DefaultView.RowFilter = "UserGroupID='{0}' AND IsPageMenu=0".FormatInvariantCulture(groupID);
        NavList.DataSource = dsRecordInfo.Tables[0].DefaultView;
        NavList.DataBind();
    }

    public DataView GetSubMenu(string groupID, string menulevelID)
    {
        dsRecordInfo.Tables[0].DefaultView.RowFilter = "UserGroupID='{0}' AND MenuLevelID='{1}' AND IsPageMenu=1".FormatInvariantCulture(groupID, menulevelID);
        return dsRecordInfo.Tables[0].DefaultView;
    }

    protected void SwitchUserGroup_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton) sender;
        if (link != null)
        {
            GetMenu(link.CommandArgument);
            Response.Cookies.Add(new HttpCookie("LAST_MENU_USERGROUPID", Server.UrlEncode(link.CommandArgument)));
        }
    }

    protected string GetAppUrl(string filePath, string fileName)
    {
        string url = "{0}/{1}".FormatInvariantCulture(filePath.Replace("Administrator", this.Page.IsMobileDevice() ? "App" : "Administrator"), fileName);
        url = url.IndexOf("?") >= 0 ? "{0}&lcode={1}".FormatInvariantCulture(url, Request["lcode"]) : "{0}?lcode={1}".FormatInvariantCulture(url, Request["lcode"]);
        return url;
    }
}