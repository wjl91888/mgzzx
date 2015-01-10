/****************************************************** 
FileName:T_PM_UserInfoWebUIBase.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.WebUI;
using RICH.Common.LM;

namespace RICH.Common.BM.T_PM_UserInfo
{
    public class T_PM_UserInfoWebUIBase : WebUIBase
    {
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public override string FilterReportType { get { return "T_PM_UserInfo"; } }
        /// <summary>
        /// ��ǰҳ�������ļ�·��
        /// </summary>
        public override string CURRENT_PATH { get { return "/Administrator/A_BM"; } }
        /// <summary>
        /// Ĭ�ϵ�����ʽ
        /// </summary>
        protected const Boolean DEFAULT_SORT = false;
        /// <summary>
        /// Ĭ�ϵ������ֶ�
        /// </summary>
        protected const string DEFAULT_SORT_FIELD = "UserID";
        /// <summary>
        /// ÿҳ��ʾ��¼��
        /// </summary>
        protected const Int32 DEFAULT_PAGE_SIZE = 50;
        /// <summary>
        /// Ĭ�ϵ�ǰҳ��
        /// </summary>
        protected const Int32 DEFAULT_CURRENT_PAGE = 1;

        #region ҳ�����ƶ���
        /// <summary>
        /// �༭ҳ���ļ���
        /// </summary>
        public override string WEBUI_ADD_FILENAME { get { return "T_PM_UserInfoWebUIAdd.aspx"; } }
        /// <summary>
        /// ��ѯҳ���ļ���
        /// </summary>
        public override string WEBUI_SEARCH_FILENAME { get { return "T_PM_UserInfoWebUISearch.aspx"; } }
        /// <summary>
        /// ����ҳ���ļ���
        /// </summary>
        public override string WEBUI_DETAIL_FILENAME { get { return "T_PM_UserInfoWebUIDetail.aspx"; } }
        /// <summary>
        /// ͳ��ҳ���ļ���
        /// </summary>
        public override string WEBUI_STATISTIC_FILENAME { get { return "T_PM_UserInfoWebUIStatistic.aspx";} }
        #endregion

        #region Ȩ�ޱ�Ŷ���
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public override string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "USER01";} }
        /// <summary>
        /// �޸�Ȩ��
        /// </summary>
        public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "USER02";} }
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID  { get { return "USER04";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID  { get { return "USER05";} }
        /// <summary>
        /// ͳ��Ȩ��
        /// </summary>
        public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID  { get { return "USER06";} }
        /// <summary>
        /// ɾ��Ȩ��
        /// </summary>
        public override string OPERATION_DELETE_PURVIEW_ID  { get { return "USER07";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string OPERATION_EXPORTALL_PURVIEW_ID { get { return "USER08";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string OPERATION_IMPORT_PURVIEW_ID { get { return "USER09";} }
        /// <summary>
        /// �������ݼ�Ȩ��
        /// </summary>
        public override string OPERATION_IMPORT_DS_PURVIEW_ID { get { return "USER10";} }
        #endregion
        #endregion

        #region ��������
        /// <summary>
        /// ����ʵ�����
        /// </summary>
        protected T_PM_UserInfoApplicationData appData;
        /// <summary>
        /// ��Ϣ��Ϣ
        /// </summary>
        protected string strMessageInfo = string.Empty;
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        protected string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
        /// <summary>
        /// AJAX��������ֵ
        /// </summary>
        protected string strAJAXReturnValue = string.Empty;
        /// <summary>
        /// ������Ϣ��Ϣ
        /// </summary>
        protected string strPopupMessageInfo = string.Empty;
        #endregion

        #region ���ݲ�������
        //=====================================================================
        //  FunctionName : AddRecord
        /// <summary>
        /// ��Ӽ�¼����
        /// </summary>
        //=====================================================================
        protected virtual void AddRecord()
        {
            if (GetAddInputParameter())
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                // �������
                appData = instanceT_PM_UserInfoApplicationLogic.Add(appData);
                // ���������ر�
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"�û���Ϣ", "���"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "�û���Ϣ", appData.UserLoginName.ToString(), "���"});
                    LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                    Page.CloseWindow(true);
                }
                else
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, new string[] {"�˱��", "�û���Ϣ"}, strMessageInfo);
                    Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
                }
            }
        }

        //=====================================================================
        //  FunctionName : ModifyRecord
        /// <summary>
        /// �޸ļ�¼����
        /// </summary>
        //=====================================================================
        protected virtual void ModifyRecord()
        {
            if (GetModifyInputParameter())
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                // �����޸�
                appData = instanceT_PM_UserInfoApplicationLogic.Modify(appData);
                // ��ر������޸�
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"�û���Ϣ", "�޸�"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "�û���Ϣ", appData.UserLoginName.ToString(), "�޸�"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
                Page.CloseWindow(true);
            }
        }

        //=====================================================================
        //  FunctionName : QueryRecord
        /// <summary>
        /// ��ѯ��¼����
        /// </summary>
        //=====================================================================
        protected virtual void QueryRecord()
        {
            if (GetQueryInputParameter())
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : DeleteRecord
        /// <summary>
        /// ɾ����¼����
        /// </summary>
        //=====================================================================
        protected virtual void DeleteRecord()
        {
            if (GetDeleteInputParameter())
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                appData = instanceT_PM_UserInfoApplicationLogic.Delete(appData);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "�û���Ϣ", (string)appData.ObjectIDBatch, "ɾ��"});
                LogLibrary.LogWrite("A02", strLogContent, null, null, null);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : CountRecord
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        //=====================================================================
        protected virtual void CountRecord()
        {
            if (GetCountInputParameter())
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                appData = instanceT_PM_UserInfoApplicationLogic.Count(appData);
            }
            else
            {
                // �Դ�����Ϣ���д���
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
        }

        //=====================================================================
        //  FunctionName : GetAddInputParameter
        /// <summary>
        /// �õ�����û������������
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetAddInputParameter()
        {
            return false;
        }

        //=====================================================================
        //  FunctionName : GetModifyInputParameter
        /// <summary>
        /// �õ��޸��û������������
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetModifyInputParameter()
        {
            return false;
        }

        //=====================================================================
        //  FunctionName : GetQueryInputParameter
        /// <summary>
        /// �õ���ѯ�û��������������ͨ��Request����
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetQueryInputParameter()
        {
            return true;
        }

          
        //=====================================================================
        //  FunctionName : GetDeleteInputParameter
        /// <summary>
        /// �õ���ѯ�û������������
        /// </summary>
        //=====================================================================
        protected virtual Boolean GetDeleteInputParameter()
        {
            return true;
        }

        //=====================================================================
        //  FunctionName : GetCountInputParameter
        /// <summary>
        /// �õ�ͳ�Ƽ�¼���û��������������ͨ��Request����
        /// </summary>
        //=====================================================================
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
        //=====================================================================
        //  FunctionName : Initalize
        /// <summary>
        /// ҳ���ʼ���麯��
        /// </summary>
        //=====================================================================
        protected virtual void Initalize()
        {
        }

        //=====================================================================
        //  FunctionName : btnFirstPage_Click
        /// <summary>
        /// ��һҳ��ť�¼�
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
        /// ��һҳ��ť�¼�
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
        /// ��һҳ��ť�¼�
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
        /// ���һҳ��ť�¼�
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
        /// ȷ����Ӱ�ť�¼�
        /// </summary>
        //=====================================================================
        protected virtual void btnAddConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_PM_UserInfoApplicationData();
            AddRecord();
        }
        
        //=====================================================================
        //  FunctionName : btnModifyConfirm_Click
        /// <summary>
        /// ȷ���޸İ�ť�¼�
        /// </summary>
        //=====================================================================
        protected virtual void btnModifyConfirm_Click(object sender, EventArgs e)
        {
            Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
            Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "SuccessClose";
            appData = new T_PM_UserInfoApplicationData();
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            ModifyRecord();
        }

        //=====================================================================
        //  FunctionName : gvList_RowDataBound
        /// <summary>
        /// GridView�б�ؼ�RowDataBound�¼�
        /// </summary>
        //=====================================================================
        protected virtual void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // �����ж��Ƿ���Header��
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // ���ò���״̬
                LinkButton btnTemp = new LinkButton();
                string strSortFieldID = "btnSort" + (string)ViewState["SortField"];
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    btnTemp = (LinkButton)e.Row.Cells[i].FindControl(strSortFieldID);
                    if (btnTemp != null)
                    {
                        if ((Boolean)ViewState["Sort"] == false)
                        {
                            btnTemp.Text = "��";
                            btnTemp.CommandName = "AscSort";
                        }
                        else if ((Boolean)ViewState["Sort"] == true)
                        {
                            btnTemp.Text = "��";
                            btnTemp.CommandName = "DescSort";
                        }
                        break;
                    }
                }
            }
            // �ж��Ƿ���������
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
        /// ����ť�ؼ�Click�¼�
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
        /// ҳ��ѡ�������б�ؼ�SelectedIndexChanged�¼�
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
        /// ÿҳ��¼�������б�ؼ�SelectedIndexChanged�¼�
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
        /// ����ѡ�м�¼�ؼ�Click�¼�
        /// </summary>
        //=====================================================================
        protected virtual void btnOperate_Click(object sender, EventArgs e)
        {
            switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
            {
                case "remove":
                    appData = new T_PM_UserInfoApplicationData();
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
        /// �������ݵ��ļ�����
        /// </summary>
        //=====================================================================
        protected virtual void ExportToFile()
        {
        }

        //=====================================================================
        //  FunctionName : VerifyRenderingInServerForm
        /// <summary>
        /// ��д����VerifyRenderingInServerForm
        /// </summary>
        //=====================================================================
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        //=====================================================================
        //  FunctionName : btnExportAllToFile_Click
        /// <summary>
        /// �����������ݵ��ļ���ť�ؼ�Click�¼�
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
        /// ������д��ť�ؼ�Click�¼�
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
        /// ���ذ�ť�ؼ�Click�¼�
        /// </summary>
        //=====================================================================
        protected virtual void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btnTemp = new LinkButton();
            btnTemp = (LinkButton)sender;
            RICH.Common.FileLibrary.DownloadFile(btnTemp.CommandArgument.ToString(), btnTemp.CommandName.ToString());
        }
        #endregion

        #region ȡ������Դ

        //=====================================================================
        //  FunctionName : GetTree_UserGroupID
        /// <summary>
        /// ����ָ������ȡ���û���(UserGroupID)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_UserGroupID(
            string strFieldName, string strFieldValue, bool boolIsTreeStyle,
            string strParentName, string strParent, ref DataSet dsReturn, int intLevel, bool isDisplayExistItem = false, bool displayTextIncludeCode = false
            )
        {
            string strDM = "UserGroupID";
            string strMC = "UserGroupName";
            RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationData 
                T_PM_UserGroupInfoAppData = new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationData();
            T_PM_UserGroupInfoAppData.PageSize = 1000;
            T_PM_UserGroupInfoAppData.CurrentPage = 1;
            T_PM_UserGroupInfoAppData.Sort = true;
            T_PM_UserGroupInfoAppData.SortField = strDM;
            if (!(!(boolIsTreeStyle == true) || !(T_PM_UserGroupInfoAppData.ValidateColumnName(strParentName) == true)))
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationData);
                typeRef.GetProperty(strParentName).SetValue(T_PM_UserGroupInfoAppData, strParent, null);
            }
            if (T_PM_UserGroupInfoAppData.ValidateColumnName(strFieldName) == true)
            {
                Type typeRef = typeof(RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationData);
                typeRef.GetProperty(strFieldName).SetValue(T_PM_UserGroupInfoAppData, strFieldValue, null);
            }
            
            RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationLogic
                T_PM_UserGroupInfoAL = (RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationLogic));
            T_PM_UserGroupInfoAL.Query(T_PM_UserGroupInfoAppData);
            
            if (!(!(boolIsTreeStyle == true)
                || !(T_PM_UserGroupInfoAppData.ValidateColumnName(strParentName) == true) 
                || !(T_PM_UserGroupInfoAppData.ResultSet.Tables[0].Rows.Count > 0))
                )
            {
                foreach (DataRow drChild in T_PM_UserGroupInfoAppData.ResultSet.Tables[0].Rows)
                {
                    if ((string)drChild[strDM] != strParent)
                    {
                        if (intLevel == 0)
                        {
                            if (DataValidateManager.ValidateIsNull(drChild[strParentName]) == true
                                || (string)drChild[strParentName] == strParent)
                            {
                                dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                GetTree_UserGroupID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_PM_UserGroupInfoAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_UserGroupID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_UserGroupID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                        }
                    }
                    else
                    {
                        dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                    }
                }
            }
            else if (boolIsTreeStyle == false
                || T_PM_UserGroupInfoAppData.ValidateColumnName(strParentName) == false)
            {
                // dsReturn = T_PM_UserGroupInfoAppData.ResultSet;
                foreach (DataRow drChild in T_PM_UserGroupInfoAppData.ResultSet.Tables[0].Rows)
                {
                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                }
            }
        }

        //=====================================================================
        //  FunctionName : GetDataSource_UserGroupID
        /// <summary>
        /// ȡ���û���(UserGroupID)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_UserGroupID(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserGroupInfo");
            dsReturn.Tables["T_PM_UserGroupInfo"].Columns.Add("UserGroupID");
            dsReturn.Tables["T_PM_UserGroupInfo"].Columns.Add("UserGroupName");
            GetTree_UserGroupID("null", "null", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_UserGroupID_AdvanceSearch
        /// <summary>
        /// ȡ���û���(UserGroupID)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_UserGroupID_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_PM_UserGroupInfo");
            dsReturn.Tables["T_PM_UserGroupInfo"].Columns.Add("UserGroupID");
            dsReturn.Tables["T_PM_UserGroupInfo"].Columns.Add("UserGroupName");
            GetTree_UserGroupID("null", "null", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_SubjectID
        /// <summary>
        /// ����ָ������ȡ��������λ(SubjectID)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_SubjectID(
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
                                GetTree_SubjectID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(T_BM_DWXXAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_SubjectID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_SubjectID(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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

        //=====================================================================
        //  FunctionName : GetDataSource_SubjectID
        /// <summary>
        /// ȡ��������λ(SubjectID)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_SubjectID(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_DWXX");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_SubjectID("null", "null", true, "SJDWBH", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_SubjectID_AdvanceSearch
        /// <summary>
        /// ȡ��������λ(SubjectID)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_SubjectID_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("T_BM_DWXX");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsReturn.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_SubjectID("null", "null", true, "SJDWBH", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetSubItem_SubjectID
        /// <summary>
        /// ȡ��������λ(SubjectID)ָ������������Ŀ��Ϣ
        /// </summary>
        //=====================================================================
        protected virtual String GetSubItem_SubjectID(String strSJDWBH, bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            System.Text.StringBuilder sbReturn = new System.Text.StringBuilder(string.Empty);
            sbReturn.Append("No Search Item!");
            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add("T_BM_DWXX");
            dsTemp.Tables["T_BM_DWXX"].Columns.Add("DWBH");
            dsTemp.Tables["T_BM_DWXX"].Columns.Add("DWMC");
            GetTree_SubjectID("null", "null", true, "SJDWBH", strSJDWBH, ref dsTemp, 0, isDisplayExistItem, displayTextIncludeCode);
            if (dsTemp.Tables.Count>0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    sbReturn.Append(",");
                    sbReturn.Append(drTemp["DWBH"]);
                }
            }
            return sbReturn.ToString();
        }
        
        //=====================================================================
        //  FunctionName : GetTree_XB
        /// <summary>
        /// ����ָ������ȡ���Ա�(XB)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_XB(
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
                                GetTree_XB(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_XB(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_XB(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
        //  FunctionName : GetDataSource_XB
        /// <summary>
        /// ȡ���Ա�(XB)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XB(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XB("LX", "0001", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_XB_AdvanceSearch
        /// <summary>
        /// ȡ���Ա�(XB)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_XB_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_XB("LX", "0001", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_MZ
        /// <summary>
        /// ����ָ������ȡ������(MZ)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_MZ(
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
                                GetTree_MZ(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_MZ(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_MZ(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
        //  FunctionName : GetDataSource_MZ
        /// <summary>
        /// ȡ������(MZ)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_MZ(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_MZ("LX", "0002", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_MZ_AdvanceSearch
        /// <summary>
        /// ȡ������(MZ)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_MZ_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_MZ("LX", "0002", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_ZZMM
        /// <summary>
        /// ����ָ������ȡ��������ò(ZZMM)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_ZZMM(
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
                                GetTree_ZZMM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_ZZMM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_ZZMM(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
        //  FunctionName : GetDataSource_ZZMM
        /// <summary>
        /// ȡ��������ò(ZZMM)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_ZZMM(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_ZZMM("LX", "0003", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_ZZMM_AdvanceSearch
        /// <summary>
        /// ȡ��������ò(ZZMM)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_ZZMM_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_ZZMM("LX", "0003", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        //=====================================================================
        //  FunctionName : GetTree_UserStatus
        /// <summary>
        /// ����ָ������ȡ���û�״̬(UserStatus)����Դ
        /// </summary>
        //=====================================================================
        protected  virtual void GetTree_UserStatus(
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
                                GetTree_UserStatus(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
                            }
                            else if(DictionaryAppData.ValidateColumnName(strFieldName) == true)
                            {
                                if ((string)drChild[strFieldName] == strFieldValue)
                                {
                                    dsReturn.Tables[0].Rows.Add(drChild[strDM], displayTextIncludeCode ? drChild[strMC] + "[" + drChild[strDM] + "]" : drChild[strMC]);
                                    GetTree_UserStatus(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
                            GetTree_UserStatus(strFieldName, strFieldValue, boolIsTreeStyle, strParentName, (string)drChild[strDM], ref dsReturn, intLevel + 1, isDisplayExistItem);
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
        //  FunctionName : GetDataSource_UserStatus
        /// <summary>
        /// ȡ���û�״̬(UserStatus)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_UserStatus(bool isDisplayExistItem = false, bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_UserStatus("LX", "0102", true, "null", null, ref dsReturn, 0, isDisplayExistItem, displayTextIncludeCode);
            return dsReturn;
        }

        //=====================================================================
        //  FunctionName : GetDataSource_UserStatus_AdvanceSearch
        /// <summary>
        /// ȡ���û�״̬(UserStatus)����Դ
        /// </summary>
        //=====================================================================
        protected virtual object GetDataSource_UserStatus_AdvanceSearch(bool displayTextIncludeCode = false)
        {
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add("Dictionary");
            dsReturn.Tables["Dictionary"].Columns.Add("DM");
            dsReturn.Tables["Dictionary"].Columns.Add("MC");
            GetTree_UserStatus("LX", "0102", true, "null", null, ref dsReturn, 0, true, displayTextIncludeCode);
            return dsReturn;
        }

        
        #endregion

        #region �޸������ֶ�
        //=====================================================================
        //  FunctionName : ModifyAnyField
        /// <summary>
        /// �޸�һ���ֶε�ֵ
        /// </summary>
        //=====================================================================
        protected virtual void ModifyAnyField()
        {
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            appData = instanceT_PM_UserInfoApplicationLogic.Modify(appData);
        }
        #endregion

        #region ͳ�������ֶ�
        //=====================================================================
        //  FunctionName : CountAnyField
        /// <summary>
        /// ͳ�Ʋ���
        /// </summary>
        //=====================================================================
        protected virtual void CountAnyField()
        {
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            appData = instanceT_PM_UserInfoApplicationLogic.Count(appData);
        }
        #endregion

        #region AJAX��ط���
        //=====================================================================
        //  FunctionName : AJAX_QuerySingle
        /// <summary>
        /// AJAX���õĶ�ȡָ����¼ָ���ֶεķ���
        /// </summary>
        //=====================================================================
        protected virtual string AJAX_QuerySingle(string strFieldName, string strFieldValue, string strReturnFieldName)
        {
            string strReturn = string.Empty;
            try
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
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
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserLoginName":
                        appData.UserLoginName = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserGroupID":
                        appData.UserGroupID = Convert.ToString(strFieldValue);
                        break;
            
                    case "SubjectID":
                        appData.SubjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserNickName":
                        appData.UserNickName = Convert.ToString(strFieldValue);
                        break;
            
                    case "Password":
                        appData.Password = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "MZ":
                        appData.MZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "ZZMM":
                        appData.ZZMM = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "SJH":
                        appData.SJH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGDH":
                        appData.BGDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "JTDH":
                        appData.JTDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "Email":
                        appData.Email = Convert.ToString(strFieldValue);
                        break;
            
                    case "QQH":
                        appData.QQH = Convert.ToString(strFieldValue);
                        break;
            
                    case "LoginTime":
                        appData.LoginTime = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LastLoginIP":
                        appData.LastLoginIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "LastLoginDate":
                        appData.LastLoginDate = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LoginTimes":
                        appData.LoginTimes = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "UserStatus":
                        appData.UserStatus = Convert.ToString(strFieldValue);
                        break;
            
                    case "vcode":
                        appData.vcode = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
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
        /// AJAX���õĶ�ȡ��¼����XML����ķ���
        /// </summary>
        //=====================================================================
        protected virtual string AJAX_QueryDataSet(string strFieldName, string strFieldValue)
        {
            string strReturn = string.Empty;
            try
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
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
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserLoginName":
                        appData.UserLoginName = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserGroupID":
                        appData.UserGroupID = Convert.ToString(strFieldValue);
                        break;
            
                    case "SubjectID":
                        appData.SubjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserNickName":
                        appData.UserNickName = Convert.ToString(strFieldValue);
                        break;
            
                    case "Password":
                        appData.Password = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "MZ":
                        appData.MZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "ZZMM":
                        appData.ZZMM = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "SJH":
                        appData.SJH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGDH":
                        appData.BGDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "JTDH":
                        appData.JTDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "Email":
                        appData.Email = Convert.ToString(strFieldValue);
                        break;
            
                    case "QQH":
                        appData.QQH = Convert.ToString(strFieldValue);
                        break;
            
                    case "LoginTime":
                        appData.LoginTime = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LastLoginIP":
                        appData.LastLoginIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "LastLoginDate":
                        appData.LastLoginDate = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LoginTimes":
                        appData.LoginTimes = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "UserStatus":
                        appData.UserStatus = Convert.ToString(strFieldValue);
                        break;
            
                    case "vcode":
                        appData.vcode = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
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
        /// AJAX���õĸ��·���
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_Modify(string strFieldName, string strFieldValue, string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    switch (strFieldName)
                    {
    
                    case "ObjectID":
                        appData.ObjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserLoginName":
                        appData.UserLoginName = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserGroupID":
                        appData.UserGroupID = Convert.ToString(strFieldValue);
                        break;
            
                    case "SubjectID":
                        appData.SubjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserNickName":
                        appData.UserNickName = Convert.ToString(strFieldValue);
                        break;
            
                    case "Password":
                        appData.Password = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "MZ":
                        appData.MZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "ZZMM":
                        appData.ZZMM = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "SJH":
                        appData.SJH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGDH":
                        appData.BGDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "JTDH":
                        appData.JTDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "Email":
                        appData.Email = Convert.ToString(strFieldValue);
                        break;
            
                    case "QQH":
                        appData.QQH = Convert.ToString(strFieldValue);
                        break;
            
                    case "LoginTime":
                        appData.LoginTime = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LastLoginIP":
                        appData.LastLoginIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "LastLoginDate":
                        appData.LastLoginDate = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LoginTimes":
                        appData.LoginTimes = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "UserStatus":
                        appData.UserStatus = Convert.ToString(strFieldValue);
                        break;
            
                    case "vcode":
                        appData.vcode = Convert.ToString(strFieldValue);
                        break;
            
                    }
                    appData = instanceT_PM_UserInfoApplicationLogic.Modify(appData);
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
        /// AJAX���õ�ɾ������
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_Delete(string strObjectID)
        {
            bool boolReturn = false;
            try
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
                appData.OPCode = ApplicationDataBase.OPType.ID;
                appData.ObjectID = strObjectID;
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = instanceT_PM_UserInfoApplicationLogic.Delete(appData);
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
        /// AJAX���õĴ��ڷ���
        /// </summary>
        //=====================================================================
        protected virtual bool AJAX_IsExist(string strFieldName, string strFieldValue)
        {
            bool boolReturn = false;
            try
            {
                T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
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
            
                    case "UserID":
                        appData.UserID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserLoginName":
                        appData.UserLoginName = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserGroupID":
                        appData.UserGroupID = Convert.ToString(strFieldValue);
                        break;
            
                    case "SubjectID":
                        appData.SubjectID = Convert.ToString(strFieldValue);
                        break;
            
                    case "UserNickName":
                        appData.UserNickName = Convert.ToString(strFieldValue);
                        break;
            
                    case "Password":
                        appData.Password = Convert.ToString(strFieldValue);
                        break;
            
                    case "XB":
                        appData.XB = Convert.ToString(strFieldValue);
                        break;
            
                    case "MZ":
                        appData.MZ = Convert.ToString(strFieldValue);
                        break;
            
                    case "ZZMM":
                        appData.ZZMM = Convert.ToString(strFieldValue);
                        break;
            
                    case "SFZH":
                        appData.SFZH = Convert.ToString(strFieldValue);
                        break;
            
                    case "SJH":
                        appData.SJH = Convert.ToString(strFieldValue);
                        break;
            
                    case "BGDH":
                        appData.BGDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "JTDH":
                        appData.JTDH = Convert.ToString(strFieldValue);
                        break;
            
                    case "Email":
                        appData.Email = Convert.ToString(strFieldValue);
                        break;
            
                    case "QQH":
                        appData.QQH = Convert.ToString(strFieldValue);
                        break;
            
                    case "LoginTime":
                        appData.LoginTime = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LastLoginIP":
                        appData.LastLoginIP = Convert.ToString(strFieldValue);
                        break;
            
                    case "LastLoginDate":
                        appData.LastLoginDate = Convert.ToDateTime(strFieldValue);
                        break;
            
                    case "LoginTimes":
                        appData.LoginTimes = Convert.ToInt32(strFieldValue);
                        break;
            
                    case "UserStatus":
                        appData.UserStatus = Convert.ToString(strFieldValue);
                        break;
            
                    case "vcode":
                        appData.vcode = Convert.ToString(strFieldValue);
                        break;
            
                    default:
                        appData.PageSize = 0;
                        break;
                }
                appData = instanceT_PM_UserInfoApplicationLogic.Query(appData);
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
        /// ʵ�ֽӿڷ���RaiseCallbackEvent
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

        //=====================================================================
        //  FunctionName : RaiseCallbackEvent
        /// <summary>
        /// ʵ�ֽӿڷ���RaiseCallbackEvent
        /// </summary>
        //=====================================================================
        public override string GetCallbackResult()
        {
            return strAJAXReturnValue;
        }
        #endregion

        #region ��֤����

        //=====================================================================
        //  FunctionName : ValidateObjectID
        /// <summary>
        /// ��ֵ��֤����
        /// </summary>
        //=====================================================================        
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
    
        //=====================================================================
        //  FunctionName : ValidateUserID
        /// <summary>
        /// �û������ֵ��֤����
        /// </summary>
        //=====================================================================        
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
    
        //=====================================================================
        //  FunctionName : ValidateUserLoginName
        /// <summary>
        /// �û�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateUserLoginName(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�û���";
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
                            if (AJAX_IsExist("UserLoginName", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�û����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�û��������ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateUserGroupID
        /// <summary>
        /// �û�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateUserGroupID(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�û���";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "500";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 500) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("UserGroupID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�û����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�û��鲻���ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateUserGroupIDBatch
        /// <summary>
        /// �û���Batch��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateUserGroupIDBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�û���";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "500";

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
        
        //=====================================================================
        //  FunctionName : ValidateSubjectID
        /// <summary>
        /// ������λ��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSubjectID(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "������λ";
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
                            if (AJAX_IsExist("SubjectID", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"������λ�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"������λ�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateSubjectIDBatch
        /// <summary>
        /// ������λBatch��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSubjectIDBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "������λ";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "50";

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
        
        //=====================================================================
        //  FunctionName : ValidateUserNickName
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateUserNickName(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����";
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
                            if (AJAX_IsExist("UserNickName", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���������ڣ�����ʹ�á�";
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
        //  FunctionName : ValidatePassword
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidatePassword(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����";
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
                            if (AJAX_IsExist("Password", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���벻���ڣ�����ʹ�á�";
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
        /// �Ա���ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXB(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�Ա�";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 2) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("XB", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�Ա��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�Ա𲻴��ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateXBBatch
        /// <summary>
        /// �Ա�Batch��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXBBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�Ա�";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

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
        
        //=====================================================================
        //  FunctionName : ValidateMZ
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateMZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 2) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("MZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���岻���ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateMZBatch
        /// <summary>
        /// ����Batch��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateMZBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

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
        
        //=====================================================================
        //  FunctionName : ValidateZZMM
        /// <summary>
        /// ������ò��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZZMM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "������ò";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 2) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("ZZMM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"������ò�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"������ò�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateZZMMBatch
        /// <summary>
        /// ������òBatch��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZZMMBatch(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "������ò";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

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
        
        //=====================================================================
        //  FunctionName : ValidateSFZH
        /// <summary>
        /// ���֤����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFZH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "���֤��";
                validateData.Parameters[1] = "18";
                validateData.Parameters[2] = "18";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 18, 18) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("SFZH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���֤���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���֤�Ų����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateSJH
        /// <summary>
        /// �ֻ���ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSJH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�ֻ�";
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
                            if (AJAX_IsExist("SJH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�ֻ��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�ֻ������ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateBGDH
        /// <summary>
        /// �칫�绰��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateBGDH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�칫�绰";
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
                            if (AJAX_IsExist("BGDH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�칫�绰�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�칫�绰�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateJTDH
        /// <summary>
        /// ��ͥ�绰��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJTDH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��ͥ�绰";
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
                            if (AJAX_IsExist("JTDH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��ͥ�绰�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��ͥ�绰�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateEmail
        /// <summary>
        /// Email��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateEmail(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "Email";
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
                            if (AJAX_IsExist("Email", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"Email�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"Email�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateQQH
        /// <summary>
        /// QQ��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateQQH(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "QQ";
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
                            if (AJAX_IsExist("QQH", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"QQ�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"QQ�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateLoginTime
        /// <summary>
        /// ��¼ʱ����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLoginTime(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��¼ʱ��";
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
                            if (AJAX_IsExist("LoginTime", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��¼ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��¼ʱ�䲻���ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateLastLoginIP
        /// <summary>
        /// ��¼IP��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLastLoginIP(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��¼IP";
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
                            if (AJAX_IsExist("LastLoginIP", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��¼IP�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��¼IP�����ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateLastLoginDate
        /// <summary>
        /// �ϴ�ʱ����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLastLoginDate(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�ϴ�ʱ��";
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
                            if (AJAX_IsExist("LastLoginDate", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�ϴ�ʱ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�ϴ�ʱ�䲻���ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateLoginTimes
        /// <summary>
        /// ��¼������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateLoginTimes(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��¼����";
                validateData.Parameters[1] = "null";
                validateData.Parameters[2] = "null";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateNumberFormat(validateData.Value, null, null) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0003, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("LoginTimes", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��¼�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��¼���������ڣ�����ʹ�á�";
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
        //  FunctionName : ValidateUserStatus
        /// <summary>
        /// �û�״̬��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateUserStatus(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�û�״̬";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "2";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 2) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("UserStatus", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�û�״̬�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�û�״̬�����ڣ�����ʹ�á�";
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
        //  FunctionName : Validatevcode
        /// <summary>
        /// ��֤����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData Validatevcode(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��֤��";
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
                            if (AJAX_IsExist("vcode", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��֤���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��֤�벻���ڣ�����ʹ�á�";
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
        //=====================================================================
        //  FunctionName : RelatedTableAddBatch()
        /// <summary>
        /// ��ر��������
        /// </summary>
        //=====================================================================
        protected virtual void RelatedTableAddBatch()
        {

        }
        
        //=====================================================================
        //  FunctionName : RelatedTableModifyBatch()
        /// <summary>
        /// ��ر������޸�
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
            T_PM_UserInfoApplicationData appData,
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
  
