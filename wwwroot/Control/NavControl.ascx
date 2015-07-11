<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavControl.ascx.cs" Inherits="NavControl" %>
<%@ Import Namespace="RICH.Common" %>
<ul class="nav navbar-nav">
    <li><a id="linkDefaultIndex" runat="server">Ê×Ò³</a></li>
    <asp:Repeater ID="NavList" runat="server">
        <ItemTemplate>
            <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <%# DataBinder.Eval(Container.DataItem, "MenuLevelName")%><b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <asp:Repeater ID="SubNavList" runat="server" DataSource='<%# GetSubMenu((string)DataBinder.Eval(Container.DataItem, "UserGroupID"), (string)DataBinder.Eval(Container.DataItem, "PurviewID")) %>'>
                        <ItemTemplate>
                            <li><a href="<%# "{0}/{1}".FormatInvariantCulture(DataBinder.Eval(Container.DataItem, "PageFilePath"), DataBinder.Eval(Container.DataItem, "PageFileName"))%>">
                                <%# DataBinder.Eval(Container.DataItem, "PurviewName")%></a></li></ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <li><a href="/Administrator/LoginOut.aspx">ÍË³ö</a></li>
</ul>
