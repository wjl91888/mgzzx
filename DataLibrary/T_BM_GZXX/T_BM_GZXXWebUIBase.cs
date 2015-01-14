/****************************************************** 
FileName:T_BM_GZXXWebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;

namespace RICH.Common.BM.T_BM_GZXX
{
    public class T_BM_GZXXWebUIBase : WebUIBase
    {
        #region 常量定义
        /// <summary>
        /// 数据类型
        /// </summary>
        public override string FilterReportType { get { return "T_BM_GZXX"; } }
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
        protected const string DEFAULT_SORT_FIELD = "FFGZNY";
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
        public override string WEBUI_ADD_FILENAME { get { return "T_BM_GZXXWebUIAdd.aspx"; } }
        /// <summary>
        /// 查询页面文件名
        /// </summary>
        public override string WEBUI_SEARCH_FILENAME { get { return "T_BM_GZXXWebUISearch.aspx"; } }
        /// <summary>
        /// 详情页面文件名
        /// </summary>
        public override string WEBUI_DETAIL_FILENAME { get { return "T_BM_GZXXWebUIDetail.aspx"; } }
        /// <summary>
        /// 统计页面文件名
        /// </summary>
        public override string WEBUI_STATISTIC_FILENAME { get { return "T_BM_GZXXWebUIStatistic.aspx";} }
        #endregion

        #region 权限编号定义
        /// <summary>
        /// 添加权限
        /// </summary>
        public override string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "GZ01";} }
        /// <summary>
        /// 修改权限
        /// </summary>
        public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "GZ02";} }
        /// <summary>
        /// 浏览权限
        /// </summary>
        public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID  { get { return "GZ04";} }
        /// <summary>
        /// 详情权限
        /// </summary>
        public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID  { get { return "GZ05";} }
        /// <summary>
        /// 统计权限
        /// </summary>
        public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID  { get { return "GZ06";} }
        /// <summary>
        /// 删除权限
        /// </summary>
        public override string OPERATION_DELETE_PURVIEW_ID  { get { return "GZ07";} }
        /// <summary>
        /// 导出权限
        /// </summary>
        public override string OPERATION_EXPORTALL_PURVIEW_ID { get { return "GZ08";} }
        /// <summary>
        /// 导入权限
        /// </summary>
        public override string OPERATION_IMPORT_PURVIEW_ID { get { return "GZ09";} }
        /// <summary>
        /// 导入数据集权限
        /// </summary>
        public override string OPERATION_IMPORT_DS_PURVIEW_ID { get { return "GZ10";} }
        #endregion
        #endregion

        #region 变量定义
        /// <summary>
        /// 数据实体对象
        /// </summary>
        protected T_BM_GZXXApplicationData appData;
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                // 添加主表
                appData = instanceT_BM_GZXXApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"工资信息", "添加"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "工资信息", appData.XM.ToString(), "添加"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"此编号", "工资信息"}, strMessageInfo);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                // 主表修改
                appData = instanceT_BM_GZXXApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"工资信息", "修改"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "工资信息", appData.XM.ToString(), "修改"});
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "工资信息", (string)appData.ObjectIDBatch, "删除"});
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Count(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
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
        //  FunctionName : btnAddConfirm_Click
        /// <summary>
        /// 确认添加按钮事件
        /// </summary>
        //=====================================================================
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_BM_GZXXApplicationData();
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
            appData = new T_BM_GZXXApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
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
                    appData = new T_BM_GZXXApplicationData();
                    appData.ObjectIDBatch = (string)Request["ObjectIDBatch"];
                    appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.BATCH;
                    DeleteRecord();
                    break;
                default:
                    break;
            }
            Initalize();
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
            T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
            appData = instanceT_BM_GZXXApplicationLogic.Modify(appData);
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
            T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
            appData = instanceT_BM_GZXXApplicationLogic.Count(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                T_BM_GZXXApplicationData appData = new T_BM_GZXXApplicationData();
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
            
                    case "XM":
                        appData.XM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FFGZNY":
                        appData.FFGZNY = Convert.ToString(strFieldValue);
                        break;
            
                    case "JCGZ":
                        appData.JCGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JSDJGZ":
                        appData.JSDJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZWGZ":
                        appData.ZWGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JBGZ":
                        appData.JBGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKDQJT":
                        appData.JKDQJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKTSGWJT":
                        appData.JKTSGWJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GLGZ":
                        appData.GLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "XJGZ":
                        appData.XJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "TGBF":
                        appData.TGBF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DHF":
                        appData.DHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DSZNF":
                        appData.DSZNF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "FNWSHLF":
                        appData.FNWSHLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "HLF":
                        appData.HLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JJ":
                        appData.JJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JTF":
                        appData.JTF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JHLGZ":
                        appData.JHLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JT":
                        appData.JT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "BF":
                        appData.BF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTBT":
                        appData.QTBT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DFXJT":
                        appData.DFXJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YFX":
                        appData.YFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTKK":
                        appData.QTKK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SYBX":
                        appData.SYBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDNQF":
                        appData.SDNQF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDS":
                        appData.SDS = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLBX":
                        appData.YLBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLIBX":
                        appData.YLIBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YSSHF":
                        appData.YSSHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZFGJJ":
                        appData.ZFGJJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KFX":
                        appData.KFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SFGZ":
                        appData.SFGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GZKKSM":
                        appData.GZKKSM = Convert.ToString(strFieldValue);
                        break;
            
                    case "TJSJ":
                        appData.TJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                T_BM_GZXXApplicationData appData = new T_BM_GZXXApplicationData();
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
            
                    case "XM":
                        appData.XM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FFGZNY":
                        appData.FFGZNY = Convert.ToString(strFieldValue);
                        break;
            
                    case "JCGZ":
                        appData.JCGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JSDJGZ":
                        appData.JSDJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZWGZ":
                        appData.ZWGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JBGZ":
                        appData.JBGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKDQJT":
                        appData.JKDQJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKTSGWJT":
                        appData.JKTSGWJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GLGZ":
                        appData.GLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "XJGZ":
                        appData.XJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "TGBF":
                        appData.TGBF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DHF":
                        appData.DHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DSZNF":
                        appData.DSZNF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "FNWSHLF":
                        appData.FNWSHLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "HLF":
                        appData.HLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JJ":
                        appData.JJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JTF":
                        appData.JTF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JHLGZ":
                        appData.JHLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JT":
                        appData.JT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "BF":
                        appData.BF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTBT":
                        appData.QTBT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DFXJT":
                        appData.DFXJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YFX":
                        appData.YFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTKK":
                        appData.QTKK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SYBX":
                        appData.SYBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDNQF":
                        appData.SDNQF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDS":
                        appData.SDS = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLBX":
                        appData.YLBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLIBX":
                        appData.YLIBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YSSHF":
                        appData.YSSHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZFGJJ":
                        appData.ZFGJJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KFX":
                        appData.KFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SFGZ":
                        appData.SFGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GZKKSM":
                        appData.GZKKSM = Convert.ToString(strFieldValue);
                        break;
            
                    case "TJSJ":
                        appData.TJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                T_BM_GZXXApplicationData appData = new T_BM_GZXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "XM":
                        appData.XM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FFGZNY":
                        appData.FFGZNY = Convert.ToString(strFieldValue);
                        break;
            
                    case "JCGZ":
                        appData.JCGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JSDJGZ":
                        appData.JSDJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZWGZ":
                        appData.ZWGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JBGZ":
                        appData.JBGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKDQJT":
                        appData.JKDQJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKTSGWJT":
                        appData.JKTSGWJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GLGZ":
                        appData.GLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "XJGZ":
                        appData.XJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "TGBF":
                        appData.TGBF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DHF":
                        appData.DHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DSZNF":
                        appData.DSZNF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "FNWSHLF":
                        appData.FNWSHLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "HLF":
                        appData.HLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JJ":
                        appData.JJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JTF":
                        appData.JTF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JHLGZ":
                        appData.JHLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JT":
                        appData.JT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "BF":
                        appData.BF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTBT":
                        appData.QTBT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DFXJT":
                        appData.DFXJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YFX":
                        appData.YFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTKK":
                        appData.QTKK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SYBX":
                        appData.SYBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDNQF":
                        appData.SDNQF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDS":
                        appData.SDS = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLBX":
                        appData.YLBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLIBX":
                        appData.YLIBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YSSHF":
                        appData.YSSHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZFGJJ":
                        appData.ZFGJJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KFX":
                        appData.KFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SFGZ":
                        appData.SFGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GZKKSM":
                        appData.GZKKSM = Convert.ToString(strFieldValue);
                        break;
            
                    case "TJSJ":
                        appData.TJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_BM_GZXXApplicationLogic.Modify(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                T_BM_GZXXApplicationData appData = new T_BM_GZXXApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_BM_GZXXApplicationLogic.Delete(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                T_BM_GZXXApplicationData appData = new T_BM_GZXXApplicationData();
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
            
                    case "XM":
                        appData.XM = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "FFGZNY":
                        appData.FFGZNY = Convert.ToString(strFieldValue);
                        break;
            
                    case "JCGZ":
                        appData.JCGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JSDJGZ":
                        appData.JSDJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZWGZ":
                        appData.ZWGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JBGZ":
                        appData.JBGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKDQJT":
                        appData.JKDQJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JKTSGWJT":
                        appData.JKTSGWJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GLGZ":
                        appData.GLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "XJGZ":
                        appData.XJGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "TGBF":
                        appData.TGBF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DHF":
                        appData.DHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DSZNF":
                        appData.DSZNF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "FNWSHLF":
                        appData.FNWSHLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "HLF":
                        appData.HLF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JJ":
                        appData.JJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JTF":
                        appData.JTF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JHLGZ":
                        appData.JHLGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "JT":
                        appData.JT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "BF":
                        appData.BF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTBT":
                        appData.QTBT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "DFXJT":
                        appData.DFXJT = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YFX":
                        appData.YFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "QTKK":
                        appData.QTKK = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SYBX":
                        appData.SYBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDNQF":
                        appData.SDNQF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SDS":
                        appData.SDS = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLBX":
                        appData.YLBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YLIBX":
                        appData.YLIBX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "YSSHF":
                        appData.YSSHF = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "ZFGJJ":
                        appData.ZFGJJ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "KFX":
                        appData.KFX = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "SFGZ":
                        appData.SFGZ = Convert.ToDouble(strFieldValue);
                        break;
            
                    case "GZKKSM":
                        appData.GZKKSM = Convert.ToString(strFieldValue);
                        break;
            
                    case "TJSJ":
                        appData.TJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
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
        //  FunctionName : ValidateXM
        /// <summary>
        /// 姓名数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "姓名";
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
                            if (AJAX_IsExist("XM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"姓名已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"姓名不存在，可以使用。";
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
        //  FunctionName : ValidateXB
        /// <summary>
        /// 性别数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXB(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "性别";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 2) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XB", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"性别已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"性别不存在，可以使用。";
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
        //  FunctionName : ValidateSFZH
        /// <summary>
        /// 身份证号数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFZH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "身份证号";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "18";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 18) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SFZH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"身份证号已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"身份证号不存在，可以使用。";
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
        //  FunctionName : ValidateFFGZNY
        /// <summary>
        /// 日期数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFFGZNY(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "日期";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "6";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 6) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FFGZNY", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"日期已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"日期不存在，可以使用。";
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
        //  FunctionName : ValidateJCGZ
        /// <summary>
        /// 基础工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJCGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "基础工资";
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
                            if (AJAX_IsExist("JCGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"基础工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"基础工资不存在，可以使用。";
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
        //  FunctionName : ValidateJSDJGZ
        /// <summary>
        /// 技术等级工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJSDJGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "技术等级工资";
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
                            if (AJAX_IsExist("JSDJGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"技术等级工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"技术等级工资不存在，可以使用。";
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
        //  FunctionName : ValidateZWGZ
        /// <summary>
        /// 职务工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZWGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "职务工资";
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
                            if (AJAX_IsExist("ZWGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"职务工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"职务工资不存在，可以使用。";
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
        //  FunctionName : ValidateJBGZ
        /// <summary>
        /// 级别工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJBGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "级别工资";
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
                            if (AJAX_IsExist("JBGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"级别工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"级别工资不存在，可以使用。";
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
        //  FunctionName : ValidateJKDQJT
        /// <summary>
        /// 艰苦地区津贴数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJKDQJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "艰苦地区津贴";
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
                            if (AJAX_IsExist("JKDQJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"艰苦地区津贴已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"艰苦地区津贴不存在，可以使用。";
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
        //  FunctionName : ValidateJKTSGWJT
        /// <summary>
        /// 艰苦特岗津贴数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJKTSGWJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "艰苦特岗津贴";
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
                            if (AJAX_IsExist("JKTSGWJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"艰苦特岗津贴已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"艰苦特岗津贴不存在，可以使用。";
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
        //  FunctionName : ValidateGLGZ
        /// <summary>
        /// 工龄工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateGLGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "工龄工资";
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
                            if (AJAX_IsExist("GLGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"工龄工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"工龄工资不存在，可以使用。";
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
        //  FunctionName : ValidateXJGZ
        /// <summary>
        /// 薪级工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXJGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "薪级工资";
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
                            if (AJAX_IsExist("XJGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"薪级工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"薪级工资不存在，可以使用。";
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
        //  FunctionName : ValidateTGBF
        /// <summary>
        /// 10%提高部分数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTGBF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "10%提高部分";
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
                            if (AJAX_IsExist("TGBF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"10%提高部分已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"10%提高部分不存在，可以使用。";
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
        //  FunctionName : ValidateDHF
        /// <summary>
        /// 电话费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDHF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "电话费";
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
                            if (AJAX_IsExist("DHF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"电话费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"电话费不存在，可以使用。";
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
        //  FunctionName : ValidateDSZNF
        /// <summary>
        /// 独生子女费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDSZNF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "独生子女费";
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
                            if (AJAX_IsExist("DSZNF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"独生子女费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"独生子女费不存在，可以使用。";
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
        //  FunctionName : ValidateFNWSHLF
        /// <summary>
        /// 妇女卫生费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFNWSHLF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "妇女卫生费";
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
                            if (AJAX_IsExist("FNWSHLF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"妇女卫生费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"妇女卫生费不存在，可以使用。";
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
        //  FunctionName : ValidateHLF
        /// <summary>
        /// 护理费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateHLF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "护理费";
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
                            if (AJAX_IsExist("HLF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"护理费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"护理费不存在，可以使用。";
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
        //  FunctionName : ValidateJJ
        /// <summary>
        /// 奖金数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "奖金";
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
                            if (AJAX_IsExist("JJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"奖金已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"奖金不存在，可以使用。";
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
        //  FunctionName : ValidateJTF
        /// <summary>
        /// 交通费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJTF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "交通费";
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
                            if (AJAX_IsExist("JTF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"交通费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"交通费不存在，可以使用。";
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
        //  FunctionName : ValidateJHLGZ
        /// <summary>
        /// 教护龄工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJHLGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "教护龄工资";
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
                            if (AJAX_IsExist("JHLGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"教护龄工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"教护龄工资不存在，可以使用。";
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
        //  FunctionName : ValidateJT
        /// <summary>
        /// 津贴数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "津贴";
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
                            if (AJAX_IsExist("JT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"津贴已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"津贴不存在，可以使用。";
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
        //  FunctionName : ValidateBF
        /// <summary>
        /// 补发数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateBF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "补发";
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
                            if (AJAX_IsExist("BF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"补发已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"补发不存在，可以使用。";
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
        //  FunctionName : ValidateQTBT
        /// <summary>
        /// 其他补贴数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateQTBT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "其他补贴";
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
                            if (AJAX_IsExist("QTBT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"其他补贴已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"其他补贴不存在，可以使用。";
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
        //  FunctionName : ValidateDFXJT
        /// <summary>
        /// 地方性津贴数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDFXJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "地方性津贴";
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
                            if (AJAX_IsExist("DFXJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"地方性津贴已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"地方性津贴不存在，可以使用。";
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
        //  FunctionName : ValidateYFX
        /// <summary>
        /// 应发项数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "应发项";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"应发项已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"应发项不存在，可以使用。";
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
        //  FunctionName : ValidateYFX
        /// <summary>
        /// 应发项Begin数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFXBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "应发项开始值";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"应发项已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"应发项不存在，可以使用。";
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
        //  FunctionName : ValidateYFX
        /// <summary>
        /// 应发项End数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFXEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "应发项结束值";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"应发项已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"应发项不存在，可以使用。";
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
        //  FunctionName : ValidateQTKK
        /// <summary>
        /// 其他扣款数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateQTKK(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "其他扣款";
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
                            if (AJAX_IsExist("QTKK", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"其他扣款已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"其他扣款不存在，可以使用。";
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
        //  FunctionName : ValidateSYBX
        /// <summary>
        /// 失业保险数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSYBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "失业保险";
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
                            if (AJAX_IsExist("SYBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"失业保险已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"失业保险不存在，可以使用。";
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
        //  FunctionName : ValidateSDNQF
        /// <summary>
        /// 水电暖气费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSDNQF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "水电暖气费";
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
                            if (AJAX_IsExist("SDNQF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"水电暖气费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"水电暖气费不存在，可以使用。";
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
        //  FunctionName : ValidateSDS
        /// <summary>
        /// 所得税数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSDS(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "所得税";
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
                            if (AJAX_IsExist("SDS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"所得税已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"所得税不存在，可以使用。";
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
        //  FunctionName : ValidateYLBX
        /// <summary>
        /// 养老保险数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYLBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "养老保险";
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
                            if (AJAX_IsExist("YLBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"养老保险已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"养老保险不存在，可以使用。";
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
        //  FunctionName : ValidateYLIBX
        /// <summary>
        /// 医疗保险数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYLIBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "医疗保险";
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
                            if (AJAX_IsExist("YLIBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"医疗保险已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"医疗保险不存在，可以使用。";
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
        //  FunctionName : ValidateYSSHF
        /// <summary>
        /// 遗属生活费数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYSSHF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "遗属生活费";
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
                            if (AJAX_IsExist("YSSHF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"遗属生活费已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"遗属生活费不存在，可以使用。";
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
        //  FunctionName : ValidateZFGJJ
        /// <summary>
        /// 住房公积金数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZFGJJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "住房公积金";
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
                            if (AJAX_IsExist("ZFGJJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"住房公积金已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"住房公积金不存在，可以使用。";
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
        //  FunctionName : ValidateKFX
        /// <summary>
        /// 扣发项数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateKFX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "扣发项";
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
                            if (AJAX_IsExist("KFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"扣发项已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"扣发项不存在，可以使用。";
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
        //  FunctionName : ValidateSFGZ
        /// <summary>
        /// 实发工资数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "实发工资";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"实发工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"实发工资不存在，可以使用。";
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
        //  FunctionName : ValidateSFGZ
        /// <summary>
        /// 实发工资Begin数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "实发工资开始值";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"实发工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"实发工资不存在，可以使用。";
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
        //  FunctionName : ValidateSFGZ
        /// <summary>
        /// 实发工资End数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "实发工资结束值";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"实发工资已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"实发工资不存在，可以使用。";
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
        //  FunctionName : ValidateGZKKSM
        /// <summary>
        /// 说明数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateGZKKSM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[2] = "1000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 1000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("GZKKSM", validateData.Value.ToString()) == true)
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
    
        //=====================================================================
        //  FunctionName : ValidateTJSJ
        /// <summary>
        /// 添加时间数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTJSJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "添加时间";
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
                            if (AJAX_IsExist("TJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"添加时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"添加时间不存在，可以使用。";
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
        //  FunctionName : ValidateTJSJ
        /// <summary>
        /// 添加时间Begin数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTJSJBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "添加时间开始值";
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
                            if (AJAX_IsExist("TJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"添加时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"添加时间不存在，可以使用。";
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
        //  FunctionName : ValidateTJSJ
        /// <summary>
        /// 添加时间End数值验证方法
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTJSJEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "添加时间结束值";
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
                            if (AJAX_IsExist("TJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"添加时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"添加时间不存在，可以使用。";
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
            T_BM_GZXXApplicationData appData,
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
  
