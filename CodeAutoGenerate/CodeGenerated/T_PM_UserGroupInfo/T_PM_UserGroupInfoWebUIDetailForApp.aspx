<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_PM_UserGroupInfoWebUIDetail.aspx.cs" Inherits="App.T_PM_UserGroupInfoWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    用户组信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupName"), null)%></h4>
            </div>
    
            <div id="UserGroupIDContainer" runat="server" class="row">
                <div id="UserGroupIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户组编号</div>
                <div id="UserGroupIDContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupID"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupNameContainer" runat="server" class="row">
                <div id="UserGroupNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户组名称</div>
                <div id="UserGroupNameContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupName"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupContentContainer" runat="server" class="row">
                <div id="UserGroupContentCaption" runat="server" class="fontbold col-xs-3 paddingleft0">内容</div>
                <div id="UserGroupContentContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupContent"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupRemarkContainer" runat="server" class="row">
                <div id="UserGroupRemarkCaption" runat="server" class="fontbold col-xs-3 paddingleft0">备注</div>
                <div id="UserGroupRemarkContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupRemark"), null)%>
                
                </div>
            </div>
        
            <div id="DefaultPageContainer" runat="server" class="row">
                <div id="DefaultPageCaption" runat="server" class="fontbold col-xs-3 paddingleft0">系统默认页</div>
                <div id="DefaultPageContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DefaultPage"), null)%>
                
                </div>
            </div>
        
            <div id="UpdateDateContainer" runat="server" class="row">
                <div id="UpdateDateCaption" runat="server" class="fontbold col-xs-3 paddingleft0">更新时间</div>
                <div id="UpdateDateContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UpdateDate"), null)%>
                
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


