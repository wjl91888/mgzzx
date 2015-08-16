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
UserGroupID.RepeatColumns = 3;Password.TextMode = TextBoxMode.Password;
        PasswordConfirm.TextMode = TextBoxMode.Password;

        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_PM_UserInfoApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
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
                    lcode.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["lcode"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                // 初始化默认值
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
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // 初始化用户组(UserGroupID)下拉列表
          UserGroupID.DataSource = GetDataSource_UserGroupID();
        UserGroupID.DataTextField = "UserGroupName";
        UserGroupID.DataValueField = "UserGroupID";
              UserGroupID.DataBind();
        
        // 初始化所属单位(SubjectID)下拉列表
          SubjectID.DataSource = GetDataSource_SubjectID();
        SubjectID.DataTextField = "DWMC";
        SubjectID.DataValueField = "DWBH";
              SubjectID.DataBind();
        
        // 初始化性别(XB)下拉列表
          XB.DataSource = GetDataSource_XB();
        XB.DataTextField = "MC";
        XB.DataValueField = "DM";
              XB.DataBind();
        
        // 初始化民族(MZ)下拉列表
          MZ.DataSource = GetDataSource_MZ();
        MZ.DataTextField = "MC";
        MZ.DataValueField = "DM";
              MZ.DataBind();
        
        // 初始化政治面貌(ZZMM)下拉列表
          ZZMM.DataSource = GetDataSource_ZZMM();
        ZZMM.DataTextField = "MC";
        ZZMM.DataValueField = "DM";
              ZZMM.DataBind();
        
        // 初始化用户状态(UserStatus)下拉列表
          UserStatus.DataSource = GetDataSource_UserStatus();
        UserStatus.DataTextField = "MC";
        UserStatus.DataValueField = "DM";
              UserStatus.DataBind();
        
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

        validateData = ValidateUserLoginName(UserLoginName.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
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
            
        validateData = ValidateXB(XB.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
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
            }
            vcode.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            vcode.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        // 自动生成编号
T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic
            = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
        appData.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(appData);
                
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
        appData = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateUserID(UserID.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.UserID = Convert.ToString(validateData.Value.ToString());
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
        
        validateData = ValidateXB(XB.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
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
        int totalCount = 0;
        int importCount = 0;
        int updateCount = 0;
        try
        {
            var appDatas = T_PM_UserInfoApplicationData.GetDataFromDataFile<T_PM_UserInfoApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_PM_UserInfoContants.ImportDataSetStartLineNum);
            T_PM_UserInfoApplicationLogic instanceT_PM_UserInfoApplicationLogic = (T_PM_UserInfoApplicationLogic)CreateApplicationLogicInstance(typeof(T_PM_UserInfoApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.UserID = instanceT_PM_UserInfoApplicationLogic.AutoGenerateUserID(app);
                    
                if(!UserLoginName.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserLoginName =  Convert.ToString(UserLoginName.Text);
                }
    
                string strUserGroupID = GetValue(new RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoApplicationLogicBase().GetValueByFixCondition("UserGroupName", app.UserGroupID, "UserGroupID"));
                if (!DataValidateManager.ValidateIsNull(strUserGroupID))app.UserGroupID = strUserGroupID;
                if(!UserGroupID.SelectedValues.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserGroupID =  Convert.ToString(UserGroupID.SelectedValues);
                }
    
                string strSubjectID = GetValue(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogicBase().GetValueByFixCondition("DWMC", app.SubjectID, "DWBH"));
                if (!DataValidateManager.ValidateIsNull(strSubjectID))app.SubjectID = strSubjectID;
                if(!SubjectID.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SubjectID =  Convert.ToString(SubjectID.SelectedValue);
                }
    
                if(!UserNickName.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserNickName =  Convert.ToString(UserNickName.Text);
                }
    
                if(!Password.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.Password =  Convert.ToString(Password.Text);
                }
    
                string strXB = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.XB, "DM"));
                if (!DataValidateManager.ValidateIsNull(strXB))app.XB = strXB;
                if(!XB.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.XB =  Convert.ToString(XB.SelectedValue);
                }
    
                string strMZ = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.MZ, "DM"));
                if (!DataValidateManager.ValidateIsNull(strMZ))app.MZ = strMZ;
                if(!MZ.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.MZ =  Convert.ToString(MZ.SelectedValue);
                }
    
                string strZZMM = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.ZZMM, "DM"));
                if (!DataValidateManager.ValidateIsNull(strZZMM))app.ZZMM = strZZMM;
                if(!ZZMM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.ZZMM =  Convert.ToString(ZZMM.SelectedValue);
                }
    
                if(!SFZH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SFZH =  Convert.ToString(SFZH.Text);
                }
    
                if(!SJH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJH =  Convert.ToString(SJH.Text);
                }
    
                if(!BGDH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BGDH =  Convert.ToString(BGDH.Text);
                }
    
                if(!JTDH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.JTDH =  Convert.ToString(JTDH.Text);
                }
    
                if(!Email.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.Email =  Convert.ToString(Email.Text);
                }
    
                if(!QQH.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.QQH =  Convert.ToString(QQH.Text);
                }
    
                string strUserStatus = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.UserStatus, "DM"));
                if (!DataValidateManager.ValidateIsNull(strUserStatus))app.UserStatus = strUserStatus;
                if(!UserStatus.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.UserStatus =  Convert.ToString(UserStatus.SelectedValue);
                }
    
                if(!vcode.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.vcode =  Convert.ToString(vcode.Text);
                }
    
                instanceT_PM_UserInfoApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_PM_UserInfoApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">共{0}条数据，导入数据{1}条，更新数据{2}条。</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">导入数据过程出错：{0}<br/>共{1}条数据，已导入数据{2}条，已更新数据{3}条。</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
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
      lcode_Area.Visible = false;
      
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      UserID_Area.Visible = false;
      LoginTime_Area.Visible = false;
      LastLoginIP_Area.Visible = false;
      LastLoginDate_Area.Visible = false;
      LoginTimes_Area.Visible = false;
      lcode_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      UserID_Area.Visible = false;
      UserLoginName_Area.Visible = false;
      UserLoginName_Area.Visible = true;
      UserGroupID_Area.Visible = false;
      UserGroupID_Area.Visible = true;
      SubjectID_Area.Visible = false;
      SubjectID_Area.Visible = true;
      UserNickName_Area.Visible = false;
      UserNickName_Area.Visible = true;
      Password_Area.Visible = false;
      Password_Area.Visible = true;
      XB_Area.Visible = false;
      XB_Area.Visible = true;
      MZ_Area.Visible = false;
      MZ_Area.Visible = true;
      ZZMM_Area.Visible = false;
      ZZMM_Area.Visible = true;
      SFZH_Area.Visible = false;
      SFZH_Area.Visible = true;
      SJH_Area.Visible = false;
      SJH_Area.Visible = true;
      BGDH_Area.Visible = false;
      BGDH_Area.Visible = true;
      JTDH_Area.Visible = false;
      JTDH_Area.Visible = true;
      Email_Area.Visible = false;
      Email_Area.Visible = true;
      QQH_Area.Visible = false;
      QQH_Area.Visible = true;
      LoginTime_Area.Visible = false;
      LastLoginIP_Area.Visible = false;
      LastLoginDate_Area.Visible = false;
      LoginTimes_Area.Visible = false;
      UserStatus_Area.Visible = false;
      UserStatus_Area.Visible = true;
      vcode_Area.Visible = false;
      vcode_Area.Visible = true;
      lcode_Area.Visible = false;
      
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
      lcode.Enabled = false;
                lcode_Area.Visible = false;
      LoginTime.Enabled = false;
                LastLoginIP.Enabled = false;
                LastLoginDate.Enabled = false;
                LoginTimes.Enabled = false;
                
            }
    
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                UserID.Enabled = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                UserLoginName.Enabled = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                UserGroupID.Enabled = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                SFZH.Enabled = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                LoginTime_Area.Visible = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                LastLoginIP_Area.Visible = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                LastLoginDate_Area.Visible = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                LoginTimes_Area.Visible = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                UserStatus_Area.Visible = false;
                }
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                vcode_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserID_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserID.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserLoginName_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserGroupID_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                SubjectID.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserNickName.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                XB.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                SFZH_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                SJH.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                BGDH.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                JTDH.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                Email.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                QQH.Enabled = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                LoginTime_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                LastLoginIP_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                LastLoginDate_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                LoginTimes_Area.Visible = false;
                }
                if(CustomPermission == TXL_PURVIEW_ID)
                {
                UserStatus_Area.Visible = false;
                }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_PM_UserInfoApplicationData();
    
                if(CustomPermission == GRZL_PURVIEW_ID)
                {
                    appData.ObjectID = CurrentUserInfo.ObjectID;
                }
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

