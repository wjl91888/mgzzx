<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Menu.aspx.cs" Inherits="Administrator_Default_Menu" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=RICH.Common.ConstantsManager.WEBSITE_NAME%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/jQuery/jquery-1.11.3.js"></script>
    <script type="text/javascript" src="../App_Themes/Themes/JavaScript/Common/Common.js"></script>
    <link href="../App_Themes/Themes/Css/mainstyle.css" type="text/css" rel="stylesheet" />
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="../bootstrap-3.3.2-dist/css/bootstrap.min.css" />
    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="../bootstrap-3.3.2-dist/css/bootstrap-theme.min.css" />
    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="../bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
</head>
<body class="leftback" style="margin: 0px;" topmargin="2" scroll="auto">
    <form id="submitForm" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramMenu" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlUserGroupID">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AjaxArea" LoadingPanelID="ralpMenu" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpMenu" runat="server" Skin="Vista">
    </telerik:RadAjaxLoadingPanel>
    <div style="width: 100%; color:#FF7D08;">
        <div style="vertical-align: middle; filter: progid:DXImageTransform.Microsoft.Shadow(Color=#e5e5e5,Direction=150,strength=5);
            font-size: 20px; font-family: 黑体; line-height: 24px; padding-left: 10px;">
            <asp:Literal ID="websiteName" runat="server"></asp:Literal>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div style="text-align: center; padding-top: 10px; color:#ffffff;">
        <a id="linkDefaultIndex" runat="server" target="ContentFrame">首页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
            href="LoginOut.aspx" target="_top">退出</a>
    </div>
    <div class="leftframetable" style="width: 95%; text-align: left; border-width: 1px;
        margin-left: 2px; margin-bottom: 3px;">
            <telerik:RadComboBox ID="ddlUserGroupID" runat="server" Font-Size="14px" AutoPostBack="true" OnSelectedIndexChanged="ddlUserGroupID_OnSelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>
    </div>
    <div id="AjaxArea" runat="server">
        <telerik:RadTreeView ID="rtvMenu" runat="server" OnNodeDataBound="rtvMenu_NodeDataBound" Font-Size="14px" Font-Bold="true" ForeColor="#ffffff" CssClass="IndexMenuStyle">
        </telerik:RadTreeView>
    </div>
    </form>
</body>
</html>
