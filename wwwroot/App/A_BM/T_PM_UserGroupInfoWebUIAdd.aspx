<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_PM_UserGroupInfoWebUIAdd.aspx.cs" Inherits="App.T_PM_UserGroupInfoWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">用户组信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=UserGroupContent.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_UserGroupContent_DesignBox { background-color: #ffffff !important;}    table.<%=UserGroupRemark.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_UserGroupRemark_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_PM_UserGroupInfo" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_PM_UserGroupInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_PM_UserGroupInfo" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserGroupIDContainer" runat="server" class="row">
                <div id="UserGroupIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户组编号</div>
                <div id="UserGroupIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UserGroupID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserGroupNameContainer" runat="server" class="row">
                <div id="UserGroupNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户组名称</div>
                <div id="UserGroupNameContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UserGroupName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserGroupContentContainer" runat="server" class="row">
                <div id="UserGroupContentCaption" runat="server" class="fontbold col-xs-3 paddingleft0">内容</div>
                <div id="UserGroupContentContent" runat="server" class="col-xs-9">
                                
                             <FTB:FreeTextBox ID="UserGroupContent" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="UserGroupRemarkContainer" runat="server" class="row">
                <div id="UserGroupRemarkCaption" runat="server" class="fontbold col-xs-3 paddingleft0">备注</div>
                <div id="UserGroupRemarkContent" runat="server" class="col-xs-9">
                                
                             <FTB:FreeTextBox ID="UserGroupRemark" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="DefaultPageContainer" runat="server" class="row">
                <div id="DefaultPageCaption" runat="server" class="fontbold col-xs-3 paddingleft0">系统默认页</div>
                <div id="DefaultPageContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DefaultPage" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UpdateDateContainer" runat="server" class="row">
                <div id="UpdateDateCaption" runat="server" class="fontbold col-xs-3 paddingleft0">更新时间</div>
                <div id="UpdateDateContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UpdateDate" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
        </div>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
  <ul id="PageInfo" runat="server" class="nav  navbar-default">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
      <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="btn btn-default navbar-btn" OnClick="btnSave_Click" />
    </li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
  </ul>
</asp:Content>

