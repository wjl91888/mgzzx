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
            // 初始化界面
            Password.TextMode = TextBoxMode.Password;
            PasswordConfirm.TextMode = TextBoxMode.Password;
            // 界面控件状态
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
                    MessageContent = "请修改密码。";
                }
                else
                {
                    Password_Area.Visible = false;
                    btnChangePassword.Visible = false;
                    btnSendChangePasswordEmail.Visible = true;
                    MessageContent = "修改密码链接已过期，请重新提交。";
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
                        validateData.Message = "登录用户名不存在，请检查后再次提交。";
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

                            // 发送Email
                            SendChangePasswordMail(appData.UserLoginName, appData.UserNickName, DomainUrl, appData.vcode);
                            MessageContent += "修改密码链接已发送到您的邮箱，请检查邮箱并进行密码修改。";
                            btnSendChangePasswordEmail.Enabled = false;
                            Page.CloseWindow(true);
                        }
                    }
                }
                else
                {
                    validateData.Message = "登录用户名格式错误。";
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
                    Password_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
            MessageContent += @"<font color=""red"">两次输入不一致，请重新输入。</font>";
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

