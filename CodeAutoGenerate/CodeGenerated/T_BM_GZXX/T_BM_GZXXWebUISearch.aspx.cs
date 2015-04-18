/****************************************************** 
FileName:T_BM_GZXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_BM_GZXX;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class T_BM_GZXXWebUISearch : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
{
    #region 定义GridView列索引

    static int intXMColumnIndex;
    static int intXBColumnIndex;
    static int intSFZHColumnIndex;
    static int intFFGZNYColumnIndex;
    static int intJCGZColumnIndex;
    static int intJSDJGZColumnIndex;
    static int intZWGZColumnIndex;
    static int intJBGZColumnIndex;
    static int intJKDQJTColumnIndex;
    static int intJKTSGWJTColumnIndex;
    static int intGLGZColumnIndex;
    static int intXJGZColumnIndex;
    static int intTGBFColumnIndex;
    static int intDHFColumnIndex;
    static int intDSZNFColumnIndex;
    static int intFNWSHLFColumnIndex;
    static int intHLFColumnIndex;
    static int intJJColumnIndex;
    static int intJTFColumnIndex;
    static int intJHLGZColumnIndex;
    static int intJTColumnIndex;
    static int intBFColumnIndex;
    static int intQTBTColumnIndex;
    static int intDFXJTColumnIndex;
    static int intYFXColumnIndex;
    static int intQTKKColumnIndex;
    static int intSYBXColumnIndex;
    static int intSDNQFColumnIndex;
    static int intSDSColumnIndex;
    static int intYLBXColumnIndex;
    static int intYLIBXColumnIndex;
    static int intYSSHFColumnIndex;
    static int intZFGJJColumnIndex;
    static int intKFXColumnIndex;
    static int intSFGZColumnIndex;
    static int intGZKKSMColumnIndex;
    static int intTJSJColumnIndex;
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
        ramT_BM_GZXX.AjaxRequest += AjaxManager_AjaxRequest;
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
            gvList.Columns[intXMColumnIndex].Visible = chkShowXM.Checked;
            gvList.Columns[intXBColumnIndex].Visible = chkShowXB.Checked;
            gvList.Columns[intSFZHColumnIndex].Visible = chkShowSFZH.Checked;
            gvList.Columns[intFFGZNYColumnIndex].Visible = chkShowFFGZNY.Checked;
            gvList.Columns[intJCGZColumnIndex].Visible = chkShowJCGZ.Checked;
            gvList.Columns[intJSDJGZColumnIndex].Visible = chkShowJSDJGZ.Checked;
            gvList.Columns[intZWGZColumnIndex].Visible = chkShowZWGZ.Checked;
            gvList.Columns[intJBGZColumnIndex].Visible = chkShowJBGZ.Checked;
            gvList.Columns[intJKDQJTColumnIndex].Visible = chkShowJKDQJT.Checked;
            gvList.Columns[intJKTSGWJTColumnIndex].Visible = chkShowJKTSGWJT.Checked;
            gvList.Columns[intGLGZColumnIndex].Visible = chkShowGLGZ.Checked;
            gvList.Columns[intXJGZColumnIndex].Visible = chkShowXJGZ.Checked;
            gvList.Columns[intTGBFColumnIndex].Visible = chkShowTGBF.Checked;
            gvList.Columns[intDHFColumnIndex].Visible = chkShowDHF.Checked;
            gvList.Columns[intDSZNFColumnIndex].Visible = chkShowDSZNF.Checked;
            gvList.Columns[intFNWSHLFColumnIndex].Visible = chkShowFNWSHLF.Checked;
            gvList.Columns[intHLFColumnIndex].Visible = chkShowHLF.Checked;
            gvList.Columns[intJJColumnIndex].Visible = chkShowJJ.Checked;
            gvList.Columns[intJTFColumnIndex].Visible = chkShowJTF.Checked;
            gvList.Columns[intJHLGZColumnIndex].Visible = chkShowJHLGZ.Checked;
            gvList.Columns[intJTColumnIndex].Visible = chkShowJT.Checked;
            gvList.Columns[intBFColumnIndex].Visible = chkShowBF.Checked;
            gvList.Columns[intQTBTColumnIndex].Visible = chkShowQTBT.Checked;
            gvList.Columns[intDFXJTColumnIndex].Visible = chkShowDFXJT.Checked;
            gvList.Columns[intYFXColumnIndex].Visible = chkShowYFX.Checked;
            gvList.Columns[intQTKKColumnIndex].Visible = chkShowQTKK.Checked;
            gvList.Columns[intSYBXColumnIndex].Visible = chkShowSYBX.Checked;
            gvList.Columns[intSDNQFColumnIndex].Visible = chkShowSDNQF.Checked;
            gvList.Columns[intSDSColumnIndex].Visible = chkShowSDS.Checked;
            gvList.Columns[intYLBXColumnIndex].Visible = chkShowYLBX.Checked;
            gvList.Columns[intYLIBXColumnIndex].Visible = chkShowYLIBX.Checked;
            gvList.Columns[intYSSHFColumnIndex].Visible = chkShowYSSHF.Checked;
            gvList.Columns[intZFGJJColumnIndex].Visible = chkShowZFGJJ.Checked;
            gvList.Columns[intKFXColumnIndex].Visible = chkShowKFX.Checked;
            gvList.Columns[intSFGZColumnIndex].Visible = chkShowSFGZ.Checked;
            gvList.Columns[intGZKKSMColumnIndex].Visible = chkShowGZKKSM.Checked;
            gvList.Columns[intTJSJColumnIndex].Visible = chkShowTJSJ.Checked;TJSJ.Attributes.Add("onclick", "setday(this);");
      TJSJBegin.Attributes.Add("onclick", "setday(this);");
        TJSJEnd.Attributes.Add("onclick", "setday(this);");
      
        // 数据查询
        appData = new T_BM_GZXXApplicationData();
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
TJSJ_Area.Visible = isDisplay;
      
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
        appData = new T_BM_GZXXApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        gvPrint.Columns[intXMColumnIndex - 1].Visible = chkShowXM.Checked;
        gvPrint.Columns[intXBColumnIndex - 1].Visible = chkShowXB.Checked;
        gvPrint.Columns[intSFZHColumnIndex - 1].Visible = chkShowSFZH.Checked;
        gvPrint.Columns[intFFGZNYColumnIndex - 1].Visible = chkShowFFGZNY.Checked;
        gvPrint.Columns[intJCGZColumnIndex - 1].Visible = chkShowJCGZ.Checked;
        gvPrint.Columns[intJSDJGZColumnIndex - 1].Visible = chkShowJSDJGZ.Checked;
        gvPrint.Columns[intZWGZColumnIndex - 1].Visible = chkShowZWGZ.Checked;
        gvPrint.Columns[intJBGZColumnIndex - 1].Visible = chkShowJBGZ.Checked;
        gvPrint.Columns[intJKDQJTColumnIndex - 1].Visible = chkShowJKDQJT.Checked;
        gvPrint.Columns[intJKTSGWJTColumnIndex - 1].Visible = chkShowJKTSGWJT.Checked;
        gvPrint.Columns[intGLGZColumnIndex - 1].Visible = chkShowGLGZ.Checked;
        gvPrint.Columns[intXJGZColumnIndex - 1].Visible = chkShowXJGZ.Checked;
        gvPrint.Columns[intTGBFColumnIndex - 1].Visible = chkShowTGBF.Checked;
        gvPrint.Columns[intDHFColumnIndex - 1].Visible = chkShowDHF.Checked;
        gvPrint.Columns[intDSZNFColumnIndex - 1].Visible = chkShowDSZNF.Checked;
        gvPrint.Columns[intFNWSHLFColumnIndex - 1].Visible = chkShowFNWSHLF.Checked;
        gvPrint.Columns[intHLFColumnIndex - 1].Visible = chkShowHLF.Checked;
        gvPrint.Columns[intJJColumnIndex - 1].Visible = chkShowJJ.Checked;
        gvPrint.Columns[intJTFColumnIndex - 1].Visible = chkShowJTF.Checked;
        gvPrint.Columns[intJHLGZColumnIndex - 1].Visible = chkShowJHLGZ.Checked;
        gvPrint.Columns[intJTColumnIndex - 1].Visible = chkShowJT.Checked;
        gvPrint.Columns[intBFColumnIndex - 1].Visible = chkShowBF.Checked;
        gvPrint.Columns[intQTBTColumnIndex - 1].Visible = chkShowQTBT.Checked;
        gvPrint.Columns[intDFXJTColumnIndex - 1].Visible = chkShowDFXJT.Checked;
        gvPrint.Columns[intYFXColumnIndex - 1].Visible = chkShowYFX.Checked;
        gvPrint.Columns[intQTKKColumnIndex - 1].Visible = chkShowQTKK.Checked;
        gvPrint.Columns[intSYBXColumnIndex - 1].Visible = chkShowSYBX.Checked;
        gvPrint.Columns[intSDNQFColumnIndex - 1].Visible = chkShowSDNQF.Checked;
        gvPrint.Columns[intSDSColumnIndex - 1].Visible = chkShowSDS.Checked;
        gvPrint.Columns[intYLBXColumnIndex - 1].Visible = chkShowYLBX.Checked;
        gvPrint.Columns[intYLIBXColumnIndex - 1].Visible = chkShowYLIBX.Checked;
        gvPrint.Columns[intYSSHFColumnIndex - 1].Visible = chkShowYSSHF.Checked;
        gvPrint.Columns[intZFGJJColumnIndex - 1].Visible = chkShowZFGJJ.Checked;
        gvPrint.Columns[intKFXColumnIndex - 1].Visible = chkShowKFX.Checked;
        gvPrint.Columns[intSFGZColumnIndex - 1].Visible = chkShowSFGZ.Checked;
        gvPrint.Columns[intGZKKSMColumnIndex - 1].Visible = chkShowGZKKSM.Checked;
        gvPrint.Columns[intTJSJColumnIndex - 1].Visible = chkShowTJSJ.Checked;
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
        
            intXMColumnIndex = 1;
            txtXMColumnIndex.Text = intXMColumnIndex.ToString();
            intNext = 1;
            intXBColumnIndex = 2;
            txtXBColumnIndex.Text = intXBColumnIndex.ToString();
            intNext = 2;
            intSFZHColumnIndex = 3;
            txtSFZHColumnIndex.Text = intSFZHColumnIndex.ToString();
            intNext = 3;
            intFFGZNYColumnIndex = 4;
            txtFFGZNYColumnIndex.Text = intFFGZNYColumnIndex.ToString();
            intNext = 4;
            intJCGZColumnIndex = 5;
            txtJCGZColumnIndex.Text = intJCGZColumnIndex.ToString();
            intNext = 5;
            intJSDJGZColumnIndex = 6;
            txtJSDJGZColumnIndex.Text = intJSDJGZColumnIndex.ToString();
            intNext = 6;
            intZWGZColumnIndex = 7;
            txtZWGZColumnIndex.Text = intZWGZColumnIndex.ToString();
            intNext = 7;
            intJBGZColumnIndex = 8;
            txtJBGZColumnIndex.Text = intJBGZColumnIndex.ToString();
            intNext = 8;
            intJKDQJTColumnIndex = 9;
            txtJKDQJTColumnIndex.Text = intJKDQJTColumnIndex.ToString();
            intNext = 9;
            intJKTSGWJTColumnIndex = 10;
            txtJKTSGWJTColumnIndex.Text = intJKTSGWJTColumnIndex.ToString();
            intNext = 10;
            intGLGZColumnIndex = 11;
            txtGLGZColumnIndex.Text = intGLGZColumnIndex.ToString();
            intNext = 11;
            intXJGZColumnIndex = 12;
            txtXJGZColumnIndex.Text = intXJGZColumnIndex.ToString();
            intNext = 12;
            intTGBFColumnIndex = 13;
            txtTGBFColumnIndex.Text = intTGBFColumnIndex.ToString();
            intNext = 13;
            intDHFColumnIndex = 14;
            txtDHFColumnIndex.Text = intDHFColumnIndex.ToString();
            intNext = 14;
            intDSZNFColumnIndex = 15;
            txtDSZNFColumnIndex.Text = intDSZNFColumnIndex.ToString();
            intNext = 15;
            intFNWSHLFColumnIndex = 16;
            txtFNWSHLFColumnIndex.Text = intFNWSHLFColumnIndex.ToString();
            intNext = 16;
            intHLFColumnIndex = 17;
            txtHLFColumnIndex.Text = intHLFColumnIndex.ToString();
            intNext = 17;
            intJJColumnIndex = 18;
            txtJJColumnIndex.Text = intJJColumnIndex.ToString();
            intNext = 18;
            intJTFColumnIndex = 19;
            txtJTFColumnIndex.Text = intJTFColumnIndex.ToString();
            intNext = 19;
            intJHLGZColumnIndex = 20;
            txtJHLGZColumnIndex.Text = intJHLGZColumnIndex.ToString();
            intNext = 20;
            intJTColumnIndex = 21;
            txtJTColumnIndex.Text = intJTColumnIndex.ToString();
            intNext = 21;
            intBFColumnIndex = 22;
            txtBFColumnIndex.Text = intBFColumnIndex.ToString();
            intNext = 22;
            intQTBTColumnIndex = 23;
            txtQTBTColumnIndex.Text = intQTBTColumnIndex.ToString();
            intNext = 23;
            intDFXJTColumnIndex = 24;
            txtDFXJTColumnIndex.Text = intDFXJTColumnIndex.ToString();
            intNext = 24;
            intYFXColumnIndex = 25;
            txtYFXColumnIndex.Text = intYFXColumnIndex.ToString();
            intNext = 25;
            intQTKKColumnIndex = 26;
            txtQTKKColumnIndex.Text = intQTKKColumnIndex.ToString();
            intNext = 26;
            intSYBXColumnIndex = 27;
            txtSYBXColumnIndex.Text = intSYBXColumnIndex.ToString();
            intNext = 27;
            intSDNQFColumnIndex = 28;
            txtSDNQFColumnIndex.Text = intSDNQFColumnIndex.ToString();
            intNext = 28;
            intSDSColumnIndex = 29;
            txtSDSColumnIndex.Text = intSDSColumnIndex.ToString();
            intNext = 29;
            intYLBXColumnIndex = 30;
            txtYLBXColumnIndex.Text = intYLBXColumnIndex.ToString();
            intNext = 30;
            intYLIBXColumnIndex = 31;
            txtYLIBXColumnIndex.Text = intYLIBXColumnIndex.ToString();
            intNext = 31;
            intYSSHFColumnIndex = 32;
            txtYSSHFColumnIndex.Text = intYSSHFColumnIndex.ToString();
            intNext = 32;
            intZFGJJColumnIndex = 33;
            txtZFGJJColumnIndex.Text = intZFGJJColumnIndex.ToString();
            intNext = 33;
            intKFXColumnIndex = 34;
            txtKFXColumnIndex.Text = intKFXColumnIndex.ToString();
            intNext = 34;
            intSFGZColumnIndex = 35;
            txtSFGZColumnIndex.Text = intSFGZColumnIndex.ToString();
            intNext = 35;
            intGZKKSMColumnIndex = 36;
            txtGZKKSMColumnIndex.Text = intGZKKSMColumnIndex.ToString();
            intNext = 36;
            intTJSJColumnIndex = 37;
            txtTJSJColumnIndex.Text = intTJSJColumnIndex.ToString();
            intNext = 37;
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
        
            intTempColumnIndex = Convert.ToInt32(txtXMColumnIndex.Text);
            if(intTempColumnIndex != intXMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXMColumnIndex - 1]);
                intXMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXBColumnIndex.Text);
            if(intTempColumnIndex != intXBColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXBColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXBColumnIndex - 1]);
                intXBColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSFZHColumnIndex.Text);
            if(intTempColumnIndex != intSFZHColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSFZHColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSFZHColumnIndex - 1]);
                intSFZHColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFFGZNYColumnIndex.Text);
            if(intTempColumnIndex != intFFGZNYColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFFGZNYColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFFGZNYColumnIndex - 1]);
                intFFGZNYColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJCGZColumnIndex.Text);
            if(intTempColumnIndex != intJCGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJCGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJCGZColumnIndex - 1]);
                intJCGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJSDJGZColumnIndex.Text);
            if(intTempColumnIndex != intJSDJGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJSDJGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJSDJGZColumnIndex - 1]);
                intJSDJGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtZWGZColumnIndex.Text);
            if(intTempColumnIndex != intZWGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intZWGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intZWGZColumnIndex - 1]);
                intZWGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJBGZColumnIndex.Text);
            if(intTempColumnIndex != intJBGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJBGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJBGZColumnIndex - 1]);
                intJBGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJKDQJTColumnIndex.Text);
            if(intTempColumnIndex != intJKDQJTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJKDQJTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJKDQJTColumnIndex - 1]);
                intJKDQJTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJKTSGWJTColumnIndex.Text);
            if(intTempColumnIndex != intJKTSGWJTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJKTSGWJTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJKTSGWJTColumnIndex - 1]);
                intJKTSGWJTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtGLGZColumnIndex.Text);
            if(intTempColumnIndex != intGLGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intGLGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intGLGZColumnIndex - 1]);
                intGLGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtXJGZColumnIndex.Text);
            if(intTempColumnIndex != intXJGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intXJGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intXJGZColumnIndex - 1]);
                intXJGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtTGBFColumnIndex.Text);
            if(intTempColumnIndex != intTGBFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intTGBFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intTGBFColumnIndex - 1]);
                intTGBFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDHFColumnIndex.Text);
            if(intTempColumnIndex != intDHFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDHFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDHFColumnIndex - 1]);
                intDHFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDSZNFColumnIndex.Text);
            if(intTempColumnIndex != intDSZNFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDSZNFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDSZNFColumnIndex - 1]);
                intDSZNFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtFNWSHLFColumnIndex.Text);
            if(intTempColumnIndex != intFNWSHLFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intFNWSHLFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intFNWSHLFColumnIndex - 1]);
                intFNWSHLFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtHLFColumnIndex.Text);
            if(intTempColumnIndex != intHLFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intHLFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intHLFColumnIndex - 1]);
                intHLFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJJColumnIndex.Text);
            if(intTempColumnIndex != intJJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJJColumnIndex - 1]);
                intJJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJTFColumnIndex.Text);
            if(intTempColumnIndex != intJTFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJTFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJTFColumnIndex - 1]);
                intJTFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJHLGZColumnIndex.Text);
            if(intTempColumnIndex != intJHLGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJHLGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJHLGZColumnIndex - 1]);
                intJHLGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtJTColumnIndex.Text);
            if(intTempColumnIndex != intJTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intJTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intJTColumnIndex - 1]);
                intJTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtBFColumnIndex.Text);
            if(intTempColumnIndex != intBFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intBFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intBFColumnIndex - 1]);
                intBFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtQTBTColumnIndex.Text);
            if(intTempColumnIndex != intQTBTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intQTBTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intQTBTColumnIndex - 1]);
                intQTBTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtDFXJTColumnIndex.Text);
            if(intTempColumnIndex != intDFXJTColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intDFXJTColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intDFXJTColumnIndex - 1]);
                intDFXJTColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYFXColumnIndex.Text);
            if(intTempColumnIndex != intYFXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYFXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYFXColumnIndex - 1]);
                intYFXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtQTKKColumnIndex.Text);
            if(intTempColumnIndex != intQTKKColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intQTKKColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intQTKKColumnIndex - 1]);
                intQTKKColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSYBXColumnIndex.Text);
            if(intTempColumnIndex != intSYBXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSYBXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSYBXColumnIndex - 1]);
                intSYBXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSDNQFColumnIndex.Text);
            if(intTempColumnIndex != intSDNQFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSDNQFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSDNQFColumnIndex - 1]);
                intSDNQFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSDSColumnIndex.Text);
            if(intTempColumnIndex != intSDSColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSDSColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSDSColumnIndex - 1]);
                intSDSColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYLBXColumnIndex.Text);
            if(intTempColumnIndex != intYLBXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYLBXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYLBXColumnIndex - 1]);
                intYLBXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYLIBXColumnIndex.Text);
            if(intTempColumnIndex != intYLIBXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYLIBXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYLIBXColumnIndex - 1]);
                intYLIBXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtYSSHFColumnIndex.Text);
            if(intTempColumnIndex != intYSSHFColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intYSSHFColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intYSSHFColumnIndex - 1]);
                intYSSHFColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtZFGJJColumnIndex.Text);
            if(intTempColumnIndex != intZFGJJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intZFGJJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intZFGJJColumnIndex - 1]);
                intZFGJJColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtKFXColumnIndex.Text);
            if(intTempColumnIndex != intKFXColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intKFXColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intKFXColumnIndex - 1]);
                intKFXColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtSFGZColumnIndex.Text);
            if(intTempColumnIndex != intSFGZColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intSFGZColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intSFGZColumnIndex - 1]);
                intSFGZColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtGZKKSMColumnIndex.Text);
            if(intTempColumnIndex != intGZKKSMColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intGZKKSMColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intGZKKSMColumnIndex - 1]);
                intGZKKSMColumnIndex = intTempColumnIndex;
            }
            intTempColumnIndex = Convert.ToInt32(txtTJSJColumnIndex.Text);
            if(intTempColumnIndex != intTJSJColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[intTJSJColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[intTJSJColumnIndex - 1]);
                intTJSJColumnIndex = intTempColumnIndex;
            }
            // 一对一对应表显示列改变
        
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new T_BM_GZXXApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            T_BM_GZXXApplicationData obj = new T_BM_GZXXApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as T_BM_GZXXApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
XM.Text = GetValue(appData.XM); 
      XB.Text = GetValue(appData.XB); 
      SFZH.Text = GetValue(appData.SFZH); 
      FFGZNY.Text = GetValue(appData.FFGZNY); 
      YFX.Text = GetValue(appData.YFXBegin); 
            YFX.Text = GetValue(appData.YFXEnd); 
            YFX.Text = GetValue(appData.YFX); 
      SFGZ.Text = GetValue(appData.SFGZBegin); 
            SFGZ.Text = GetValue(appData.SFGZEnd); 
            SFGZ.Text = GetValue(appData.SFGZ); 
      TJSJ.Text = GetValue(appData.TJSJBegin); 
            TJSJ.Text = GetValue(appData.TJSJEnd); 
            TJSJ.Text = GetValue(appData.TJSJ); 
      
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new T_BM_GZXXApplicationData();
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

            validateData = ValidateXM(XM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateXB(XB.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XB = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSFZH(SFZH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SFZH = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFFGZNY(FFGZNY.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FFGZNY = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateYFXBegin(YFXBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YFXBegin = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            validateData = ValidateYFXEnd(YFXEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YFXEnd = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateYFX(YFX.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YFX = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateSFGZBegin(SFGZBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SFGZBegin = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            validateData = ValidateSFGZEnd(SFGZEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SFGZEnd = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateSFGZ(SFGZ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SFGZ = Convert.ToDouble(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateTJSJBegin(TJSJBegin.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.TJSJBegin = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            validateData = ValidateTJSJEnd(TJSJEnd.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.TJSJEnd = Convert.ToDateTime(validateData.Value.ToString());
                }
            }
            
            validateData = ValidateTJSJ(TJSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.TJSJ = Convert.ToDateTime(validateData.Value.ToString());
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

        if(CustomPermission == WDGZ_PURVIEW_ID)
        {
            appData.SFZH = CurrentUserInfo.SFZH;
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
            sbCaption.Append(@"工资信息列表");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"查询条件如下：");

            if (!DataValidateManager.ValidateIsNull(XM.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("姓名：");
                sbCaption.Append(XM.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(XB.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("性别：");
                sbCaption.Append(XB.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SFZH.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("身份证号：");
                sbCaption.Append(SFZH.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(FFGZNY.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("日期：");
                sbCaption.Append(FFGZNY.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YFX.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("应发项：");
                sbCaption.Append(YFX.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YFXBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("应发项开始值：");
                sbCaption.Append(YFXBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(YFXEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("应发项结束值：");
                sbCaption.Append(YFXEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SFGZ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("实发工资：");
                sbCaption.Append(SFGZ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SFGZBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("实发工资开始值：");
                sbCaption.Append(SFGZBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(SFGZEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("实发工资结束值：");
                sbCaption.Append(SFGZEnd.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(TJSJ.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("添加时间：");
                sbCaption.Append(TJSJ.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(TJSJBegin.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("添加时间开始值：");
                sbCaption.Append(TJSJBegin.Text);
               sbCaption.Append(@"</div>");
            }
            if (!DataValidateManager.ValidateIsNull(TJSJEnd.Text))
            {
               sbCaption.Append(@"<div style=""margin-right:10px"">");
                sbCaption.Append("添加时间结束值：");
                sbCaption.Append(TJSJEnd.Text);
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

            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            XM_Area.Visible = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            XB_Area.Visible = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            SFZH_Area.Visible = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            YFX_Area.Visible = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            SFGZ_Area.Visible = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            gvList.Columns[intTJSJColumnIndex].Visible = 
            chkShowTJSJ_Area.Visible =
            chkShowTJSJ.Checked =
            chkShowTJSJ.Enabled = false;
            }
            if(CustomPermission == WDGZ_PURVIEW_ID)
            {
            TJSJ_Area.Visible = false;
            }
        }
    }

    protected override void SetCurrentAccessPermission()
    {

        if (CustomPermission == WDGZ_PURVIEW_ID)
        {
            CurrentAccessPermission = WDGZ_PURVIEW_ID;
        }
        
        base.SetCurrentAccessPermission();
    }
}

