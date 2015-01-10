/****************************************************** 
FileName:ShortMessageWebUIAdd.aspx.cs
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
using RICH.Common.BM.ShortMessage;

public partial class ShortMessageWebUIAdd : RICH.Common.BM.ShortMessage.ShortMessageWebUI
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
DXXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";DXXFJ.Attributes.Add("onclick", "uploadfile(this);");

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new ShortMessageApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    DXXBT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXBT"]); 
                    DXXLX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXLX"]); 
                    DXXNR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXNR"]); 
                    DXXFJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXFJ"]); 
                    FSSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSSJ"]); 
                    FSR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSR"]); 
                    FSBM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSBM"]); 
                    FSIP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSIP"]); 
                    JSR.SelectedValues = GetValue(appData.ResultSet.Tables[0].Rows[0]["JSR"]); 
                    SFCK.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFCK"]); 
                    CKSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["CKSJ"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["JSR"]))
                {
                    JSR.SelectedValues = GetValue(Request.QueryString["JSR"]); 
                    JSR.Enabled = false;
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

        // 初始化接收人(JSR)下拉列表
          JSR.DataSource = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetTreeData_T_PM_UserInfo_SubjectID("UserID", "UserNickName",  null, "null", null);
        JSR.DataFieldID = "ID";
        JSR.DataFieldParentID = "ParentID";
        JSR.DataTextField = "Name";
        JSR.DataValueField = "ID";
        JSR.CheckBoxes = true;
        JSR.CheckChildNodes = true;
              JSR.DataBind();
        
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

        validateData = ValidateDXXBT(DXXBT.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXBT = Convert.ToString(validateData.Value.ToString());
                DXXBT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DXXBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDXXNR(DXXNR.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXNR = Convert.ToString(validateData.Value.ToString());
                DXXNR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DXXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDXXFJ(DXXFJ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXFJ = Convert.ToString(validateData.Value.ToString());
                DXXFJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DXXFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXFJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
                JSR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // 自动生成编号

        appData.DXXLX = "01";

        appData.FSSJ = DateTime.Now;

        appData.FSR = (string)Session[ConstantsManager.SESSION_USER_ID];

        appData.FSBM = (string)Session[ConstantsManager.SESSION_SSDW_ID];

        appData.FSIP = (string)Request.ServerVariables["REMOTE_ADDR"];

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
        appData = RICH.Common.BM.ShortMessage.ShortMessageBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateDXXBT(DXXBT.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXBT = Convert.ToString(validateData.Value.ToString());
                DXXBT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.DXXBT = null;
            }
            DXXBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDXXNR(DXXNR.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXNR = Convert.ToString(validateData.Value.ToString());
                DXXNR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.DXXNR = null;
            }
            DXXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDXXFJ(DXXFJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXFJ = Convert.ToString(validateData.Value.ToString());
                DXXFJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.DXXFJ = null;
            }
            DXXFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXFJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
                JSR_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.JSR = null;
            }
            JSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSR.BackColor = System.Drawing.Color.YellowGreen;
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
	  DXXBT.Enabled = false;
                DXXLX_Area.Visible = false;
	  DXXNR.ReadOnly = true;
			    DXXFJ.Enabled = false;
                FSSJ_Area.Visible = false;
	  FSR_Area.Visible = false;
	  FSBM_Area.Visible = false;
	  FSIP_Area.Visible = false;
	  JSR.ReadOnly = true;
			    SFCK_Area.Visible = false;
	  CKSJ_Area.Visible = false;
	  
			}
			else if(AddMode || CopyMode)
			{
	ObjectID_Area.Visible = false;
	  DXXLX_Area.Visible = false;
	  FSSJ_Area.Visible = false;
	  FSR_Area.Visible = false;
	  FSBM_Area.Visible = false;
	  FSIP_Area.Visible = false;
	  SFCK_Area.Visible = false;
	  CKSJ_Area.Visible = false;
	  
			}
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      DXXBT.Enabled = false;
                DXXLX.Enabled = false;
                DXXLX_Area.Visible = false;
      DXXNR.ReadOnly = true;
                DXXFJ.Enabled = false;
                FSSJ.Enabled = false;
                FSR.Enabled = false;
                FSBM.Enabled = false;
                FSIP.Enabled = false;
                FSIP_Area.Visible = false;
      JSR.ReadOnly = true;
                JSR_Area.Visible = false;
      SFCK.Enabled = false;
                SFCK_Area.Visible = false;
      CKSJ.Enabled = false;
                CKSJ_Area.Visible = false;
      
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

