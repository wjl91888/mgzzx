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
        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public override string FilterReportType { get { return "T_BM_GZXX"; } }
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
        protected const string DEFAULT_SORT_FIELD = "FFGZNY";
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
        public override string WEBUI_ADD_FILENAME { get { return "T_BM_GZXXWebUIAdd.aspx"; } }
        /// <summary>
        /// ��ѯҳ���ļ���
        /// </summary>
        public override string WEBUI_SEARCH_FILENAME { get { return "T_BM_GZXXWebUISearch.aspx"; } }
        /// <summary>
        /// ����ҳ���ļ���
        /// </summary>
        public override string WEBUI_DETAIL_FILENAME { get { return "T_BM_GZXXWebUIDetail.aspx"; } }
        /// <summary>
        /// ͳ��ҳ���ļ���
        /// </summary>
        public override string WEBUI_STATISTIC_FILENAME { get { return "T_BM_GZXXWebUIStatistic.aspx";} }
        #endregion

        #region Ȩ�ޱ�Ŷ���
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public override string WEBUI_ADD_ACCESS_PURVIEW_ID { get { return "GZ01";} }
        /// <summary>
        /// �޸�Ȩ��
        /// </summary>
        public override string WEBUI_MODIFY_ACCESS_PURVIEW_ID { get { return "GZ02";} }
        /// <summary>
        /// ���Ȩ��
        /// </summary>
        public override string WEBUI_SEARCH_ACCESS_PURVIEW_ID  { get { return "GZ04";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string WEBUI_DETAIL_ACCESS_PURVIEW_ID  { get { return "GZ05";} }
        /// <summary>
        /// ͳ��Ȩ��
        /// </summary>
        public override string WEBUI_STATISTIC_ACCESS_PURVIEW_ID  { get { return "GZ06";} }
        /// <summary>
        /// ɾ��Ȩ��
        /// </summary>
        public override string OPERATION_DELETE_PURVIEW_ID  { get { return "GZ07";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string OPERATION_EXPORTALL_PURVIEW_ID { get { return "GZ08";} }
        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public override string OPERATION_IMPORT_PURVIEW_ID { get { return "GZ09";} }
        #endregion
        #endregion

        #region ��������
        /// <summary>
        /// ����ʵ�����
        /// </summary>
        protected T_BM_GZXXApplicationData appData;
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                // �������
                appData = instanceT_BM_GZXXApplicationLogic.Add(appData);
                // ���������ر�
                RelatedTableAddBatch();
                if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
                {
                    MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "���"}, strMessageInfo);
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.XM.ToString(), "���"});
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                // �����޸�
                appData = instanceT_BM_GZXXApplicationLogic.Modify(appData);
                // ��ر������޸�
                RelatedTableModifyBatch();
                MessageContent = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, new string[] {"������Ϣ", "�޸�"}, strMessageInfo);
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, new string[] {(string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME], "������Ϣ", appData.XM.ToString(), "�޸�"});
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Query(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Delete(appData);
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
                T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                    = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
                appData = instanceT_BM_GZXXApplicationLogic.Count(appData);
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
            appData = new T_BM_GZXXApplicationData();
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
            appData = new T_BM_GZXXApplicationData();
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
            T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
            appData = instanceT_BM_GZXXApplicationLogic.Modify(appData);
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
            T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic
                = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
            appData = instanceT_BM_GZXXApplicationLogic.Count(appData);
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
        /// AJAX���õĶ�ȡ��¼����XML����ķ���
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
        /// AJAX���õĸ��·���
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
        /// AJAX���õ�ɾ������
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
        /// AJAX���õĴ��ڷ���
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
        //  FunctionName : ValidateXM
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXM(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("XM", validateData.Value.ToString()) == true)
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
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "18";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 18) == false)
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
        //  FunctionName : ValidateFFGZNY
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFFGZNY(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[2] = "6";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 6) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("FFGZNY", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���ڲ����ڣ�����ʹ�á�";
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
        /// ����������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJCGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("JCGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�������ʲ����ڣ�����ʹ�á�";
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
        /// �����ȼ�������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJSDJGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�����ȼ�����";
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
                            if (AJAX_IsExist("JSDJGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����ȼ������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����ȼ����ʲ����ڣ�����ʹ�á�";
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
        /// ְ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZWGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ְ����";
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
                            if (AJAX_IsExist("ZWGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ְ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ְ���ʲ����ڣ�����ʹ�á�";
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
        /// ��������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJBGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("JBGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����ʲ����ڣ�����ʹ�á�";
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
        /// ������������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJKDQJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����������";
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
                            if (AJAX_IsExist("JKDQJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���������������ڣ�����ʹ�á�";
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
        /// ����ظڽ�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJKTSGWJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����ظڽ���";
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
                            if (AJAX_IsExist("JKTSGWJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����ظڽ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����ظڽ��������ڣ�����ʹ�á�";
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
        /// ���乤����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateGLGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "���乤��";
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
                            if (AJAX_IsExist("GLGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���乤���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���乤�ʲ����ڣ�����ʹ�á�";
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
        /// н��������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateXJGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "н������";
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
                            if (AJAX_IsExist("XJGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"н�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"н�����ʲ����ڣ�����ʹ�á�";
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
        /// 10%��߲�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateTGBF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "10%��߲���";
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
                            if (AJAX_IsExist("TGBF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"10%��߲����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"10%��߲��ֲ����ڣ�����ʹ�á�";
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
        /// �绰����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDHF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�绰��";
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
                            if (AJAX_IsExist("DHF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�绰���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�绰�Ѳ����ڣ�����ʹ�á�";
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
        /// ������Ů����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDSZNF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "������Ů��";
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
                            if (AJAX_IsExist("DSZNF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"������Ů���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"������Ů�Ѳ����ڣ�����ʹ�á�";
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
        /// ��Ů��������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateFNWSHLF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��Ů������";
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
                            if (AJAX_IsExist("FNWSHLF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��Ů�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��Ů�����Ѳ����ڣ�����ʹ�á�";
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
        /// �������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateHLF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�����";
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
                            if (AJAX_IsExist("HLF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����Ѳ����ڣ�����ʹ�á�";
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
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJJ(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("JJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���𲻴��ڣ�����ʹ�á�";
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
        /// ��ͨ����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJTF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "��ͨ��";
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
                            if (AJAX_IsExist("JTF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"��ͨ���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��ͨ�Ѳ����ڣ�����ʹ�á�";
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
        /// �̻��乤����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJHLGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�̻��乤��";
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
                            if (AJAX_IsExist("JHLGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�̻��乤���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�̻��乤�ʲ����ڣ�����ʹ�á�";
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
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateJT(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("JT", validateData.Value.ToString()) == true)
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
        //  FunctionName : ValidateBF
        /// <summary>
        /// ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateBF(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("BF", validateData.Value.ToString()) == true)
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
        //  FunctionName : ValidateQTBT
        /// <summary>
        /// ����������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateQTBT(object objValidateData, bool boolNullable, bool boolExist)
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
                            if (AJAX_IsExist("QTBT", validateData.Value.ToString()) == true)
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
    
        //=====================================================================
        //  FunctionName : ValidateDFXJT
        /// <summary>
        /// �ط��Խ�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateDFXJT(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�ط��Խ���";
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
                            if (AJAX_IsExist("DFXJT", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�ط��Խ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�ط��Խ��������ڣ�����ʹ�á�";
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
        /// Ӧ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "Ӧ����";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"Ӧ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"Ӧ������ڣ�����ʹ�á�";
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
        /// Ӧ����Begin��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFXBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "Ӧ���ʼֵ";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"Ӧ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"Ӧ������ڣ�����ʹ�á�";
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
        /// Ӧ����End��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYFXEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "Ӧ�������ֵ";
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
                            if (AJAX_IsExist("YFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"Ӧ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"Ӧ������ڣ�����ʹ�á�";
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
        /// �����ۿ���ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateQTKK(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�����ۿ�";
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
                            if (AJAX_IsExist("QTKK", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�����ۿ��Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�����ۿ���ڣ�����ʹ�á�";
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
        /// ʧҵ������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSYBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ʧҵ����";
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
                            if (AJAX_IsExist("SYBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ʧҵ�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ʧҵ���ղ����ڣ�����ʹ�á�";
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
        /// ˮ��ů������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSDNQF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ˮ��ů����";
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
                            if (AJAX_IsExist("SDNQF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ˮ��ů�����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ˮ��ů���Ѳ����ڣ�����ʹ�á�";
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
        /// ����˰��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSDS(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "����˰";
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
                            if (AJAX_IsExist("SDS", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����˰�Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"����˰�����ڣ�����ʹ�á�";
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
        /// ���ϱ�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYLBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "���ϱ���";
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
                            if (AJAX_IsExist("YLBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"���ϱ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"���ϱ��ղ����ڣ�����ʹ�á�";
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
        /// ҽ�Ʊ�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYLIBX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ҽ�Ʊ���";
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
                            if (AJAX_IsExist("YLIBX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ҽ�Ʊ����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ҽ�Ʊ��ղ����ڣ�����ʹ�á�";
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
        /// �����������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateYSSHF(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "���������";
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
                            if (AJAX_IsExist("YSSHF", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"����������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"��������Ѳ����ڣ�����ʹ�á�";
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
        /// ס����������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateZFGJJ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ס��������";
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
                            if (AJAX_IsExist("ZFGJJ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ס���������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ס�������𲻴��ڣ�����ʹ�á�";
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
        /// �۷�����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateKFX(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "�۷���";
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
                            if (AJAX_IsExist("KFX", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"�۷����Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"�۷�����ڣ�����ʹ�á�";
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
        /// ʵ��������ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZ(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ʵ������";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ʵ�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ʵ�����ʲ����ڣ�����ʹ�á�";
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
        /// ʵ������Begin��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZBegin(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ʵ�����ʿ�ʼֵ";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ʵ�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ʵ�����ʲ����ڣ�����ʹ�á�";
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
        /// ʵ������End��ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateSFGZEnd(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "ʵ�����ʽ���ֵ";
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
                            if (AJAX_IsExist("SFGZ", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"ʵ�������Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"ʵ�����ʲ����ڣ�����ʹ�á�";
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
        /// ˵����ֵ��֤����
        /// </summary>
        //=====================================================================        
        protected virtual ValidateData ValidateGZKKSM(object objValidateData, bool boolNullable, bool boolExist)
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
                validateData.Parameters[0] = "˵��";
                validateData.Parameters[1] = "1";
                validateData.Parameters[2] = "1000";

                // ����֤
                if (DataValidateManager.ValidateIsNull(validateData.Value) == false)
                {
                    // ��ֵ��ʽ��֤
                    if (DataValidateManager.ValidateStringLengthRange(validateData.Value, 1, 1000) == false)
                    {
                        validateData.Message = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, validateData.Parameters);
                        validateData.Result = false;
                    }
                    else
                    {
                        // ���ݴ�����֤
                        if (validateData.Exist == true)
                        {
                            if (AJAX_IsExist("GZKKSM", validateData.Value.ToString()) == true)
                            {
                                 validateData.IsExist = true;
                                 validateData.Message = @"˵���Ѵ��ڣ����ٻ�һ����";
                                 validateData.Result = false;
                            }
                            else
                            {
                                validateData.Message = @"˵�������ڣ�����ʹ�á�";
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
  
