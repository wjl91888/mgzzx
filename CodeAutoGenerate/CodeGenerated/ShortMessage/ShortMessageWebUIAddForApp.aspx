<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ShortMessageWebUIAdd.aspx.cs" Inherits="App.ShortMessageWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">消息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=DXXNR.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_DXXNR_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramShortMessage" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramShortMessage" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpShortMessage" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DXXBTContainer" runat="server" class="row">
                <div id="DXXBTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">标题</div>
                <div id="DXXBTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="DXXBT" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="DXXLXContainer" runat="server" class="row">
                <div id="DXXLXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">类型</div>
                <div id="DXXLXContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="DXXLX" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="DXXNRContainer" runat="server" class="row">
                <div id="DXXNRCaption" runat="server" class="fontbold col-xs-12 paddingleft0">内容</div>
                <div id="DXXNRContent" runat="server" class="col-xs-12">
                                
                             <FTB:FreeTextBox ID="DXXNR" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="DXXFJContainer" runat="server" class="row">
                <div id="DXXFJCaption" runat="server" class="fontbold col-xs-12 paddingleft0">附件</div>
                <div id="DXXFJContent" runat="server" class="col-xs-12">
                                
                             <control:FilesList ID="DXXFJ" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="FSSJContainer" runat="server" class="row">
                <div id="FSSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送时间</div>
                <div id="FSSJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FSSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FSRContainer" runat="server" class="row">
                <div id="FSRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送人</div>
                <div id="FSRContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FSR" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FSBMContainer" runat="server" class="row">
                <div id="FSBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送部门</div>
                <div id="FSBMContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FSBM" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FSIPContainer" runat="server" class="row">
                <div id="FSIPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发送IP</div>
                <div id="FSIPContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FSIP" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JSRContainer" runat="server" class="row">
                <div id="JSRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">接收人</div>
                <div id="JSRContent" runat="server" class="col-xs-9">
                                
                             <control:ComboTreeView ID="JSR" runat="server" CssClass="input widthfull"></control:ComboTreeView>
                                                 
                </div>
            </div>
  
            <div id="SFCKContainer" runat="server" class="row">
                <div id="SFCKCaption" runat="server" class="fontbold col-xs-3 paddingleft0">查看状态</div>
                <div id="SFCKContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SFCK" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="CKSJContainer" runat="server" class="row">
                <div id="CKSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">查看时间</div>
                <div id="CKSJContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="CKSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

