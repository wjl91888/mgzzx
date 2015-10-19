<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FilterReportWebUIDetail.aspx.cs" Inherits="App.FilterReportWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    报表信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGMC"), null)%></h4>
            </div>
    
            <div id="BGMCContainer" runat="server" class="row">
                <div id="BGMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报表名称</div>
                <div id="BGMCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGMC"), null)%>
                
                </div>
            </div>
        
            <div id="UserIDContainer" runat="server" class="row">
                <div id="UserIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户编号</div>
                <div id="UserIDContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "UserID_T_PM_UserInfo_UserLoginName")%>
        
                </div>
            </div>
        
            <div id="BGLXContainer" runat="server" class="row">
                <div id="BGLXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报告类型</div>
                <div id="BGLXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGLX"), null)%>
                
                </div>
            </div>
        
            <div id="GXBGContainer" runat="server" class="row">
                <div id="GXBGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">共享报告</div>
                <div id="GXBGContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "GXBG_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="XTBGContainer" runat="server" class="row">
                <div id="XTBGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">系统报告</div>
                <div id="XTBGContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "XTBG_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="BGCXTJContainer" runat="server" class="row">
                <div id="BGCXTJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报告条件</div>
                <div id="BGCXTJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGCXTJ"), null)%>
                
                </div>
            </div>
        
            <div id="BGCJSJContainer" runat="server" class="row">
                <div id="BGCJSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">创建时间</div>
                <div id="BGCJSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGCJSJ"), null)%>
                
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


