<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DictionaryWebUIDetail.aspx.cs" Inherits="App.DictionaryWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    Dictionary
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DM"), null)%></h4>
            </div>
    
            <div id="DMContainer" runat="server" class="row">
                <div id="DMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">代码</div>
                <div id="DMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DM"), null)%>
                
                </div>
            </div>
        
            <div id="LXContainer" runat="server" class="row">
                <div id="LXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">类型</div>
                <div id="LXContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "LX_DictionaryType_MC")%>
        
                </div>
            </div>
        
            <div id="MCContainer" runat="server" class="row">
                <div id="MCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">名称</div>
                <div id="MCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "MC"), null)%>
                
                </div>
            </div>
        
            <div id="SJDMContainer" runat="server" class="row">
                <div id="SJDMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上级代码</div>
                <div id="SJDMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SJDM_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="SMContainer" runat="server" class="row">
                <div id="SMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">说明</div>
                <div id="SMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SM"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="修改" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


