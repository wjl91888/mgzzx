/****************************************************** 
FileName:T_PM_UserInfoWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_PM_UserInfoWebUIAdd : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }

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
            }
            else
            {
                // 初始化耦合绑定数据
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 初始化界面
    UserGroupID.RepeatColumns = 1;Password.TextMode = TextBoxMode.Password;
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
            appData = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetDataByObjectID(base.ObjectID);
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

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          UserID.Enabled = false;
                    LoginTimeContainer.Visible = false;
          LastLoginIPContainer.Visible = false;
          LastLoginDateContainer.Visible = false;
          LoginTimesContainer.Visible = false;
          lcodeContainer.Visible = false;
          
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          UserIDContainer.Visible = false;
          LoginTimeContainer.Visible = false;
          LastLoginIPContainer.Visible = false;
          LastLoginDateContainer.Visible = false;
          LoginTimesContainer.Visible = false;
          lcodeContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          UserIDContainer.Visible = false;
          UserLoginNameContainer.Visible = false;
          UserLoginNameContainer.Visible = true;
          UserGroupIDContainer.Visible = false;
          UserGroupIDContainer.Visible = true;
          SubjectIDContainer.Visible = false;
          SubjectIDContainer.Visible = true;
          UserNickNameContainer.Visible = false;
          UserNickNameContainer.Visible = true;
          PasswordContainer.Visible = false;
          PasswordContainer.Visible = true;
          XBContainer.Visible = false;
          XBContainer.Visible = true;
          MZContainer.Visible = false;
          MZContainer.Visible = true;
          ZZMMContainer.Visible = false;
          ZZMMContainer.Visible = true;
          SFZHContainer.Visible = false;
          SFZHContainer.Visible = true;
          SJHContainer.Visible = false;
          SJHContainer.Visible = true;
          BGDHContainer.Visible = false;
          BGDHContainer.Visible = true;
          JTDHContainer.Visible = false;
          JTDHContainer.Visible = true;
          EmailContainer.Visible = false;
          EmailContainer.Visible = true;
          QQHContainer.Visible = false;
          QQHContainer.Visible = true;
          LoginTimeContainer.Visible = false;
          LastLoginIPContainer.Visible = false;
          LastLoginDateContainer.Visible = false;
          LoginTimesContainer.Visible = false;
          UserStatusContainer.Visible = false;
          UserStatusContainer.Visible = true;
          vcodeContainer.Visible = false;
          vcodeContainer.Visible = true;
          lcodeContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
                    PasswordContainer.Visible = false;
          JTDH.Enabled = false;
                    Email.Enabled = false;
                    UserStatus.Enabled = false;
                    UserStatusContainer.Visible = false;
          QQH.Enabled = false;
                    vcode.Enabled = false;
                    vcodeContainer.Visible = false;
          lcode.Enabled = false;
                    lcodeContainer.Visible = false;
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
                    LoginTimeContainer.Visible = false;
                  }
                    if(CustomPermission == GRZL_PURVIEW_ID)
                    {
                    LastLoginIPContainer.Visible = false;
                  }
                    if(CustomPermission == GRZL_PURVIEW_ID)
                    {
                    LastLoginDateContainer.Visible = false;
                  }
                    if(CustomPermission == GRZL_PURVIEW_ID)
                    {
                    LoginTimesContainer.Visible = false;
                  }
                    if(CustomPermission == GRZL_PURVIEW_ID)
                    {
                    UserStatusContainer.Visible = false;
                  }
                    if(CustomPermission == GRZL_PURVIEW_ID)
                    {
                    vcodeContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    UserIDContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    UserID.Enabled = false;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    UserLoginNameContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    UserGroupIDContainer.Visible = false;
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
                    SFZHContainer.Visible = false;
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
                    LoginTimeContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    LastLoginIPContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    LastLoginDateContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    LoginTimesContainer.Visible = false;
                  }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                    UserStatusContainer.Visible = false;
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
}

