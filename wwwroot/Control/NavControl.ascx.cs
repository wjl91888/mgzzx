using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using Telerik.Web.UI;

public partial class NavControl : System.Web.UI.UserControl
{
    private Hashtable htInputParameter;
    private Hashtable htOutputParameter;
    private DataSet dsRecordInfo;

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

}
