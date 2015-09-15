<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DictionaryTypeWebUIDetail.aspx.cs" Inherits="App.DictionaryTypeWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    字典类型
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
                <div id="DMCaption" runat="server" class="fontbold col-xs- paddingleft0">类型代码</div>
                <div id="DMContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DM"), null)%>
                
                </div>
            </div>
        
            <div id="MCContainer" runat="server" class="row">
                <div id="MCCaption" runat="server" class="fontbold col-xs- paddingleft0">类型名称</div>
                <div id="MCContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "MC"), null)%>
                
                </div>
            </div>
        
            <div id="SMContainer" runat="server" class="row">
                <div id="SMCaption" runat="server" class="fontbold col-xs- paddingleft0">说明</div>
                <div id="SMContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SM"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>


