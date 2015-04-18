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
    #region 定义GridView列索引

    static int intDXXBTColumnIndex;
    static int intDXXFJColumnIndex;
    static int intFSSJColumnIndex;
    static int intFSRColumnIndex;
    static int intFSBMColumnIndex;
    static int intSFCKColumnIndex;
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
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
    
        DetailPage = true;
            gvList.Columns[intDXXBTColumnIndex].Visible = chkShowDXXBT.Checked;
            gvList.Columns[intDXXFJColumnIndex].Visible = chkShowDXXFJ.Checked;
            gvList.Columns[intFSSJColumnIndex].Visible = chkShowFSSJ.Checked;
            gvList.Columns[intFSRColumnIndex].Visible = chkShowFSR.Checked;
            gvList.Columns[intFSBMColumnIndex].Visible = chkShowFSBM.Checked;
            gvList.Columns[intSFCKColumnIndex].Visible = chkShowSFCK.Checked;
        // 数据查询
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
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected override void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;
FSBM_Area.Visible = isDisplay;
      
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

            // 初始化接收人(JSR)下拉列表
          JSR.DataSource = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetTreeData_T_PM_UserInfo_SubjectID("UserID", "UserNickName",  null, "null", null);
			JSR.DataFieldID = "ID";
			JSR.DataFieldParentID = "ParentID";
			JSR.DataTextField = "Name";
			JSR.DataValueField = "ID";
			JSR.CheckBoxes = true;
			JSR.CheckChildNodes = true;
              JSR.DataBind();
                  
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
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
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

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
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

        if(CustomPermission == SJX_PURVIEW_ID)
        {
            appData.DXXLX = "02";
        }
        
        if(CustomPermission == SJX_PURVIEW_ID)
        {
            appData.JSR = CurrentUserInfo.UserID;
        }
        
        if(CustomPermission == FJX_PURVIEW_ID)
        {
            appData.DXXLX = "01";
        }
        
        if(CustomPermission == FJX_PURVIEW_ID)
        {
            appData.FSR = CurrentUserInfo.UserID;
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
            sbCaption.Append(@"消息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(DXXBT.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("标题：");
                sbCaption.Append(DXXBT.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(DXXNR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("内容：");
                sbCaption.Append(DXXNR.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发送时间：");
                sbCaption.Append(FSSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发送时间开始值：");
                sbCaption.Append(FSSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发送时间结束值：");
                sbCaption.Append(FSSJEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSR.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发送人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", FSR.Text, "UserNickName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FSBM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("发送部门：");
                sbCaption.Append(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity().GetValueByFixCondition("DWBH", FSBM.Text, "DWMC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(JSR.SelectedValues))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("接收人：");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", JSR.SelectedValues, "UserNickName"));
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

            if(CustomPermission == SJX_PURVIEW_ID)
            {
            JSR_Area.Visible = false;
            }
            if(CustomPermission == SJX_PURVIEW_ID)
            {
            gvList.Columns[intSFCKColumnIndex].Visible = 
            chkShowSFCK_Area.Visible =
            chkShowSFCK.Checked =
            chkShowSFCK.Enabled = false;
            }
            if(CustomPermission == FJX_PURVIEW_ID)
            {
            gvList.Columns[intFSRColumnIndex].Visible = 
            chkShowFSR_Area.Visible =
            chkShowFSR.Checked =
            chkShowFSR.Enabled = false;
            }
            if(CustomPermission == FJX_PURVIEW_ID)
            {
            FSR_Area.Visible = false;
            }
            if(CustomPermission == FJX_PURVIEW_ID)
            {
            gvList.Columns[intFSBMColumnIndex].Visible = 
            chkShowFSBM_Area.Visible =
            chkShowFSBM.Checked =
            chkShowFSBM.Enabled = false;
            }
            if(CustomPermission == FJX_PURVIEW_ID)
            {
            FSBM_Area.Visible = false;
            }
            if(CustomPermission == FJX_PURVIEW_ID)
            {
            gvList.Columns[intSFCKColumnIndex].Visible = 
            chkShowSFCK_Area.Visible =
            chkShowSFCK.Checked =
            chkShowSFCK.Enabled = false;
            }
        }
    }

    protected override void SetCurrentAccessPermission()
    {

        if (CustomPermission == FJX_PURVIEW_ID)
        {
            CurrentAccessPermission = FJX_PURVIEW_ID;
        }
        
        if (CustomPermission == SJX_PURVIEW_ID)
        {
            CurrentAccessPermission = SJX_PURVIEW_ID;
        }
        
        base.SetCurrentAccessPermission();
    }
}

