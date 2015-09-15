/****************************************************** 
FileName:DictionaryWebUIAdd.aspx.cs
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
using RICH.Common.BM.Dictionary;

public partial class DictionaryWebUIAdd : RICH.Common.BM.Dictionary.DictionaryWebUI
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
            appData = new DictionaryApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    DM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DM"]); 
                    LX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["LX"]); 
                    MC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["MC"]); 
                    LXCoupled();
                SJDM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDM"]); 
                    SM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SM"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["LX"]))
                {
                    LX.SelectedValue = GetValue(Request.QueryString["LX"]); 
                    LX.Enabled = false;
                }
            LXCoupled();
      
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["SJDM"]))
                {
                    SJDM.SelectedValue = GetValue(Request.QueryString["SJDM"]); 
                    SJDM.Enabled = false;
                }
            
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

        // 初始化类型(LX)下拉列表
          LX.DataSource = GetDataSource_LX();
        LX.DataTextField = "MC";
        LX.DataValueField = "DM";
              LX.DataBind();
        
        // 初始化上级代码(SJDM)下拉列表
        SJDM.DataTextField = "MC";
        SJDM.DataValueField = "DM";
        LXCoupled();
    
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

        validateData = ValidateDM(DM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DM = Convert.ToString(validateData.Value.ToString());
            }
            DM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateLX(LX.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LX = Convert.ToString(validateData.Value.ToString());
            }
            LX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateMC(MC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.MC = Convert.ToString(validateData.Value.ToString());
            }
            MC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJDM = Convert.ToString(validateData.Value.ToString());
            }
            SJDM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSM(SM.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SM = Convert.ToString(validateData.Value.ToString());
            }
            SM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // 自动生成编号

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
        appData = RICH.Common.BM.Dictionary.DictionaryBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateDM(DM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.DM = null;
            }
            DM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLX(LX.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LX = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LX = null;
            }
            LX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateMC(MC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.MC = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.MC = null;
            }
            MC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJDM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SJDM = null;
            }
            SJDM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSM(SM.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SM = null;
            }
            SM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SM.BackColor = System.Drawing.Color.YellowGreen;
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
            SJDM.DataSource = GetDataSource_SJDM("LX", LX.SelectedValue);
            SJDM.DataBind();
            if (!(SJDM.Items.Count > 0))
            {
                SJDM.Items.Insert(0, new ListItem("无", ""));
            }
            
            else
            {
                SJDM.Items.Insert(0, new ListItem("请选择", ""));    
            }
            
        }
        else
        {
            SJDM.Items.Clear();
            SJDM.Items.Insert(0, new ListItem("请先选择类型", ""));
        }
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "Dictionary", dt, true, true);
        DictionaryApplicationLogic instanceDictionaryApplicationLogic = (DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new DictionaryApplicationData();

            int i = 0;

            appData = instanceDictionaryApplicationLogic.Add(appData);
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
            var appDatas = DictionaryApplicationData.GetDataFromDataFile<DictionaryApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: DictionaryContants.ImportDataSetStartLineNum);
            DictionaryApplicationLogic instanceDictionaryApplicationLogic = (DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                if(!DM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DM =  Convert.ToString(DM.Text);
                }
    
                string strLX = GetValue(new RICH.Common.BM.DictionaryType.DictionaryTypeApplicationLogicBase().GetValueByFixCondition("MC", app.LX, "DM"));
                if (!DataValidateManager.ValidateIsNull(strLX))app.LX = strLX;
                if(!LX.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.LX =  Convert.ToString(LX.SelectedValue);
                }
    
                if(!MC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.MC =  Convert.ToString(MC.Text);
                }
    
                string strSJDM = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.SJDM, "DM"));
                if (!DataValidateManager.ValidateIsNull(strSJDM))app.SJDM = strSJDM;
                if(!SJDM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJDM =  Convert.ToString(SJDM.SelectedValue);
                }
    
                if(!SM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SM =  Convert.ToString(SM.Text);
                }
    
                instanceDictionaryApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceDictionaryApplicationLogic.Modify(app);
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
      DM.Enabled = false;
                LX.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      DM_Area.Visible = false;
      DM_Area.Visible = true;
      LX_Area.Visible = false;
      LX_Area.Visible = true;
      MC_Area.Visible = false;
      MC_Area.Visible = true;
      SJDM_Area.Visible = false;
      SJDM_Area.Visible = true;
      SM_Area.Visible = false;
      SM_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      DM.Enabled = false;
                LX.Enabled = false;
                MC.Enabled = false;
                SJDM.Enabled = false;
                SM.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new DictionaryApplicationData();
    
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

