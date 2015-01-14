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

public partial class T_PM_UserInfoWebUIAdd : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
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
UserGroupID.RepeatColumns = 3;Password.TextMode = TextBoxMode.Password;
        PasswordConfirm.TextMode = TextBoxMode.Password;

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_PM_UserInfoApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    UserID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserID"]); 
                    UserLoginName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserLoginName"]); 
                    UserGroupID.SelectedValues = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserGroupID"]); 
                    SubjectID.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SubjectID"]); 
                    UserNickName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserNickName"]); 
                    XB.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["XB"]); 
                    MZ.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["MZ"]); 
                    ZZMM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["ZZMM"]); 
                    SFZH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFZH"]); 
                    SJH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJH"]); 
                    BGDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGDH"]); 
                    JTDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JTDH"]); 
                    Email.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["Email"]); 
                    QQH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["QQH"]); 
                    LoginTime.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LoginTime"]); 
                    LastLoginIP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LastLoginIP"]); 
                    LastLoginDate.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LastLoginDate"]); 
                    LoginTimes.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LoginTimes"]); 
                    UserStatus.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserStatus"]); 
                    vcode.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["vcode"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

                // ��ʼ��Ĭ��ֵ
UserStatus.SelectedValue = "02"; 

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
        
        // ��ʼ���Ա�(XB)�����б�
          XB.DataSource = GetDataSource_XB();
        XB.DataTextField = "MC";
        XB.DataValueField = "DM";
              XB.DataBind();
        
        // ��ʼ������(MZ)�����б�
          MZ.DataSource = GetDataSource_MZ();
        MZ.DataTextField = "MC";
        MZ.DataValueField = "DM";
              MZ.DataBind();
        
        // ��ʼ��������ò(ZZMM)�����б�
          ZZMM.DataSource = GetDataSource_ZZMM();
        ZZMM.DataTextField = "MC";
        ZZMM.DataValueField = "DM";
              ZZMM.DataBind();
        
        // ��ʼ���û�״̬(UserStatus)�����б�
          UserStatus.DataSource = GetDataSource_UserStatus();
        UserStatus.DataTextField = "MC";
        UserStatus.DataValueField = "DM";
              UserStatus.DataBind();
        
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
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
                
        validateData = ValidateSubjectID(SubjectID.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
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
            
        validateData = ValidateXB(XB.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
                XB_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            XB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateMZ(MZ.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.MZ = Convert.ToString(validateData.Value.ToString());
                MZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            MZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZZMM(ZZMM.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.ZZMM = Convert.ToString(validateData.Value.ToString());
                ZZMM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            ZZMM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZZMM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFZH(SFZH.Text, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SFZH = Convert.ToString(validateData.Value.ToString());
                SFZH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            SFZH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFZH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJH(SJH.Text, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.SJH = Convert.ToString(validateData.Value.ToString());
                SJH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            SJH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBGDH(BGDH.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.BGDH = Convert.ToString(validateData.Value.ToString());
                BGDH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            BGDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJTDH(JTDH.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.JTDH = Convert.ToString(validateData.Value.ToString());
                JTDH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            JTDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JTDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateEmail(Email.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.Email = Convert.ToString(validateData.Value.ToString());
                Email_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            Email.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            Email.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateQQH(QQH.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.QQH = Convert.ToString(validateData.Value.ToString());
                QQH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            QQH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QQH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserStatus(UserStatus.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.UserStatus = Convert.ToString(validateData.Value.ToString());
                UserStatus_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            UserStatus.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserStatus.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = Validatevcode(vcode.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.vcode = Convert.ToString(validateData.Value.ToString());
                vcode_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            vcode.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            vcode.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
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
        
        validateData = ValidateXB(XB.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
                XB_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.XB = null;
            }
            XB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateMZ(MZ.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.MZ = Convert.ToString(validateData.Value.ToString());
                MZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.MZ = null;
            }
            MZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZZMM(ZZMM.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.ZZMM = Convert.ToString(validateData.Value.ToString());
                ZZMM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.ZZMM = null;
            }
            ZZMM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZZMM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFZH(SFZH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SFZH = Convert.ToString(validateData.Value.ToString());
                SFZH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.SFZH = null;
            }
            SFZH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFZH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJH(SJH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJH = Convert.ToString(validateData.Value.ToString());
                SJH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.SJH = null;
            }
            SJH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBGDH(BGDH.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BGDH = Convert.ToString(validateData.Value.ToString());
                BGDH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.BGDH = null;
            }
            BGDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BGDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJTDH(JTDH.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JTDH = Convert.ToString(validateData.Value.ToString());
                JTDH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.JTDH = null;
            }
            JTDH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JTDH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateEmail(Email.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.Email = Convert.ToString(validateData.Value.ToString());
                Email_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                
        validateData = ValidateQQH(QQH.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.QQH = Convert.ToString(validateData.Value.ToString());
                QQH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.QQH = null;
            }
            QQH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QQH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateUserStatus(UserStatus.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserStatus = Convert.ToString(validateData.Value.ToString());
                UserStatus_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.UserStatus = null;
            }
            UserStatus.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            UserStatus.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = Validatevcode(vcode.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.vcode = Convert.ToString(validateData.Value.ToString());
                vcode_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.vcode = null;
            }
            vcode.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            vcode.BackColor = System.Drawing.Color.YellowGreen;
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

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_PM_UserInfo", dt, true, true);
        T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_PM_UserInfoApplicationData();

            appData.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(appData);
                
            int i = 0;

            appData = instanceT_PM_UserInfoApplicationLogic.Add(appData);
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
        try
        {
            var appDatas = T_PM_UserInfoApplicationData.GetDataFromDataFile<T_PM_UserInfoApplicationData>(InfoFromDoc.Text, true);
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            foreach (var app in appDatas)
            {
    
                app.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(app);
                    
                string strUserGroupID = GetValue(new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationLogicBase().GetValueByFixCondition("UserGroupName", app.UserGroupID, "UserGroupID"));
                if (!DataValidateManager.ValidateIsNull(strUserGroupID))app.UserGroupID = strUserGroupID;
                string strSubjectID = GetValue(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogicBase().GetValueByFixCondition("DWMC", app.SubjectID, "DWBH"));
                if (!DataValidateManager.ValidateIsNull(strSubjectID))app.SubjectID = strSubjectID;
                string strXB = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.XB, "DM"));
                if (!DataValidateManager.ValidateIsNull(strXB))app.XB = strXB;
                string strMZ = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.MZ, "DM"));
                if (!DataValidateManager.ValidateIsNull(strMZ))app.MZ = strMZ;
                string strZZMM = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.ZZMM, "DM"));
                if (!DataValidateManager.ValidateIsNull(strZZMM))app.ZZMM = strZZMM;
                string strUserStatus = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.UserStatus, "DM"));
                if (!DataValidateManager.ValidateIsNull(strUserStatus))app.UserStatus = strUserStatus;
                instanceT_PM_UserInfoApplicationLogic.Add(app);
            }
            MessageContent += @"<font color=""green"">��������{0}��</font>".FormatInvariantCulture(appDatas.Count);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">�������ݹ��̳���{0}</font>".FormatInvariantCulture(ex.Message);
        }
    }

    public void CheckPermission()
    {
        if (AccessPermission)
        {
            if(EditMode)
            {
    ObjectID_Area.Visible = false;
      UserID.Enabled = false;
                LoginTime_Area.Visible = false;
      LastLoginIP_Area.Visible = false;
      LastLoginDate_Area.Visible = false;
      LoginTimes_Area.Visible = false;
      
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      UserID_Area.Visible = false;
      LoginTime_Area.Visible = false;
      LastLoginIP_Area.Visible = false;
      LastLoginDate_Area.Visible = false;
      LoginTimes_Area.Visible = false;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      UserID.Enabled = false;
                UserLoginName.Enabled = false;
                UserGroupID.Enabled = false;
                SubjectID.Enabled = false;
                XB.Enabled = false;
                SFZH.Enabled = false;
                UserNickName.Enabled = false;
                MZ.Enabled = false;
                SJH.Enabled = false;
                ZZMM.Enabled = false;
                BGDH.Enabled = false;
                Password.Enabled = false;
                Password_Area.Visible = false;
      JTDH.Enabled = false;
                Email.Enabled = false;
                UserStatus.Enabled = false;
                UserStatus_Area.Visible = false;
      QQH.Enabled = false;
                vcode.Enabled = false;
                vcode_Area.Visible = false;
      LoginTime.Enabled = false;
                LastLoginIP.Enabled = false;
                LastLoginDate.Enabled = false;
                LoginTimes.Enabled = false;
                
      btnAddConfirm.Visible = false;
    
            }
            else
            {
      btnEditItem.Visible = false;
    
            }
        }
        else
        {
            ImportControlContainer.Visible = false;
            ControlContainer.Visible = false;
            btnAddConfirm.Visible = false;
        
            btnInfoFromDS.Visible = false;
            btnInfoFromDoc.Visible = false;
            btnInfoFromDocBatch.Visible = false;
            btnInfoFromDocCancel.Visible = false;
        }
    }
}

