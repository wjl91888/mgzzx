using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;
using RICH.Common;
using Telerik.Web.UI;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase : System.Web.UI.Page
    {
        public virtual string CURRENT_PATH { get { return "/Administrator/A_BM"; } }

        #region 页面名称定义
        public virtual string WEBUI_ADD_FILENAME { get { return "{0}WebUIAdd.aspx".FormatInvariantCulture(TableName); } }
        public virtual string WEBUI_SEARCH_FILENAME { get { return "{0}WebUISearch.aspx".FormatInvariantCulture(TableName); } }
        public virtual string WEBUI_DETAIL_FILENAME { get { return "{0}WebUIDetail.aspx".FormatInvariantCulture(TableName); } }
        public virtual string WEBUI_IMAGE_FILENAME { get { return "{0}WebUIImage.aspx".FormatInvariantCulture(TableName); } }
        public virtual string WEBUI_STATISTIC_FILENAME { get { return "{0}WebUIStatistic.aspx".FormatInvariantCulture(TableName); } }
        #endregion

        #region 权限编号定义
        public virtual string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "{0}01".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "{0}02".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string WEBUI_SEARCH_ACCESS_PURVIEW_ID { get { return "{0}04".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string WEBUI_DETAIL_ACCESS_PURVIEW_ID { get { return "{0}05".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string WEBUI_STATISTIC_ACCESS_PURVIEW_ID { get { return "{0}06".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string OPERATION_DELETE_PURVIEW_ID { get { return "{0}07".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string OPERATION_EXPORTALL_PURVIEW_ID { get { return "{0}08".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string OPERATION_IMPORT_PURVIEW_ID { get { return "{0}09".FormatInvariantCulture(PurviewPrefix); } }
        public virtual string OPERATION_IMPORT_DS_PURVIEW_ID { get { return "{0}10".FormatInvariantCulture(PurviewPrefix); } }
        #endregion

        protected virtual void ExportToFile() { }
        
        protected virtual void SetCurrentAccessPermission() { }

        protected virtual void CheckPermission() { }

        protected virtual void ProcessUIControlsInit()
        {
        }

        protected virtual void ProcessUIControlsStatus()
        {
            // for App
            if (MainContainerPlaceHolder != null &&  PageNavContainerPlaceHolder != null)
            {
                var txtObjectIDItem = (TextBox)MainContainerPlaceHolder.FindControl("ObjectID");
                if (txtObjectIDItem != null)
                {
                    txtObjectIDItem.Text = ObjectID;
                }
                var btnAddItem = (HtmlInputButton)MainContainerPlaceHolder.FindControl("btnAddItem");
                if (btnAddItem != null)
                {
                    btnAddItem.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIAddAccessPurviewID());
                    btnAddItem.Attributes.Add("onclick",
                                               this.IsMobileDevice()
                                                   ? RedirectJsCode.FormatInvariantCulture(GetAddPageUrl())
                                                   : OpenWindowJsCode.FormatInvariantCulture(GetAddPageUrl()));
                }
                var btnEditItem = (HtmlInputButton)PageNavContainerPlaceHolder.FindControl("btnEditItem");
                if (btnEditItem != null)
                {
                    btnEditItem.Visible = !EditMode && !AddMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIModifyAccessPurviewID());
                    btnEditItem.Attributes.Add("onclick",
                                               this.IsMobileDevice()
                                                   ? RedirectJsCode.FormatInvariantCulture(GetEditPageUrl(ObjectID))
                                                   : OpenWindowJsCode.FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                }
                #region add page
                if (CurrentPageFileName.Equals(WEBUI_ADD_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    var ControlContainer = MainContainerPlaceHolder.FindControl("ControlContainer");
                    var btnAddConfirm = PageNavContainerPlaceHolder.FindControl("btnAddConfirm");
                    if (btnEditItem != null)
                    {
                        btnEditItem.Visible = btnEditItem.Visible && AccessPermission;
                        btnEditItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                    }
                    if (ControlContainer != null)
                    {
                        ControlContainer.Visible = AccessPermission;
                    }
                    if (btnAddConfirm != null)
                    {
                        btnAddConfirm.Visible = (CopyMode || AddMode || EditMode) && AccessPermission;
                    }
                }
                #endregion add page

                #region search page
                if (CurrentPageFileName.Equals(WEBUI_SEARCH_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    var PageTitle = MainContainerPlaceHolder.FindControl("PageTitle") as Literal;
                    if (PageTitle != null)
                    {
                        PageTitle.Text = PageHeaderTitle;
                    }
                    if (!AccessPermission)
                    {
                        var advancesearchpage = MainContainerPlaceHolder.FindControl("advancesearchpage");
                        if (advancesearchpage != null)
                        {
                            advancesearchpage.Visible = false;
                        }
                        var SearchPageTopButtonBar = MainContainerPlaceHolder.FindControl("SearchPageTopButtonBar");
                        if (SearchPageTopButtonBar != null)
                        {
                            SearchPageTopButtonBar.Visible = false;
                        }
                        var SearchPageTopToolBar = MainContainerPlaceHolder.FindControl("SearchPageTopToolBar");
                        if (SearchPageTopToolBar != null)
                        {
                            SearchPageTopToolBar.Visible = false;
                        }
                        var ListControl = MainContainerPlaceHolder.FindControl("ListControl");
                        if (ListControl != null)
                        {
                            ListControl.Visible = false;
                        }
                    }
                }
                #endregion search page

                #region detail page
                if (CurrentPageFileName.Equals(WEBUI_DETAIL_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    if (btnEditItem != null)
                    {
                        btnEditItem.Visible = btnEditItem.Visible && AccessPermission;
                        btnEditItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                    }
                    var ControlContainer = MainContainerPlaceHolder.FindControl("ControlContainer");
                    if (ControlContainer != null)
                    {
                        ControlContainer.Visible = AccessPermission;
                    }
                }
                #endregion detail page
            }
            // for Web
            else if (MainContentPlaceHolder != null)
            {
                var txtObjectIDItem = (TextBox)MainContentPlaceHolder.FindControl("ObjectID");
                if (txtObjectIDItem != null)
                {
                    txtObjectIDItem.Text = ObjectID;
                }
                var btnAddItem = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnAddItem");
                if (btnAddItem != null)
                {
                    btnAddItem.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIAddAccessPurviewID());
                    btnAddItem.Attributes.Add("onclick",
                                               this.IsMobileDevice()
                                                   ? RedirectJsCode.FormatInvariantCulture(GetAddPageUrl())
                                                   : OpenWindowJsCode.FormatInvariantCulture(GetAddPageUrl()));
                }
                var btnEditItem = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnEditItem");
                if (btnEditItem != null)
                {
                    btnEditItem.Visible = !EditMode && !AddMode && SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIModifyAccessPurviewID());
                    btnEditItem.Attributes.Add("onclick",
                                               this.IsMobileDevice()
                                                   ? RedirectJsCode.FormatInvariantCulture(GetEditPageUrl(ObjectID))
                                                   : OpenWindowJsCode.FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                }
                var btnCopyItem = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnCopyItem");
                var btnImportFromDoc = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnImportFromDoc");
                if (btnImportFromDoc != null)
                {
                    btnImportFromDoc.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_PURVIEW_ID);
                    btnImportFromDoc.Attributes.Add("onclick", OpenWindowJsCode.FormatInvariantCulture(GetImportDocPageUrl()));
                }
                var btnImportFromDataSet = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnImportFromDataSet");
                if (btnImportFromDataSet != null)
                {
                    btnImportFromDataSet.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, OPERATION_IMPORT_DS_PURVIEW_ID);
                    btnImportFromDataSet.Attributes.Add("onclick", OpenWindowJsCode.FormatInvariantCulture(GetImportDocPageUrl()));
                }
                var btnStatisticItem = (HtmlInputButton)MainContentPlaceHolder.FindControl("btnStatisticItem");
                if (btnStatisticItem != null)
                {
                    btnStatisticItem.Visible = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, WEBUI_STATISTIC_ACCESS_PURVIEW_ID);
                    btnStatisticItem.Attributes.Add("onclick", OpenWindowJsCode.FormatInvariantCulture(GetStatisicPageUrl()));
                }
                if (MainContentPlaceHolder.FindControl("ddlOperation") != null)
                {
                    DropDownList ddlOperation = (DropDownList)MainContentPlaceHolder.FindControl("ddlOperation");
                    var deletePurview = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetOperationDeletePurviewID());
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
                #region add page
                if (CurrentPageFileName.Equals(WEBUI_ADD_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    var ControlContainer = MainContentPlaceHolder.FindControl("ControlContainer");
                    var ImportControlContainer = MainContentPlaceHolder.FindControl("ImportControlContainer");
                    var btnInfoFromDoc = MainContentPlaceHolder.FindControl("btnInfoFromDoc");
                    var btnInfoFromDocBatch = MainContentPlaceHolder.FindControl("btnInfoFromDocBatch");
                    var btnInfoFromDocCancel = MainContentPlaceHolder.FindControl("btnInfoFromDocCancel");
                    var btnInfoFromDS = MainContentPlaceHolder.FindControl("btnInfoFromDS");
                    var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as TextBox;
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
                        //if (ControlContainer != null)
                        //{
                        //    ControlContainer.Visible = false;
                        //}
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
                        if (btnEditItem != null)
                        {
                            btnEditItem.Visible = btnEditItem.Visible && AccessPermission;
                            btnEditItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                        }
                        if (btnCopyItem != null)
                        {
                            btnCopyItem.Visible = ViewMode && AccessPermission;
                            btnCopyItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetCopyPageUrl(ObjectID)));
                        }
                        if (ControlContainer != null)
                        {
                            ControlContainer.Visible = AccessPermission;
                        }
                        if (btnAddConfirm != null)
                        {
                            btnAddConfirm.Visible = (CopyMode || AddMode || EditMode) && AccessPermission;
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
                #endregion add page

                #region search page
                if (CurrentPageFileName.Equals(WEBUI_SEARCH_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    var PageTitle = MainContentPlaceHolder.FindControl("PageTitle") as Literal;
                    if (PageTitle != null)
                    {
                        PageTitle.Text = PageHeaderTitle;
                    }
                    if (!AccessPermission)
                    {
                        var advancesearchpage = MainContentPlaceHolder.FindControl("advancesearchpage");
                        if (advancesearchpage != null)
                        {
                            advancesearchpage.Visible = false;
                        }
                        var SearchPageTopButtonBar = MainContentPlaceHolder.FindControl("SearchPageTopButtonBar");
                        if (SearchPageTopButtonBar != null)
                        {
                            SearchPageTopButtonBar.Visible = false;
                        }
                        var SearchPageTopToolBar = MainContentPlaceHolder.FindControl("SearchPageTopToolBar");
                        if (SearchPageTopToolBar != null)
                        {
                            SearchPageTopToolBar.Visible = false;
                        }
                        var ListControl = MainContentPlaceHolder.FindControl("ListControl");
                        if (ListControl != null)
                        {
                            ListControl.Visible = false;
                        }
                    }
                }
                #endregion search page

                #region detail page
                if (CurrentPageFileName.Equals(WEBUI_DETAIL_FILENAME, StringComparison.OrdinalIgnoreCase))
                {
                    if (btnEditItem != null)
                    {
                        btnEditItem.Visible = btnEditItem.Visible && AccessPermission;
                        btnEditItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetEditPageUrl(ObjectID)));
                    }
                    if (btnCopyItem != null)
                    {
                        btnCopyItem.Visible = AccessPermission;
                        btnCopyItem.Attributes.Add("onclick", "window.location='{0}';".FormatInvariantCulture(GetCopyPageUrl(ObjectID)));
                    }
                    var ControlContainer = MainContentPlaceHolder.FindControl("ControlContainer");
                    if (ControlContainer != null)
                    {
                        ControlContainer.Visible = AccessPermission;
                    }
                    var btnPrintPage = MainContentPlaceHolder.FindControl("btnPrintPage");
                    if (btnPrintPage != null)
                    {
                        btnPrintPage.Visible = AccessPermission;
                    }
                }
                #endregion detail page

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
                currentUserInfo = T_PM_UserInfoBusinessEntity.GetDataByKey(new T_PM_UserInfoApplicationData()
                {
                    UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                });
                return true;
            }
            if (!string.IsNullOrWhiteSpace(Request.QueryString["lcode"]))
            {
                currentUserInfo = T_PM_UserInfoBusinessEntity.GetDataByKey(new T_PM_UserInfoApplicationData()
                {
                    UserID = (string)(new T_PM_UserInfoBusinessEntity()).GetValueByFixCondition("lcode", (string)Request.QueryString["lcode"], "UserID"),
                });
                Session[ConstantsManager.SESSION_USER_ID] = currentUserInfo.UserID;
                Session[ConstantsManager.SESSION_USER_GROUP_ID] = currentUserInfo.UserGroupID;
                Session[ConstantsManager.SESSION_USER_LOGIN_NAME] = currentUserInfo.UserLoginName;
                Session[ConstantsManager.SESSION_SSDW_ID] = currentUserInfo.SubjectID;
                Session[ConstantsManager.SESSION_USER_NICK_NAME] = currentUserInfo.UserNickName;
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
                currentUserInfo = T_PM_UserInfoBusinessEntity.GetDataByKey(new T_PM_UserInfoApplicationData()
                {
                    UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                });
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
            htInputParameter.Add("UserID", CurrentUserInfo.UserID);
            htInputParameter.Add("UserGroupID", CurrentUserInfo.UserGroupID);
            htInputParameter.Add("PurviewID", CurrentAccessPermission);
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
            if (MainContentPlaceHolder != null || PageNavContainerPlaceHolder != null)
            {
                var container = MainContentPlaceHolder ?? PageNavContainerPlaceHolder;
                var btnFirstPage = container.FindControl("btnFirstPage") as Button;
                var btnPrePage = container.FindControl("btnPrePage") as Button;
                var btnNextPage = container.FindControl("btnNextPage") as Button;
                var btnLastPage = container.FindControl("btnLastPage") as Button;
                var ddlPageCount = container.FindControl("ddlPageCount") as DropDownList;
                var ddlPageSize = container.FindControl("ddlPageSize") as DropDownList;
                var lblPageInfo = container.FindControl("lblPageInfo") as Label;
                var rcbPageCount = container.FindControl("ddlPageCount") as RadComboBox;
                if (btnFirstPage != null && btnPrePage != null && btnNextPage != null && btnLastPage != null)
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
                    if (ddlPageCount != null && ddlPageSize != null && lblPageInfo != null)
                    {
                        ddlPageCount.Items.Clear();
                        for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                        {
                            ddlPageCount.Items.Add(new ListItem("第" + i.ToString() + "页", i.ToString()));
                        }
                        ddlPageSize.Items.Clear();
                        for (int i = 50; i <= 500; i = i + 50)
                        {
                            ddlPageSize.Items.Add(new ListItem(i.ToString() + "/页", i.ToString()));
                        }
                        ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                        ddlPageSize.SelectedValue = ViewState["PageSize"].ToString();
                        lblPageInfo.Text =
                            "共<b>{0}</b>页<b><span id=recordcount>{1}</span></b>条记录。".FormatInvariantCulture(
                                ViewState["PageCount"], ViewState["RecordCount"]);
                    }
                    else if (ddlPageCount != null)
                    {
                        ddlPageCount.Items.Clear();
                        for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                        {
                            ddlPageCount.Items.Add(new ListItem("{0}/{1},{2}条".FormatInvariantCulture(
                                i, ViewState["PageCount"], ViewState["RecordCount"]), i.ToString()));
                        }
                        ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                    }
                    else if (rcbPageCount != null)
                    {
                        rcbPageCount.Items.Clear();
                        for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                        {
                            rcbPageCount.Items.Add(new RadComboBoxItem("{0}/{1}页,共{2}条".FormatInvariantCulture(
                                i, ViewState["PageCount"], ViewState["RecordCount"]), i.ToString()));
                        }
                        rcbPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                    }
                }
            }
        }

        protected virtual Boolean GetAddInputParameter() { return false; }

        protected virtual Boolean GetModifyInputParameter() { return false; }

        protected virtual Boolean GetQueryInputParameter() { return true; }

        protected virtual Boolean GetDeleteInputParameter() { return true; }

        protected virtual string GetObjectID() { return string.Empty; }

    }
}
