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
            // 初始化绑定数据
            InitalizeDataBind();
            // 全局初始化
            Initalize();
        }
        base.Page_Load(sender, e);
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
        Password.TextMode = TextBoxMode.Password;
        PasswordConfirm.TextMode = TextBoxMode.Password;
        // 界面控件状态
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
    /// 添加记录操作
    /// </summary>
    //=====================================================================
    protected override void AddRecord()
    {
        if (GetAddInputParameter())
        {
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            // 添加主表
            appData = instanceT_PM_UserInfoApplicationLogic.Add(appData);
            // 批量添加相关表
            RelatedTableAddBatch();
            if (appData.ResultCode == ApplicationDataBase.ResultState.Succeed)
            {

                // 对成功消息进行处理
                strMessageParam[0] = "用户信息";
                strMessageParam[1] = "添加";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
                MessageContent = strMessageInfo;

                // 记录日志开始
                string strLogTypeID = "A02";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "用户信息";
                strMessageParam[2] = appData.UserLoginName.ToString();
                strMessageParam[3] = "添加";
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                // 记录日志结束

                // 发送Email
                SendValidateMail(appData.UserLoginName, appData.UserNickName, DomainUrl, appData.vcode);

                // 成功后页面跳转
                Page.CloseWindow(true);
            }
            else
            {
                // 对失败消息进行处理
                strMessageParam[0] = "此编号";
                strMessageParam[1] = "用户信息";
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0013, strMessageParam, strMessageInfo);
                MessageContent = strMessageInfo;
                Session[ConstantsManager.SESSION_MESSAGE_TYPE] = "FaildPre";
            }
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
        // 初始化所属单位(SubjectID)下拉列表
        SubjectID.DataSource = GetDataSource_SubjectID();
        SubjectID.DataTextField = "DWMC";
        SubjectID.DataValueField = "DWBH";
        SubjectID.DataBind();
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
        T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
                    = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
        ValidateData validateData = new ValidateData();
        // 验证输入参数
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
                        UserLoginName_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
                    }
                    else
                    {
                        validateData.Message = "登录用户名已存在，请更换后再次提交。";
                        UserLoginName.BackColor = System.Drawing.Color.YellowGreen;
                        MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                        boolReturn = false;
                    }
                }
                else
                {
                    validateData.Message = "登录名格式错误。";
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
                SubjectID_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
                UserNickName_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
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
            MessageContent += @"<font color=""red"">两次密码输入不一致，请重新输入。</font>";
            boolReturn = false;
        }

        // 自动生成编号
        appData.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(appData);
        appData.UserGroupID = ConstantsManager.DEFAULT_REGISTER_USERGROUPID;
        appData.vcode = Guid.NewGuid().ToString();
        appData.UserStatus = "01";
        return boolReturn;
    }
}

