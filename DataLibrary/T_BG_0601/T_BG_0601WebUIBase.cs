/****************************************************** 
FileName:T_BG_0601WebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;

namespace RICH.Common.BM.T_BG_0601
{
    public class T_BG_0601WebUIBase : WebUIBase
    {
        #region 常量定义
        /// <summary>
        /// 数据类型
        /// </summary>
        public override string FilterReportType { get { return "T_BG_0601"; } }
        /// <summary>
        /// 当前页面所在文件路径
        /// </summary>
        public override string CURRENT_PATH { get { return "/Administrator/A_BM"; } }
        /// <summary>
        /// 默认的排序方式
        /// </summary>
        protected const Boolean DEFAULT_SORT = false;
        /// <summary>
        /// 默认的排序字段
        /// </summary>
        protected const string DEFAULT_SORT_FIELD = "FBH";
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
        public override string WEBUI_ADD_FILENAME { get { return "T_BG_0601WebUIAdd.aspx"; } }
        /// <summary>
        /// 查询页面文件名
        /// </summary>
        public override string WEBUI_SEARCH_FILENAME { get { return "T_BG_0601WebUISearch.aspx"; } }
        /// <summary>
        /// 详情页面文件名
        /// </summary>
        public override string WEBUI_DETAIL_FILENAME { get { return "T_BG_0601WebUIDetail.aspx"; } }
        /// <summary>
        /// 统计页面文件名
        /// </summary>
        public override string WEBUI_STATISTIC_FILENAME { get { return "T_BG_0601WebUIStatistic.aspx";} }
        #endregion

        #region 权限编号定义
        /// <summary>
        /// 添加权限
        /// </summary>
        public override string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "BG060101";} }
        /// <summary>
        /// 修改权限
        /// </summary>
        public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "BG060102";} }
        /// <summary>
        /// 浏览权限
        /// </summary>
        public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID  { get { return "BG060104";} }
        /// <summary>
        /// 详情权限
        /// </summary>
        public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID  { get { return "BG060105";} }
        /// <summary>
        /// 统计权限
        /// </summary>
        public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID  { get { return "BG060106";} }
        /// <summary>
        /// 删除权限
        /// </summary>
        public override string OPERATION_DELETE_PURVIEW_ID  { get { return "BG060107";} }
        /// <summary>
        /// 导出权限
        /// </summary>
        public override string OPERATION_EXPORTALL_PURVIEW_ID { get { return "BG060108";} }
        /// <summary>
        /// 导入权限
        /// </summary>
        public override string OPERATION_IMPORT_PURVIEW_ID { get { return "BG060109";} }
        #endregion
        #endregion

        #region 变量定义
        /// <summary>
        /// 数据实体对象
        /// </summary>
        protected T_BG_0601ApplicationData appData;
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                // 添加主表
                appData = instanceT_BG_0601ApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {

                    // 对成功消息进行处理
                    strMessageParam[0] = "公共信息";
                    strMessageParam[1] = "添加";
                    strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
                    MessageContent = strMessageInfo;

                    // 记录日志开始
                    string strLogTypeID = "A02";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "公共信息";
                    strMessageParam[2] = appData.BT.ToString();
                    strMessageParam[3] = "添加";
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
                    LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                    // 记录日志结束

                    // 成功后页面跳转
                    Page.CloseWindow(true);
                }
                else
                {
                    // 对失败消息进行处理
                    strMessageParam[0] = "此编号";
                    strMessageParam[1] = "公共信息";
                    strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, strMessageParam, strMessageInfo);
                    MessageContent = strMessageInfo;
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                // 主表修改
                appData = instanceT_BG_0601ApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                // 对成功消息进行处理
                strMessageParam[0] = "公共信息";
                strMessageParam[1] = "修改";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
                MessageContent = strMessageInfo;

                // 记录日志开始
                string strLogTypeID = "A02";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "公共信息";
                strMessageParam[2] = appData.BT.ToString();
                strMessageParam[3] = "修改";
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, appData.ObjectID.ToString(), null);
                // 记录日志结束

                // 成功后页面跳转
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                appData = instanceT_BG_0601ApplicationLogic.Delete(appData);
                            // 记录日志开始
                string strLogTypeID = "A02";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "公共信息";
                strMessageParam[2] = (string)appData.ObjectIDBatch;
                strMessageParam[3] = "删除";
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // 记录日志结束
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                appData = instanceT_BG_0601ApplicationLogic.Count(appData);
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
            appData = new T_BG_0601ApplicationData();
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
            appData = new T_BG_0601ApplicationData();
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
                    appData = new T_BG_0601ApplicationData();
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

        //=====================================================================
        //  FunctionName : GetTree_FBLM
        /// <summary>
        /// 根据指定条件取得发布栏目(FBLM)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_FBLM(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "LMH";
            string strMC = "LMM";
            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData 
                T_BG_0602AppData = new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData();
            T_BG_0602AppData.PageSize = 1000;
            T_BG_0602AppData.CurrentPage = 1;
            T_BG_0602AppData.Sort = true;
            T_BG_0602AppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BG_0602AppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BG_0602AppData, strParent, null);
            }
            if (T_BG_0602AppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BG_0602AppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic
                T_BG_0602AL = (RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic));
            T_BG_0602AL.Query(T_BG_0602AppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BG_0602AppData.ValidateColumnName(strParentName) == true) 
                || !(T_BG_0602AppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BG_0602AppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_FBLM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BG_0602AppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_FBLM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_FBLM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BG_0602AppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BG_0602AppData.ResultSet;
                foreach (DataRow drChild in T_BG_0602AppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_FBLM
        /// <summary>
        /// 取得发布栏目(FBLM)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_FBLM(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BG_0602");
            dsReturn.Tables["T_BG_0602"].Columns.Add("LMH");
            dsReturn.Tables["T_BG_0602"].Columns.Add("LMM");
            GetTree_FBLM("null", "null", true, "SJLMH", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_FBLM_AdvanceSearch
        /// <summary>
        /// 取得发布栏目(FBLM)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_FBLM_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BG_0602");
            dsReturn.Tables["T_BG_0602"].Columns.Add("LMH");
            dsReturn.Tables["T_BG_0602"].Columns.Add("LMM");
            GetTree_FBLM("null", "null", true, "SJLMH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetSubItem_FBLM
        /// <summary>
        /// 取得发布栏目(FBLM)指定条件的子项目信息
        /// </summary>
        //=====================================================================
        protected virtual String GetSubItem_FBLM(String strSJLMH, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            sbReturn.Append("No Search Item!");
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add("T_BG_0602");
            dsTemp.Tables["T_BG_0602"].Columns.Add("LMH");
            dsTemp.Tables["T_BG_0602"].Columns.Add("LMM");
            GetTree_FBLM("null", "null", true, "SJLMH", strSJLMH, ref dsTemp, 0, isDisplayExistItem, displayTextIncludeCode);
            if (dsTemp.Tables.Count>0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    sbReturn.Append(",");
                    sbReturn.Append(drTemp["LMH"]);
                }
            }
            return sbReturn.ToString();
        }
        
        //=====================================================================
        //  FunctionName : GetTree_XXLX
        /// <summary>
        /// 根据指定条件取得信息类型(XXLX)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_XXLX(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "DM";
            string strMC = "MC";
            RICH.Common.BM.Dictionary.DictionaryApplicationData 
                DictionaryAppData = new RICH.Common.BM.Dictionary.DictionaryApplicationData();
            DictionaryAppData.PageSize = 1000;
            DictionaryAppData.CurrentPage = 1;
            DictionaryAppData.Sort = true;
            DictionaryAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(DictionaryAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strParentName).SetValue(DictionaryAppData, strParent, null);
            }
            if (DictionaryAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(DictionaryAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.Dictionary.DictionaryApplicationLogic
                DictionaryAL = (RICH.Common.BM.Dictionary.DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.Dictionary.DictionaryApplicationLogic));
            DictionaryAL.Query(DictionaryAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(DictionaryAppData.ValidateColumnName(strParentName) == true) 
                || !(DictionaryAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_XXLX(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_XXLX(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_XXLX(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || DictionaryAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = DictionaryAppData.ResultSet;
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_XXLX
        /// <summary>
        /// 取得信息类型(XXLX)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XXLX(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XXLX("LX", "0101", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_XXLX_AdvanceSearch
        /// <summary>
        /// 取得信息类型(XXLX)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XXLX_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XXLX("LX", "0101", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_XXZT
        /// <summary>
        /// 根据指定条件取得信息状态(XXZT)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_XXZT(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "DM";
            string strMC = "MC";
            RICH.Common.BM.Dictionary.DictionaryApplicationData 
                DictionaryAppData = new RICH.Common.BM.Dictionary.DictionaryApplicationData();
            DictionaryAppData.PageSize = 1000;
            DictionaryAppData.CurrentPage = 1;
            DictionaryAppData.Sort = true;
            DictionaryAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(DictionaryAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strParentName).SetValue(DictionaryAppData, strParent, null);
            }
            if (DictionaryAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(DictionaryAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.Dictionary.DictionaryApplicationLogic
                DictionaryAL = (RICH.Common.BM.Dictionary.DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.Dictionary.DictionaryApplicationLogic));
            DictionaryAL.Query(DictionaryAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(DictionaryAppData.ValidateColumnName(strParentName) == true) 
                || !(DictionaryAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_XXZT(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_XXZT(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_XXZT(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || DictionaryAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = DictionaryAppData.ResultSet;
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_XXZT
        /// <summary>
        /// 取得信息状态(XXZT)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XXZT(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XXZT("LX", "0102", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_XXZT_AdvanceSearch
        /// <summary>
        /// 取得信息状态(XXZT)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XXZT_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XXZT("LX", "0102", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_IsTop
        /// <summary>
        /// 根据指定条件取得是否置顶(IsTop)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_IsTop(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "DM";
            string strMC = "MC";
            RICH.Common.BM.Dictionary.DictionaryApplicationData 
                DictionaryAppData = new RICH.Common.BM.Dictionary.DictionaryApplicationData();
            DictionaryAppData.PageSize = 1000;
            DictionaryAppData.CurrentPage = 1;
            DictionaryAppData.Sort = true;
            DictionaryAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(DictionaryAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strParentName).SetValue(DictionaryAppData, strParent, null);
            }
            if (DictionaryAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(DictionaryAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.Dictionary.DictionaryApplicationLogic
                DictionaryAL = (RICH.Common.BM.Dictionary.DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.Dictionary.DictionaryApplicationLogic));
            DictionaryAL.Query(DictionaryAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(DictionaryAppData.ValidateColumnName(strParentName) == true) 
                || !(DictionaryAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_IsTop(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_IsTop(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_IsTop(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || DictionaryAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = DictionaryAppData.ResultSet;
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_IsTop
        /// <summary>
        /// 取得是否置顶(IsTop)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_IsTop(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_IsTop("LX", "0004", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_IsTop_AdvanceSearch
        /// <summary>
        /// 取得是否置顶(IsTop)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_IsTop_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_IsTop("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_IsBest
        /// <summary>
        /// 根据指定条件取得推荐(IsBest)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_IsBest(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "DM";
            string strMC = "MC";
            RICH.Common.BM.Dictionary.DictionaryApplicationData 
                DictionaryAppData = new RICH.Common.BM.Dictionary.DictionaryApplicationData();
            DictionaryAppData.PageSize = 1000;
            DictionaryAppData.CurrentPage = 1;
            DictionaryAppData.Sort = true;
            DictionaryAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(DictionaryAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strParentName).SetValue(DictionaryAppData, strParent, null);
            }
            if (DictionaryAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.Dictionary.DictionaryApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(DictionaryAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.Dictionary.DictionaryApplicationLogic
                DictionaryAL = (RICH.Common.BM.Dictionary.DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.Dictionary.DictionaryApplicationLogic));
            DictionaryAL.Query(DictionaryAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(DictionaryAppData.ValidateColumnName(strParentName) == true) 
                || !(DictionaryAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_IsBest(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_IsBest(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_IsBest(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || DictionaryAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = DictionaryAppData.ResultSet;
                foreach (DataRow drChild in DictionaryAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_IsBest
        /// <summary>
        /// 取得推荐(IsBest)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_IsBest(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_IsBest("LX", "0004", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_IsBest_AdvanceSearch
        /// <summary>
        /// 取得推荐(IsBest)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_IsBest_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_IsBest("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_FBRJGH
        /// <summary>
        /// 根据指定条件取得发布人(FBRJGH)数据源
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_FBRJGH(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "UserID";
            string strMC = "UserNickName";
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData 
                T_PM_UserInfoAppData = new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData();
            T_PM_UserInfoAppData.PageSize = 1000;
            T_PM_UserInfoAppData.CurrentPage = 1;
            T_PM_UserInfoAppData.Sort = true;
            T_PM_UserInfoAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_PM_UserInfoAppData, strParent, null);
            }
            if (T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_PM_UserInfoAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic
                T_PM_UserInfoAL = (RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogic));
            T_PM_UserInfoAL.Query(T_PM_UserInfoAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_PM_UserInfoAppData.ValidateColumnName(strParentName) == true) 
                || !(T_PM_UserInfoAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_FBRJGH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_FBRJGH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "└" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "　" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_FBRJGH(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_PM_UserInfoAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_PM_UserInfoAppData.ResultSet;
                foreach (DataRow drChild in T_PM_UserInfoAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_FBRJGH
        /// <summary>
        /// 取得发布人(FBRJGH)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_FBRJGH(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_FBRJGH("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_FBRJGH_AdvanceSearch
        /// <summary>
        /// 取得发布人(FBRJGH)数据源
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_FBRJGH_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_FBRJGH("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
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
            T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
            appData = instanceT_BG_0601ApplicationLogic.Modify(appData);
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
            T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
            appData = instanceT_BG_0601ApplicationLogic.Count(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                T_BG_0601ApplicationData appData = new T_BG_0601ApplicationData();
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
            
                    case "FBH":
                        appData.FBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BT":
                        appData.BT = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBLM":
                        appData.FBLM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXLX":
                        appData.XXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXTPDZ":
                        appData.XXTPDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXNR":
                        appData.XXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FJXZDZ":
                        appData.FJXZDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXZT":
                        appData.XXZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "IsTop":
                        appData.IsTop = Convert.ToString(strFieldValue);
                        break;
            
                    case "TopSort":
                        appData.TopSort = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "IsBest":
                        appData.IsBest = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBRJGH":
                        appData.FBRJGH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBSJRQ":
                        appData.FBSJRQ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FBIP":
                        appData.FBIP = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                T_BG_0601ApplicationData appData = new T_BG_0601ApplicationData();
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
            
                    case "FBH":
                        appData.FBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BT":
                        appData.BT = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBLM":
                        appData.FBLM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXLX":
                        appData.XXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXTPDZ":
                        appData.XXTPDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXNR":
                        appData.XXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FJXZDZ":
                        appData.FJXZDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXZT":
                        appData.XXZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "IsTop":
                        appData.IsTop = Convert.ToString(strFieldValue);
                        break;
            
                    case "TopSort":
                        appData.TopSort = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "IsBest":
                        appData.IsBest = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBRJGH":
                        appData.FBRJGH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBSJRQ":
                        appData.FBSJRQ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FBIP":
                        appData.FBIP = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                T_BG_0601ApplicationData appData = new T_BG_0601ApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBH":
                        appData.FBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BT":
                        appData.BT = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBLM":
                        appData.FBLM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXLX":
                        appData.XXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXTPDZ":
                        appData.XXTPDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXNR":
                        appData.XXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FJXZDZ":
                        appData.FJXZDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXZT":
                        appData.XXZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "IsTop":
                        appData.IsTop = Convert.ToString(strFieldValue);
                        break;
            
                    case "TopSort":
                        appData.TopSort = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "IsBest":
                        appData.IsBest = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBRJGH":
                        appData.FBRJGH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBSJRQ":
                        appData.FBSJRQ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FBIP":
                        appData.FBIP = Convert.ToString(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_BG_0601ApplicationLogic.Modify(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                T_BG_0601ApplicationData appData = new T_BG_0601ApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_BG_0601ApplicationLogic.Delete(appData);
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
                T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                    = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
                T_BG_0601ApplicationData appData = new T_BG_0601ApplicationData();
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
            
                    case "FBH":
                        appData.FBH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BT":
                        appData.BT = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBLM":
                        appData.FBLM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXLX":
                        appData.XXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXTPDZ":
                        appData.XXTPDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXNR":
                        appData.XXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FJXZDZ":
                        appData.FJXZDZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "XXZT":
                        appData.XXZT = Convert.ToString(strFieldValue);
                        break;
            
                    case "IsTop":
                        appData.IsTop = Convert.ToString(strFieldValue);
                        break;
            
                    case "TopSort":
                        appData.TopSort = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "IsBest":
                        appData.IsBest = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBRJGH":
                        appData.FBRJGH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FBSJRQ":
                        appData.FBSJRQ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FBIP":
                        appData.FBIP = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BG_0601ApplicationLogic.Query(appData);
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
        //  FunctionName : ValidateFBH
        /// <summary>
        /// 发布号数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布号";
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
                            if (AJAX_IsExist("FBH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布号不存在，可以使用。";
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
        //  FunctionName : ValidateBT
        /// <summary>
        /// 标题数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateBT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "标题";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "100";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 100) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"标题已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"标题不存在，可以使用。";
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
        //  FunctionName : ValidateLanguageID
        /// <summary>
        /// 语言数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLanguageID(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "语言";
                validateData.Parameters[1] = "2";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 2, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LanguageID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"语言已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"语言不存在，可以使用。";
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
        //  FunctionName : ValidateFBLM
        /// <summary>
        /// 发布栏目数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBLM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布栏目";
                validateData.Parameters[1] = "8";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 8, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBLM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布栏目已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布栏目不存在，可以使用。";
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
        //  FunctionName : ValidateFBLMBatch
        /// <summary>
        /// 发布栏目Batch数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBLMBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布栏目";
                validateData.Parameters[1] = "8";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    validateData.IsNull = false;
                }
                else
                {
                    validateData.IsNull = true;
                }
            }
            catch (Exception)
            {
                validateData.Result = false;
            }
            return validateData;
        }
        
        //=====================================================================
        //  FunctionName : ValidateFBZT
        /// <summary>
        /// 发布专题数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBZT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布专题";
                validateData.Parameters[1] = "8";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 8, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBZT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布专题已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布专题不存在，可以使用。";
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
        //  FunctionName : ValidateXXLX
        /// <summary>
        /// 信息类型数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXXLX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "信息类型";
                validateData.Parameters[1] = "2";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 2, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XXLX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"信息类型已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"信息类型不存在，可以使用。";
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
        //  FunctionName : ValidateXXTPDZ
        /// <summary>
        /// 信息图片数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXXTPDZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "信息图片";
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
                            if (AJAX_IsExist("XXTPDZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"信息图片已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"信息图片不存在，可以使用。";
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
        //  FunctionName : ValidateXXNR
        /// <summary>
        /// 信息内容数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXXNR(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "信息内容";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XXNR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"信息内容已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"信息内容不存在，可以使用。";
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
        //  FunctionName : ValidateFJXZDZ
        /// <summary>
        /// 附件数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFJXZDZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "附件";
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
                            if (AJAX_IsExist("FJXZDZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"附件已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"附件不存在，可以使用。";
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
        //  FunctionName : ValidatePZRJGH
        /// <summary>
        /// 批准人数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidatePZRJGH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "批准人";
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
                            if (AJAX_IsExist("PZRJGH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"批准人已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"批准人不存在，可以使用。";
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
        //  FunctionName : ValidateXXZT
        /// <summary>
        /// 信息状态数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXXZT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "信息状态";
                validateData.Parameters[1] = "2";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 2, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XXZT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"信息状态已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"信息状态不存在，可以使用。";
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
        //  FunctionName : ValidateIsTop
        /// <summary>
        /// 是否置顶数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateIsTop(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "是否置顶";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 1, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("IsTop", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"是否置顶已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"是否置顶不存在，可以使用。";
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
        //  FunctionName : ValidateTopSort
        /// <summary>
        /// 置顶序号数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTopSort(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "置顶序号";
                validateData.Parameters[1] = "9999";
                validateData.Parameters[2] = "0";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateNumberRange(validateData.Value, 9999, 0) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0008, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("TopSort", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"置顶序号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"置顶序号不存在，可以使用。";
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
        //  FunctionName : ValidateIsBest
        /// <summary>
        /// 推荐数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateIsBest(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "推荐";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLength(validateData.Value, 1, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("IsBest", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"推荐已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"推荐不存在，可以使用。";
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
        //  FunctionName : ValidateYXSJRQ
        /// <summary>
        /// 有效时间数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYXSJRQ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "有效时间";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("YXSJRQ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"有效时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"有效时间不存在，可以使用。";
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
        //  FunctionName : ValidateFBRJGH
        /// <summary>
        /// 发布人数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBRJGH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布人";
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
                            if (AJAX_IsExist("FBRJGH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布人已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布人不存在，可以使用。";
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
        //  FunctionName : ValidateFBSJRQ
        /// <summary>
        /// 发布时间数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBSJRQ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布时间";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBSJRQ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布时间不存在，可以使用。";
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
        //  FunctionName : ValidateFBSJRQ
        /// <summary>
        /// 发布时间Begin数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBSJRQBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布时间开始值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBSJRQ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布时间不存在，可以使用。";
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
        //  FunctionName : ValidateFBSJRQ
        /// <summary>
        /// 发布时间End数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBSJRQEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布时间结束值";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBSJRQ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布时间不存在，可以使用。";
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
        //  FunctionName : ValidateFBIP
        /// <summary>
        /// 发布IP数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFBIP(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发布IP";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "20";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 20) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FBIP", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发布IP已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发布IP不存在，可以使用。";
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
        //  FunctionName : ValidateLLCS
        /// <summary>
        /// 浏览次数数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLLCS(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "浏览次数";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LLCS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"浏览次数已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"浏览次数不存在，可以使用。";
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
            T_BG_0601ApplicationData appData,
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
  
