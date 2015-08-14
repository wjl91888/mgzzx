<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageNavControl.ascx.cs"
    Inherits="PageNavControl" %>
<%@ Import Namespace="RICH.Common" %>
<ul class="nav navbar-inverse">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important;padding-left: 0px !important;">
        <a data-toggle="collapse" href="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
            <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
        </a>
    </li>
    <asp:Repeater ID="NavList" runat="server">
        <ItemTemplate>
            <li class="dropdown col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important;
                padding-left: 0px !important;"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                    <%# DataBinder.Eval(Container.DataItem, "Key")%><b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <asp:Repeater ID="NavList" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Value") %>'>
                        <ItemTemplate>
                            <li><a href="<%# "{0}&{1}={2}".FormatInvariantCulture(CurrentUrl, DataBinder.Eval(Container.DataItem, "Extend"), DataBinder.Eval(Container.DataItem, "Key"))%>">
                                <%# DataBinder.Eval(Container.DataItem, "Value")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<div class="collapse" id="collapseExample">
  <div class="well">
    <div class="input-group">
      <span class="input-group-addon glyphicon glyphicon-search" aria-hidden="true"></span>
      <input type="text" class="form-control needrefresh" name="SearchKeywords" placeholder="查找关键字" aria-describedby="basic-addon1">
    </div>
  </div>
</div>
