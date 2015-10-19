<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0602WebUIAdd.aspx.cs" Inherits="App.T_BG_0602WebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">公共信息栏目编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=LMNR.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_LMNR_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BG_0602" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BG_0602" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0602" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LMHContainer" runat="server" class="row">
                <div id="LMHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">栏目号</div>
                <div id="LMHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LMH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LMMContainer" runat="server" class="row">
                <div id="LMMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">栏目名</div>
                <div id="LMMContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LMM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SJLMHContainer" runat="server" class="row">
                <div id="SJLMHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上级栏目</div>
                <div id="SJLMHContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SJLMH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="LMTPContainer" runat="server" class="row">
                <div id="LMTPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">栏目图片</div>
                <div id="LMTPContent" runat="server" class="col-xs-9">
                                
                             <control:FilesList ID="LMTP" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="LMNRContainer" runat="server" class="row">
                <div id="LMNRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">栏目显示内容</div>
                <div id="LMNRContent" runat="server" class="col-xs-9">
                                
                             <FTB:FreeTextBox ID="LMNR" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="LMLBYSContainer" runat="server" class="row">
                <div id="LMLBYSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">栏目列表样式</div>
                <div id="LMLBYSContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="LMLBYS" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="SFLBLMContainer" runat="server" class="row">
                <div id="SFLBLMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">列表内容栏目</div>
                <div id="SFLBLMContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SFLBLM" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="SFWBURLContainer" runat="server" class="row">
                <div id="SFWBURLCaption" runat="server" class="fontbold col-xs-3 paddingleft0">外部栏目</div>
                <div id="SFWBURLContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SFWBURL" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="WBURLContainer" runat="server" class="row">
                <div id="WBURLCaption" runat="server" class="fontbold col-xs-3 paddingleft0">外部栏目连接</div>
                <div id="WBURLContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="WBURL" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

