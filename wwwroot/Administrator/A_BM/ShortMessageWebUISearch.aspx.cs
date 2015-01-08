/****************************************************** 
FileName:ShortMessageWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.ShortMessage;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class ShortMessageWebUISearch : RICH.Common.BM.ShortMessage.ShortMessageWebUI
{
    #region ����GridView������

    static int intDXXBTColumnIndex;
    static int intDXXFJColumnIndex;
    static int intFSSJColumnIndex;
    static int intFSRColumnIndex;
    static int intFSBMColumnIndex;
    static int intSFCKColumnIndex;
    #endregion

    protected override void Page_Init(object sender, EventArgs e)
    {
        // ����SESSION��ֵ
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_SEARCH_FILENAME;
        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_SEARCH_ACCESS_PURVIEW_ID;
        MessageContent = string.Empty;
        if (IsPostBack)
        {
            if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnOperate", StringComparison.OrdinalIgnoreCase))
            {
                switch (Request["ctl00$MainContentPlaceHolder$ddlOperation"].ToLower())
                {
                    case "remove":
                        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_DELETE_PURVIEW_ID;
                        break;
                    default:
                        break;
                }
            }
            else if (string.Equals(Request.Params["__EVENTTARGET"], "ctl00$MainContentPlaceHolder$btnExportAllToFile", StringComparison.OrdinalIgnoreCase))
            {
                Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = OPERATION_EXPORTALL_PURVIEW_ID;
            }
        }
        base.Page_Init(sender, e);
    }
    
    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            InitalizeColumnIndex();
            SetMoreSearchItemDisplay(false);
            InitalizeDataBind();
            InitalizeCoupledDataSource();
JSR.SelectedValues = (string)Request.QueryString["JSR"];
      
            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramShortMessage.AjaxRequest += AjaxManager_AjaxRequest;
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {

            gvList.Columns[intDXXBTColumnIndex].Visible = chkShowDXXBT.Checked;
            gvList.Columns[intDXXFJColumnIndex].Visible = chkShowDXXFJ.Checked;
            gvList.Columns[intFSSJColumnIndex].Visible = chkShowFSSJ.Checked;
            gvList.Columns[intFSRColumnIndex].Visible = chkShowFSR.Checked;
            gvList.Columns[intFSBMColumnIndex].Visible = chkShowFSBM.Checked;
            gvList.Columns[intSFCKColumnIndex].Visible = chkShowSFCK.Checked;
        // ���ݲ�ѯ
        appData = new ShortMessageApplicationData();
        QueryRecord();
        gvList.DataSource = appData.ResultSet;
        gvList.DataBind();
        ViewState["RecordCount"] = appData.RecordCount;
        ViewState["CurrentPage"] = appData.CurrentPage;
        ViewState["PageSize"] = appData.PageSize;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// �趨�����ѯ����ʾ״̬
    /// </summary>
    //=====================================================================
    protected void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;
FSBM_Area.Visible = isDisplay;
      
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// ��ʼ�����ݰ�
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // ��ѯ�����б�
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // ����

            // ��ʼ��������(JSR)�����б�
          JSR.DataSource = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetTreeData_T_PM_UserInfo_SubjectID("UserID", "UserNickName",  null, "null", null);
			JSR.DataFieldID = "ID";
			JSR.DataFieldParentID = "ParentID";
			JSR.DataTextField = "Name";
			JSR.DataValueField = "ID";
			JSR.CheckBoxes = true;
			JSR.CheckChildNodes = true;
              JSR.DataBind();
                  
            // һ��һ��ر�

    }

    #region InitPageInfo
    //=====================================================================
    //  FunctionName : InitPageInfo
    /// <summary>
    /// ��ʼ����ҳ��Ϣ��
    /// </summary>
    //=====================================================================
    private void InitPageInfo()
    {
                if ((int)ViewState["PageCount"] == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"])
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["PageCount"] == 0)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == 0)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = false;
                    btnLastPage.Enabled = false;
                }
                else if ((int)ViewState["CurrentPage"] == 1)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = false;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                else if ((int)ViewState["CurrentPage"] == 2)
                {
                    btnFirstPage.Enabled = false;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }

                else if ((int)ViewState["CurrentPage"] == (int)ViewState["PageCount"] - 1)
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = false;
                }
                else
                {
                    btnFirstPage.Enabled = true;
                    btnPrePage.Enabled = true;
                    btnNextPage.Enabled = true;
                    btnLastPage.Enabled = true;
                }
                ddlPageCount.Items.Clear();
                for (int i = 1; i <= ((int)ViewState["PageCount"] <= 100 ? (int)ViewState["PageCount"] : 100); i++)
                {
                    ddlPageCount.Items.Add(new ListItem("��ǰ��" + i.ToString() + "ҳ", i.ToString()));
                }
                ddlPageSize.Items.Clear();
                for (int i = 10; i <= 500; i=i+10)
                {
                    ddlPageSize.Items.Add(new ListItem("ÿҳ" + i.ToString() + "����¼", i.ToString()));
                }
                ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                ddlPageSize.SelectedValue = ViewState["PageSize"].ToString();
                lblPageInfo.Text = "��<b>{0}</b>ҳ<b><span id=recordcount>{1}</span></b>����¼��";
                lblPageInfo.Text = string.Format(lblPageInfo.Text, ViewState["PageCount"], ViewState["RecordCount"]);
    }
    #endregion

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ���ص������ļ�����
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new ShortMessageApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intDXXBTColumnIndex - 1].Visible = chkShowDXXBT.Checked;
        gvPrint.Columns[intDXXFJColumnIndex - 1].Visible = chkShowDXXFJ.Checked;
        gvPrint.Columns[intFSSJColumnIndex - 1].Visible = chkShowFSSJ.Checked;
        gvPrint.Columns[intFSRColumnIndex - 1].Visible = chkShowFSR.Checked;
        gvPrint.Columns[intFSBMColumnIndex - 1].Visible = chkShowFSBM.Checked;
        gvPrint.Columns[intSFCKColumnIndex - 1].Visible = chkShowSFCK.Checked;
        // ������Ϣ����
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    #region �ؼ��¼�
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request�¼�
    /// </summary>
    //=====================================================================
    protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "Refresh":
                Initalize();
                break;
            default:
                break;
        }
    }

    //=====================================================================
    //  FunctionName : btnShowAdvanceSearchItem_Click
    /// <summary>
    /// �߼���ѯ���水ť�ؼ�Click�¼�
    /// </summary>
    //=====================================================================
    protected void btnShowAdvanceSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(true);
    }
    //=====================================================================
    //  FunctionName : btnShowSimpleSearchItem_Click
    /// <summary>
    /// �򵥲�ѯ���水ť�ؼ�Click�¼�
    /// </summary>
    //=====================================================================
    protected void btnShowSimpleSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(false);
    }
    //=====================================================================
    //  FunctionName : btnAdvanceSearch_Click
    /// <summary>
    /// �߼���ѯ��ť�ؼ�Click�¼�
    /// </summary>
    //=====================================================================
    protected void btnAdvanceSearch_Click(object sender, EventArgs e)
    {
            CustomColumnIndex();
            ViewState.Clear();
            chkAll.Visible = true;
            ddlOperation.Visible = true;
            btnOperate.Visible = true;

            Initalize();
    }
    
    //=====================================================================
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// ��ʼ��������
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // ��ʼ��������ʾ�����
        
            intDXXBTColumnIndex = 1;
            txtDXXBTColumnIndex.Text = intDXXBTColumnIndex.ToString();
            intNext = 1;
            intDXXFJColumnIndex = 2;
            txtDXXFJColumnIndex.Text = intDXXFJColumnIndex.ToString();
            intNext = 2;
            intFSSJColumnIndex = 3;
            txtFSSJColumnIndex.Text = intFSSJColumnIndex.ToString();
            intNext = 3;
            intFSRColumnIndex = 4;
            txtFSRColumnIndex.Text = intFSRColumnIndex.ToString();
            intNext = 4;
            intFSBMColumnIndex = 5;
            txtFSBMColumnIndex.Text = intFSBMColumnIndex.ToString();
            intNext = 5;
            intSFCKColumnIndex = 6;
            txtSFCKColumnIndex.Text = intSFCKColumnIndex.ToString();
            intNext = 6;
            // ��ʼ��һ��һ��Ӧ����ʾ�����
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// �Զ�����ʾ��λ��
    /// </summary>
    //=====================================================================
    private void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // ������ʾ��λ�øı�
        
            intTempColumnIndex = Convert.ToInt32(txtDXXBTColumnIndex.Text);
            if(intTempColumnIndex != intDXXBTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDXXBTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDXXBTColumnIndex - 1]);
                intDXXBTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDXXFJColumnIndex.Text);
            if(intTempColumnIndex != intDXXFJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDXXFJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDXXFJColumnIndex - 1]);
                intDXXFJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFSSJColumnIndex.Text);
            if(intTempColumnIndex != intFSSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFSSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFSSJColumnIndex - 1]);
                intFSSJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFSRColumnIndex.Text);
            if(intTempColumnIndex != intFSRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFSRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFSRColumnIndex - 1]);
                intFSRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFSBMColumnIndex.Text);
            if(intTempColumnIndex != intFSBMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFSBMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFSBMColumnIndex - 1]);
                intFSBMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSFCKColumnIndex.Text);
            if(intTempColumnIndex != intSFCKColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSFCKColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSFCKColumnIndex - 1]);
                intSFCKColumnIndex = intTempColumnIndex;
            }
            // һ��һ��Ӧ����ʾ�иı�
        
    }

    //=====================================================================
    //  FunctionName : gvList_RowDataBound
    /// <summary>
    /// GridView�б�ؼ�RowDataBound�¼�
    /// </summary>
    //=====================================================================
    protected override void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    else if ((Boolean)ViewState["Sort"])
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
            
            e.Row.Attributes.Add("ondblclick", "OpenWindow('ShortMessageWebUIAdd.aspx?ObjectID={0}{1}a=v',770,600,window);return false;".FormatInvariantCulture(strObjectID,  AndChar));
        }
    }
    protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new ShortMessageApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            ShortMessageApplicationData obj = new ShortMessageApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as ShortMessageApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
DXXBT.Text = GetValue(appData.DXXBT); 
      DXXNR.Text = GetValue(appData.DXXNR); 
      FSSJ.Text = GetValue(appData.FSSJBegin); 
            FSSJ.Text = GetValue(appData.FSSJEnd); 
            FSSJ.Text = GetValue(appData.FSSJ); 
      FSR.Text = GetValue(appData.FSR); 
      JSR.SelectedValues = GetValue(appData.JSRBatch); 
      FSBM.Text = GetValue(appData.FSBM); 
      
        }
        Initalize();
    }

    protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new ShortMessageApplicationData();
        GetQueryInputParameter();
        FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData()
        {
            BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
            UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
            BGLX = FilterReportType,
            GXBG = "0",
            XTBG = "0",
            BGCXTJ = JsonHelper.ObjectToJson(appData),
            BGCJSJ = DateTime.Now,
        };
        FilterReportApplicationData filterReportQueryApplicationData;
        if (!FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            filterReportQueryApplicationData = new FilterReportApplicationData()
            {
                BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
                UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                BGLX = FilterReportType,
                XTBG = "0",
                CurrentPage = 1,
                PageSize = 1000,
            };
            filterReportQueryApplicationData = filterReportApplicationLogic.Query(filterReportQueryApplicationData);
            if (filterReportQueryApplicationData.ResultSet.Tables.Count > 0)
            {
                foreach (DataRow item in filterReportQueryApplicationData.ResultSet.Tables[0].Rows)
                {
                    filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = GetValue(item["ObjectID"]), OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID });
                }
            }
        }
        filterReportApplicationLogic.Add(filterReportApplicationData);
        FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
        FilterReportList.Items.FindByText(FilterReportName.Text.TrimIfNotNullOrWhiteSpace()).Selected = true;
    }

    protected virtual void btnDeleteFilterReport_Click(object sender, EventArgs e)
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
            MessageContent += @"<font color=""red"">û��Ȩ��ɾ��ϵͳ���档</font>";
        }
        else if (!filterReportApplicationData.UserID.Equals((string) Session[ConstantsManager.SESSION_USER_ID]))
        {
            MessageContent += @"<font color=""red"">û��Ȩ��ɾ�������档</font>";
        }
        else
        {
            filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = filterReportApplicationData.ObjectID, OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID});
            FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
            FilterReportList_SelectedIndexChanged(sender, e);
        }
    }
    #endregion

    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// ��ʼ����������
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }



    //=====================================================================
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// �õ���ѯ�û��������������ͨ��Request����
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������

            validateData = ValidateDXXBT(DXXBT.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DXXBT = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateDXXNR(DXXNR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DXXNR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFSSJBegin(FSSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FSSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateFSSJEnd(FSSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FSSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateFSSJ(FSSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FSSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateFSR(FSR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FSR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFSBM(FSBM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FSBM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateJSRBatch(JSR.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.JSRBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      

      if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
        {
          appData.QueryType = "AND";
        }
        else
        {
          appData.QueryType = ViewState["QueryType"].ToString();
        }
      }
      else
      {
        appData.SortField = "AND";
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
      {
        if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
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
      if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
        {
          appData.SortField = DEFAULT_SORT_FIELD;
        }
        else
        {
          appData.SortField = ViewState["SortField"].ToString();
        }
      }
      else
      {
        appData.SortField = DEFAULT_SORT_FIELD;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
        {
          appData.PageSize = DEFAULT_PAGE_SIZE;
        }
        else
        {
          appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
        }
      }
      else
      {
        appData.PageSize = DEFAULT_PAGE_SIZE;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
        {
          appData.CurrentPage = DEFAULT_CURRENT_PAGE;
        }
        else
        {
          appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        }
      }
      else
      {
        appData.CurrentPage = DEFAULT_CURRENT_PAGE;
      }
      return boolReturn;                
    }

    //=====================================================================
    //  FunctionName : GetTableCaption
    /// <summary>
    /// �õ���Ϣ����
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
            System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
            sbCaption.Append(@"��Ϣ�б�");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"��ѯ�������£�");

            if (!DataValidateManager.ValidateIsNull(DXXBT.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("���⣺");
                sbCaption.Append(DXXBT.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(DXXNR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("���ݣ�");
                sbCaption.Append(DXXNR.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�䣺");
                sbCaption.Append(FSSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�俪ʼֵ��");
                sbCaption.Append(FSSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�����ֵ��");
                sbCaption.Append(FSSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�����ˣ�");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", FSR.Text, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSBM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("���Ͳ��ţ�");
                sbCaption.Append(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity().GetValueByFixCondition("DWBH", FSBM.Text, "DWMC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(JSR.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�����ˣ�");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", JSR.SelectedValues, "UserNickName"));
               sbCaption.Append(@"</div>");
            }
            // һ��һ��ر�

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
}

