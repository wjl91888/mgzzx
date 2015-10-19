<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_DWXXWebUIAdd.aspx.cs" Inherits="App.T_BM_DWXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">单位信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_DWXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_DWXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DWBHContainer" runat="server" class="row">
                <div id="DWBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">单位编号</div>
                <div id="DWBHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DWBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DWMCContainer" runat="server" class="row">
                <div id="DWMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">单位名称</div>
                <div id="DWMCContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DWMC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SJDWBHContainer" runat="server" class="row">
                <div id="SJDWBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上级单位</div>
                <div id="SJDWBHContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SJDWBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="DZContainer" runat="server" class="row">
                <div id="DZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">地址</div>
                <div id="DZContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DZ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YBContainer" runat="server" class="row">
                <div id="YBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">邮编</div>
                <div id="YBContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="YB" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LXBMContainer" runat="server" class="row">
                <div id="LXBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系部门</div>
                <div id="LXBMContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LXBM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LXDHContainer" runat="server" class="row">
                <div id="LXDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系电话</div>
                <div id="LXDHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LXDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="EmailContainer" runat="server" class="row">
                <div id="EmailCaption" runat="server" class="fontbold col-xs-3 paddingleft0">Email</div>
                <div id="EmailContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="Email" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LXRContainer" runat="server" class="row">
                <div id="LXRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系人</div>
                <div id="LXRContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LXR" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SJContainer" runat="server" class="row">
                <div id="SJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">手机</div>
                <div id="SJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

