using System;
using System.Web.UI;
using RICH.Common;
using RICH.Common.LM;
public partial class LoginOut : Page
{
     #region 当前页面变量定义
    /// <summary>
    /// 用来存储消息信息的参数
    /// </summary>
    private string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //记录日志开始
        string strLogTypeID = "A01";
        strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0010, strMessageParam);
        LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
        //记录日志结束
        Request.Cookies.Remove(ConstantsManager.COOKIE_USER_ID);
        Response.Cookies[ConstantsManager.COOKIE_USER_ID].Expires = DateTime.Now.AddDays(-1);
        Request.Cookies.Remove(ConstantsManager.COOKIE_PASSWORD);
        Response.Cookies[ConstantsManager.COOKIE_PASSWORD].Expires = DateTime.Now.AddDays(-1);
        Request.Cookies.Remove(ConstantsManager.COOKIE_SAVE_LOGIN_STATUS);
        Response.Cookies[ConstantsManager.COOKIE_SAVE_LOGIN_STATUS].Expires = DateTime.Now.AddDays(-1);
        Session.Abandon();
        Response.Redirect("Login.Aspx");
    }
}
