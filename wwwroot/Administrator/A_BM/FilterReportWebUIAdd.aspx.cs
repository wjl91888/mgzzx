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


        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new FilterReportApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
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
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.BGMC = Convert.ToString(validateData.Value.ToString());
                BGMC_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.BGLX = Convert.ToString(validateData.Value.ToString());
                BGLX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.GXBG = Convert.ToString(validateData.Value.ToString());
                GXBG_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.XTBG = Convert.ToString(validateData.Value.ToString());
                XTBG_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.BGCXTJ = Convert.ToString(validateData.Value.ToString());
                BGCXTJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                BGMC_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                UserID_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                BGLX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                GXBG_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                XTBG_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                BGCXTJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                BGCJSJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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



    public void CheckPermission()
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

