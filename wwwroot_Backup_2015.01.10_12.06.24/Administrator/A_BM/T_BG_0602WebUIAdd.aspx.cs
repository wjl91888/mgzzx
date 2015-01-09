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
        // 基本SESSION赋值
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_ADD_FILENAME;
        if (EditMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_MODIFY_ACCESS_PURVIEW_ID;
        }
        else if (ViewMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_DETAIL_ACCESS_PURVIEW_ID;
        }
        else if (AddMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_ADD_ACCESS_PURVIEW_ID;
        }
        else
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = NO_ACCESS_PURVIEW_ID;
        }
        MessageContent = string.Empty;
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
        CheckPermission();
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
LMTP.Attributes.Add("onclick", "UplaodImageFile(this);");LMNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BG_0602ApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LMM = Convert.ToString(validateData.Value.ToString());
                LMM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SJLMH = Convert.ToString(validateData.Value.ToString());
                SJLMH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SJLMH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJLMH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMTP(LMTP.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LMTP = Convert.ToString(validateData.Value.ToString());
                LMTP_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            LMTP.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMTP.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMNR(LMNR.Text, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LMNR = Convert.ToString(validateData.Value.ToString());
                LMNR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LMLBYS = Convert.ToString(validateData.Value.ToString());
                LMLBYS_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SFLBLM = Convert.ToString(validateData.Value.ToString());
                SFLBLM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SFWBURL = Convert.ToString(validateData.Value.ToString());
                SFWBURL_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.WBURL = Convert.ToString(validateData.Value.ToString());
                WBURL_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LMH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LMM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                SJLMH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                
        validateData = ValidateLMTP(LMTP.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMTP = Convert.ToString(validateData.Value.ToString());
                LMTP_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.LMTP = null;
            }
            LMTP.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LMTP.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLMNR(LMNR.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LMNR = Convert.ToString(validateData.Value.ToString());
                LMNR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LMLBYS_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                SFLBLM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                SFWBURL_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                WBURL_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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



    public void CheckPermission()
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
            if (ViewMode)
            {
    ObjectID.ReadOnly = true;
                ObjectID_Area.Visible = false;
      LMH.ReadOnly = true;
                LMM.ReadOnly = true;
                SJLMH.Enabled = false;
                LMTP.ReadOnly = true;
                LMNR.ReadOnly = true;
                LMLBYS.Enabled = false;
                SFLBLM.Enabled = false;
                SFWBURL.Enabled = false;
                WBURL.ReadOnly = true;
                
      btnAddConfirm.Visible = false;
      btnReset.Visible = false;
    
            }
            else
            {
      btnEditItem.Visible = false;
    
      btnCopyItem.Visible = false;
    
            }
        }
        else
        {
            ControlContainer.Visible = false;
            btnAddConfirm.Visible = false;
            btnReset.Visible = false;
        
            btnCopyItem.Visible = false;
        
        }
    }
}

