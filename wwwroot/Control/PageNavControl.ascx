<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageNavControl.ascx.cs"
    Inherits="PageNavControl" %>
<%@ Import Namespace="RICH.Common" %>
<ul class="nav navbar-inverse">
    <li class="dropdown col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important;
        padding-left: 0px !important;"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
            信息<b class="caret"></b></a>
        <ul class="dropdown-menu">
            <asp:Repeater ID="NavList" runat="server">
                <ItemTemplate>
                    <li><a href="<%# "{0}?{1}={2}".FormatInvariantCulture(CurrentUrl, DataBinder.Eval(Container.DataItem, "FieldName"), DataBinder.Eval(Container.DataItem, "FieldValue"))%>">
                        <%# DataBinder.Eval(Container.DataItem, "Name")%></a></li></ItemTemplate>
            </asp:Repeater>
        </ul>
    </li>
</ul>
