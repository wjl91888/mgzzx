using System;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.BM.T_PM_UserInfo;

public partial class ForgetPassword : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
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
            Password_Area.Visible = false;
            btnChangePassword.Visible = false;
            btnSendChangePasswordEmail.Visible = false;
            // ��ʼ������
            Password.TextMode = TextBoxMode.Password;
            PasswordConfirm.TextMode = TextBoxMode.Password;
            // ����ؼ�״̬
            ObjectID_Area.Visible = false;

            var vcode = Request.QueryString["vcode"];
            if (vcode.IsHtmlNullOrWiteSpace() || !DataValidateManager.ValidateUniqueIdentifierFormat(vcode))
            {
                UserLoginName.Text = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME].Value);
                Password_Area.Visible = false;
                btnChangePassword.Visible = false;
                btnSendChangePasswordEmail.Visible = true;
            }
            else
            {
                T_PM_UserInfoApplicationLogic userInfoApplicationLogic = new T_PM_UserInfoApplicationLogic();
                appData = new T_PM_UserInfoApplicationData();
                appData.vcode = vcode;
                appData.CurrentPage = 1;
                appData.PageSize = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                userInfoApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                    UserLoginName.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserLoginName"]);
                    UserLoginName.Enabled = false;
                    Password_Area.Visible = true;
                    btnChangePassword.Visible = true;
                    btnSendChangePasswordEmail.Visible = false;
                    MessageContent = "���޸����롣";
                }
                else
                {
                    Password_Area.Visible = false;
                    btnChangePassword.Visible = false;
                    btnSendChangePasswordEmail.Visible = true;
                    MessageContent = "�޸����������ѹ��ڣ��������ύ��";
                }
            }
        }
        base.Page_Load(sender, e);
    }

    protected void btnSendChangePasswordEmail_Click(object sender, EventArgs e)
    {
        bool boolReturn = true;
        ValidateData validateData = new ValidateData();
        T_PM_UserInfoApplicationLogic userInfoApplicationLogic = new T_PM_UserInfoApplicationLogic();
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
                    existAppData = userInfoApplicationLogic.Query(existAppData);
                    if (existAppData.RecordCount == 0)
                    {
                        validateData.Message = "��¼�û��������ڣ�������ٴ��ύ��";
                        UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
                        MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                        boolReturn = false;
                    }
                    else
                    {
                        appData = T_PM_UserInfoBusinessEntity.GetDataByObjectID(((Guid)existAppData.ResultSet.Tables[0].Rows[0]["ObjectID"]).ToString());
                        if (appData != null)
                        {
                            appData.vcode = Guid.NewGuid().ToString();
                            appData.OPCode = ApplicationDataBase.OPType.ID;
                            userInfoApplicationLogic.Modify(appData);

                            // ����Email
                            SendChangePasswordMail(appData.UserLoginName, appData.UserNickName, DomainUrl, appData.vcode);
                            MessageContent += "�޸����������ѷ��͵��������䣬�������䲢���������޸ġ�";
                            btnSendChangePasswordEmail.Enabled = false;
                            Page.CloseWindow(true);
                        }
                    }
                }
                else
                {
                    validateData.Message = "��¼�û�����ʽ����";
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

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        bool boolReturn = true;
        ValidateData validateData = new ValidateData();
        appData = T_PM_UserInfoBusinessEntity.GetDataByObjectID(ObjectID.Text);
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
        if (boolReturn)
        {
            T_PM_UserInfoApplicationLogic userInfoApplicationLogic = new T_PM_UserInfoApplicationLogic();
            appData.vcode = null;
            appData.OPCode = ApplicationDataBase.OPType.ID;
            userInfoApplicationLogic.Modify(appData);
            Response.Redirect("login.aspx");
        }
    }
}

