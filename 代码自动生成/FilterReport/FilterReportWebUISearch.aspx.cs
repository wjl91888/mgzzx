/****************************************************** 
FileName:FilterReportWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class FilterReportWebUISearch : RICH.Common.BM.FilterReport.FilterReportWebUI
{
    #region ����GridView������

    static int intBGMCColumnIndex;
    static int intUserIDColumnIndex;
    static int intBGLXColumnIndex;
    static int intGXBGColumnIndex;
    static int intXTBGColumnIndex;
    static int intBGCJSJColumnIndex;
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

            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ramFilterReport.AjaxRequest += AjaxManager_AjaxRequest;
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
    
            gvList.Columns[intBGMCColumnIndex].Visible = chkShowBGMC.Checked;
            gvList.Columns[intUserIDColumnIndex].Visible = chkShowUserID.Checked;
            gvList.Columns[intBGLXColumnIndex].Visible = chkShowBGLX.Checked;
            gvList.Columns[intGXBGColumnIndex].Visible = chkShowGXBG.Checked;
            gvList.Columns[intXTBGColumnIndex].Visible = chkShowXTBG.Checked;
            gvList.Columns[intBGCJSJColumnIndex].Visible = chkShowBGCJSJ.Checked;BGCJSJ.Attributes.Add("onclick", "setday(this);");
      
        // ���ݲ�ѯ
        appData = new FilterReportApplicationData();
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
    protected override void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;

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

            // ��ʼ���û����(UserID)�����б�
          UserID.DataSource = GetDataSource_UserID_AdvanceSearch();
            UserID.DataTextField = "UserLoginName";
            UserID.DataValueField = "UserID";
              UserID.DataBind();
                  UserID.Items.Insert(0, new ListItem("ѡ���û����", ""));
                    
            // ��ʼ��������(GXBG)�����б�
          GXBG.DataSource = GetDataSource_GXBG_AdvanceSearch();
            GXBG.DataTextField = "MC";
            GXBG.DataValueField = "DM";
              GXBG.DataBind();
                  GXBG.Items.Insert(0, new ListItem("ѡ������", ""));
                    
            // ��ʼ��ϵͳ����(XTBG)�����б�
          XTBG.DataSource = GetDataSource_XTBG_AdvanceSearch();
            XTBG.DataTextField = "MC";
            XTBG.DataValueField = "DM";
              XTBG.DataBind();
                  XTBG.Items.Insert(0, new ListItem("ѡ��ϵͳ����", ""));
                    
            // һ��һ��ر�

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ���ص������ļ�����
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new FilterReportApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intBGMCColumnIndex - 1].Visible = chkShowBGMC.Checked;
        gvPrint.Columns[intUserIDColumnIndex - 1].Visible = chkShowUserID.Checked;
        gvPrint.Columns[intBGLXColumnIndex - 1].Visible = chkShowBGLX.Checked;
        gvPrint.Columns[intGXBGColumnIndex - 1].Visible = chkShowGXBG.Checked;
        gvPrint.Columns[intXTBGColumnIndex - 1].Visible = chkShowXTBG.Checked;
        gvPrint.Columns[intBGCJSJColumnIndex - 1].Visible = chkShowBGCJSJ.Checked;
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
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// ��ʼ��������
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // ��ʼ��������ʾ�����
        
            intBGMCColumnIndex = 1;
            txtBGMCColumnIndex.Text = intBGMCColumnIndex.ToString();
            intNext = 1;
            intUserIDColumnIndex = 2;
            txtUserIDColumnIndex.Text = intUserIDColumnIndex.ToString();
            intNext = 2;
            intBGLXColumnIndex = 3;
            txtBGLXColumnIndex.Text = intBGLXColumnIndex.ToString();
            intNext = 3;
            intGXBGColumnIndex = 4;
            txtGXBGColumnIndex.Text = intGXBGColumnIndex.ToString();
            intNext = 4;
            intXTBGColumnIndex = 5;
            txtXTBGColumnIndex.Text = intXTBGColumnIndex.ToString();
            intNext = 5;
            intBGCJSJColumnIndex = 6;
            txtBGCJSJColumnIndex.Text = intBGCJSJColumnIndex.ToString();
            intNext = 6;
            // ��ʼ��һ��һ��Ӧ����ʾ�����
        
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// �Զ�����ʾ��λ��
    /// </summary>
    //=====================================================================
    protected override void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // ������ʾ��λ�øı�
        
            intTempColumnIndex = Convert.ToInt32(txtBGMCColumnIndex.Text);
            if(intTempColumnIndex != intBGMCColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBGMCColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBGMCColumnIndex - 1]);
                intBGMCColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtUserIDColumnIndex.Text);
            if(intTempColumnIndex != intUserIDColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intUserIDColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intUserIDColumnIndex - 1]);
                intUserIDColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBGLXColumnIndex.Text);
            if(intTempColumnIndex != intBGLXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBGLXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBGLXColumnIndex - 1]);
                intBGLXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtGXBGColumnIndex.Text);
            if(intTempColumnIndex != intGXBGColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intGXBGColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intGXBGColumnIndex - 1]);
                intGXBGColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXTBGColumnIndex.Text);
            if(intTempColumnIndex != intXTBGColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXTBGColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXTBGColumnIndex - 1]);
                intXTBGColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBGCJSJColumnIndex.Text);
            if(intTempColumnIndex != intBGCJSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBGCJSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBGCJSJColumnIndex - 1]);
                intBGCJSJColumnIndex = intTempColumnIndex;
            }
            // һ��һ��Ӧ����ʾ�иı�
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new FilterReportApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            FilterReportApplicationData obj = new FilterReportApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as FilterReportApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
BGMC.Text = GetValue(appData.BGMC); 
      UserID.SelectedValue = GetValue(appData.UserID); 
      BGLX.Text = GetValue(appData.BGLX); 
      GXBG.SelectedValue = GetValue(appData.GXBG); 
      XTBG.SelectedValue = GetValue(appData.XTBG); 
      BGCJSJ.Text = GetValue(appData.BGCJSJ); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new FilterReportApplicationData();
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

            validateData = ValidateBGMC(BGMC.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGMC = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateUserID(UserID.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserID = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateBGLX(BGLX.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGLX = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateGXBG(GXBG.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.GXBG = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateXTBG(XTBG.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XTBG = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateBGCJSJ(BGCJSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGCJSJ = Convert.ToDateTime(validateData.Value.ToString());
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

            if (!DataValidateManager.ValidateIsNull(BGMC.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�������ƣ�");
                sbCaption.Append(BGMC.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(UserID.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�û���ţ�");
                sbCaption.Append(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity().GetValueByFixCondition("UserID", UserID.SelectedValue, "UserLoginName"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BGLX.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�������ͣ�");
                sbCaption.Append(BGLX.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(GXBG.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("�����棺");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", GXBG.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XTBG.SelectedValue))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("ϵͳ���棺");
                sbCaption.Append(new RICH.Common.BM.Dictionary.DictionaryBusinessEntity().GetValueByFixCondition("DM", XTBG.SelectedValue, "MC"));
                
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(BGCJSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("����ʱ�䣺");
                sbCaption.Append(BGCJSJ.Text);
               sbCaption.Append(@"</div>");
            }
            // һ��һ��ر�

            sbCaption.Append("</div>");
            return sbCaption.ToString();
    }
    
    protected override void CheckPermission()
    {
        if(AccessPermission)
        {

        }
    }

    protected override void SetCurrentAccessPermission()
    {

        base.SetCurrentAccessPermission();
    }
}

