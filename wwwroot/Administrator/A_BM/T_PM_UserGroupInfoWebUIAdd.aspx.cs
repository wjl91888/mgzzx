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
            // ��ʼ��������
            InitalizeDataBind();
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
            // ȫ�ֳ�ʼ��
            Initalize();
            // ��ʼ���Զ�������ֶ�
            InitalizeCustomAdd();
            // ��ر����
            InitalizeRelatedTableAdd();
        }
        else
        {
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
        }
        base.Page_Load(sender, e);
        CheckPermission();
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
        // ��ʼ������
UserGroupContent.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";UserGroupRemark.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_PM_UserGroupInfoApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
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
                // ��ʼ���������

                // ��ʼ��Ĭ��ֵ
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
    /// ��ʼ�����ݰ�
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// �õ�����û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������

        validateData = ValidateUserGroupID(UserGroupID.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.UserGroupID = Convert.ToString(validateData.Value.ToString());
                UserGroupID_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupContent_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupRemark_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                DefaultPage_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            DefaultPage.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DefaultPage.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // �Զ����ɱ��

        appData.UpdateDate = DateTime.Now;

        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetModifyInputParameter
    /// <summary>
    /// �õ��޸��û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetModifyInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������
        appData = RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateUserGroupID(UserGroupID.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupID = Convert.ToString(validateData.Value.ToString());
                UserGroupID_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupContent_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                UserGroupRemark_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                DefaultPage_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
    /// ��ʼ����������
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }


    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// ��ʼ���Զ������
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // ���������ر���Ϣ

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// ��ʼ���������ģ��
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// ��ر�������ദ��
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
    /// ��ر��������
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// ��ر������޸�
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

