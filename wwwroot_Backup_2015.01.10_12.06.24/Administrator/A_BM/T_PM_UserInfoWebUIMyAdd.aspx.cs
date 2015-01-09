/****************************************************** 
FileName:T_PM_UserInfoWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_PM_UserInfo;

public partial class T_PM_UserInfoWebUIMyAdd : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
{
    private bool editMode = false;
    private bool EditMode
    {
        get
        {
            if (!editMode)
            {
                appData = new T_PM_UserInfoApplicationData();
                appData.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];
                appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                QueryRecord();
                if (appData.RecordCount > 0)
                {
                    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                    editMode = true;
                }
                else
                {
                    editMode = false;
                }
            }
            return editMode;
        }
    }
    private bool CopyMode
    {
        get
        {
            if (!DataValidateManager.ValidateIsNull(Request.QueryString["action"]))
            {
                return Request.QueryString["action"].Equals("copy", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
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

    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        // ����SESSION��ֵ
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_MYADD_FILENAME;
        Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_MYADD_ACCESS_PURVIEW_ID;
        base.Page_Load(sender, e);
        MessageContent = string.Empty;
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
        UserGroupID.RepeatColumns = 3; Password.TextMode = TextBoxMode.Password;
        PasswordConfirm.TextMode = TextBoxMode.Password;

        // ����ؼ�״̬

        if (EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_PM_UserInfoApplicationData();
            appData.ObjectID = ObjectID.Text;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
                UserID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserID"]);
                UserLoginName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserLoginName"]);
                UserGroupID.SelectedValues = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupID"]);
                SubjectID.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SubjectID"]);
                UserNickName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserNickName"]);
                LoginTime.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LoginTime"]);
                LastLoginIP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LastLoginIP"]);
                LastLoginDate.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LastLoginDate"]);
                LoginTimes.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LoginTimes"]);

            }
        }
        if (EditMode)
        {
            ObjectID_Area.Visible = false;
            ObjectID_Area.Visible = false;
            UserID.Enabled = false;
            LoginTime.Enabled = false;
            LastLoginIP.Enabled = false;
            LastLoginDate.Enabled = false;
            LoginTimes.Enabled = false;

        }
        else
        {
            if (!CopyMode)
            {
                // ��ʼ���������

                // ��ʼ��Ĭ��ֵ

            }
            ObjectID_Area.Visible = false;
            UserID_Area.Visible = false;
            LoginTime_Area.Visible = false;
            LastLoginIP_Area.Visible = false;
            LastLoginDate_Area.Visible = false;
            LoginTimes_Area.Visible = false;

        }
        UserGroupID_Area.Visible = false;
        LoginTime_Area.Visible = false;
        LastLoginIP_Area.Visible = false;
        LastLoginDate_Area.Visible = false;
        LoginTimes_Area.Visible = false;
        UserID.Enabled = false;
        UserLoginName.Enabled = false;
        UserGroupID.Enabled = false;
        SubjectID.Enabled = false;
        UserNickName.Enabled = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (EditMode)
        {
            btnModifyConfirm_Click(sender, e);
        }
        else
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

        // ��ʼ���û���(UserGroupID)�����б�
        UserGroupID.DataSource = GetDataSource_UserGroupID();
        UserGroupID.DataTextField = "UserGroupName";
        UserGroupID.DataValueField = "UserGroupID";
        UserGroupID.DataBind();

        // ��ʼ��������λ(SubjectID)�����б�
        SubjectID.DataSource = GetDataSource_SubjectID();
        SubjectID.DataTextField = "DWMC";
        SubjectID.DataValueField = "DWBH";
        SubjectID.DataBind();

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

        validateData = ValidateUserLoginName(UserLoginName.Text, false, false);
        if (validateData.Result == true)
        {
            if (validateData.IsNull == false)
            {
                appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
                UserLoginName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            UserLoginName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateUserGroupID(UserGroupID.SelectedValues, false, false);
        if (validateData.Result == true)
        {
            if (validateData.IsNull == false)
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

        validateData = ValidateSubjectID(SubjectID.SelectedValue, false, false);
        if (validateData.Result == true)
        {
            if (validateData.IsNull == false)
            {
                appData.SubjectID = Convert.ToString(validateData.Value.ToString());
                SubjectID_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            SubjectID.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SubjectID.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateUserNickName(UserNickName.Text, false, false);
        if (validateData.Result == true)
        {
            if (validateData.IsNull == false)
            {
                appData.UserNickName = Convert.ToString(validateData.Value.ToString());
                UserNickName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            UserNickName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserNickName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        if (Password.Text == PasswordConfirm.Text)
        {
            validateData = ValidatePassword(Password.Text, false, false);
            if (validateData.Result == true)
            {
                if (validateData.IsNull == false)
                {
                    appData.Password = RICH.Common.SecurityManager.MD5(Convert.ToString(validateData.Value.ToString()), 32);
                    Password_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
                }
                Password.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Password.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
        }
        else
        {
            Password.BackColor = System.Drawing.Color.YellowGreen;
            PasswordConfirm.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">�������벻һ�£����������롣</font>";
            boolReturn = false;
        }

        // �Զ����ɱ��
        T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
        appData.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(appData);

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
        appData = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateUserID(UserID.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserID = Convert.ToString(validateData.Value.ToString());
                UserID_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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

        validateData = ValidateUserLoginName(UserLoginName.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
                UserLoginName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }

            else
            {
                appData.UserLoginName = null;
            }
            UserLoginName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateUserGroupID(UserGroupID.SelectedValues, false, false);
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

        validateData = ValidateSubjectID(SubjectID.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SubjectID = Convert.ToString(validateData.Value.ToString());
                SubjectID_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }

            else
            {
                appData.SubjectID = null;
            }
            SubjectID.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SubjectID.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateUserNickName(UserNickName.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserNickName = Convert.ToString(validateData.Value.ToString());
                UserNickName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }

            else
            {
                appData.UserNickName = null;
            }
            UserNickName.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserNickName.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        if (Password.Text == PasswordConfirm.Text)
        {
            validateData = ValidatePassword(Password.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.Password = RICH.Common.SecurityManager.MD5(Convert.ToString(validateData.Value.ToString()), 32);
                    Password_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
                }
                Password.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Password.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
        }
        else
        {
            Password.BackColor = System.Drawing.Color.YellowGreen;
            PasswordConfirm.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">�������벻һ�£����������롣</font>";
            boolReturn = false;
        }

        validateData = ValidateLoginTime(LoginTime.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LoginTime = Convert.ToDateTime(validateData.Value.ToString());
                LoginTime_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            LoginTime.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LoginTime.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateLastLoginIP(LastLoginIP.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LastLoginIP = Convert.ToString(validateData.Value.ToString());
                LastLoginIP_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }

            else
            {
                appData.LastLoginIP = null;
            }
            LastLoginIP.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LastLoginIP.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateLastLoginDate(LastLoginDate.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LastLoginDate = Convert.ToDateTime(validateData.Value.ToString());
                LastLoginDate_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            LastLoginDate.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LastLoginDate.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

        validateData = ValidateLoginTimes(LoginTimes.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LoginTimes = Convert.ToInt32(validateData.Value.ToString());
                LoginTimes_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            LoginTimes.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LoginTimes.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }

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


}

