/****************************************************** 
FileName:ShortMessageWebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;
using RICH.Common.Utilities;
using System.Collections.Generic;

namespace RICH.Common.BM.ShortMessage
{
    public class ShortMessageWebUIBase : WebUIBase
    {
        #region 常量定义
        public override string TableName { get { return "ShortMessage"; } }
        public override string PurviewPrefix { get { return "DXX"; } }
        public override string FilterReportType { get { return "ShortMessage"; } }
        protected const Boolean DEFAULT_SORT = false;
        protected const string DEFAULT_SORT_FIELD = "FSSJ";

        #region 权限编号定义

        /// <summary>
        /// 发件箱权限
        /// </summary>
        public string FJX_PURVIEW_ID { get { return "DXX51";} }
        public string FJX_ADD_PURVIEW_ID { get { return "DXX51_Add";} }
        public string FJX_MODIFY_PURVIEW_ID { get { return "DXX51_Modify";} }
        public string FJX_DETAIL_PURVIEW_ID { get { return "DXX51_Detail";} }
        
        /// <summary>
        /// 收件箱权限
        /// </summary>
        public string SJX_PURVIEW_ID { get { return "DXX52";} }
        public string SJX_ADD_PURVIEW_ID { get { return "DXX52_Add";} }
        public string SJX_MODIFY_PURVIEW_ID { get { return "DXX52_Modify";} }
        public string SJX_DETAIL_PURVIEW_ID { get { return "DXX52_Detail";} }
        
        #endregion
        #endregion

        #region 变量定义
        protected ShortMessageApplicationData appData;
        protected string strMessageInfo = string.Empty;
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        protected string strAJAXReturnValue = string.Empty;
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region 数据操作方法
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                // 添加主表
                appData = instanceShortMessageApplicationLogic.Add(appData);
                // 批量添加相关表
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"消息", "添加"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "消息", appData.DXXBT.ToString(), "添加"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"此编号", "消息"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                // 主表修改
                appData = instanceShortMessageApplicationLogic.Modify(appData);
                // 相关表批量修改
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"消息", "修改"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "消息", appData.DXXBT.ToString(), "修改"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                appData = instanceShortMessageApplicationLogic.Query(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                appData = instanceShortMessageApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "消息", (string)appData.ObjectIDBatch, "删除"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                appData = instanceShortMessageApplicationLogic.Count(appData);
            }
            else
            {
                // 对错误消息进行处理
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

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
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new ShortMessageApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new ShortMessageApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new ShortMessageApplicationData();
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

        protected  virtual void GetTree_FSR(
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
                                GetTree_FSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_FSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_FSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_FSR(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_FSR("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_FSR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_FSR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_FSR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_FSR("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "FSR")).ToList();
        }

        
        protected  virtual void GetTree_FSBM(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "DWBH";
            string strMC = "DWMC";
            RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationData 
                T_BM_DWXXAppData = new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationData();
            T_BM_DWXXAppData.PageSize = 1000;
            T_BM_DWXXAppData.CurrentPage = 1;
            T_BM_DWXXAppData.Sort = true;
            T_BM_DWXXAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_BM_DWXXAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_BM_DWXXAppData, strParent, null);
            }
            if (T_BM_DWXXAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_BM_DWXXAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogic
                T_BM_DWXXAL = (RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogic));
            T_BM_DWXXAL.Query(T_BM_DWXXAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_BM_DWXXAppData.ValidateColumnName(strParentName) == true) 
                || !(T_BM_DWXXAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_BM_DWXXAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_FSBM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_DWXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_FSBM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_FSBM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_BM_DWXXAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_BM_DWXXAppData.ResultSet;
                foreach (DataRow drChild in T_BM_DWXXAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_FSBM(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_DWXX");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_FSBM("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_FSBM_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_DWXX");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_FSBM("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_FSBM_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_DWXX");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_FSBM("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["DWBH"]), GetValue(dr["DWMC"]), "FSBM")).ToList();
        }

        
        protected  virtual void GetTree_JSR(
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
                                GetTree_JSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_JSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_JSR(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_JSR(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_JSR("null", "null", true, "SubjectID", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_JSR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_JSR("null", "null", true, "SubjectID", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_JSR_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserNickName");
            GetTree_JSR("null", "null", true, "SubjectID", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserNickName"]), "JSR")).ToList();
        }

        
        #endregion

        #region 修改任意字段
        protected virtual void ModifyAnyField()
        {
            ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
            appData = instanceShortMessageApplicationLogic.Modify(appData);
        }
        #endregion

        #region 统计任意字段
        protected virtual void CountAnyField()
        {
            ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
            appData = instanceShortMessageApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX相关方法
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                ShortMessageApplicationData appData = new ShortMessageApplicationData();
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
            
                    case "DXXBT":
                        appData.DXXBT = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXLX":
                        appData.DXXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXNR":
                        appData.DXXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXFJ":
                        appData.DXXFJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSSJ":
                        appData.FSSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FSR":
                        appData.FSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSBM":
                        appData.FSBM = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSIP":
                        appData.FSIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSR":
                        appData.JSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFCK":
                        appData.SFCK = Convert.ToBoolean(strFieldValue);
                        break;
            
                    case "CKSJ":
                        appData.CKSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceShortMessageApplicationLogic.Query(appData);
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

        protected virtual string AJAX_QueryDataSet(string strFieldName, string strFieldValue)
        {
            string strReturn = string.Empty;
            try
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                ShortMessageApplicationData appData = new ShortMessageApplicationData();
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
            
                    case "DXXBT":
                        appData.DXXBT = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXLX":
                        appData.DXXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXNR":
                        appData.DXXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXFJ":
                        appData.DXXFJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSSJ":
                        appData.FSSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FSR":
                        appData.FSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSBM":
                        appData.FSBM = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSIP":
                        appData.FSIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSR":
                        appData.JSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFCK":
                        appData.SFCK = Convert.ToBoolean(strFieldValue);
                        break;
            
                    case "CKSJ":
                        appData.CKSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceShortMessageApplicationLogic.Query(appData);
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

        protected virtual bool AJAX_Modify(string strFieldName, string strFieldValue, string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                ShortMessageApplicationData appData = new ShortMessageApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceShortMessageApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXBT":
                        appData.DXXBT = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXLX":
                        appData.DXXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXNR":
                        appData.DXXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXFJ":
                        appData.DXXFJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSSJ":
                        appData.FSSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FSR":
                        appData.FSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSBM":
                        appData.FSBM = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSIP":
                        appData.FSIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSR":
                        appData.JSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFCK":
                        appData.SFCK = Convert.ToBoolean(strFieldValue);
                        break;
            
                    case "CKSJ":
                        appData.CKSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    }
                    appData = instanceShortMessageApplicationLogic.Modify(appData);
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

        protected virtual bool AJAX_Delete(string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                ShortMessageApplicationData appData = new ShortMessageApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceShortMessageApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceShortMessageApplicationLogic.Delete(appData);
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

        protected virtual bool AJAX_IsExist(string strFieldName, string strFieldValue)
        {
            bool boolReturn = false;
            try
            {
                ShortMessageApplicationLogic instanceShortMessageApplicationLogic
                    = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
                ShortMessageApplicationData appData = new ShortMessageApplicationData();
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
            
                    case "DXXBT":
                        appData.DXXBT = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXLX":
                        appData.DXXLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXNR":
                        appData.DXXNR = Convert.ToString(strFieldValue);
                        break;
            
                    case "DXXFJ":
                        appData.DXXFJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSSJ":
                        appData.FSSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "FSR":
                        appData.FSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSBM":
                        appData.FSBM = Convert.ToString(strFieldValue);
                        break;
            
                    case "FSIP":
                        appData.FSIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "JSR":
                        appData.JSR = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFCK":
                        appData.SFCK = Convert.ToBoolean(strFieldValue);
                        break;
            
                    case "CKSJ":
                        appData.CKSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceShortMessageApplicationLogic.Query(appData);
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

        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region 验证数据

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
    
        protected virtual ValidateData ValidateDXXBT(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("DXXBT", validateData.Value.ToString()) == true)
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
    
        protected virtual ValidateData ValidateDXXLX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "类型";
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
                            if (AJAX_IsExist("DXXLX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"类型已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"类型不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateDXXNR(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "内容";
                validateData.Parameters[1] = "0";
                validateData.Parameters[2] = "4000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringFormat(validateData.Value, 0, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0023, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("DXXNR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"内容已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"内容不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateDXXFJ(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("DXXFJ", validateData.Value.ToString()) == true)
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
    
        protected virtual ValidateData ValidateFSSJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送时间";
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
                            if (AJAX_IsExist("FSSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送时间不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateFSSJBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送时间开始值";
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
                            if (AJAX_IsExist("FSSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送时间不存在，可以使用。";
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

        protected virtual ValidateData ValidateFSSJEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送时间结束值";
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
                            if (AJAX_IsExist("FSSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送时间不存在，可以使用。";
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
        
        protected virtual ValidateData ValidateFSR(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送人";
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
                            if (AJAX_IsExist("FSR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送人已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送人不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateFSBM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送部门";
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
                            if (AJAX_IsExist("FSBM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送部门已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送部门不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateFSIP(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "发送IP";
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
                            if (AJAX_IsExist("FSIP", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"发送IP已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"发送IP不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateJSR(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "接收人";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // 空验证
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // 数值格式验证
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // 数据存在验证
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("JSR", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"接收人已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"接收人不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateJSRBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "接收人";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

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
        
        protected virtual ValidateData ValidateSFCK(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "查看状态";
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
                            if (AJAX_IsExist("SFCK", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"查看状态已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"查看状态不存在，可以使用。";
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
    
        protected virtual ValidateData ValidateCKSJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "查看时间";
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
                            if (AJAX_IsExist("CKSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"查看时间已存在，请再换一个。";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"查看时间不存在，可以使用。";
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
        protected virtual void RelatedTableAddBatch()
        {

        }
        
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
            ShortMessageApplicationData appData,
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
  
