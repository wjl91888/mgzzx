/****************************************************** 
FileName:T_BG_0601WebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BG_0601;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BG_0601WebUISearch : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
{
    #region ����GridView������

    static int intFBHColumnIndex;
    static int intBTColumnIndex;
    static int intFBLMColumnIndex;
    static int intXXLXColumnIndex;
    static int intFJXZDZColumnIndex;
    static int intXXZTColumnIndex;
    static int intIsTopColumnIndex;
    static int intTopSortColumnIndex;
    static int intIsBestColumnIndex;
    static int intFBRJGHColumnIndex;
    static int intFBSJRQColumnIndex;
    static int intFBIPColumnIndex;
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
FBLM.SelectedValue = (string)Request.QueryString["FBLM"];
      FBRJGH.Text = (string)Request.QueryString["FBRJGH"];
      
            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramT_BG_0601.AjaxRequest += AjaxManager_AjaxRequest;
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

            gvList.Columns[intFBHColumnIndex].Visible = chkShowFBH.Checked;
            gvList.Columns[intBTColumnIndex].Visible = chkShowBT.Checked;
            gvList.Columns[intFBLMColumnIndex].Visible = chkShowFBLM.Checked;
            gvList.Columns[intXXLXColumnIndex].Visible = chkShowXXLX.Checked;
            gvList.Columns[intFJXZDZColumnIndex].Visible = chkShowFJXZDZ.Checked;
            gvList.Columns[intXXZTColumnIndex].Visible = chkShowXXZT.Checked;
            gvList.Columns[intIsTopColumnIndex].Visible = chkShowIsTop.Checked;
            gvList.Columns[intTopSortColumnIndex].Visible = chkShowTopSort.Checked;
            gvList.Columns[intIsBestColumnIndex].Visible = chkShowIsBest.Checked;
            gvList.Columns[intFBRJGHColumnIndex].Visible = chkShowFBRJGH.Checked;
            gvList.Columns[intFBSJRQColumnIndex].Visible = chkShowFBSJRQ.Checked;
            gvList.Columns[intFBIPColumnIndex].Visible = chkShowFBIP.Checked;FBLM.RepeatColumns = 1;
        
        // ���ݲ�ѯ
        appData = new T_BG_0601ApplicationData();
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
FBH_Area.Visible = isDisplay;
      XXLX_Area.Visible = isDisplay;
      IsTop_Area.Visible = isDisplay;
      IsBest_Area.Visible = isDisplay;
      FBRJGH_Area.Visible = isDisplay;
      
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

            // ��ʼ��������Ŀ(FBLM)�����б�
          FBLM.DataSource = GetDataSource_FBLM_AdvanceSearch();
            FBLM.DataTextField = "LMM";
            FBLM.DataValueField = "LMH";
              FBLM.DataBind();
                  FBLM.RepeatColumns = 1;
                    
            // ��ʼ����Ϣ����(XXLX)�����б�
          XXLX.DataSource = GetDataSource_XXLX_AdvanceSearch();
            XXLX.DataTextField = "MC";
            XXLX.DataValueField = "DM";
              XXLX.DataBind();
                  XXLX.Items.Insert(0, new ListItem("ѡ����Ϣ����", ""));
                    
            // ��ʼ���Ƿ��ö�(IsTop)�����б�
          IsTop.DataSource = GetDataSource_IsTop_AdvanceSearch();
            IsTop.DataTextField = "MC";
            IsTop.DataValueField = "DM";
              IsTop.DataBind();
                  IsTop.Items.Insert(0, new ListItem("ѡ���Ƿ��ö�", ""));
                    
            // ��ʼ���Ƽ�(IsBest)�����б�
          IsBest.DataSource = GetDataSource_IsBest_AdvanceSearch();
            IsBest.DataTextField = "MC";
            IsBest.DataValueField = "DM";
              IsBest.DataBind();
                  IsBest.Items.Insert(0, new ListItem("ѡ���Ƽ�", ""));
                    
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
        appData = new T_BG_0601ApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intFBHColumnIndex - 1].Visible = chkShowFBH.Checked;
        gvPrint.Columns[intBTColumnIndex - 1].Visible = chkShowBT.Checked;
        gvPrint.Columns[intFBLMColumnIndex - 1].Visible = chkShowFBLM.Checked;
        gvPrint.Columns[intXXLXColumnIndex - 1].Visible = chkShowXXLX.Checked;
        gvPrint.Columns[intFJXZDZColumnIndex - 1].Visible = chkShowFJXZDZ.Checked;
        gvPrint.Columns[intXXZTColumnIndex - 1].Visible = chkShowXXZT.Checked;
        gvPrint.Columns[intIsTopColumnIndex - 1].Visible = chkShowIsTop.Checked;
        gvPrint.Columns[intTopSortColumnIndex - 1].Visible = chkShowTopSort.Checked;
        gvPrint.Columns[intIsBestColumnIndex - 1].Visible = chkShowIsBest.Checked;
        gvPrint.Columns[intFBRJGHColumnIndex - 1].Visible = chkShowFBRJGH.Checked;
        gvPrint.Columns[intFBSJRQColumnIndex - 1].Visible = chkShowFBSJRQ.Checked;
        gvPrint.Columns[intFBIPColumnIndex - 1].Visible = chkShowFBIP.Checked;
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
        
            intFBHColumnIndex = 1;
            txtFBHColumnIndex.Text = intFBHColumnIndex.ToString();
            intNext = 1;
            intBTColumnIndex = 2;
            txtBTColumnIndex.Text = intBTColumnIndex.ToString();
            intNext = 2;
            intFBLMColumnIndex = 3;
            txtFBLMColumnIndex.Text = intFBLMColumnIndex.ToString();
            intNext = 3;
            intXXLXColumnIndex = 4;
            txtXXLXColumnIndex.Text = intXXLXColumnIndex.ToString();
            intNext = 4;
            intFJXZDZColumnIndex = 5;
            txtFJXZDZColumnIndex.Text = intFJXZDZColumnIndex.ToString();
            intNext = 5;
            intXXZTColumnIndex = 6;
            txtXXZTColumnIndex.Text = intXXZTColumnIndex.ToString();
            intNext = 6;
            intIsTopColumnIndex = 7;
            txtIsTopColumnIndex.Text = intIsTopColumnIndex.ToString();
            intNext = 7;
            intTopSortColumnIndex = 8;
            txtTopSortColumnIndex.Text = intTopSortColumnIndex.ToString();
            intNext = 8;
            intIsBestColumnIndex = 9;
            txtIsBestColumnIndex.Text = intIsBestColumnIndex.ToString();
            intNext = 9;
            intFBRJGHColumnIndex = 10;
            txtFBRJGHColumnIndex.Text = intFBRJGHColumnIndex.ToString();
            intNext = 10;
            intFBSJRQColumnIndex = 11;
            txtFBSJRQColumnIndex.Text = intFBSJRQColumnIndex.ToString();
            intNext = 11;
            intFBIPColumnIndex = 12;
            txtFBIPColumnIndex.Text = intFBIPColumnIndex.ToString();
            intNext = 12;
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
        
            intTempColumnIndex = Convert.ToInt32(txtFBHColumnIndex.Text);
            if(intTempColumnIndex != intFBHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBHColumnIndex - 1]);
                intFBHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBTColumnIndex.Text);
            if(intTempColumnIndex != intBTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBTColumnIndex - 1]);
                intBTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFBLMColumnIndex.Text);
            if(intTempColumnIndex != intFBLMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBLMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBLMColumnIndex - 1]);
                intFBLMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXXLXColumnIndex.Text);
            if(intTempColumnIndex != intXXLXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXXLXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXXLXColumnIndex - 1]);
                intXXLXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFJXZDZColumnIndex.Text);
            if(intTempColumnIndex != intFJXZDZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFJXZDZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFJXZDZColumnIndex - 1]);
                intFJXZDZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXXZTColumnIndex.Text);
            if(intTempColumnIndex != intXXZTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXXZTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXXZTColumnIndex - 1]);
                intXXZTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtIsTopColumnIndex.Text);
            if(intTempColumnIndex != intIsTopColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intIsTopColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intIsTopColumnIndex - 1]);
                intIsTopColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtTopSortColumnIndex.Text);
            if(intTempColumnIndex != intTopSortColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intTopSortColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intTopSortColumnIndex - 1]);
                intTopSortColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtIsBestColumnIndex.Text);
            if(intTempColumnIndex != intIsBestColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intIsBestColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intIsBestColumnIndex - 1]);
                intIsBestColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFBRJGHColumnIndex.Text);
            if(intTempColumnIndex != intFBRJGHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBRJGHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBRJGHColumnIndex - 1]);
                intFBRJGHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFBSJRQColumnIndex.Text);
            if(intTempColumnIndex != intFBSJRQColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBSJRQColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBSJRQColumnIndex - 1]);
                intFBSJRQColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFBIPColumnIndex.Text);
            if(intTempColumnIndex != intFBIPColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBIPColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBIPColumnIndex - 1]);
                intFBIPColumnIndex = intTempColumnIndex;
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
            
            e.Row.Attributes.Add("ondblclick", "OpenWindow('T_BG_0601WebUIDetail.aspx?ObjectID=" + strObjectID + "',770,600,window);return false;");
        }
    }
    protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BG_0601ApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BG_0601ApplicationData obj = new T_BG_0601ApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BG_0601ApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
BT.Text = GetValue(appData.BT); 
      FBLM.SelectedValue = GetValue(appData.FBLMBatch); 
      XXNR.Text = GetValue(appData.XXNR); 
      FBSJRQ.Text = GetValue(appData.FBSJRQBegin); 
            FBSJRQ.Text = GetValue(appData.FBSJRQEnd); 
            FBSJRQ.Text = GetValue(appData.FBSJRQ); 
      FBH.Text = GetValue(appData.FBH); 
      XXLX.SelectedValue = GetValue(appData.XXLX); 
      IsTop.SelectedValue = GetValue(appData.IsTop); 
      IsBest.SelectedValue = GetValue(appData.IsBest); 
      FBRJGH.Text = GetValue(appData.FBRJGH); 
      
        }
        Initalize();
    }

    protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BG_0601ApplicationData();
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

            validateData = ValidateFBH(FBH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateBT(BT.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BT = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBLMBatch(FBLM.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBLMBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBLM(FBLM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemFBLM.Checked)
                    {
                        appData.FBLM = null;
                        appData.FBLMBatch = GetSubItem_FBLM(FBLM.SelectedValue) + "," + FBLM.SelectedValue;
                    }
                }
            }
        
            validateData = ValidateXXLX(XXLX.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XXLX = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateXXNR(XXNR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XXNR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateIsTop(IsTop.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.IsTop = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateIsBest(IsBest.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.IsBest = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBRJGH(FBRJGH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBRJGH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBSJRQBegin(FBSJRQBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBSJRQBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateFBSJRQEnd(FBSJRQEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBSJRQEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateFBSJRQ(FBSJRQ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBSJRQ = Convert.ToDateTime(validateData.Value.ToString());
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
            sbCaption.Append(@"������Ϣ�б�");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"��ѯ�������£�");

            if (!DataValidateManager.ValidateIsNull(FBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�����ţ�");
                sbCaption.Append(FBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BT.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("���⣺");
                sbCaption.Append(BT.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBLM.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("������Ŀ��");
                sbCaption.Append(new RICH.Common.BM.T_BG_0602.T_BG_0602BusinessEntity().GetValueByFixCondition("LMH", FBLM.SelectedValues, "LMM"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XXLX.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��Ϣ���ͣ�");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", XXLX.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XXNR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("��Ϣ���ݣ�");
                sbCaption.Append(XXNR.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(IsTop.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�Ƿ��ö���");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", IsTop.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(IsBest.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�Ƽ���");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", IsBest.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBRJGH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�����ˣ�");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", FBRJGH.Text, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�䣺");
                sbCaption.Append(FBSJRQ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�俪ʼֵ��");
                sbCaption.Append(FBSJRQBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�����ֵ��");
                sbCaption.Append(FBSJRQEnd.Text);
               sbCaption.Append(@"</div>");
            }
            // һ��һ��ر�

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
}

