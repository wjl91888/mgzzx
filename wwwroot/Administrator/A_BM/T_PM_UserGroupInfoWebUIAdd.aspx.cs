/****************************************************** 
FileName:T_PM_UserGroupInfoWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_PM_UserGroupInfo;

public partial class T_PM_UserGroupInfoWebUIAdd : RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoWebUI
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
UserGroupContent.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";UserGroupRemark.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_PM_UserGroupInfoApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    UserGroupID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupID"]); 
                    UserGroupName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupName"]); 
                    UserGroupContent.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupContent"]); 
                    UserGroupRemark.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupRemark"]); 
                    DefaultPage.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DefaultPage"]); 
                    UpdateDate.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UpdateDate"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                // 初始化默认值
UpdateDate.Text = DateTime.Now.ToString(); 

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

        validateData = ValidateUserGroupID(UserGroupID.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.UserGroupID = Convert.ToString(validateData.Value.ToString());
                UserGroupID_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            UserGroupID.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupID.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateUserGroupName(UserGroupName.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.UserGroupName = Convert.ToString(validateData.Value.ToString());
                UserGroupName_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            UserGroupName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateUserGroupContent(UserGroupContent.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.UserGroupContent = Convert.ToString(validateData.Value.ToString());
                UserGroupContent_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            UserGroupContent.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupContent.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateUserGroupRemark(UserGroupRemark.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.UserGroupRemark = Convert.ToString(validateData.Value.ToString());
                UserGroupRemark_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            UserGroupRemark.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupRemark.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDefaultPage(DefaultPage.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DefaultPage = Convert.ToString(validateData.Value.ToString());
                DefaultPage_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DefaultPage.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DefaultPage.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // 自动生成编号

        appData.UpdateDate = DateTime.Now;

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
        appData = RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateUserGroupID(UserGroupID.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupID = Convert.ToString(validateData.Value.ToString());
                UserGroupID_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.UserGroupID = null;
            }
            UserGroupID.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupID.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserGroupName(UserGroupName.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupName = Convert.ToString(validateData.Value.ToString());
                UserGroupName_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.UserGroupName = null;
            }
            UserGroupName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserGroupContent(UserGroupContent.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupContent = Convert.ToString(validateData.Value.ToString());
                UserGroupContent_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.UserGroupContent = null;
            }
            UserGroupContent.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupContent.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserGroupRemark(UserGroupRemark.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupRemark = Convert.ToString(validateData.Value.ToString());
                UserGroupRemark_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.UserGroupRemark = null;
            }
            UserGroupRemark.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserGroupRemark.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDefaultPage(DefaultPage.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DefaultPage = Convert.ToString(validateData.Value.ToString());
                DefaultPage_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.DefaultPage = null;
            }
            DefaultPage.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DefaultPage.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        appData.UpdateDate = DateTime.Now;

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
	  UserGroupID.Enabled = false;
                UpdateDate.Enabled = false;
                
			}
			else if(AddMode || CopyMode)
			{
	ObjectID_Area.Visible = false;
	  UpdateDate_Area.Visible = false;
	  
			}
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      UserGroupID.Enabled = false;
                UserGroupName.Enabled = false;
                UserGroupContent.ReadOnly = true;
                UserGroupRemark.ReadOnly = true;
                DefaultPage.Enabled = false;
                UpdateDate.Enabled = false;
                
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

