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

public partial class MasterPages_NewBasePage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            websiteName.Text = RICH.Common.ConstantsManager.WEBSITE_NAME;
            InitalPage();
            if (!DataValidateManager.ValidateIsNull(Request.Cookies["LAST_MENU_USERGROUPID"]))
            {
                ddlUserGroupID.SelectedValue = Request.Cookies["LAST_MENU_USERGROUPID"].Value;
            }
        }
    }


    private void InitalPage()
    {
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
                    ddlUserGroupID.Items.Add(new ListItem(strUserGroupName, strUserGroupID));
                }
            }
        }
        NavList.GetMenu(ddlUserGroupID.SelectedValue);
    }

    protected void ddlUserGroupID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        NavList.GetMenu(ddlUserGroupID.SelectedValue);
    }
}
