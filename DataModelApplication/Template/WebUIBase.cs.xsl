<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIBase.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUIBase.cs
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

namespace RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    public class <xsl:value-of select="/NewDataSet/TableName"/>WebUIBase : WebUIBase
    {
        #region ��������
        public override string TableName { get { return "<xsl:value-of select="/NewDataSet/TableName"/>"; } }
        public override string PurviewPrefix { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/>"; } }
        public override string FilterReportType { get { return "<xsl:value-of select="/NewDataSet/TableName"/>"; } }
        protected const Boolean DEFAULT_SORT = <xsl:value-of select="/NewDataSet/Sort"/>;
        protected const string DEFAULT_SORT_FIELD = "<xsl:value-of select="/NewDataSet/SortField"/>";

        #region Ȩ�ޱ�Ŷ���
<xsl:for-each select="/NewDataSet/CustomPermissionConfig">
        <xsl:if test="CustomPermissionType">
        /// <summary>
        /// <xsl:value-of select="CustomPermissionRemark"/>Ȩ��
        /// </summary>
        <xsl:if test="CustomPermissionType = 'AddPage'">
        public string <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>";} }
        public string <xsl:value-of select="CustomPermissionName"/>_MODIFY_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify";} }</xsl:if>
        <xsl:if test="CustomPermissionType = 'SearchPage'">
        public string <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>";} }
        public string <xsl:value-of select="CustomPermissionName"/>_ADD_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Add";} }
        public string <xsl:value-of select="CustomPermissionName"/>_MODIFY_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify";} }
        public string <xsl:value-of select="CustomPermissionName"/>_DETAIL_PURVIEW_ID { get { return "<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Detail";} }
        </xsl:if></xsl:if>
</xsl:for-each>
        #endregion
        #endregion

        #region ��������
        protected <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData;
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                // �������
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Add(appData);
                // ���������ر�
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"<xsl:value-of select="/NewDataSet/TableRemark"/>", "���"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "<xsl:value-of select="/NewDataSet/TableRemark"/>", appData.<xsl:value-of select="/NewDataSet/TitleField"/>.ToString(), "���"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"�˱��", "<xsl:value-of select="/NewDataSet/TableRemark"/>"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                // �����޸�
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Modify(appData);
                // ��ر������޸�
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"<xsl:value-of select="/NewDataSet/TableRemark"/>", "�޸�"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "<xsl:value-of select="/NewDataSet/TableRemark"/>", appData.<xsl:value-of select="/NewDataSet/TitleField"/>.ToString(), "�޸�"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "<xsl:value-of select="/NewDataSet/TableRemark"/>", (string)appData.ObjectIDBatch, "ɾ��"});
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Count(appData);
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
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsStatisticalCondition = 'true'">
      <xsl:choose>
        <xsl:when test="IsRangeSearch = 'true'">
                if (DataValidateManager.ValidateIsNull(Request.Form["<xsl:value-of select="FieldName"/>"]) == false)
                {
                      if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(Request.Form["<xsl:value-of select="FieldName"/>"].ToString(), <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                      {
                          strMessageParam[0] = "<xsl:value-of select="FieldRemark"/>";
                          strMessageParam[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                          strMessageParam[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, strMessageParam, strMessageInfo);
                          boolReturn = false;
                      }
                      else
                      {
                          appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(Request.Form["<xsl:value-of select="FieldName"/>"].ToString());
                      }
                }
                if (DataValidateManager.ValidateIsNull(Request.Form["<xsl:value-of select="FieldName"/>Begin"]) == false)
                {
                      if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(Request.Form["<xsl:value-of select="FieldName"/>Begin"].ToString(), <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                      {
                          strMessageParam[0] = "<xsl:value-of select="FieldRemark"/>��ʼֵ";
                          strMessageParam[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                          strMessageParam[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, strMessageParam, strMessageInfo);
                          boolReturn = false;
                      }
                      else
                      {
                          appData.<xsl:value-of select="FieldName"/>Begin = Convert.To<xsl:value-of select="FieldType"/>(Request.Form["<xsl:value-of select="FieldName"/>Begin"].ToString());
                      }
                }
                if (DataValidateManager.ValidateIsNull(Request.Form["<xsl:value-of select="FieldName"/>End"]) == false)
                {
                      if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(Request.Form["<xsl:value-of select="FieldName"/>End"].ToString(), <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                      {
                          strMessageParam[0] = "<xsl:value-of select="FieldRemark"/>����ֵ";
                          strMessageParam[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                          strMessageParam[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, strMessageParam, strMessageInfo);
                          boolReturn = false;
                      }
                      else
                      {
                          appData.<xsl:value-of select="FieldName"/>End = Convert.To<xsl:value-of select="FieldType"/>(Request.Form["<xsl:value-of select="FieldName"/>End"].ToString());
                      }
                }
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
                if (DataValidateManager.ValidateIsNull(Request.Form["<xsl:value-of select="FieldName"/>"]) == false)
                {
                      if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(Request.Form["<xsl:value-of select="FieldName"/>"].ToString(), <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                      {
                          strMessageParam[0] = "<xsl:value-of select="FieldRemark"/>";
                          strMessageParam[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                          strMessageParam[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";
                          strMessageInfo = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, strMessageParam, strMessageInfo);
                          boolReturn = false;
                      }
                      else
                      {
                          appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(Request.Form["<xsl:value-of select="FieldName"/>"].ToString());
                      }
                }
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
</xsl:for-each>
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
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            AddRecord();
        }
        
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
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
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsDataBind = 'true'">
        protected  virtual void GetTree_<xsl:value-of select="FieldName"/>(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "<xsl:value-of select="DataBindValueField"/>";
            string strMC = "<xsl:value-of select="DataBindTextField"/>";
            RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationData 
                <xsl:value-of select="DataBindTableName"/>AppData = new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationData();
            <xsl:value-of select="DataBindTableName"/>AppData.PageSize = 1000;
            <xsl:value-of select="DataBindTableName"/>AppData.CurrentPage = 1;
            <xsl:value-of select="DataBindTableName"/>AppData.Sort = true;
            <xsl:value-of select="DataBindTableName"/>AppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(<xsl:value-of select="DataBindTableName"/>AppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationData);
                typeRef.GetProperty(strParentName).SetValue(<xsl:value-of select="DataBindTableName"/>AppData, strParent, null);
            }
            if (<xsl:value-of select="DataBindTableName"/>AppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(<xsl:value-of select="DataBindTableName"/>AppData, strFieldValue, null);
            }
            <xsl:if test="OnlyDisplayUsedNode = 'false'">
            RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic
                <xsl:value-of select="DataBindTableName"/>AL = (RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic));
            <xsl:value-of select="DataBindTableName"/>AL.Query(<xsl:value-of select="DataBindTableName"/>AppData);
            </xsl:if>
            <xsl:if test="OnlyDisplayUsedNode = 'true'">
            if(isDisplayExistItem)
            {
                <xsl:value-of select="DataBindTableName"/>AppData.ResultSet = <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>(<xsl:value-of select="DataBindTableName"/>AppData);
            }
            else
            {
                RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic
                    <xsl:value-of select="DataBindTableName"/>AL = (RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogic));
                <xsl:value-of select="DataBindTableName"/>AL.Query(<xsl:value-of select="DataBindTableName"/>AppData);
            }
            </xsl:if>
            if (!(!(boolIsTreeStyle == true)
                || !(<xsl:value-of select="DataBindTableName"/>AppData.ValidateColumnName(strParentName) == true) 
                || !(<xsl:value-of select="DataBindTableName"/>AppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in <xsl:value-of select="DataBindTableName"/>AppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_<xsl:value-of select="FieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(<xsl:value-of select="DataBindTableName"/>AppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_<xsl:value-of select="FieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_<xsl:value-of select="FieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || <xsl:value-of select="DataBindTableName"/>AppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = <xsl:value-of select="DataBindTableName"/>AppData.ResultSet;
                foreach (DataRow drChild in <xsl:value-of select="DataBindTableName"/>AppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        protected virtual object GetDataSource_<xsl:value-of select="FieldName"/>(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="DataBindTableName"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindValueField"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindTextField"/>");
            GetTree_<xsl:value-of select="FieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, "<xsl:value-of select="TreeParentNode"/>", <xsl:value-of select="TreeParentNodeValue"/>, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual object GetDataSource_<xsl:value-of select="FieldName"/>_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="DataBindTableName"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindValueField"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindTextField"/>");
            GetTree_<xsl:value-of select="FieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, "<xsl:value-of select="TreeParentNode"/>", <xsl:value-of select="TreeParentNodeValue"/>, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        protected virtual List<![CDATA[<Triples<string, string, string>>]]> GetList_<xsl:value-of select="FieldName"/>_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="DataBindTableName"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindValueField"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindTextField"/>");
            GetTree_<xsl:value-of select="FieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, "<xsl:value-of select="TreeParentNode"/>", <xsl:value-of select="TreeParentNodeValue"/>, ref dsReturn, 0, true, displayTextIncludeCode);
            return (from DataRow dr in dsReturn.Tables[0].Rows
                    select new <![CDATA[Triples<string, string, string>]]>(GetValue(dr["<xsl:value-of select="DataBindValueField"/>"]), GetValue(dr["<xsl:value-of select="DataBindTextField"/>"]), "<xsl:value-of select="FieldName"/>")).ToList();
        }

        <xsl:if test="IsSubItemSearch = 'true'">
        protected virtual String GetSubItem_<xsl:value-of select="FieldName"/>(String str<xsl:value-of select="TreeParentNode"/>, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            sbReturn.Append("No Search Item!");
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add("<xsl:value-of select="DataBindTableName"/>");
            dsTemp.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindValueField"/>");
            dsTemp.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindTextField"/>");
            GetTree_<xsl:value-of select="FieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, "<xsl:value-of select="TreeParentNode"/>", str<xsl:value-of select="TreeParentNode"/>, ref dsTemp, 0, isDisplayExistItem, displayTextIncludeCode);
            if (dsTemp.Tables.Count>0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    sbReturn.Append(",");
                    sbReturn.Append(drTemp["<xsl:value-of select="DataBindValueField"/>"]);
                }
            }
            return sbReturn.ToString();
        }
        </xsl:if>
        <xsl:if test="IsCoupledNext = 'true'">
        protected virtual object GetDataSource_<xsl:value-of select="FieldName"/>(string strFieldName, string strFieldValue, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="DataBindTableName"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindValueField"/>");
            dsReturn.Tables["<xsl:value-of select="DataBindTableName"/>"].Columns.Add("<xsl:value-of select="DataBindTextField"/>");
            GetTree_<xsl:value-of select="FieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, strFieldName, strFieldValue, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>

<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAdvanceSearch = 'true'">
        <xsl:if test="IsBindData = 'true'">
        protected  virtual void GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel
            )
        {
            string strDM = "<xsl:value-of select="BindDataRelativeFieldName"/>";
            string strMC = "<xsl:value-of select="BindDataFieldName"/>";
            RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationData 
                <xsl:value-of select="BindDataTableName"/>AppData = new RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationData();
            <xsl:value-of select="BindDataTableName"/>AppData.PageSize = 1000;
            <xsl:value-of select="BindDataTableName"/>AppData.CurrentPage = 1;
            <xsl:value-of select="BindDataTableName"/>AppData.Sort = true;
            <xsl:value-of select="BindDataTableName"/>AppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(<xsl:value-of select="BindDataTableName"/>AppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationData);
                typeRef.GetProperty(strParentName).SetValue(<xsl:value-of select="BindDataTableName"/>AppData, strParent, null);
            }
            if (<xsl:value-of select="BindDataTableName"/>AppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(<xsl:value-of select="BindDataTableName"/>AppData, strFieldValue, null);
            }
            RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationLogic
                <xsl:value-of select="BindDataTableName"/>AL = (RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>ApplicationLogic));
            <xsl:value-of select="BindDataTableName"/>AL.Query(<xsl:value-of select="BindDataTableName"/>AppData);
            if (!(!(boolIsTreeStyle == true)
                || !(<xsl:value-of select="BindDataTableName"/>AppData.ValidateColumnName(strParentName) == true) 
                || !(<xsl:value-of select="BindDataTableName"/>AppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in <xsl:value-of select="BindDataTableName"/>AppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], drChild[strMC] + "[" + drChild[strDM] + "]");
                                GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1);
                            }
                            else if(<xsl:value-of select="BindDataTableName"/>AppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], drChild[strMC] + "[" + drChild[strDM] + "]");
                                    GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1);
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
                            dsReturn.Tables[0].Rows.Add(drChild[strDM], drChild[strMC] + "[" + drChild[strDM] + "]");
                            GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], drChild[strMC] + "[" + drChild[strDM] + "]");
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || <xsl:value-of select="BindDataTableName"/>AppData.ValidateColumnName(strParentName) == false)
            {
                foreach (DataRow drChild in <xsl:value-of select="BindDataTableName"/>AppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], drChild[strMC] + "[" + drChild[strDM] + "]");
                }
            }
        }

        protected virtual object GetDataSource_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="BindDataTableName"/>");
            dsReturn.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataRelativeFieldName"/>");
            dsReturn.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataFieldName"/>");
            GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>("<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>", true, "<xsl:value-of select="TreeParentNode"/>", <xsl:value-of select="TreeParentNodeValue"/>, ref dsReturn, 0);
            return dsReturn;
        }

        protected virtual object GetDataSource_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_AdvanceSearch()
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("<xsl:value-of select="BindDataTableName"/>");
            dsReturn.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataRelativeFieldName"/>");
            dsReturn.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataFieldName"/>");
            GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(null, null, true, "<xsl:value-of select="TreeParentNode"/>", <xsl:value-of select="TreeParentNodeValue"/>, ref dsReturn, 0);
            return dsReturn;
        }
            <xsl:if test="IsSubItemSearch = 'true'">
        protected virtual String GetSubItem_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(String str<xsl:value-of select="TreeParentNode"/>)
        {
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            sbReturn.Append("No Search Item!");
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add("<xsl:value-of select="BindDataTableName"/>");
            dsTemp.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataRelativeFieldName"/>");
            dsTemp.Tables["<xsl:value-of select="BindDataTableName"/>"].Columns.Add("<xsl:value-of select="BindDataFieldName"/>");
            GetTree_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(null, null, true, "<xsl:value-of select="TreeParentNode"/>", str<xsl:value-of select="TreeParentNode"/>, ref dsTemp, 0);
            if (dsTemp.Tables.Count>0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    sbReturn.Append(",");
                    sbReturn.Append(drTemp["<xsl:value-of select="BindDataRelativeFieldName"/>"]);
                }
            }
            return sbReturn.ToString();
        }
            </xsl:if>
        </xsl:if>
    </xsl:if>
