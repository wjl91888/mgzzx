<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUIAdd.aspx.cs" Inherits="App.T_BG_0601WebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">公共信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .ctl00_MainContentPlaceHolder_XXNR_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BG_0601" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0601" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FBHContainer" runat="server" class="row">
                <div id="FBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布号</div>
                <div id="FBHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="BTContainer" runat="server" class="row">
                <div id="BTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">标题</div>
                <div id="BTContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BT" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FBLMContainer" runat="server" class="row">
                <div id="FBLMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布栏目</div>
                <div id="FBLMContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="FBLM" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="FBBMContainer" runat="server" class="row">
                <div id="FBBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布部门</div>
                <div id="FBBMContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="FBBM" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="XXLXContainer" runat="server" class="row">
                <div id="XXLXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">信息类型</div>
                <div id="XXLXContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="XXLX" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="XXTPDZContainer" runat="server" class="row">
                <div id="XXTPDZCaption" runat="server" class="fontbold col-xs-12 paddingleft0">信息图片</div>
                <div id="XXTPDZContent" runat="server" class="col-xs-12">
                                
                             <control:FilesList ID="XXTPDZ" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="XXNRContainer" runat="server" class="row">
                <div id="XXNRCaption" runat="server" class="fontbold col-xs-12 paddingleft0">信息内容</div>
                <div id="XXNRContent" runat="server" class="col-xs-12">
                                
                             <FTB:FreeTextBox ID="XXNR" runat="server" Language="zh-cn"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste,Delete;Undo,Redo,Print|InsertTable, EditTable, InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn|InsertDiv, Preview, SelectAll, EditStyle"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="FJXZDZContainer" runat="server" class="row">
                <div id="FJXZDZCaption" runat="server" class="fontbold col-xs-12 paddingleft0">附件</div>
                <div id="FJXZDZContent" runat="server" class="col-xs-12">
                                
                             <control:FilesList ID="FJXZDZ" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="XXZTContainer" runat="server" class="row">
                <div id="XXZTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">信息状态</div>
                <div id="XXZTContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="XXZT" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="IsTopContainer" runat="server" class="row">
                <div id="IsTopCaption" runat="server" class="fontbold col-xs-3 paddingleft0">是否置顶</div>
                <div id="IsTopContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="IsTop" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="TopSortContainer" runat="server" class="row">
                <div id="TopSortCaption" runat="server" class="fontbold col-xs-3 paddingleft0">置顶序号</div>
                <div id="TopSortContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="TopSort" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="IsBestContainer" runat="server" class="row">
                <div id="IsBestCaption" runat="server" class="fontbold col-xs-3 paddingleft0">推荐</div>
                <div id="IsBestContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="IsBest" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="FBRJGHContainer" runat="server" class="row">
                <div id="FBRJGHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布人</div>
                <div id="FBRJGHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FBRJGH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FBSJRQContainer" runat="server" class="row">
                <div id="FBSJRQCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布时间</div>
                <div id="FBSJRQContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FBSJRQ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="FBIPContainer" runat="server" class="row">
                <div id="FBIPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布IP</div>
                <div id="FBIPContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="FBIP" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

