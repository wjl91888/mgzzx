/****************************************************** 
FileName:T_BM_DWXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_DWXX;

public partial class T_BM_DWXXWebUIAdd : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
            appData = new T_BM_DWXXApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    DWBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWBH"]); 
                    DWMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWMC"]); 
                    SJDWBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDWBH"]); 
                    DZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DZ"]); 
                    YB.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YB"]); 
                    LXBM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXBM"]); 
                    LXDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXDH"]); 
                    Email.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["Email"]); 
                    LXR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXR"]); 
                    SJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJ"]); 
                    
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

        // 初始化上级单位(SJDWBH)下拉列表
          SJDWBH.DataSource = GetDataSource_SJDWBH();
        SJDWBH.DataTextField = "DWMC";
        SJDWBH.DataValueField = "DWBH";
              SJDWBH.DataBind();
        SJDWBH.Items.Insert(0, new ListItem("请选择上级单位", ""));
              
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

        validateData = ValidateDWMC(DWMC.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.DWMC = Convert.ToString(validateData.Value.ToString());
            }
            DWMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DWMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
            }
            SJDWBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDZ(DZ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.DZ = Convert.ToString(validateData.Value.ToString());
            }
            DZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYB(YB.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.YB = Convert.ToString(validateData.Value.ToString());
            }
            YB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXBM(LXBM.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LXBM = Convert.ToString(validateData.Value.ToString());
            }
            LXBM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXBM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXDH(LXDH.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LXDH = Convert.ToString(validateData.Value.ToString());
            }
            LXDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateEmail(Email.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.Email = Convert.ToString(validateData.Value.ToString());
            }
            Email.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            Email.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXR(LXR.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LXR = Convert.ToString(validateData.Value.ToString());
            }
            LXR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJ(SJ.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SJ = Convert.ToString(validateData.Value.ToString());
            }
            SJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_BM_DWXXApplicationLogic instanceT_BM_DWXXApplicationLogic
            = (T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_DWXXApplicationLogic));
        appData.DWBH = instanceT_BM_DWXXApplicationLogic.AutoGenerateDWBH(appData);
                
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
        appData = RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateDWBH(DWBH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DWBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.DWBH = null;
            }
            DWBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DWBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDWMC(DWMC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DWMC = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.DWMC = null;
            }
            DWMC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DWMC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SJDWBH = null;
            }
            SJDWBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDZ(DZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DZ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.DZ = null;
            }
            DZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYB(YB.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YB = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.YB = null;
            }
            YB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXBM(LXBM.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LXBM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LXBM = null;
            }
            LXBM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXBM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXDH(LXDH.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LXDH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LXDH = null;
            }
            LXDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateEmail(Email.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.Email = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.Email = null;
            }
            Email.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            Email.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLXR(LXR.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LXR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LXR = null;
            }
            LXR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LXR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJ(SJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJ = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SJ = null;
            }
            SJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJ.BackColor = System.Drawing.Color.YellowGreen;
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_DWXX", dt, true, true);
        T_BM_DWXXApplicationLogic instanceT_BM_DWXXApplicationLogic = (T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_DWXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_DWXXApplicationData();

            appData.DWBH = instanceT_BM_DWXXApplicationLogic.AutoGenerateDWBH(appData);
                
            int i = 0;

            appData = instanceT_BM_DWXXApplicationLogic.Add(appData);
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
            var appDatas = T_BM_DWXXApplicationData.GetDataFromDataFile<T_BM_DWXXApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BM_DWXXContants.ImportDataSetStartLineNum);
            T_BM_DWXXApplicationLogic instanceT_BM_DWXXApplicationLogic = (T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_DWXXApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.DWBH = instanceT_BM_DWXXApplicationLogic.AutoGenerateDWBH(app);
                    
                if(!DWMC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DWMC =  Convert.ToString(DWMC.Text);
                }
    
                string strSJDWBH = GetValue(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogicBase().GetValueByFixCondition("DWMC", app.SJDWBH, "DWBH"));
                if (!DataValidateManager.ValidateIsNull(strSJDWBH))app.SJDWBH = strSJDWBH;
                if(!SJDWBH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJDWBH =  Convert.ToString(SJDWBH.SelectedValue);
                }
    
                if(!DZ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DZ =  Convert.ToString(DZ.Text);
                }
    
                if(!YB.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.YB =  Convert.ToString(YB.Text);
                }
    
                if(!LXBM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LXBM =  Convert.ToString(LXBM.Text);
                }
    
                if(!LXDH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LXDH =  Convert.ToString(LXDH.Text);
                }
    
                if(!Email.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.Email =  Convert.ToString(Email.Text);
                }
    
                if(!LXR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LXR =  Convert.ToString(LXR.Text);
                }
    
                if(!SJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJ =  Convert.ToString(SJ.Text);
                }
    
                instanceT_BM_DWXXApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BM_DWXXApplicationLogic.Modify(app);
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
      DWBH.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      DWBH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      DWBH_Area.Visible = false;
      DWMC_Area.Visible = false;
      DWMC_Area.Visible = true;
      SJDWBH_Area.Visible = false;
      SJDWBH_Area.Visible = true;
      DZ_Area.Visible = false;
      DZ_Area.Visible = true;
      YB_Area.Visible = false;
      YB_Area.Visible = true;
      LXBM_Area.Visible = false;
      LXBM_Area.Visible = true;
      LXDH_Area.Visible = false;
      LXDH_Area.Visible = true;
      Email_Area.Visible = false;
      Email_Area.Visible = true;
      LXR_Area.Visible = false;
      LXR_Area.Visible = true;
      SJ_Area.Visible = false;
      SJ_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      DWBH.Enabled = false;
                DWMC.Enabled = false;
                SJDWBH.Enabled = false;
                DZ.Enabled = false;
                YB.Enabled = false;
                LXBM.Enabled = false;
                LXDH.Enabled = false;
                Email.Enabled = false;
                LXR.Enabled = false;
                SJ.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BM_DWXXApplicationData();
    
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

