/****************************************************** 
FileName:DictionaryTypeWebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;

namespace RICH.Common.BM.DictionaryType
{
    public class DictionaryTypeWebUIBase : WebUIBase
    {
        #region 常量定义
        /// <summary>
        /// 数据类型
        /// </summary>
        public override string FilterReportType { get { return "DictionaryType"; } }
        /// <summary>
        /// 当前页面所在文件路径
        /// </summary>
        public override string CURRENT_PATH { get { return "/Administrator/A_BM"; } }
        /// <summary>
        /// 默认的排序方式
        /// </summary>
        protected const Boolean DEFAULT_SORT = true;
        /// <summary>
        /// 默认的排序字段
        /// </summary>
        protected const string DEFAULT_SORT_FIELD = "DM";
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        protected const Int32 DEFAULT_PAGE_SIZE = 50;
        /// <summary>
        /// 默认当前页号
        /// </summary>
        protected const Int32 DEFAULT_CURRENT_PAGE = 1;

        #region 页面名称定义
        /// <summary>
        /// 编辑页面文件名
        /// </summary>
        public override string WEBUI_ADD_FILENAME { get { return "DictionaryTypeWebUIAdd.aspx"; } }
        /// <summary>
        /// 查询页面文件名
        /// </summary>
        public override string WEBUI_SEARCH_FILENAME { get { return "DictionaryTypeWebUISearch.aspx"; } }
        /// <summary>
        /// 详情页面文件名
        /// </summary>
        public override string WEBUI_DETAIL_FILENAME { get { return "DictionaryTypeWebUIDetail.aspx"; } }
        /// <summary>
        /// 统计页面文件名
        /// </summary>
        public override string WEBUI_STATISTIC_FILENAME { get { return "DictionaryTypeWebUIStatistic.aspx";} }
        #endregion

        #region 权限编号定义
        /// <summary>
        /// 添加权限
        /// </summary>
        public override string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "DICTT01";} }
        /// <summary>
        /// 修改权限
        /// </summary>
        public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "DICTT02";} }
        /// <summary>
        /// 浏览权限
        /// </summary>
        public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID  { get { return "DICTT04";} }
        /// <summary>
        /// 详情权限
        /// </summary>
        public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID  { get { return "DICTT05";} }
        /// <summary>
        /// 统计权限
        /// </summary>
        public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID  { get { return "DICTT06";} }
        /// <summary>
        /// 删除权限
        /// </summary>
        public override string OPERATION_DELETE_PURVIEW_ID  { get { return "DICTT07";} }
        /// <summary>
        /// 导出权限
        /// </summary>
        public override string OPERATION_EXPORTALL_PURVIEW_ID { get { return "DICTT08";} }
        /// <summary>
        /// 导入权限
        /// </summary>
        public override string OPERATION_IMPORT_PURVIEW_ID { get { return "DICTT09";} }
        /// <summary>
        /// 导入数据集权限
        /// </summary>
        public override string OPERATION_IMPORT_DS_PURVIEW_ID { get { return "DICTT10";} }
        #endregion
        #endregion

        #region 变量定义
        /// <summary>
        /// 数据实体对象
        /// </summary>
        protected DictionaryTypeApplicationData appData;
        /// <summary>
        /// 消息信息
        /// </summary>
        protected string strMessageInfo = string.Empty;
        /// <summary>
        /// 消息参数
        /// </summary>
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        /// <summary>
        /// AJAX操作返回值
        /// </summary>
        protected string strAJAXReturnValue = string.Empty;
        /// <summary>
        /// 弹出消息信息
        /// </summary>
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region 数据操作方法
        //=====================================================================
        //  FunctionName : AddRecord
        /// <summary>
        /// 添加记录操作
        /// </summary>
        //=====================================================================
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                // 添加主表
                appData = instanceDictionaryTypeApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"字典类型", "添加"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "字典类型", appData.DM.ToString(), "添加"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"此编号", "字典类型"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        //=====================================================================
        //  FunctionName : ModifyRecord
        /// <summary>
        /// 修改记录操作
        /// </summary>
        //=====================================================================
        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                // 主表修改
                appData = instanceDictionaryTypeApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"字典类型", "修改"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "字典类型", appData.DM.ToString(), "修改"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        //=====================================================================
        //  FunctionName : QueryRecord
        /// <summary>
        /// 查询记录操作
        /// </summary>
        //=====================================================================
        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : DeleteRecord
        /// <summary>
        /// 删除记录操作
        /// </summary>
        //=====================================================================
        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                appData = instanceDictionaryTypeApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "字典类型", (string)appData.ObjectIDBatch, "删除"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : CountRecord
        /// <summary>
        /// 统计记录数操作
        /// </summary>
        //=====================================================================
        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                appData = instanceDictionaryTypeApplicationLogic.Count(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : GetAddInputParameter
        /// <summary>
        /// 得到添加用户输入参数操作
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetAddInputParameter()
        {
            return false;
        }

        //=====================================================================
        //  FunctionName : GetModifyInputParameter
        /// <summary>
        /// 得到修改用户输入参数操作
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetModifyInputParameter()
        {
            return false;
        }

        //=====================================================================
        //  FunctionName : GetQueryInputParameter
        /// <summary>
        /// 得到查询用户输入参数操作（通过Request对象）
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetQueryInputParameter()
        {
            return true;
        }

          
        //=====================================================================
        //  FunctionName : GetDeleteInputParameter
        /// <summary>
        /// 得到查询用户输入参数操作
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetDeleteInputParameter()
        {
            return true;
        }

        //=====================================================================
        //  FunctionName : GetCountInputParameter
        /// <summary>
        /// 得到统计记录数用户输入参数操作（通过Request对象）
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetCountInputParameter()
        {
            Boolean boolReturn = true;
            // 验证输入参数
            if (ValidateRequestParamter() == true)
            {

                if (DataValidateManager.ValidateIsNull(Request["CountField"]) == false)
                {
                    if (DataValidateManager.ValidateStringLengthRange(Request["CountField"].ToString(), 1, 50) == false)
                    {
                          strMessageParam[0] = "统计方式";
                          strMessageParam[1] = "1";
                          strMessageParam[2] = "50";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                          boolReturn = false;
                    }
                    else
                    {
                        appData.CountField = Request["CountField"].ToString();
                    }
                }
                else
                {
                      strMessageParam[0] = "统计方式";
                      strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, strMessageParam, strMessageInfo);
                      boolReturn = false;
                }

                if (DataValidateManager.ValidateIsNull(ViewState["Sort"]) == false)
                {
                    if (DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()) == false)
                    {
                        appData.Sort = DEFAULT_SORT;
                    }
                    else
                    {
                        appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
                    }
                }
                else
                {
                    appData.Sort = DEFAULT_SORT;
                }

                if (DataValidateManager.ValidateIsNull(ViewState["SortField"]) == false)
                {
                    if (DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()) == false)
                    {
                        appData.SortField = "RecordID";
                    }
                    else
                    {
                        appData.SortField = ViewState["SortField"].ToString();
                    }
                }
                else
                {
                    appData.SortField = "RecordID";
                }
            }
            else
            {
                // 记录日志开始
                string strLogTypeID = "A04";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0009, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // 记录日志结束

                // 对错误消息进行处理
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0027, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/ErrorPage/CommonErrorPage.aspx");
                Response.End();
            }
            return boolReturn;
        }
        #endregion

        #region 页面控件相关方法
        //=====================================================================
        //  FunctionName : Initalize
        /// <summary>
        /// 页面初始化虚函数
        /// </summary>
        //=====================================================================
        protected virtual void Initalize()
        {
        }

        //=====================================================================
        //  FunctionName : btnFirstPage_Click
        /// <summary>
        /// 第一页按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnFirstPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = 1;
            Initalize();
        }

        //=====================================================================
        //  FunctionName : btnPrePage_Click
        /// <summary>
        /// 上一页按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnPrePage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] - 1;
            Initalize();
        }

        //=====================================================================
        //  FunctionName : btnNextPage_Click
        /// <summary>
        /// 下一页按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnNextPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = (int)ViewState["CurrentPage"] + 1;
            Initalize();
        }

        //=====================================================================
        //  FunctionName : btnLastPage_Click
        /// <summary>
        /// 最后一页按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnLastPage_Click(object sender, EventArgs e)
        {
            ViewState["CurrentPage"] = ViewState["PageCount"];
            Initalize();
        }

        //=====================================================================
        //  FunctionName : btnAddConfirm_Click
        /// <summary>
        /// 确认添加按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new DictionaryTypeApplicationData();
            AddRecord();
        }
        
        //=====================================================================
        //  FunctionName : btnModifyConfirm_Click
        /// <summary>
        /// 确认修改按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new DictionaryTypeApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        //=====================================================================
        //  FunctionName : gvList_RowDataBound
        /// <summary>
        /// GridView列表控件RowDataBound事件
        /// </summary>
        //=====================================================================
        protected virtual void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        else if ((Boolean)ViewState["Sort"] == true)
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
                string strItemMenu = string.Empty;
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    Control hcTemp = e.Row.Cells[i].FindControl("ObjectID");
                    if (hcTemp != null)
                    {
                        strObjectID = ((HtmlInputHidden)hcTemp).Value;
                    }
                    hcTemp = e.Row.Cells[i].FindControl("itemMenu");
                    if (hcTemp != null)
                    {
                        strItemMenu = ((HtmlContainerControl)hcTemp).ClientID;
                    }
                }
                e.Row.Attributes.Add("onmouseover", "overColor(this);");
                e.Row.Attributes.Add("onmouseout", "outColor(this);");
                e.Row.Attributes.Add("oncontextmenu", "showMenu('" + strItemMenu + "');");
            }
        }

        //=====================================================================
        //  FunctionName : btnSort_Click
        /// <summary>
        /// 排序按钮控件Click事件
        /// </summary>
        //=====================================================================
        protected virtual void btnSort_Click(object sender, EventArgs e)
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

        //=====================================================================
        //  FunctionName : ddlPageCount_SelectedIndexChanged
        /// <summary>
        /// 页码选择下拉列表控件SelectedIndexChanged事件
        /// </summary>
        //=====================================================================
        protected virtual void ddlPageCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTemp = new DropDownList();
            ddlTemp = (DropDownList)sender;
            ViewState["CurrentPage"] = int.Parse(ddlTemp.SelectedValue);
            Initalize();
        }

        //=====================================================================
        //  FunctionName : ddlPageSize_SelectedIndexChanged
        /// <summary>
        /// 每页记录数下拉列表控件SelectedIndexChanged事件
        /// </summary>
        //=====================================================================
        protected virtual void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTemp = new DropDownList();
            ddlTemp = (DropDownList)sender;
            ViewState["PageSize"] = int.Parse(ddlTemp.SelectedValue);
            ViewState["CurrentPage"] = 1;
            Initalize();
        }

        //=====================================================================
        //  FunctionName : btnOperate_Click
        /// <summary>
        /// 操作选中记录控件Click事件
        /// </summary>
        //=====================================================================
        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new DictionaryTypeApplicationData();
                    appData.ObjectIDBatch = (string)Request["ObjectIDBatch"];
                    appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.BATCH;
                    DeleteRecord();
                    break;
                default:
                    break;
            }
            Initalize();
        }

        //=====================================================================
        //  FunctionName : ExportToFile
        /// <summary>
        /// 导出数据到文件函数
        /// </summary>
        //=====================================================================
        protected virtual void ExportToFile()
        {
        }

        //=====================================================================
        //  FunctionName : VerifyRenderingInServerForm
        /// <summary>
        /// 重写函数VerifyRenderingInServerForm
        /// </summary>
        //=====================================================================
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        //=====================================================================
        //  FunctionName : btnExportAllToFile_Click
        /// <summary>
        /// 导出所有数据到文件按钮控件Click事件
        /// </summary>
        //=====================================================================
        protected virtual void btnExportAllToFile_Click(object sender, EventArgs e)
        {
            ViewState["PageSize"] = 10000000;
            ViewState["CurrentPage"] = 1;
            ExportToFile();
        }

        //=====================================================================
        //  FunctionName : btnReset_Click
        /// <summary>
        /// 重新填写按钮控件Click事件
        /// </summary>
        //=====================================================================
        protected virtual void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Path);
            Response.End();
        }

        //=====================================================================
        //  FunctionName : btnDownload_Click
        /// <summary>
        /// 下载按钮控件Click事件
        /// </summary>
        //=====================================================================
        protected virtual void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btnTemp = new LinkButton();
            btnTemp = (LinkButton)sender;
            RICH.Common.FileLibrary.DownloadFile(btnTemp.CommandArgument.ToString(), btnTemp.CommandName.ToString());
        }
        #endregion

        #region 取得数据源

        #endregion

        #region 修改任意字段
        //=====================================================================
        //  FunctionName : ModifyAnyField
        /// <summary>
        /// 修改一个字段的值
        /// </summary>
        //=====================================================================
        protected virtual void ModifyAnyField()
        {
            DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
            appData = instanceDictionaryTypeApplicationLogic.Modify(appData);
        }
        #endregion

        #region 统计任意字段
        //=====================================================================
        //  FunctionName : CountAnyField
        /// <summary>
        /// 统计操作
        /// </summary>
        //=====================================================================
        protected virtual void CountAnyField()
        {
            DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
            appData = instanceDictionaryTypeApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX相关方法
        //=====================================================================
        //  FunctionName : AJAX_QuerySingle
        /// <summary>
        /// AJAX调用的读取指定记录指定字段的方法
        /// </summary>
        //=====================================================================
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                DictionaryTypeApplicationData appData = new DictionaryTypeApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "DM":
                        appData.DM = Convert.ToString(strFieldValue);
                        break;
            
                    case "MC":
                        appData.MC = Convert.ToString(strFieldValue);
                        break;
            
                    case "SM":
                        appData.SM = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    strReturn = appData.ResultSet.Tables[0].Rows[0][strReturnFieldName] == DBNull.Value ? "" : appData.ResultSet.Tables[0].Rows[0][strReturnFieldName].ToString();
                }
            }
            catch (Exception)
            {
                strReturn = string.Empty;
            }
            return strReturn;
        }

        //=====================================================================
        //  FunctionName : AJAX_QueryDataSet
        /// <summary>
        /// AJAX调用的读取记录集的XML代码的方法
        /// </summary>
        //=====================================================================
        protected virtual string AJAX_QueryDataSet(string strFieldName, string strFieldValue)
        {
            string strReturn = string.Empty;
            try
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                DictionaryTypeApplicationData appData = new DictionaryTypeApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 10;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "DM":
                        appData.DM = Convert.ToString(strFieldValue);
                        break;
            
                    case "MC":
                        appData.MC = Convert.ToString(strFieldValue);
                        break;
            
                    case "SM":
                        appData.SM = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    strReturn = appData.ResultSet.GetXml();
                }
            }
            catch (Exception)
            {
                strReturn = string.Empty;
            }
            return strReturn;
        }

        //=====================================================================
        //  FunctionName : AJAX_Modify
        /// <summary>
        /// AJAX调用的更新方法
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_Modify(string strFieldName, string strFieldValue, string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                DictionaryTypeApplicationData appData = new DictionaryTypeApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "DM":
                        appData.DM = Convert.ToString(strFieldValue);
                        break;
            
                    case "MC":
                        appData.MC = Convert.ToString(strFieldValue);
                        break;
            
                    case "SM":
                        appData.SM = Convert.ToString(strFieldValue);
                        break;
            
                    }
                    appData = instanceDictionaryTypeApplicationLogic.Modify(appData);
                    if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                    {
                        boolReturn = true;
                    }
                    else
                    {
                        boolReturn = false;
                    }
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        //=====================================================================
        //  FunctionName : AJAX_Delete
        /// <summary>
        /// AJAX调用的删除方法
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_Delete(string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                DictionaryTypeApplicationData appData = new DictionaryTypeApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceDictionaryTypeApplicationLogic.Delete(appData);
                    if (appData.ResultCode== ApplicationDataBase.ResultState.Succeed)
                    {
                        boolReturn = true;                        
                    }
                    else
                    {
                        boolReturn = false;
                    }
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        //=====================================================================
        //  FunctionName : AJAX_IsExist
        /// <summary>
        /// AJAX调用的存在方法
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_IsExist(string strFieldName, string strFieldValue)
        {
            bool boolReturn = false;
            try
            {
                DictionaryTypeApplicationLogic instanceDictionaryTypeApplicationLogic
                    = (DictionaryTypeApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryTypeApplicationLogic));
                DictionaryTypeApplicationData appData = new DictionaryTypeApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "DM":
                        appData.DM = Convert.ToString(strFieldValue);
                        break;
            
                    case "MC":
                        appData.MC = Convert.ToString(strFieldValue);
                        break;
            
                    case "SM":
                        appData.SM = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceDictionaryTypeApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    boolReturn = true;
                }
                else
                {
                    boolReturn = false;
                }
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            return boolReturn;
        }

        
        //=====================================================================
        //  FunctionName : RaiseCallbackEvent
        /// <summary>
        /// 实现接口方法RaiseCallbackEvent
        /// </summary>
        //=====================================================================
        public override void RaiseCallbackEvent(string eventArgument)
        {
            try
            {
                string[] strInputArg = eventArgument.Split(new string[]{"$$$"}, StringSplitOptions.None);
                string strFieldName;
                string strFieldValue;
                string strReturnFieldName;
                string strObjectID;
                if (strInputArg.Length > 0)
                {
                    string strAjaxAppType = strInputArg[0];
                    switch (strAjaxAppType)
                    {
                        case "01":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            if (AJAX_IsExist(strFieldName, strFieldValue) == true)
                            {
                                 strAJAXReturnValue = @"<font color=""red"">已存在，请再换一个。</font>";
                            }
                            else
                            {
                                strAJAXReturnValue = @"不存在，可以使用。";
                            }
                            break;
                        case "02":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strReturnFieldName = strInputArg[3];
                            strAJAXReturnValue = AJAX_QuerySingle(strFieldName, strFieldValue,  strReturnFieldName);
                            break;
                        case "03":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strAJAXReturnValue = AJAX_QueryDataSet(strFieldName, strFieldValue);
                            break;
                        case "04":
                            strFieldName = strInputArg[1];
                            strFieldValue = strInputArg[2];
                            strObjectID = strInputArg[3];
                            if (AJAX_Modify(strFieldName, strFieldValue,  strObjectID) == true)
                            {
                                strAJAXReturnValue = "操作成功。";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">操作失败。</font>";
                            }
                            break;
                        case "05":
                            strObjectID = strInputArg[1];
                            if (AJAX_Delete(strObjectID) == true)
                            {
                                strAJAXReturnValue = @"操作成功。";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">操作失败。</font>";
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                strAJAXReturnValue = "通讯出错。";
            }
        }

        //=====================================================================
        //  FunctionName : RaiseCallbackEvent
        /// <summary>
        /// 实现接口方法RaiseCallbackEvent
        /// </summary>
        //=====================================================================
        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region 验证数据

        //=====================================================================
        //  FunctionName : ValidateObjectID
        /// <summary>
        /// 数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateObjectID(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateUniqueIdentifierFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0012, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("ObjectID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"不存在，可以使用。";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        //=====================================================================
        //  FunctionName : ValidateDM
        /// <summary>
        /// 类型代码数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDM(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "类型代码";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "10";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 10) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("DM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"类型代码已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"类型代码不存在，可以使用。";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        //=====================================================================
        //  FunctionName : ValidateMC
        /// <summary>
        /// 类型名称数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateMC(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "类型名称";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "50";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 50) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("MC", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"类型名称已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"类型名称不存在，可以使用。";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        //=====================================================================
        //  FunctionName : ValidateSM
        /// <summary>
        /// 说明数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSM(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // 初始化参数
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // 传入参数赋值
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "说明";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "255";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 255) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"说明已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"说明不存在，可以使用。";
                                validateData.Result = true;
                            }
                        }
                        else
                        {
                            validateData.Result = true;
                        }
                    }
                }
                else
                {
                    validateData.IsNull = true;
                    if (validateData.Nullable == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, validateData.Parameters);
                        validateData.Result = false;
                    }
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
    
        #endregion

        #region 获取相关表信息

        #endregion

        #region 获取相关表批量添加模板

        #endregion    

        #region 相关表批量操作
        //=====================================================================
        //  FunctionName : RelatedTableAddBatch()
        /// <summary>
        /// 相关表批量添加
        /// </summary>
        //=====================================================================
        protected virtual void RelatedTableAddBatch()
        {

        }
        
        //=====================================================================
        //  FunctionName : RelatedTableModifyBatch()
        /// <summary>
        /// 相关表批量修改
        /// </summary>
        //=====================================================================
        protected virtual void RelatedTableModifyBatch()
        {

        }




        private bool IsAddBatchRow(string strRelatedTableName, GridViewRow gvrTemp)
        {
            bool boolReturn = false;
            
            return boolReturn;
        }

        RICH.Common.Base.ApplicationData.ApplicationDataBase SetBatchOperationValue(
            string strRelatedTableName,
            Type typeofApplicationData,
            DictionaryTypeApplicationData appData,
            GridViewRow gvrTemp
        )
        {
            RICH.Common.Base.ApplicationData.ApplicationDataBase ApplicationData = (RICH.Common.Base.ApplicationData.ApplicationDataBase)Activator.CreateInstance(typeofApplicationData);
            Type typeField;
            Object[] objConstructParms;
            Object objValue;
            
            return ApplicationData;
        }
        #endregion
    }
}
  
