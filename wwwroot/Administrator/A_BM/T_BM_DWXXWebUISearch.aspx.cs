/****************************************************** 
FileName:T_BM_DWXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_DWXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_DWXXWebUISearch : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
{
    #region ����GridView������

    static int intDWBHColumnIndex;
    static int intDWMCColumnIndex;
    static int intSJDWBHColumnIndex;
    static int intDZColumnIndex;
    static int intYBColumnIndex;
    static int intLXBMColumnIndex;
    static int intLXDHColumnIndex;
    static int intEmailColumnIndex;
    static int intLXRColumnIndex;
    static int intSJColumnIndex;
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

            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramT_BM_DWXX.AjaxRequest += AjaxManager_AjaxRequest;
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

            gvList.Columns[intDWBHColumnIndex].Visible = chkShowDWBH.Checked;
            gvList.Columns[intDWMCColumnIndex].Visible = chkShowDWMC.Checked;
            gvList.Columns[intSJDWBHColumnIndex].Visible = chkShowSJDWBH.Checked;
            gvList.Columns[intDZColumnIndex].Visible = chkShowDZ.Checked;
            gvList.Columns[intYBColumnIndex].Visible = chkShowYB.Checked;
            gvList.Columns[intLXBMColumnIndex].Visible = chkShowLXBM.Checked;
            gvList.Columns[intLXDHColumnIndex].Visible = chkShowLXDH.Checked;
            gvList.Columns[intEmailColumnIndex].Visible = chkShowEmail.Checked;
            gvList.Columns[intLXRColumnIndex].Visible = chkShowLXR.Checked;
            gvList.Columns[intSJColumnIndex].Visible = chkShowSJ.Checked;
        // ���ݲ�ѯ
        appData = new T_BM_DWXXApplicationData();
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
DWBH_Area.Visible = isDisplay;
      DZ_Area.Visible = isDisplay;
      
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

            // ��ʼ���ϼ���λ(SJDWBH)�����б�
          SJDWBH.DataSource = GetDataSource_SJDWBH_AdvanceSearch();
            SJDWBH.DataTextField = "DWMC";
            SJDWBH.DataValueField = "DWBH";
              SJDWBH.DataBind();
                  SJDWBH.Items.Insert(0, new ListItem("ѡ���ϼ���λ", ""));
                    
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
        appData = new T_BM_DWXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intDWBHColumnIndex - 1].Visible = chkShowDWBH.Checked;
        gvPrint.Columns[intDWMCColumnIndex - 1].Visible = chkShowDWMC.Checked;
        gvPrint.Columns[intSJDWBHColumnIndex - 1].Visible = chkShowSJDWBH.Checked;
        gvPrint.Columns[intDZColumnIndex - 1].Visible = chkShowDZ.Checked;
        gvPrint.Columns[intYBColumnIndex - 1].Visible = chkShowYB.Checked;
        gvPrint.Columns[intLXBMColumnIndex - 1].Visible = chkShowLXBM.Checked;
        gvPrint.Columns[intLXDHColumnIndex - 1].Visible = chkShowLXDH.Checked;
        gvPrint.Columns[intEmailColumnIndex - 1].Visible = chkShowEmail.Checked;
        gvPrint.Columns[intLXRColumnIndex - 1].Visible = chkShowLXR.Checked;
        gvPrint.Columns[intSJColumnIndex - 1].Visible = chkShowSJ.Checked;
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
        
            intDWBHColumnIndex = 1;
            txtDWBHColumnIndex.Text = intDWBHColumnIndex.ToString();
            intNext = 1;
            intDWMCColumnIndex = 2;
            txtDWMCColumnIndex.Text = intDWMCColumnIndex.ToString();
            intNext = 2;
            intSJDWBHColumnIndex = 3;
            txtSJDWBHColumnIndex.Text = intSJDWBHColumnIndex.ToString();
            intNext = 3;
            intDZColumnIndex = 4;
            txtDZColumnIndex.Text = intDZColumnIndex.ToString();
            intNext = 4;
            intYBColumnIndex = 5;
            txtYBColumnIndex.Text = intYBColumnIndex.ToString();
            intNext = 5;
            intLXBMColumnIndex = 6;
            txtLXBMColumnIndex.Text = intLXBMColumnIndex.ToString();
            intNext = 6;
            intLXDHColumnIndex = 7;
            txtLXDHColumnIndex.Text = intLXDHColumnIndex.ToString();
            intNext = 7;
            intEmailColumnIndex = 8;
            txtEmailColumnIndex.Text = intEmailColumnIndex.ToString();
            intNext = 8;
            intLXRColumnIndex = 9;
            txtLXRColumnIndex.Text = intLXRColumnIndex.ToString();
            intNext = 9;
            intSJColumnIndex = 10;
            txtSJColumnIndex.Text = intSJColumnIndex.ToString();
            intNext = 10;
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
        
            intTempColumnIndex = Convert.ToInt32(txtDWBHColumnIndex.Text);
            if(intTempColumnIndex != intDWBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDWBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDWBHColumnIndex - 1]);
                intDWBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDWMCColumnIndex.Text);
            if(intTempColumnIndex != intDWMCColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDWMCColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDWMCColumnIndex - 1]);
                intDWMCColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSJDWBHColumnIndex.Text);
            if(intTempColumnIndex != intSJDWBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSJDWBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSJDWBHColumnIndex - 1]);
                intSJDWBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDZColumnIndex.Text);
            if(intTempColumnIndex != intDZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDZColumnIndex - 1]);
                intDZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYBColumnIndex.Text);
            if(intTempColumnIndex != intYBColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYBColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYBColumnIndex - 1]);
                intYBColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLXBMColumnIndex.Text);
            if(intTempColumnIndex != intLXBMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLXBMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLXBMColumnIndex - 1]);
                intLXBMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLXDHColumnIndex.Text);
            if(intTempColumnIndex != intLXDHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLXDHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLXDHColumnIndex - 1]);
                intLXDHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtEmailColumnIndex.Text);
            if(intTempColumnIndex != intEmailColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intEmailColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intEmailColumnIndex - 1]);
                intEmailColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLXRColumnIndex.Text);
            if(intTempColumnIndex != intLXRColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLXRColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLXRColumnIndex - 1]);
                intLXRColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSJColumnIndex.Text);
            if(intTempColumnIndex != intSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSJColumnIndex - 1]);
                intSJColumnIndex = intTempColumnIndex;
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
            
            e.Row.Attributes.Add("ondblclick", "OpenWindow('T_BM_DWXXWebUIAdd.aspx?ObjectID={0}{1}a=v',770,600,window);return false;".FormatInvariantCulture(strObjectID,  AndChar));
        }
    }
    protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_DWXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_DWXXApplicationData obj = new T_BM_DWXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_DWXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
DWMC.Text = GetValue(appData.DWMC); 
      SJDWBH.SelectedValue = GetValue(appData.SJDWBH); 
      LXR.Text = GetValue(appData.LXR); 
      DWBH.Text = GetValue(appData.DWBH); 
      DZ.Text = GetValue(appData.DZ); 
      
        }
        Initalize();
    }

    protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_DWXXApplicationData();
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

            validateData = ValidateDWBH(DWBH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateDWMC(DWMC.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWMC = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateDZ(DZ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DZ = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateLXR(LXR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXR = Convert.ToString(validateData.Value.ToString());
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
            sbCaption.Append(@"��λ��Ϣ�б�");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"��ѯ�������£�");

            if (!DataValidateManager.ValidateIsNull(DWBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��λ��ţ�");
                sbCaption.Append(DWBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(DWMC.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��λ���ƣ�");
                sbCaption.Append(DWMC.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SJDWBH.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�ϼ���λ��");
                sbCaption.Append(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity().GetValueByFixCondition("DWBH", SJDWBH.SelectedValue, "DWMC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(DZ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��ַ��");
                sbCaption.Append(DZ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LXR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��ϵ�ˣ�");
                sbCaption.Append(LXR.Text);
               sbCaption.Append(@"</div>");
            }
            // һ��һ��ر�

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
}

