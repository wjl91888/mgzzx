<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ShortMessageWebUIDetail.aspx.cs" Inherits="App.ShortMessageWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    ��Ϣ
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DXXBT"), null)%></h4>
            </div>

    
            <div id="DXXBTCaption" runat="server" class="fontbold col-xs-4 paddingleft0">����</div>
            <div id="DXXBTContent" runat="server" class="col-xs-8">
        
                <%# GetValue(DataBinder.Eval(Container.DataItem, "DXXBT"), null)%>
                
            </div>
        
            <div id="DXXNRCaption" runat="server" class="fontbold col-xs-4 paddingleft0">����</div>
            <div id="DXXNRContent" runat="server" class="col-xs-8">
        
                <%# GetValue(DataBinder.Eval(Container.DataItem, "DXXNR"), null)%>
                
            </div>
        
            <div id="DXXFJCaption" runat="server" class="fontbold col-xs-4 paddingleft0">����</div>
            <div id="DXXFJContent" runat="server" class="col-xs-8">
        
                <control:FilesList ID="DXXFJ" runat="server" CssClass="input" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "DXXFJ")%>'></control:FilesList>
                
            </div>
        
            <div id="FSSJCaption" runat="server" class="fontbold col-xs-4 paddingleft0">����ʱ��</div>
            <div id="FSSJContent" runat="server" class="col-xs-8">
        
                <%# GetValue(DataBinder.Eval(Container.DataItem, "FSSJ"), null)%>
                
            </div>
        
            <div id="FSRCaption" runat="server" class="fontbold col-xs-4 paddingleft0">������</div>
            <div id="FSRContent" runat="server" class="col-xs-8">
        
                <%# DataBinder.Eval(Container.DataItem, "FSR_T_PM_UserInfo_UserNickName")%>
        
            </div>
        
            <div id="FSBMCaption" runat="server" class="fontbold col-xs-4 paddingleft0">���Ͳ���</div>
            <div id="FSBMContent" runat="server" class="col-xs-8">
        
                <%# DataBinder.Eval(Container.DataItem, "FSBM_T_BM_DWXX_DWMC")%>
        
            </div>
        
            <div id="JSRCaption" runat="server" class="fontbold col-xs-4 paddingleft0">������</div>
            <div id="JSRContent" runat="server" class="col-xs-8">
        
                <%# DataBinder.Eval(Container.DataItem, "JSR_T_PM_UserInfo_UserNickName")%>
        
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>


