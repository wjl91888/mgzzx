using System;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase
    {
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            if (CurrentPageFileName.Equals(WEBUI_ADD_FILENAME, StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_ADD_FILENAME;
                if (EditMode)
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_MODIFY_ACCESS_PURVIEW_ID;
                }
                else if (ViewMode)
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_DETAIL_ACCESS_PURVIEW_ID;
                }
                else if (AddMode)
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_ADD_ACCESS_PURVIEW_ID;
                }
                else if (ImportDocMode)
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_IMPORT_PURVIEW_ID;
                }
                else if (ImportDSMode)
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_IMPORT_DS_PURVIEW_ID;
                }
                else
                {
                    Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = NO_ACCESS_PURVIEW_ID;
                }
                MessageContent = string.Empty;
            }
            if (NeedLogin)
            {
                if (!ValidateUserIsLogined())
                {
                    // 未登录处理
                    strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0016, strMessageInfo);
                    //MessageContent = strMessageInfo;
                    Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Administrator/Login.aspx");
                }
                //权限验证
                if (!DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_CURRENT_PURVIEW]))
                {
                    AccessPermission = ValidateUserPagePurview();
                    if (!AccessPermission)
                    {
                        //记录日志
                        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0004, new string[] { (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], (string)Session[ConstantsManager.SESSION_CURRENT_PURVIEW] });
                        LogLibrary.LogWrite("A03", strLogContent, null, null, null);

                        //对权限验证错误消息进行处理
                        MessageContent = strMessageInfo;
                        Session.Remove(ConstantsManager.SESSION_CURRENT_PURVIEW);
                    }
                }
            }
            // 页面中加入AJAX脚本
            String cbReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
            String callbackScript;
            callbackScript = "function CallServerById(arg, context)"
                             + "{ document.getElementById(context).innerHTML = '信息读取中...';if(document.getElementById(arg).value != null){arg = document.getElementById(arg).value}else{arg = document.getElementById(arg).innerText};" + cbReference + ";}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServerById", callbackScript, true);
            callbackScript = "function CallServer(arg, context)" + "{ " + cbReference + ";}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);
            callbackScript = "function ReceiveServerData(rValue, context){document.getElementById(context).innerHTML = rValue;}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ReceiveServerData", callbackScript, true);
            if (MainContentPlaceHolder != null)
            {
                ProcessUIControlsInit();
            }
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {
        }

        protected virtual void Page_PreRender(object sender, EventArgs e)
        {
            if (MainContentPlaceHolder != null)
            {
                if (!DataValidateManager.ValidateIsNull(MessageContent))
                {
                    var lb = (Literal)MainContentPlaceHolder.FindControl("MessageBox");
                    if (lb != null)
                    {
                        lb.Text = string.Format("<div class='messagebox'><div class='messagebody'><div>{0}</div></div></div>", MessageContent);
                        MessageContent = string.Empty;
                    }
                }
                if (!IsPostBack)
                {
                    ProcessUIControlsStatus();
                }
            }
        }

        protected virtual void ProcessUIControlsInit()
        {
        }

        protected virtual void ProcessUIControlsStatus()
        {
            if (MainContentPlaceHolder != null)
            {
                var txtObjectIDItem = (TextBox)MainContentPlaceHolder.FindControl("ObjectID");
                if (txtObjectIDItem != null)
                {
                    txtObjectIDItem.Text = ObjectID;
                }
                var btnAddItem = MainContentPlaceHolder.FindControl("btnAddItem");
                if (btnAddItem != null)
                {
                    btnAddItem.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, WEBUI_ADD_ACCESS_PURVIEW_ID);
                }
                var btnEditItem = MainContentPlaceHolder.FindControl("btnEditItem");
                if (btnEditItem != null)
                {
                    btnEditItem.Visible = !EditMode && !AddMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, WEBUI_MODIFY_ACCESS_PURVIEW_ID);
                }
                var btnStatisticItem = MainContentPlaceHolder.FindControl("btnStatisticItem");
                if (btnStatisticItem != null)
                {
                    btnStatisticItem.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, WEBUI_STATISTIC_ACCESS_PURVIEW_ID);
                }
                if (MainContentPlaceHolder.FindControl("ddlOperation") != null)
                {
                    DropDownList ddlOperation = (DropDownList)MainContentPlaceHolder.FindControl("ddlOperation");
                    var deletePurview = RICH.Common.SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_DELETE_PURVIEW_ID);
                    if (!deletePurview)
                    {
                        var item = ddlOperation.Items.FindByValue("remove");
                        if (item != null)
                        {
                            int index = ddlOperation.Items.IndexOf(item);
                            ddlOperation.Items.RemoveAt(index);
                        }
                    }
                    if (ddlOperation.Items.Count <= 1)
                    {
                        ddlOperation.Visible = false;
                        var btnOperate = MainContentPlaceHolder.FindControl("btnOperate");
                        if (btnOperate != null)
                        {
                            btnOperate.Visible = false;
                        }
                        var chkAll = MainContentPlaceHolder.FindControl("chkAll");
                        if (chkAll != null)
                        {
                            chkAll.Visible = false;
                        }
                    }
                }
                var btnImportFromDoc = MainContentPlaceHolder.FindControl("btnImportFromDoc");
                if (btnImportFromDoc != null)
                {
                    btnImportFromDoc.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_PURVIEW_ID);
                }
                var btnImportFromDataSet = MainContentPlaceHolder.FindControl("btnImportFromDataSet");
                if (btnImportFromDataSet != null)
                {
                    btnImportFromDataSet.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_DS_PURVIEW_ID);
                }
                var btnExportAllToFile = MainContentPlaceHolder.FindControl("btnExportAllToFile");
                var ddlExportFileFormat = MainContentPlaceHolder.FindControl("ddlExportFileFormat");
                if (btnExportAllToFile != null)
                {
                    btnExportAllToFile.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_EXPORTALL_PURVIEW_ID);
                }
                if (ddlExportFileFormat != null)
                {
                    ddlExportFileFormat.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_EXPORTALL_PURVIEW_ID);
                }
                if (CurrentPageFileName.Equals(WEBUI_ADD_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    if (ImportDocMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_PURVIEW_ID))
                    {
                        var addpage = MainContentPlaceHolder.FindControl("addpage");
                        if (addpage != null)
                        {
                            addpage.Visible = false;
                        }
                        var AddFromDoc = MainContentPlaceHolder.FindControl("AddFromDoc");
                        if (AddFromDoc != null)
                        {
                            AddFromDoc.Visible = true;
                        }
                        var btnInfoFromDoc = MainContentPlaceHolder.FindControl("btnInfoFromDoc");
                        if (btnInfoFromDoc != null)
                        {
                            btnInfoFromDoc.Visible = true;
                        }
                        var btnInfoFromDocBatch = MainContentPlaceHolder.FindControl("btnInfoFromDocBatch");
                        if (btnInfoFromDocBatch != null)
                        {
                            btnInfoFromDocBatch.Visible = true;
                        }
                        var btnInfoFromDS = MainContentPlaceHolder.FindControl("btnInfoFromDS");
                        if (btnInfoFromDS != null)
                        {
                            btnInfoFromDS.Visible = false;
                        }
                        var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as TextBox;
                        if (InfoFromDoc != null)
                        {
                            InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                        }
                    }
                    else if (ImportDSMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_DS_PURVIEW_ID))
                    {
                        var addpage = MainContentPlaceHolder.FindControl("addpage");
                        if (addpage != null)
                        {
                            addpage.Visible = false;
                        }
                        var AddFromDoc = MainContentPlaceHolder.FindControl("AddFromDoc");
                        if (AddFromDoc != null)
                        {
                            AddFromDoc.Visible = true;
                        }
                        var btnInfoFromDoc = MainContentPlaceHolder.FindControl("btnInfoFromDoc");
                        if (btnInfoFromDoc != null)
                        {
                            btnInfoFromDoc.Visible = false;
                        }
                        var btnInfoFromDocBatch = MainContentPlaceHolder.FindControl("btnInfoFromDocBatch");
                        if (btnInfoFromDocBatch != null)
                        {
                            btnInfoFromDocBatch.Visible = false;
                        }
                        var btnInfoFromDS = MainContentPlaceHolder.FindControl("btnInfoFromDS");
                        if (btnInfoFromDS != null)
                        {
                            btnInfoFromDS.Visible = true;
                        }
                        var btnInfoFromDocCancel = MainContentPlaceHolder.FindControl("btnInfoFromDocCancel");
                        if (btnInfoFromDocCancel != null)
                        {
                            btnInfoFromDocCancel.Visible = false;
                        }
                        var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as TextBox;
                        if (InfoFromDoc != null)
                        {
                            InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                        }
                    }
                    else
                    {
                        var addpage = MainContentPlaceHolder.FindControl("addpage");
                        if (addpage != null)
                        {
                            addpage.Visible = true;
                        }
                        var AddFromDoc = MainContentPlaceHolder.FindControl("AddFromDoc");
                        if (AddFromDoc != null)
                        {
                            AddFromDoc.Visible = false;
                        }
                    }
                }
            }
        }

        protected bool ValidateUserIsLogined()
        {
            if (DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_ID]) == false
                && DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_GROUP_ID]) == false
                && DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_NICK_NAME]) == false
                // && DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_SSDW_ID]) == false
                && DataValidateManager.ValidateIsNull(Session[ConstantsManager.SESSION_USER_LOGIN_NAME]) == false)
            {
                currentUserInfo = new T_PM_UserInfoApplicationData()
                {
                    UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                    UserGroupID = (string)Session[ConstantsManager.SESSION_USER_GROUP_ID],
                    UserLoginName = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME],
                    UserNickName = (string)Session[ConstantsManager.SESSION_USER_NICK_NAME],
                    SubjectID = (string)Session[ConstantsManager.SESSION_SSDW_ID]
                };
                return true;
            }
            if (DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_ID]) == false
                && DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_GROUP_ID]) == false
                && DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_NICK_NAME]) == false
                // && DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_SSDW_ID]) == false
                && DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME]) == false)
            {
                Session[ConstantsManager.SESSION_USER_ID] = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_ID].Value.ToString());
                Session[ConstantsManager.SESSION_USER_GROUP_ID] = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_GROUP_ID].Value.ToString());
                Session[ConstantsManager.SESSION_USER_LOGIN_NAME] = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME].Value.ToString());
                Session[ConstantsManager.SESSION_SSDW_ID] = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_SSDW_ID].Value.ToString());
                Session[ConstantsManager.SESSION_USER_NICK_NAME] = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_NICK_NAME].Value.ToString());
                currentUserInfo = new T_PM_UserInfoApplicationData()
                {
                    UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                    UserGroupID = (string)Session[ConstantsManager.SESSION_USER_GROUP_ID],
                    UserLoginName = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME],
                    UserNickName = (string)Session[ConstantsManager.SESSION_USER_NICK_NAME],
                    SubjectID = (string)Session[ConstantsManager.SESSION_SSDW_ID]
                };
                //记录日志开始
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0001, new string[] { currentUserInfo.UserLoginName });
                LogLibrary.LogWrite("A01", strLogContent, null, null, null);
                //记录日志结束
                return true;
            }
            currentUserInfo = null;
            return false;
        }

        private bool ValidateUserPagePurview()
        {
            htInputParameter = new Hashtable();
            htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
            htInputParameter.Add("UserID", Session[ConstantsManager.SESSION_USER_ID]);
            htInputParameter.Add("UserGroupID", Session[ConstantsManager.SESSION_USER_GROUP_ID]);
            htInputParameter.Add("PurviewID", Session[ConstantsManager.SESSION_CURRENT_PURVIEW]);
            htOutputParameter = SystemValidateLibrary.ValidateUserPurview(htInputParameter);
            if (htOutputParameter[ConstantsManager.MESSAGE_ID] != DBNull.Value)
            {
                //得到鉴权失败消息
                strMessageInfo = MessageManager.GetMessageInfo(htOutputParameter[ConstantsManager.MESSAGE_ID].ToString(), strMessageInfo);
                return false;
            }
            return true;
        }

        protected void FilterReportDataBind(string userID, DropDownList filterReportList, string defaultSelectValue = null)
        {
            FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
            FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData()
            {
                UserID = userID,
                BGLX = FilterReportType,
                GXBG = "0",
                XTBG = "0",
                CurrentPage = 1,
                PageSize = 1000,
            };
            filterReportApplicationData = filterReportApplicationLogic.Query(filterReportApplicationData);
            filterReportList.DataSource = filterReportApplicationData.ResultSet;
            filterReportList.DataBind();
            filterReportList.Items.Insert(0, new ListItem("选择报告", ""));
            if (!defaultSelectValue.IsNullOrWhiteSpace())
            {
                filterReportList.SelectedValue = defaultSelectValue;
            }
        }
    }
}
