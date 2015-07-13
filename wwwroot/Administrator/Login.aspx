<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Login"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="IdentifyCode" Src="~/Control/IdentifyCodeControl.ascx" %>
<!DOCTYPE html />
<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-cn">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="viewport" content="width=device-width,height=device-height,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["WEBSITE_NAME"]%></title>
    <!-- �� Bootstrap ���� CSS �ļ� -->
    <link rel="stylesheet" href="../bootstrap-3.3.2-dist/css/bootstrap.min.css" />
    <!-- ��ѡ��Bootstrap�����ļ���һ�㲻�����룩 -->
    <link rel="stylesheet" href="../bootstrap-3.3.2-dist/css/bootstrap-theme.min.css" />
    <link href="../fancyapps-fancyBox-18d1712/source/jquery.fancybox.css" rel="stylesheet"/>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/jQuery/jquery-1.10.1.min.js"></script>
    <!-- ���µ� Bootstrap ���� JavaScript �ļ� -->
    <script src="../bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../fancyapps-fancyBox-18d1712/source/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/Common/Common.js"></script>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/Common/CommonNew.js"></script>
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
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="text-danger">
                    <asp:Label ID="MessageLabel" runat="server"></asp:Label></div>
                <form role="form">
                <legend>
                    <%=ConfigurationManager.AppSettings["WEBSITE_NAME"]%></legend>
                <div class="form-group">
                    <label for="txtUserLoginName">
                        �û���</label>
                    <asp:TextBox ID="txtUserLoginName" class="form-control" runat="server" placeholder="�������û���"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPassword">
                        ��&nbsp;&nbsp;��</label>
                    <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"
                        placeholder="����������"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtIdentifyCode">
                        ��֤��</label>
                    <asp:TextBox ID="txtIdentifyCode" runat="server" MaxLength="10" class="form-control"
                        placeholder="��������֤��"></asp:TextBox>
                    <p class="help-block">
                        ������<asp:Image ID="imgIdentifyCode" runat="server" Height="20" /></p>
                </div>
                <div class="form-group">
                    <label class="checkbox" for="chkSaveLoginStatus">
                    </label>
                    <asp:CheckBox ID="chkSaveLoginStatus" runat="server" data-toggle="checkbox" Text="�����¼״̬" />
                </div>
                <div class="form-group text-right">
                    <asp:Button ID="btnLogin" runat="server" Text="��¼" class="btn btn-primary" OnClick="btnLogin_Click" />
<%--                    <a id="btnRegUser" class="fancyboxlink btn btn-primary" href="RegUser.aspx">ע���û�</a>
                    <a id="btnForgetPassword" class="fancyboxlink btn btn-primary" href="ForgetPassword.aspx">�һ�����</a>--%>
                </div>
                </form>
            </div>
            <!-- /.col-md-12 -->
        </div>
        <!-- /.row -->
    </div>
    </form>
</body>
</html>
