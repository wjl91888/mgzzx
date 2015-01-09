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
using System.IO;
using RICH.Common;


public partial class IdentifyCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //需要输出图象信息 要修改HTTP头
        Response.ClearContent();
        Response.ContentType = "image/Png";
        string strIdenteifyCode =IdentifyCodeLibrary.GetIdentifyCode(ConstantsManager.IDENTIFY_CODE_LENGTH, ConstantsManager.IDENTIFY_CODE_TYPE);
        Session[ConstantsManager.SESSION_IDENTIFY_CODE] = strIdenteifyCode;
        Response.Cookies.Add(new HttpCookie(ConstantsManager.SESSION_IDENTIFY_CODE, strIdenteifyCode));
        Response.BinaryWrite(IdentifyCodeLibrary.GetIdentifyCodeImage(strIdenteifyCode).ToArray());
        Response.End();
    }
}