</xsl:for-each>
        #endregion

        #region �޸������ֶ�
        protected virtual void ModifyAnyField()
        {
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
            appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Modify(appData);
        }
        #endregion

        #region ͳ�������ֶ�
        protected virtual void CountAnyField()
        {
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
            appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX��ط���
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
          <xsl:choose>
            <xsl:when test="DBType = 'Image'">
            </xsl:when>
            <xsl:otherwise>
                    case "<xsl:value-of select="FieldName"/>":
                        appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(strFieldValue);
                        break;
            </xsl:otherwise>
          </xsl:choose>
      </xsl:if>
    </xsl:for-each>
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 10;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
          <xsl:choose>
            <xsl:when test="DBType = 'Image'">
            </xsl:when>
            <xsl:otherwise>
                    case "<xsl:value-of select="FieldName"/>":
                        appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(strFieldValue);
                        break;
            </xsl:otherwise>
          </xsl:choose>
      </xsl:if>
    </xsl:for-each>
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
          <xsl:choose>
            <xsl:when test="DBType = 'Image'">
            </xsl:when>
            <xsl:otherwise>
                    case "<xsl:value-of select="FieldName"/>":
                        appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(strFieldValue);
                        break;
            </xsl:otherwise>
          </xsl:choose>
      </xsl:if>
    </xsl:for-each>
                    }
                    appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Modify(appData);
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Delete(appData);
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
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
                    = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
                <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
                appData.Sort = false;
                appData.SortField = "ObjectID";
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                switch (strFieldName)
                {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
          <xsl:choose>
            <xsl:when test="DBType = 'Image'">
            </xsl:when>
            <xsl:otherwise>
                    case "<xsl:value-of select="FieldName"/>":
                        appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(strFieldValue);
                        break;
            </xsl:otherwise>
          </xsl:choose>
      </xsl:if>
    </xsl:for-each>
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Query(appData);
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
                                <![CDATA[ strAJAXReturnValue = @"<font color=""red"">�Ѵ��ڣ����ٻ�һ����</font>";]]>
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
                                <![CDATA[ strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";]]>
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
                                <![CDATA[ strAJAXReturnValue = @"<font color=""red"">����ʧ�ܡ�</font>";]]>
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
<xsl:for-each select="/NewDataSet/RecordInfo">
        protected virtual ValidateData Validate<xsl:value-of select="FieldName"/>(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "<xsl:value-of select="FieldRemark"/>";
                validateData.Parameters[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                validateData.Parameters[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(validateData.Value, <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("<xsl:value-of select="FieldName"/>", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"<xsl:value-of select="FieldRemark"/>�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"<xsl:value-of select="FieldRemark"/>�����ڣ�����ʹ�á�";
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
    <xsl:choose>
        <xsl:when test="IsBatchSearch = 'true'">
        protected virtual ValidateData Validate<xsl:value-of select="FieldName"/>Batch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "<xsl:value-of select="FieldRemark"/>";
                validateData.Parameters[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                validateData.Parameters[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";

                // ����֤
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
        </xsl:when>
        <xsl:when test="IsMoreItemSearch = 'true'">
        protected virtual ValidateData Validate<xsl:value-of select="FieldName"/>Batch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "<xsl:value-of select="FieldRemark"/>";
                validateData.Parameters[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                validateData.Parameters[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";

                // ����֤
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
        </xsl:when>
        <xsl:when test="IsRangeSearch = 'true'">
        protected virtual ValidateData Validate<xsl:value-of select="FieldName"/>Begin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "<xsl:value-of select="FieldRemark"/>��ʼֵ";
                validateData.Parameters[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                validateData.Parameters[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(validateData.Value, <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("<xsl:value-of select="FieldName"/>", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"<xsl:value-of select="FieldRemark"/>�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"<xsl:value-of select="FieldRemark"/>�����ڣ�����ʹ�á�";
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

        protected virtual ValidateData Validate<xsl:value-of select="FieldName"/>End(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "<xsl:value-of select="FieldRemark"/>����ֵ";
                validateData.Parameters[1] = "<xsl:value-of select="DataValidateParameterOne"/>";
                validateData.Parameters[2] = "<xsl:value-of select="DataValidateParameterTwo"/>";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.<xsl:value-of select="DataValidateMethod"/>(validateData.Value, <xsl:value-of select="DataValidateParameterOne"/>, <xsl:value-of select="DataValidateParameterTwo"/>) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.<xsl:value-of select="DataValidateFaildMessage"/>, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("<xsl:value-of select="FieldName"/>", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"<xsl:value-of select="FieldRemark"/>�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"<xsl:value-of select="FieldRemark"/>�����ڣ�����ʹ�á�";
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
        </xsl:when>
        <xsl:otherwise>
        </xsl:otherwise>
    </xsl:choose>
</xsl:for-each>
        #endregion

        #region ��ȡ��ر���Ϣ
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="RelatedTableType = '1_to_n'">
        protected DataSet Get<xsl:value-of select="RelatedTableName"/>(object obj<xsl:value-of select="TableWithField"/>)
        {
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic instance<xsl:value-of select="RelatedTableName"/>ApplicationLogic
                = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic));
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData <xsl:value-of select="RelatedTableName"/>ApplicationData = new RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData();
            <xsl:value-of select="RelatedTableName"/>ApplicationData.Sort = <xsl:value-of select="Sort"/>;
            <xsl:value-of select="RelatedTableName"/>ApplicationData.SortField = "<xsl:value-of select="SortField"/>";
            <xsl:value-of select="RelatedTableName"/>ApplicationData.PageSize = 10000000;
            <xsl:value-of select="RelatedTableName"/>ApplicationData.CurrentPage = 1;
            <xsl:value-of select="RelatedTableName"/>ApplicationData.<xsl:value-of select="RelatedTableWithField"/> = (string)obj<xsl:value-of select="TableWithField"/>;
            instance<xsl:value-of select="RelatedTableName"/>ApplicationLogic.Query(<xsl:value-of select="RelatedTableName"/>ApplicationData);
            return <xsl:value-of select="RelatedTableName"/>ApplicationData.ResultSet;
        }
    </xsl:if>
</xsl:for-each>
        #endregion

        #region ��ȡ��ر��������ģ��
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        protected DataSet Get<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="AddBatchTemplateTableName"/>(object obj<xsl:value-of select="TemplateMainField"/>)
        {
            RICH.Common.BM.<xsl:value-of select="AddBatchTemplateTableName"/>.<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationLogic <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationLogic
                = (RICH.Common.BM.<xsl:value-of select="AddBatchTemplateTableName"/>.<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="AddBatchTemplateTableName"/>.<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationLogic));
            RICH.Common.BM.<xsl:value-of select="AddBatchTemplateTableName"/>.<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData = new RICH.Common.BM.<xsl:value-of select="AddBatchTemplateTableName"/>.<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData();
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.Sort = true;
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.SortField = "<xsl:value-of select="TemplateMainField"/>";
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.PageSize = 10000000;
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.CurrentPage = 1;
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.<xsl:value-of select="TemplateMainField"/>Batch = (string)obj<xsl:value-of select="TemplateMainField"/>;
            <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationLogic.Query(<xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData);
            return <xsl:value-of select="AddBatchTemplateTableName"/>ApplicationData.ResultSet;
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>
        #endregion    

        #region ��ر���������
        protected virtual void RelatedTableAddBatch()
        {

        }
        
        protected virtual void RelatedTableModifyBatch()
        {

        }


<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        protected void <xsl:value-of select="RelatedTableName"/>AddBatch(GridView gvAddBatch)
        {
            // ������ر�<xsl:value-of select="RelatedInfoName"/>
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic <xsl:value-of select="RelatedTableName"/>ApplicationLogic
                = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic));
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData <xsl:value-of select="RelatedTableName"/>ApplicationData;
            foreach (GridViewRow gvrTemp in gvAddBatch.Rows)
            {
                if (gvrTemp.RowType == DataControlRowType.DataRow)
                {
                    if (IsAddBatchRow("<xsl:value-of select="RelatedTableName"/>", gvrTemp) == true)
                    {
                        <xsl:value-of select="RelatedTableName"/>ApplicationData = new RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData();
                        // ������Ϣ��ֵ
                        <xsl:value-of select="RelatedTableName"/>ApplicationData = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData)SetBatchOperationValue("<xsl:value-of select="RelatedTableName"/>", typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData), appData, gvrTemp);
                        // ������Ϣ��Ӳ���
                        <xsl:value-of select="RelatedTableName"/>ApplicationData = <xsl:value-of select="RelatedTableName"/>ApplicationLogic.Add(<xsl:value-of select="RelatedTableName"/>ApplicationData);
                    }
                }
            }
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>

<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        protected void <xsl:value-of select="RelatedTableName"/>ModifyBatch(GridView gvModifyBatch)
        {
            // ������ر�<xsl:value-of select="RelatedInfoName"/>
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic <xsl:value-of select="RelatedTableName"/>ApplicationLogic
                = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationLogic));
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData <xsl:value-of select="RelatedTableName"/>ApplicationData;
            foreach (GridViewRow gvrTemp in gvModifyBatch.Rows)
            {
                if (gvrTemp.RowType == DataControlRowType.DataRow)
                {
                    <xsl:value-of select="RelatedTableName"/>ApplicationData = new RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData();
                    // ������Ϣ��ֵ
                    <xsl:value-of select="RelatedTableName"/>ApplicationData = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData)SetBatchOperationValue("<xsl:value-of select="RelatedTableName"/>", typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData), appData, gvrTemp);
                    // ������Ϣ�޸Ĳ���
                    <xsl:value-of select="RelatedTableName"/>ApplicationData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    <xsl:value-of select="RelatedTableName"/>ApplicationData = <xsl:value-of select="RelatedTableName"/>ApplicationLogic.Modify(<xsl:value-of select="RelatedTableName"/>ApplicationData);
                }
            }
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>

        private bool IsAddBatchRow(string strRelatedTableName, GridViewRow gvrTemp)
        {
            bool boolReturn = false;
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:if test="IsAddBatchField = 'true'">
                    <xsl:if test="IsFromMainTable = 'false'">
                        <xsl:if test="IsFromTemplateTable = 'false'">
            if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
            {
                if (DataValidateManager.ValidateIsNull(((TextBox)gvrTemp.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Text) == false)
                {
                    boolReturn = true;
                }
            }
                        </xsl:if>
                    </xsl:if>
                </xsl:if>
            </xsl:for-each>
            return boolReturn;
        }

        RICH.Common.Base.ApplicationData.ApplicationDataBase SetBatchOperationValue(
            string strRelatedTableName,
            Type typeofApplicationData,
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData,
            GridViewRow gvrTemp
        )
        {
            RICH.Common.Base.ApplicationData.ApplicationDataBase ApplicationData = (RICH.Common.Base.ApplicationData.ApplicationDataBase)Activator.CreateInstance(typeofApplicationData);
            Type typeField;
            Object[] objConstructParms;
            Object objValue;
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                <xsl:if test="IsAddBatchField = 'true'">
            if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
            {
                    <xsl:if test="IsFromMainTable = 'true'">
                typeField = Type.GetType(typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").PropertyType.AssemblyQualifiedName);
                objConstructParms = new object[] { (string)appData.<xsl:value-of select="FromTableField"/> };
                objValue = Activator.CreateInstance(typeField, objConstructParms);
                typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").SetValue(ApplicationData, objValue, null);            
                    </xsl:if>
                    <xsl:if test="IsFromMainTable = 'false'">
                        <xsl:if test="IsFromTemplateTable = 'false'">
                typeField = Type.GetType(typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").PropertyType.AssemblyQualifiedName);
                objConstructParms = new object[] { ((TextBox)gvrTemp.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Text };
                objValue = Activator.CreateInstance(typeField, objConstructParms);
                typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").SetValue(ApplicationData, objValue, null);            
                        </xsl:if>
                        <xsl:if test="IsFromTemplateTable = 'true'">
                typeField = Type.GetType(typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").PropertyType.AssemblyQualifiedName);
                objConstructParms = new object[] { ((Label)gvrTemp.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Text };
                objValue = Activator.CreateInstance(typeField, objConstructParms);
                typeofApplicationData.GetProperty("<xsl:value-of select="DisplayFieldName"/>").SetValue(ApplicationData, objValue, null);            
                        </xsl:if>
                    </xsl:if>
            }
                </xsl:if>
            </xsl:for-each>
            return ApplicationData;
        }
        #endregion
    }
}
  </xsl:template>
</xsl:stylesheet>
