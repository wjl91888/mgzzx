/****************************************************** 
FileName:T_BG_0602WebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BG_0602;

public partial class T_BG_0602WebUIAdd : RICH.Common.BM.T_BG_0602.T_BG_0602WebUI
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
LMNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BG_0602ApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    LMH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LMH"]); 
                    LMM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LMM"]); 
                    SJLMH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJLMH"]); 
                    LMTP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LMTP"]); 
                    LMNR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LMNR"]); 
                    LMLBYS.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["LMLBYS"]); 
                    SFLBLM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFLBLM"]); 
                    SFWBURL.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFWBURL"]); 
                    WBURL.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["WBURL"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["SJLMH"]))
                {
                    SJLMH.SelectedValue = GetValue(Request.QueryString["SJLMH"]); 
                    SJLMH.Enabled = false;
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

        // 初始化上级栏目(SJLMH)下拉列表
          SJLMH.DataSource = GetDataSource_SJLMH();
        SJLMH.DataTextField = "LMM";
        SJLMH.DataValueField = "LMH";
              SJLMH.DataBind();
        SJLMH.Items.Insert(0, new ListItem("请选择上级栏目", ""));
              
        // 初始化栏目列表样式(LMLBYS)下拉列表
          LMLBYS.DataSource = GetDataSource_LMLBYS();
        LMLBYS.DataTextField = "MC";
        LMLBYS.DataValueField = "DM";
              LMLBYS.DataBind();
        
        // 初始化列表内容栏目(SFLBLM)下拉列表
          SFLBLM.DataSource = GetDataSource_SFLBLM();
        SFLBLM.DataTextField = "MC";
        SFLBLM.DataValueField = "DM";
              SFLBLM.DataBind();
        
        // 初始化外部栏目(SFWBURL)下拉列表
          SFWBURL.DataSource = GetDataSource_SFWBURL();
        SFWBURL.DataTextField = "MC";
        SFWBURL.DataValueField = "DM";
              SFWBURL.DataBind();
        
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

        validateData = ValidateLMM(LMM.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LMM = Convert.ToString(validateData.Value.ToString());
            }
            LMM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJLMH(SJLMH.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SJLMH = Convert.ToString(validateData.Value.ToString());
            }
            SJLMH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJLMH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (LMTP.Upload())
        {
            appData.LMTP = LMTP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + LMTP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateLMNR(LMNR.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LMNR = Convert.ToString(validateData.Value.ToString());
            }
            LMNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMLBYS(LMLBYS.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.LMLBYS = Convert.ToString(validateData.Value.ToString());
            }
            LMLBYS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMLBYS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFLBLM(SFLBLM.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SFLBLM = Convert.ToString(validateData.Value.ToString());
            }
            SFLBLM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFLBLM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFWBURL(SFWBURL.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.SFWBURL = Convert.ToString(validateData.Value.ToString());
            }
            SFWBURL.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFWBURL.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateWBURL(WBURL.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.WBURL = Convert.ToString(validateData.Value.ToString());
            }
            WBURL.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            WBURL.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_BG_0602ApplicationLogic instanceT_BG_0602ApplicationLogic
            = (T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0602ApplicationLogic));
        appData.LMH = instanceT_BG_0602ApplicationLogic.AutoGenerateLMH(appData);
                
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
        appData = RICH.Common.BM.T_BG_0602.T_BG_0602BusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateLMH(LMH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LMH = null;
            }
            LMH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMM(LMM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LMM = null;
            }
            LMM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJLMH(SJLMH.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJLMH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SJLMH = null;
            }
            SJLMH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJLMH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (LMTP.Upload())
        {
            appData.LMTP = LMTP.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + LMTP.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateLMNR(LMNR.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMNR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LMNR = null;
            }
            LMNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMLBYS(LMLBYS.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMLBYS = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.LMLBYS = null;
            }
            LMLBYS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMLBYS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFLBLM(SFLBLM.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SFLBLM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SFLBLM = null;
            }
            SFLBLM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFLBLM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFWBURL(SFWBURL.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SFWBURL = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.SFWBURL = null;
            }
            SFWBURL.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFWBURL.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateWBURL(WBURL.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.WBURL = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.WBURL = null;
            }
            WBURL.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            WBURL.BackColor = System.Drawing.Color.YellowGreen;
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BG_0602", dt, true, true);
        T_BG_0602ApplicationLogic instanceT_BG_0602ApplicationLogic = (T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0602ApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BG_0602ApplicationData();

            appData.LMH = instanceT_BG_0602ApplicationLogic.AutoGenerateLMH(appData);
                
            int i = 0;

            appData = instanceT_BG_0602ApplicationLogic.Add(appData);
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
            var appDatas = T_BG_0602ApplicationData.GetDataFromDataFile<T_BG_0602ApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BG_0602Contants.ImportDataSetStartLineNum);
            T_BG_0602ApplicationLogic instanceT_BG_0602ApplicationLogic = (T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0602ApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.LMH = instanceT_BG_0602ApplicationLogic.AutoGenerateLMH(app);
                    
                if(!LMM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LMM =  Convert.ToString(LMM.Text);
                }
    
                string strSJLMH = GetValue(new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogicBase().GetValueByFixCondition("LMM", app.SJLMH, "LMH"));
                if (!DataValidateManager.ValidateIsNull(strSJLMH))app.SJLMH = strSJLMH;
                if(!SJLMH.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJLMH =  Convert.ToString(SJLMH.SelectedValue);
                }
    
                if(!LMTP.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LMTP =  Convert.ToString(LMTP.Text);
                }
    
                if(!LMNR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.LMNR =  Convert.ToString(LMNR.Text);
                }
    
                string strLMLBYS = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.LMLBYS, "DM"));
                if (!DataValidateManager.ValidateIsNull(strLMLBYS))app.LMLBYS = strLMLBYS;
                if(!LMLBYS.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.LMLBYS =  Convert.ToString(LMLBYS.SelectedValue);
                }
    
                string strSFLBLM = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.SFLBLM, "DM"));
                if (!DataValidateManager.ValidateIsNull(strSFLBLM))app.SFLBLM = strSFLBLM;
                if(!SFLBLM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SFLBLM =  Convert.ToString(SFLBLM.SelectedValue);
                }
    
                string strSFWBURL = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.SFWBURL, "DM"));
                if (!DataValidateManager.ValidateIsNull(strSFWBURL))app.SFWBURL = strSFWBURL;
                if(!SFWBURL.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SFWBURL =  Convert.ToString(SFWBURL.SelectedValue);
                }
    
                if(!WBURL.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.WBURL =  Convert.ToString(WBURL.Text);
                }
    
                instanceT_BG_0602ApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BG_0602ApplicationLogic.Modify(app);
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
      
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      LMH_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      LMH_Area.Visible = false;
      LMM_Area.Visible = false;
      LMM_Area.Visible = true;
      SJLMH_Area.Visible = false;
      SJLMH_Area.Visible = true;
      LMTP_Area.Visible = false;
      LMTP_Area.Visible = true;
      LMNR_Area.Visible = false;
      LMNR_Area.Visible = true;
      LMLBYS_Area.Visible = false;
      LMLBYS_Area.Visible = true;
      SFLBLM_Area.Visible = false;
      SFLBLM_Area.Visible = true;
      SFWBURL_Area.Visible = false;
      SFWBURL_Area.Visible = true;
      WBURL_Area.Visible = false;
      WBURL_Area.Visible = true;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      LMH.Enabled = false;
                LMM.Enabled = false;
                SJLMH.Enabled = false;
                LMTP.ReadOnly = true;
                LMNR.ReadOnly = true;
                LMLBYS.Enabled = false;
                SFLBLM.Enabled = false;
                SFWBURL.Enabled = false;
                WBURL.Enabled = false;
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BG_0602ApplicationData();
    
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

