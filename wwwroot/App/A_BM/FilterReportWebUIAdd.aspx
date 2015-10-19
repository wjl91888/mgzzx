<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FilterReportWebUIAdd.aspx.cs" Inherits="App.FilterReportWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">报表信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramFilterReport" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpFilterReport" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="BGMCContainer" runat="server" class="row">
                <div id="BGMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报表名称</div>
                <div id="BGMCContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BGMC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserIDContainer" runat="server" class="row">
                <div id="UserIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">用户编号</div>
                <div id="UserIDContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="UserID" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="BGLXContainer" runat="server" class="row">
                <div id="BGLXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报告类型</div>
                <div id="BGLXContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BGLX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="GXBGContainer" runat="server" class="row">
                <div id="GXBGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">共享报告</div>
                <div id="GXBGContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="GXBG" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="XTBGContainer" runat="server" class="row">
                <div id="XTBGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">系统报告</div>
                <div id="XTBGContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="XTBG" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="BGCXTJContainer" runat="server" class="row">
                <div id="BGCXTJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">报告条件</div>
                <div id="BGCXTJContent" runat="server" class="col-xs-9">
                                
                             <control:GridDataBind ID="BGCXTJ" runat="server"  EditMode="true" Visible="true" GridHeadText="条件||值" GridColumnName="TJ||TJDYZ" Width="100||100" ></control:GridDataBind>
                                                 
                </div>
            </div>
  
            <div id="BGCJSJContainer" runat="server" class="row">
                <div id="BGCJSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">创建时间</div>
                <div id="BGCJSJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BGCJSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

