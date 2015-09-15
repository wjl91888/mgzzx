/****************************************************** 
FileName:FilterReportWebUIAdd.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.BM.FilterReport;

public partial class FilterReportWebUIAdd : RICH.Common.BM.FilterReport.FilterReportWebUI
{
    //=====================================================================
    //  FunctionName : OnPreInit
    /// <summary>
    /// OnPreInit
    /// </summary>
    //=====================================================================
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
  
    }

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
            // 初始化绑定数据
            InitalizeDataBind();
            // 初始化耦合绑定数据
            InitalizeCoupledDataSource();
            // 全局初始化
            Initalize();
            // 初始化自定义添加字段
            InitalizeCustomAdd();
            // 相关表相关
            InitalizeRelatedTableAdd();
        }
        else
        {
            // 初始化耦合绑定数据
            InitalizeCoupledDataSource();
        }
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
        // 初始化界面


        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new FilterReportApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    BGMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGMC"]); 
                    UserID.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserID"]); 
                    BGLX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGLX"]); 
                    GXBG.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["GXBG"]); 
                    XTBG.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["XTBG"]); 
                    BGCXTJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGCXTJ"]); 
                    BGCJSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGCJSJ"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                // 初始化默认值

            }

    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (EditMode)
        {
            btnModifyConfirm_Click(sender, e);
        }
        else if(CopyMode || AddMode)
        {
            btnAddConfirm_Click(sender, e);
        }
    }

    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // 初始化用户编号(UserID)下拉列表
          UserID.DataSource = GetDataSource_UserID();
        UserID.DataTextField = "UserLoginName";
        UserID.DataValueField = "UserID";
              UserID.DataBind();
        
        // 初始化共享报告(GXBG)下拉列表
          GXBG.DataSource = GetDataSource_GXBG();
        GXBG.DataTextField = "MC";
        GXBG.DataValueField = "DM";
              GXBG.DataBind();
        
        // 初始化系统报告(XTBG)下拉列表
          XTBG.DataSource = GetDataSource_XTBG();
        XTBG.DataTextField = "MC";
        XTBG.DataValueField = "DM";
              XTBG.DataBind();
        
    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// 得到添加用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数

        validateData = ValidateBGMC(BGMC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGMC = Convert.ToString(validateData.Value.ToString());
            }
            BGMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateBGLX(BGLX.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGLX = Convert.ToString(validateData.Value.ToString());
            }
            BGLX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGLX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateGXBG(GXBG.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.GXBG = Convert.ToString(validateData.Value.ToString());
            }
            GXBG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GXBG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateXTBG(XTBG.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XTBG = Convert.ToString(validateData.Value.ToString());
            }
            XTBG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XTBG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateBGCXTJ(BGCXTJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGCXTJ = Convert.ToString(validateData.Value.ToString());
            }
            BGCXTJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGCXTJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // 自动生成编号

        appData.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];

        appData.BGCJSJ = DateTime.Now;

        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetModifyInputParameter
    /// <summary>
    /// 得到修改用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetModifyInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数
        appData = RICH.Common.BM.FilterReport.FilterReportBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateBGMC(BGMC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGMC = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BGMC = null;
            }
            BGMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserID(UserID.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserID = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.UserID = null;
            }
            UserID.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserID.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBGLX(BGLX.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGLX = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BGLX = null;
            }
            BGLX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGLX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateGXBG(GXBG.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.GXBG = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.GXBG = null;
            }
            GXBG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GXBG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXTBG(XTBG.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XTBG = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.XTBG = null;
            }
            XTBG.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XTBG.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBGCXTJ(BGCXTJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGCXTJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BGCXTJ = null;
            }
            BGCXTJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGCXTJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBGCJSJ(BGCJSJ.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGCJSJ = Convert.ToDateTime(validateData.Value.ToString());
            }
            BGCJSJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGCJSJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        return boolReturn;
    }

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
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// 初始化自定义添加
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // 定制添加相关表信息

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// 初始化批量添加模板
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        string strSortClassify = string.Empty;
        GridView rptTemp = (GridView)sender;

    }

    //=====================================================================
    //  FunctionName : RelatedTableAddBatch()
    /// <summary>
    /// 相关表批量添加
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// 相关表批量修改
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {

    }

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "FilterReport", dt, true, true);
        FilterReportApplicationLogic instanceFilterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new FilterReportApplicationData();

            int i = 0;

            appData = instanceFilterReportApplicationLogic.Add(appData);
        }
    }
    protected void btnInfoFromDoc_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWord(InfoFromDoc.Text, dt, true);
        if (dt.Rows.Count > 0)
        {
            int i = 0;

        }
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    protected void btnImportFromDoc_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = true;
        ControlContainer.Visible = false;
    }
    protected void btnInfoFromDocCancel_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    private DataTable GetTemplateColumn(DataTable dt)
    {

        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        int totalCount = 0;
        int importCount = 0;
        int updateCount = 0;
        try
        {
            var appDatas = FilterReportApplicationData.GetDataFromDataFile<FilterReportApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: FilterReportContants.ImportDataSetStartLineNum);
            FilterReportApplicationLogic instanceFilterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                if(!BGMC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BGMC =  Convert.ToString(BGMC.Text);
                }
    
                app.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];
                string strUserID = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserLoginName", app.UserID, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strUserID))app.UserID = strUserID;
                if(!BGLX.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BGLX =  Convert.ToString(BGLX.Text);
                }
    
                string strGXBG = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.GXBG, "DM"));
                if (!DataValidateManager.ValidateIsNull(strGXBG))app.GXBG = strGXBG;
                if(!GXBG.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.GXBG =  Convert.ToString(GXBG.SelectedValue);
                }
    
                string strXTBG = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.XTBG, "DM"));
                if (!DataValidateManager.ValidateIsNull(strXTBG))app.XTBG = strXTBG;
                if(!XTBG.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.XTBG =  Convert.ToString(XTBG.SelectedValue);
                }
    
                if(!BGCXTJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BGCXTJ =  Convert.ToString(BGCXTJ.Text);
                }
    
                app.BGCJSJ = DateTime.Now;
                instanceFilterReportApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceFilterReportApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">共{0}条数据，导入数据{1}条，更新数据{2}条。</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">导入数据过程出错：{0}<br/>共{1}条数据，已导入数据{2}条，已更新数据{3}条。</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
    {
        if (AccessPermission)
        {
            if(EditMode)
            {
    ObjectID_Area.Visible = false;
      UserID.Enabled = false;
                BGLX.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      UserID_Area.Visible = false;
      BGCJSJ_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      BGMC_Area.Visible = false;
      BGMC_Area.Visible = true;
      UserID_Area.Visible = false;
      BGLX_Area.Visible = false;
      BGLX_Area.Visible = true;
      GXBG_Area.Visible = false;
      GXBG_Area.Visible = true;
      XTBG_Area.Visible = false;
      XTBG_Area.Visible = true;
      BGCXTJ_Area.Visible = false;
      BGCXTJ_Area.Visible = true;
      BGCJSJ_Area.Visible = false;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      BGMC.Enabled = false;
                UserID.Enabled = false;
                BGLX.Enabled = false;
                GXBG.Enabled = false;
                XTBG.Enabled = false;
                BGCXTJ.EditMode=false;
                BGCJSJ.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new FilterReportApplicationData();
    
                appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                QueryRecord();
                if (appData.RecordCount == 1)
                {
                    return GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                }
                else
                {
                    return string.Empty;
                }
    }
}

