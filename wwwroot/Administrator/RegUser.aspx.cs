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
using RICH.Common.Base.ApplicationData;
using RICH.Common.LM;
using RICH.Common.BM.T_PM_UserInfo;

public partial class RegUser : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
{
    public override bool NeedLogin
    {
        get { return false; }
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
        MessageContent = string.Empty;
        if (IsPostBack != true)
        {
            // ��ʼ��������
            InitalizeDataBind();
            // ȫ�ֳ�ʼ��
            Initalize();
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
        Password.TextMode = TextBoxMode.Password;
        PasswordConfirm.TextMode = TextBoxMode.Password;
        // ����ؼ�״̬
        ObjectID_Area.Visible = false;
        UserID_Area.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnAddConfirm_Click(sender, e);
    }

    //=====================================================================
    //  FunctionName : AddRecord
    /// <summary>
    /// ��Ӽ�¼����
    /// </summary>
    //=====================================================================
    protected override void AddRecord()
    {
        if (GetAddInputParameter())
        {
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            // �������
            appData = instanceT_PM_UserInfoApplicationLogic.Add(appData);
            // ���������ر�
            RelatedTableAddBatch();
            if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
            {

                // �Գɹ���Ϣ���д���
                strMessageParam[0] = "�û���Ϣ";
                strMessageParam[1] = "���";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
                MessageContent = strMessageInfo;

                // ��¼��־��ʼ
                string strLogTypeID = "A02";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "�û���Ϣ";
                strMessageParam[2] = appData.UserLoginName.ToString();
                strMessageParam[3] = "���";
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // ��¼��־����

                // ����Email
                SendValidateMail(appData.UserLoginName, appData.UserNickName, DomainUrl, appData.vcode);

                // �ɹ���ҳ����ת
                Page.CloseWindow(true);
            }
            else
            {
                // ��ʧ����Ϣ���д���
                strMessageParam[0] = "�˱��";
                strMessageParam[1] = "�û���Ϣ";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, strMessageParam, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
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
        T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
        ValidateData validateData = new ValidateData();
        // ��֤�������
        validateData = ValidateUserLoginName(UserLoginName.Text, false, false);
        if (validateData.Result)
        {
            UserLoginName.BackColor = System.Drawing.Color.Empty;
            if (!validateData.IsNull)
            {
                if (UserLoginName.Text.IsValidEmail())
                {
                    T_PM_UserInfoApplicationData existAppData = new T_PM_UserInfoApplicationData();
                    existAppData.UserLoginName = UserLoginName.Text.HtmlDecodeWithTrim();
                    existAppData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                    existAppData.PageSize = 1;
                    existAppData.CurrentPage = 1;
                    existAppData = instanceT_PM_UserInfoApplicationLogic.Query(existAppData);
                    if (existAppData.RecordCount == 0)
                    {
                        appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
                        UserLoginName_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
                    }
                    else
                    {
                        validateData.Message = "��¼�û����Ѵ��ڣ���������ٴ��ύ��";
                        UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
                        MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                        boolReturn = false;
                    }
                }
                else
                {
                    validateData.Message = "��¼����ʽ����";
                    UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
                    MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                    boolReturn = false;
                }
            }
        }
        else
        {
            UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
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
            MessageContent += @"<font color=""red"">�����������벻һ�£����������롣</font>";
            boolReturn = false;
        }

        // �Զ����ɱ��
        appData.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(appData);
        appData.UserGroupID = ConstantsManager.DEFAULT_REGISTER_USERGROUPID;
        appData.vcode = Guid.NewGuid().ToString();
        appData.UserStatus = "01";
        return boolReturn;
    }
}

