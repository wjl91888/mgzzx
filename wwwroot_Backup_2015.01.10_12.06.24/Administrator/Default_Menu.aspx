<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Menu.aspx.cs" Inherits="Administrator_Default_Menu" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=RICH.Common.ConstantsManager.WEBSITE_NAME%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="IE=7" http-equiv="X-UA-Compatible" />
    <script type="text/javascript" src="/App_Themes/Themes/JavaScript/Common/Common.js"
        language="javascript" charset="gb2312"></script>
    <link href="/App_Themes/Themes/Css/mainstyle.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        ul
        {
            list-style-type: none;
            list-style-position: outside;
            margin: 0px;
            padding: 0px;
        }
    </style>
    <script language="JavaScript" type="text/JavaScript">
        function opensubmenu(menuid, tagname, submenuid) {

            for (i = 0; i < document.getElementById(menuid).getElementsByTagName(tagname).length; i++) {
                if (document.getElementById(menuid).getElementsByTagName(tagname).item(i).id != ''
            && document.getElementById(menuid).getElementsByTagName(tagname).item(i).id != submenuid) {
                    document.getElementById(menuid).getElementsByTagName(tagname).item(i).style.display = "none";
                }

            }
            if (document.getElementById(submenuid).style.display == "none") {
                document.getElementById(submenuid).style.display = "";
            }
            else {
                document.getElementById(submenuid).style.display = "none";
            }
        }
    </script>
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
    <div style="width: 100%;">
        <div style="vertical-align: middle; filter: progid:DXImageTransform.Microsoft.Shadow(Color=#e5e5e5,Direction=150,strength=5);
            font-size: 20px; font-family: 黑体; line-height: 24px; padding-left: 10px;">
            <asp:Literal ID="websiteName" runat="server"></asp:Literal>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div style="text-align: center; padding-top: 10px;">
        <a id="linkDefaultIndex" runat="server" target="ContentFrame">首页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
            href="LoginOut.aspx" target="_top">退出</a>
    </div>
    <ul class="leftframetable" style="width: 95%; text-align: left; border-width: 1px;
        margin-left: 2px; margin-bottom: 3px;">
        <li>
            <telerik:RadComboBox ID="ddlUserGroupID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserGroupID_OnSelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>
        </li>
    </ul>
    <div id="AjaxArea" runat="server">
        <asp:Label ID="lblMenu" runat="server"></asp:Label>
        <div style="clear: both;">
        </div>
    </div>
    </form>
</body>
</html>
