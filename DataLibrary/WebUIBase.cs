using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationLogic;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;

namespace RICH.Common.Base.WebUI
{
    public abstract partial class WebUIBase : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        protected ApplicationLogicBase CreateApplicationLogicInstance(Type typeofApplicationLogic)
        {
            ApplicationLogicBase applicationLogic = (ApplicationLogicBase)Activator.CreateInstance(typeofApplicationLogic);
            return applicationLogic;
        }

        protected Boolean ValidateRequestParamter()
        {
            Boolean boolReturn = true;
            string[] arrBadWords = { 
                                       "\'", "&", "insert", "select", "delete", "%", 
                                       "*", "master", "truncate", "declare" };
            for (int i = 0; i < Request.Form.Count; i++)
            {
                foreach (string strTemp in arrBadWords)
                {
                    if (Request.Form[i].ToLower().IndexOf(strTemp) >= 0)
                    {
                        boolReturn = false;
                    }
                }
            }
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                foreach (string strTemp in arrBadWords)
                {
                    if (Request.QueryString[i].ToLower().IndexOf(strTemp) >= 0)
                    {
                        boolReturn = false;
                    }
                }
            }
            return boolReturn;
        }


        protected string GetValue(object objValue)
        {
            return GetValue(objValue, null);
        }

        protected string GetValue(object objValue, string strDisplayFormat = null)
        {
            string strReturn = string.Empty;
            if (objValue == DBNull.Value)
            {
                return strReturn;
            }
            if (objValue == null)
            {
                return strReturn;
            }
            if (strDisplayFormat == null)
            {
                strReturn = objValue.ToString();
            }
            else if(Type.GetType("System.String") == objValue.GetType())
            {
                char[] value = objValue.ToString().ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {
                    strDisplayFormat = strDisplayFormat.Replace("{" + i.ToString() + "}", value[i].ToString());
                }
                strReturn = strDisplayFormat;
            }
            else if (DataValidateManager.ValidateNumberFormat(objValue))
            {
                var number = Decimal.Parse(objValue.ToString());
                strReturn = number.ToString(strDisplayFormat);
            }
            else if (DataValidateManager.ValidateDateFormat(objValue))
            {
                strReturn = DateTime.Parse(objValue.ToString()).ToString(strDisplayFormat);
            }
            else
            {
                try
                {
                    char[] value = objValue.ToString().ToCharArray();
                    for (int i = 0; i < value.Length; i++)
                    {
                        strDisplayFormat = strDisplayFormat.Replace("{" + i.ToString() + "}", value[i].ToString());
                    }
                    strReturn = strDisplayFormat;
                }
                catch (Exception)
                {
                    strReturn = objValue.ToString();
                }
            }
            return strReturn;
        }

        protected byte[] GetImageData(FileUpload objFileUpload)
        {
            HttpPostedFile upPhoto = objFileUpload.PostedFile;
            int upPhotoLength = upPhoto.ContentLength;
            Stream fs = upPhoto.InputStream;
            byte[] imageData = new byte[upPhotoLength];
            fs.Read(imageData, 0, upPhotoLength);
            return imageData;
        }

        virtual public void RaiseCallbackEvent(string eventArgument)
        {
        }

        virtual public string GetCallbackResult()
        {
            return string.Empty;
        }

        virtual protected void Page_Init(object sender, EventArgs e)
        {
            CurrentPageFileName = Path.GetFileName(Request.PhysicalPath);
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
                        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0004, new string[] { (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], (string)Session[ConstantsManager.SESSION_CURRENT_PURVIEW]});
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
                    Literal lb = (Literal)MainContentPlaceHolder.FindControl("MessageBox");
                    if (lb != null)
                    {
                        lb.Text = string.Format("<div class='messagebox'><div class='messagebody'><div>{0}</div></div></div>", MessageContent);
                        MessageContent = string.Empty;
                    }
                }
                ProcessUIControlsStatus();
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
                    btnAddItem.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], WEBUI_ADD_ACCESS_PURVIEW_ID);
                }
                var btnEditItem = MainContentPlaceHolder.FindControl("btnEditItem");
                if (btnEditItem != null)
                {
                    btnEditItem.Visible = !EditMode && !AddMode && SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], WEBUI_MODIFY_ACCESS_PURVIEW_ID);
                }
                var btnStatisticItem = MainContentPlaceHolder.FindControl("btnStatisticItem");
                if (btnStatisticItem != null)
                {
                    btnStatisticItem.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], WEBUI_STATISTIC_ACCESS_PURVIEW_ID);
                }
                if (MainContentPlaceHolder.FindControl("ddlOperation") != null)
                {
                    DropDownList ddlOperation = (DropDownList)MainContentPlaceHolder.FindControl("ddlOperation");
                    var deletePurview = RICH.Common.SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_DELETE_PURVIEW_ID);
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
                    btnImportFromDoc.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_IMPORT_PURVIEW_ID);
                }
                var btnImportFromDataSet = MainContentPlaceHolder.FindControl("btnImportFromDataSet");
                if (btnImportFromDataSet != null)
                {
                    btnImportFromDataSet.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_IMPORT_DS_PURVIEW_ID);
                }
                var btnExportAllToFile = MainContentPlaceHolder.FindControl("btnExportAllToFile");
                var ddlExportFileFormat = MainContentPlaceHolder.FindControl("ddlExportFileFormat");
                if (btnExportAllToFile != null)
                {
                    btnExportAllToFile.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_EXPORTALL_PURVIEW_ID);
                }
                if (ddlExportFileFormat != null)
                {
                    ddlExportFileFormat.Visible = SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_EXPORTALL_PURVIEW_ID);
                }
                if (ImportDocMode && SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_IMPORT_PURVIEW_ID))
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
                    var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as Button;
                    if (InfoFromDoc != null)
                    {
                        InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                    }
                }
                else if (ImportDSMode && SystemValidateLibrary.ValidateUserPurview((string)Session[ConstantsManager.SESSION_USER_ID], (string)Session[ConstantsManager.SESSION_USER_GROUP_ID], OPERATION_IMPORT_DS_PURVIEW_ID))
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
                    var InfoFromDoc = MainContentPlaceHolder.FindControl("InfoFromDoc") as Button;
                    if (InfoFromDoc != null)
                    {
                        InfoFromDoc.Attributes.Add("onclick", "uploadfile(this);");
                    }
                }
            }
        }

        protected Table GenerateHtmlTable(
            string strHeadText, 
            string strContent,
            bool border = true,
            bool innerTable = false,
            string strTableCss = null, 
            string strHeadCss = null, 
            string strCellCss = null,
            string strTableWidth = null,
            string strCellWidth = null
            )
        {
            Table htTemp = new Table();
            strContent = strContent.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
            if (!DataValidateManager.ValidateIsNull(strTableCss))
            {
                htTemp.CssClass = strTableCss;
            }
            htTemp.CellPadding = 0;
            htTemp.CellSpacing = 0;
            htTemp.BorderWidth = 0;
            htTemp.Style.Add("width", "100%");

            string[] headText = strHeadText.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            TableRow htrHead = new TableRow();
            for (int i = 0; i < headText.Length; i++)
            {
                TableCell htc = new TableCell();
                htc.Text = headText[i];
                if (!DataValidateManager.ValidateIsNull(strHeadCss))
                {
                    htc.CssClass = strHeadCss;
                }
                htc.Style.Add("text-align", "center");
                htrHead.Cells.Add(htc);
            }
            htTemp.Rows.Add(htrHead);

            string[] rows = strContent.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < rows.Length; index++ )
            {
                TableRow htr = new TableRow();
                string[] fields = rows[index].Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                for (int i = 0; i < fields.Length && i < headText.Length; i++)
                {
                    TableCell htc = new TableCell();
                    htc.Text = fields[i];
                    if (!DataValidateManager.ValidateIsNull(strCellCss))
                    {
                        htc.CssClass = strCellCss;
                    }
                    htc.Style.Add("text-align", "center !important");
                    htr.Cells.Add(htc);
                }
                htTemp.Rows.Add(htr);
            }

            // 设置inner table边框
            if (htTemp.Rows.Count > 0)
            {
                for (int index = 0; index < htTemp.Rows.Count; index++)
                {
                    for (int i = 0; i < htTemp.Rows[index].Cells.Count; i++)
                    {
                        if (border && innerTable)
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border-top", index == 0 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-left", i == 0 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-bottom", index == htTemp.Rows.Count - 1 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-right", i == headText.Length - 1 ? "0px black solid" : "1px black solid");
                        }
                        else if (border)
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border", "1px black solid");
                        }
                        else
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border", "0px black solid");
                        }
                    }
                }
            }
            return htTemp;
        }

        protected DataTable GenerateDataTable(
            string strColumnName,
            string strContent
            )
        {
            DataTable dtTemp = new DataTable();
            strContent = strContent.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
            string[] columnName = strColumnName.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            for (int i = 0; i < columnName.Length; i++)
            {
                dtTemp.Columns.Add(columnName[i]);
            }
            string[] rows = strContent.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < rows.Length; index++)
            {
                DataRow dr = dtTemp.NewRow();
                string[] fields = rows[index].Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                for (int i = 0; i < fields.Length && i < columnName.Length; i++)
                {
                    dr[i] = fields[i];
                }
                dtTemp.Rows.Add(dr);
            }
            return dtTemp;
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
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0001, new string[] { (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME] });
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
