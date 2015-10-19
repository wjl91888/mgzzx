<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ShortMessageWebUIDetail.aspx.cs" Inherits="App.ShortMessageWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    消息
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
    
            <div id="DXXBTContainer" runat="server" class="row">
                <div id="DXXBTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">标题</div>
                <div id="DXXBTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DXXBT"), null)%>
                
                </div>
            </div>
        
            <div id="DXXNRContainer" runat="server" class="row">
                <div id="DXXNRCaption" runat="server" class="fontbold col-xs-12 paddingleft0">内容</div>
                <div id="DXXNRContent" runat="server" class="col-xs-12">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DXXNR"), null)%>
                
                </div>
            </div>
        
            <div id="DXXFJContainer" runat="server" class="row">
                <div id="DXXFJCaption" runat="server" class="fontbold col-xs-12 paddingleft0">附件</div>
                <div id="DXXFJContent" runat="server" class="col-xs-12">
        
                    <control:FilesList ID="DXXFJ" runat="server" CssClass="input" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "DXXFJ")%>'></control:FilesList>
                
                </div>
            </div>
        
            <div id="FSSJContainer" runat="server" class="row">
                <div id="FSSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送时间</div>
                <div id="FSSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FSSJ"), "yy-MM-dd HH:mm")%>
                
                </div>
            </div>
        
            <div id="FSRContainer" runat="server" class="row">
                <div id="FSRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送人</div>
                <div id="FSRContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "FSR_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="FSBMContainer" runat="server" class="row">
                <div id="FSBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送部门</div>
                <div id="FSBMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "FSBM_T_BM_DWXX_DWMC")%>
        
                </div>
            </div>
        
            <div id="JSRContainer" runat="server" class="row">
                <div id="JSRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">接收人</div>
                <div id="JSRContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "JSR_T_PM_UserInfo_UserNickName")%>
        
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


