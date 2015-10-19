using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;


public partial class Administrator_Login : Page
{
    #region 当前页面变量定义
    /// <summary>
    /// 输入参数HashTable
    /// </summary>
    private Hashtable htInputParameter;

    /// <summary>
    /// 输出参数HashTable
    /// </summary>
    private Hashtable htOutputParameter;

    /// <summary>
    /// 用来存储消息信息
    /// </summary>
    private string strMessageInfo = string.Empty;

    /// <summary>
    /// 用来存储消息信息的参数
    /// </summary>
    private string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_SAVE_LOGIN_STATUS])
            && !DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME])
            && !DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_PASSWORD]))
        {
            txtUserLoginName.Text = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME].Value);
            txtPassword.Text = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_PASSWORD].Value);
            chkSaveLoginStatus.Checked = true;
            ValidateUserLogin();
        }
        imgIdentifyCode.ImageUrl = ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Page/IdentifyCode.aspx";
        if (!IsPostBack)
        {
            var vcode = Request.QueryString["vcode"];
            if (vcode.IsHtmlNullOrWiteSpace() || !DataValidateManager.ValidateUniqueIdentifierFormat(vcode))
            {
                if (!DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME]))
                {
                    txtUserLoginName.Text = Server.UrlDecode(Request.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME].Value);
                }
            }
            else
            {
                T_PM_UserInfoApplicationLogic userInfoApplicationLogic = new T_PM_UserInfoApplicationLogic();
                T_PM_UserInfoApplicationData appData = new T_PM_UserInfoApplicationData();
                appData.vcode = vcode;
                appData.CurrentPage = 1;
                appData.PageSize = 1;
                appData.OPCode = ApplicationDataBase.OPType.ALL;
                userInfoApplicationLogic.Query(appData);
                if (appData.RecordCount > 0)
                {
                    appData = T_PM_UserInfoBusinessEntity.GetDataByObjectID(((Guid)appData.ResultSet.Tables[0].Rows[0]["ObjectID"]).ToString());
                    appData.UserStatus = "02";
                    appData.vcode = null;
                    appData.OPCode = ApplicationDataBase.OPType.ID;
                    userInfoApplicationLogic.Modify(appData);
                    txtUserLoginName.Text = appData.UserLoginName;
                    MessageLabel.Text = "邮箱通过验证，请登录开始使用系统。";
                }
                else
                {
                    MessageLabel.Text = "邮箱验证信息有误。";
                }
            }
        }
        txtIdentifyCode.Attributes.Add("onfocus", "document.getElementById('txtIdentifyCode').value = GetCookie('IdentifyCode');");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //if (txtIdentifyCode.Text == (string)Session[ConstantsManager.SESSION_IDENTIFY_CODE])
        //{
            ValidateUserLogin();
            //Session.Remove(ConstantsManager.SESSION_IDENTIFY_CODE);
            txtIdentifyCode.Text = "";
        //}
        //else
        //{
        //    //Session.Remove(ConstantsManager.SESSION_IDENTIFY_CODE);
        //    txtIdentifyCode.Text = "";
        //    strMessageInfo = MessageManager.GetMessageInfo(MessageManager.ERR_MSGID_0018, strMessageInfo);
        //    //对错误消息进行处理
        //    Session.Remove(ConstantsManager.SESSION_CURRENT_PURVIEW);
        //    MessageLabel.Text = strMessageInfo;
        //}
    }

    private void ValidateUserLogin()
    {
        htInputParameter = new Hashtable();
        htInputParameter.Add("UserLoginName", txtUserLoginName.Text);
        htInputParameter.Add("Password", txtPassword.Text);
        htInputParameter.Add("LastLoginIP", Request.ServerVariables["REMOTE_ADDR"]);
        htInputParameter.Add("lcodeFromUrl", Request.QueryString["lcode"]);
        htInputParameter.Add("UserID", null);
        htInputParameter.Add("UserGroupID", null);
        htInputParameter.Add("UserNickName", null);

        //对输入参数进行检验
        if (ValidateInputParameter() || !DataValidateManager.ValidateIsNull(Request.Cookies[ConstantsManager.COOKIE_SAVE_LOGIN_STATUS]))
        {
            if (((string)htInputParameter["Password"]).Length != 32)
            {
                htInputParameter["Password"] = SecurityManager.MD5(htInputParameter["Password"].ToString(), 32);
            }
            htOutputParameter = SystemValidateLibrary.ValidateUserLogin(htInputParameter);
            if (htOutputParameter[ConstantsManager.MESSAGE_ID] == DBNull.Value)
            {
                //初始化用户登录数据登录
                Session[ConstantsManager.SESSION_USER_ID] = htOutputParameter["UserID"].ToString();
                Session[ConstantsManager.SESSION_USER_GROUP_ID] = htOutputParameter["UserGroupID"].ToString();
                Session[ConstantsManager.SESSION_USER_LOGIN_NAME] = htOutputParameter["UserLoginName"].ToString();
                Session[ConstantsManager.SESSION_USER_NICK_NAME] = htOutputParameter["UserNickName"].ToString();
                Session[ConstantsManager.SESSION_SSDW_ID] = htOutputParameter["SubjectID"].ToString();
                Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_USER_ID, Server.UrlEncode(htOutputParameter["UserID"].ToString())));
                Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_USER_GROUP_ID, Server.UrlEncode(htOutputParameter["UserGroupID"].ToString())));
                Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_USER_LOGIN_NAME, Server.UrlEncode(htOutputParameter["UserLoginName"].ToString())));
                Response.Cookies[ConstantsManager.COOKIE_USER_LOGIN_NAME].Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_USER_NICK_NAME, Server.UrlEncode(htOutputParameter["UserNickName"].ToString())));
                Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_SSDW_ID, Server.UrlEncode(htOutputParameter["SubjectID"].ToString())));
                if (chkSaveLoginStatus.Checked)
                {
                    Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_PASSWORD, Server.UrlEncode((string)htInputParameter["Password"])));
                    Response.Cookies[ConstantsManager.COOKIE_PASSWORD].Expires = DateTime.Now.AddDays(180);
                    Response.Cookies.Add(new HttpCookie(ConstantsManager.COOKIE_SAVE_LOGIN_STATUS, Server.UrlEncode("true")));
                    Response.Cookies[ConstantsManager.COOKIE_SAVE_LOGIN_STATUS].Expires = DateTime.Now.AddDays(180);
                }
                //得到登录成功消息
                strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0001, strMessageInfo);

                //记录日志开始
                string strLogTypeID = "A01";
                strMessageParam[0] = htOutputParameter["UserLoginName"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0001, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                //记录日志结束

                //添加用户在线信息开始
                //                RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationData appData = new RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationData();
                //                RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic instanceT_PM_UserOnlineInfoApplicationLogic
                //= (RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic));
                //                appData.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];
                //                appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                //                instanceT_PM_UserOnlineInfoApplicationLogic.Delete(appData);
                //                appData.AccessDate = DateTime.Now;
                //                appData.AccessIP = RICH.Common.IM.IPAddessLibrary.GetRemoteTrueIP();
                //                //appData.AccessLocation = RICH.Common.IM.IPAddessLibrary.GetLocationFromIP(appData.AccessIP.ToString());
                //                appData = instanceT_PM_UserOnlineInfoApplicationLogic.Add(appData);
                //添加用户在线信息结束

                //对正确消息进行处理
                Response.Write(strMessageInfo);
                Response.Redirect(this.IsMobileDevice() && chkSaveLoginStatus.Checked
                                      ? "Default.aspx?lcode={0}".FormatInvariantCulture(htOutputParameter["lcode"])
                                      : "Default.aspx");
            }
            else
            {
                //记录日志开始
                string strLogTypeID = "A01";
                strMessageParam[0] = htOutputParameter["UserLoginName"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0002, strMessageParam);
                LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
                //记录日志结束

                strMessageInfo = MessageManager.GetMessageInfo((string)htOutputParameter[ConstantsManager.MESSAGE_ID], strMessageInfo);
                //对错误消息进行处理
                Session.Remove(ConstantsManager.SESSION_CURRENT_PURVIEW);
                MessageLabel.Text = strMessageInfo;
            }
        }
        else
        {
            //对错误消息进行处理
            Session.Remove(ConstantsManager.SESSION_CURRENT_PURVIEW);
            MessageLabel.Text = strMessageInfo;
        }
    }
    private Boolean ValidateInputParameter()
    {
        Boolean boolReturn = true;
        //UserLoginName输入检验
        if (DataValidateManager.ValidateIsNull(htInputParameter["UserLoginName"])
            || DataValidateManager.ValidateStringLengthRange(htInputParameter["UserLoginName"], 1, 50) == false)
        {
            strMessageParam[0] = "用户登录名";
            strMessageParam[1] = "1";
            strMessageParam[2] = "50";
            strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
            boolReturn = false;
        }
        //Password输入检验
        if (DataValidateManager.ValidateIsNull(htInputParameter["Password"]) == true
            || DataValidateManager.ValidateStringLengthRange(htInputParameter["Password"], 1, 20) == false)
        {
            strMessageParam[0] = "用户密码";
            strMessageParam[1] = "1";
            strMessageParam[2] = "20";
            strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
            boolReturn = false;
        }
        return boolReturn;
    }
}
