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
            appData = new T_PM_UserGroupInfoApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
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
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserGroupID = Convert.ToString(validateData.Value.ToString());
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

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_PM_UserGroupInfo", dt, true, true);
        T_PM_UserGroupInfoApplicationLogic instanceT_PM_UserGroupInfoApplicationLogic = (T_PM_UserGroupInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserGroupInfoApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_PM_UserGroupInfoApplicationData();

            int i = 0;

            appData = instanceT_PM_UserGroupInfoApplicationLogic.Add(appData);
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
            var appDatas = T_PM_UserGroupInfoApplicationData.GetDataFromDataFile<T_PM_UserGroupInfoApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_PM_UserGroupInfoContants.ImportDataSetStartLineNum);
            T_PM_UserGroupInfoApplicationLogic instanceT_PM_UserGroupInfoApplicationLogic = (T_PM_UserGroupInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserGroupInfoApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                if(!UserGroupID.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserGroupID =  Convert.ToString(UserGroupID.Text);
                }
    
                if(!UserGroupName.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserGroupName =  Convert.ToString(UserGroupName.Text);
                }
    
                if(!UserGroupContent.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserGroupContent =  Convert.ToString(UserGroupContent.Text);
                }
    
                if(!UserGroupRemark.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserGroupRemark =  Convert.ToString(UserGroupRemark.Text);
                }
    
                if(!DefaultPage.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DefaultPage =  Convert.ToString(DefaultPage.Text);
                }
    
                app.UpdateDate = DateTime.Now;
                instanceT_PM_UserGroupInfoApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_PM_UserGroupInfoApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">��{0}�����ݣ���������{1}������������{2}����</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">�������ݹ��̳���{0}<br/>��{1}�����ݣ��ѵ�������{2}�����Ѹ�������{3}����</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
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
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      UserGroupID_Area.Visible = false;
      UserGroupID_Area.Visible = true;
      UserGroupName_Area.Visible = false;
      UserGroupName_Area.Visible = true;
      UserGroupContent_Area.Visible = false;
      UserGroupContent_Area.Visible = true;
      UserGroupRemark_Area.Visible = false;
      UserGroupRemark_Area.Visible = true;
      DefaultPage_Area.Visible = false;
      DefaultPage_Area.Visible = true;
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
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_PM_UserGroupInfoApplicationData();
    
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

