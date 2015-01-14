using System;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase
    {
        protected virtual void ExportToFile() { }

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
                    var deletePurview = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_DELETE_PURVIEW_ID);
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
                    var ControlContainer = MainContentPlaceHolder.FindControl("ControlContainer");
                    var ImportControlContainer = MainContentPlaceHolder.FindControl("ImportControlContainer");
                    var btnInfoFromDoc = MainContentPlaceHolder.FindControl("btnInfoFromDoc");
                    var btnInfoFromDocBatch = MainContentPlaceHolder.FindControl("btnInfoFromDocBatch");
                    var btnInfoFromDocCancel = MainContentPlaceHolder.FindControl("btnInfoFromDocCancel");
                    var btnInfoFromDS = MainContentPlaceHolder.FindControl("btnInfoFromDS");
                    var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as TextBox;
                    var btnCopyItem = MainContentPlaceHolder.FindControl("btnCopyItem");
                    var btnAddConfirm = MainContentPlaceHolder.FindControl("btnAddConfirm");
                    if (ImportDocMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_PURVIEW_ID))
                    {
                        if (ControlContainer != null)
                        {
                            ControlContainer.Visible = false;
                        }
                        if (ImportControlContainer != null)
                        {
                            ImportControlContainer.Visible = AccessPermission;
                        }
                        if (btnInfoFromDoc != null)
                        {
                            btnInfoFromDoc.Visible = true;
                        }
                        if (btnInfoFromDocBatch != null)
                        {
                            btnInfoFromDocBatch.Visible = AccessPermission;
                        }
                        if (btnInfoFromDS != null)
                        {
                            btnInfoFromDS.Visible = false;
                        }
                        if (InfoFromDoc != null)
                        {
                            InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                        }
                        if (btnEditItem != null)
                        {
                            btnEditItem.Visible = false;
                        }
                        if (btnCopyItem != null)
                        {
                            btnCopyItem.Visible = false;
                        }
                        if (btnAddConfirm != null)
                        {
                            btnAddConfirm.Visible = false;
                        }
                        if (btnImportFromDoc != null)
                        {
                            btnImportFromDoc.Visible = false;
                        }
                    }
                    else if (ImportDSMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_DS_PURVIEW_ID))
                    {
                        if (ControlContainer != null)
                        {
                            ControlContainer.Visible = false;
                        }
                        if (ImportControlContainer != null)
                        {
                            ImportControlContainer.Visible = AccessPermission;
                        }
                        if (btnInfoFromDoc != null)
                        {
                            btnInfoFromDoc.Visible = false;
                        }
                        if (btnInfoFromDocBatch != null)
                        {
                            btnInfoFromDocBatch.Visible = false;
                        }
                        if (btnInfoFromDS != null)
                        {
                            btnInfoFromDS.Visible = AccessPermission;
                        }
                        if (btnInfoFromDocCancel != null)
                        {
                            btnInfoFromDocCancel.Visible = false;
                        }
                        if (InfoFromDoc != null)
                        {
                            InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                        }
                        if (btnEditItem != null)
                        {
                            btnEditItem.Visible = false;
                        }
                        if (btnCopyItem != null)
                        {
                            btnCopyItem.Visible = false;
                        }
                        if (btnAddConfirm != null)
                        {
                            btnAddConfirm.Visible = false;
                        }
                        if (btnImportFromDoc != null)
                        {
                            btnImportFromDoc.Visible = false;
                        }
                    }
                    else
                    {
                        if (ControlContainer != null)
                        {
                            ControlContainer.Visible = AccessPermission;
                        }
                        if (btnCopyItem != null)
                        {
                            btnCopyItem.Visible = ViewMode && AccessPermission;
                        }
                        if (btnAddConfirm != null)
                        {
                            btnAddConfirm.Visible = (CopyMode || AddMode || EditMode) && AccessPermission;
                        }
                        if (btnEditItem != null)
                        {
                            btnEditItem.Visible = ViewMode && AccessPermission;
                        }
                        if (ImportControlContainer != null)
                        {
                            ImportControlContainer.Visible = false;
                        }
                        if (btnInfoFromDoc != null)
                        {
                            btnInfoFromDoc.Visible = false;
                        }
                        if (btnInfoFromDocBatch != null)
                        {
                            btnInfoFromDocBatch.Visible = false;
                        }
                        if (btnInfoFromDS != null)
                        {
                            btnInfoFromDS.Visible = false;
                        }
                        if (btnInfoFromDocCancel != null)
                        {
                            btnInfoFromDocCancel.Visible = false;
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

        protected virtual void SetMoreSearchItemDisplay(bool isDisplay = false) { }

        protected virtual void CustomColumnIndex() { }

        protected virtual void Initalize() { }

        protected virtual void InitPageInfo()
        {
            if (MainContentPlaceHolder != null)
            {
                var btnFirstPage = MainContentPlaceHolder.FindControl("btnFirstPage") as Button;
                var btnPrePage = MainContentPlaceHolder.FindControl("btnPrePage") as Button;
                var btnNextPage = MainContentPlaceHolder.FindControl("btnNextPage") as Button;
                var btnLastPage = MainContentPlaceHolder.FindControl("btnLastPage") as Button;
                var ddlPageCount = MainContentPlaceHolder.FindControl("ddlPageCount") as DropDownList;
                var ddlPageSize = MainContentPlaceHolder.FindControl("ddlPageSize") as DropDownList;
                var lblPageInfo = MainContentPlaceHolder.FindControl("lblPageInfo") as Label;
                if (btnFirstPage != null && btnPrePage != null && btnNextPage != null && btnLastPage != null
                    && ddlPageCount != null && ddlPageSize != null && lblPageInfo != null)
                {
                    if ((int)ViewState["PageCount"] == 1 || (int)ViewState["PageCount"] == 0 || (int)ViewState["CurrentPage"] == 0)
                    {
                        btnFirstPage.Enabled = btnPrePage.Enabled = btnNextPage.Enabled = btnLastPage.Enabled = false;
                    }
                    else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"])
                    {
                        btnFirstPage.Enabled = btnPrePage.Enabled = true;
                        btnNextPage.Enabled = btnLastPage.Enabled = false;
                    }
                    else if ((int)ViewState["CurrentPage"] == 1)
                    {
                        btnFirstPage.Enabled = btnPrePage.Enabled = false;
                        btnNextPage.Enabled = btnLastPage.Enabled = true;
                    }
                    else if ((int)ViewState["CurrentPage"] == 2)
                    {
                        btnFirstPage.Enabled = false;
                        btnPrePage.Enabled = btnNextPage.Enabled = btnLastPage.Enabled = true;
                    }

                    else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"] - 1)
                    {
                        btnFirstPage.Enabled = btnPrePage.Enabled = btnNextPage.Enabled = true;
                        btnLastPage.Enabled = false;
                    }
                    else
                    {
                        btnFirstPage.Enabled = btnPrePage.Enabled = btnNextPage.Enabled = btnLastPage.Enabled = true;
                    }
                    ddlPageCount.Items.Clear();
                    for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                    {
                        ddlPageCount.Items.Add(new ListItem("当前第" + i.ToString() + "页", i.ToString()));
                    }
                    ddlPageSize.Items.Clear();
                    for (int i = 10; i <= 500; i = i + 10)
                    {
                        ddlPageSize.Items.Add(new ListItem("每页" + i.ToString() + "条记录", i.ToString()));
                    }
                    ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                    ddlPageSize.SelectedValue = ViewState["PageSize"].ToString();
                    lblPageInfo.Text = "共<b>{0}</b>页<b><span id=recordcount>{1}</span></b>条记录。";
                    lblPageInfo.Text = string.Format(lblPageInfo.Text, ViewState["PageCount"], ViewState["RecordCount"]);
                }
            }
        }

        protected virtual Boolean GetAddInputParameter() { return false; }

        protected virtual Boolean GetModifyInputParameter() { return false; }

        protected virtual Boolean GetQueryInputParameter() { return true; }

        protected virtual Boolean GetDeleteInputParameter() { return true; }

    }
}
