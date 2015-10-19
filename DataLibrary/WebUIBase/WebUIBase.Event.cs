using System;
using System.Collections;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;
using Telerik.Web.UI;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase
    {
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            if (CurrentPageFileName.Equals(WEBUI_SEARCH_FILENAME, StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
                CurrentAccessPermission = GetWebUISearchAccessPurviewID();
                SetCurrentAccessPermission();
                MessageContent = string.Empty;
                if (IsPostBack)
                {
                    if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnOperate", StringComparison.OrdinalIgnoreCase))
                    {
                        switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
                        {
                            case "remove":
                                CurrentAccessPermission = GetOperationDeletePurviewID();
                                break;
                            default:
                                break;
                        }
                    }
                    else if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnExportAllToFile", StringComparison.OrdinalIgnoreCase))
                    {
                        CurrentAccessPermission = OPERATION_EXPORTALL_PURVIEW_ID;
                    }
                }
            }
            else if (CurrentPageFileName.Equals(WEBUI_ADD_FILENAME, StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_ADD_FILENAME;
                if (EditMode)
                {
                    CurrentAccessPermission = GetWebUIModifyAccessPurviewID();
                }
                else if (ViewMode)
                {
                    CurrentAccessPermission = GetWebUIDetailAccessPurviewID();
                }
                else if (AddMode)
                {
                    CurrentAccessPermission = GetWebUIAddAccessPurviewID();
                }
                else if (ImportDocMode)
                {
                    CurrentAccessPermission = OPERATION_IMPORT_PURVIEW_ID;
                }
                else if (ImportDSMode)
                {
                    CurrentAccessPermission = OPERATION_IMPORT_DS_PURVIEW_ID;
                }
                else
                {
                    CurrentAccessPermission = NO_ACCESS_PURVIEW_ID;
                }
                MessageContent = string.Empty;
            }
            else if (CurrentPageFileName.Equals(WEBUI_DETAIL_FILENAME, StringComparison.OrdinalIgnoreCase)
                || CurrentPageFileName.Equals(WEBUI_IMAGE_FILENAME, StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_DETAIL_FILENAME;
                CurrentAccessPermission = GetWebUIDetailAccessPurviewID();
            }
            else if (CurrentPageFileName.Equals(WEBUI_STATISTIC_FILENAME, StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_STATISTIC_FILENAME;
                CurrentAccessPermission = WEBUI_STATISTIC_ACCESS_PURVIEW_ID;
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
                if (!DataValidateManager.ValidateIsNull(CurrentAccessPermission))
                {
                    AccessPermission = ValidateUserPagePurview();
                    if (!AccessPermission)
                    {
                        //记录日志
                        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0004, new string[] { (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], (string)CurrentAccessPermission });
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
            if (MainContentPlaceHolder != null || MainContainerPlaceHolder != null)
            {
                var placeHolder = (MainContentPlaceHolder ?? MainContainerPlaceHolder);
                if (!DataValidateManager.ValidateIsNull(MessageContent))
                {
                    var lb = (Literal)placeHolder.FindControl("MessageBox");
                    if (lb != null)
                    {
                        lb.Text = string.Format("<div class='messagebox'><div class='messagebody'><div>{0}</div></div></div>", MessageContent);
                        MessageContent = string.Empty;
                    }
                }
            }
            CheckPermission();
            if (!IsPostBack)
            {
                ProcessUIControlsStatus();
            }
        }

        protected void btnShowAdvanceSearchItem_Click(object sender, EventArgs e)
        {
            SetMoreSearchItemDisplay(true);
        }

        protected void btnShowSimpleSearchItem_Click(object sender, EventArgs e)
        {
            SetMoreSearchItemDisplay(false);
        }

        protected void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (MainContentPlaceHolder != null)
            {
                var ddlOperation = MainContentPlaceHolder.FindControl("ddlOperation");
                var btnOperate = MainContentPlaceHolder.FindControl("btnOperate"); 
                var chkAll = MainContentPlaceHolder.FindControl("chkAll");
                if (ddlOperation != null && btnOperate != null && chkAll != null)
                {
                    CustomColumnIndex();
                    ViewState.Clear();
                    chkAll.Visible = true;
                    ddlOperation.Visible = true;
                    btnOperate.Visible = true;
                    Initalize();
                }
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = 1;
            Initalize();
        }

        protected void btnPrePage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] - 1;
            Initalize();
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] + 1;
            Initalize();
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = ViewState["PageCount"];
            Initalize();
        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            LinkButton btnTemp = new LinkButton();
            btnTemp = (LinkButton)sender;
            ViewState["SortField"] = btnTemp.CommandArgument.ToString();
            if (btnTemp.CommandName == "DescSort")
            {
                ViewState["Sort"] = false;
            }
            else if (btnTemp.CommandName == "AscSort")
            {
                ViewState["Sort"] = true;
            }
            else
            {
                ViewState["Sort"] = false;
            }
            Initalize();
        }

        protected void ddlPageCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlTemp = sender as DropDownList;
            if (ddlTemp == null)
            {
                var rcbTemp = sender as RadComboBox;
                if (rcbTemp != null)
                {
                    ViewState["CurrentPage"] = int.Parse(rcbTemp.SelectedValue);
                }
            }
            else
            {
                ViewState["CurrentPage"] = int.Parse(ddlTemp.SelectedValue);
            }
            Initalize();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlTemp = (DropDownList)sender;
            ViewState["PageSize"] = int.Parse(ddlTemp.SelectedValue);
            ViewState["CurrentPage"] = 1;
            Initalize();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void btnExportAllToFile_Click(object sender, EventArgs e)
        {
            ViewState["PageSize"] = 10000000;
            ViewState["CurrentPage"] = 1;
            ExportToFile();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Path);
            Response.End();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btnTemp = new LinkButton();
            btnTemp = (LinkButton)sender;
            RICH.Common.FileLibrary.DownloadFile(btnTemp.CommandArgument.ToString(), btnTemp.CommandName.ToString());
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // 首先判断是否是Header行
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // 设置操作状态
                LinkButton btnTemp = new LinkButton();
                string strSortFieldID = "btnSort" + (string)ViewState["SortField"];
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    btnTemp = (LinkButton)e.Row.Cells[i].FindControl(strSortFieldID);
                    if (btnTemp != null)
                    {
                        if ((Boolean)ViewState["Sort"] == false)
                        {
                            btnTemp.Text = "▼";
                            btnTemp.CommandName = "AscSort";
                        }
                        else if ((Boolean)ViewState["Sort"])
                        {
                            btnTemp.Text = "▲";
                            btnTemp.CommandName = "DescSort";
                        }
                        break;
                    }
                }
            }
            // 判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strObjectID = string.Empty;
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    Control hcTemp = e.Row.Cells[i].FindControl("ObjectID");
                    if (hcTemp != null)
                    {
                        strObjectID = ((HtmlInputHidden)hcTemp).Value;
                    }
                }
                e.Row.Attributes.Add("onmouseover", "overColor(this);");
                e.Row.Attributes.Add("onmouseout", "outColor(this);");
                if (DetailAccessPermission)
                {
                    for (int i = 1; i < e.Row.Cells.Count && e.Row.Cells.Count > 1; i++)
                    {
                        e.Row.Cells[i].Attributes.Add("onclick", "OpenWindow('{0}',770,600,window);return false;".FormatInvariantCulture(DetailPage ? GetDetailPageUrl(strObjectID) : GetViewPageUrl(strObjectID)));
                    }
                }
                else if (ModifyAccessPermission)
                {
                    for (int i = 1; i < e.Row.Cells.Count && e.Row.Cells.Count > 1; i++)
                    {
                        e.Row.Cells[i].Attributes.Add("onclick", "OpenWindow('{0}',770,600,window);return false;".FormatInvariantCulture(GetEditPageUrl(strObjectID)));
                    }
                }
            }
        }

        protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e) { }
        protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e) { }
        protected void btnDeleteFilterReport_Click(object sender, EventArgs e)
        {
            if (MainContentPlaceHolder != null)
            {
                var FilterReportList = MainContentPlaceHolder.FindControl("FilterReportList") as DropDownList;
                var FilterReportName = MainContentPlaceHolder.FindControl("FilterReportName") as TextBox;
                if (FilterReportList != null && FilterReportName != null)
                {
                    FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                    FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData();
                    if (FilterReportList.SelectedIndex <= 0 || !string.Equals(FilterReportName.Text.TrimIfNotNullOrWhiteSpace(), FilterReportList.SelectedItem.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
                    if (filterReportApplicationData.XTBG != "0")
                    {
                        MessageContent += @"<font color=""red"">没有权限删除系统报告。</font>";
                    }
                    else if (!filterReportApplicationData.UserID.Equals((string)Session[ConstantsManager.SESSION_USER_ID]))
                    {
                        MessageContent += @"<font color=""red"">没有权限删除共享报告。</font>";
                    }
                    else
                    {
                        filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = filterReportApplicationData.ObjectID, OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID });
                        FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
                        FilterReportList_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }
    }
}
