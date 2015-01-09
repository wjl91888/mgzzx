<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Login"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="IdentifyCode" Src="~/Control/IdentifyCodeControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-cn">
<head runat="server">
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        <%=System.Configuration.ConfigurationSettings.AppSettings["WEBSITE_NAME"]%></title>
    <link href="/App_Themes/Themes/Css/mainstyle.css" rev="stylesheet" rel="stylesheet"
        type="text/css" media="screen" charset="gb2312" />
    <link href="/App_Themes/Themes/JavaScript/fancybox/jquery.fancybox-1.3.4.css" rev="stylesheet"
        rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/jQuery/jquery-1.4.2.js"
        language="javascript" charset="gb2312"></script>
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/fancybox/jquery.fancybox-1.3.4.pack.js"
        language="javascript" charset="gb2312"></script>
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/Common/Common.js"
        language="javascript" charset="gb2312"></script>
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/Common/CommonNew.js"
        language="javascript" charset="gb2312"></script>
    <style type="text/css">
        .a12
        {
            font-size: 12px;
            line-height: 23px;
            text-decoration: none;
        }
        A:link
        {
            font-size: 12px;
            color: #000000;
            line-height: 23px;
            text-decoration: none;
        }
        A:visited
        {
            font-size: 12px;
            color: #990000;
            line-height: 23px;
            text-decoration: none;
        }
        A:hover
        {
            font-size: 12px;
            color: #ff6600;
            line-height: 23px;
            text-decoration: underline;
        }
        BODY
        {
            margin-top: 0px;
        }
        .login
        {
            border-right: #cccccc 1px solid;
            border-top: #cccccc 1px solid;
            border-left: #cccccc 1px solid;
            border-bottom: #cccccc 1px solid;
            background-color: #ffffff;
        }
        .textline
        {
            border-right: #999999 1px;
            border-top: #999999 1px;
            border-left: #999999 1px;
            border-bottom: #999999 1px solid;
            background-color: #ffffff;
        }
        .a12red
        {
            font-size: 12px;
            color: #990000;
            line-height: 23px;
            text-decoration: none;
        }
    </style>
    <script language="javascript" type="text/javascript">
        if (window != top) {
            top.location.href = "login.aspx";
        }
    </script>
</head>
<body style="margin: 60px auto 0px auto;">
    <form id="SubmitForm" runat="server">
    <script language="javascript" type="text/javascript">
        function GetCookie(sName) {
            //��=ֵ;��=ֵ;   
            var aCookie = document.cookie.split("; ");
            for (var i = 0; i < aCookie.length; i++) {
                //alert(unescape(aCookie[i])) ;
                //   ��=ֵ   
                var aCrumb = aCookie[i].split("=");
                if (sName == aCrumb[0]) {
                    return unescape(aCrumb[1]);
                }
            }
            return "";
        }   
    </script>
    <center>
        <table class="a12" cellspacing="0" cellpadding="0" width="476" align="center" background="/App_Themes/Themes/Image/login_bg.gif"
            border="0">
            <tbody>
                <tr>
                    <td valign="top">
                        <img height="100" src="/App_Themes/Themes/Image/login1.gif" width="477">
                    </td>
                </tr>
                <tr>
                    <td align="middle" height="100">
                        <form name="form1" action="checklogin.asp" method="post">
                        <table class="a12" cellspacing="0" cellpadding="0" width="300" align="center" border="0">
                            <tbody>
                                <tr align="middle" bgcolor="#ffffff">
                                    <td colspan="2" height="38">
                                        <%=System.Configuration.ConfigurationSettings.AppSettings["WEBSITE_NAME"]%>
                                    </td>
                                </tr>
                                <tr align="middle" bgcolor="#ffffff">
                                    <td colspan="2">
                                        <div>
                                            <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"></asp:Label></div>
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="middle" width="100" bgcolor="#ffffff" height="28">
                                        �û�����
                                    </td>
                                    <td align="left" width="320" height="28">
                                        <asp:TextBox ID="txtUserLoginName" runat="server" CssClass="textline" Style="width: 200px"
                                            name="name"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="middle" width="100" bgcolor="#ffffff" height="28">
                                        ��&nbsp;&nbsp;�룺
                                    </td>
                                    <td align="left" width="320" height="28">
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textline" Style="width: 200px"
                                            name="name" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="middle" width="100" bgcolor="#ffffff" height="28">
                                        ��֤�룺
                                    </td>
                                    <td align="left" width="320" height="28">
                                        <asp:TextBox ID="txtIdentifyCode" runat="server" CssClass="input_1" MaxLength="10"
                                            Style="width: 40px" size="10" name="VerifyCode"></asp:TextBox>
                                        &nbsp;&nbsp;������<asp:Image ID="imgIdentifyCode" runat="server" Height="16px" />
                                    </td>
                                </tr>
                                <tr bgcolor="#ffffff">
                                    <td align="middle" bgcolor="#ffffff" colspan="2" height="38">
                                        <asp:Button ID="btnLogin" runat="server" Text="ȷ����½" CssClass="login" OnClick="btnLogin_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnRefresh" runat="server" Text="ˢ�±�ҳ" CssClass="login" />
                                        &nbsp;&nbsp; <a id="btnRegUser" class="fancyboxlink" href="RegUser.aspx">ע���û�</a>
                                        &nbsp;&nbsp; <a id="btnForgetPassword" class="fancyboxlink" href="ForgetPassword.aspx">�һ�����</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        </form>
                    </td>
                </tr>
                <tr>
                    <td valign="bottom">
                        <img height="11" src="/App_Themes/Themes/Image/login2.gif" width="477">
                    </td>
                </tr>
            </tbody>
        </table>
    </center>
    </form>
</body>
</html>
