/****************************************************** 
FileName:FilterReportWebUIBase.cs
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

namespace RICH.Common.BM.FilterReport
{
    public class FilterReportWebUIBase : WebUIBase
    {
        #region ��������
        public override string TableName { get { return "FilterReport"; } }
        public override string PurviewPrefix { get { return "FR"; } }
        public override string FilterReportType { get { return "FilterReport"; } }
        protected const Boolean DEFAULT_SORT = false;
        protected const string DEFAULT_SORT_FIELD = "BGCJSJ";

        #region Ȩ�ޱ�Ŷ���

        #endregion
        #endregion

        #region ��������
        protected FilterReportApplicationData appData;
        protected string strMessageInfo = string.Empty;
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        protected string strAJAXReturnValue = string.Empty;
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region ���ݲ�������
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                // �������
                appData = instanceFilterReportApplicationLogic.Add(appData);
                // ���������ر�
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "���"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.BGMC.ToString(), "���"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"�˱��", "������Ϣ"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                // �����޸�
                appData = instanceFilterReportApplicationLogic.Modify(appData);
                // ��ر������޸�
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "�޸�"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.BGMC.ToString(), "�޸�"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                appData = instanceFilterReportApplicationLogic.Query(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                appData = instanceFilterReportApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", (string)appData.ObjectIDBatch, "ɾ��"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                appData = instanceFilterReportApplicationLogic.Count(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        protected virtual Boolean GetCountInputParameter()
        {
            Boolean boolReturn = true;
            // ��֤�������
            if (ValidateRequestParamter() == true)
            {

                if (DataValidateManager.ValidateIsNull(Request["CountField"]) == false)
                {
                    if (DataValidateManager.ValidateStringLengthRange(Request["CountField"].ToString(), 1, 50) == false)
                    {
                          strMessageParam[0] = "ͳ�Ʒ�ʽ";
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
                      strMessageParam[0] = "ͳ�Ʒ�ʽ";
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
                // ��¼��־��ʼ
                string strLogTypeID = "A04";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0009, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // ��¼��־����

                // �Դ�����Ϣ���д���
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0027, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/ErrorPage/CommonErrorPage.aspx");
                Response.End();
            }
            return boolReturn;
        }
        #endregion

        #region ҳ��ؼ���ط���
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new FilterReportApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new FilterReportApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new FilterReportApplicationData();
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

        #region ȡ������Դ

        protected  virtual void GetTree_UserID(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "UserID";
            string strMC = "UserLoginName";
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
                                GetTree_UserID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_UserID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_UserID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_UserID(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserLoginName");
            GetTree_UserID("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_UserID_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserLoginName");
            GetTree_UserID("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_UserID_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserInfo");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserID");
            dsReturn.Tables["T_PM_UserInfo"].Columns.Add("UserLoginName");
            GetTree_UserID("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["UserID"]), GetValue(dr["UserLoginName"]), "UserID")).ToList();
        }

        
        protected  virtual void GetTree_GXBG(
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
                                GetTree_GXBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_GXBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_GXBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_GXBG(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_GXBG("LX", "0004", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_GXBG_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_GXBG("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_GXBG_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_GXBG("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["DM"]), GetValue(dr["MC"]), "GXBG")).ToList();
        }

        
        protected  virtual void GetTree_XTBG(
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
                                GetTree_XTBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_XTBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                                }
                            }
                        }
                        else
                        {
                            drChild[strMC] = "��" + drChild[strMC];
                            for (int i = 0; intLevel > i; i++)
                            {
                                drChild[strMC] = "��" + drChild[strMC];
                            }
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                            GetTree_XTBG(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        protected virtual object GetDataSource_XTBG(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XTBG("LX", "0004", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_XTBG_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XTBG("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<Triples<string, string, string>> GetList_XTBG_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XTBG("LX", "0004", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new Triples<string, string, string>(GetValue(dr["DM"]), GetValue(dr["MC"]), "XTBG")).ToList();
        }

        
        #endregion

        #region �޸������ֶ�
        protected virtual void ModifyAnyField()
        {
            FilterReportApplicationLogic instanceFilterReportApplicationLogic
                = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
            appData = instanceFilterReportApplicationLogic.Modify(appData);
        }
        #endregion

        #region ͳ�������ֶ�
        protected virtual void CountAnyField()
        {
            FilterReportApplicationLogic instanceFilterReportApplicationLogic
                = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
            appData = instanceFilterReportApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX��ط���
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                FilterReportApplicationData appData = new FilterReportApplicationData();
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
            
                    case "BGMC":
                        appData.BGMC = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGLX":
                        appData.BGLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "GXBG":
                        appData.GXBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "XTBG":
                        appData.XTBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCXTJ":
                        appData.BGCXTJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCJSJ":
                        appData.BGCJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceFilterReportApplicationLogic.Query(appData);
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
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                FilterReportApplicationData appData = new FilterReportApplicationData();
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
            
                    case "BGMC":
                        appData.BGMC = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGLX":
                        appData.BGLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "GXBG":
                        appData.GXBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "XTBG":
                        appData.XTBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCXTJ":
                        appData.BGCXTJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCJSJ":
                        appData.BGCJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceFilterReportApplicationLogic.Query(appData);
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
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                FilterReportApplicationData appData = new FilterReportApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceFilterReportApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGMC":
                        appData.BGMC = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGLX":
                        appData.BGLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "GXBG":
                        appData.GXBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "XTBG":
                        appData.XTBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCXTJ":
                        appData.BGCXTJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCJSJ":
                        appData.BGCJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    }
                    appData = instanceFilterReportApplicationLogic.Modify(appData);
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
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                FilterReportApplicationData appData = new FilterReportApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceFilterReportApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceFilterReportApplicationLogic.Delete(appData);
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
                FilterReportApplicationLogic instanceFilterReportApplicationLogic
                    = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
                FilterReportApplicationData appData = new FilterReportApplicationData();
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
            
                    case "BGMC":
                        appData.BGMC = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGLX":
                        appData.BGLX = Convert.ToString(strFieldValue);
                        break;
            
                    case "GXBG":
                        appData.GXBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "XTBG":
                        appData.XTBG = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCXTJ":
                        appData.BGCXTJ = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGCJSJ":
                        appData.BGCJSJ = Convert.ToDateTime(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceFilterReportApplicationLogic.Query(appData);
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
                                 strAJAXReturnValue = @"<font color=""red"">�Ѵ��ڣ����ٻ�һ����</font>";
                            }
                            else
                            {
                                strAJAXReturnValue = @"�����ڣ�����ʹ�á�";
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
                                strAJAXReturnValue = "�����ɹ���";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";
                            }
                            break;
                        case "05":
                            strObjectID = strInputArg[1];
                            if (AJAX_Delete(strObjectID) == true)
                            {
                                strAJAXReturnValue = @"�����ɹ���";
                            }
                            else
                            {
                                 strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                strAJAXReturnValue = "ͨѶ����";
            }
        }

        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region ��֤����

        protected virtual ValidateData ValidateObjectID(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateUniqueIdentifierFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0012, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("ObjectID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateBGMC(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��������";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "50";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 50) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BGMC", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�������Ʋ����ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateUserID(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "�û����";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "50";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 50) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("UserID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�û�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�û���Ų����ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateBGLX(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��������";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "50";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 50) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BGLX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�������Ͳ����ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateGXBG(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "������";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "1";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 1) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("GXBG", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����治���ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateXTBG(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "ϵͳ����";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "1";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 1) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XTBG", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ϵͳ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ϵͳ���治���ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateBGCXTJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "��������";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "4000";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 4000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BGCXTJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�������������ڣ�����ʹ�á�";
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
    
        protected virtual ValidateData ValidateBGCJSJ(object objValidateData, bool boolNullable, bool boolExist)
        {
            ValidateData validateData = new ValidateData();
            try
            {
                // ��ʼ������
                validateData.Result = true;
                validateData.Message = string.Empty;
                validateData.Parameters = new string[5];
                validateData.IsNull = false;
                validateData.IsExist = false;
                
                // ���������ֵ
                validateData.Value = objValidateData;
                validateData.Nullable = boolNullable;
                validateData.Exist = boolExist;
                validateData.Parameters[0] = "����ʱ��";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateDateFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0005, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("BGCJSJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����ʱ�䲻���ڣ�����ʹ�á�";
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

        #region ��ȡ��ر���Ϣ

        #endregion

        #region ��ȡ��ر��������ģ��

        #endregion    

        #region ��ر���������
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
            FilterReportApplicationData appData,
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
  
