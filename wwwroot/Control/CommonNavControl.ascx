<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommonNavControl.ascx.cs" Inherits="CommonNavControl" %>
<%@ Import Namespace="RICH.Common" %>
<ul class="nav navbar-inverse">
    <asp:Repeater ID="NavList" runat="server">
        <ItemTemplate>
            <li class="dropdown col-sm-3 col-xs-3 text-center" style="padding-right:0px !important;padding-left:0px !important;"><a href="#" class="dropdown-toggle"
                data-toggle="dropdown">
                <%# DataBinder.Eval(Container.DataItem, "MenuLevelName")%><b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <asp:Repeater ID="SubNavList" runat="server" DataSource='<%# GetSubMenu((string)DataBinder.Eval(Container.DataItem, "UserGroupID"), (string)DataBinder.Eval(Container.DataItem, "PurviewID")) %>'>
                        <ItemTemplate>
                            <li><a href="<%# GetAppUrl((string)DataBinder.Eval(Container.DataItem, "PageFilePath"), (string)DataBinder.Eval(Container.DataItem, "PageFileName"))%>">
                                <%# DataBinder.Eval(Container.DataItem, "PurviewName")%></a></li></ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <li class="dropdown col-sm-3 col-xs-3 text-center" style="padding-right:0px !important;padding-left:0px !important;"><a href="#" class="dropdown-toggle"
        data-toggle="dropdown">其他<b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a id="linkDefaultIndex" runat="server">首页</a></li>
            <li>
                <asp:Repeater ID="UserGroupList" runat="server">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton ID="SwitchUserGroup" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Key")%>' OnClick="SwitchUserGroup_OnSelectedIndexChanged">
                            <%# DataBinder.Eval(Container.DataItem, "Value")%></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </li>
            <li><a href="/Administrator/LoginOut.aspx">退出</a></li>
        </ul>
    </li>
</ul>
