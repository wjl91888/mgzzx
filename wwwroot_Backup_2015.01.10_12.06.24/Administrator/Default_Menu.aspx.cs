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

    public override string FilterReportType
    {
        get { throw new NotImplementedException(); }
    }

    public override string CURRENT_PATH
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_ADD_FILENAME
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_SEARCH_FILENAME
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_DETAIL_FILENAME
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_STATISTIC_FILENAME
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_ADD_ACCESS_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string OPERATION_DELETE_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string OPERATION_EXPORTALL_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
    }

    public override string OPERATION_IMPORT_PURVIEW_ID
    {
        get { throw new NotImplementedException(); }
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
            lblMenu.Text = GetMenu(ddlUserGroupID.SelectedValue);
        }
        else
        {
            lblMenu.Text = GetMenu(ddlUserGroupID.SelectedValue);
        }
    }

    private void InitalPage()
    {
        linkDefaultIndex.HRef = RICH.Common.ConstantsManager.DEFAULT_ADMINISTRATOR_INDEX;
        if (!RICH.Common.DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_GROUP_ID]))
        {
            string[] strArrUserGroupID = ((string)Session[ConstantsManager.SESSION_USER_GROUP_ID]).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string strUserGroupID in strArrUserGroupID)
            {
                string strUserGroupName;
                RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase t_PM_UserGroupInfoBusinessEntityBase = new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntityBase();
                strUserGroupName = (string)t_PM_UserGroupInfoBusinessEntityBase.GetValueByFixCondition("UserGroupID", strUserGroupID, "UserGroupName");
                if (!RICH.Common.DataValidateManager.ValidateIsNull(strUserGroupName))
                {
                    ddlUserGroupID.Items.Add(new RadComboBoxItem(strUserGroupName, strUserGroupID));
                }
            }
        }
    }

    private string GetMenu(string strUserGroupID)
    {
        //定义权限类型名临时变量
        string strPurviewTypeName;
        int i;
        StringBuilder sbReturn = new StringBuilder(string.Empty);
        sbReturn.Append("<ul><li><ul>");
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserID", Session["UserID"]);
        htInputParameter.Add("IsPageMenu", "true");
        htInputParameter.Add("PurviewPRI", 1);

        UserPurviewLibrary instanceUserPurviewLibrary = new UserPurviewLibrary();
        htOutputParameter = instanceUserPurviewLibrary.GetUserPurviewInfo(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];
        strPurviewTypeName = "";
        for (i = 0; i < dsRecordInfo.Tables[0].Rows.Count; i++)
        {
            if (!DataValidateManager.ValidateIsNull(dsRecordInfo.Tables[0].Rows[i]["UserID"]) ||
                !DataValidateManager.ValidateIsNull(dsRecordInfo.Tables[0].Rows[i]["UserGroupID"]))
            {
                if (DataValidateManager.ValidateIsNull(strUserGroupID))
                {
                    if (dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString() != strPurviewTypeName)
                    {
                        sbReturn.Append("</ul></li></ul>");
                        sbReturn.Append("<ul class=\"leftframetable\" style=\"width:95%;text-align:left;border-width:1px;margin-left:2px;margin-bottom:3px;\">");
                        sbReturn.Append("<li onmouseup=\"opensubmenu('lblMenu', 'li', '" + "menu_" + dsRecordInfo.Tables[0].Rows[i]["PurviewTypeID"].ToString() + "');\" class=\"titledaohang\" style=\"vertical-align:top;height:16px;margin-left:4px;padding:4px 0px 4px 0px;cursor: pointer;width:98%;\">");
                        sbReturn.Append("<img height=\"17\" src=\"../App_Themes/Themes/Image/sub_sys.gif\"  width=\"15\">&nbsp;&nbsp;");
                        sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewTypeContent"].ToString());
                        sbReturn.Append("</li>");
                        sbReturn.Append("<li id=\"" + "menu_" + dsRecordInfo.Tables[0].Rows[i]["PurviewTypeID"].ToString() + "\"  class=\"leftframetable\" style=\"display: none;width:95%;text-align:left;border-width:0px\">");
                        sbReturn.Append("<ul>");
                        strPurviewTypeName = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                    }
                    string strFilename = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + (string)dsRecordInfo.Tables[0].Rows[i]["PageFilePath"] + "/" + (string)dsRecordInfo.Tables[0].Rows[i]["PageFileName"];
                    sbReturn.Append("<li class=\"lefttop\"  style=\"margin-left:4px;width:95%;text-align:left;border-width:0px;vertical-align:top;\">");
                    sbReturn.Append("<img src=\"../App_Themes/Themes/Image/folderclosed.gif\">&nbsp;");
                    sbReturn.Append("<a href=\"" + strFilename + "\" target=\"ContentFrame\">");
                    sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewContent"].ToString());
                    sbReturn.Append("</a>");
                    //sbReturn.Append("<a href=\"#\" style=\"cursor:pointer;text-decoration:none;\" onclick=\"OpenWindow('" + strFilename + "',770,600,window);\">");
                    //sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewContent"].ToString());
                    //sbReturn.Append("</a>");
                    sbReturn.Append("</li>");
                }
                else if (dsRecordInfo.Tables[0].Rows[i]["UserGroupID"] != DBNull.Value)
                {
                    if(strUserGroupID == (string)dsRecordInfo.Tables[0].Rows[i]["UserGroupID"])
                    {
                        if (dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString() != strPurviewTypeName)
                        {
                            sbReturn.Append("</ul></li></ul>");
                            sbReturn.Append("<ul class=\"leftframetable\" style=\"width:95%;text-align:left;border-width:1px;margin-left:2px;margin-bottom:3px;\">");
                            sbReturn.Append("<li onmouseup=\"opensubmenu('lblMenu', 'li', '" + "menu_" + dsRecordInfo.Tables[0].Rows[i]["PurviewTypeID"].ToString() + "');\" class=\"titledaohang\" style=\"vertical-align:top;height:16px;margin-left:4px;padding:4px 0px 4px 0px;cursor: pointer;width:98%;\">");
                            sbReturn.Append("<img height=\"17\" src=\"../App_Themes/Themes/Image/sub_sys.gif\"  width=\"15\">&nbsp;&nbsp;");
                            sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewTypeContent"].ToString());
                            sbReturn.Append("</li>");
                            sbReturn.Append("<li id=\"" + "menu_" + dsRecordInfo.Tables[0].Rows[i]["PurviewTypeID"].ToString() + "\"  class=\"leftframetable\" style=\"display: none;width:95%;text-align:left;border-width:0px\">");
                            sbReturn.Append("<ul>");
                            strPurviewTypeName = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                        }
                        string strFilename = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + (string)dsRecordInfo.Tables[0].Rows[i]["PageFilePath"] + "/" + (string)dsRecordInfo.Tables[0].Rows[i]["PageFileName"];
                        sbReturn.Append("<li class=\"lefttop\"  style=\"margin-left:4px;width:95%;text-align:left;border-width:0px;vertical-align:top;\">");
                        sbReturn.Append("<img src=\"../App_Themes/Themes/Image/folderclosed.gif\">&nbsp;");
                        sbReturn.Append("<a href=\"" + strFilename + "\" target=\"ContentFrame\">");
                        sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewContent"].ToString());
                        sbReturn.Append("</a>");
                        //sbReturn.Append("<a href=\"#\" style=\"cursor:pointer;text-decoration:none;\" onclick=\"OpenWindow('" + strFilename + "',770,600,window);\">");
                        //sbReturn.Append(dsRecordInfo.Tables[0].Rows[i]["PurviewContent"].ToString());
                        //sbReturn.Append("</a>");
                        sbReturn.Append("</li>");
                    }
                }
            }
        }
        sbReturn.Append("</ul></li></ul>");
        return sbReturn.ToString();
    }

    protected void ddlUserGroupID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        lblMenu.Text = GetMenu(ddlUserGroupID.SelectedValue);
    }
}
