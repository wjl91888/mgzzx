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
            appData = new T_BM_DWXXApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.DWMC = Convert.ToString(validateData.Value.ToString());
                DWMC_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                SJDWBH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.DZ = Convert.ToString(validateData.Value.ToString());
                DZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.YB = Convert.ToString(validateData.Value.ToString());
                YB_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LXBM = Convert.ToString(validateData.Value.ToString());
                LXBM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LXDH = Convert.ToString(validateData.Value.ToString());
                LXDH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.Email = Convert.ToString(validateData.Value.ToString());
                Email_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.LXR = Convert.ToString(validateData.Value.ToString());
                LXR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SJ = Convert.ToString(validateData.Value.ToString());
                SJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                DWBH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                DWMC_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                SJDWBH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                DZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                YB_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LXBM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LXDH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                Email_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                LXR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                SJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }
    protected void btnImportFromDoc_Click(object sender, EventArgs e)
    {
        AddFromDoc.Visible = true;
        addpage.Visible = false;
    }
    protected void btnInfoFromDocCancel_Click(object sender, EventArgs e)
    {
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }
    private DataTable GetTemplateColumn(DataTable dt)
    {

        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWord(InfoFromDoc.Text, dt, true);
        if (dt.Rows.Count > 0)
        {
            int i = 0;

        }
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }

    public void CheckPermission()
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
                
      btnAddConfirm.Visible = false;
      btnReset.Visible = false;
    
            }
            else
            {
      btnEditItem.Visible = false;
    
            }
        }
        else
        {
            ControlContainer.Visible = false;
            btnAddConfirm.Visible = false;
            btnReset.Visible = false;
        
        }
    }
}

