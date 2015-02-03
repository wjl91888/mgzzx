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
    #region 定义GridView列索引

    static int intFBHColumnIndex;
    static int intBTColumnIndex;
    static int intFBLMColumnIndex;
    static int intFBBMColumnIndex;
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
      FBBM.SelectedValue = (string)Request.QueryString["FBBM"];
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
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
    
        DetailPage = true;
            gvList.Columns[intFBHColumnIndex].Visible = chkShowFBH.Checked;
            gvList.Columns[intBTColumnIndex].Visible = chkShowBT.Checked;
            gvList.Columns[intFBLMColumnIndex].Visible = chkShowFBLM.Checked;
            gvList.Columns[intFBBMColumnIndex].Visible = chkShowFBBM.Checked;
            gvList.Columns[intXXLXColumnIndex].Visible = chkShowXXLX.Checked;
            gvList.Columns[intFJXZDZColumnIndex].Visible = chkShowFJXZDZ.Checked;
            gvList.Columns[intXXZTColumnIndex].Visible = chkShowXXZT.Checked;
            gvList.Columns[intIsTopColumnIndex].Visible = chkShowIsTop.Checked;
            gvList.Columns[intTopSortColumnIndex].Visible = chkShowTopSort.Checked;
            gvList.Columns[intIsBestColumnIndex].Visible = chkShowIsBest.Checked;
            gvList.Columns[intFBRJGHColumnIndex].Visible = chkShowFBRJGH.Checked;
            gvList.Columns[intFBSJRQColumnIndex].Visible = chkShowFBSJRQ.Checked;
            gvList.Columns[intFBIPColumnIndex].Visible = chkShowFBIP.Checked;FBLM.RepeatColumns = 1;
        
        // 数据查询
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
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected override void SetMoreSearchItemDisplay(bool isDisplay = false)
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
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // 查询报告列表
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // 主表

            // 初始化发布栏目(FBLM)下拉列表
          FBLM.DataSource = GetDataSource_FBLM_AdvanceSearch();
            FBLM.DataTextField = "LMM";
            FBLM.DataValueField = "LMH";
              FBLM.DataBind();
                  FBLM.RepeatColumns = 1;
                    
            // 初始化发布部门(FBBM)下拉列表
          FBBM.DataSource = GetDataSource_FBBM_AdvanceSearch();
            FBBM.DataTextField = "DWMC";
            FBBM.DataValueField = "DWBH";
              FBBM.DataBind();
                  FBBM.Items.Insert(0, new ListItem("选择发布部门", ""));
                    
            // 初始化信息类型(XXLX)下拉列表
          XXLX.DataSource = GetDataSource_XXLX_AdvanceSearch();
            XXLX.DataTextField = "MC";
            XXLX.DataValueField = "DM";
              XXLX.DataBind();
                  XXLX.Items.Insert(0, new ListItem("选择信息类型", ""));
                    
            // 初始化是否置顶(IsTop)下拉列表
          IsTop.DataSource = GetDataSource_IsTop_AdvanceSearch();
            IsTop.DataTextField = "MC";
            IsTop.DataValueField = "DM";
              IsTop.DataBind();
                  IsTop.Items.Insert(0, new ListItem("选择是否置顶", ""));
                    
            // 初始化推荐(IsBest)下拉列表
          IsBest.DataSource = GetDataSource_IsBest_AdvanceSearch();
            IsBest.DataTextField = "MC";
            IsBest.DataValueField = "DM";
              IsBest.DataBind();
                  IsBest.Items.Insert(0, new ListItem("选择推荐", ""));
                    
            // 一对一相关表

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
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
        gvPrint.Columns[intFBBMColumnIndex - 1].Visible = chkShowFBBM.Checked;
        gvPrint.Columns[intXXLXColumnIndex - 1].Visible = chkShowXXLX.Checked;
        gvPrint.Columns[intFJXZDZColumnIndex - 1].Visible = chkShowFJXZDZ.Checked;
        gvPrint.Columns[intXXZTColumnIndex - 1].Visible = chkShowXXZT.Checked;
        gvPrint.Columns[intIsTopColumnIndex - 1].Visible = chkShowIsTop.Checked;
        gvPrint.Columns[intTopSortColumnIndex - 1].Visible = chkShowTopSort.Checked;
        gvPrint.Columns[intIsBestColumnIndex - 1].Visible = chkShowIsBest.Checked;
        gvPrint.Columns[intFBRJGHColumnIndex - 1].Visible = chkShowFBRJGH.Checked;
        gvPrint.Columns[intFBSJRQColumnIndex - 1].Visible = chkShowFBSJRQ.Checked;
        gvPrint.Columns[intFBIPColumnIndex - 1].Visible = chkShowFBIP.Checked;
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
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// 初始化列索引
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // 初始化主表显示列序号
        
            intFBHColumnIndex = 1;
            txtFBHColumnIndex.Text = intFBHColumnIndex.ToString();
            intNext = 1;
            intBTColumnIndex = 2;
            txtBTColumnIndex.Text = intBTColumnIndex.ToString();
            intNext = 2;
            intFBLMColumnIndex = 3;
            txtFBLMColumnIndex.Text = intFBLMColumnIndex.ToString();
            intNext = 3;
            intFBBMColumnIndex = 4;
            txtFBBMColumnIndex.Text = intFBBMColumnIndex.ToString();
            intNext = 4;
            intXXLXColumnIndex = 5;
            txtXXLXColumnIndex.Text = intXXLXColumnIndex.ToString();
            intNext = 5;
            intFJXZDZColumnIndex = 6;
            txtFJXZDZColumnIndex.Text = intFJXZDZColumnIndex.ToString();
            intNext = 6;
            intXXZTColumnIndex = 7;
            txtXXZTColumnIndex.Text = intXXZTColumnIndex.ToString();
            intNext = 7;
            intIsTopColumnIndex = 8;
            txtIsTopColumnIndex.Text = intIsTopColumnIndex.ToString();
            intNext = 8;
            intTopSortColumnIndex = 9;
            txtTopSortColumnIndex.Text = intTopSortColumnIndex.ToString();
            intNext = 9;
            intIsBestColumnIndex = 10;
            txtIsBestColumnIndex.Text = intIsBestColumnIndex.ToString();
            intNext = 10;
            intFBRJGHColumnIndex = 11;
            txtFBRJGHColumnIndex.Text = intFBRJGHColumnIndex.ToString();
            intNext = 11;
            intFBSJRQColumnIndex = 12;
            txtFBSJRQColumnIndex.Text = intFBSJRQColumnIndex.ToString();
            intNext = 12;
            intFBIPColumnIndex = 13;
            txtFBIPColumnIndex.Text = intFBIPColumnIndex.ToString();
            intNext = 13;
            // 初始化一对一对应表显示列序号
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// 自定义显示列位置
    /// </summary>
    //=====================================================================
    protected override void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // 主表显示列位置改变
        
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
            intTempColumnIndex = Convert.ToInt32(txtFBBMColumnIndex.Text);
            if(intTempColumnIndex != intFBBMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFBBMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFBBMColumnIndex - 1]);
                intFBBMColumnIndex = intTempColumnIndex;
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
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
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
      FBBM.SelectedValue = GetValue(appData.FBBM); 
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

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
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

    #endregion

    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// 初始化联动设置
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

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
        
            validateData = ValidateFBBM(FBBM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBBM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBBM(FBBM.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItemFBBM.Checked)
                    {
                        appData.FBBM = null;
                        appData.FBBMBatch = GetSubItem_FBBM(FBBM.SelectedValue) + "," + FBBM.SelectedValue;
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

        if(CustomPermission == WFBD_PURVIEW_ID)
        {
            appData.FBRJGH = CurrentUserInfo.UserID;
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
            sbCaption.Append(@"公共信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(FBH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布号：");
                sbCaption.Append(FBH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BT.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("标题：");
                sbCaption.Append(BT.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBLM.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布栏目：");
                sbCaption.Append(new RICH.Common.BM.T_BG_0602.T_BG_0602BusinessEntity().GetValueByFixCondition("LMH", FBLM.SelectedValues, "LMM"));
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBBM.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布部门：");
                sbCaption.Append(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity().GetValueByFixCondition("DWBH", FBBM.SelectedValue, "DWMC"));
                
                if (chkShowSubItemFBBM.Checked)
                {
                    sbCaption.Append("的子（下级）项信息");
                }
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XXLX.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("信息类型：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", XXLX.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XXNR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("信息内容：");
                sbCaption.Append(XXNR.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(IsTop.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("是否置顶：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", IsTop.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(IsBest.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("推荐：");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", IsBest.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBRJGH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", FBRJGH.Text, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布时间：");
                sbCaption.Append(FBSJRQ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布时间开始值：");
                sbCaption.Append(FBSJRQBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FBSJRQEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发布时间结束值：");
                sbCaption.Append(FBSJRQEnd.Text);
               sbCaption.Append(@"</div>");
            }
            // 一对一相关表

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
    
    protected override void CheckPermission()
    {
        if(AccessPermission)
        {

            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intFBHColumnIndex].Visible = 
            chkShowFBH_Area.Visible =
            chkShowFBH.Checked =
            chkShowFBH.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            FBBM_Area.Visible = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            XXLX_Area.Visible = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intXXZTColumnIndex].Visible = 
            chkShowXXZT_Area.Visible =
            chkShowXXZT.Checked =
            chkShowXXZT.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intIsTopColumnIndex].Visible = 
            chkShowIsTop_Area.Visible =
            chkShowIsTop.Checked =
            chkShowIsTop.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            IsTop_Area.Visible = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intTopSortColumnIndex].Visible = 
            chkShowTopSort_Area.Visible =
            chkShowTopSort.Checked =
            chkShowTopSort.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intIsBestColumnIndex].Visible = 
            chkShowIsBest_Area.Visible =
            chkShowIsBest.Checked =
            chkShowIsBest.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            IsBest_Area.Visible = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intFBRJGHColumnIndex].Visible = 
            chkShowFBRJGH_Area.Visible =
            chkShowFBRJGH.Checked =
            chkShowFBRJGH.Enabled = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            FBRJGH_Area.Visible = false;
            }
            if(CustomPermission == WFBD_PURVIEW_ID)
            {
            gvList.Columns[intFBIPColumnIndex].Visible = 
            chkShowFBIP_Area.Visible =
            chkShowFBIP.Checked =
            chkShowFBIP.Enabled = false;
            }
        }
    }

    protected override void SetCurrentAccessPermission()
    {

        if (CustomPermission == WFBD_PURVIEW_ID)
        {
            CurrentAccessPermission = WFBD_PURVIEW_ID;
        }
        
        base.SetCurrentAccessPermission();
    }
}

