/****************************************************** 
FileName:DictionaryWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.Dictionary;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class DictionaryWebUISearch : RICH.Common.BM.Dictionary.DictionaryWebUI
{
    #region 定义GridView列索引

    static int intDMColumnIndex;
    static int intLXColumnIndex;
    static int intMCColumnIndex;
    static int intSJDMColumnIndex;
    static int intSMColumnIndex;
    #endregion

    protected override void Page_Init(object sender, EventArgs e)
    {
        // 基本SESSION赋值
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
LX.SelectedValue = (string)Request.QueryString["LX"];
      LXCoupled();SJDM.SelectedValue = (string)Request.QueryString["SJDM"];
      
            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramDictionary.AjaxRequest += AjaxManager_AjaxRequest;
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {

            gvList.Columns[intDMColumnIndex].Visible = chkShowDM.Checked;
            gvList.Columns[intLXColumnIndex].Visible = chkShowLX.Checked;
            gvList.Columns[intMCColumnIndex].Visible = chkShowMC.Checked;
            gvList.Columns[intSJDMColumnIndex].Visible = chkShowSJDM.Checked;
            gvList.Columns[intSMColumnIndex].Visible = chkShowSM.Checked;
        // 数据查询
        appData = new DictionaryApplicationData();
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
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;

    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // 查询报告列表
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // 主表

            // 初始化类型(LX)下拉列表
          LX.DataSource = GetDataSource_LX_AdvanceSearch();
            LX.DataTextField = "MC";
            LX.DataValueField = "DM";
              LX.DataBind();
                  LX.Items.Insert(0, new ListItem("选择类型", ""));
                    
            // 初始化上级代码(SJDM)下拉列表
            SJDM.DataTextField = "MC";
            SJDM.DataValueField = "DM";
            LXCoupled();
        
            // 一对一相关表

    }

    #region InitPageInfo
    //=====================================================================
    //  FunctionName : InitPageInfo
    /// <summary>
    /// 初始化分页信息栏
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
                    ddlPageCount.Items.Add(new ListItem("当前第" + i.ToString() + "页", i.ToString()));
                }
                ddlPageSize.Items.Clear();
                for (int i = 10; i <= 500; i=i+10)
                {
                    ddlPageSize.Items.Add(new ListItem("每页" + i.ToString() + "条记录", i.ToString()));
                }
                ddlPageCount.SelectedValue = ViewState["CurrentPage"].ToString();
                ddlPageSize.SelectedValue = ViewState["PageSize"].ToString();
                lblPageInfo.Text = "共<b>{0}</b>页<b><span id=recordcount>{1}</span></b>条记录。";
                lblPageInfo.Text = string.Format(lblPageInfo.Text, ViewState["PageCount"], ViewState["RecordCount"]);
    }
    #endregion

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new DictionaryApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intDMColumnIndex - 1].Visible = chkShowDM.Checked;
        gvPrint.Columns[intLXColumnIndex - 1].Visible = chkShowLX.Checked;
        gvPrint.Columns[intMCColumnIndex - 1].Visible = chkShowMC.Checked;
        gvPrint.Columns[intSJDMColumnIndex - 1].Visible = chkShowSJDM.Checked;
        gvPrint.Columns[intSMColumnIndex - 1].Visible = chkShowSM.Checked;
        // 创建信息标题
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

    #region 控件事件
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request事件
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
    /// 高级查询界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowAdvanceSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(true);
    }
    //=====================================================================
    //  FunctionName : btnShowSimpleSearchItem_Click
    /// <summary>
    /// 简单查询界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowSimpleSearchItem_Click(object sender, EventArgs e)
    {
        SetMoreSearchItemDisplay(false);
    }
    //=====================================================================
    //  FunctionName : btnAdvanceSearch_Click
    /// <summary>
    /// 高级查询按钮控件Click事件
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
    /// 初始化列索引
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // 初始化主表显示列序号
        
            intDMColumnIndex = 1;
            txtDMColumnIndex.Text = intDMColumnIndex.ToString();
            intNext = 1;
            intLXColumnIndex = 2;
            txtLXColumnIndex.Text = intLXColumnIndex.ToString();
            intNext = 2;
            intMCColumnIndex = 3;
            txtMCColumnIndex.Text = intMCColumnIndex.ToString();
            intNext = 3;
            intSJDMColumnIndex = 4;
            txtSJDMColumnIndex.Text = intSJDMColumnIndex.ToString();
            intNext = 4;
            intSMColumnIndex = 5;
            txtSMColumnIndex.Text = intSMColumnIndex.ToString();
            intNext = 5;
            // 初始化一对一对应表显示列序号
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// 自定义显示列位置
    /// </summary>
    //=====================================================================
    private void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // 主表显示列位置改变
        
            intTempColumnIndex = Convert.ToInt32(txtDMColumnIndex.Text);
            if(intTempColumnIndex != intDMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDMColumnIndex - 1]);
                intDMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtLXColumnIndex.Text);
            if(intTempColumnIndex != intLXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intLXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intLXColumnIndex - 1]);
                intLXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtMCColumnIndex.Text);
            if(intTempColumnIndex != intMCColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intMCColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intMCColumnIndex - 1]);
                intMCColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSJDMColumnIndex.Text);
            if(intTempColumnIndex != intSJDMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSJDMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSJDMColumnIndex - 1]);
                intSJDMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSMColumnIndex.Text);
            if(intTempColumnIndex != intSMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSMColumnIndex - 1]);
                intSMColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    //=====================================================================
    //  FunctionName : gvList_RowDataBound
    /// <summary>
    /// GridView列表控件RowDataBound事件
    /// </summary>
    //=====================================================================
    protected override void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    else if ((Boolean)ViewState["Sort"])
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
            
            e.Row.Attributes.Add("ondblclick", "OpenWindow('DictionaryWebUIAdd.aspx?ObjectID={0}{1}a=v',770,600,window);return false;".FormatInvariantCulture(strObjectID,  AndChar));
        }
    }
    protected virtual void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new DictionaryApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            DictionaryApplicationData obj = new DictionaryApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as DictionaryApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
DM.Text = GetValue(appData.DM); 
      LX.SelectedValue = GetValue(appData.LX); 
      MC.Text = GetValue(appData.MC); 
      SJDM.SelectedValue = GetValue(appData.SJDM); 
      SM.Text = GetValue(appData.SM); 
      
        }
        Initalize();
    }

    protected virtual void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new DictionaryApplicationData();
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
            MessageContent += @"<font color=""red"">没有权限删除系统报告。</font>";
        }
        else if (!filterReportApplicationData.UserID.Equals((string) Session[ConstantsManager.SESSION_USER_ID]))
        {
            MessageContent += @"<font color=""red"">没有权限删除共享报告。</font>";
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
    /// 初始化联动设置
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

        // 类型联动设置
        LX.AutoPostBack = true;
        LX.SelectedIndexChanged += new System.EventHandler(this.LX_SelectedIndexChanged);
  
    }


    //=====================================================================
    //  FunctionName : LX_SelectedIndexChanged
    /// <summary>
    /// 类型的SelectedIndexChanged事件
    /// </summary>
    //=====================================================================
    protected void LX_SelectedIndexChanged(object sender, EventArgs e)
    {
        LXCoupled();
    }

    //=====================================================================
    //  FunctionName : LXCoupled()
    /// <summary>
    /// 类型的联动处理方法
    /// </summary>
    //=====================================================================
    protected void LXCoupled()
    {
        if (!DataValidateManager.ValidateIsNull(LX.SelectedValue))
        {
            SJDM.DataSource = GetDataSource_SJDM("LX", LX.SelectedValue, true);
            SJDM.DataBind();
            if (!(SJDM.Items.Count > 0))
            {
                SJDM.Items.Insert(0, new ListItem("无", ""));
            }
            else
            {
                SJDM.Items.Insert(0, new ListItem("选择", ""));
            }
        }
        else
        {
            SJDM.Items.Clear();
            SJDM.Items.Insert(0, new ListItem("请先选择类型", ""));
        }
        SJDM.Attributes.Add("onchange", "RefreshGrid()");
        Initalize();
    }
  

    //=====================================================================
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// 得到查询用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数

            validateData = ValidateDM(DM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateLX(LX.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LX = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateMC(MC.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.MC = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemSJDM.Checked)
                    {
                        appData.SJDM = null;
                        appData.SJDMBatch = GetSubItem_SJDM(SJDM.SelectedValue) + "," + SJDM.SelectedValue;
                    }
                }
            }
        
            validateData = ValidateSM(SM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SM = Convert.ToString(validateData.Value.ToString());
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
    /// 得到信息标题
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
            System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
            sbCaption.Append(@"字典信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(DM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("代码：");
                sbCaption.Append(DM.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(LX.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("类型：");
                sbCaption.Append(new RICH.Common.BM.DictionaryType.DictionaryTypeBusinessEntity().GetValueByFixCondition("DM", LX.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(MC.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("名称：");
                sbCaption.Append(MC.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SJDM.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("上级代码：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", SJDM.SelectedValue, "MC"));
                
                if (chkShowSubItemSJDM.Checked)
                {
                    sbCaption.Append("的子（下级）项信息");
                }
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("说明：");
                sbCaption.Append(SM.Text);
               sbCaption.Append(@"</div>");
            }
            // 一对一相关表

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
}

